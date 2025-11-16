// TrangChu.cs 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLICafeMeo.Forms; 

namespace QLICafeMeo
{
    public partial class TrangChu : Form
    {
        private readonly string _quyen;
        private readonly string _tenDangNhap;
        private List<Button> _menuButtons;
        private ToolTip _toolTip;
        private Timer _clockTimer;

        public TrangChu(string quyen, string tenDangNhap)
        {
            _quyen = quyen ?? "";
            _tenDangNhap = tenDangNhap ?? "KHÁCH";
            InitializeComponent();
            SetupEvents();
            LoadMenuButtons();
            StartClock();
        }

        private void SetupEvents()
        {
            _toolTip = new ToolTip { ShowAlways = true };

            const string placeholder = "Tìm nhanh menu...";
            txtSearch.Text = placeholder;
            txtSearch.ForeColor = Color.Gray;

            txtSearch.GotFocus += (s, e) =>
            {
                if (txtSearch.Text == placeholder) { txtSearch.Text = ""; txtSearch.ForeColor = Color.Black; }
            };

            txtSearch.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = placeholder; txtSearch.ForeColor = Color.Gray; }
            };

            txtSearch.TextChanged += (s, e) =>
            {
                string kw = txtSearch.ForeColor == Color.Gray ? "" : txtSearch.Text.Trim().ToLower();
                foreach (var btn in _menuButtons)
                    btn.Visible = string.IsNullOrEmpty(kw) || btn.Text.ToLower().Contains(kw);
            };

            btnLogout.Click += (s, e) =>
            {
                if (MessageBox.Show("Đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Application.Restart();
            };

            lblUser.Text = $"Xin chào, {_tenDangNhap.ToUpper()}!";
            lblRole.Text = $"Quyền: {_quyen.ToUpper()}";
        }

        private void StartClock()
        {
            _clockTimer = new Timer { Interval = 1000 };
            _clockTimer.Tick += (s, e) => lblClock.Text = DateTime.Now.ToString("HH:mm:ss | dd/MM/yyyy");
            _clockTimer.Start();
        }

        private void LoadMenuButtons()
        {
    
            flpMenu.Controls.Clear();
            _menuButtons = new List<Button>();

            var items = new[]
            {
                new MenuItem("NHÂN VIÊN", typeof(frmNhanVien), Color.FromArgb(46, 125, 50), "Admin"),
                new MenuItem("KHÁCH HÀNG", typeof(frmKhachHang), Color.FromArgb(21, 101, 192), null),
                new MenuItem("QUẢN LÝ MÈO", typeof(frmNVMeo), Color.FromArgb(255, 143, 0), "Admin"),
                new MenuItem("PHÒNG CHƠI", typeof(frmPhong), Color.FromArgb(211, 47, 47), "Admin"),
                new MenuItem("MENU", typeof(frmQuanLyMon), Color.FromArgb(13, 71, 161), "Admin"),
                new MenuItem("GỌI MÓN", typeof(DonHang), Color.FromArgb(55, 71, 79), null),
                new MenuItem("HÓA ĐƠN", typeof(frmHoaDon), Color.FromArgb(106, 27, 154), null),
                new MenuItem("SỰ KIỆN/KM", typeof(QLICafeMeo.Forms.frmSuKien), Color.FromArgb(171, 71, 188), "Admin,QuanLy"),
                
       
                new MenuItem("THỐNG KÊ KHÁCH", typeof(frmThongKeKhach), Color.FromArgb(198, 40, 40), "Admin,ThuQuy"),
                new MenuItem("THỐNG KÊ LOẠI", typeof(frmThongKeTheoLoai), Color.FromArgb(255, 160, 0), "Admin,ThuQuy"),

                new MenuItem("TÌM KIẾM", typeof(frmTimKiem), Color.FromArgb(136, 14, 79), null),
                new MenuItem("CẤU HÌNH", typeof(frmCauHinh), Color.FromArgb(13, 71, 161), "Admin"),
                new MenuItem("PHÂN QUYỀN", typeof(frmPhanQuyen), Color.FromArgb(74, 20, 140), "Admin")
            };

            foreach (var item in items)
            {
                if (item.RoleRequired != null && !item.RoleRequired.Split(',').Contains(_quyen))
                    continue;

                var btn = CreateMenuButton(item.Text, item.FormType, item.Color);
                flpMenu.Controls.Add(btn);
                _menuButtons.Add(btn);
            }
        }

        private void RefreshMenu()
        {
            flpMenu.Controls.Clear();
            LoadMenuButtons();
        }

        private Button CreateMenuButton(string text, Type formType, Color baseColor)
        {
            var btn = new Button
            {
                Text = text,
                Size = new Size(180, 130),
                BackColor = baseColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(15),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;

            var hoverColor = Color.FromArgb(
                Math.Min(255, baseColor.R + 30),
                Math.Min(255, baseColor.G + 30),
                Math.Min(255, baseColor.B + 30)
            );
            btn.MouseEnter += (s, e) => btn.BackColor = hoverColor;
            btn.MouseLeave += (s, e) => btn.BackColor = baseColor;

            _toolTip.SetToolTip(btn, $"Mở {text}");

            btn.Click += (s, e) =>
            {
                try
                {
                    if (formType == null)
                    {
                        MessageBox.Show($"Form cho '{text}' chưa được định nghĩa (null).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Form form;
                    var constructor = formType.GetConstructor(new[] { typeof(string) });
                    if (constructor != null)
                    {
                        form = (Form)Activator.CreateInstance(formType, _quyen);
                    }
                    else
                    {
                        form = (Form)Activator.CreateInstance(formType);
                    }

                    if (formType == typeof(frmPhanQuyen))
                    {
                        form.FormClosed += (fs, fe) => RefreshMenu();
                    }

                    form.ShowDialog();
                }
                catch (Exception ex)
                {
                    string innerEx = ex.InnerException?.Message ?? ex.Message;
                    MessageBox.Show($"Lỗi khi mở form '{formType?.Name}':\n{innerEx}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            return btn;
        }

        private class MenuItem
        {
            public string Text { get; }
            public Type FormType { get; }
            public Color Color { get; }
            public string RoleRequired { get; }

            public MenuItem(string text, Type formType, Color color, string roleRequired)
            {
                Text = text;
                FormType = formType;
                Color = color;
                RoleRequired = roleRequired;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F)) { txtSearch.Focus(); txtSearch.SelectAll(); return true; }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _clockTimer?.Stop();
            base.OnFormClosed(e);
        }
    }
}