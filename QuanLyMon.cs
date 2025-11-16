// frmQuanLyMon.cs
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.Linq;

namespace QLICafeMeo.Forms
{
    
    public partial class frmQuanLyMon : Form
    {
        private int? _maMon;
        private readonly DataClasses1DataContext _db;
        private readonly string _currentUserRole;

        public frmQuanLyMon() : this("NhanVien") { }

      
        public frmQuanLyMon(string role = "NhanVien")
        {
            _currentUserRole = role;
            _db = new DataClasses1DataContext(QLICafeMeo.Properties.Settings.Default.QLICafeMeoConnectionString);
            InitializeComponent();

           
            this._cbLoai.Items.AddRange(new object[] { "Đồ uống", "Ăn nhẹ", "Cho mèo" });

            this.Load += (s, e) => { LoadData(); ApplyPermissions(); SetPlaceholder(); FormatDgv(); };
        }

        private void SetPlaceholder()
        {
            SetPlaceholder(_txtTimKiem, "Tìm món theo tên hoặc loại...");
        }

        private void SetPlaceholder(TextBox txt, string placeholder)
        {
            txt.Text = placeholder;
            txt.ForeColor = Color.Gray;

            txt.GotFocus += (s, ev) =>
            {
                if (txt.Text == placeholder)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                }
            };

