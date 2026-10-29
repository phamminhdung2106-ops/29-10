
using HotelManagementSystem.DAL;
using System.Data;

namespace HotelManagementSystem.BUS
{
    public class PhongBUS
    {
        private PhongDAL dal = new PhongDAL();
        public DataTable GetAllPhong()
        {
            return dal.GetDanhSachPhong();
        }
    }
}
