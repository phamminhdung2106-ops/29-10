using System.Drawing;
using System.Windows.Forms;

namespace CafePOS.GUI
{
    partial class Form1
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Clean up any resources being used.</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>Required method for Designer support.</summary>
        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbSoDoBan = new System.Windows.Forms.GroupBox();
            this.flpBan = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlLegend = new System.Windows.Forms.Panel();
            this.lblChuThichCoKhach = new System.Windows.Forms.Label();
            this.lblChuThichTrong = new System.Windows.Forms.Label();
            this.gbOrder = new System.Windows.Forms.GroupBox();
            this.lblBanChon = new System.Windows.Forms.Label();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.gbThemMon = new System.Windows.Forms.GroupBox();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.lblMon = new System.Windows.Forms.Label();
            this.cboMon = new System.Windows.Forms.ComboBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.btnXoaMon = new System.Windows.Forms.Button();
            this.gbThanhToan = new System.Windows.Forms.GroupBox();
            this.lblTong = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblDoiBan = new System.Windows.Forms.Label();
            this.cboBanTrong = new System.Windows.Forms.ComboBox();
            this.btnDoiBan = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnQuanLyThucDon = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.gbSoDoBan.SuspendLayout();
            this.pnlLegend.SuspendLayout();
            this.gbOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.gbThemMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.gbThanhToan.SuspendLayout();
            this.SuspendLayout();
            //
            // tlpMain
            //
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpMain.Controls.Add(this.gbSoDoBan, 0, 0);
            this.tlpMain.Controls.Add(this.gbOrder, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(8);
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1180, 700);
            this.tlpMain.TabIndex = 0;
            //
            // gbSoDoBan
            //
            this.gbSoDoBan.Controls.Add(this.flpBan);
            this.gbSoDoBan.Controls.Add(this.pnlLegend);
            this.gbSoDoBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSoDoBan.Location = new System.Drawing.Point(11, 11);
            this.gbSoDoBan.Name = "gbSoDoBan";
            this.gbSoDoBan.Size = new System.Drawing.Size(634, 678);
            this.gbSoDoBan.TabIndex = 0;
            this.gbSoDoBan.TabStop = false;
            this.gbSoDoBan.Text = "Sơ đồ bàn";
            //
            // flpBan
            //
            this.flpBan.AutoScroll = true;
            this.flpBan.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBan.Location = new System.Drawing.Point(3, 19);
            this.flpBan.Name = "flpBan";
            this.flpBan.Padding = new System.Windows.Forms.Padding(6);
            this.flpBan.Size = new System.Drawing.Size(628, 620);
            this.flpBan.TabIndex = 0;
            //
            // pnlLegend
            //
            this.pnlLegend.Controls.Add(this.lblChuThichCoKhach);
            this.pnlLegend.Controls.Add(this.lblChuThichTrong);
            this.pnlLegend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLegend.Location = new System.Drawing.Point(3, 639);
            this.pnlLegend.Name = "pnlLegend";
            this.pnlLegend.Size = new System.Drawing.Size(628, 36);
            this.pnlLegend.TabIndex = 1;
            //
            // lblChuThichCoKhach
            //
            this.lblChuThichCoKhach.AutoSize = true;
            this.lblChuThichCoKhach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblChuThichCoKhach.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.lblChuThichCoKhach.Location = new System.Drawing.Point(120, 8);
            this.lblChuThichCoKhach.Name = "lblChuThichCoKhach";
            this.lblChuThichCoKhach.Size = new System.Drawing.Size(94, 19);
            this.lblChuThichCoKhach.TabIndex = 1;
            this.lblChuThichCoKhach.Text = "■ Có khách";
            //
            // lblChuThichTrong
            //
            this.lblChuThichTrong.AutoSize = true;
            this.lblChuThichTrong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblChuThichTrong.ForeColor = System.Drawing.Color.FromArgb(46, 160, 67);
            this.lblChuThichTrong.Location = new System.Drawing.Point(12, 8);
            this.lblChuThichTrong.Name = "lblChuThichTrong";
            this.lblChuThichTrong.Size = new System.Drawing.Size(72, 19);
            this.lblChuThichTrong.TabIndex = 0;
            this.lblChuThichTrong.Text = "■ Trống";
            //
            // gbOrder
            //
            this.gbOrder.Controls.Add(this.lblBanChon);
            this.gbOrder.Controls.Add(this.dgvChiTiet);
            this.gbOrder.Controls.Add(this.gbThemMon);
            this.gbOrder.Controls.Add(this.gbThanhToan);
            this.gbOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOrder.Location = new System.Drawing.Point(651, 11);
            this.gbOrder.Name = "gbOrder";
            this.gbOrder.Size = new System.Drawing.Size(518, 678);
            this.gbOrder.TabIndex = 1;
            this.gbOrder.TabStop = false;
            this.gbOrder.Text = "Gọi món && thanh toán";
            //
            // lblBanChon
            //
            this.lblBanChon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBanChon.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBanChon.Location = new System.Drawing.Point(12, 24);
            this.lblBanChon.Name = "lblBanChon";
            this.lblBanChon.Size = new System.Drawing.Size(494, 32);
            this.lblBanChon.TabIndex = 0;
            this.lblBanChon.Text = "Chưa chọn bàn";
            this.lblBanChon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dgvChiTiet
            //
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Location = new System.Drawing.Point(12, 62);
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(494, 280);
            this.dgvChiTiet.TabIndex = 1;
            //
            // gbThemMon
            //
            this.gbThemMon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbThemMon.Controls.Add(this.lblDanhMuc);
            this.gbThemMon.Controls.Add(this.cboDanhMuc);
            this.gbThemMon.Controls.Add(this.lblMon);
            this.gbThemMon.Controls.Add(this.cboMon);
            this.gbThemMon.Controls.Add(this.lblSoLuong);
            this.gbThemMon.Controls.Add(this.nudSoLuong);
            this.gbThemMon.Controls.Add(this.btnThemMon);
            this.gbThemMon.Controls.Add(this.btnXoaMon);
            this.gbThemMon.Location = new System.Drawing.Point(12, 350);
            this.gbThemMon.Name = "gbThemMon";
            this.gbThemMon.Size = new System.Drawing.Size(494, 112);
            this.gbThemMon.TabIndex = 2;
            this.gbThemMon.TabStop = false;
            this.gbThemMon.Text = "Thêm món";
            //
            // lblDanhMuc
            //
            this.lblDanhMuc.AutoSize = true;
            this.lblDanhMuc.Location = new System.Drawing.Point(12, 28);
            this.lblDanhMuc.Name = "lblDanhMuc";
            this.lblDanhMuc.Size = new System.Drawing.Size(62, 15);
            this.lblDanhMuc.TabIndex = 0;
            this.lblDanhMuc.Text = "Danh mục:";
            //
            // cboDanhMuc
            //
            this.cboDanhMuc.DisplayMember = "TenDanhMuc";
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(80, 24);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(150, 23);
            this.cboDanhMuc.TabIndex = 1;
            this.cboDanhMuc.ValueMember = "MaDanhMuc";
            this.cboDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cboDanhMuc_SelectedIndexChanged);
            //
            // lblMon
            //
            this.lblMon.AutoSize = true;
            this.lblMon.Location = new System.Drawing.Point(244, 28);
            this.lblMon.Name = "lblMon";
            this.lblMon.Size = new System.Drawing.Size(34, 15);
            this.lblMon.TabIndex = 2;
            this.lblMon.Text = "Món:";
            //
            // cboMon
            //
            this.cboMon.DisplayMember = "TenHienThi";
            this.cboMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMon.FormattingEnabled = true;
            this.cboMon.Location = new System.Drawing.Point(284, 24);
            this.cboMon.Name = "cboMon";
            this.cboMon.Size = new System.Drawing.Size(198, 23);
            this.cboMon.TabIndex = 3;
            this.cboMon.ValueMember = "MaMon";
            //
            // lblSoLuong
            //
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(12, 66);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(55, 15);
            this.lblSoLuong.TabIndex = 4;
            this.lblSoLuong.Text = "Số lượng:";
            //
            // nudSoLuong
            //
            this.nudSoLuong.Location = new System.Drawing.Point(80, 62);
            this.nudSoLuong.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            this.nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(60, 23);
            this.nudSoLuong.TabIndex = 5;
            this.nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // btnThemMon
            //
            this.btnThemMon.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThemMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMon.ForeColor = System.Drawing.Color.White;
            this.btnThemMon.Location = new System.Drawing.Point(160, 56);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(150, 32);
            this.btnThemMon.TabIndex = 6;
            this.btnThemMon.Text = "Thêm món";
            this.btnThemMon.UseVisualStyleBackColor = false;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            //
            // btnXoaMon
            //
            this.btnXoaMon.Location = new System.Drawing.Point(324, 56);
            this.btnXoaMon.Name = "btnXoaMon";
            this.btnXoaMon.Size = new System.Drawing.Size(158, 32);
            this.btnXoaMon.TabIndex = 7;
            this.btnXoaMon.Text = "Xóa món đã chọn";
            this.btnXoaMon.UseVisualStyleBackColor = true;
            this.btnXoaMon.Click += new System.EventHandler(this.btnXoaMon_Click);
            //
            // gbThanhToan
            //
            this.gbThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbThanhToan.Controls.Add(this.lblTong);
            this.gbThanhToan.Controls.Add(this.lblTongTien);
            this.gbThanhToan.Controls.Add(this.lblDoiBan);
            this.gbThanhToan.Controls.Add(this.cboBanTrong);
            this.gbThanhToan.Controls.Add(this.btnDoiBan);
            this.gbThanhToan.Controls.Add(this.btnThanhToan);
            this.gbThanhToan.Controls.Add(this.btnQuanLyThucDon);
            this.gbThanhToan.Location = new System.Drawing.Point(12, 470);
            this.gbThanhToan.Name = "gbThanhToan";
            this.gbThanhToan.Size = new System.Drawing.Size(494, 170);
            this.gbThanhToan.TabIndex = 3;
            this.gbThanhToan.TabStop = false;
            this.gbThanhToan.Text = "Thanh toán";
            //
            // lblTong
            //
            this.lblTong.AutoSize = true;
            this.lblTong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTong.Location = new System.Drawing.Point(12, 28);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(83, 21);
            this.lblTong.TabIndex = 0;
            this.lblTong.Text = "Tổng tiền:";
            //
            // lblTongTien
            //
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTongTien.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTongTien.Location = new System.Drawing.Point(110, 20);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(372, 40);
            this.lblTongTien.TabIndex = 1;
            this.lblTongTien.Text = "0 đ";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblDoiBan
            //
            this.lblDoiBan.AutoSize = true;
            this.lblDoiBan.Location = new System.Drawing.Point(12, 76);
            this.lblDoiBan.Name = "lblDoiBan";
            this.lblDoiBan.Size = new System.Drawing.Size(80, 15);
            this.lblDoiBan.TabIndex = 2;
            this.lblDoiBan.Text = "Đổi sang bàn:";
            //
            // cboBanTrong
            //
            this.cboBanTrong.DisplayMember = "TenBan";
            this.cboBanTrong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBanTrong.FormattingEnabled = true;
            this.cboBanTrong.Location = new System.Drawing.Point(104, 72);
            this.cboBanTrong.Name = "cboBanTrong";
            this.cboBanTrong.Size = new System.Drawing.Size(150, 23);
            this.cboBanTrong.TabIndex = 3;
            this.cboBanTrong.ValueMember = "MaBan";
            //
            // btnDoiBan
            //
            this.btnDoiBan.Location = new System.Drawing.Point(264, 68);
            this.btnDoiBan.Name = "btnDoiBan";
            this.btnDoiBan.Size = new System.Drawing.Size(100, 30);
            this.btnDoiBan.TabIndex = 4;
            this.btnDoiBan.Text = "Đổi bàn";
            this.btnDoiBan.UseVisualStyleBackColor = true;
            this.btnDoiBan.Click += new System.EventHandler(this.btnDoiBan_Click);
            //
            // btnThanhToan
            //
            this.btnThanhToan.BackColor = System.Drawing.Color.SeaGreen;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(12, 108);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(230, 36);
            this.btnThanhToan.TabIndex = 5;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            //
            // btnQuanLyThucDon
            //
            this.btnQuanLyThucDon.Location = new System.Drawing.Point(252, 108);
            this.btnQuanLyThucDon.Name = "btnQuanLyThucDon";
            this.btnQuanLyThucDon.Size = new System.Drawing.Size(230, 36);
            this.btnQuanLyThucDon.TabIndex = 6;
            this.btnQuanLyThucDon.Text = "Quản lý thực đơn";
            this.btnQuanLyThucDon.UseVisualStyleBackColor = true;
            this.btnQuanLyThucDon.Click += new System.EventHandler(this.btnQuanLyThucDon_Click);
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 700);
            this.Controls.Add(this.tlpMain);
            this.MinimumSize = new System.Drawing.Size(1000, 680);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý quán Cafe - POS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tlpMain.ResumeLayout(false);
            this.gbSoDoBan.ResumeLayout(false);
            this.pnlLegend.ResumeLayout(false);
            this.pnlLegend.PerformLayout();
            this.gbOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.gbThemMon.ResumeLayout(false);
            this.gbThemMon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.gbThanhToan.ResumeLayout(false);
            this.gbThanhToan.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox gbSoDoBan;
        private System.Windows.Forms.FlowLayoutPanel flpBan;
        private System.Windows.Forms.Panel pnlLegend;
        private System.Windows.Forms.Label lblChuThichCoKhach;
        private System.Windows.Forms.Label lblChuThichTrong;
        private System.Windows.Forms.GroupBox gbOrder;
        private System.Windows.Forms.Label lblBanChon;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.GroupBox gbThemMon;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.Label lblMon;
        private System.Windows.Forms.ComboBox cboMon;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Button btnXoaMon;
        private System.Windows.Forms.GroupBox gbThanhToan;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblDoiBan;
        private System.Windows.Forms.ComboBox cboBanTrong;
        private System.Windows.Forms.Button btnDoiBan;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnQuanLyThucDon;
    }
}
