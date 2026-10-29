
using InventoryManagementSystem.BUS;
using InventoryManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagementSystem.GUI
{
    public partial class MainForm : Form
    {
        private VatTuBUS vatTuBUS = new VatTuBUS();
        private GiaoDichBUS giaoDichBUS = new GiaoDichBUS();
        private List<ChiTietPhieuKhoDTO> chiTietPhieu = new List<ChiTietPhieuKhoDTO>();

        public MainForm()
        {
            InitializeComponent();
            LoadData();
            cboLoaiPhieu.SelectedIndex = 0; // Default to NHAP
        }

        private void LoadData()
        {
            dgvVatTu.DataSource = vatTuBUS.GetAllVatTu();
            lblTongGiaTri.Text = "Tổng GT Tồn Kho ước tính: " + vatTuBUS.GetTongGiaTriTonKho().ToString("N0") + " VNĐ";
            UpdateCartGrid();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvVatTu.DataSource = vatTuBUS.SearchVatTu(txtTimKiem.Text);
        }

        private void btnThemVaoPhieu_Click(object sender, EventArgs e)
        {
            if (dgvVatTu.CurrentRow != null)
            {
                string maVT = dgvVatTu.CurrentRow.Cells["MaVatTu"].Value.ToString();
                string tenVT = dgvVatTu.CurrentRow.Cells["TenVatTu"].Value.ToString();
                
                if (!decimal.TryParse(txtSoLuong.Text, out decimal sl) || sl <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0");
                    return;
                }
                if (!decimal.TryParse(txtDonGia.Text, out decimal gia) || gia <= 0)
                {
                    MessageBox.Show("Đơn giá phải lớn hơn 0");
                    return;
                }

                var item = chiTietPhieu.FirstOrDefault(x => x.MaVatTu == maVT);
                if (item != null)
                {
                    item.SoLuong += sl;
                    item.DonGia = gia;
                }
                else
                {
                    chiTietPhieu.Add(new ChiTietPhieuKhoDTO { MaVatTu = maVT, TenVatTu = tenVT, SoLuong = sl, DonGia = gia });
                }
                UpdateCartGrid();
            }
        }

        private void UpdateCartGrid()
        {
            dgvChiTietPhieu.DataSource = null;
            dgvChiTietPhieu.DataSource = chiTietPhieu;
            
            decimal tongTien = chiTietPhieu.Sum(x => x.ThanhTien);
            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (chiTietPhieu.Count == 0)
            {
                MessageBox.Show("Chưa có vật tư nào trong phiếu!");
                return;
            }

            string loaiPhieu = cboLoaiPhieu.SelectedItem.ToString();
            decimal tongTien = chiTietPhieu.Sum(x => x.ThanhTien);
            
            if (giaoDichBUS.LuuPhieu(loaiPhieu, null, tongTien, chiTietPhieu, out string errorMsg))
            {
                MessageBox.Show("Lưu phiếu thành công!");
                chiTietPhieu.Clear();
                LoadData();
            }
            else
            {
                MessageBox.Show("Lỗi Giao Dịch (Rollback): " + errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnCanhBao_Click(object sender, EventArgs e)
        {
            DataTable dt = vatTuBUS.GetAllVatTu();
            DataView dv = new DataView(dt);
            dv.RowFilter = "SoLuongTon < 50"; // Ngưỡng an toàn là 50
            dgvVatTu.DataSource = dv;
        }
    }
}
