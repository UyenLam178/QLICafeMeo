using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLICafeMeo.Properties;

namespace QLICafeMeo.Forms
{
    public partial class frmSuKien : Form
    {
        private readonly DataClasses1DataContext _db;
        private int? _maSKDangChon;
        private readonly string _currentUserRole;

        public frmSuKien(string role = "NhanVien")
        {
            _currentUserRole = role;
            // Sử dụng QLICafeMeoConnectionString1 đã được xác định trong Settings.Default
            _db = new DataClasses1DataContext(Settings.Default.QLICafeMeoConnectionString1);
            InitializeComponent();

            // === CẤU HÌNH CONTROLS ===
            _cbLoaiApDung.Items.AddRange(new object[] { "Món", "Khách hàng", "Tất cả" });
            _cbLoaiApDung.DropDownStyle = ComboBoxStyle.DropDownList;

            // Cấu hình cho controls
            _txtMaSK.ReadOnly = true; // Mã sự kiện vẫn ReadOnly
            if (_cbLoaiGiam.Items.Count > 0) _cbLoaiGiam.SelectedIndex = 0;
            if (_cbTrangThai.Items.Count > 0) _cbTrangThai.SelectedIndex = 0;

            // === SỰ KIỆN ===
            this.Load += (s, e) =>
            {
                LoadData();
                ApplyPermissions();
                if (_cbLoaiApDung.Items.Count > 0) _cbLoaiApDung.SelectedIndex = 0;
            };

            _nudGiamGia.Minimum = 1;
            _nudGiamGia.Maximum = 10000000;
            _nudGiamGia.DecimalPlaces = 0;

            _cbLoaiApDung.SelectedIndexChanged += CbLoaiApDung_SelectedIndexChanged;
            _chkApDungTatCa.CheckedChanged += ChkApDungTatCa_CheckedChanged;
            _dgv.SelectionChanged += Dgv_SelectionChanged;
            _nudGiamGia.ValueChanged += NudGiamGia_ValueChanged;
            _btnThem.Click += BtnThem_Click;
            _btnSua.Click += BtnSua_Click;
            _btnXoa.Click += BtnXoa_Click;
            _btnHuy.Click += BtnHuy_Click;
        }

        // === CẬP NHẬT LOẠI GIẢM (SỬ DỤNG COMBOBOX) ===
        private void NudGiamGia_ValueChanged(object sender, EventArgs e) => UpdateLoaiGiamComboBox();
        private void UpdateLoaiGiamComboBox()
        {
            decimal giaTri = _nudGiamGia.Value;

            if (giaTri != 0)
            {
                // Giá trị <= 100 được coi là "Phần trăm", giá trị lớn hơn 100 là "Tiền mặt"
                string loaiGiam = (giaTri <= 100 && _nudGiamGia.DecimalPlaces == 0) ? "Phần trăm" : "Tiền mặt";
                _cbLoaiGiam.Text = loaiGiam;
            }
            else
            {
                _cbLoaiGiam.Text = "Phần trăm";
            }
        }

        // === PHÂN QUYỀN ===
        private void ApplyPermissions()
        {
            bool isAdmin = _currentUserRole == "Admin";
            bool canEdit = isAdmin || _currentUserRole == "QuanLy";

            _btnThem.Visible = isAdmin;
            _btnSua.Visible = canEdit;
            _btnXoa.Visible = isAdmin;
        }

