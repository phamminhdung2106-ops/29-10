using CafePOS.DTO;
using Microsoft.Data.SqlClient;

namespace CafePOS.DAL
{
    public class DanhMucDAL
    {
        public List<DanhMucDTO> GetAll()
        {
            var list = new List<DanhMucDTO>();
            using var conn = DatabaseHelper.CreateConnection();
            conn.Open();
            using var cmd = DatabaseHelper.CreateCommand(
                "SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc ORDER BY TenDanhMuc", conn);
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new DanhMucDTO { MaDanhMuc = rd.GetInt32(0), TenDanhMuc = rd.GetString(1) });
            }
            return list;
        }

        public int Insert(DanhMucDTO dm)
        {
            using var conn = DatabaseHelper.CreateConnection();
            conn.Open();
            using var cmd = DatabaseHelper.CreateCommand(
                "INSERT INTO DanhMuc(TenDanhMuc) VALUES (@Ten)", conn);
            cmd.Parameters.AddWithValue("@Ten", dm.TenDanhMuc);
            return cmd.ExecuteNonQuery();
        }

        public int Update(DanhMucDTO dm)
        {
            using var conn = DatabaseHelper.CreateConnection();
            conn.Open();
            using var cmd = DatabaseHelper.CreateCommand(
                "UPDATE DanhMuc SET TenDanhMuc = @Ten WHERE MaDanhMuc = @Ma", conn);
            cmd.Parameters.AddWithValue("@Ten", dm.TenDanhMuc);
            cmd.Parameters.AddWithValue("@Ma", dm.MaDanhMuc);
            return cmd.ExecuteNonQuery();
        }

        public int Delete(int maDanhMuc)
        {
            using var conn = DatabaseHelper.CreateConnection();
            conn.Open();
            using var cmd = DatabaseHelper.CreateCommand(
                "DELETE FROM DanhMuc WHERE MaDanhMuc = @Ma", conn);
            cmd.Parameters.AddWithValue("@Ma", maDanhMuc);
            return cmd.ExecuteNonQuery();
        }

        public int CountMon(int maDanhMuc)
        {
            using var conn = DatabaseHelper.CreateConnection();
            conn.Open();
            using var cmd = DatabaseHelper.CreateCommand(
                "SELECT COUNT(*) FROM MonAn WHERE MaDanhMuc = @Ma", conn);
            cmd.Parameters.AddWithValue("@Ma", maDanhMuc);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}
