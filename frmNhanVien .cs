// frmNhanVien.cs
using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.Linq;
using QLICafeMeo;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;

namespace QLICafeMeo.Forms
{
    public partial class frmNhanVien : Form
    {
        private int? _maNVDangChon;
        private readonly DataClasses1DataContext _db;
        private readonly string _currentUserRole;

        public frmNhanVien() : this("NhanVien") { }

        public frmNhanVien(string role = "NhanVien")
        {
            _currentUserRole = role;
            _db = new DataClasses1DataContext(QLICafeMeo.Properties.Settings.Default.QLICafeMeoConnectionString);
            InitializeComponent();
            this.Load += (s, e) => { LoadData(); ApplyPermissions(); SetPlaceholder(); };
        }

        private void SetPlaceholder()
        {
            SetPlaceholder(_txtTimKiem, "Tìm kiếm theo họ tên, SĐT...");
        }

        private void SetPlaceholder(TextBox txt, string placeholder)
        {
            txt.Text = placeholder; txt.ForeColor = Color.Gray;
            txt.GotFocus += (s, ev) => { if (txt.Text == placeholder) { txt.Text = ""; txt.ForeColor = Color.Black; } };
            txt.LostFocus += (s, ev) => { if (string.IsNullOrWhiteSpace(txt.Text)) { txt.Text = placeholder; txt.ForeColor = Color.Gray; } };
        }

        private void ApplyPermissions()
        {
            bool isAdmin = _currentUserRole == "Admin";
            bool isQuanLy = _currentUserRole == "QuanLy";
            _btnThem.Visible = isAdmin;
            _btnSua.Visible = isAdmin || isQuanLy;
            _btnXoa.Visible = isAdmin;
            _btnDoiMK.Visible = isAdmin;
            _btnXemChiTiet.Visible = true; 
            bool canEdit = isAdmin || isQuanLy;
            _txtHoTen.ReadOnly = !canEdit;
            _txtSDT.ReadOnly = !canEdit;
            _cbGioiTinh.Enabled = canEdit;
            _cbChucVu.Enabled = canEdit;
        }

        private void LoadData()
        {
            int? selected = _maNVDangChon;
            string kw = _txtTimKiem.ForeColor == Color.Gray ? "" : _txtTimKiem.Text.Trim().ToLower();
            try
            {
                var query = from nv in _db.NhanViens
                            join tk in _db.TaiKhoans on nv.TÊN_ĐĂNG_NHẬP equals tk.TÊN_ĐĂNG_NHẬP into gj
                            from tk in gj.DefaultIfEmpty()
                            where (nv.HỌ_TÊN.ToLower().Contains(kw) || nv.SỐ_ĐIỆN_THOẠI.Contains(kw))
                            orderby nv.MÃ_NHÂN_VIÊN
                            select new
                            {
                                MaNV = nv.MÃ_NHÂN_VIÊN,
                                HoTen = nv.HỌ_TÊN,
                                GioiTinh = nv.GIỚI_TÍNH,
                                SDT = nv.SỐ_ĐIỆN_THOẠI,
                                ChucVu = nv.CHỨC_VỤ,
                                TaiKhoan = tk != null ? tk.TÊN_ĐĂNG_NHẬP : "N/A"
                            };
                _dgv.DataSource = query.ToList();

                if (selected.HasValue && _dgv.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in _dgv.Rows)
                    {
                        if (row.Cells["MaNV"].Value != null && (int)row.Cells["MaNV"].Value == selected.Value)
                        {
                            _dgv.CurrentCell = row.Cells[0];
                            row.Selected = true;
                            break;
                        }
                    }
                }
                FormatDgv();
            }
            catch (Exception ex)
            {
                Msg("Lỗi tải dữ liệu: " + ex.Message);
            }
            Clear();
        }