            txt.LostFocus += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                }
            };
        }

        private void ApplyPermissions()
        {
           
            bool isAdmin = _currentUserRole == "Admin";
            bool isQuanLy = _currentUserRole == "QuanLy";
            bool canEdit = isAdmin || isQuanLy;

            _btnThem.Visible = isAdmin;
            _btnSua.Visible = canEdit;
            _btnXoa.Visible = isAdmin;

            _txtTenMon.ReadOnly = !canEdit;
            _txtGia.ReadOnly = !canEdit;
            _cbLoai.Enabled = canEdit;
        }

        private void FormatDgv()
        {
            
            if (_dgvMon.Columns.Contains("MÃ_MÓN")) _dgvMon.Columns["MÃ_MÓN"].HeaderText = "Mã Món";
            if (_dgvMon.Columns.Contains("TÊN_MÓN")) _dgvMon.Columns["TÊN_MÓN"].HeaderText = "Tên Món";
            if (_dgvMon.Columns.Contains("GIÁ"))
            {
                _dgvMon.Columns["GIÁ"].HeaderText = "Giá";
                _dgvMon.Columns["GIÁ"].DefaultCellStyle.Format = "N0"; 
                _dgvMon.Columns["GIÁ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (_dgvMon.Columns.Contains("Loai")) _dgvMon.Columns["Loai"].HeaderText = "Loại";
        }


        private void LoadData() 
        {
            string kw = _txtTimKiem.ForeColor == Color.Gray ? "" : _txtTimKiem.Text.Trim().ToLower();

            try
            {
               
                var query = from m in _db.Mons
                            where m.TÊN_MÓN.ToLower().Contains(kw) ||
                                  (m.LOẠI ?? "").ToLower().Contains(kw)
                            orderby m.MÃ_MÓN
                            select new
                            {
                                m.MÃ_MÓN,
                                m.TÊN_MÓN,
                                m.GIÁ,
                                Loai = m.LOẠI ?? "Chưa phân loại"
                            };

                _dgvMon.DataSource = query.ToList();

               
                if (_maMon.HasValue && _dgvMon.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in _dgvMon.Rows)
                    {
                        if (row.Cells["MÃ_MÓN"].Value != null && (int)row.Cells["MÃ_MÓN"].Value == _maMon.Value)
                        {
                            _dgvMon.CurrentCell = row.Cells[0];
                            row.Selected = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Msg("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void DgvMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _dgvMon.Rows.Count) return;
            var row = _dgvMon.Rows[e.RowIndex];

         
            if (row.Cells["MÃ_MÓN"].Value == null) return;

            _maMon = (int)row.Cells["MÃ_MÓN"].Value;
            _txtTenMon.Text = row.Cells["TÊN_MÓN"].Value.ToString();

           
            if (row.Cells["GIÁ"].Value is decimal giaValue)
            {
                _txtGia.Text = giaValue.ToString("N0");
            }
            else
            {
                _txtGia.Text = row.Cells["GIÁ"].Value.ToString();
            }

            _cbLoai.Text = row.Cells["Loai"].Value.ToString();
        }

        private void TxtTimKiem_KeyUp(object sender, KeyEventArgs e) => LoadData();

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(_txtTenMon.Text)) { Msg("Vui lòng nhập tên món!"); return false; }
           
            if (!decimal.TryParse(_txtGia.Text.Replace(",", ""), out decimal gia) || gia <= 0) { Msg("Giá phải là số dương!"); return false; }
            if (_cbLoai.SelectedIndex == -1) { Msg("Vui lòng chọn loại món!"); return false; }
            return true;
        }


        private bool IsTenMonExists(string ten, int? excludeMaMon = null)
        {
          
            var query = _db.Mons.Where(m => m.TÊN_MÓN == ten);
            if (excludeMaMon.HasValue)
            {
           
                query = query.Where(m => m.MÃ_MÓN != excludeMaMon.Value);
            }
            return query.Any(); 
        }

        private void _btnThem_Click(object sender, EventArgs e) 
        {
            if (!ValidateInput()) return;
            if (IsTenMonExists(_txtTenMon.Text)) { Msg("Tên món đã tồn tại!"); return; }

            decimal giaParsed = decimal.Parse(_txtGia.Text.Replace(",", ""));

            try
            {

                var mon = new QLICafeMeo.Mon
                {
                    TÊN_MÓN = _txtTenMon.Text,
                    GIÁ = giaParsed,
                    LOẠI = _cbLoai.Text,
                    NGỪNG_KINH_DOANH = false 
                };

                _db.Mons.InsertOnSubmit(mon); 
                _db.SubmitChanges();

                MessageBox.Show("Thêm món thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _maMon = mon.MÃ_MÓN;
                LoadData();
                Clear();
            }
            catch (Exception ex) { Msg("Lỗi: " + ex.Message); }
        }

        private void _btnSua_Click(object sender, EventArgs e) 
        {
            if (!_maMon.HasValue) { Msg("Vui lòng chọn món để sửa!"); return; }
            if (!ValidateInput()) return;
            if (IsTenMonExists(_txtTenMon.Text, _maMon)) { Msg("Tên món đã tồn tại!"); return; }

            decimal giaParsed = decimal.Parse(_txtGia.Text.Replace(",", ""));

            try
            {
               
                var mon = _db.Mons.FirstOrDefault(m => m.MÃ_MÓN == _maMon.Value);
                if (mon != null)
                {
                    mon.TÊN_MÓN = _txtTenMon.Text;
                    mon.GIÁ = giaParsed;
                    mon.LOẠI = _cbLoai.Text;

                    _db.SubmitChanges(); 
                    LoadData();
                    Clear();
                    MessageBox.Show("Cập nhật thành công!");
                }
            }
            catch (Exception ex) { Msg("Lỗi: " + ex.Message); }
        }

        private void _btnXoa_Click(object sender, EventArgs e)
        {
            if (!_maMon.HasValue) { Msg("Vui lòng chọn món để xóa!"); return; }
            if (MessageBox.Show($"Xóa món \"{_txtTenMon.Text}\"?\nTất cả hóa đơn liên quan sẽ bị ảnh hưởng!", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                var mon = _db.Mons.FirstOrDefault(m => m.MÃ_MÓN == _maMon.Value);
                if (mon != null)
                {
                    
                    var chiTiet = _db.ChiTietHoaDons.Where(ct => ct.MÃ_MÓN == _maMon);
                    _db.ChiTietHoaDons.DeleteAllOnSubmit(chiTiet);

                    _db.Mons.DeleteOnSubmit(mon);
                    _db.SubmitChanges(); 

                    LoadData();
                    Clear();
                    MessageBox.Show("Xóa thành công!");
                }
            }
            catch (Exception ex) { Msg("Lỗi: " + ex.Message); }
        }

        private void Clear()
        {
            _txtTenMon.Clear();
            _txtGia.Clear();
            _cbLoai.SelectedIndex = -1;
            _maMon = null;
        }

        private void Msg(string msg) => MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}