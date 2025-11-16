//frmPhong.cs
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.Linq;

namespace QLICafeMeo
{
    public partial class frmPhong : Form
    {
        private DataClasses1DataContext _db;
        private int? _maPhongDangChon;

        public frmPhong()
        {
            InitializeComponent();
            this._cbTrangThai.Items.AddRange(new object[] { "Trống", "Đang sử dụng", "Đang dọn" });
            this._cbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Clear()
        {
            _txtTen.Clear();
            _nudSucChua.Value = _nudSucChua.Minimum;
            _cbTrangThai.SelectedIndex = -1;
            _maPhongDangChon = null;
            _dgv.ClearSelection();
        }

        private void Msg(string msg) => MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void MsgSuccess(string msg) => MessageBox.Show(msg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private DialogResult MsgYesNo(string msg) => MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        private void Phong_Load(object sender, EventArgs e)
        {
            _db = new DataClasses1DataContext(Properties.Settings.Default.QLICafeMeoConnectionString);
            LoadData();
            FormatDgv();
        }

        private void FormatDgv()
        {
            _dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            if (_dgv.Columns.Contains("MaPhong"))
            {
                _dgv.Columns["MaPhong"].HeaderText = "Mã Phòng";
                _dgv.Columns["MaPhong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _dgv.Columns["MaPhong"].Width = 80;
            }
            if (_dgv.Columns.Contains("TenPhong"))
            {
                _dgv.Columns["TenPhong"].HeaderText = "Tên Phòng";
                _dgv.Columns["TenPhong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                _dgv.Columns["TenPhong"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (_dgv.Columns.Contains("SucChua"))
            {
                _dgv.Columns["SucChua"].HeaderText = "Sức Chứa";
                _dgv.Columns["SucChua"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _dgv.Columns["SucChua"].Width = 100;
            }
            if (_dgv.Columns.Contains("TrangThai"))
            {
                _dgv.Columns["TrangThai"].HeaderText = "Trạng Thái";
                _dgv.Columns["TrangThai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _dgv.Columns["TrangThai"].Width = 150;
            }
        }

        private void LoadData()
        {
            try
            {
                var query = from p in _db.Phongs
                            orderby p.TÊN_PHÒNG
                            select new
                            {
                                MaPhong = p.MÃ_PHÒNG,
                                TenPhong = p.TÊN_PHÒNG,
                                SucChua = p.SỨC_CHỨA,
                                TrangThai = p.TRẠNG_THÁI
                            };
                _dgv.DataSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Clear();
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || _dgv.Rows.Count == 0) return;
            var row = _dgv.Rows[e.RowIndex];

            if (row.Cells["MaPhong"].Value == null) return;

            _maPhongDangChon = (int)row.Cells["MaPhong"].Value;
            _txtTen.Text = row.Cells["TenPhong"].Value.ToString();

            if (row.Cells["SucChua"].Value is int sucChua)
            {
                _nudSucChua.Value = sucChua;
            }
            else
            {
                _nudSucChua.Value = _nudSucChua.Minimum;
            }

            _cbTrangThai.Text = row.Cells["TrangThai"].Value?.ToString() ?? string.Empty;
        }

        private void _btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_txtTen.Text)) { Msg("Vui lòng nhập tên phòng!"); return; }
            if (_cbTrangThai.SelectedIndex == -1) { Msg("Vui lòng chọn trạng thái!"); return; }

            try
            {
                if (_db.Phongs.Any(p => p.TÊN_PHÒNG == _txtTen.Text))
                {
                    Msg("Tên phòng đã tồn tại. Vui lòng chọn tên khác.");
                    return;
                }

                var newPhong = new QLICafeMeo.Phong
                {
                    TÊN_PHÒNG = _txtTen.Text,
                    SỨC_CHỨA = (int)_nudSucChua.Value,
                    TRẠNG_THÁI = _cbTrangThai.Text,
                };
                _db.Phongs.InsertOnSubmit(newPhong);
                _db.SubmitChanges();
                LoadData();
                MsgSuccess("Thêm phòng thành công!");
            }
            catch (Exception ex) { Msg("Lỗi: " + ex.Message); }
        }

        private void _btnSua_Click(object sender, EventArgs e)
        {
            if (!_maPhongDangChon.HasValue) { Msg("Vui lòng chọn phòng để sửa!"); return; }
            if (string.IsNullOrWhiteSpace(_txtTen.Text)) { Msg("Vui lòng nhập tên phòng!"); return; }
            if (_cbTrangThai.SelectedIndex == -1) { Msg("Vui lòng chọn trạng thái!"); return; }

            try
            {
                if (_db.Phongs.Any(x => x.TÊN_PHÒNG == _txtTen.Text && x.MÃ_PHÒNG != _maPhongDangChon.Value))
                {
                    Msg("Tên phòng đã tồn tại. Vui lòng chọn tên khác.");
                    return;
                }

                var phongToUpdate = _db.Phongs.FirstOrDefault(p => p.MÃ_PHÒNG == _maPhongDangChon.Value);
                if (phongToUpdate != null)
                {
                    phongToUpdate.TÊN_PHÒNG = _txtTen.Text;
                    phongToUpdate.SỨC_CHỨA = (int)_nudSucChua.Value;
                    phongToUpdate.TRẠNG_THÁI = _cbTrangThai.Text;
                    _db.SubmitChanges();
                    LoadData();
                    MsgSuccess("Sửa thông tin phòng thành công!");
                }
            }
            catch (Exception ex) { Msg("Lỗi: " + ex.Message); }
        }

        private void _btnXoa_Click(object sender, EventArgs e)
        {
            if (!_maPhongDangChon.HasValue) { Msg("Vui lòng chọn phòng để xóa!"); return; }
            if (MsgYesNo("Bạn có chắc chắn muốn xóa phòng này?") != DialogResult.Yes) return;

            try
            {
                var p = _db.Phongs.FirstOrDefault(x => x.MÃ_PHÒNG == _maPhongDangChon.Value);
                if (p != null)
                {
                    _db.Phongs.DeleteOnSubmit(p);
                    _db.SubmitChanges();
                    LoadData();
                    MsgSuccess("Xóa phòng thành công!");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("REFERENCE constraint") || ex.Message.Contains("khóa ngoại"))
                {
                    Msg("Lỗi: Xóa thất bại. Phòng đang được sử dụng hoặc có dữ liệu liên quan.");
                }
                else
                {
                    Msg("Lỗi: " + ex.Message);
                }
            }
        }
    }
}