// DonHang.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace QLICafeMeo.Forms
{
    public partial class DonHang : Form
    {
        private DataTable _gioHang = new DataTable();
        private readonly DataClasses1DataContext _db;

        public DonHang()
        {
            _db = new DataClasses1DataContext(Properties.Settings.Default.QLICafeMeoConnectionString);
            InitializeComponent();
            Load += (s, e) => {
                InitGioHang();
                LoadMon();
                LoadKhachHang();
                FormatDGVMon(); 
                FormatDGVGioHang(); 
            };
        }

        private void InitGioHang()
        {
            _gioHang.Columns.Add("MaMon", typeof(int));
            _gioHang.Columns.Add("TenMon", typeof(string));
            _gioHang.Columns.Add("Gia", typeof(decimal));
            _gioHang.Columns.Add("SoLuong", typeof(int));
            _gioHang.Columns.Add("ThanhTien", typeof(decimal));

            var colXoa = new DataGridViewButtonColumn
            {
                Name = "Xoa",
                HeaderText = "Xóa",
                Text = "XÓA",
                UseColumnTextForButtonValue = true
            };
            _dgvGioHang.Columns.Add(colXoa);
            _dgvGioHang.DataSource = _gioHang;
        }

        private void LoadMon()
        {
            var query = from m in _db.Mons
                        where m.NGỪNG_KINH_DOANH == false
                        orderby m.LOẠI, m.TÊN_MÓN
                        select new { m.MÃ_MÓN, m.TÊN_MÓN, m.GIÁ, Loai = m.LOẠI ?? "" };
            _dgvMon.DataSource = query.ToList();

 
            _dgvMon.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _dgvMon.ColumnHeadersDefaultCellStyle.Font = new Font(_dgvMon.Font, FontStyle.Bold);
        }

        private void LoadKhachHang()
        {
            var khach = _db.KhachHangs
                .OrderBy(k => k.HỌ_TÊN)
                .Select(k => new { k.MÃ_KHÁCH_HÀNG, k.HỌ_TÊN })
                .ToList();

            var dt = khach.ToDataTable();
            var row = dt.NewRow();

            row["MÃ_KHÁCH_HÀNG"] = DBNull.Value;
            row["HỌ_TÊN"] = "Khách vãng lai";
            dt.Rows.InsertAt(row, 0);

            _cbKhachHang.DataSource = dt;
            _cbKhachHang.DisplayMember = "HỌ_TÊN";
            _cbKhachHang.ValueMember = "MÃ_KHÁCH_HÀNG";
        }

        private void FormatDGVMon()
        {
            if (_dgvMon.Columns.Count == 0) return;

            foreach (DataGridViewColumn col in _dgvMon.Columns)
            {
                string colName = col.Name;

                // 1. Đặt tên cột (In hoa chữ cái đầu)
                string headerText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(colName.Replace('_', ' ').ToLower());

                // Sử dụng tên cột chuẩn theo yêu cầu: Mã Món, Tên Món, Giá, Loại
                if (colName.Equals("MÃ_MÓN", StringComparison.OrdinalIgnoreCase)) headerText = "Mã Món";
                else if (colName.Equals("TÊN_MÓN", StringComparison.OrdinalIgnoreCase)) headerText = "Tên Món";
                else if (colName.Equals("GIÁ", StringComparison.OrdinalIgnoreCase)) headerText = "Giá";
                else if (colName.Equals("LOAI", StringComparison.OrdinalIgnoreCase)) headerText = "Loại";

                col.HeaderText = headerText;

                // 2. Định dạng căn chỉnh
                if (colName.Equals("MÃ_MÓN", StringComparison.OrdinalIgnoreCase))
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa Mã Món
                    col.FillWeight = 80; // Tối ưu độ rộng
                }
                else if (colName.Equals("GIÁ", StringComparison.OrdinalIgnoreCase))
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Căn phải Giá
                    col.DefaultCellStyle.Format = "N0"; // Định dạng tiền tệ 15.000
                    col.FillWeight = 100;
                }
                else
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }
        }

        private void FormatDGVGioHang()
        {
            if (_dgvGioHang.Columns.Count == 0) return;

            // THIẾT LẬP HEADER STYLE
            _dgvGioHang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _dgvGioHang.ColumnHeadersDefaultCellStyle.Font = new Font(_dgvGioHang.Font, FontStyle.Bold);

            foreach (DataGridViewColumn col in _dgvGioHang.Columns)
            {
                string colName = col.Name;
                string headerText = colName;

                // 1. Đặt tên cột (In hoa chữ cái đầu)

                if (colName.Equals("Xoa", StringComparison.OrdinalIgnoreCase)) headerText = "Xóa";
                else if (colName.Equals("MaMon", StringComparison.OrdinalIgnoreCase)) headerText = "Mã Món";
                else if (colName.Equals("TenMon", StringComparison.OrdinalIgnoreCase)) headerText = "Tên Món";
                else if (colName.Equals("Gia", StringComparison.OrdinalIgnoreCase)) headerText = "Giá";
                else if (colName.Equals("SoLuong", StringComparison.OrdinalIgnoreCase)) headerText = "Số Lượng";
                else if (colName.Equals("ThanhTien", StringComparison.OrdinalIgnoreCase)) headerText = "Thành Tiền";

                col.HeaderText = headerText;

                // 2. Định dạng căn chỉnh và tiền tệ
                if (colName.Equals("MaMon", StringComparison.OrdinalIgnoreCase) ||
                    colName.Equals("SoLuong", StringComparison.OrdinalIgnoreCase))
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa ID và SL
                    col.FillWeight = 80; // Tối ưu độ rộng
                }
                else if (colName.Equals("Gia", StringComparison.OrdinalIgnoreCase) ||
                         colName.Equals("ThanhTien", StringComparison.OrdinalIgnoreCase))
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Căn phải Tiền tệ
                    col.DefaultCellStyle.Format = "N0"; // Định dạng tiền tệ 15.000
                    col.FillWeight = 100;
                }
                else if (colName.Equals("Xoa", StringComparison.OrdinalIgnoreCase))
                {
                    col.FillWeight = 60; // Tối ưu độ rộng nút Xóa
                }
                else
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }
        }


        private void DgvMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = _dgvMon.Rows[e.RowIndex];

            // Sử dụng tên cột chính xác từ LINQ query
            int maMonM = (int)row.Cells["MÃ_MÓN"].Value;
            string tenMonM = row.Cells["TÊN_MÓN"].Value.ToString();
            decimal giaM = (decimal)row.Cells["GIÁ"].Value;

            using (var f = new Form
            {
                Text = $"Chọn số lượng: {tenMonM}",
                Size = new Size(300, 150),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            })
            {
                var lbl = new Label { Text = "Số lượng:", Location = new Point(50, 25), AutoSize = true };
                var nud = new NumericUpDown { Minimum = 1, Maximum = 99, Value = 1, Location = new Point(120, 23), Width = 100 };
                var btnOK = new Button
                {
                    Text = "THÊM",
                    DialogResult = DialogResult.OK,
                    Location = new Point(100, 70),
                    Size = new Size(80, 35),
                    BackColor = Color.FromArgb(0, 123, 255),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                f.Controls.AddRange(new Control[] { lbl, nud, btnOK });
                f.AcceptButton = btnOK;
                if (f.ShowDialog() == DialogResult.OK)
                    ThemVaoGioHang(maMonM, tenMonM, giaM, (int)nud.Value);
            }
        }

        private void ThemVaoGioHang(int maMon, string tenMon, decimal gia, int soLuong)
        {
            var exist = _gioHang.Select($"MaMon = {maMon}");
            if (exist.Length > 0)
            {
                exist[0]["SoLuong"] = (int)exist[0]["SoLuong"] + soLuong;
                exist[0]["ThanhTien"] = (int)exist[0]["SoLuong"] * gia;
            }
            else
            {
                _gioHang.Rows.Add(maMon, tenMon, gia, soLuong, gia * soLuong);
            }
            CapNhatTongTien();
        }

        private void DgvGioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == _dgvGioHang.Columns["Xoa"].Index)
            {
                if (MessageBox.Show("Xóa món khỏi giỏ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _gioHang.Rows.RemoveAt(e.RowIndex);
                    CapNhatTongTien();
                }
            }
        }

        private void CapNhatTongTien()
        {
            decimal tong = _gioHang.AsEnumerable().Sum(r => r.Field<decimal>("ThanhTien"));
            // Định dạng tổng tiền thành N0 (100,000)
            _txtTongTien.Text = tong.ToString("N0");
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            if (_gioHang.Rows.Count == 0)
            {
                Msg("Chưa chọn món nào!");
                return;
            }

            object maKH = _cbKhachHang.SelectedValue;
            bool isVangLai = maKH == DBNull.Value || maKH == null;

            if (isVangLai && MsgYesNo("Khách vãng lai – Không tích điểm?\nTiếp tục thanh toán?") == DialogResult.No)
                return;

            try
            {
                var hd = new global::QLICafeMeo.HoaDon
                {
                    MÃ_KHÁCH_HÀNG = isVangLai ? (int?)null : (int)maKH,
                    TỔNG_TIỀN = decimal.Parse(_txtTongTien.Text.Replace(",", "")),
                    NGÀY_LẬP = DateTime.Now
                };
                _db.HoaDons.InsertOnSubmit(hd);
                _db.SubmitChanges();

                foreach (DataRow r in _gioHang.Rows)
                {
                    var ct = new global::QLICafeMeo.ChiTietHoaDon
                    {
                        MÃ_HÓA_ĐƠN = hd.MÃ_HÓA_ĐƠN,
                        MÃ_MÓN = (int)r["MaMon"],
                        SỐ_LƯỢNG = (int)r["SoLuong"],

                    };
               
                    _db.ChiTietHoaDons.InsertOnSubmit(ct);
                }

                if (!isVangLai)
                {
                    int diem = (int)(hd.TỔNG_TIỀN / 10000);
                    var kh = _db.KhachHangs.First(k => k.MÃ_KHÁCH_HÀNG == (int)maKH);
                    kh.ĐIỂM_TÍCH_LŨY += diem;
                    Msg($"Thanh toán thành công!\nHóa đơn: HD{hd.MÃ_HÓA_ĐƠN:000}\nĐiểm tích lũy: +{diem}");
                }
                else
                {
                    Msg($"Thanh toán thành công!\nHóa đơn: HD{hd.MÃ_HÓA_ĐƠN:000}\n(Khách vãng lai – Không tích điểm)");
                }

                _db.SubmitChanges();
                _gioHang.Clear();
                CapNhatTongTien();
            }
            catch (Exception ex)
            {
                Msg("Lỗi thanh toán: " + ex.Message);
            }
        }

        private void BtnInHoaDon_Click(object sender, EventArgs e)
        {
            if (_gioHang.Rows.Count == 0) return;

            var pd = new PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                float y = 20;
                var fBold = new Font("Segoe UI", 16, FontStyle.Bold);
                var fNorm = new Font("Segoe UI", 10);
                var fTotal = new Font("Segoe UI", 14, FontStyle.Bold);

                ev.Graphics.DrawString("QUÁN CÀ PHÊ MÈO", fBold, Brushes.Black, 80, y); y += 40;
                ev.Graphics.DrawString($"Khách: {_cbKhachHang.Text}", fNorm, Brushes.Black, 20, y); y += 25;
                ev.Graphics.DrawString($"Ngày: {DateTime.Now:dd/MM/yyyy HH:mm}", fNorm, Brushes.Black, 20, y); y += 30;
                ev.Graphics.DrawString("-----------------------------------------------", fNorm, Brushes.Black, 20, y); y += 20;

                foreach (DataRow r in _gioHang.Rows)
                {
                    string ten = r["TenMon"].ToString();
                    int sl = (int)r["SoLuong"];
                    decimal tt = (decimal)r["ThanhTien"];
                    ev.Graphics.DrawString($"{ten} x{sl}", fNorm, Brushes.Black, 20, y);
                    ev.Graphics.DrawString($"{tt:N0}đ", fNorm, Brushes.Black, 280, y);
                    y += 20;
                }

                y += 10;
                ev.Graphics.DrawString("===============================================", fNorm, Brushes.Black, 20, y); y += 25;
                ev.Graphics.DrawString($"TỔNG: {_txtTongTien.Text}đ", fTotal, Brushes.Black, 20, y); y += 40;
                ev.Graphics.DrawString("Cảm ơn quý khách!", fNorm, Brushes.Black, 20, y);
            };

            new PrintPreviewDialog { Document = pd }.ShowDialog();
        }

        private void Msg(string msg) =>
            MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private DialogResult MsgYesNo(string msg) =>
            MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }

    public static class Extensions
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> data) where T : class
        {
            var dt = new DataTable();
            var props = typeof(T).GetProperties();
            foreach (var p in props) dt.Columns.Add(p.Name, p.PropertyType);
            foreach (var item in data)
            {
                var row = dt.NewRow();
                foreach (var p in props) row[p.Name] = p.GetValue(item) ?? DBNull.Value;
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}