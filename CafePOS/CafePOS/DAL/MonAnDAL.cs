using System.Data;
using CafePOS.DTO;
using Microsoft.Data.SqlClient;

namespace CafePOS.DAL
{
    public class MonAnDAL
    {
        /// <summary>
        /// Mô hình ngắt kết nối: nạp danh mục + thực đơn vào một DataSet bằng SqlDataAdapter.
        /// Sau khi Fill xong kết nối được đóng, Form làm việc hoàn toàn trên DataSet.
        /// </summary>
        public DataSet GetMenuDataSet()
        {
            var ds = new DataSet("Menu");
            using var conn = DatabaseHelper.CreateConnection();

            using (var da = new SqlDataAdapter(
                "SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc ORDER BY TenDanhMuc", conn))
            {
                da.Fill(ds, "DanhMuc");
            }

            using (var da = new SqlDataAdapter(
                @"SELECT MaMon, TenMon, MaDanhMuc, DonGia,
                         CONCAT(TenMon, N' - ', FORMAT(DonGia, 'N0'), N'đ') AS TenHienThi
                  FROM MonAn ORDER BY TenMon", conn))
            {
                da.Fill(ds, "MonAn");
            }

            return ds;
        }

        /// <summary>Danh sách món kèm tên danh mục (dùng cho lưới quản lý thực đơn).</summary>
        public DataTable GetAllTable()
        {
            var dt = new DataTable("MonAn");
            using var conn = DatabaseHelper.CreateConnection();
            using var da = new SqlDataAdapter(
                @"SELECT m.MaMon, m.TenMon, m.MaDanhMuc, d.TenDanhMuc, m.DonGia
                  FROM MonAn m INNER JOIN DanhMuc d ON d.MaDanhMuc = m.MaDanhMuc
                  ORDER BY d.TenDanhMuc, m.TenMon", conn);
            da.Fill(dt);
            return dt;
        }

        public int Insert(MonAnDTO m)
        {
            using var conn = DatabaseHelper.CreateConnection();
            conn.Open();
            using var cmd = DatabaseHelper.CreateCommand(
                "INSERT INTO MonAn(TenMon, MaDanhMuc, DonGia) VALUES (@Ten, @MaDM, @Gia)", conn);
            cmd.Parameters.AddWithValue("@Ten", m.TenMon);
            cmd.Parameters.AddWithValue("@MaDM", m.MaDanhMuc);
            cmd.Parameters.AddWithValue("@Gia", m.DonGia);
            return cmd.ExecuteNonQuery();
        }

        public int Update(MonAnDTO m)
        {
            using var conn = DatabaseHelper.CreateConnection();
            conn.Open();
            using var cmd = DatabaseHelper.CreateCommand(
                "UPDATE MonAn SET TenMon = @Ten, MaDanhMuc = @MaDM, DonGia = @Gia WHERE MaMon = @Ma", conn);
            cmd.Parameters.AddWithValue("@Ten", m.TenMon);
            cmd.Parameters.AddWithValue("@MaDM", m.MaDanhMuc);
            cmd.Parameters.AddWithValue("@Gia", m.DonGia);
            cmd.Parameters.AddWithValue("@Ma", m.MaMon);
            return cmd.ExecuteNonQuery();
        }

        public int Delete(int maMon)
        {
            using var conn = DatabaseHelper.CreateConnection();
            conn.Open();
            using var cmd = DatabaseHelper.CreateCommand("DELETE FROM MonAn WHERE MaMon = @Ma", conn);
            cmd.Parameters.AddWithValue("@Ma", maMon);
            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) when (ex.Number == 547) // vi phạm khóa ngoại
            {
                throw new InvalidOperationException("Món này đã có trong hóa đơn nên không thể xóa.");
            }
        }
    }
}