        private void LoadData()
        {
            try
            {
                // Lấy dữ liệu cơ bản từ DB
                var baseQuery = _db.SuKiens
                    .Where(sk => sk.DA_XOA != true)
                    .Select(sk => new
                    {
                        sk.MA_SUKIEN,
                        sk.TEN_SUKIEN,
                        sk.LOAI_KHUYENMAI,
                        sk.MA_MON,
                        sk.MA_KHACH_HANG,
                        sk.GIA_TRI_GIAM,
                        sk.LOAI_GIAM,
                        sk.NGAY_BATDAU,
                        sk.NGAY_KETTHUC,
                        sk.TRANG_THAI
                    })
                    .OrderByDescending(sk => sk.NGAY_BATDAU)
                    .ToList();

                // Xử lý tên món & khách hàng trong bộ nhớ
                var data = baseQuery.Select(sk => new
                {
                    MaSK = sk.MA_SUKIEN,
                    TenSK = sk.TEN_SUKIEN,
                    LoaiApDung = sk.LOAI_KHUYENMAI,
                    DoiTuong = sk.LOAI_KHUYENMAI == "Món"
                        ? (sk.MA_MON.HasValue
                            ? _db.Mons.FirstOrDefault(m => m.MÃ_MÓN == sk.MA_MON)?.TÊN_MÓN ?? "Không xác định"
                            : "Tất cả món")
                        : sk.LOAI_KHUYENMAI == "Khách hàng"
                            ? (sk.MA_KHACH_HANG.HasValue
                                ? _db.KhachHangs.FirstOrDefault(k => k.MÃ_KHÁCH_HÀNG == sk.MA_KHACH_HANG)?.HỌ_TÊN ?? "Không xác định"
                                : "Tất cả khách")
                            : "Tất cả",
                    GiamGia = sk.GIA_TRI_GIAM,
                    LoaiGiam = sk.LOAI_GIAM,
                    NgayBD = sk.NGAY_BATDAU,
                    NgayKT = sk.NGAY_KETTHUC,
                    TrangThai = sk.TRANG_THAI ?? "Hoạt động"
                }).ToList();

                _dgv.DataSource = data;
                FormatDgv();
                Clear();
            }
            catch (Exception ex)
            {
                Msg($"Lỗi tải dữ liệu sự kiện: {ex.Message}");
            }
        }

        private void FormatDgv()
        {
            if (_dgv.Columns.Count == 0) return;

            _dgv.Columns["MaSK"].HeaderText = "Mã SK";
            _dgv.Columns["TenSK"].HeaderText = "Tên Sự Kiện";
            _dgv.Columns["LoaiApDung"].HeaderText = "Áp Dụng Cho";
            _dgv.Columns["DoiTuong"].HeaderText = "Đối Tượng Cụ Thể";
            _dgv.Columns["GiamGia"].HeaderText = "Giá Trị";
            _dgv.Columns["LoaiGiam"].HeaderText = "Loại Giảm";
            _dgv.Columns["NgayBD"].HeaderText = "Từ Ngày";
            _dgv.Columns["NgayKT"].HeaderText = "Đến Ngày";
            _dgv.Columns["TrangThai"].HeaderText = "Trạng Thái";

            _dgv.Columns["MaSK"].Width = 60;
            _dgv.Columns["GiamGia"].Width = 80;
            _dgv.Columns["TenSK"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var centerCols = new[] { "GiamGia", "NgayBD", "NgayKT", "LoaiApDung", "LoaiGiam", "TrangThai" };
            foreach (var col in centerCols)
                if (_dgv.Columns[col] != null)
                    _dgv.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            _dgv.Columns["NgayBD"].DefaultCellStyle.Format = "dd/MM/yyyy";
            _dgv.Columns["NgayKT"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        // === LOAD ĐỐI TƯỢNG ===
        private void LoadDoiTuong(string loai)
        {
            _cbDoiTuong.DataSource = null;
            _cbDoiTuong.Items.Clear();

            if (loai == "Món")
            {
                var data = _db.Mons
                    .Where(m => m.NGỪNG_KINH_DOANH == false)
                    .Select(m => new { ID = m.MÃ_MÓN, Ten = m.TÊN_MÓN })
                    .ToList();
                _cbDoiTuong.DataSource = data;
                _cbDoiTuong.DisplayMember = "Ten";
                _cbDoiTuong.ValueMember = "ID";
            }
            else if (loai == "Khách hàng")
            {
                var data = _db.KhachHangs
                    .Where(k => k.ĐÃ_XÓA == false)
                    .Select(k => new { ID = k.MÃ_KHÁCH_HÀNG, Ten = k.HỌ_TÊN })
                    .ToList();
                _cbDoiTuong.DataSource = data;
                _cbDoiTuong.DisplayMember = "Ten";
                _cbDoiTuong.ValueMember = "ID";
            }

            if (loai == "Tất cả")
            {
                _chkApDungTatCa.Checked = true;
                _cbDoiTuong.Enabled = false;
                _chkApDungTatCa.Enabled = false;
            }
            else
            {
                _chkApDungTatCa.Enabled = true;
                _cbDoiTuong.Enabled = !_chkApDungTatCa.Checked;
            }

            if (_cbDoiTuong.Items.Count == 0 && loai != "Tất cả")
            {
                // Không gán text nếu dùng DataSource, chỉ gán khi không có dữ liệu
                if (_cbDoiTuong.DataSource == null)
                {
                    _cbDoiTuong.Text = $"Không có {loai} nào hoạt động";
                }
            }
        }

        private void CbLoaiApDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loai = _cbLoaiApDung.Text;
            LoadDoiTuong(loai);
            UpdateLoaiGiamComboBox();
        }

        private void ChkApDungTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbLoaiApDung.Text == "Tất cả")
            {
                _cbDoiTuong.Enabled = false;
                _chkApDungTatCa.Checked = true;
                return;
            }

            _cbDoiTuong.Enabled = !_chkApDungTatCa.Checked;

            if (_chkApDungTatCa.Checked)
            {
                _cbDoiTuong.Text = $"Áp dụng cho tất cả {_cbLoaiApDung.Text}";
            }
            else
            {
                // Load lại danh sách đối tượng khi bỏ chọn "Áp dụng tất cả"
                LoadDoiTuong(_cbLoaiApDung.Text);
            }
        }

