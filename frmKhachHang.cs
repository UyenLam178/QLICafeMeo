// frmKhachHang.cs 
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace QLICafeMeo
{
    public partial class frmKhachHang : Form
    {
        private DataClasses1DataContext _db;
        private int? _maKHDangChon;

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            _db = new DataClasses1DataContext(Properties.Settings.Default.QLICafeMeoConnectionString);
            LoadData();
        }

        private void LoadData()
        {
            string kw = _txtTimKiem.Text.Trim().ToLower();

            // LINQ: Truy vấn dữ liệu khách hàng
            var query = _db.KhachHangs
                .Where(k => (k.ĐÃ_XÓA == null || k.ĐÃ_XÓA == false) &&
                            (string.IsNullOrEmpty(kw) ||
                             (k.HỌ_TÊN != null && k.HỌ_TÊN.ToLower().Contains(kw)) ||
                             (k.SỐ_ĐIỆN_THOẠI != null && k.SỐ_ĐIỆN_THOẠI.Contains(kw))))
                .OrderBy(k => k.HỌ_TÊN)
                .Select(k => new
                {
                    MaKH = k.MÃ_KHÁCH_HÀNG,
                    HoTen = k.HỌ_TÊN,
                    SDT = k.SỐ_ĐIỆN_THOẠI,
                    DiemTichLuy = k.ĐIỂM_TÍCH_LŨY ?? 0
                });

            _dgv.DataSource = query.ToList();
            FormatDgv();
        }

        private string FormatColumnName(string name)
        {
            // Logic dịch tên cột theo yêu cầu: In hoa chữ cái đầu mỗi từ
            if (name == "MaKH") return "Mã Khách Hàng";
            if (name == "HoTen") return "Họ Và Tên";
            if (name == "SDT") return "Số Điện Thoại";
            if (name == "DiemTichLuy") return "Điểm Tích Lũy";
            return name;
        }

        private void FormatDgv()
        {
            _dgv.EnableHeadersVisualStyles = false;

            // ĐỔI NỀN BẢNG THÀNH TRẮNG TINH 100% VÀ CHỮ ĐEN (HEADER)
            _dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            _dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            _dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            _dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _dgv.ColumnHeadersHeight = 50;

            // TẤT CẢ Ô DỮ LIỆU: TRẮNG TINH 100%
            _dgv.RowsDefaultCellStyle.BackColor = Color.White;
            _dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            // Căn lề TRÁI cho toàn bộ nội dung (Mặc định cho dữ liệu)
            _dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            _dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Đặt tên cột mới, căn giữa tiêu đề, và căn lề trái nội dung
            foreach (DataGridViewColumn col in _dgv.Columns)
            {
                col.HeaderText = FormatColumnName(col.Name);
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa tiêu đề

                // Giữ nguyên thiết lập màu trắng
                col.HeaderCell.Style.BackColor = Color.White;

                // TẤT CẢ CÁC CỘT DỮ LIỆU ĐỀU CĂN LỀ TRÁI (LEFT)
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _dgv.Rows.Count) return;
            var row = _dgv.Rows[e.RowIndex];
            _maKHDangChon = Convert.ToInt32(row.Cells["MaKH"].Value);
            _txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
            _txtSDT.Text = row.Cells["SDT"].Value?.ToString() ?? "";
            _nudDiem.Value = row.Cells["DiemTichLuy"].Value != null ? Convert.ToDecimal(row.Cells["DiemTichLuy"].Value) : 0;
        }

        private void TxtTimKiem_KeyUp(object sender, KeyEventArgs e) => LoadData();

        private void _btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_txtHoTen.Text)) { Msg("Vui lòng nhập họ tên!"); return; }
            if (!System.Text.RegularExpressions.Regex.IsMatch(_txtSDT.Text, @"^0[3|5|7|8|9]\d{8}$")) { Msg("Số điện thoại không hợp lệ!"); return; }
            if (IsSDTExists(_txtSDT.Text)) { Msg("Số điện thoại đã tồn tại!"); return; }

            var kh = new KhachHang
            {
                HỌ_TÊN = _txtHoTen.Text.Trim(),
                SỐ_ĐIỆN_THOẠI = _txtSDT.Text,
                ĐIỂM_TÍCH_LŨY = (int)_nudDiem.Value,
                ĐÃ_XÓA = false
            };

            _db.KhachHangs.InsertOnSubmit(kh);
            _db.SubmitChanges();
            LoadData(); Clear();
            MsgSuccess("Thêm khách hàng thành công!");
        }

        private void _btnSua_Click(object sender, EventArgs e)
        {
            if (!_maKHDangChon.HasValue) { Msg("Vui lòng chọn khách hàng!"); return; }
            if (string.IsNullOrWhiteSpace(_txtHoTen.Text)) { Msg("Vui lòng nhập họ tên!"); return; }
            if (!System.Text.RegularExpressions.Regex.IsMatch(_txtSDT.Text, @"^0[3|5|7|8|9]\d{8}$")) { Msg("Số điện thoại không hợp lệ!"); return; }
            if (IsSDTExists(_txtSDT.Text, _maKHDangChon)) { Msg("Số điện thoại đã được dùng!"); return; }

            var kh = _db.KhachHangs.FirstOrDefault(k => k.MÃ_KHÁCH_HÀNG == _maKHDangChon.Value);
            if (kh != null)
            {
                kh.HỌ_TÊN = _txtHoTen.Text.Trim();
                kh.SỐ_ĐIỆN_THOẠI = _txtSDT.Text;
                kh.ĐIỂM_TÍCH_LŨY = (int)_nudDiem.Value;
                _db.SubmitChanges();
                LoadData(); Clear();
                MsgSuccess("Sửa thành công!");
            }
        }

        private void _btnXoa_Click(object sender, EventArgs e)
        {
            if (!_maKHDangChon.HasValue) { Msg("Vui lòng chọn khách hàng!"); return; }
            if (MsgYesNo("Xóa khách hàng này?") != DialogResult.Yes) return;

            var kh = _db.KhachHangs.FirstOrDefault(k => k.MÃ_KHÁCH_HÀNG == _maKHDangChon.Value);
            if (kh != null)
            {
                kh.ĐÃ_XÓA = true; // Soft Delete
                _db.SubmitChanges();
                LoadData(); Clear();
                MsgSuccess("Đã xóa khách hàng!");
            }
        }

        private void BtnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (!_maKHDangChon.HasValue) { Msg("Vui lòng chọn khách hàng!"); return; }

            var kh = _db.KhachHangs.FirstOrDefault(k => k.MÃ_KHÁCH_HÀNG == _maKHDangChon.Value);
            if (kh == null) return;

          
            string trangThaiXoa = kh.ĐÃ_XÓA ? "Đã xóa" : "Đang hoạt động";

            MessageBox.Show(
                $"Thông tin chi tiết Khách Hàng:\n" +
                $"- Mã KH: {_maKHDangChon.Value}\n" +
                $"- Họ Tên: {kh.HỌ_TÊN}\n" +
                $"- SĐT: {kh.SỐ_ĐIỆN_THOẠI}\n" +
                $"- Điểm Tích Lũy: {kh.ĐIỂM_TÍCH_LŨY}\n" +
                $"- Trạng thái: {trangThaiXoa}",
                "Xem Chi Tiết Khách Hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool IsSDTExists(string sdt, int? exclude = null)
        {
            var q = _db.KhachHangs.Where(k => k.SỐ_ĐIỆN_THOẠI == sdt && (k.ĐÃ_XÓA == null || k.ĐÃ_XÓA == false));
            if (exclude.HasValue) q = q.Where(k => k.MÃ_KHÁCH_HÀNG != exclude.Value);
            return q.Any();
        }

        private void Clear()
        {
            _txtHoTen.Clear(); _txtSDT.Clear(); _nudDiem.Value = 0; _maKHDangChon = null;
        }

        private void Msg(string m) => MessageBox.Show(m, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void MsgSuccess(string m) => MessageBox.Show(m, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private DialogResult MsgYesNo(string m) => MessageBox.Show(m, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
}