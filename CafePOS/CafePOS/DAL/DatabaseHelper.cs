using System.Configuration;
using Microsoft.Data.SqlClient;

namespace CafePOS.DAL
{
    /// <summary>Đọc chuỗi kết nối từ App.config và tạo kết nối / lệnh SQL.</summary>
    public static class DatabaseHelper
    {
        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["CafePOSDB"].ConnectionString;

        public static SqlConnection CreateConnection() => new SqlConnection(ConnectionString);

        public static SqlCommand CreateCommand(string sql, SqlConnection conn, SqlTransaction tran = null)
        {
            var cmd = new SqlCommand(sql, conn);
            if (tran != null) cmd.Transaction = tran;
            return cmd;
        }
    }
}
