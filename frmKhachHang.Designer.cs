// frmKhachHang.Designer.cs 
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLICafeMeo
{
    partial class frmKhachHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private DataGridView _dgv;
        private TextBox _txtHoTen, _txtSDT, _txtTimKiem;
        private NumericUpDown _nudDiem;
        private Button _btnThem, _btnSua, _btnXoa;
        private Button _btnXemChiTiet; // KHAI BÁO NÚT MỚI
        private Label _lblTitle;
        private GroupBox _gb;
        private TableLayoutPanel _tlp;
        private Label lblHoTen;
        private Label lblSDT;
        private Label lblDiem;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this._dgv = new System.Windows.Forms.DataGridView();
            this._txtHoTen = new System.Windows.Forms.TextBox();
            this._txtSDT = new System.Windows.Forms.TextBox();
            this._txtTimKiem = new System.Windows.Forms.TextBox();
            this._nudDiem = new System.Windows.Forms.NumericUpDown();
            this._btnThem = new System.Windows.Forms.Button();
            this._btnSua = new System.Windows.Forms.Button();
            this._btnXoa = new System.Windows.Forms.Button();
            this._btnXemChiTiet = new System.Windows.Forms.Button();
            this._lblTitle = new System.Windows.Forms.Label();
            this._gb = new System.Windows.Forms.GroupBox();
            this._tlp = new System.Windows.Forms.TableLayoutPanel();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblDiem = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudDiem)).BeginInit();
            this._gb.SuspendLayout();
            this._tlp.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dgv
            // 
            this._dgv.AllowUserToAddRows = false;
            this._dgv.AllowUserToDeleteRows = false;
            this._dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgv.BackgroundColor = System.Drawing.Color.White;
            this._dgv.ColumnHeadersHeight = 50;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dgv.DefaultCellStyle = dataGridViewCellStyle1;
            this._dgv.Location = new System.Drawing.Point(20, 140);
            this._dgv.Name = "_dgv";
            this._dgv.ReadOnly = true;
            this._dgv.RowHeadersVisible = false;
            this._dgv.RowHeadersWidth = 51;
            this._dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgv.Size = new System.Drawing.Size(900, 270);
            this._dgv.TabIndex = 2;
            this._dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_CellClick);
            // 
            // _txtHoTen
            // 
            this._txtHoTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtHoTen.Location = new System.Drawing.Point(93, 13);
            this._txtHoTen.Name = "_txtHoTen";
            this._txtHoTen.Size = new System.Drawing.Size(118, 31);
            this._txtHoTen.TabIndex = 1;
            // 
            // _txtSDT
            // 
            this._txtSDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtSDT.Location = new System.Drawing.Point(360, 13);
            this._txtSDT.Name = "_txtSDT";
            this._txtSDT.Size = new System.Drawing.Size(118, 31);
            this._txtSDT.TabIndex = 3;
            // 
            // _txtTimKiem
            // 
            this._txtTimKiem.Location = new System.Drawing.Point(20, 100);
            this._txtTimKiem.Name = "_txtTimKiem";
            this._txtTimKiem.Size = new System.Drawing.Size(350, 31);
            this._txtTimKiem.TabIndex = 1;
            this._txtTimKiem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtTimKiem_KeyUp);
            // 
            // _nudDiem
            // 
            this._nudDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this._nudDiem.Location = new System.Drawing.Point(636, 13);
            this._nudDiem.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._nudDiem.Name = "_nudDiem";
            this._nudDiem.Size = new System.Drawing.Size(118, 31);
            this._nudDiem.TabIndex = 5;
            this._nudDiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _btnThem
            // 
            this._btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this._btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnThem.ForeColor = System.Drawing.Color.White;
            this._btnThem.Location = new System.Drawing.Point(93, 63);
            this._btnThem.Name = "_btnThem";
            this._btnThem.Size = new System.Drawing.Size(100, 35);
            this._btnThem.TabIndex = 6;
            this._btnThem.Text = "THÊM";
            this._btnThem.UseVisualStyleBackColor = false;
            this._btnThem.Click += new System.EventHandler(this._btnThem_Click);
            // 
            // _btnSua
            // 
            this._btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this._btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnSua.ForeColor = System.Drawing.Color.White;
            this._btnSua.Location = new System.Drawing.Point(217, 63);
            this._btnSua.Name = "_btnSua";
            this._btnSua.Size = new System.Drawing.Size(100, 35);
            this._btnSua.TabIndex = 7;
            this._btnSua.Text = "SỬA";
            this._btnSua.UseVisualStyleBackColor = false;
            this._btnSua.Click += new System.EventHandler(this._btnSua_Click);
            // 
            // _btnXoa
            // 
            this._btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this._btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnXoa.ForeColor = System.Drawing.Color.White;
            this._btnXoa.Location = new System.Drawing.Point(360, 63);
            this._btnXoa.Name = "_btnXoa";
            this._btnXoa.Size = new System.Drawing.Size(100, 35);
            this._btnXoa.TabIndex = 8;
            this._btnXoa.Text = "XÓA";
            this._btnXoa.UseVisualStyleBackColor = false;
            this._btnXoa.Click += new System.EventHandler(this._btnXoa_Click);
            // 
            // _btnXemChiTiet
            // 
            this._btnXemChiTiet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this._btnXemChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnXemChiTiet.ForeColor = System.Drawing.Color.White;
            this._btnXemChiTiet.Location = new System.Drawing.Point(484, 63);
            this._btnXemChiTiet.Name = "_btnXemChiTiet";
            this._btnXemChiTiet.Size = new System.Drawing.Size(130, 35);
            this._btnXemChiTiet.TabIndex = 9;
            this._btnXemChiTiet.Text = "XEM CHI TIẾT";
            this._btnXemChiTiet.UseVisualStyleBackColor = false;
            this._btnXemChiTiet.Click += new System.EventHandler(this.BtnXemChiTiet_Click);
            // 
            // _lblTitle
            // 
            this._lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this._lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this._lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this._lblTitle.Location = new System.Drawing.Point(0, 0);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Padding = new System.Windows.Forms.Padding(0, 25, 0, 10);
            this._lblTitle.Size = new System.Drawing.Size(940, 90);
            this._lblTitle.TabIndex = 0;
            this._lblTitle.Text = "DANH SÁCH KHÁCH HÀNG";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _gb
            // 
            this._gb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gb.Controls.Add(this._tlp);
            this._gb.Location = new System.Drawing.Point(20, 430);
            this._gb.Name = "_gb";
            this._gb.Size = new System.Drawing.Size(900, 150);
            this._gb.TabIndex = 3;
            this._gb.TabStop = false;
            this._gb.Text = "Thông tin Khách Hàng";
            // 
            // _tlp
            // 
            this._tlp.ColumnCount = 7;
            this._tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this._tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this._tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this._tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlp.Controls.Add(this.lblHoTen, 0, 0);
            this._tlp.Controls.Add(this._txtHoTen, 1, 0);
            this._tlp.Controls.Add(this.lblSDT, 2, 0);
            this._tlp.Controls.Add(this._txtSDT, 3, 0);
            this._tlp.Controls.Add(this.lblDiem, 4, 0);
            this._tlp.Controls.Add(this._nudDiem, 5, 0);
            this._tlp.Controls.Add(this._btnThem, 1, 2);
            this._tlp.Controls.Add(this._btnSua, 2, 2);
            this._tlp.Controls.Add(this._btnXoa, 3, 2);
            this._tlp.Controls.Add(this._btnXemChiTiet, 4, 2);
            this._tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlp.Location = new System.Drawing.Point(3, 27);
            this._tlp.Name = "_tlp";
            this._tlp.Padding = new System.Windows.Forms.Padding(10);
            this._tlp.RowCount = 3;
            this._tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this._tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this._tlp.Size = new System.Drawing.Size(894, 120);
            this._tlp.TabIndex = 0;
            // 
            // lblHoTen
            // 
            this.lblHoTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHoTen.Location = new System.Drawing.Point(13, 10);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(74, 40);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "Họ tên:";
            this.lblHoTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSDT
            // 
            this.lblSDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSDT.Location = new System.Drawing.Point(217, 10);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(137, 40);
            this.lblSDT.TabIndex = 2;
            this.lblSDT.Text = "SĐT:";
            this.lblSDT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiem
            // 
            this.lblDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiem.Location = new System.Drawing.Point(484, 10);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(146, 40);
            this.lblDiem.TabIndex = 4;
            this.lblDiem.Text = "Điểm:";
            this.lblDiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmKhachHang
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(940, 620);
            this.Controls.Add(this._lblTitle);
            this.Controls.Add(this._txtTimKiem);
            this.Controls.Add(this._dgv);
            this.Controls.Add(this._gb);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Khách Hàng";
            this.Load += new System.EventHandler(this.frmKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudDiem)).EndInit();
            this._gb.ResumeLayout(false);
            this._tlp.ResumeLayout(false);
            this._tlp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}