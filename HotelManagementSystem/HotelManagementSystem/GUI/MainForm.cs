
using HotelManagementSystem.BUS;
using HotelManagementSystem.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace HotelManagementSystem.GUI
{
    public partial class MainForm : Form
    {
        private PhongBUS phongBUS = new PhongBUS();
        private GiaoDichBUS giaoDichBUS = new GiaoDichBUS();

        public MainForm()
        {
            InitializeComponent();
            LoadPhong();
        }

        private void LoadPhong()
        {
            dgvPhong.DataSource = phongBUS.GetAllPhong();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if(dgvPhong.CurrentRow != null)
            {
                string trangThai = dgvPhong.CurrentRow.Cells["TrangThai"].Value.ToString();
                if(trangThai != "Trống")
                {
                    MessageBox.Show("Phòng không trống!");
                    return;
                }
                
                string soPhong = dgvPhong.CurrentRow.Cells["SoPhong"].Value.ToString();
                KhachHangDTO kh = new KhachHangDTO 
                { 
                    HoTen = txtTenKH.Text, 
                    CCCD = txtCCCD.Text, 
                    SoDienThoai = txtSDT.Text 
                };

                if (giaoDichBUS.NhanPhong(kh, soPhong))
                {
                    MessageBox.Show("Check-in thành công!");
                    LoadPhong();
                }
                else
                {
                    MessageBox.Show("Check-in thất bại!");
                }
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if(dgvPhong.CurrentRow != null)
            {
                string soPhong = dgvPhong.CurrentRow.Cells["SoPhong"].Value.ToString();
                if (giaoDichBUS.TraPhong(soPhong))
                {
                    MessageBox.Show("Check-out thành công!");
                    LoadPhong();
                }
                else
                {
                    MessageBox.Show("Check-out thất bại!");
                }
            }
        }

        private void txtLoc_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = phongBUS.GetAllPhong();
            DataView dv = new DataView(dt);
            dv.RowFilter = $"TrangThai LIKE '%{txtLoc.Text}%' OR LoaiPhong LIKE '%{txtLoc.Text}%'";
            dgvPhong.DataSource = dv;
        }
    }
}
