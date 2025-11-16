// NVMeo.Designer.cs 
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLICafeMeo
{
    partial class frmNVMeo
    {
        private System.ComponentModel.IContainer components = null;

      
        private DataGridView _dgv;
        private TextBox _txtTen;
        private TextBox _txtGiong;
        private ComboBox _cbTinhTrang;
        private DateTimePicker _dtTiemPhong;
        private TextBox _txtGhiChu;
        private Button _btnThem;
        private Button _btnSua;
        private Button _btnXoa;
        private Button _btnHuy;
        private Button _btnXemChiTiet; 

        private Label _lblTen;
        private Label _lblGiong;
        private Label _lblTinhTrang;
        private Label _lblTiem;
        private Label _lblGhiChu;
        private Label _lblTieuDe;
        private Panel _pnlTop;
        private Panel _pnlBottom;

        private TableLayoutPanel _tlpInput;
        private TableLayoutPanel _tlpButtons;


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
            this._dgv = new System.Windows.Forms.DataGridView();
            this._txtTen = new System.Windows.Forms.TextBox();
            this._txtGiong = new System.Windows.Forms.TextBox();
            this._cbTinhTrang = new System.Windows.Forms.ComboBox();
            this._dtTiemPhong = new System.Windows.Forms.DateTimePicker();
            this._txtGhiChu = new System.Windows.Forms.TextBox();
            this._btnThem = new System.Windows.Forms.Button();
            this._btnSua = new System.Windows.Forms.Button();
            this._btnXoa = new System.Windows.Forms.Button();
            this._btnHuy = new System.Windows.Forms.Button();
            this._btnXemChiTiet = new System.Windows.Forms.Button();
            this._lblTen = new System.Windows.Forms.Label();
            this._lblGiong = new System.Windows.Forms.Label();
            this._lblTinhTrang = new System.Windows.Forms.Label();
            this._lblTiem = new System.Windows.Forms.Label();
            this._lblGhiChu = new System.Windows.Forms.Label();
            this._lblTieuDe = new System.Windows.Forms.Label();
            this._tlpInput = new System.Windows.Forms.TableLayoutPanel();
            this._tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this._pnlTop = new System.Windows.Forms.Panel();
            this._pnlBottom = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).BeginInit();
            this._tlpInput.SuspendLayout();
            this._tlpButtons.SuspendLayout();
            this._pnlTop.SuspendLayout();
            this._pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dgv
            // 
            this._dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgv.BackgroundColor = System.Drawing.Color.White;
            this._dgv.ColumnHeadersHeight = 29;
            this._dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgv.Location = new System.Drawing.Point(20, 40);
            this._dgv.Margin = new System.Windows.Forms.Padding(0);
            this._dgv.Name = "_dgv";
            this._dgv.ReadOnly = true;
            this._dgv.RowHeadersWidth = 51;
            this._dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgv.Size = new System.Drawing.Size(842, 280);
            this._dgv.TabIndex = 2;
            this._dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_CellClick);
            // 
            // _txtTen
            // 
            this._txtTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtTen.Location = new System.Drawing.Point(110, 10);
            this._txtTen.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._txtTen.Name = "_txtTen";
            this._txtTen.Size = new System.Drawing.Size(232, 34);
            this._txtTen.TabIndex = 1;
            // 
            // _txtGiong
            // 
            this._txtGiong.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtGiong.Location = new System.Drawing.Point(110, 45);
            this._txtGiong.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._txtGiong.Name = "_txtGiong";
            this._txtGiong.Size = new System.Drawing.Size(232, 34);
            this._txtGiong.TabIndex = 3;
            // 
            // _cbTinhTrang
            // 
            this._cbTinhTrang.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cbTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbTinhTrang.Items.AddRange(new object[] {
            "Khỏe mạnh",
            "Ốm",
            "Đang điều trị"});
            this._cbTinhTrang.Location = new System.Drawing.Point(110, 80);
            this._cbTinhTrang.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._cbTinhTrang.Name = "_cbTinhTrang";
            this._cbTinhTrang.Size = new System.Drawing.Size(232, 36);
            this._cbTinhTrang.TabIndex = 5;
            // 
            // _dtTiemPhong
            // 
            this._dtTiemPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dtTiemPhong.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtTiemPhong.Location = new System.Drawing.Point(110, 115);
            this._dtTiemPhong.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._dtTiemPhong.Name = "_dtTiemPhong";
            this._dtTiemPhong.Size = new System.Drawing.Size(232, 34);
            this._dtTiemPhong.TabIndex = 7;
            this._dtTiemPhong.Value = new System.DateTime(2025, 11, 12, 0, 0, 0, 0);
            // 
            // _txtGhiChu
            // 
            this._txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtGhiChu.Location = new System.Drawing.Point(110, 150);
            this._txtGhiChu.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._txtGhiChu.Multiline = true;
            this._txtGhiChu.Name = "_txtGhiChu";
            this._txtGhiChu.Size = new System.Drawing.Size(232, 70);
            this._txtGhiChu.TabIndex = 9;
            // 
            // _btnThem
            // 
            this._btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this._btnThem.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnThem.ForeColor = System.Drawing.Color.White;
            this._btnThem.Location = new System.Drawing.Point(5, 5);
            this._btnThem.Margin = new System.Windows.Forms.Padding(5);
            this._btnThem.Name = "_btnThem";
            this._btnThem.Size = new System.Drawing.Size(140, 35);
            this._btnThem.TabIndex = 0;
            this._btnThem.Text = "THÊM";
            this._btnThem.UseVisualStyleBackColor = false;
            this._btnThem.Click += new System.EventHandler(this._btnThem_Click);
            // 
            // _btnSua
            // 
            this._btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this._btnSua.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnSua.ForeColor = System.Drawing.Color.White;
            this._btnSua.Location = new System.Drawing.Point(155, 5);
            this._btnSua.Margin = new System.Windows.Forms.Padding(5);
            this._btnSua.Name = "_btnSua";
            this._btnSua.Size = new System.Drawing.Size(140, 35);
            this._btnSua.TabIndex = 1;
            this._btnSua.Text = "SỬA";
            this._btnSua.UseVisualStyleBackColor = false;
            this._btnSua.Click += new System.EventHandler(this._btnSua_Click);
            // 
            // _btnXoa
            // 
            this._btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this._btnXoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnXoa.ForeColor = System.Drawing.Color.White;
            this._btnXoa.Location = new System.Drawing.Point(5, 50);
            this._btnXoa.Margin = new System.Windows.Forms.Padding(5);
            this._btnXoa.Name = "_btnXoa";
            this._btnXoa.Size = new System.Drawing.Size(140, 35);
            this._btnXoa.TabIndex = 2;
            this._btnXoa.Text = "XÓA";
            this._btnXoa.UseVisualStyleBackColor = false;
            this._btnXoa.Click += new System.EventHandler(this._btnXoa_Click);
            // 
            // _btnHuy
            // 
            this._btnHuy.BackColor = System.Drawing.Color.Gray;
            this._btnHuy.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnHuy.ForeColor = System.Drawing.Color.White;
            this._btnHuy.Location = new System.Drawing.Point(155, 50);
            this._btnHuy.Margin = new System.Windows.Forms.Padding(5);
            this._btnHuy.Name = "_btnHuy";
            this._btnHuy.Size = new System.Drawing.Size(140, 35);
            this._btnHuy.TabIndex = 3;
            this._btnHuy.Text = "HỦY";
            this._btnHuy.UseVisualStyleBackColor = false;
            this._btnHuy.Click += new System.EventHandler(this._btnHuy_Click);
            // 
            // _btnXemChiTiet
            // 
            this._btnXemChiTiet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this._tlpButtons.SetColumnSpan(this._btnXemChiTiet, 2);
            this._btnXemChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnXemChiTiet.ForeColor = System.Drawing.Color.White;
            this._btnXemChiTiet.Location = new System.Drawing.Point(5, 95);
            this._btnXemChiTiet.Margin = new System.Windows.Forms.Padding(5);
            this._btnXemChiTiet.Name = "_btnXemChiTiet";
            this._btnXemChiTiet.Size = new System.Drawing.Size(290, 35);
            this._btnXemChiTiet.TabIndex = 4;
            this._btnXemChiTiet.Text = "XEM CHI TIẾT";
            this._btnXemChiTiet.UseVisualStyleBackColor = false;
            this._btnXemChiTiet.Click += new System.EventHandler(this.BtnXemChiTiet_Click);
            // 
            // _lblTen
            // 
            this._lblTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblTen.Location = new System.Drawing.Point(8, 5);
            this._lblTen.Name = "_lblTen";
            this._lblTen.Size = new System.Drawing.Size(96, 35);
            this._lblTen.TabIndex = 0;
            this._lblTen.Text = "Tên mèo:";
            this._lblTen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblGiong
            // 
            this._lblGiong.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblGiong.Location = new System.Drawing.Point(8, 40);
            this._lblGiong.Name = "_lblGiong";
            this._lblGiong.Size = new System.Drawing.Size(96, 35);
            this._lblGiong.TabIndex = 2;
            this._lblGiong.Text = "Giống:";
            this._lblGiong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblTinhTrang
            // 
            this._lblTinhTrang.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblTinhTrang.Location = new System.Drawing.Point(8, 75);
            this._lblTinhTrang.Name = "_lblTinhTrang";
            this._lblTinhTrang.Size = new System.Drawing.Size(96, 35);
            this._lblTinhTrang.TabIndex = 4;
            this._lblTinhTrang.Text = "Tình trạng:";
            this._lblTinhTrang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblTiem
            // 
            this._lblTiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblTiem.Location = new System.Drawing.Point(8, 110);
            this._lblTiem.Name = "_lblTiem";
            this._lblTiem.Size = new System.Drawing.Size(96, 35);
            this._lblTiem.TabIndex = 6;
            this._lblTiem.Text = "Ngày tiêm:";
            this._lblTiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblGhiChu
            // 
            this._lblGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblGhiChu.Location = new System.Drawing.Point(8, 145);
            this._lblGhiChu.Name = "_lblGhiChu";
            this._lblGhiChu.Size = new System.Drawing.Size(96, 80);
            this._lblGhiChu.TabIndex = 8;
            this._lblGhiChu.Text = "Ghi chú:";
            // 
            // _lblTieuDe
            // 
            this._lblTieuDe.BackColor = System.Drawing.Color.White;
            this._lblTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this._lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this._lblTieuDe.Location = new System.Drawing.Point(20, 0);
            this._lblTieuDe.Name = "_lblTieuDe";
            this._lblTieuDe.Size = new System.Drawing.Size(842, 40);
            this._lblTieuDe.TabIndex = 0;
            this._lblTieuDe.Text = "NHÂN VIÊN MÈO";
            this._lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _tlpInput
            // 
            this._tlpInput.ColumnCount = 2;
            this._tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._tlpInput.Controls.Add(this._lblTen, 0, 0);
            this._tlpInput.Controls.Add(this._txtTen, 1, 0);
            this._tlpInput.Controls.Add(this._lblGiong, 0, 1);
            this._tlpInput.Controls.Add(this._txtGiong, 1, 1);
            this._tlpInput.Controls.Add(this._lblTinhTrang, 0, 2);
            this._tlpInput.Controls.Add(this._cbTinhTrang, 1, 2);
            this._tlpInput.Controls.Add(this._lblTiem, 0, 3);
            this._tlpInput.Controls.Add(this._dtTiemPhong, 1, 3);
            this._tlpInput.Controls.Add(this._lblGhiChu, 0, 4);
            this._tlpInput.Controls.Add(this._txtGhiChu, 1, 4);
            this._tlpInput.Location = new System.Drawing.Point(20, 20);
            this._tlpInput.Name = "_tlpInput";
            this._tlpInput.Padding = new System.Windows.Forms.Padding(5);
            this._tlpInput.RowCount = 5;
            this._tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this._tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this._tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this._tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this._tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this._tlpInput.Size = new System.Drawing.Size(350, 200);
            this._tlpInput.TabIndex = 1;
            // 
            // _tlpButtons
            // 
            this._tlpButtons.ColumnCount = 2;
            this._tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlpButtons.Controls.Add(this._btnThem, 0, 0);
            this._tlpButtons.Controls.Add(this._btnSua, 1, 0);
            this._tlpButtons.Controls.Add(this._btnXoa, 0, 1);
            this._tlpButtons.Controls.Add(this._btnHuy, 1, 1);
            this._tlpButtons.Controls.Add(this._btnXemChiTiet, 0, 2);
            this._tlpButtons.Location = new System.Drawing.Point(400, 20);
            this._tlpButtons.Name = "_tlpButtons";
            this._tlpButtons.RowCount = 3;
            this._tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this._tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this._tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this._tlpButtons.Size = new System.Drawing.Size(300, 135);
            this._tlpButtons.TabIndex = 0;
            // 
            // _pnlTop
            // 
            this._pnlTop.Controls.Add(this._dgv);
            this._pnlTop.Controls.Add(this._lblTieuDe);
            this._pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlTop.Location = new System.Drawing.Point(0, 0);
            this._pnlTop.Name = "_pnlTop";
            this._pnlTop.Padding = new System.Windows.Forms.Padding(20, 0, 20, 20);
            this._pnlTop.Size = new System.Drawing.Size(882, 340);
            this._pnlTop.TabIndex = 0;
            // 
            // _pnlBottom
            // 
            this._pnlBottom.Controls.Add(this._tlpButtons);
            this._pnlBottom.Controls.Add(this._tlpInput);
            this._pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlBottom.Location = new System.Drawing.Point(0, 340);
            this._pnlBottom.Name = "_pnlBottom";
            this._pnlBottom.Padding = new System.Windows.Forms.Padding(20);
            this._pnlBottom.Size = new System.Drawing.Size(882, 213);
            this._pnlBottom.TabIndex = 1;
            // 
            // frmNVMeo
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this._pnlBottom);
            this.Controls.Add(this._pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "frmNVMeo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Mèo";
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).EndInit();
            this._tlpInput.ResumeLayout(false);
            this._tlpInput.PerformLayout();
            this._tlpButtons.ResumeLayout(false);
            this._pnlTop.ResumeLayout(false);
            this._pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}