        private void FormatDgv()
        {
            _dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            if (_dgv.Columns.Contains("MaNV"))
            {
                _dgv.Columns["MaNV"].HeaderText = "Mã NV";
                _dgv.Columns["MaNV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _dgv.Columns["MaNV"].Width = 60;
            }
            if (_dgv.Columns.Contains("HoTen"))
            {
                _dgv.Columns["HoTen"].HeaderText = "Họ Tên";
                _dgv.Columns["HoTen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (_dgv.Columns.Contains("GioiTinh"))
            {
                _dgv.Columns["GioiTinh"].HeaderText = "Giới Tính";
                _dgv.Columns["GioiTinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _dgv.Columns["GioiTinh"].Width = 80;
            }
            if (_dgv.Columns.Contains("SDT"))
            {
                _dgv.Columns["SDT"].HeaderText = "SĐT";
                _dgv.Columns["SDT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _dgv.Columns["SDT"].Width = 120;
            }
            if (_dgv.Columns.Contains("ChucVu"))
            {
                _dgv.Columns["ChucVu"].HeaderText = "Chức Vụ";
                _dgv.Columns["ChucVu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _dgv.Columns["ChucVu"].Width = 100;
            }
            if (_dgv.Columns.Contains("TaiKhoan"))
            {
                _dgv.Columns["TaiKhoan"].HeaderText = "Tài Khoản";
                _dgv.Columns["TaiKhoan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _dgv.Columns["TaiKhoan"].Width = 100;
            }
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = _dgv.Rows[e.RowIndex];

            _maNVDangChon = (int)row.Cells["MaNV"].Value;
            _txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
            _cbGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
            _txtSDT.Text = row.Cells["SDT"].Value.ToString();
            _cbChucVu.Text = row.Cells["ChucVu"].Value.ToString();
        }

        private void TxtTimKiem_KeyUp(object sender, KeyEventArgs e) => LoadData();

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(_txtHoTen.Text)) { Msg("Vui lòng nhập họ tên!"); return false; }
            if (_cbGioiTinh.SelectedIndex == -1) { Msg("Vui lòng chọn giới tính!"); return false; }
            if (!Regex.IsMatch(_txtSDT.Text, @"^0[3|5|7|8|9]\d{8}$")) { Msg("Số điện thoại không hợp lệ (gồm 10 số, bắt đầu bằng 03,05,07,08,09)!"); return false; }
            if (_cbChucVu.SelectedIndex == -1) { Msg("Vui lòng chọn chức vụ!"); return false; }
            return true;
        }

        private bool IsSDTExists(string sdt, int? exclude = null)
        {
            var q = _db.NhanViens.Where(nv => nv.SỐ_ĐIỆN_THOẠI == sdt);
            if (exclude.HasValue) q = q.Where(nv => nv.MÃ_NHÂN_VIÊN != exclude.Value);
            return q.Any();
        }

        private void _btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            if (IsSDTExists(_txtSDT.Text)) { Msg("SĐT đã tồn tại!"); return; }

            string tenDN = GenerateUsername(_txtHoTen.Text);
            string mk = HashPassword("123");

            try
            {
                string quyen = "";
                if (_cbChucVu.Text == "Admin") quyen = "Admin";
                else if (_cbChucVu.Text == "QuanLy") quyen = "QuanLy";
                else if (_cbChucVu.Text == "ThuNgan") quyen = "ThuNgan";
                else quyen = "NhanVien";

                var tk = new QLICafeMeo.TaiKhoan
                {
                    TÊN_ĐĂNG_NHẬP = tenDN,
                    MẬT_KHẨU = mk,
                    QUYỀN = quyen
                };
                _db.TaiKhoans.InsertOnSubmit(tk);

                var nv = new QLICafeMeo.NhanVien
                {
                    HỌ_TÊN = _txtHoTen.Text,
                    GIỚI_TÍNH = _cbGioiTinh.Text,
                    SỐ_ĐIỆN_THOẠI = _txtSDT.Text,
                    CHỨC_VỤ = _cbChucVu.Text,
                    TÊN_ĐĂNG_NHẬP = tenDN
                };
                _db.NhanViens.InsertOnSubmit(nv);

                _db.SubmitChanges();

                MessageBox.Show($"Thêm thành công!\nTài khoản: {tenDN}\nMật khẩu: 123", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex) { Msg("Lỗi: " + ex.Message); }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private string GenerateUsername(string hoTen)
        {
            string noDiacritics = Regex.Replace(hoTen.Normalize(System.Text.NormalizationForm.FormD), @"\p{Mn}", string.Empty);
            string[] names = noDiacritics.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string baseName = names[names.Length - 1].ToLower();
            for (int i = 0; i < names.Length - 1; i++)
            {
                baseName += names[i].Substring(0, 1).ToLower();
            }

            string username = Regex.Replace(baseName, @"[^\w]", "");
            int count = 1;
            string check = username;

            while (_db.TaiKhoans.Any(t => t.TÊN_ĐĂNG_NHẬP == check))
            {
                check = username + count;
                count++;
            }
            return check;
        }

        private void _btnSua_Click(object sender, EventArgs e)
        {
            if (!_maNVDangChon.HasValue) { Msg("Vui lòng chọn nhân viên!"); return; }
            if (!ValidateInput()) return;
            if (IsSDTExists(_txtSDT.Text, _maNVDangChon)) { Msg("SĐT đã dùng!"); return; }
            try
            {
                var nv = _db.NhanViens.FirstOrDefault(n => n.MÃ_NHÂN_VIÊN == _maNVDangChon.Value);
                if (nv != null)
                {
                    nv.HỌ_TÊN = _txtHoTen.Text;
                    nv.GIỚI_TÍNH = _cbGioiTinh.Text;
                    nv.SỐ_ĐIỆN_THOẠI = _txtSDT.Text;
                    nv.CHỨC_VỤ = _cbChucVu.Text;

                    if (nv.TaiKhoan != null)
                    {
                        if (nv.CHỨC_VỤ == "Admin") nv.TaiKhoan.QUYỀN = "Admin";
                        else if (nv.CHỨC_VỤ == "QuanLy") nv.TaiKhoan.QUYỀN = "QuanLy";
                        else if (nv.CHỨC_VỤ == "ThuNgan") nv.TaiKhoan.QUYỀN = "ThuNgan";
                        else nv.TaiKhoan.QUYỀN = "NhanVien";
                    }

                    _db.SubmitChanges();
                    LoadData();
                    MsgSuccess("Cập nhật thành công!");
                }
            }
            catch (Exception ex) { Msg("Lỗi: " + ex.Message); }
        }

        private void _btnXoa_Click(object sender, EventArgs e)
        {
            if (!_maNVDangChon.HasValue) { Msg("Vui lòng chọn nhân viên!"); return; }
            if (MsgYesNo($"Xóa nhân viên \"{_txtHoTen.Text}\"?\nTHAO TÁC NÀY SẼ XÓA VĨNH VIỄN VÀ CÓ THỂ LỖI NẾU NHÂN VIÊN ĐÃ LẬP HÓA ĐƠN.") != DialogResult.Yes) return;

            try
            {
                var nv = _db.NhanViens.FirstOrDefault(n => n.MÃ_NHÂN_VIÊN == _maNVDangChon.Value);
                if (nv == null) return;

                
               
                var chiTietHD = from ct in _db.ChiTietHoaDons
                                join hd in _db.HoaDons on ct.MÃ_HÓA_ĐƠN equals hd.MÃ_HÓA_ĐƠN
                                where hd.MÃ_NHÂN_VIÊN == _maNVDangChon.Value
                                select ct;
                _db.ChiTietHoaDons.DeleteAllOnSubmit(chiTietHD);

                var hoaDon = _db.HoaDons.Where(h => h.MÃ_NHÂN_VIÊN == _maNVDangChon.Value);
                _db.HoaDons.DeleteAllOnSubmit(hoaDon);

                
                if (nv.TaiKhoan != null)
                {
                    _db.TaiKhoans.DeleteOnSubmit(nv.TaiKhoan);
                }

               
                _db.NhanViens.DeleteOnSubmit(nv);

                _db.SubmitChanges();

                LoadData();
                MsgSuccess("Xóa thành công!");
            }
            catch (Exception ex)
            {
                Msg("Lỗi: " + ex.Message + "\nCó thể nhân viên đã có dữ liệu liên quan không thể xóa.");
            }
        }

        private void _btnDoiMK_Click(object sender, EventArgs e)
        {
            if (!_maNVDangChon.HasValue) { Msg("Vui lòng chọn nhân viên!"); return; }

            using (var f = new Form
            {
                Text = "Đổi Mật Khẩu",
                Size = new Size(380, 180),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            })
            {
                var lbl = new Label { Text = "Mật khẩu mới:", Location = new Point(30, 30), AutoSize = true };
                var txt = new TextBox { Location = new Point(140, 27), Width = 180, PasswordChar = '*' };
                var ok = new Button { Text = "ĐỔI", Location = new Point(140, 80), DialogResult = DialogResult.OK, FlatStyle = FlatStyle.Flat, BackColor = Color.FromArgb(0, 123, 255), ForeColor = Color.White };
                var cancel = new Button { Text = "HỦY", Location = new Point(230, 80), DialogResult = DialogResult.Cancel, FlatStyle = FlatStyle.Flat };
                f.Controls.AddRange(new Control[] { lbl, txt, ok, cancel });
                f.AcceptButton = ok; f.CancelButton = cancel;
                if (f.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(txt.Text))
                {
                    try
                    {
                        var nv = _db.NhanViens.FirstOrDefault(n => n.MÃ_NHÂN_VIÊN == _maNVDangChon.Value);
                        if (nv?.TÊN_ĐĂNG_NHẬP != null)
                        {
                            var tk = _db.TaiKhoans.FirstOrDefault(t => t.TÊN_ĐĂNG_NHẬP == nv.TÊN_ĐĂNG_NHẬP);
                            if (tk != null)
                            {
                                tk.MẬT_KHẨU = HashPassword(txt.Text);
                                _db.SubmitChanges();
                                MsgSuccess("Đổi mật khẩu thành công!");
                            }
                        }
                        else Msg("Nhân viên chưa có tài khoản!");
                    }
                    catch (Exception ex) { Msg("Lỗi: " + ex.Message); }
                }
            }
        }

      
        private void BtnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (!_maNVDangChon.HasValue) { Msg("Vui lòng chọn nhân viên!"); return; }

            var nv = _db.NhanViens.FirstOrDefault(n => n.MÃ_NHÂN_VIÊN == _maNVDangChon.Value);
            if (nv == null) return;

            string maTK = nv.TÊN_ĐĂNG_NHẬP ?? "Chưa có tài khoản";
            string quyen = nv.TaiKhoan?.QUYỀN ?? "N/A";

            MessageBox.Show(
                $"Thông tin chi tiết nhân viên:\n" +
                $"- Mã NV: {_maNVDangChon.Value}\n" +
                $"- Họ Tên: {nv.HỌ_TÊN}\n" +
                $"- SĐT: {nv.SỐ_ĐIỆN_THOẠI}\n" +
                $"- Chức vụ: {nv.CHỨC_VỤ}\n" +
                $"--------------------------\n" +
                $"- Tên Đăng Nhập: {maTK}\n" +
                $"- Quyền: {quyen}",
                "Xem Chi Tiết Nhân Viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void Clear()
        {
            _txtHoTen.Clear(); _txtSDT.Clear();
            _cbGioiTinh.SelectedIndex = -1; _cbChucVu.SelectedIndex = -1;
            _maNVDangChon = null;
            _dgv.ClearSelection();
        }

        private void Msg(string msg) => MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void MsgSuccess(string msg) => MessageBox.Show(msg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private DialogResult MsgYesNo(string msg) => MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
    }
}