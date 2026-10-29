
namespace InventoryManagementSystem.DTO
{
    public class ChiTietPhieuKhoDTO
    {
        public string MaVatTu { get; set; }
        public string TenVatTu { get; set; }
        public decimal SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien => SoLuong * DonGia;
    }
}
