// frmSuKien.Designer.cs 

using System.Drawing;
using System.Windows.Forms;

namespace QLICafeMeo.Forms
{
    partial class frmSuKien
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView _dgv;
        private TextBox _txtMaSK;       
        private TextBox _txtTenSK;
        private NumericUpDown _nudGiamGia; 
        private ComboBox _cbLoaiGiam;   
        private ComboBox _cbLoaiApDung; 
        private ComboBox _cbDoiTuong;   
        private DateTimePicker _dtNgayBD;
        private DateTimePicker _dtNgayKT;
        private Button _btnThem, _btnSua, _btnXoa, _btnHuy;
        private CheckBox _chkApDungTatCa;
        private ComboBox _cbTrangThai;  

        // Layouts
        private GroupBox _gbThongTin;
        private TableLayoutPanel _tlpMain;
        private TableLayoutPanel _tlpInput;
        private TableLayoutPanel _tlpButtons;
        private Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this._dgv = new System.Windows.Forms.DataGridView();
            this._txtMaSK = new System.Windows.Forms.TextBox(); 
            this._txtTenSK = new System.Windows.Forms.TextBox();
            this._nudGiamGia = new System.Windows.Forms.NumericUpDown();
            this._cbLoaiGiam = new System.Windows.Forms.ComboBox(); 
            this._cbLoaiApDung = new System.Windows.Forms.ComboBox();
            this._cbDoiTuong = new System.Windows.Forms.ComboBox();
            this._dtNgayBD = new System.Windows.Forms.DateTimePicker();
            this._dtNgayKT = new System.Windows.Forms.DateTimePicker();
            this._btnThem = new System.Windows.Forms.Button();
            this._btnSua = new System.Windows.Forms.Button();
            this._btnXoa = new System.Windows.Forms.Button();
            this._btnHuy = new System.Windows.Forms.Button();
            this._chkApDungTatCa = new System.Windows.Forms.CheckBox();
            this._cbTrangThai = new System.Windows.Forms.ComboBox(); 
            this._gbThongTin = new System.Windows.Forms.GroupBox();
            this._tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this._tlpInput = new System.Windows.Forms.TableLayoutPanel();
            this._tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this._dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudGiamGia)).BeginInit();
            this._gbThongTin.SuspendLayout();
            this._tlpMain.SuspendLayout();
            this._tlpInput.SuspendLayout();
            this._tlpButtons.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(143)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(964, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ SỰ KIỆN & KHUYẾN MÃI";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _tlpMain
            // 
            this._tlpMain.ColumnCount = 1;
            this._tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpMain.Controls.Add(this._dgv, 0, 0);
            this._tlpMain.Controls.Add(this._gbThongTin, 0, 1);
            this._tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpMain.Location = new System.Drawing.Point(10, 50);
            this._tlpMain.Name = "_tlpMain";
            this._tlpMain.RowCount = 2;
            this._tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this._tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this._tlpMain.Size = new System.Drawing.Size(964, 541);
            this._tlpMain.TabIndex = 1;
            // 
            // _dgv
            // 
            this._dgv.AllowUserToAddRows = false;
            this._dgv.AllowUserToDeleteRows = false;
            this._dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgv.BackgroundColor = System.Drawing.Color.White;
            this._dgv.ColumnHeadersHeight = 30;
            this._dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgv.Location = new System.Drawing.Point(3, 3);
            this._dgv.Name = "_dgv";
            this._dgv.ReadOnly = true;
            this._dgv.RowHeadersWidth = 51;
            this._dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgv.Size = new System.Drawing.Size(958, 318);
            this._dgv.TabIndex = 0;
            this._dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_CellClick);
            // 
            // _gbThongTin
            // 
            this._gbThongTin.Controls.Add(this._tlpInput);
            this._gbThongTin.Controls.Add(this._tlpButtons);
            this._gbThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gbThongTin.Location = new System.Drawing.Point(3, 327);
            this._gbThongTin.Name = "_gbThongTin";
            this._gbThongTin.Size = new System.Drawing.Size(958, 211);
            this._gbThongTin.TabIndex = 1;
            this._gbThongTin.TabStop = false;
            this._gbThongTin.Text = "Chi Tiết Khuyến Mãi";

            // 
            // _tlpInput
            // 
            this._tlpInput.ColumnCount = 4;
            this._tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F)); 
            this._tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F)); 
            this._tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F)); 
            this._tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F)); 
            this._tlpInput.RowCount = 5; 
            this._tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); 
            this._tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); 
            this._tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); 
            this._tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); 
            this._tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); 
            this._tlpInput.Location = new System.Drawing.Point(10, 25);
            this._tlpInput.Name = "_tlpInput";
            this._tlpInput.Size = new System.Drawing.Size(650, 180);
            this._tlpInput.TabIndex = 0;


            // DÒNG 1: Mã SK | Tên Sự Kiện
            this._tlpInput.Controls.Add(new Label() { Text = "Mã Sự Kiện:", TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 0, 0);
            this._txtMaSK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtMaSK.ReadOnly = true; 
            this._txtMaSK.Text = "Tự động gán";
            this._txtMaSK.Location = new System.Drawing.Point(123, 4);
            this._txtMaSK.Name = "_txtMaSK";
            this._txtMaSK.Size = new System.Drawing.Size(200, 27);
            this._tlpInput.Controls.Add(this._txtMaSK, 1, 0); 
            this._tlpInput.Controls.Add(new Label() { Text = "Tên Sự Kiện:", TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 2, 0);
            this._txtTenSK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTenSK.Location = new System.Drawing.Point(443, 4);
            this._txtTenSK.Name = "_txtTenSK";
            this._txtTenSK.Size = new System.Drawing.Size(204, 27);
            this._tlpInput.Controls.Add(this._txtTenSK, 3, 0);

            // DÒNG 2: Áp Dụng Cho | Giá Trị
            this._tlpInput.Controls.Add(new Label() { Text = "Áp Dụng Cho:", TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 0, 1);
            this._cbLoaiApDung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cbLoaiApDung.Location = new System.Drawing.Point(123, 39);
            this._cbLoaiApDung.Name = "_cbLoaiApDung";
            this._cbLoaiApDung.Size = new System.Drawing.Size(200, 28);
            this._tlpInput.Controls.Add(this._cbLoaiApDung, 1, 1);
            this._tlpInput.Controls.Add(new Label() { Text = "Giá Trị:", TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 2, 1);
            this._nudGiamGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._nudGiamGia.Location = new System.Drawing.Point(443, 39);
            this._nudGiamGia.Name = "_nudGiamGia";
            this._nudGiamGia.Size = new System.Drawing.Size(204, 27);
            this._tlpInput.Controls.Add(this._nudGiamGia, 3, 1);

            // DÒNG 3: Đối Tượng Cụ Thể | Loại Giảm
            this._tlpInput.Controls.Add(new Label() { Text = "Đối Tượng Cụ Thể:", TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 0, 2);
            this._cbDoiTuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cbDoiTuong.Location = new System.Drawing.Point(123, 74);
            this._cbDoiTuong.Name = "_cbDoiTuong";
            this._cbDoiTuong.Size = new System.Drawing.Size(200, 28);
            this._tlpInput.Controls.Add(this._cbDoiTuong, 1, 2);
            this._tlpInput.Controls.Add(new Label() { Text = "Loại Giảm:", TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 2, 2);
            this._cbLoaiGiam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cbLoaiGiam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbLoaiGiam.Items.AddRange(new object[] { "Phần trăm", "Tiền mặt" });
            this._cbLoaiGiam.Text = "Phần trăm";
            this._cbLoaiGiam.Location = new System.Drawing.Point(443, 74);
            this._cbLoaiGiam.Name = "_cbLoaiGiam";
            this._cbLoaiGiam.Size = new System.Drawing.Size(204, 28);
            this._tlpInput.Controls.Add(this._cbLoaiGiam, 3, 2); 

            // DÒNG 4: Từ Ngày | Đến Ngày
            this._tlpInput.Controls.Add(new Label() { Text = "Từ Ngày:", TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 0, 3);
            this._dtNgayBD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._dtNgayBD.Location = new System.Drawing.Point(123, 109);
            this._dtNgayBD.Name = "_dtNgayBD";
            this._dtNgayBD.Size = new System.Drawing.Size(200, 27);
            this._tlpInput.Controls.Add(this._dtNgayBD, 1, 3);
            this._tlpInput.Controls.Add(new Label() { Text = "Đến Ngày:", TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 2, 3);
            this._dtNgayKT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._dtNgayKT.Location = new System.Drawing.Point(443, 109);
            this._dtNgayKT.Name = "_dtNgayKT";
            this._dtNgayKT.Size = new System.Drawing.Size(204, 27);
            this._tlpInput.Controls.Add(this._dtNgayKT, 3, 3);

            // DÒNG 5: Trạng Thái | Áp dụng cho tất cả
            this._tlpInput.Controls.Add(new Label() { Text = "Trạng Thái:", TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 0, 4);
            this._cbTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._cbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbTrangThai.Items.AddRange(new object[] { "Hoạt động", "Tạm dừng", "Đã kết thúc" });
            this._cbTrangThai.Text = "Hoạt động";
            this._cbTrangThai.Location = new System.Drawing.Point(123, 144);
            this._cbTrangThai.Name = "_cbTrangThai";
            this._cbTrangThai.Size = new System.Drawing.Size(200, 28);
            this._tlpInput.Controls.Add(this._cbTrangThai, 1, 4); 
            this._chkApDungTatCa.AutoSize = true;
            this._chkApDungTatCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this._chkApDungTatCa.Text = "Áp dụng cho tất cả đối tượng";
            this._chkApDungTatCa.Location = new System.Drawing.Point(443, 144);
            this._chkApDungTatCa.Name = "_chkApDungTatCa";
            this._chkApDungTatCa.Size = new System.Drawing.Size(204, 33);
            this._tlpInput.Controls.Add(this._chkApDungTatCa, 3, 4);



            this._txtMaSK.Size = new System.Drawing.Size(200, 27);
            this._txtTenSK.Size = new System.Drawing.Size(200, 27);

            this._nudGiamGia.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this._nudGiamGia.Minimum = new decimal(new int[] { 1, 0, 0, 0 });

            this._cbLoaiApDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbDoiTuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this._dtNgayBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtNgayKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // 
            // _tlpButtons
            // 
            this._tlpButtons.ColumnCount = 1;
            this._tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpButtons.Controls.Add(this._btnThem, 0, 0);
            this._tlpButtons.Controls.Add(this._btnSua, 0, 1);
            this._tlpButtons.Controls.Add(this._btnXoa, 0, 2);
            this._tlpButtons.Controls.Add(this._btnHuy, 0, 3);
            this._tlpButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this._tlpButtons.Location = new System.Drawing.Point(670, 25);
            this._tlpButtons.Name = "_tlpButtons";
            this._tlpButtons.RowCount = 4;
            this._tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tlpButtons.Size = new System.Drawing.Size(285, 183);
            this._tlpButtons.TabIndex = 1;
            // 
            // _btnThem
            // 
            this._btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this._btnThem.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnThem.ForeColor = System.Drawing.Color.White;
            this._btnThem.Location = new System.Drawing.Point(3, 3);
            this._btnThem.Name = "_btnThem";
            this._btnThem.Size = new System.Drawing.Size(279, 39);
            this._btnThem.TabIndex = 0;
            this._btnThem.Text = "THÊM";
            this._btnThem.UseVisualStyleBackColor = false;
            // 
            // _btnSua
            // 
            this._btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this._btnSua.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnSua.ForeColor = System.Drawing.Color.White;
            this._btnSua.Location = new System.Drawing.Point(3, 48);
            this._btnSua.Name = "_btnSua";
            this._btnSua.Size = new System.Drawing.Size(279, 39);
            this._btnSua.TabIndex = 1;
            this._btnSua.Text = "SỬA";
            this._btnSua.UseVisualStyleBackColor = false;
            // 
            // _btnXoa
            // 
            this._btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this._btnXoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnXoa.ForeColor = System.Drawing.Color.White;
            this._btnXoa.Location = new System.Drawing.Point(3, 93);
            this._btnXoa.Name = "_btnXoa";
            this._btnXoa.Size = new System.Drawing.Size(279, 39);
            this._btnXoa.TabIndex = 2;
            this._btnXoa.Text = "XÓA";
            this._btnXoa.UseVisualStyleBackColor = false;
            // 
            // _btnHuy
            // 
            this._btnHuy.BackColor = System.Drawing.Color.Gray;
            this._btnHuy.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnHuy.ForeColor = System.Drawing.Color.White;
            this._btnHuy.Location = new System.Drawing.Point(3, 138);
            this._btnHuy.Name = "_btnHuy";
            this._btnHuy.Size = new System.Drawing.Size(279, 42);
            this._btnHuy.TabIndex = 3;
            this._btnHuy.Text = "HỦY";
            this._btnHuy.UseVisualStyleBackColor = false;
            // 
            // frmSuKien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(984, 601);
            this.Controls.Add(this._tlpMain);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmSuKien";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Quản lý Sự Kiện & Khuyến Mãi";
            ((System.ComponentModel.ISupportInitialize)(this._dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._nudGiamGia)).EndInit();
            this._gbThongTin.ResumeLayout(false);
            this._tlpMain.ResumeLayout(false);
            this._tlpInput.ResumeLayout(false);
            this._tlpInput.PerformLayout();
            this._tlpButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}