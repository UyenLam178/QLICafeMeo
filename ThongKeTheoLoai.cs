// frmThongKeTheoLoai.cs 
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QLICafeMeo
{
    public partial class frmThongKeTheoLoai : Form
    {
        private DataClasses1DataContext _db;
        private readonly string _currentUserRole;

        public frmThongKeTheoLoai() : this("Admin") { }

        public frmThongKeTheoLoai(string role)
        {
            InitializeComponent();
            _currentUserRole = role;

            this.dgvThongKe.ColumnHeadersDefaultCellStyle.Font = new Font(
                this.dgvThongKe.Font.FontFamily,
                this.dgvThongKe.Font.Size,
                FontStyle.Bold
            );
            this.dgvThongKe.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            _db = new DataClasses1DataContext(Properties.Settings.Default.QLICafeMeoConnectionString);
            this.Load += (s, e) => { ApplyPermissions(); LoadDataKhachHangAndChart(); };
        }

        private void ApplyPermissions()
        {
            bool canView = _currentUserRole == "Admin" || _currentUserRole == "ThuQuy";
            if (!canView)
            {
                MessageBox.Show("Bạn không có quyền xem thống kê này!", "Lỗi Phân Quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new MethodInvoker(this.Close));
            }
        }

        private void LoadDataKhachHangAndChart()
        {
            // 1. Cập nhật tiêu đề
            this.Text = "Thống kê Top 10 Khách Hàng";
            this.lblTitle.Text = "TOP 10 KHÁCH HÀNG CHI TIÊU NHIỀU NHẤT VÀ BIỂU ĐỒ";

            // 2. Truy vấn LINQ: TOP 10 Khách Hàng chi tiêu nhiều nhất
            var data = _db.HoaDons
                .Where(h => h.MÃ_KHÁCH_HÀNG != null)
                .GroupBy(h => h.KhachHang)
                .Select(g => new
                {
                    KhachHang = g.Key.HỌ_TÊN,
                    TongChiTieu = g.Sum(h => h.TỔNG_TIỀN ?? 0)
                })
                .OrderByDescending(x => x.TongChiTieu)
                .Take(10)
                .ToList();

            // 3. Hiển thị dữ liệu lên DataGridView (Phần bên phải)
            var dgvData = data.Select(x => new
            {
                x.KhachHang,
                TongChiTieu = x.TongChiTieu
            });

            dgvThongKe.DataSource = dgvData.ToList();

            if (dgvThongKe.Columns.Contains("KhachHang"))
            {
                dgvThongKe.Columns["KhachHang"].HeaderText = "Khách Hàng";
                dgvThongKe.Columns["KhachHang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvThongKe.Columns.Contains("TongChiTieu"))
            {
                dgvThongKe.Columns["TongChiTieu"].HeaderText = "Tổng Chi Tiêu";
                dgvThongKe.Columns["TongChiTieu"].DefaultCellStyle.Format = "N0";
                dgvThongKe.Columns["TongChiTieu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // 4. VẼ CHART 

            chartThongKe.Series.Clear();
            chartThongKe.Titles.Clear();

            Series series = new Series("TongTien")
            {
                ChartType = SeriesChartType.Bar, 
                IsValueShownAsLabel = true,
                Color = Color.FromArgb(70, 130, 180),
                Font = new Font("Segoe UI", 8F, FontStyle.Bold)
            };

            foreach (var item in data)
            {
                int index = series.Points.AddXY(item.KhachHang, (double)item.TongChiTieu); 
                series.Points[index].Label = item.TongChiTieu.ToString("N0"); 
            }

            chartThongKe.ChartAreas[0].AxisX.Interval = 1;
            chartThongKe.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
            chartThongKe.ChartAreas[0].AxisX.Title = "Khách Hàng";
            chartThongKe.ChartAreas[0].AxisY.Title = "Tổng Tiền Chi Tiêu";

            chartThongKe.Series.Add(series);
            chartThongKe.Titles.Add("Tổng Chi Tiêu (TOP 10 Khách Hàng)");
            chartThongKe.Titles[0].Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            chartThongKe.Titles[0].ForeColor = Color.DarkRed;

            chartThongKe.Visible = true;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _db?.Dispose();
            base.OnFormClosed(e);
        }
    }
}