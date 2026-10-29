namespace CafePOS.DTO
{
    /// <summary>Các giá trị trạng thái của bàn.</summary>
    public static class TrangThaiBan
    {
        public const string Trong = "Trống";
        public const string CoKhach = "Có khách";
    }

    public class BanAnDTO
    {
        public int MaBan { get; set; }
        public string TenBan { get; set; }
        public string TrangThai { get; set; }
    }
}
