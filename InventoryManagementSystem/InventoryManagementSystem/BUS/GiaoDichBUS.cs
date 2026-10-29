
using InventoryManagementSystem.DAL;
using InventoryManagementSystem.DTO;
using System.Collections.Generic;

namespace InventoryManagementSystem.BUS
{
    public class GiaoDichBUS
    {
        private GiaoDichDAL dal = new GiaoDichDAL();

        public bool LuuPhieu(string loaiPhieu, int? maNCC, decimal tongTien, List<ChiTietPhieuKhoDTO> chiTietList, out string errorMsg)
        {
            return dal.LuuPhieuKho(loaiPhieu, maNCC, tongTien, chiTietList, out errorMsg);
        }
    }
}
