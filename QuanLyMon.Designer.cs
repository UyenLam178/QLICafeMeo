// frmQuanLyMon.designer.cs
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLICafeMeo.Forms
{
    partial class frmQuanLyMon
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView _dgvMon;
        private TextBox _txtTimKiem, _txtTenMon, _txtGia;
        private ComboBox _cbLoai;
        private Button _btnThem, _btnSua, _btnXoa;
        private Label _lblTitle;
        private GroupBox _gb;
        private TableLayoutPanel _tlp;

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
            this._dgvMon = new System.Windows.Forms.DataGridView();
            this._txtTimKiem = new System.Windows.Forms.TextBox();
            this._txtTenMon = new System.Windows.Forms.TextBox();
            this._txtGia = new System.Windows.Forms.TextBox();
            this._cbLoai = new System.Windows.Forms.ComboBox();
            this._btnThem = new System.Windows.Forms.Button();
            this._btnSua = new System.Windows.Forms.Button();
            this._btnXoa = new System.Windows.Forms.Button();
            this._lblTitle = new System.Windows.Forms.Label();
            this._gb = new System.Windows.Forms.GroupBox();
            this._tlp = new System.Windows.Forms.TableLayoutPanel();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.lblLoai = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._dgvMon)).BeginInit();
            this._gb.SuspendLayout();
            this._tlp.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dgvMon
            // 
            this._dgvMon.AllowUserToAddRows = false;
            this._dgvMon.AllowUserToDeleteRows = false;
            this._dgvMon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvMon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvMon.BackgroundColor = System.Drawing.Color.White;
            this._dgvMon.ColumnHeadersHeight = 29;
            this._dgvMon.Location = new System.Drawing.Point(20, 110);
            this._dgvMon.Name = "_dgvMon";
            this._dgvMon.ReadOnly = true;
            this._dgvMon.RowHeadersVisible = false;
            this._dgvMon.RowHeadersWidth = 51;
            this._dgvMon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvMon.Size = new System.Drawing.Size(950, 350);
            this._dgvMon.TabIndex = 2;
            this._dgvMon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMon_CellClick);
            // 
            // _txtTimKiem
            // 
            this._txtTimKiem.Location = new System.Drawing.Point(20, 64);
            this._txtTimKiem.Name = "_txtTimKiem";
            this._txtTimKiem.Size = new System.Drawing.Size(400, 31);
            this._txtTimKiem.TabIndex = 1;
            this._txtTimKiem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtTimKiem_KeyUp);
            // 
            // _txtTenMon
            // 
            this._txtTenMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtTenMon.Location = new System.Drawing.Point(113, 13);
            this._txtTenMon.Name = "_txtTenMon";
            this._txtTenMon.Size = new System.Drawing.Size(213, 31);
            this._txtTenMon.TabIndex = 1;
            // 
            // _txtGia
            // 
            this._txtGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtGia.Location = new System.Drawing.Point(412, 13);
            this._txtGia.Name = "_txtGia";
            this._txtGia.Size = new System.Drawing.Size(213, 31);
            this._txtGia.TabIndex = 3;
            // 
            // _cbLoai
            // 
            this._cbLoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cbLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbLoai.Location = new System.Drawing.Point(711, 13);
            this._cbLoai.Name = "_cbLoai";
            this._cbLoai.Size = new System.Drawing.Size(220, 33);
            this._cbLoai.TabIndex = 5;
            // 
            // _btnThem
            // 
            this._btnThem.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this._btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnThem.ForeColor = System.Drawing.Color.White;
            this._btnThem.Location = new System.Drawing.Point(226, 75);
            this._btnThem.Name = "_btnThem";
            this._btnThem.Size = new System.Drawing.Size(100, 30);
            this._btnThem.TabIndex = 6;
            this._btnThem.Text = "THÊM";
            this._btnThem.UseVisualStyleBackColor = false;
            this._btnThem.Click += new System.EventHandler(this._btnThem_Click);
            // 
            // _btnSua
            // 
            this._btnSua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this._btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnSua.ForeColor = System.Drawing.Color.White;
            this._btnSua.Location = new System.Drawing.Point(332, 75);
            this._btnSua.Name = "_btnSua";
            this._btnSua.Size = new System.Drawing.Size(74, 30);
            this._btnSua.TabIndex = 7;
            this._btnSua.Text = "SỬA";
            this._btnSua.UseVisualStyleBackColor = false;
            this._btnSua.Click += new System.EventHandler(this._btnSua_Click);
            // 
            // _btnXoa
            // 
            this._btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this._btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnXoa.ForeColor = System.Drawing.Color.White;
            this._btnXoa.Location = new System.Drawing.Point(412, 75);
            this._btnXoa.Name = "_btnXoa";
            this._btnXoa.Size = new System.Drawing.Size(80, 30);
            this._btnXoa.TabIndex = 8;
            this._btnXoa.Text = "XÓA";
            this._btnXoa.UseVisualStyleBackColor = false;
            this._btnXoa.Click += new System.EventHandler(this._btnXoa_Click);
            // 
            // _lblTitle
            // 
            this._lblTitle.AutoSize = true;
            this._lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this._lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this._lblTitle.Location = new System.Drawing.Point(20, 20);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Size = new System.Drawing.Size(331, 48);
            this._lblTitle.TabIndex = 0;
            this._lblTitle.Text = "DANH SÁCH MÓN";
            // 
            // _gb
            // 
            this._gb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gb.Controls.Add(this._tlp);
            this._gb.Location = new System.Drawing.Point(20, 470);
            this._gb.Name = "_gb";
            this._gb.Size = new System.Drawing.Size(950, 150);
            this._gb.TabIndex = 3;
            this._gb.TabStop = false;
            this._gb.Text = "Thông tin món";
            // 
            // _tlp
            // 
            this._tlp.ColumnCount = 6;
            this._tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this._tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this._tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this._tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this._tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this._tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this._tlp.Controls.Add(this.lblTenMon, 0, 0);
            this._tlp.Controls.Add(this._txtTenMon, 1, 0);
            this._tlp.Controls.Add(this.lblGia, 2, 0);
            this._tlp.Controls.Add(this._txtGia, 3, 0);
            this._tlp.Controls.Add(this.lblLoai, 4, 0);
            this._tlp.Controls.Add(this._cbLoai, 5, 0);
            this._tlp.Controls.Add(this._btnThem, 1, 2);
            this._tlp.Controls.Add(this._btnSua, 2, 2);
            this._tlp.Controls.Add(this._btnXoa, 3, 2);
            this._tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlp.Location = new System.Drawing.Point(3, 27);
            this._tlp.Name = "_tlp";
            this._tlp.Padding = new System.Windows.Forms.Padding(10);
            this._tlp.RowCount = 3;
            this._tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this._tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this._tlp.Size = new System.Drawing.Size(944, 120);
            this._tlp.TabIndex = 0;
            // 
            // lblTenMon
            // 
            this.lblTenMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenMon.Location = new System.Drawing.Point(13, 10);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(94, 30);
            this.lblTenMon.TabIndex = 0;
            this.lblTenMon.Text = "Tên món:";
            this.lblTenMon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGia
            // 
            this.lblGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGia.Location = new System.Drawing.Point(332, 10);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(74, 30);
            this.lblGia.TabIndex = 2;
            this.lblGia.Text = "Giá:";
            this.lblGia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLoai
            // 
            this.lblLoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoai.Location = new System.Drawing.Point(631, 10);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(74, 30);
            this.lblLoai.TabIndex = 4;
            this.lblLoai.Text = "Loại:";
            this.lblLoai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmQuanLyMon
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.Controls.Add(this._lblTitle);
            this.Controls.Add(this._txtTimKiem);
            this.Controls.Add(this._dgvMon);
            this.Controls.Add(this._gb);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmQuanLyMon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Món";
            ((System.ComponentModel.ISupportInitialize)(this._dgvMon)).EndInit();
            this._gb.ResumeLayout(false);
            this._tlp.ResumeLayout(false);
            this._tlp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label lblTenMon;
        private Label lblGia;
        private Label lblLoai;
    }
}