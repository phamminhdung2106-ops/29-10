using System.Data;
using CafePOS.DTO;
using Microsoft.Data.SqlClient;

namespace CafePOS.DAL
{
    public class HoaDonDAL
    {
        /// <summary>
        /// Nạp các món đã gọi của hóa đơn chưa thanh toán tại bàn vào DataTable (SqlDataAdapter).
        /// </summary>
        public DataTable GetChiTietByBan(int maBan)
        {
            const string sql = @"
                SELECT ct.MaMon, m.TenMon, ct.SoLuong, ct.DonGia, ct.SoLuong * ct.DonGia AS ThanhTien
                FROM HoaDon hd
                INNER JOIN ChiTietHoaDon ct ON ct.MaHoaDon = hd.MaHoaDon
                INNER JOIN MonAn m ON m.MaMon = ct.MaMon
                WHERE hd.MaBan = @MaBan AND hd.TrangThai = 0
                ORDER BY m.TenMon";

            var dt = new DataTable("ChiTietHoaDon");
            using var conn = DatabaseHelper.CreateConnection();
            using var da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@MaBan", maBan);
            da.Fill(dt);
            return dt;
        }

        // ---------- các hàm dùng chung trong transaction ----------

        private static int? LayHoaDonChuaThanhToan(int maBan, SqlConnection conn, SqlTransaction tran)
        {
            using var cmd = DatabaseHelper.CreateCommand(
                "SELECT TOP 1 MaHoaDon FROM HoaDon WHERE MaBan = @MaBan AND TrangThai = 0 ORDER BY MaHoaDon DESC",
                conn, tran);
            cmd.Parameters.AddWithValue("@MaBan", maBan);
            object r = cmd.ExecuteScalar();
            return (r == null || r == DBNull.Value) ? (int?)null : Convert.ToInt32(r);
        }

        private static void DatTrangThaiBan(int maBan, string trangThai, SqlConnection conn, SqlTransaction tran)
        {
            using var cmd = DatabaseHelper.CreateCommand(
                "UPDATE BanAn SET TrangThai = @TT WHERE MaBan = @MaBan", conn, tran);
            cmd.Parameters.AddWithValue("@TT", trangThai);
            cmd.Parameters.AddWithValue("@MaBan", maBan);
            cmd.ExecuteNonQuery();
        }

        // ---------- nghiệp vụ ----------

