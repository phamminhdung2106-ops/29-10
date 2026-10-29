
using System.Data;
using System.Data.SqlClient;

namespace InventoryManagementSystem.DAL
{
    public class VatTuDAL : DBConnect
    {
        public DataTable GetAllVatTu()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM VatTu", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        
        public DataTable SearchVatTu(string keyword)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM VatTu WHERE MaVatTu LIKE @kw OR TenVatTu LIKE @kw", conn);
            cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public decimal GetTongGiaTriTonKho()
        {
            // ExecuteScalar example
            SqlCommand cmd = new SqlCommand("SELECT ISNULL(SUM(SoLuongTon * 10000), 0) FROM VatTu", conn); // Giả sử đơn giá trung bình 10k để tính
            conn.Open();
            decimal result = System.Convert.ToDecimal(cmd.ExecuteScalar());
            conn.Close();
            return result;
        }
    }
}
