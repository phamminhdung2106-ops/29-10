
using HotelManagementSystem.DTO;
using System.Data.SqlClient;

namespace HotelManagementSystem.DAL
{
    public class KhachHangDAL : DBConnect
    {
        public int CheckAndInsertKhachHang(KhachHangDTO kh, SqlTransaction trans)
        {
            SqlCommand cmdCheck = new SqlCommand("SELECT MaKH FROM KhachHang WHERE CCCD = @CCCD", trans.Connection, trans);
            cmdCheck.Parameters.AddWithValue("@CCCD", kh.CCCD);
            object result = cmdCheck.ExecuteScalar();
            if (result != null) return (int)result;

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO KhachHang (HoTen, CCCD, SoDienThoai) OUTPUT INSERTED.MaKH VALUES (@HoTen, @CCCD, @SDT)", trans.Connection, trans);
            cmdInsert.Parameters.AddWithValue("@HoTen", kh.HoTen);
            cmdInsert.Parameters.AddWithValue("@CCCD", kh.CCCD);
            cmdInsert.Parameters.AddWithValue("@SDT", kh.SoDienThoai);
            
            return (int)cmdInsert.ExecuteScalar();
        }
    }
}