        /// <summary>
        /// Thêm món vào hóa đơn của bàn. Nếu bàn chưa có hóa đơn thì tạo mới.
        /// Bàn tự động chuyển sang "Có khách".
        /// </summary>
        public void ThemMon(int maBan, int maMon, int soLuong)
        {
            using var conn = DatabaseHelper.CreateConnection();
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                int? maHoaDon = LayHoaDonChuaThanhToan(maBan, conn, tran);
                if (maHoaDon == null)
                {
                    using var cmdHd = DatabaseHelper.CreateCommand(
                        @"INSERT INTO HoaDon(MaBan, GioVao, TongTien, TrangThai)
                          VALUES (@MaBan, GETDATE(), 0, 0);
                          SELECT CAST(SCOPE_IDENTITY() AS INT);", conn, tran);
                    cmdHd.Parameters.AddWithValue("@MaBan", maBan);
                    maHoaDon = Convert.ToInt32(cmdHd.ExecuteScalar());
                }

                decimal donGia;
                using (var cmdGia = DatabaseHelper.CreateCommand(
                    "SELECT DonGia FROM MonAn WHERE MaMon = @MaMon", conn, tran))
                {
                    cmdGia.Parameters.AddWithValue("@MaMon", maMon);
                    object g = cmdGia.ExecuteScalar();
                    if (g == null || g == DBNull.Value)
                        throw new InvalidOperationException("Món ăn không tồn tại.");
                    donGia = Convert.ToDecimal(g);
                }

                // Đã có món trong hóa đơn -> cộng dồn số lượng, chưa có -> thêm dòng mới
                using (var cmdUp = DatabaseHelper.CreateCommand(
                    @"UPDATE ChiTietHoaDon SET SoLuong = SoLuong + @SoLuong
                      WHERE MaHoaDon = @MaHoaDon AND MaMon = @MaMon", conn, tran))
                {
                    cmdUp.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmdUp.Parameters.AddWithValue("@MaHoaDon", maHoaDon.Value);
                    cmdUp.Parameters.AddWithValue("@MaMon", maMon);
                    if (cmdUp.ExecuteNonQuery() == 0)
                    {
                        using var cmdIns = DatabaseHelper.CreateCommand(
                            @"INSERT INTO ChiTietHoaDon(MaHoaDon, MaMon, SoLuong, DonGia)
                              VALUES (@MaHoaDon, @MaMon, @SoLuong, @DonGia)", conn, tran);
                        cmdIns.Parameters.AddWithValue("@MaHoaDon", maHoaDon.Value);
                        cmdIns.Parameters.AddWithValue("@MaMon", maMon);
                        cmdIns.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmdIns.Parameters.AddWithValue("@DonGia", donGia);
                        cmdIns.ExecuteNonQuery();
                    }
                }

                DatTrangThaiBan(maBan, TrangThaiBan.CoKhach, conn, tran);
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        /// <summary>Xóa một món khỏi hóa đơn; nếu hóa đơn hết món thì hủy hóa đơn và trả bàn về "Trống".</summary>
        public void XoaMon(int maBan, int maMon)
        {
            using var conn = DatabaseHelper.CreateConnection();
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                int? maHoaDon = LayHoaDonChuaThanhToan(maBan, conn, tran);
                if (maHoaDon == null)
                    throw new InvalidOperationException("Bàn này chưa có hóa đơn.");

                using (var cmdDel = DatabaseHelper.CreateCommand(
                    "DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon AND MaMon = @MaMon", conn, tran))
                {
                    cmdDel.Parameters.AddWithValue("@MaHoaDon", maHoaDon.Value);
                    cmdDel.Parameters.AddWithValue("@MaMon", maMon);
                    cmdDel.ExecuteNonQuery();
                }

                int conLai;
                using (var cmdCount = DatabaseHelper.CreateCommand(
                    "SELECT COUNT(*) FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon", conn, tran))
                {
                    cmdCount.Parameters.AddWithValue("@MaHoaDon", maHoaDon.Value);
                    conLai = Convert.ToInt32(cmdCount.ExecuteScalar());
                }

                if (conLai == 0)
                {
                    using var cmdHd = DatabaseHelper.CreateCommand(
                        "DELETE FROM HoaDon WHERE MaHoaDon = @MaHoaDon", conn, tran);
                    cmdHd.Parameters.AddWithValue("@MaHoaDon", maHoaDon.Value);
                    cmdHd.ExecuteNonQuery();
                    DatTrangThaiBan(maBan, TrangThaiBan.Trong, conn, tran);
                }

                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        /// <summary>
        /// Thanh toán: tính tổng tiền -> cập nhật GioRa, TongTien, TrangThai = 1 -> bàn về "Trống".
        /// Toàn bộ nằm trong một SqlTransaction. Trả về tổng tiền.
        /// </summary>
        public decimal ThanhToan(int maBan)
        {
            using var conn = DatabaseHelper.CreateConnection();
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                int? maHoaDon = LayHoaDonChuaThanhToan(maBan, conn, tran);
                if (maHoaDon == null)
                    throw new InvalidOperationException("Bàn này chưa có hóa đơn để thanh toán.");

                decimal tong;
                using (var cmdSum = DatabaseHelper.CreateCommand(
                    "SELECT ISNULL(SUM(SoLuong * DonGia), 0) FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon",
                    conn, tran))
                {
                    cmdSum.Parameters.AddWithValue("@MaHoaDon", maHoaDon.Value);
                    tong = Convert.ToDecimal(cmdSum.ExecuteScalar());
                }

                using (var cmdHd = DatabaseHelper.CreateCommand(
                    @"UPDATE HoaDon SET GioRa = GETDATE(), TongTien = @Tong, TrangThai = 1
                      WHERE MaHoaDon = @MaHoaDon", conn, tran))
                {
                    cmdHd.Parameters.AddWithValue("@Tong", tong);
                    cmdHd.Parameters.AddWithValue("@MaHoaDon", maHoaDon.Value);
                    cmdHd.ExecuteNonQuery();
                }

                DatTrangThaiBan(maBan, TrangThaiBan.Trong, conn, tran);
                tran.Commit();
                return tong;
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        /// <summary>Đổi bàn: chuyển hóa đơn chưa thanh toán sang bàn trống khác.</summary>
        public void DoiBan(int maBanCu, int maBanMoi)
        {
            using var conn = DatabaseHelper.CreateConnection();
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                using (var cmdCheck = DatabaseHelper.CreateCommand(
                    "SELECT TrangThai FROM BanAn WHERE MaBan = @MaBan", conn, tran))
                {
                    cmdCheck.Parameters.AddWithValue("@MaBan", maBanMoi);
                    object tt = cmdCheck.ExecuteScalar();
                    if (tt == null || tt == DBNull.Value || tt.ToString() != TrangThaiBan.Trong)
                        throw new InvalidOperationException("Bàn mới không còn trống.");
                }

                using (var cmdMove = DatabaseHelper.CreateCommand(
                    "UPDATE HoaDon SET MaBan = @Moi WHERE MaBan = @Cu AND TrangThai = 0", conn, tran))
                {
                    cmdMove.Parameters.AddWithValue("@Moi", maBanMoi);
                    cmdMove.Parameters.AddWithValue("@Cu", maBanCu);
                    if (cmdMove.ExecuteNonQuery() == 0)
                        throw new InvalidOperationException("Bàn hiện tại chưa có hóa đơn để chuyển.");
                }

                DatTrangThaiBan(maBanCu, TrangThaiBan.Trong, conn, tran);
                DatTrangThaiBan(maBanMoi, TrangThaiBan.CoKhach, conn, tran);
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }
    }
}
