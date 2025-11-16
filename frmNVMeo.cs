// frmNVMeo.cs 
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace QLICafeMeo
{
    public partial class frmNVMeo : Form
    {
        private readonly DataClasses1DataContext _db = new DataClasses1DataContext(Properties.Settings.Default.QLICafeMeoConnectionString);
        private int? _maMeoDangChon;

        public frmNVMeo()
        {
            InitializeComponent();
            Load += (s, e) => LoadData();

            if (_cbTinhTrang.Items.Count > 0)
            {
                _cbTinhTrang.SelectedIndex = 0;
            }

            _dgv.CellFormatting += _dgv_CellFormatting;
        }

        private void LoadData()
        {
            try
            {
                var query = from m in _db.Meos
                            where m.ĐÃ_XÓA == false
                            select new
                            {
                                MaMeo = m.MÃ_MÈO,
                                TenMeo = m.TÊN_MÈO,
                                Giong = m.GIỐNG_MÈO,
                                TinhTrang = m.TÌNH_TRẠNG,
                                NgayTiemPhong = m.NGÀY_TIÊM_PHÒNG,
                                GhiChu = m.GHI_CHÚ
                            };
                _dgv.DataSource = query.ToList();

                if (_dgv.Columns.Count > 0)
                {
                    if (_dgv.Columns.Contains("MaMeo")) _dgv.Columns["MaMeo"].Visible = false;

                    SetColumnStyle(_dgv.Columns["TenMeo"], "Tên Mèo", DataGridViewContentAlignment.MiddleLeft);
                    SetColumnStyle(_dgv.Columns["Giong"], "Giống", DataGridViewContentAlignment.MiddleLeft);
                    SetColumnStyle(_dgv.Columns["TinhTrang"], "Tình Trạng", DataGridViewContentAlignment.MiddleLeft);
                    SetColumnStyle(_dgv.Columns["NgayTiemPhong"], "Ngày Tiêm Phòng", DataGridViewContentAlignment.MiddleCenter);
                    SetColumnStyle(_dgv.Columns["GhiChu"], "Ghi Chú", DataGridViewContentAlignment.MiddleLeft);

                    foreach (DataGridViewColumn col in _dgv.Columns)
                    {
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        col.HeaderCell.Style.Font = new Font(_dgv.Font, FontStyle.Bold);
                    }

                    if (_dgv.Columns.Contains("GhiChu")) _dgv.Columns["GhiChu"].FillWeight = 150;
                }
            }
            catch (Exception ex)
            {
                Msg("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void SetColumnStyle(DataGridViewColumn column, string headerText, DataGridViewContentAlignment alignment)
        {
            if (column == null) return;
            column.HeaderText = headerText;
            column.DefaultCellStyle.Alignment = alignment;
        }

        private void _dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_dgv.Columns[e.ColumnIndex].Name == "TenMeo" || _dgv.Columns[e.ColumnIndex].Name == "Giong")
            {
                if (e.Value != null && e.Value is string text)
                {
                    e.Value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
                    e.FormattingApplied = true;
                }
            }
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = _dgv.Rows[e.RowIndex];
            _maMeoDangChon = (int)row.Cells["MaMeo"].Value;
            _txtTen.Text = row.Cells["TenMeo"].Value.ToString();
            _txtGiong.Text = row.Cells["Giong"].Value.ToString();
            _cbTinhTrang.Text = row.Cells["TinhTrang"].Value.ToString();
            if (row.Cells["NgayTiemPhong"].Value is DateTime dt)
                _dtTiemPhong.Value = dt;
            else
                _dtTiemPhong.Value = DateTime.Today;
            _txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";
        }

        private void _btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_txtTen.Text)) { Msg("Nhập tên mèo!"); return; }
            try
            {
                var meo = new global::QLICafeMeo.Meo
                {
                    TÊN_MÈO = _txtTen.Text.ToLower(),
                    GIỐNG_MÈO = _txtGiong.Text.ToLower(),
                    TÌNH_TRẠNG = _cbTinhTrang.Text,
                    NGÀY_TIÊM_PHÒNG = _dtTiemPhong.Value,
                    GHI_CHÚ = _txtGhiChu.Text.ToLower(),
                    ĐÃ_XÓA = false
                };
                _db.Meos.InsertOnSubmit(meo);
                _db.SubmitChanges();
                LoadData(); Clear();
                MsgSuccess("Thêm thành công!");
            }
            catch (Exception ex) { Msg("Lỗi thêm: " + ex.Message); }
        }

        private void _btnSua_Click(object sender, EventArgs e)
        {
            if (!_maMeoDangChon.HasValue) { Msg("Chọn mèo!"); return; }
            try
            {
                var meo = _db.Meos.FirstOrDefault(m => m.MÃ_MÈO == _maMeoDangChon.Value);
                if (meo != null)
                {
                    meo.TÊN_MÈO = _txtTen.Text.ToLower();
                    meo.GIỐNG_MÈO = _txtGiong.Text.ToLower();
                    meo.TÌNH_TRẠNG = _cbTinhTrang.Text;
                    meo.NGÀY_TIÊM_PHÒNG = _dtTiemPhong.Value;
                    meo.GHI_CHÚ = _txtGhiChu.Text.ToLower();
                    _db.SubmitChanges();
                    LoadData(); Clear();
                    MsgSuccess("Sửa thành công!");
                }
            }
            catch (Exception ex) { Msg("Lỗi sửa: " + ex.Message); }
        }

        private void _btnXoa_Click(object sender, EventArgs e)
        {
            if (!_maMeoDangChon.HasValue) { Msg("Chọn mèo!"); return; }
            if (MsgYesNo("Xóa mèo này?") != DialogResult.Yes) return;
            try
            {
                var meo = _db.Meos.FirstOrDefault(m => m.MÃ_MÈO == _maMeoDangChon.Value);
                if (meo != null)
                {
                    meo.ĐÃ_XÓA = true;
                    _db.SubmitChanges();
                    LoadData(); Clear();
                    MsgSuccess("Xóa thành công!");
                }
            }
            catch (Exception ex) { Msg("Lỗi xóa: " + ex.Message); }
        }

        private void BtnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (!_maMeoDangChon.HasValue) { Msg("Vui lòng chọn mèo!"); return; }

            var meo = _db.Meos.FirstOrDefault(m => m.MÃ_MÈO == _maMeoDangChon.Value);
            if (meo == null) return;

            bool isDeleted = meo.ĐÃ_XÓA;
            string trangThaiXoa = isDeleted ? "Đã xóa" : "Đang hoạt động";

            MessageBox.Show(
                $"Thông tin chi tiết Mèo:\n" +
                $"- Mã Mèo: {_maMeoDangChon.Value}\n" +
                $"- Tên Mèo: {meo.TÊN_MÈO}\n" +
                $"- Giống: {meo.GIỐNG_MÈO}\n" +
                $"- Tình trạng: {meo.TÌNH_TRẠNG}\n" +
                $"- Ngày tiêm phòng: {meo.NGÀY_TIÊM_PHÒNG:dd/MM/yyyy}\n" +
                $"- Ghi chú: {meo.GHI_CHÚ}\n" +
                $"- Trạng thái: {trangThaiXoa}",
                "Xem Chi Tiết Mèo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _btnHuy_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            _txtTen.Clear();
            _txtGiong.Clear();
            _txtGhiChu.Clear();
            if (_cbTinhTrang.Items.Count > 0)
                _cbTinhTrang.SelectedIndex = 0;
            _dtTiemPhong.Value = DateTime.Today;
            _maMeoDangChon = null;
        }

        private void Msg(string msg) => MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void MsgSuccess(string msg) => MessageBox.Show(msg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private DialogResult MsgYesNo(string msg) => MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
}