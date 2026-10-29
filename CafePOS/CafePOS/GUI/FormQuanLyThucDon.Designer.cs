using System.Drawing;
using System.Windows.Forms;

namespace CafePOS.GUI
{
    partial class FormQuanLyThucDon
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbDanhMuc = new System.Windows.Forms.GroupBox();
            this.dgvDanhMuc = new System.Windows.Forms.DataGridView();
            this.lblTenDanhMuc = new System.Windows.Forms.Label();
            this.txtTenDanhMuc = new System.Windows.Forms.TextBox();
            this.btnThemDM = new System.Windows.Forms.Button();
            this.btnSuaDM = new System.Windows.Forms.Button();
            this.btnXoaDM = new System.Windows.Forms.Button();
            this.gbMon = new System.Windows.Forms.GroupBox();
            this.dgvMon = new System.Windows.Forms.DataGridView();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.lblDanhMucMon = new System.Windows.Forms.Label();
            this.cboDanhMucMon = new System.Windows.Forms.ComboBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.btnSuaMon = new System.Windows.Forms.Button();
            this.btnXoaMon = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tlpMain.SuspendLayout();
            this.gbDanhMuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).BeginInit();
            this.gbMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            //
            // tlpMain
            //
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62F));
            this.tlpMain.Controls.Add(this.gbDanhMuc, 0, 0);
            this.tlpMain.Controls.Add(this.gbMon, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(8);
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1040, 560);
            this.tlpMain.TabIndex = 0;
            //
            // gbDanhMuc
            //
            this.gbDanhMuc.Controls.Add(this.dgvDanhMuc);
            this.gbDanhMuc.Controls.Add(this.lblTenDanhMuc);
            this.gbDanhMuc.Controls.Add(this.txtTenDanhMuc);
            this.gbDanhMuc.Controls.Add(this.btnThemDM);
            this.gbDanhMuc.Controls.Add(this.btnSuaDM);
            this.gbDanhMuc.Controls.Add(this.btnXoaDM);
            this.gbDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDanhMuc.Location = new System.Drawing.Point(11, 11);
            this.gbDanhMuc.Name = "gbDanhMuc";
            this.gbDanhMuc.Size = new System.Drawing.Size(383, 538);
            this.gbDanhMuc.TabIndex = 0;
            this.gbDanhMuc.TabStop = false;
            this.gbDanhMuc.Text = "Danh mục";
            //
            // dgvDanhMuc
            //
            this.dgvDanhMuc.AllowUserToAddRows = false;
            this.dgvDanhMuc.AllowUserToDeleteRows = false;
            this.dgvDanhMuc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDanhMuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhMuc.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDanhMuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhMuc.Location = new System.Drawing.Point(12, 24);
            this.dgvDanhMuc.MultiSelect = false;
            this.dgvDanhMuc.Name = "dgvDanhMuc";
            this.dgvDanhMuc.ReadOnly = true;
            this.dgvDanhMuc.RowHeadersVisible = false;
            this.dgvDanhMuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhMuc.Size = new System.Drawing.Size(353, 370);
            this.dgvDanhMuc.TabIndex = 0;
            this.dgvDanhMuc.SelectionChanged += new System.EventHandler(this.dgvDanhMuc_SelectionChanged);
            //
            // lblTenDanhMuc
            //
            this.lblTenDanhMuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTenDanhMuc.AutoSize = true;
            this.lblTenDanhMuc.Location = new System.Drawing.Point(12, 406);
            this.lblTenDanhMuc.Name = "lblTenDanhMuc";
            this.lblTenDanhMuc.Size = new System.Drawing.Size(87, 15);
            this.lblTenDanhMuc.TabIndex = 1;
            this.lblTenDanhMuc.Text = "Tên danh mục:";
            //
            // txtTenDanhMuc
            //
            this.txtTenDanhMuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenDanhMuc.Location = new System.Drawing.Point(12, 426);
            this.txtTenDanhMuc.MaxLength = 100;
            this.txtTenDanhMuc.Name = "txtTenDanhMuc";
            this.txtTenDanhMuc.Size = new System.Drawing.Size(353, 23);
            this.txtTenDanhMuc.TabIndex = 2;
            //
            // btnThemDM
            //
            this.btnThemDM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThemDM.Location = new System.Drawing.Point(12, 464);
            this.btnThemDM.Name = "btnThemDM";
            this.btnThemDM.Size = new System.Drawing.Size(108, 32);
            this.btnThemDM.TabIndex = 3;
            this.btnThemDM.Text = "Thêm";
            this.btnThemDM.UseVisualStyleBackColor = true;
            this.btnThemDM.Click += new System.EventHandler(this.btnThemDM_Click);
            //
            // btnSuaDM
            //
            this.btnSuaDM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSuaDM.Location = new System.Drawing.Point(128, 464);
            this.btnSuaDM.Name = "btnSuaDM";
            this.btnSuaDM.Size = new System.Drawing.Size(108, 32);
            this.btnSuaDM.TabIndex = 4;
            this.btnSuaDM.Text = "Sửa";
            this.btnSuaDM.UseVisualStyleBackColor = true;
            this.btnSuaDM.Click += new System.EventHandler(this.btnSuaDM_Click);
            //
            // btnXoaDM
            //
            this.btnXoaDM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoaDM.Location = new System.Drawing.Point(244, 464);
            this.btnXoaDM.Name = "btnXoaDM";
            this.btnXoaDM.Size = new System.Drawing.Size(108, 32);
            this.btnXoaDM.TabIndex = 5;
            this.btnXoaDM.Text = "Xóa";
            this.btnXoaDM.UseVisualStyleBackColor = true;
            this.btnXoaDM.Click += new System.EventHandler(this.btnXoaDM_Click);
            //
            // gbMon
            //
            this.gbMon.Controls.Add(this.dgvMon);
            this.gbMon.Controls.Add(this.lblTenMon);
            this.gbMon.Controls.Add(this.txtTenMon);
            this.gbMon.Controls.Add(this.lblDanhMucMon);
            this.gbMon.Controls.Add(this.cboDanhMucMon);
            this.gbMon.Controls.Add(this.lblDonGia);
            this.gbMon.Controls.Add(this.txtDonGia);
            this.gbMon.Controls.Add(this.btnThemMon);
            this.gbMon.Controls.Add(this.btnSuaMon);
            this.gbMon.Controls.Add(this.btnXoaMon);
            this.gbMon.Controls.Add(this.btnLamMoi);
            this.gbMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMon.Location = new System.Drawing.Point(400, 11);
            this.gbMon.Name = "gbMon";
            this.gbMon.Size = new System.Drawing.Size(629, 538);
            this.gbMon.TabIndex = 1;
            this.gbMon.TabStop = false;
            this.gbMon.Text = "Thực đơn";
            //
            // dgvMon
            //
            this.dgvMon.AllowUserToAddRows = false;
            this.dgvMon.AllowUserToDeleteRows = false;
            this.dgvMon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMon.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMon.Location = new System.Drawing.Point(12, 24);
            this.dgvMon.MultiSelect = false;
            this.dgvMon.Name = "dgvMon";
            this.dgvMon.ReadOnly = true;
            this.dgvMon.RowHeadersVisible = false;
            this.dgvMon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMon.Size = new System.Drawing.Size(599, 330);
            this.dgvMon.TabIndex = 0;
            this.dgvMon.SelectionChanged += new System.EventHandler(this.dgvMon_SelectionChanged);
            //
            // lblTenMon
            //
            this.lblTenMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTenMon.AutoSize = true;
            this.lblTenMon.Location = new System.Drawing.Point(12, 376);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(51, 15);
            this.lblTenMon.TabIndex = 1;
            this.lblTenMon.Text = "Tên món:";
            //
            // txtTenMon
            //
            this.txtTenMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTenMon.Location = new System.Drawing.Point(100, 372);
            this.txtTenMon.MaxLength = 100;
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(250, 23);
            this.txtTenMon.TabIndex = 2;
            //
            // lblDanhMucMon
            //
            this.lblDanhMucMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDanhMucMon.AutoSize = true;
            this.lblDanhMucMon.Location = new System.Drawing.Point(370, 376);
            this.lblDanhMucMon.Name = "lblDanhMucMon";
            this.lblDanhMucMon.Size = new System.Drawing.Size(62, 15);
            this.lblDanhMucMon.TabIndex = 3;
            this.lblDanhMucMon.Text = "Danh mục:";
            //
            // cboDanhMucMon
            //
            this.cboDanhMucMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboDanhMucMon.DisplayMember = "TenDanhMuc";
            this.cboDanhMucMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMucMon.FormattingEnabled = true;
            this.cboDanhMucMon.Location = new System.Drawing.Point(445, 372);
            this.cboDanhMucMon.Name = "cboDanhMucMon";
            this.cboDanhMucMon.Size = new System.Drawing.Size(166, 23);
            this.cboDanhMucMon.TabIndex = 4;
            this.cboDanhMucMon.ValueMember = "MaDanhMuc";
            //
            // lblDonGia
            //
            this.lblDonGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(12, 416);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(70, 15);
            this.lblDonGia.TabIndex = 5;
            this.lblDonGia.Text = "Đơn giá (đ):";
            //
            // txtDonGia
            //
            this.txtDonGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDonGia.Location = new System.Drawing.Point(100, 412);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(150, 23);
            this.txtDonGia.TabIndex = 6;
            //
            // btnThemMon
            //
            this.btnThemMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThemMon.Location = new System.Drawing.Point(12, 464);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(138, 34);
            this.btnThemMon.TabIndex = 7;
            this.btnThemMon.Text = "Thêm món";
            this.btnThemMon.UseVisualStyleBackColor = true;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            //
            // btnSuaMon
            //
            this.btnSuaMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSuaMon.Location = new System.Drawing.Point(160, 464);
            this.btnSuaMon.Name = "btnSuaMon";
            this.btnSuaMon.Size = new System.Drawing.Size(138, 34);
            this.btnSuaMon.TabIndex = 8;
            this.btnSuaMon.Text = "Sửa món / giá";
            this.btnSuaMon.UseVisualStyleBackColor = true;
            this.btnSuaMon.Click += new System.EventHandler(this.btnSuaMon_Click);
            //
            // btnXoaMon
            //
            this.btnXoaMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoaMon.Location = new System.Drawing.Point(308, 464);
            this.btnXoaMon.Name = "btnXoaMon";
            this.btnXoaMon.Size = new System.Drawing.Size(138, 34);
            this.btnXoaMon.TabIndex = 9;
            this.btnXoaMon.Text = "Xóa món";
            this.btnXoaMon.UseVisualStyleBackColor = true;
            this.btnXoaMon.Click += new System.EventHandler(this.btnXoaMon_Click);
            //
            // btnLamMoi
            //
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLamMoi.Location = new System.Drawing.Point(456, 464);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(138, 34);
            this.btnLamMoi.TabIndex = 10;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            //
            // errorProvider1
            //
            this.errorProvider1.ContainerControl = this;
            //
            // FormQuanLyThucDon
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 560);
            this.Controls.Add(this.tlpMain);
            this.MinimumSize = new System.Drawing.Size(900, 540);
            this.Name = "FormQuanLyThucDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý danh mục & thực đơn";
            this.Load += new System.EventHandler(this.FormQuanLyThucDon_Load);
            this.tlpMain.ResumeLayout(false);
            this.gbDanhMuc.ResumeLayout(false);
            this.gbDanhMuc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).EndInit();
            this.gbMon.ResumeLayout(false);
            this.gbMon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox gbDanhMuc;
        private System.Windows.Forms.DataGridView dgvDanhMuc;
        private System.Windows.Forms.Label lblTenDanhMuc;
        private System.Windows.Forms.TextBox txtTenDanhMuc;
        private System.Windows.Forms.Button btnThemDM;
        private System.Windows.Forms.Button btnSuaDM;
        private System.Windows.Forms.Button btnXoaDM;
        private System.Windows.Forms.GroupBox gbMon;
        private System.Windows.Forms.DataGridView dgvMon;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.Label lblDanhMucMon;
        private System.Windows.Forms.ComboBox cboDanhMucMon;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Button btnSuaMon;
        private System.Windows.Forms.Button btnXoaMon;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
