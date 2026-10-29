
using HotelManagementSystem.DAL;
using HotelManagementSystem.DTO;
using System.Data;

namespace HotelManagementSystem.BUS
{
    public class GiaoDichBUS
    {
        private GiaoDichDAL dal = new GiaoDichDAL();

        public bool NhanPhong(KhachHangDTO kh, string soPhong)
        {
            return dal.CheckIn(kh, soPhong);
        }
        
        public bool TraPhong(string soPhong)
        {
            return dal.CheckOut(soPhong);
        }

        public DataTable GetDichVu()
        {
            return dal.GetDichVu();
        }
    }
}
