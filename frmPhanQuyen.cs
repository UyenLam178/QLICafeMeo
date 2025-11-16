// frmPhanQuyen.cs 
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QLICafeMeo
{
    public partial class frmPhanQuyen : Form
    {
        private DataClasses1DataContext _db;
        private string userDangChon;
        private readonly string _currentUserRole;

        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);

        
        private static readonly Dictionary<string, string> QuyenMap = new Dictionary<string, string>
        {
            {"Admin", "Admin"},
            {"ThuNgan", "Thu Ngân"},
            {"NhanVien", "Nhân Viên"},
            {"Disabled", "Vô hiệu hóa"}
        };
        

        // Constructor mặc định
        public frmPhanQuyen() : this("Admin") { }

        // Constructor nhận quyền
        public frmPhanQuyen(string role)
        {
            InitializeComponent();
            _currentUserRole = role; 
        
            _db = new DataClasses1DataContext(Properties.Settings.Default.QLICafeMeoConnectionString1);

            this.Load += (s, e) => { LoadData(); ApplyPermissions(); };
            dgv.SelectionChanged += dgv_SelectionChanged;


            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
        }

        private string HashPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return null;
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
                return Convert.ToBase64String(bytes);
            }
        }

        private string MapQuyenToVietnamese(string dbQuyen)
        {
            return QuyenMap.ContainsKey(dbQuyen) ? QuyenMap[dbQuyen] : dbQuyen;
        }

        private string MapQuyenToDatabase(string vnQuyen)
        {
            var pair = QuyenMap.FirstOrDefault(x => x.Value == vnQuyen);
            return pair.Key ?? vnQuyen;
        }

        private void ApplyPermissions()
        {
            bool isAdmin = _currentUserRole == "Admin";
            if (!isAdmin)
            {
                // Nếu không phải Admin, khóa toàn bộ form
                txtUser.Enabled = false;
                txtPass.Enabled = false;
                cbQuyen.Enabled = false;
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnXoa.Visible = false;
                dgv.Enabled = false;
            }
        }

        private void LoadData()
        {
            var dataFromDb = _db.TaiKhoans
                              .Select(t => new {
                                  TenDangNhap = t.TÊN_ĐĂNG_NHẬP,
                                  Quyen = t.QUYỀN
                              })
                              .OrderBy(t => t.TenDangNhap)
                              .ToList();

            dgv.DataSource = dataFromDb.Select(t => new
            {
                t.TenDangNhap,
                Quyen = MapQuyenToVietnamese(t.Quyen) 
            }).ToList();


            if (dgv.Columns.Contains("TenDangNhap")) dgv.Columns["TenDangNhap"].HeaderText = "Tên Đăng Nhập";
            if (dgv.Columns.Contains("Quyen")) dgv.Columns["Quyen"].HeaderText = "Quyền";

            ClearForm();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                var row = dgv.SelectedRows[0];

                string vnQuyen = row.Cells["Quyen"].Value.ToString();

                userDangChon = row.Cells["TenDangNhap"].Value.ToString();
                txtUser.Text = userDangChon;
                cbQuyen.Text = vnQuyen; 
                txtPass.Clear();
                SendMessage(txtPass.Handle, EM_SETCUEBANNER, IntPtr.Zero, "Nhập để thay đổi mật khẩu");
                txtUser.ReadOnly = true;
                btnThem.Enabled = false; btnSua.Enabled = true; btnXoa.Enabled = true;
            }
        }

        private void ClearForm()
        {
            txtUser.Clear();
            txtPass.Clear();
            cbQuyen.SelectedIndex = -1;
            userDangChon = null;
            SendMessage(txtPass.Handle, EM_SETCUEBANNER, IntPtr.Zero, string.Empty);
            txtUser.ReadOnly = false;
            btnThem.Enabled = true; btnSua.Enabled = false; btnXoa.Enabled = false;
            dgv.ClearSelection();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text) || cbQuyen.SelectedIndex == -1) return;

            if (_db.TaiKhoans.Any(t => t.TÊN_ĐĂNG_NHẬP == txtUser.Text.Trim()))
            {
                MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dbQuyen = MapQuyenToDatabase(cbQuyen.Text);

            var tk = new TaiKhoan
            {
                TÊN_ĐĂNG_NHẬP = txtUser.Text.Trim(),
                MẬT_KHẨU = HashPassword(txtPass.Text),
                QUYỀN = dbQuyen 
            };
            _db.TaiKhoans.InsertOnSubmit(tk);
            _db.SubmitChanges();
            LoadData();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userDangChon) || cbQuyen.SelectedIndex == -1) return;

            var tk = _db.TaiKhoans.FirstOrDefault(t => t.TÊN_ĐĂNG_NHẬP == userDangChon);
            if (tk != null)
            {
                tk.QUYỀN = MapQuyenToDatabase(cbQuyen.Text);

                if (!string.IsNullOrWhiteSpace(txtPass.Text))
                    tk.MẬT_KHẨU = HashPassword(txtPass.Text);
                _db.SubmitChanges();
                LoadData();
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userDangChon)) return;
            if (MessageBox.Show($"Xóa tài khoản '{userDangChon}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                var tk = _db.TaiKhoans.FirstOrDefault(t => t.TÊN_ĐĂNG_NHẬP == userDangChon);
                if (tk != null)
                {
                    // 1. Kiểm tra và gỡ liên kết khỏi bảng NhanVien (FK)
                    var nv = _db.NhanViens.FirstOrDefault(n => n.TÊN_ĐĂNG_NHẬP == userDangChon);
                    if (nv != null)
                    {
                        nv.TÊN_ĐĂNG_NHẬP = null; 
                    }

                    // 2. Xóa Tài Khoản
                    _db.TaiKhoans.DeleteOnSubmit(tk);
                    _db.SubmitChanges();
                    MsgSuccess("Đã xóa tài khoản thành công!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MsgSuccess(string msg) => MessageBox.Show(msg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _db?.Dispose();
            base.OnFormClosed(e);
        }
    }
}