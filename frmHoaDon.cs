//frmHoaDon.cs
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QLICafeMeo
{
    public partial class frmHoaDon : Form
    {
        private DataClasses1DataContext _db;
        private readonly string _currentUserRole;

        public frmHoaDon() : this("Admin") { }

        public frmHoaDon(string role)
        {
            InitializeComponent();
            _currentUserRole = role;
            _db = new DataClasses1DataContext(Properties.Settings.Default.QLICafeMeoConnectionString);
        }

        private void ApplyPermissions()
        {
            bool canView = _currentUserRole == "Admin" || _currentUserRole == "ThuQuy";
            if (!canView)
            {
                MessageBox.Show("Bạn không có quyền xem thống kê hóa đơn!", "Lỗi Phân Quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new MethodInvoker(this.Close));
            }
        }

        private void LoadReport()
        {
            try
            {
                var data = from c in _db.ChiTietHoaDons
                           join m in _db.Mons on c.MÃ_MÓN equals m.MÃ_MÓN
                           join h in _db.HoaDons on c.MÃ_HÓA_ĐƠN equals h.MÃ_HÓA_ĐƠN
                           orderby h.NGÀY_LẬP descending
                           select new
                           {
                               TenMon = m.TÊN_MÓN,
                               SoLuong = c.SỐ_LƯỢNG ?? 0,
                               Gia = m.GIÁ ?? 0m,
                               ThanhTien = (c.SỐ_LƯỢNG ?? 0) * (m.GIÁ ?? 0m),
                               MaHD = h.MÃ_HÓA_ĐƠN,
                               KhachHang = h.KhachHang.HỌ_TÊN ?? "Khách vãng lai"
                           };

                var list = data.ToList();
                if (!list.Any())
                {
                    MessageBox.Show("Không có dữ liệu chi tiết hóa đơn!");
                    return;
                }

                var dt = new dsChiTietHoaDon.ChiTietHoaDonDataTable();
                foreach (var item in list)
                {
                    var row = dt.NewChiTietHoaDonRow();
                    row.MaHD = item.MaHD;
                    row.TenMon = item.TenMon;
                    row.SoLuong = item.SoLuong;
                    row.DonGia = (int)item.Gia;
                    row.TongTien = (int)item.ThanhTien;
                    row.KhachHang = item.KhachHang;
                    dt.Rows.Add(row);
                }

                reportViewer1.Reset();
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportEmbeddedResource = "QLICafeMeo.dsChiTietHoaDon.rdlc";

                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsChiTietHoaDon", (DataTable)dt));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("BaoCaoChiTiet", "CHI TIẾT TẤT CẢ HÓA ĐƠN"));
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Debug Error");
            }
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            ApplyPermissions();
            LoadReport();
        }
    }
}
