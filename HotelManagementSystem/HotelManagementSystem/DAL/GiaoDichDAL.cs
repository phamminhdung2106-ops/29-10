
using HotelManagementSystem.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementSystem.DAL
{
    public class GiaoDichDAL : DBConnect
    {
        public bool CheckIn(KhachHangDTO kh, string soPhong)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                KhachHangDAL khDAL = new KhachHangDAL();
                int maKH = khDAL.CheckAndInsertKhachHang(kh, trans);

                SqlCommand cmd = new SqlCommand("INSERT INTO PhieuDatPhong (SoPhong, MaKH, NgayNhanPhong) VALUES (@SoPhong, @MaKH, @Ngay)", conn, trans);
                cmd.Parameters.AddWithValue("@SoPhong", soPhong);
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                cmd.Parameters.AddWithValue("@Ngay", DateTime.Now);
                cmd.ExecuteNonQuery();

                PhongDAL phongDAL = new PhongDAL();
                phongDAL.CapNhatTrangThai(soPhong, "Đang ở", trans);

                trans.Commit();
                return true;
            }
            catch
            {
                trans.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        
        public DataTable GetDichVu()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DichVu", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool CheckOut(string soPhong)
        {
            // Simplified check-out transaction for demonstration
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                // Get MaPhieu
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 MaPhieu FROM PhieuDatPhong WHERE SoPhong=@SoPhong AND NgayTraPhong IS NULL ORDER BY MaPhieu DESC", conn, trans);
                cmd.Parameters.AddWithValue("@SoPhong", soPhong);
                object maPhieuObj = cmd.ExecuteScalar();
                if(maPhieuObj == null) throw new Exception("Không tìm thấy phiếu đặt phòng");
                int maPhieu = (int)maPhieuObj;

                SqlCommand cmdThanhToan = new SqlCommand("UPDATE PhieuDatPhong SET NgayTraPhong = @Ngay, TongTienThanhToan = 1000000 WHERE MaPhieu = @MaPhieu", conn, trans);
                cmdThanhToan.Parameters.AddWithValue("@Ngay", DateTime.Now);
                cmdThanhToan.Parameters.AddWithValue("@MaPhieu", maPhieu);
                cmdThanhToan.ExecuteNonQuery();

                PhongDAL phongDAL = new PhongDAL();
                phongDAL.CapNhatTrangThai(soPhong, "Đang dọn dẹp", trans);

                trans.Commit();
                return true;
            }
            catch
            {
                trans.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
