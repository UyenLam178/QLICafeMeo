// frmNhanVien.designer.cs
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLICafeMeo.Forms
{
    partial class frmNhanVien
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView _dgv;
        private TextBox _txtHoTen, _txtSDT, _txtTimKiem;
        private ComboBox _cbGioiTinh, _cbChucVu;
        private Button _btnThem, _btnSua, _btnXoa, _btnDoiMK, _btnXemChiTiet; 
        private Label _lblTitle;
        private GroupBox _gb;
        private TableLayoutPanel _tlp;
        private Label lblHoTen;
        private Label lblGioiTinh;
        private Label lblSDT;
        private Label lblChucVu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this._dgv = new System.Windows.Forms.DataGridView();
            this._txtHoTen = new System.Windows.Forms.TextBox();
            this._txtSDT = new System.Windows.Forms.TextBox();
            this._txtTimKiem = new System.Windows.Forms.TextBox();
            this._cbGioiTinh = new System.Windows.Forms.ComboBox();
            this._cbChucVu = new System.Windows.Forms.ComboBox();
            this._btnThem = new System.Windows.Forms.Button();
            this._btnSua = new System.Windows.Forms.Button();
            this._btnXoa = new System.Windows.Forms.Button();
            this._btnDoiMK = new System.Windows.Forms.Button();
            this._btnXemChiTiet = new System.Windows.Forms.Button();
            this._lblTitle = new System.Windows.Forms.Label();
            this._gb = new System.Windows.Forms.GroupBox();
            this._tlp = new System.Windows.Forms.TableLayoutPanel();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblChucVu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).BeginInit();
            this._gb.SuspendLayout();
            this._tlp.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dgv
            // 
            this._dgv.AllowUserToAddRows = false;
            this._dgv.AllowUserToDeleteRows = false;
            this._dgv.AllowUserToResizeRows = false;
            this._dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgv.BackgroundColor = System.Drawing.Color.White;
            this._dgv.ColumnHeadersHeight = 29;
            this._dgv.Location = new System.Drawing.Point(20, 100);
            this._dgv.Name = "_dgv";
            this._dgv.ReadOnly = true;
            this._dgv.RowHeadersVisible = false;
            this._dgv.RowHeadersWidth = 51;
            this._dgv.RowTemplate.Height = 24;
            this._dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgv.Size = new System.Drawing.Size(900, 300);
            this._dgv.TabIndex = 2;
            this._dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_CellClick);
            // 
            // _txtHoTen
            // 
            this._txtHoTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtHoTen.Location = new System.Drawing.Point(133, 13);
            this._txtHoTen.Name = "_txtHoTen";
            this._txtHoTen.Size = new System.Drawing.Size(48, 30);
            this._txtHoTen.TabIndex = 1;
            // 
            // _txtSDT
            // 
            this._txtSDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtSDT.Location = new System.Drawing.Point(464, 13);
            this._txtSDT.Name = "_txtSDT";
            this._txtSDT.Size = new System.Drawing.Size(156, 30);
            this._txtSDT.TabIndex = 5;
            // 
            // _txtTimKiem
            // 
            this._txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTimKiem.Location = new System.Drawing.Point(20, 60);
            this._txtTimKiem.Name = "_txtTimKiem";
            this._txtTimKiem.Size = new System.Drawing.Size(900, 30);
            this._txtTimKiem.TabIndex = 1;
            this._txtTimKiem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtTimKiem_KeyUp);
            // 
            // _cbGioiTinh
            // 
            this._cbGioiTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cbGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbGioiTinh.FormattingEnabled = true;
            this._cbGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this._cbGioiTinh.Location = new System.Drawing.Point(285, 13);
            this._cbGioiTinh.Name = "_cbGioiTinh";
            this._cbGioiTinh.Size = new System.Drawing.Size(48, 31);
            this._cbGioiTinh.TabIndex = 3;
            // 
            // _cbChucVu
            // 
            this._cbChucVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cbChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbChucVu.FormattingEnabled = true;
            this._cbChucVu.Items.AddRange(new object[] {
            "Admin",
            "QuanLy",
            "ThuNgan",
            "NhanVien"});
            this._cbChucVu.Location = new System.Drawing.Point(133, 43);
            this._cbChucVu.Name = "_cbChucVu";
            this._cbChucVu.Size = new System.Drawing.Size(48, 31);
            this._cbChucVu.TabIndex = 7;
            // 
            // _btnThem
            // 
            this._btnThem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this._btnThem.FlatAppearance.BorderSize = 0;
            this._btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnThem.ForeColor = System.Drawing.Color.White;
            this._btnThem.Location = new System.Drawing.Point(193, 90);
            this._btnThem.Name = "_btnThem";
            this._btnThem.Size = new System.Drawing.Size(80, 30);
            this._btnThem.TabIndex = 8;
            this._btnThem.Text = "THÊM";
            this._btnThem.UseVisualStyleBackColor = false;
            this._btnThem.Click += new System.EventHandler(this._btnThem_Click);
            // 
            // _btnSua
            // 
            this._btnSua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this._btnSua.FlatAppearance.BorderSize = 0;
            this._btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnSua.ForeColor = System.Drawing.Color.White;
            this._btnSua.Location = new System.Drawing.Point(358, 90);
            this._btnSua.Name = "_btnSua";
            this._btnSua.Size = new System.Drawing.Size(80, 30);
            this._btnSua.TabIndex = 9;
            this._btnSua.Text = "SỬA";
            this._btnSua.UseVisualStyleBackColor = false;
            this._btnSua.Click += new System.EventHandler(this._btnSua_Click);
            // 
            // _btnXoa
            // 
            this._btnXoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this._btnXoa.FlatAppearance.BorderSize = 0;
            this._btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnXoa.ForeColor = System.Drawing.Color.White;
            this._btnXoa.Location = new System.Drawing.Point(502, 90);
            this._btnXoa.Name = "_btnXoa";
            this._btnXoa.Size = new System.Drawing.Size(80, 30);
            this._btnXoa.TabIndex = 10;
            this._btnXoa.Text = "XÓA";
            this._btnXoa.UseVisualStyleBackColor = false;
            this._btnXoa.Click += new System.EventHandler(this._btnXoa_Click);
            // 
            // _btnDoiMK
            // 
            this._btnDoiMK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._btnDoiMK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this._btnDoiMK.FlatAppearance.BorderSize = 0;
            this._btnDoiMK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnDoiMK.ForeColor = System.Drawing.Color.White;
            this._btnDoiMK.Location = new System.Drawing.Point(648, 90);
            this._btnDoiMK.Name = "_btnDoiMK";
            this._btnDoiMK.Size = new System.Drawing.Size(80, 30);
            this._btnDoiMK.TabIndex = 11;
            this._btnDoiMK.Text = "ĐỔI MK";
            this._btnDoiMK.UseVisualStyleBackColor = false;
            this._btnDoiMK.Click += new System.EventHandler(this._btnDoiMK_Click);
            // 
            // _btnXemChiTiet
            // 
            this._btnXemChiTiet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._btnXemChiTiet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this._btnXemChiTiet.FlatAppearance.BorderSize = 0;
            this._btnXemChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnXemChiTiet.ForeColor = System.Drawing.Color.White;
            this._btnXemChiTiet.Location = new System.Drawing.Point(756, 90);
            this._btnXemChiTiet.Name = "_btnXemChiTiet";
            this._btnXemChiTiet.Size = new System.Drawing.Size(125, 30);
            this._btnXemChiTiet.TabIndex = 12;
            this._btnXemChiTiet.Text = "XEM CHI TIẾT";
            this._btnXemChiTiet.UseVisualStyleBackColor = false;
            this._btnXemChiTiet.Click += new System.EventHandler(this.BtnXemChiTiet_Click);
            // 
            // _lblTitle
            // 
            this._lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this._lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this._lblTitle.Location = new System.Drawing.Point(20, 15);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Size = new System.Drawing.Size(900, 37);
            this._lblTitle.TabIndex = 0;
            this._lblTitle.Text = "DANH SÁCH NHÂN VIÊN";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _gb
            // 
            this._gb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gb.Controls.Add(this._tlp);
            this._gb.Location = new System.Drawing.Point(20, 410);
            this._gb.Name = "_gb";
            this._gb.Size = new System.Drawing.Size(900, 180);
            this._gb.TabIndex = 3;
            this._gb.TabStop = false;
            this._gb.Text = "Thông tin";
            // 
            // _tlp
            // 
            this._tlp.ColumnCount = 8;
            this._tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this._tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this._tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this._tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this._tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this._tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this._tlp.Controls.Add(this.lblHoTen, 0, 0);
            this._tlp.Controls.Add(this._txtHoTen, 1, 0);
            this._tlp.Controls.Add(this.lblGioiTinh, 2, 0);
            this._tlp.Controls.Add(this._cbGioiTinh, 3, 0);
            this._tlp.Controls.Add(this.lblSDT, 4, 0);
            this._tlp.Controls.Add(this._txtSDT, 5, 0);
            this._tlp.Controls.Add(this.lblChucVu, 0, 1);
            this._tlp.Controls.Add(this._cbChucVu, 1, 1);
            this._tlp.Controls.Add(this._btnDoiMK, 6, 2);
            this._tlp.Controls.Add(this._btnXoa, 5, 2);
            this._tlp.Controls.Add(this._btnSua, 4, 2);
            this._tlp.Controls.Add(this._btnThem, 2, 2);
            this._tlp.Controls.Add(this._btnXemChiTiet, 7, 2);
            this._tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlp.Location = new System.Drawing.Point(3, 26);
            this._tlp.Name = "_tlp";
            this._tlp.Padding = new System.Windows.Forms.Padding(10);
            this._tlp.RowCount = 3;
            this._tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this._tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this._tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlp.Size = new System.Drawing.Size(894, 151);
            this._tlp.TabIndex = 0;
            // 
            // lblHoTen
            // 
            this.lblHoTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHoTen.Location = new System.Drawing.Point(13, 10);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(114, 30);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "Họ tên:";
            this.lblHoTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGioiTinh.Location = new System.Drawing.Point(187, 10);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(92, 30);
            this.lblGioiTinh.TabIndex = 2;
            this.lblGioiTinh.Text = "Giới tính:";
            this.lblGioiTinh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSDT
            // 
            this.lblSDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSDT.Location = new System.Drawing.Point(339, 10);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(119, 30);
            this.lblSDT.TabIndex = 4;
            this.lblSDT.Text = "SĐT:";
            this.lblSDT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblChucVu
            // 
            this.lblChucVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChucVu.Location = new System.Drawing.Point(13, 40);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Size = new System.Drawing.Size(114, 30);
            this.lblChucVu.TabIndex = 6;
            this.lblChucVu.Text = "Chức vụ:";
            this.lblChucVu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmNhanVien
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(940, 600);
            this.Controls.Add(this._lblTitle);
            this.Controls.Add(this._txtTimKiem);
            this.Controls.Add(this._dgv);
            this.Controls.Add(this._gb);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Nhân Viên";
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).EndInit();
            this._gb.ResumeLayout(false);
            this._tlp.ResumeLayout(false);
            this._tlp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}