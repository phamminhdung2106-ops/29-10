
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementSystem.DAL
{
    public class PhongDAL : DBConnect
    {
        public DataTable GetDanhSachPhong()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Phong", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool CapNhatTrangThai(string soPhong, string trangThai, SqlTransaction trans = null)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Phong SET TrangThai = @TrangThai WHERE SoPhong = @SoPhong");
            cmd.Parameters.AddWithValue("@TrangThai", trangThai);
            cmd.Parameters.AddWithValue("@SoPhong", soPhong);
            if (trans != null)
            {
                cmd.Connection = trans.Connection;
                cmd.Transaction = trans;
                return cmd.ExecuteNonQuery() > 0;
            }
            else
            {
                cmd.Connection = conn;
                conn.Open();
                bool result = cmd.ExecuteNonQuery() > 0;
                conn.Close();
                return result;
            }
        }
    }
}
