// frmTimKiem.cs
using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using System.Collections.Generic;

namespace QLICafeMeo
{
    public partial class frmTimKiem : Form
    {
        private DataClasses1DataContext _db;

        public frmTimKiem()
        {
            InitializeComponent();

            _db = new DataClasses1DataContext(Properties.Settings.Default.QLICafeMeoConnectionString);

            this.Load += (s, e) => {
                if (cbLoai.Items.Count > 0) cbLoai.SelectedIndex = 0;
                LoadAll();
            };
            this.btnTim.Click += new System.EventHandler(this.BtnTim_Click);
            this.cbLoai.SelectedIndexChanged += (s, e) => {
                txtTuKhoa.Clear(); 
                LoadAll();
            };


            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            string kw = txtTuKhoa.Text.Trim();
            if (string.IsNullOrEmpty(kw)) { LoadAll(); return; }
            string lowerKw = kw.ToLower();
            object data;

            switch (cbLoai.Text)
            {
                case "Món":
                    data = _db.Mons.Where(m => m.TÊN_MÓN.ToLower().Contains(lowerKw)).ToList();
                    break;
                case "Khách hàng":
                    data = _db.KhachHangs.Where(k => k.HỌ_TÊN.ToLower().Contains(lowerKw) || k.SỐ_ĐIỆN_THOẠI.Contains(kw)).ToList();
                    break;
                case "Hóa đơn":
                    data = _db.HoaDons
                        .Where(h => h.MÃ_HÓA_ĐƠN.ToString().Contains(kw))
                        .Select(h => new
                        {
                            h.MÃ_HÓA_ĐƠN,
                            h.NGÀY_LẬP,
                            KhachHang = h.KhachHang != null ? h.KhachHang.HỌ_TÊN : "Vãng lai",
                            h.TỔNG_TIỀN
                        })
                        .ToList();
                    break;
                case "Nhân viên":
                    data = _db.NhanViens.Where(n => n.HỌ_TÊN.ToLower().Contains(lowerKw) || n.SỐ_ĐIỆN_THOẠI.Contains(kw)).ToList();
                    break;
                default:
                    data = _db.Mons.ToList();
                    break;
            }

            dgv.DataSource = data;
            FormatDGV(cbLoai.Text);
        }

        private void LoadAll()
        {
            object data;

            switch (cbLoai.Text)
            {
                case "Món":
                    data = _db.Mons.ToList(); break;
                case "Khách hàng":
                    data = _db.KhachHangs.ToList(); break;
                case "Hóa đơn":
                    data = _db.HoaDons
                        .Select(h => new
                        {
                            h.MÃ_HÓA_ĐƠN,
                            h.NGÀY_LẬP,
                            KhachHang = h.KhachHang != null ? h.KhachHang.HỌ_TÊN : "Vãng lai",
                            h.TỔNG_TIỀN
                        }).ToList(); break;
                case "Nhân viên":
                    data = _db.NhanViens.ToList(); break;
                default:
                    data = _db.Mons.ToList(); break;
            }

            dgv.DataSource = data;
            FormatDGV(cbLoai.Text);
        }


        private void FormatDGV(string loai)
        {
            if (dgv.DataSource == null || dgv.Columns.Count == 0) return;

            string idColumnName = string.Empty;
            switch (loai)
            {
                case "Món": idColumnName = "MÃ_MÓN"; break;
                case "Khách hàng": idColumnName = "MÃ_KHÁCH_HÀNG"; break;
                case "Hóa đơn": idColumnName = "MÃ_HÓA_ĐƠN"; break;
                case "Nhân viên": idColumnName = "MÃ_NHÂN_VIÊN"; break;
            }

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                string columnName = col.Name;
                string formattedText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(columnName.Replace('_', ' ').ToLower());

                // 1. Đặt tên cột 
                if (columnName.Equals("TaiKhoan", StringComparison.OrdinalIgnoreCase))
                {
                    col.HeaderText = "Tài Khoản";
                }
                else
                {
                    col.HeaderText = formattedText;
                }

                // 2. Điều chỉnh FillWeight theo loại bảng
                col.FillWeight = 100; 

                if (loai == "Nhân viên")
                {
                    if (columnName.Equals("MÃ_NHÂN_VIÊN", StringComparison.OrdinalIgnoreCase) ||
                        columnName.Equals("ĐÃ_XÓA", StringComparison.OrdinalIgnoreCase) ||
                        columnName.Equals("GIỚI_TÍNH", StringComparison.OrdinalIgnoreCase))
                    {
                        col.FillWeight = 50; 
                    }
                    else if (columnName.Equals("HỌ_TÊN", StringComparison.OrdinalIgnoreCase))
                    {
                        col.FillWeight = 180; 
                    }
                    else if (columnName.Equals("SỐ_ĐIỆN_THOẠ", StringComparison.OrdinalIgnoreCase) ||
                             columnName.Equals("TÊN_ĐĂNG_NHẬP", StringComparison.OrdinalIgnoreCase))
                    {
                        col.FillWeight = 120;
                    }
                    else if (columnName.Equals("CHỨC_VỤ", StringComparison.OrdinalIgnoreCase))
                    {
                        col.FillWeight = 130;
                    }
                    else if (columnName.Equals("TaiKhoan", StringComparison.OrdinalIgnoreCase))
                    {
                        col.FillWeight = 150; 
                    }
                }
                else if (loai == "Món")
                {
                    if (columnName.Equals("TÊN_MÓN", StringComparison.OrdinalIgnoreCase))
                    {
                        col.FillWeight = 150;
                    }
                    else if (columnName.Equals("NGỪNG_KINH_DOANH", StringComparison.OrdinalIgnoreCase))
                    {
                        col.FillWeight = 60;
                    }
                }
                else if (loai == "Khách hàng" && columnName.Equals("ĐÃ_XÓA", StringComparison.OrdinalIgnoreCase))
                {
                    col.FillWeight = 60;
                }
                else if (loai == "Hóa đơn" && columnName.Equals("MÃ_HÓA_ĐƠN", StringComparison.OrdinalIgnoreCase))
                {
                    col.FillWeight = 60;
                }


                // 3. Căn chỉnh nội dung
                if (columnName.Equals(idColumnName, StringComparison.OrdinalIgnoreCase))
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (col.ValueType == typeof(bool)) 
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (columnName.Equals("GIÁ", StringComparison.OrdinalIgnoreCase) ||
                columnName.Equals("TỔNG_TIỀN", StringComparison.OrdinalIgnoreCase))
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    col.DefaultCellStyle.Format = "N0";   
                }
                else if (columnName.Equals("ĐIỂM_TÍCH_LŨY", StringComparison.OrdinalIgnoreCase))
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _db?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
