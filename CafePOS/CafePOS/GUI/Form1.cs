using System.Data;
using CafePOS.BUS;
using CafePOS.DTO;
using Microsoft.Data.SqlClient;

namespace CafePOS.GUI
{
    public partial class Form1 : Form
    {
        private static readonly Color MauXanh = Color.FromArgb(46, 160, 67);
        private static readonly Color MauDo = Color.FromArgb(220, 53, 69);

        private readonly BanAnBUS _banBus = new BanAnBUS();
        private readonly HoaDonBUS _hoaDonBus = new HoaDonBUS();
        private readonly MonAnBUS _monBus = new MonAnBUS();

        private DataSet _dsMenu;          // DataSet ngắt kết nối chứa DanhMuc + MonAn
        private DataTable _dtChiTiet;      // món đã gọi của bàn đang chọn
        private BanAnDTO _banDangChon;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                LoadMenu();
                LamMoiTatCa();
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        // ================= Nạp dữ liệu =================

        private void LoadMenu()
        {
            _dsMenu = _monBus.GetMenuDataSet();
            cboDanhMuc.DataSource = _dsMenu.Tables["DanhMuc"];   // DisplayMember/ValueMember đã đặt trong Designer
        }

        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dsMenu == null || cboDanhMuc.SelectedItem is not DataRowView dm) return;

            var dv = new DataView(_dsMenu.Tables["MonAn"])
            {
                RowFilter = "MaDanhMuc = " + dm["MaDanhMuc"],
                Sort = "TenMon"
            };
            cboMon.DataSource = dv;
        }

        /// <summary>Tạo lại các nút bàn (màu xanh = trống, đỏ = có khách).</summary>
        private void LoadBan()
        {
            List<BanAnDTO> dsBan = _banBus.GetAll();

            if (_banDangChon != null)
                _banDangChon = dsBan.FirstOrDefault(b => b.MaBan == _banDangChon.MaBan);

            flpBan.SuspendLayout();
            foreach (Control c in flpBan.Controls) c.Dispose();
            flpBan.Controls.Clear();

            foreach (BanAnDTO ban in dsBan)
            {
                bool coKhach = ban.TrangThai == TrangThaiBan.CoKhach;
                bool dangChon = _banDangChon != null && _banDangChon.MaBan == ban.MaBan;

                var btn = new Button
                {
                    Width = 112,
                    Height = 92,
                    Margin = new Padding(8),
                    Text = ban.TenBan + Environment.NewLine + ban.TrangThai,
                    Tag = ban,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = coKhach ? MauDo : MauXanh,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                };
                btn.FlatAppearance.BorderSize = dangChon ? 4 : 0;
                btn.FlatAppearance.BorderColor = Color.Black;
                btn.Click += BanButton_Click;
                flpBan.Controls.Add(btn);
            }
            flpBan.ResumeLayout();

            // Danh sách bàn trống để đổi bàn (không gồm bàn đang chọn)
            cboBanTrong.DataSource = dsBan
                .Where(b => b.TrangThai == TrangThaiBan.Trong &&
                            (_banDangChon == null || b.MaBan != _banDangChon.MaBan))
                .ToList();
        }

        private void LoadChiTiet()
        {
            if (_banDangChon == null)
            {
                dgvChiTiet.DataSource = null;
                lblTongTien.Text = "0 đ";
                return;
            }

            _dtChiTiet = _hoaDonBus.GetChiTietByBan(_banDangChon.MaBan);
            dgvChiTiet.DataSource = _dtChiTiet;
            DinhDangLuoi();

            decimal tong = _dtChiTiet.AsEnumerable().Sum(r => r.Field<decimal>("ThanhTien"));
            lblTongTien.Text = tong.ToString("N0") + " đ";
        }

        private void DinhDangLuoi()
        {
            if (dgvChiTiet.Columns.Count == 0) return;

            dgvChiTiet.Columns["MaMon"].Visible = false;
            dgvChiTiet.Columns["TenMon"].HeaderText = "Tên món";
            dgvChiTiet.Columns["SoLuong"].HeaderText = "SL";
            dgvChiTiet.Columns["SoLuong"].FillWeight = 25;
            dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành tiền";

            foreach (string name in new[] { "SoLuong", "DonGia", "ThanhTien" })
            {
                dgvChiTiet.Columns[name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }

        private void CapNhatGiaoDien()
        {
            bool coBan = _banDangChon != null;
            bool coKhach = coBan && _banDangChon.TrangThai == TrangThaiBan.CoKhach;

            lblBanChon.Text = coBan
                ? _banDangChon.TenBan + " - " + _banDangChon.TrangThai
                : "Chưa chọn bàn";

            gbThemMon.Enabled = coBan;
            btnXoaMon.Enabled = coKhach;
            btnThanhToan.Enabled = coKhach;
            btnDoiBan.Enabled = coKhach && cboBanTrong.Items.Count > 0;
        }

        private void LamMoiTatCa()
        {
            LoadBan();
            LoadChiTiet();
            CapNhatGiaoDien();
        }

        // ================= Sự kiện =================

        private void BanButton_Click(object sender, EventArgs e)
        {
            try
            {
                _banDangChon = (BanAnDTO)((Button)sender).Tag;
                LamMoiTatCa();
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (_banDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboMon.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn món.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int maMon = Convert.ToInt32(cboMon.SelectedValue);
                _hoaDonBus.ThemMon(_banDangChon.MaBan, maMon, (int)nudSoLuong.Value);
                nudSoLuong.Value = 1;
                LamMoiTatCa();
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (_banDangChon == null || dgvChiTiet.CurrentRow?.DataBoundItem is not DataRowView row)
            {
                MessageBox.Show("Vui lòng chọn một món trong danh sách để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                _hoaDonBus.XoaMon(_banDangChon.MaBan, Convert.ToInt32(row["MaMon"]));
                LamMoiTatCa();
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (_banDangChon == null) return;

            if (_dtChiTiet == null || _dtChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Bàn này chưa có món nào để thanh toán.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal tong = _dtChiTiet.AsEnumerable().Sum(r => r.Field<decimal>("ThanhTien"));
            var hoi = MessageBox.Show(
                $"Thanh toán {_banDangChon.TenBan}\nTổng tiền: {tong:N0} đ\n\nXác nhận?",
                "Thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi != DialogResult.Yes) return;

            try
            {
                decimal daThu = _hoaDonBus.ThanhToan(_banDangChon.MaBan);
                MessageBox.Show($"Thanh toán thành công: {daThu:N0} đ", "Thanh toán",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiTatCa();
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        private void btnDoiBan_Click(object sender, EventArgs e)
        {
            if (_banDangChon == null || cboBanTrong.SelectedValue == null) return;

            try
            {
                int banMoi = Convert.ToInt32(cboBanTrong.SelectedValue);
                _hoaDonBus.DoiBan(_banDangChon.MaBan, banMoi);
                _banDangChon = new BanAnDTO { MaBan = banMoi };   // LoadBan sẽ nạp lại thông tin đầy đủ
                LamMoiTatCa();
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        private void btnQuanLyThucDon_Click(object sender, EventArgs e)
        {
            using (var frm = new FormQuanLyThucDon())
            {
                frm.ShowDialog(this);
            }

            try
            {
                LoadMenu();   // nạp lại thực đơn sau khi chỉnh sửa
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        private static void HienLoi(Exception ex)
        {
            string msg = ex is SqlException
                ? "Lỗi cơ sở dữ liệu. Kiểm tra lại ConnectionString trong App.config và đã chạy ScriptDB.sql chưa.\n\n" + ex.Message
                : ex.Message;
            MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
