
using System.Configuration;
using System.Data.SqlClient;

namespace InventoryManagementSystem.DAL
{
    public class DBConnect
    {
        protected SqlConnection conn;
        public DBConnect()
        {
            string connString = ConfigurationManager.ConnectionStrings["InventoryDB"].ConnectionString;
            conn = new SqlConnection(connString);
        }
    }
}
