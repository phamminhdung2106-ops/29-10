using System.Data;
using CafePOS.DAL;
using CafePOS.DTO;

namespace CafePOS.BUS
{
    public class MonAnBUS
    {
        private readonly MonAnDAL _dal = new MonAnDAL();

        public DataSet GetMenuDataSet() => _dal.GetMenuDataSet();

        public DataTable GetAllTable() => _dal.GetAllTable();

        /// <summary>Validation: tên món không rỗng, đơn giá không âm, phải chọn danh mục.</summary>
        private static void Validate(MonAnDTO m)
        {
            if (m == null || string.IsNullOrWhiteSpace(m.TenMon))
                throw new ArgumentException("Tên món không được để trống.");
            if (m.DonGia < 0)
                throw new ArgumentException("Đơn giá không được âm.");
            if (m.MaDanhMuc <= 0)
                throw new ArgumentException("Vui lòng chọn danh mục cho món.");
            m.TenMon = m.TenMon.Trim();
        }

        public void Them(MonAnDTO m)
        {
            Validate(m);
            _dal.Insert(m);
        }

        public void Sua(MonAnDTO m)
        {
            Validate(m);
            if (_dal.Update(m) == 0)
                throw new InvalidOperationException("Không tìm thấy món cần sửa.");
        }

        public void Xoa(int maMon) => _dal.Delete(maMon);
    }
}
