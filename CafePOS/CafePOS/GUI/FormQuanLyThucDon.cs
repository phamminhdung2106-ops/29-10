using System.Data;
using System.Globalization;
using CafePOS.BUS;
using CafePOS.DTO;

namespace CafePOS.GUI
{
    /// <summary>Quản lý danh mục và thực đơn (CRUD 3-Tier, có validation).</summary>
    public partial class FormQuanLyThucDon : Form
    {
        private readonly DanhMucBUS _dmBus = new DanhMucBUS();
        private readonly MonAnBUS _monBus = new MonAnBUS();
        private bool _dangNap;

        public FormQuanLyThucDon()
        {
            InitializeComponent();
        }

        private void FormQuanLyThucDon_Load(object sender, EventArgs e)
        {
            try
            {
                NapDanhMuc();
                NapMon();
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        // ================= Nạp dữ liệu =================

        private void NapDanhMuc()
        {
            _dangNap = true;
            List<DanhMucDTO> ds = _dmBus.GetAll();

            dgvDanhMuc.DataSource = ds;
            if (dgvDanhMuc.Columns.Count > 0)
            {
                dgvDanhMuc.Columns["MaDanhMuc"].HeaderText = "Mã";
                dgvDanhMuc.Columns["MaDanhMuc"].FillWeight = 25;
                dgvDanhMuc.Columns["TenDanhMuc"].HeaderText = "Tên danh mục";
            }

            // Dùng một List riêng cho ComboBox để không bị đồng bộ vị trí với DataGridView
            cboDanhMucMon.DataSource = new List<DanhMucDTO>(ds);
            _dangNap = false;
            txtTenDanhMuc.Clear();
        }

        private void NapMon()
        {
            _dangNap = true;
            dgvMon.DataSource = _monBus.GetAllTable();
            if (dgvMon.Columns.Count > 0)
            {
                dgvMon.Columns["MaMon"].HeaderText = "Mã";
                dgvMon.Columns["MaMon"].FillWeight = 20;
                dgvMon.Columns["TenMon"].HeaderText = "Tên món";
                dgvMon.Columns["MaDanhMuc"].Visible = false;
                dgvMon.Columns["TenDanhMuc"].HeaderText = "Danh mục";
                dgvMon.Columns["DonGia"].HeaderText = "Đơn giá";
                dgvMon.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                dgvMon.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            _dangNap = false;
            XoaFormMon();
        }

        private void XoaFormMon()
        {
            errorProvider1.Clear();
            txtTenMon.Clear();
            txtDonGia.Clear();
            if (cboDanhMucMon.Items.Count > 0) cboDanhMucMon.SelectedIndex = 0;
        }

        // ================= Chọn dòng trên lưới =================

        private void dgvDanhMuc_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangNap) return;
            if (dgvDanhMuc.CurrentRow?.DataBoundItem is DanhMucDTO dm)
                txtTenDanhMuc.Text = dm.TenDanhMuc;
        }

        private void dgvMon_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangNap) return;
            if (dgvMon.CurrentRow?.DataBoundItem is DataRowView row)
            {
                errorProvider1.Clear();
                txtTenMon.Text = Convert.ToString(row["TenMon"]);
                cboDanhMucMon.SelectedValue = Convert.ToInt32(row["MaDanhMuc"]);
                txtDonGia.Text = Convert.ToDecimal(row["DonGia"]).ToString("0");
            }
        }

        // ================= Danh mục =================

        private void btnThemDM_Click(object sender, EventArgs e)
        {
            try
            {
                _dmBus.Them(new DanhMucDTO { TenDanhMuc = txtTenDanhMuc.Text });
                NapDanhMuc();
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        private void btnSuaDM_Click(object sender, EventArgs e)
        {
            if (dgvDanhMuc.CurrentRow?.DataBoundItem is not DanhMucDTO dm)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                _dmBus.Sua(new DanhMucDTO { MaDanhMuc = dm.MaDanhMuc, TenDanhMuc = txtTenDanhMuc.Text });
                NapDanhMuc();
                NapMon();
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        private void btnXoaDM_Click(object sender, EventArgs e)
        {
            if (dgvDanhMuc.CurrentRow?.DataBoundItem is not DanhMucDTO dm)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Xóa danh mục \"{dm.TenDanhMuc}\"?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                _dmBus.Xoa(dm.MaDanhMuc);
                NapDanhMuc();
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        // ================= Thực đơn =================

        /// <summary>Kiểm tra dữ liệu nhập, hiển thị lỗi bằng ErrorProvider.</summary>
        private bool KiemTraMon(out decimal donGia)
        {
            errorProvider1.Clear();
            bool hopLe = true;
            donGia = 0;

            if (string.IsNullOrWhiteSpace(txtTenMon.Text))
            {
                errorProvider1.SetError(txtTenMon, "Tên món không được để trống.");
                hopLe = false;
            }

            if (cboDanhMucMon.SelectedValue == null)
            {
                errorProvider1.SetError(cboDanhMucMon, "Vui lòng chọn danh mục.");
                hopLe = false;
            }

            if (!decimal.TryParse(txtDonGia.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out donGia))
            {
                errorProvider1.SetError(txtDonGia, "Đơn giá phải là một số.");
                hopLe = false;
            }
            else if (donGia < 0)
            {
                errorProvider1.SetError(txtDonGia, "Đơn giá không được âm.");
                hopLe = false;
            }

            return hopLe;
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (!KiemTraMon(out decimal donGia)) return;

            try
            {
                _monBus.Them(new MonAnDTO
                {
                    TenMon = txtTenMon.Text,
                    MaDanhMuc = Convert.ToInt32(cboDanhMucMon.SelectedValue),
                    DonGia = donGia
                });
                NapMon();
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        private void btnSuaMon_Click(object sender, EventArgs e)
        {
            if (dgvMon.CurrentRow?.DataBoundItem is not DataRowView row)
            {
                MessageBox.Show("Vui lòng chọn món cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!KiemTraMon(out decimal donGia)) return;

            try
            {
                _monBus.Sua(new MonAnDTO
                {
                    MaMon = Convert.ToInt32(row["MaMon"]),
                    TenMon = txtTenMon.Text,
                    MaDanhMuc = Convert.ToInt32(cboDanhMucMon.SelectedValue),
                    DonGia = donGia
                });
                NapMon();
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (dgvMon.CurrentRow?.DataBoundItem is not DataRowView row)
            {
                MessageBox.Show("Vui lòng chọn món cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Xóa món \"{row["TenMon"]}\"?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                _monBus.Xoa(Convert.ToInt32(row["MaMon"]));
                NapMon();
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                NapDanhMuc();
                NapMon();
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        private static void HienLoi(Exception ex)
        {
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
