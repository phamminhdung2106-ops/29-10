using CafePOS.DAL;
using CafePOS.DTO;

namespace CafePOS.BUS
{
    public class DanhMucBUS
    {
        private readonly DanhMucDAL _dal = new DanhMucDAL();

        public List<DanhMucDTO> GetAll() => _dal.GetAll();

        private static void Validate(DanhMucDTO dm)
        {
            if (dm == null || string.IsNullOrWhiteSpace(dm.TenDanhMuc))
                throw new ArgumentException("Tên danh mục không được để trống.");
            dm.TenDanhMuc = dm.TenDanhMuc.Trim();
        }

        public void Them(DanhMucDTO dm)
        {
            Validate(dm);
            _dal.Insert(dm);
        }

        public void Sua(DanhMucDTO dm)
        {
            Validate(dm);
            if (_dal.Update(dm) == 0)
                throw new InvalidOperationException("Không tìm thấy danh mục cần sửa.");
        }

        public void Xoa(int maDanhMuc)
        {
            if (_dal.CountMon(maDanhMuc) > 0)
                throw new InvalidOperationException("Danh mục đang có món ăn, hãy xóa hoặc chuyển các món trước.");
            _dal.Delete(maDanhMuc);
        }
    }
}
