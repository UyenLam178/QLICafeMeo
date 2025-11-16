// DangNhap.cs
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace QLICafeMeo
{
    public partial class DangNhap : Form
    {
        private string connString;

        public DangNhap()
        {
            connString = global::QLICafeMeo.Properties.Settings.Default.QLICafeMeoConnectionString;
            InitializeComponent();
        }

        
        private string HashPassword(string pass, string format = "auto")
        {
            if (string.IsNullOrEmpty(pass)) return null;

            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));

                if (format == "base64")
                    return Convert.ToBase64String(bytes);

                if (format == "hex")
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var b in bytes)
                      
                        sb.Append(b.ToString("X2"));
                    return sb.ToString();
                }

         
                return Convert.ToBase64String(bytes);
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new DataClasses1DataContext(connString))
                {
                    var account = db.TaiKhoans
                                    .FirstOrDefault(a => a.TÊN_ĐĂNG_NHẬP == user);

                    if (account == null)
                    {
                        MessageBox.Show("Sai tên đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Lấy các định dạng Hash của mật khẩu người dùng nhập
                    string hashHexUpper = HashPassword(pass, "hex");       
                    string hashHexLower = hashHexUpper.ToLower();         
                    string hashBase64 = HashPassword(pass, "base64");      

                 
                    if (account.MẬT_KHẨU == hashHexUpper)
                    {
                        LoginSuccess(db, account, user);
                        return;
                    }

                   
                    if (account.MẬT_KHẨU == hashHexLower)
                    {
                       
                        MessageBox.Show("CẢNH BÁO: Mật khẩu đang lưu dạng Hex chữ thường!\nĐã tự động cập nhật.",
                                        "Bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        account.MẬT_KHẨU = hashHexUpper;
                        db.SubmitChanges();
                        LoginSuccess(db, account, user);
                        return;
                    }

                    // 3. KIỂM TRA CHUẨN CŨ (BASE64)
                    if (account.MẬT_KHẨU == hashBase64)
                    {
                       
                        MessageBox.Show("CẢNH BÁO: Mật khẩu đang lưu dạng Base64!\nĐã tự động cập nhật.",
                                        "Bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        account.MẬT_KHẨU = hashHexUpper;
                        db.SubmitChanges();
                        LoginSuccess(db, account, user);
                        return;
                    }

                    // 4. KIỂM TRA PLAINTEXT (Nếu còn)
                    if (account.MẬT_KHẨU == pass)
                    {
                       
                        MessageBox.Show("CẢNH BẢO: Mật khẩu đang lưu dạng plaintext!\nĐã tự động mã hóa.",
                                        "Bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        account.MẬT_KHẨU = hashHexUpper;
                        db.SubmitChanges();
                        LoginSuccess(db, account, user);
                        return;
                    }

                    MessageBox.Show("Sai mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL:\n" + ex.Message, "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginSuccess(DataClasses1DataContext db, TaiKhoan account, string user)
        {
            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            new TrangChu(account.QUYỀN, user).Show();
        }
    }
}