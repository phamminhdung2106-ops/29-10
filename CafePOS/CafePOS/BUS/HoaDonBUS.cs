using System.Data;
using CafePOS.DAL;

namespace CafePOS.BUS
{
    public class HoaDonBUS
    {
        private readonly HoaDonDAL _dal = new HoaDonDAL();

        public DataTable GetChiTietByBan(int maBan) => _dal.GetChiTietByBan(maBan);

        public void ThemMon(int maBan, int maMon, int soLuong)
        {
            if (maBan <= 0) throw new ArgumentException("Vui lòng chọn bàn.");
            if (maMon <= 0) throw new ArgumentException("Vui lòng chọn món.");
            if (soLuong <= 0) throw new ArgumentException("Số lượng phải lớn hơn 0.");
            _dal.ThemMon(maBan, maMon, soLuong);
        }

        public void XoaMon(int maBan, int maMon)
        {
            if (maBan <= 0 || maMon <= 0) throw new ArgumentException("Dữ liệu không hợp lệ.");
            _dal.XoaMon(maBan, maMon);
        }

        public decimal ThanhToan(int maBan)
        {
            if (maBan <= 0) throw new ArgumentException("Vui lòng chọn bàn.");
            return _dal.ThanhToan(maBan);
        }

        public void DoiBan(int maBanCu, int maBanMoi)
        {
            if (maBanCu <= 0 || maBanMoi <= 0) throw new ArgumentException("Vui lòng chọn bàn.");
            if (maBanCu == maBanMoi) throw new ArgumentException("Bàn mới phải khác bàn hiện tại.");
            _dal.DoiBan(maBanCu, maBanMoi);
        }
    }
}
