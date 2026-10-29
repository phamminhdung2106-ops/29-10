
namespace InventoryManagementSystem.GUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvVatTu = new System.Windows.Forms.DataGridView();
            this.dgvChiTietPhieu = new System.Windows.Forms.DataGridView();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.btnThemVaoPhieu = new System.Windows.Forms.Button();
            this.btnLuuPhieu = new System.Windows.Forms.Button();
            this.cboLoaiPhieu = new System.Windows.Forms.ComboBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblTongGiaTri = new System.Windows.Forms.Label();
            this.btnCanhBao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVatTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVatTu
            // 
            this.dgvVatTu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVatTu.Location = new System.Drawing.Point(12, 50);
            this.dgvVatTu.Name = "dgvVatTu";
            this.dgvVatTu.Size = new System.Drawing.Size(400, 250);
            this.dgvVatTu.TabIndex = 0;
            // 
            // dgvChiTietPhieu
            // 
            this.dgvChiTietPhieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietPhieu.Location = new System.Drawing.Point(430, 50);
            this.dgvChiTietPhieu.Name = "dgvChiTietPhieu";
            this.dgvChiTietPhieu.Size = new System.Drawing.Size(400, 180);
            this.dgvChiTietPhieu.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(80, 20);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(200, 20);
            this.txtTimKiem.TabIndex = 2;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tìm Vật Tư:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(12, 310);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(100, 20);
            this.txtSoLuong.TabIndex = 4;
            this.txtSoLuong.Text = "1";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(120, 310);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(100, 20);
            this.txtDonGia.TabIndex = 5;
            this.txtDonGia.Text = "10000";
            // 
            // btnThemVaoPhieu
            // 
            this.btnThemVaoPhieu.Location = new System.Drawing.Point(230, 308);
            this.btnThemVaoPhieu.Name = "btnThemVaoPhieu";
            this.btnThemVaoPhieu.Size = new System.Drawing.Size(100, 23);
            this.btnThemVaoPhieu.TabIndex = 6;
            this.btnThemVaoPhieu.Text = "Thêm vào phiếu";
            this.btnThemVaoPhieu.UseVisualStyleBackColor = true;
            this.btnThemVaoPhieu.Click += new System.EventHandler(this.btnThemVaoPhieu_Click);
            // 
            // btnLuuPhieu
            // 
            this.btnLuuPhieu.Location = new System.Drawing.Point(730, 308);
            this.btnLuuPhieu.Name = "btnLuuPhieu";
            this.btnLuuPhieu.Size = new System.Drawing.Size(100, 30);
            this.btnLuuPhieu.TabIndex = 7;
            this.btnLuuPhieu.Text = "Lưu Phiếu";
            this.btnLuuPhieu.UseVisualStyleBackColor = true;
            this.btnLuuPhieu.Click += new System.EventHandler(this.btnLuuPhieu_Click);
            // 
            // cboLoaiPhieu
            // 
            this.cboLoaiPhieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiPhieu.FormattingEnabled = true;
            this.cboLoaiPhieu.Items.AddRange(new object[] {
            "NHAP",
            "XUAT"});
            this.cboLoaiPhieu.Location = new System.Drawing.Point(430, 20);
            this.cboLoaiPhieu.Name = "cboLoaiPhieu";
            this.cboLoaiPhieu.Size = new System.Drawing.Size(121, 21);
            this.cboLoaiPhieu.TabIndex = 8;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.Red;
            this.lblTongTien.Location = new System.Drawing.Point(430, 240);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(59, 20);
            this.lblTongTien.TabIndex = 9;
            this.lblTongTien.Text = "0 VNĐ";
            // 
            // lblTongGiaTri
            // 
            this.lblTongGiaTri.AutoSize = true;
            this.lblTongGiaTri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongGiaTri.Location = new System.Drawing.Point(12, 340);
            this.lblTongGiaTri.Name = "lblTongGiaTri";
            this.lblTongGiaTri.Size = new System.Drawing.Size(107, 15);
            this.lblTongGiaTri.TabIndex = 10;
            this.lblTongGiaTri.Text = "Tổng GT Tồn Kho:";
            // 
            // btnCanhBao
            // 
            this.btnCanhBao.Location = new System.Drawing.Point(290, 18);
            this.btnCanhBao.Name = "btnCanhBao";
            this.btnCanhBao.Size = new System.Drawing.Size(120, 23);
            this.btnCanhBao.TabIndex = 11;
            this.btnCanhBao.Text = "Cảnh báo Tồn Kho";
            this.btnCanhBao.UseVisualStyleBackColor = true;
            this.btnCanhBao.Click += new System.EventHandler(this.btnCanhBao_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(850, 380);
            this.Controls.Add(this.btnCanhBao);
            this.Controls.Add(this.lblTongGiaTri);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.cboLoaiPhieu);
            this.Controls.Add(this.btnLuuPhieu);
            this.Controls.Add(this.btnThemVaoPhieu);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.dgvChiTietPhieu);
            this.Controls.Add(this.dgvVatTu);
            this.Name = "MainForm";
            this.Text = "Quản lý Xuất Nhập Kho (Bài 5.5) - 3 Tier Architecture";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVatTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dgvVatTu;
        private System.Windows.Forms.DataGridView dgvChiTietPhieu;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Button btnThemVaoPhieu;
        private System.Windows.Forms.Button btnLuuPhieu;
        private System.Windows.Forms.ComboBox cboLoaiPhieu;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblTongGiaTri;
        private System.Windows.Forms.Button btnCanhBao;
    }
}