        // === CHỌN DÒNG TRONG DGV ===
        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            // Thêm kiểm tra Null Reference để tránh lỗi khi DGV bị refresh
            if (_dgv.CurrentRow == null || _dgv.CurrentRow.DataBoundItem == null || _dgv.CurrentRow.Cells["MaSK"].Value == null)
            {
                Clear(false); // Clear nhưng không clear selection
                return;
            }

            var row = _dgv.CurrentRow;
            // Đảm bảo MaSK là số nguyên và không null
            if (row.Cells["MaSK"].Value is int maSK)
            {
                _maSKDangChon = maSK;
                _txtMaSK.Text = _maSKDangChon.ToString(); // GÁN VÀO TEXTBOX READONLY
            }
            else
            {
                Clear(false);
                return;
            }

            _txtTenSK.Text = row.Cells["TenSK"].Value?.ToString() ?? "";

            // Xử lý giá trị giảm (có thể là decimal hoặc int)
            if (row.Cells["GiamGia"].Value is decimal giamGia)
            {
                _nudGiamGia.Value = giamGia;
            }
            else if (row.Cells["GiamGia"].Value is int giamGiaInt)
            {
                _nudGiamGia.Value = giamGiaInt;
            }

            _cbLoaiGiam.Text = row.Cells["LoaiGiam"].Value?.ToString() ?? "Phần trăm";
            _cbTrangThai.Text = row.Cells["TrangThai"].Value?.ToString() ?? "Hoạt động";

            if (row.Cells["NgayBD"].Value is DateTime bd) _dtNgayBD.Value = bd;
            if (row.Cells["NgayKT"].Value is DateTime kt) _dtNgayKT.Value = kt;

            string loaiApDung = row.Cells["LoaiApDung"].Value?.ToString() ?? "";
            string doiTuong = row.Cells["DoiTuong"].Value?.ToString() ?? "";

            // Cập nhật ComboBox Loại Áp Dụng
            _cbLoaiApDung.Text = loaiApDung;

            // Xử lý Đối Tượng Cụ Thể và CheckBox
            if (doiTuong.StartsWith("Tất cả")) // Bao gồm "Tất cả", "Tất cả món", "Tất cả khách"
            {
                _chkApDungTatCa.Checked = true;
                _cbDoiTuong.Enabled = false;
                _cbDoiTuong.Text = doiTuong;
            }
            else
            {
                _chkApDungTatCa.Checked = false;
                _cbDoiTuong.Enabled = true;

                // Load lại danh sách và chọn đối tượng cụ thể
                LoadDoiTuong(loaiApDung);
                _cbDoiTuong.Text = doiTuong;
            }
        }

