// frmThongKeKhach.cs
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QLICafeMeo
{
    public partial class frmThongKeKhach : Form
    {
        private DataClasses1DataContext _db;
        private readonly string _currentUserRole;

        public frmThongKeKhach() : this("Admin") { }

        public frmThongKeKhach(string role)
        {
            InitializeComponent();
            _currentUserRole = role;

            _db = new DataClasses1DataContext(Properties.Settings.Default.QLICafeMeoConnectionString);

            this.Load += (s, e) => { ApplyPermissions(); LoadReport(); };
        }

        private void ApplyPermissions()
        {
            bool canView = _currentUserRole == "Admin" || _currentUserRole == "ThuQuy";

            if (!canView)
            {
                MessageBox.Show("Bạn không có quyền xem thống kê!",
                    "Lỗi Phân Quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.BeginInvoke(new MethodInvoker(this.Close));
            }
        }

        private void LoadReport()
        {
            try
            {
                var data = _db.HoaDons
                    .Where(h => h.MÃ_KHÁCH_HÀNG != null)
                    .GroupBy(h => h.KhachHang)
                    .Select(g => new
                    {
                        HoTen = g.Key.HỌ_TÊN,
                        TongChiTieu = g.Sum(h => h.TỔNG_TIỀN ?? 0m),
                        SoLanMua = g.Count(),
                        SDT = g.Key.SỐ_ĐIỆN_THOẠI
                    })
                    .OrderByDescending(x => x.TongChiTieu)
                    .Take(10)
                    .ToList();

                if (!data.Any())
                {
                    MessageBox.Show("Không có dữ liệu!", "Thông báo");
                    return;
                }

                var dt = new dsTopKhachHang.TopKhachHangDataTable();
                int stt = 1;

                foreach (var item in data)
                {
                    var row = dt.NewTopKhachHangRow();

                    try
                    {
                        row["MÃ KHÁCH HÀNG"] = stt++;
                        row["HỌ TÊN"] = item.HoTen ?? "Khách lẻ";
                        row["ĐIỂM TÍCH LŨY"] = (int)item.TongChiTieu;
                        row["SỐ ĐIỆN THOẠI"] = $"{item.SDT ?? "N/A"} - {item.SoLanMua} lần";
                    }
                    catch
                    {
                   
                        row.MaKhachHang = stt++;
                        row.HoTen = item.HoTen ?? "Khách lẻ";
                        row.DiemTichLuy = (int)item.TongChiTieu;
                        row.SDT = $"{item.SDT ?? "N/A"} - {item.SoLanMua} lần";
                    }

                    dt.Rows.Add(row);
                }

                reportViewer1.Reset();
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportEmbeddedResource = "QLICafeMeo.BCMeo.rdlc";

                var rds = new ReportDataSource("dsTopKhachHang", (DataTable)dt);
                reportViewer1.LocalReport.DataSources.Add(rds);

                var param = new ReportParameter("TopKhachHang",
                    "DANH SÁCH KHÁCH HÀNG THÂN THIẾT");
                reportViewer1.LocalReport.SetParameters(param);

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi:\n{ex.Message}\n\n{ex.InnerException?.Message}\n\n{ex.StackTrace}",
                    "Lỗi chi tiết", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _db?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
