using CafePOS.DTO;

namespace CafePOS.DAL
{
    public class BanAnDAL
    {
        public List<BanAnDTO> GetAll()
        {
            var list = new List<BanAnDTO>();
            using var conn = DatabaseHelper.CreateConnection();
            conn.Open();
            using var cmd = DatabaseHelper.CreateCommand(
                "SELECT MaBan, TenBan, TrangThai FROM BanAn ORDER BY MaBan", conn);
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new BanAnDTO
                {
                    MaBan = rd.GetInt32(0),
                    TenBan = rd.GetString(1),
                    TrangThai = rd.IsDBNull(2) ? TrangThaiBan.Trong : rd.GetString(2)
                });
            }
            return list;
        }
    }
}