        // Sửa Dgv_CellClick để đảm bảo Dgv_SelectionChanged được kích hoạt
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // === BỔ SUNG LOGIC ĐỂ ĐẢM BẢO CURRENT ROW ĐƯỢC CẬP NHẬT TẠI CHỖ CLICK ===
                if (_dgv.CurrentRow == null || _dgv.CurrentRow.Index != e.RowIndex)
                {
                    // Đặt lại CurrentCell và Selected để kích hoạt SelectionChanged một cách chính xác
                    _dgv.Rows[e.RowIndex].Selected = true;
                    _dgv.CurrentCell = _dgv.Rows[e.RowIndex].Cells[0];
                }
                // Nếu SelectionChanged không tự động chạy sau CurrentCell, gọi thủ công
                Dgv_SelectionChanged(sender, EventArgs.Empty);
                // ======================================================================
            }
        }


        // === KIỂM TRA TRÙNG TÊN ===
        private bool IsTenSKExists(string ten, int? excludeMaSK = null)
        {
            var q = _db.SuKiens.Where(sk => sk.TEN_SUKIEN == ten.Trim() && sk.DA_XOA != true);
            if (excludeMaSK.HasValue) q = q.Where(sk => sk.MA_SUKIEN != excludeMaSK.Value);
            return q.Any();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(_txtTenSK.Text))
            {
                Msg("Vui lòng nhập tên sự kiện!");
                return false;
            }
            if (IsTenSKExists(_txtTenSK.Text.Trim(), _maSKDangChon))
            {
                Msg("Tên sự kiện đã tồn tại!");
                return false;
            }
            if (_cbLoaiApDung.SelectedIndex == -1)
            {
                Msg("Vui lòng chọn loại áp dụng!");
                return false;
            }
            if (_nudGiamGia.Value <= 0)
            {
                Msg("Giá trị giảm phải lớn hơn 0!");
                return false;
            }
            if (_dtNgayBD.Value.Date > _dtNgayKT.Value.Date)
            {
                Msg("Ngày bắt đầu không được sau ngày kết thúc!");
                return false;
            }

            if (!_chkApDungTatCa.Checked &&
                (_cbLoaiApDung.Text == "Món" || _cbLoaiApDung.Text == "Khách hàng") &&
                _cbDoiTuong.SelectedValue == null)
            {
                Msg($"Vui lòng chọn đối tượng cụ thể cho {_cbLoaiApDung.Text}!");
                return false;
            }

            return true;
        }

        // === THÊM ===
        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                UpdateLoaiGiamComboBox();
                string loaiGiam = _cbLoaiGiam.Text;
                string loaiApDung = _cbLoaiApDung.Text;

                var sk = new SuKien
                {
                    TEN_SUKIEN = _txtTenSK.Text.Trim(),
                    LOAI_KHUYENMAI = loaiApDung,
                    GIA_TRI_GIAM = _nudGiamGia.Value,
                    LOAI_GIAM = loaiGiam,
                    NGAY_BATDAU = _dtNgayBD.Value.Date,
                    NGAY_KETTHUC = _dtNgayKT.Value.Date,
                    TRANG_THAI = _cbTrangThai.Text,
                    DA_XOA = false
                };

                if (loaiApDung == "Món" && !_chkApDungTatCa.Checked)
                    sk.MA_MON = (int?)_cbDoiTuong.SelectedValue;
                else if (loaiApDung == "Khách hàng" && !_chkApDungTatCa.Checked)
                    sk.MA_KHACH_HANG = (int?)_cbDoiTuong.SelectedValue;
                else if (loaiApDung == "Tất cả" || _chkApDungTatCa.Checked)
                {
                    sk.MA_MON = null;
                    sk.MA_KHACH_HANG = null;
                }

                _db.SuKiens.InsertOnSubmit(sk);
                _db.SubmitChanges();

                // HIỂN THỊ MÃ SK TỰ ĐỘNG TĂNG SAU KHI INSERT
                _txtMaSK.Text = sk.MA_SUKIEN.ToString();

                MsgSuccess("Thêm sự kiện thành công!");
                LoadData();

                // === BỔ SUNG: CHỌN DÒNG VỪA THÊM SAU KHI LOAD DATA ===
                // Tìm dòng vừa thêm trong DGV (dựa vào Mã SK vừa tạo)
                var newRow = _dgv.Rows.Cast<DataGridViewRow>()
                    .FirstOrDefault(r => r.Cells["MaSK"].Value != null && (int)r.Cells["MaSK"].Value == sk.MA_SUKIEN);

                if (newRow != null)
                {
                    _dgv.ClearSelection();
                    newRow.Selected = true;
                    _dgv.CurrentCell = newRow.Cells[0];
                    Dgv_SelectionChanged(sender, EventArgs.Empty); // Buộc cập nhật form chi tiết
                }
            }
            catch (Exception ex)
            {
                Msg("Lỗi thêm: " + ex.Message);
            }
        }

        // === SỬA ===
        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (!_maSKDangChon.HasValue)
            {
                Msg("Vui lòng chọn sự kiện để sửa!");
                return;
            }
            if (!ValidateInput()) return;

            try
            {
                var sk = _db.SuKiens.FirstOrDefault(s => s.MA_SUKIEN == _maSKDangChon.Value);
                if (sk == null) return;

                UpdateLoaiGiamComboBox();
                string loaiApDung = _cbLoaiApDung.Text;

                sk.TEN_SUKIEN = _txtTenSK.Text.Trim();
                sk.LOAI_KHUYENMAI = loaiApDung;
                sk.GIA_TRI_GIAM = _nudGiamGia.Value;
                sk.LOAI_GIAM = _cbLoaiGiam.Text;
                sk.NGAY_BATDAU = _dtNgayBD.Value.Date;
                sk.NGAY_KETTHUC = _dtNgayKT.Value.Date;
                sk.TRANG_THAI = _cbTrangThai.Text;

                sk.MA_MON = null;
                sk.MA_KHACH_HANG = null;

                if (loaiApDung == "Món" && !_chkApDungTatCa.Checked)
                    sk.MA_MON = (int?)_cbDoiTuong.SelectedValue;
                else if (loaiApDung == "Khách hàng" && !_chkApDungTatCa.Checked)
                    sk.MA_KHACH_HANG = (int?)_cbDoiTuong.SelectedValue;

                else if (loaiApDung == "Tất cả" || _chkApDungTatCa.Checked)
                {
                    sk.MA_MON = null;
                    sk.MA_KHACH_HANG = null;
                }


                _db.SubmitChanges();
                MsgSuccess("Sửa sự kiện thành công!");
                LoadData();

                // === BỔ SUNG: CHỌN DÒNG VỪA SỬA SAU KHI LOAD DATA ===
                var updatedRow = _dgv.Rows.Cast<DataGridViewRow>()
                    .FirstOrDefault(r => r.Cells["MaSK"].Value != null && (int)r.Cells["MaSK"].Value == _maSKDangChon.Value);

                if (updatedRow != null)
                {
                    _dgv.ClearSelection();
                    updatedRow.Selected = true;
                    _dgv.CurrentCell = updatedRow.Cells[0];
                    Dgv_SelectionChanged(sender, EventArgs.Empty); // Buộc cập nhật form chi tiết
                }
            }
            catch (Exception ex)
            {
                Msg("Lỗi sửa: " + ex.Message);
            }
        }

        // === XÓA (SOFT DELETE) ===
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (!_maSKDangChon.HasValue)
            {
                Msg("Vui lòng chọn sự kiện để xóa!");
                return;
            }

            if (MsgYesNo("Chuyển sự kiện này sang trạng thái đã xóa?") != DialogResult.Yes)
                return;

            try
            {
                var sk = _db.SuKiens.FirstOrDefault(s => s.MA_SUKIEN == _maSKDangChon.Value);
                if (sk != null)
                {
                    sk.DA_XOA = true;
                    sk.TRANG_THAI = "Đã xóa";
                    _db.SubmitChanges();
                    MsgSuccess("Đã chuyển sang trạng thái đã xóa!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                Msg("Lỗi xóa: " + ex.Message);
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e) => Clear();

        private void Clear(bool clearSelection = true)
        {
            _maSKDangChon = null;
            _txtMaSK.Text = "Tự động gán";
            _txtTenSK.Clear();
            _nudGiamGia.Value = 1;
            _dtNgayBD.Value = DateTime.Today;
            _dtNgayKT.Value = DateTime.Today.AddDays(7);
            if (_cbLoaiApDung.Items.Count > 0) _cbLoaiApDung.SelectedIndex = 0;
            _chkApDungTatCa.Checked = true;
            UpdateLoaiGiamComboBox();
            _cbTrangThai.Text = "Hoạt động";
            if (clearSelection)
            {
                _dgv.ClearSelection();
            }
        }

        // === HỘP THOẠI ===
        private void Msg(string msg) => MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void MsgSuccess(string msg) => MessageBox.Show(msg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private DialogResult MsgYesNo(string msg) => MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _db?.Dispose();
            base.OnFormClosed(e);
        }
    }
}