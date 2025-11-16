// frmCauHinh.cs
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace QLICafeMeo
{
    public partial class frmCauHinh : Form
    {
        private readonly string configPath = Path.Combine(Application.StartupPath, "QLICafeMeo.exe.config");

        private readonly string connStringKey = "QLICafeMeo.Properties.Settings.QLICafeMeoConnectionString";

        public frmCauHinh()
        {
            InitializeComponent();
            LoadCauHinh();
            chkWindowsAuth.CheckedChanged += chkWindowsAuth_CheckedChanged;
        }

        private void LoadCauHinh()
        {
            try
            {
                if (File.Exists(configPath))
                {
                    var config = ConfigurationManager.OpenExeConfiguration(configPath);

                    
                    string connStr = config.ConnectionStrings.ConnectionStrings[connStringKey]?.ConnectionString;

                    if (!string.IsNullOrEmpty(connStr))
                    {
                        txtServer.Text = GetConnValue(connStr, "Data Source");
                        txtDatabase.Text = GetConnValue(connStr, "Initial Catalog");
                        chkWindowsAuth.Checked = connStr.Contains("Integrated Security=True");

                        if (!chkWindowsAuth.Checked)
                        {
                            txtUser.Text = GetConnValue(connStr, "User ID");
                            txtPass.Text = GetConnValue(connStr, "Password");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc cấu hình: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetConnValue(string connStr, string key)
        {
            int start = connStr.IndexOf(key + "=", StringComparison.OrdinalIgnoreCase);
            if (start < 0) return "";
            start += key.Length + 1;
            int end = connStr.IndexOf(';', start);
            return end > start ? connStr.Substring(start, end - start).Trim() : connStr.Substring(start).Trim();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string server = txtServer.Text.Trim();
                string database = txtDatabase.Text.Trim();

                if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(database))
                {
                    MessageBox.Show("Vui lòng nhập Server và Database!", "Thiếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string connStr = chkWindowsAuth.Checked
                    ? $"Data Source={server};Initial Catalog={database};Integrated Security=True;Encrypt=True;TrustServerCertificate=True"
                    : $"Data Source={server};Initial Catalog={database};User ID={txtUser.Text};Password={txtPass.Text};Encrypt=True;TrustServerCertificate=True";

                // Thử kết nối
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    MessageBox.Show("Kết nối thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Lưu chuỗi kết nối vào file .config
                var config = ConfigurationManager.OpenExeConfiguration(configPath);

                var cs = config.ConnectionStrings.ConnectionStrings[connStringKey];
                if (cs == null)
                    config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(connStringKey, connStr));
                else
                    cs.ConnectionString = connStr;

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");

               
                QLICafeMeo.Properties.Settings.Default["QLICafeMeoConnectionString"] = connStr;
                QLICafeMeo.Properties.Settings.Default.Save();


                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu cấu hình:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            bool sqlAuth = !chkWindowsAuth.Checked;
            txtUser.Enabled = sqlAuth;
            txtPass.Enabled = sqlAuth;
            lblUser.Enabled = sqlAuth;
            lblPass.Enabled = sqlAuth;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}