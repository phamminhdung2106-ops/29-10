
using System.Configuration;
using System.Data.SqlClient;

namespace HotelManagementSystem.DAL
{
    public class DBConnect
    {
        protected SqlConnection conn;
        public DBConnect()
        {
            string connString = ConfigurationManager.ConnectionStrings["HotelDB"].ConnectionString;
            conn = new SqlConnection(connString);
        }
    }
}
