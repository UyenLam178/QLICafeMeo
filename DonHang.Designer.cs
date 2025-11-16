// DonHang.designer.cs
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLICafeMeo.Forms
{
    partial class DonHang
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView _dgvMon, _dgvGioHang;
        private ComboBox _cbKhachHang;
        private TextBox _txtTongTien;
        private Button _btnThanhToan, _btnInHoaDon;
        private Label _lblMon, _lblGio, _lblKH, _lblTong;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this._dgvMon = new System.Windows.Forms.DataGridView();
            this._dgvGioHang = new System.Windows.Forms.DataGridView();
            this._cbKhachHang = new System.Windows.Forms.ComboBox();
            this._txtTongTien = new System.Windows.Forms.TextBox();
            this._btnThanhToan = new System.Windows.Forms.Button();
            this._btnInHoaDon = new System.Windows.Forms.Button();
            this._lblMon = new System.Windows.Forms.Label();
            this._lblGio = new System.Windows.Forms.Label();
            this._lblKH = new System.Windows.Forms.Label();
            this._lblTong = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._dgvMon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvGioHang)).BeginInit();
            this.SuspendLayout();
            // 
            // _dgvMon
            // 
            this._dgvMon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvMon.BackgroundColor = System.Drawing.Color.White;
            this._dgvMon.ColumnHeadersHeight = 29;
            this._dgvMon.Location = new System.Drawing.Point(20, 50);
            this._dgvMon.Name = "_dgvMon";
            this._dgvMon.ReadOnly = true;
            this._dgvMon.RowHeadersWidth = 51;
            this._dgvMon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvMon.Size = new System.Drawing.Size(550, 450);
            this._dgvMon.TabIndex = 1;
            this._dgvMon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMon_CellClick);
            // 
            // _dgvGioHang
            // 
            this._dgvGioHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvGioHang.BackgroundColor = System.Drawing.Color.White;
            this._dgvGioHang.ColumnHeadersHeight = 29;
            this._dgvGioHang.Location = new System.Drawing.Point(600, 50);
            this._dgvGioHang.Name = "_dgvGioHang";
            this._dgvGioHang.RowHeadersWidth = 51;
            this._dgvGioHang.Size = new System.Drawing.Size(600, 450);
            this._dgvGioHang.TabIndex = 3;
            this._dgvGioHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvGioHang_CellClick);
            // 
            // _cbKhachHang
            // 
            this._cbKhachHang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._cbKhachHang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._cbKhachHang.Location = new System.Drawing.Point(80, 517);
            this._cbKhachHang.Name = "_cbKhachHang";
            this._cbKhachHang.Size = new System.Drawing.Size(300, 31);
            this._cbKhachHang.TabIndex = 5;
            // 
            // _txtTongTien
            // 
            this._txtTongTien.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._txtTongTien.Location = new System.Drawing.Point(750, 518);
            this._txtTongTien.Name = "_txtTongTien";
            this._txtTongTien.ReadOnly = true;
            this._txtTongTien.Size = new System.Drawing.Size(150, 39);
            this._txtTongTien.TabIndex = 7;
            this._txtTongTien.Text = "0";
            this._txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _btnThanhToan
            // 
            this._btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this._btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._btnThanhToan.ForeColor = System.Drawing.Color.White;
            this._btnThanhToan.Location = new System.Drawing.Point(600, 570); // CHỈNH VỊ TRÍ
            this._btnThanhToan.Name = "_btnThanhToan";
            this._btnThanhToan.Size = new System.Drawing.Size(181, 50);
            this._btnThanhToan.TabIndex = 8;
            this._btnThanhToan.Text = "THANH TOÁN";
            this._btnThanhToan.UseVisualStyleBackColor = false;
            this._btnThanhToan.Click += new System.EventHandler(this.BtnThanhToan_Click);
            // 
            // _btnInHoaDon
            // 
            this._btnInHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this._btnInHoaDon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this._btnInHoaDon.ForeColor = System.Drawing.Color.White;
            this._btnInHoaDon.Location = new System.Drawing.Point(800, 570); // CHỈNH VỊ TRÍ
            this._btnInHoaDon.Name = "_btnInHoaDon";
            this._btnInHoaDon.Size = new System.Drawing.Size(181, 50);
            this._btnInHoaDon.TabIndex = 9;
            this._btnInHoaDon.Text = "IN HÓA ĐƠN";
            this._btnInHoaDon.UseVisualStyleBackColor = false;
            this._btnInHoaDon.Click += new System.EventHandler(this.BtnInHoaDon_Click);
            // 
            // _lblMon
            // 
            this._lblMon.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold); // Tăng cỡ chữ
            this._lblMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255))))); // Chữ xanh
            this._lblMon.Location = new System.Drawing.Point(20, 10); // Căn lên trên
            this._lblMon.Name = "_lblMon";
            this._lblMon.Size = new System.Drawing.Size(550, 35);
            this._lblMon.TabIndex = 0;
            this._lblMon.Text = "DANH SÁCH MÓN (Click để chọn số lượng)"; // Cập nhật tiêu đề
            this._lblMon.TextAlign = ContentAlignment.MiddleCenter; // Căn giữa
            // 
            // _lblGio
            // 
            this._lblGio.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold); // Tăng cỡ chữ
            this._lblGio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255))))); // Chữ xanh
            this._lblGio.Location = new System.Drawing.Point(600, 10);
            this._lblGio.Name = "_lblGio";
            this._lblGio.Size = new System.Drawing.Size(600, 35);
            this._lblGio.TabIndex = 2;
            this._lblGio.Text = "GIỎ HÀNG"; // Tiêu đề in hoa
            this._lblGio.TextAlign = ContentAlignment.MiddleCenter; // Căn giữa
            // 
            // _lblKH
            // 
            this._lblKH.AutoSize = true;
            this._lblKH.Location = new System.Drawing.Point(20, 520);
            this._lblKH.Name = "_lblKH";
            this._lblKH.Size = new System.Drawing.Size(61, 23);
            this._lblKH.TabIndex = 4;
            this._lblKH.Text = "Khách:";
            // 
            // _lblTong
            // 
            this._lblTong.AutoSize = true;
            this._lblTong.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this._lblTong.Location = new System.Drawing.Point(600, 520);
            this._lblTong.Name = "_lblTong";
            this._lblTong.Size = new System.Drawing.Size(150, 32);
            this._lblTong.TabIndex = 6;
            this._lblTong.Text = "TỔNG TIỀN:";
            // 
            // DonHang
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1232, 703);
            this.Controls.Add(this._lblMon);
            this.Controls.Add(this._dgvMon);
            this.Controls.Add(this._lblGio);
            this.Controls.Add(this._dgvGioHang);
            this.Controls.Add(this._lblKH);
            this.Controls.Add(this._cbKhachHang);
            this.Controls.Add(this._lblTong);
            this.Controls.Add(this._txtTongTien);
            this.Controls.Add(this._btnThanhToan);
            this.Controls.Add(this._btnInHoaDon);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "DonHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gọi Món & Thanh Toán";
            ((System.ComponentModel.ISupportInitialize)(this._dgvMon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgvGioHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}