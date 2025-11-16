// Phong.Designer.cs
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLICafeMeo
{
    partial class frmPhong
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView _dgv;
        private TextBox _txtTen;
        private NumericUpDown _nudSucChua;
        private ComboBox _cbTrangThai;
        private Button _btnThem;
        private Button _btnSua;
        private Button _btnXoa;

        private Label _lblTitle; 
        private GroupBox _gbControls; 
        private TableLayoutPanel _tlpControls; 

        private Label lblTen;
        private Label lblSucChua;
        private Label lblTrangThai;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this._dgv = new System.Windows.Forms.DataGridView();
            this._txtTen = new System.Windows.Forms.TextBox();
            this._nudSucChua = new System.Windows.Forms.NumericUpDown();
            this._cbTrangThai = new System.Windows.Forms.ComboBox();
            this._btnThem = new System.Windows.Forms.Button();
            this._btnSua = new System.Windows.Forms.Button();
            this._btnXoa = new System.Windows.Forms.Button();
            this._lblTitle = new System.Windows.Forms.Label();
            this._gbControls = new System.Windows.Forms.GroupBox();
            this._tlpControls = new System.Windows.Forms.TableLayoutPanel();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblSucChua = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudSucChua)).BeginInit();
            this._gbControls.SuspendLayout();
            this._tlpControls.SuspendLayout();
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
            this._dgv.ColumnHeadersHeight = 29;
            this._dgv.Location = new System.Drawing.Point(20, 60);
            this._dgv.Name = "_dgv";
            this._dgv.ReadOnly = true;
            this._dgv.RowHeadersVisible = false;
            this._dgv.RowHeadersWidth = 51;
            this._dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgv.Size = new System.Drawing.Size(1005, 320);
            this._dgv.TabIndex = 1;
            this._dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_CellClick);
            // 
            // _txtTen
            // 
            this._tlpControls.SetColumnSpan(this._txtTen, 2);
            this._txtTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtTen.Location = new System.Drawing.Point(103, 7);
            this._txtTen.Margin = new System.Windows.Forms.Padding(3, 7, 10, 3);
            this._txtTen.Name = "_txtTen";
            this._txtTen.Size = new System.Drawing.Size(553, 27);
            this._txtTen.TabIndex = 1;
            // 
            // _nudSucChua
            // 
            this._nudSucChua.Location = new System.Drawing.Point(103, 51);
            this._nudSucChua.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this._nudSucChua.Name = "_nudSucChua";
            this._nudSucChua.Size = new System.Drawing.Size(150, 27);
            this._nudSucChua.TabIndex = 3;
            // 
            // _cbTrangThai
            // 
            this._cbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbTrangThai.FormattingEnabled = true;
            this._cbTrangThai.Location = new System.Drawing.Point(103, 95);
            this._cbTrangThai.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this._cbTrangThai.Name = "_cbTrangThai";
            this._cbTrangThai.Size = new System.Drawing.Size(150, 28);
            this._cbTrangThai.TabIndex = 5;
            // 
            // _btnThem
            // 
            this._btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this._btnThem.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnThem.ForeColor = System.Drawing.Color.White;
            this._btnThem.Location = new System.Drawing.Point(669, 3);
            this._btnThem.Name = "_btnThem";
            this._btnThem.Size = new System.Drawing.Size(327, 38);
            this._btnThem.TabIndex = 6;
            this._btnThem.Text = "Thêm";
            this._btnThem.UseVisualStyleBackColor = false;
            this._btnThem.Click += new System.EventHandler(this._btnThem_Click);
            // 
            // _btnSua
            // 
            this._btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this._btnSua.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnSua.ForeColor = System.Drawing.Color.White;
            this._btnSua.Location = new System.Drawing.Point(669, 47);
            this._btnSua.Name = "_btnSua";
            this._btnSua.Size = new System.Drawing.Size(327, 38);
            this._btnSua.TabIndex = 7;
            this._btnSua.Text = "Sửa";
            this._btnSua.UseVisualStyleBackColor = false;
            this._btnSua.Click += new System.EventHandler(this._btnSua_Click);
            // 
            // _btnXoa
            // 
            this._btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this._btnXoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnXoa.ForeColor = System.Drawing.Color.White;
            this._btnXoa.Location = new System.Drawing.Point(669, 91);
            this._btnXoa.Name = "_btnXoa";
            this._btnXoa.Size = new System.Drawing.Size(327, 40);
            this._btnXoa.TabIndex = 8;
            this._btnXoa.Text = "Xóa";
            this._btnXoa.UseVisualStyleBackColor = false;
            this._btnXoa.Click += new System.EventHandler(this._btnXoa_Click);
            // 
            // _lblTitle
            // 
            this._lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this._lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this._lblTitle.Location = new System.Drawing.Point(12, 9);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Size = new System.Drawing.Size(1005, 40);
            this._lblTitle.TabIndex = 0;
            this._lblTitle.Text = "QUẢN LÝ PHÒNG";
            this._lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _gbControls
            // 
            this._gbControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gbControls.Controls.Add(this._tlpControls);
            this._gbControls.Location = new System.Drawing.Point(20, 390);
            this._gbControls.Name = "_gbControls";
            this._gbControls.Size = new System.Drawing.Size(1005, 160);
            this._gbControls.TabIndex = 2;
            this._gbControls.TabStop = false;
            this._gbControls.Text = "Thông tin phòng";
            // 
            // _tlpControls
            // 
            this._tlpControls.ColumnCount = 4;
            this._tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this._tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this._tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this._tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 332F));
            this._tlpControls.Controls.Add(this.lblTen, 0, 0);
            this._tlpControls.Controls.Add(this._txtTen, 1, 0);
            this._tlpControls.Controls.Add(this.lblSucChua, 0, 1);
            this._tlpControls.Controls.Add(this._nudSucChua, 1, 1);
            this._tlpControls.Controls.Add(this.lblTrangThai, 0, 2);
            this._tlpControls.Controls.Add(this._cbTrangThai, 1, 2);
            this._tlpControls.Controls.Add(this._btnThem, 3, 0);
            this._tlpControls.Controls.Add(this._btnSua, 3, 1);
            this._tlpControls.Controls.Add(this._btnXoa, 3, 2);
            this._tlpControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpControls.Location = new System.Drawing.Point(3, 23);
            this._tlpControls.Name = "_tlpControls";
            this._tlpControls.RowCount = 3;
            this._tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._tlpControls.Size = new System.Drawing.Size(999, 134);
            this._tlpControls.TabIndex = 0;
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTen.Location = new System.Drawing.Point(3, 0);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(94, 44);
            this.lblTen.TabIndex = 0;
            this.lblTen.Text = "Tên Phòng:";
            this.lblTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSucChua
            // 
            this.lblSucChua.AutoSize = true;
            this.lblSucChua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSucChua.Location = new System.Drawing.Point(3, 44);
            this.lblSucChua.Name = "lblSucChua";
            this.lblSucChua.Size = new System.Drawing.Size(94, 44);
            this.lblSucChua.TabIndex = 2;
            this.lblSucChua.Text = "Sức Chứa:";
            this.lblSucChua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrangThai.Location = new System.Drawing.Point(3, 88);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(94, 46);
            this.lblTrangThai.TabIndex = 4;
            this.lblTrangThai.Text = "Trạng Thái:";
            this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1045, 560);
            this.Controls.Add(this._gbControls);
            this.Controls.Add(this._dgv);
            this.Controls.Add(this._lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmPhong";
            this.Text = "Quản lý Phòng";
            this.Load += new System.EventHandler(this.Phong_Load);
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudSucChua)).EndInit();
            this._gbControls.ResumeLayout(false);
            this._tlpControls.ResumeLayout(false);
            this._tlpControls.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}