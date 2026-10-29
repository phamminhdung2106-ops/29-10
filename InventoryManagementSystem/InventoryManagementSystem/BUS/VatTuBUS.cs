
using InventoryManagementSystem.DAL;
using System.Data;

namespace InventoryManagementSystem.BUS
{
    public class VatTuBUS
    {
        private VatTuDAL dal = new VatTuDAL();
        public DataTable GetAllVatTu() => dal.GetAllVatTu();
        public DataTable SearchVatTu(string kw) => dal.SearchVatTu(kw);
        public decimal GetTongGiaTriTonKho() => dal.GetTongGiaTriTonKho();
    }
}
