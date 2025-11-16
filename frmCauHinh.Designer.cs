// frmCauHinh.Designer.cs
using System.Drawing;
using System.Windows.Forms;

namespace QLICafeMeo
{
    partial class frmCauHinh
    {
        private System.ComponentModel.IContainer components = null;

        
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txtServer;
        private TextBox txtDatabase;
        private TextBox txtUser;
        private TextBox txtPass;
        private CheckBox chkWindowsAuth;
        private Button btnLuu;
        private Button btnHuy;
        private Label lblServer;
        private Label lblDatabase;
        private Label lblUser;
        private Label lblPass;
        private Label lblAuth;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.lblAuth = new System.Windows.Forms.Label();
            this.chkWindowsAuth = new System.Windows.Forms.CheckBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.lblServer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtServer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDatabase, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDatabase, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAuth, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkWindowsAuth, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblUser, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtUser, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPass, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtPass, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnLuu, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnHuy, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(480, 250);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblServer
            // 
            this.lblServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblServer.Location = new System.Drawing.Point(23, 15);
            this.lblServer.Name = "lblServer";
            this.lblServer.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblServer.Size = new System.Drawing.Size(170, 35);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "Server:";
            this.lblServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtServer
            // 
            this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServer.Location = new System.Drawing.Point(196, 20);
            this.txtServer.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(264, 27);
            this.txtServer.TabIndex = 1;
            // 
            // lblDatabase
            // 
            this.lblDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDatabase.Location = new System.Drawing.Point(23, 50);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblDatabase.Size = new System.Drawing.Size(170, 35);
            this.lblDatabase.TabIndex = 2;
            this.lblDatabase.Text = "Database:";
            this.lblDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatabase.Location = new System.Drawing.Point(196, 55);
            this.txtDatabase.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(264, 27);
            this.txtDatabase.TabIndex = 3;
            // 
            // lblAuth
            // 
            this.lblAuth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAuth.Location = new System.Drawing.Point(23, 85);
            this.lblAuth.Name = "lblAuth";
            this.lblAuth.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblAuth.Size = new System.Drawing.Size(170, 35);
            this.lblAuth.TabIndex = 4;
            this.lblAuth.Text = "Xác thực:";
            this.lblAuth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkWindowsAuth
            // 
            this.chkWindowsAuth.AutoSize = true;
            this.chkWindowsAuth.Checked = true;
            this.chkWindowsAuth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWindowsAuth.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkWindowsAuth.Location = new System.Drawing.Point(196, 93);
            this.chkWindowsAuth.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.chkWindowsAuth.Name = "chkWindowsAuth";
            this.chkWindowsAuth.Size = new System.Drawing.Size(193, 27);
            this.chkWindowsAuth.TabIndex = 5;
            this.chkWindowsAuth.Text = "Windows Authentication";
            this.chkWindowsAuth.CheckedChanged += new System.EventHandler(this.chkWindowsAuth_CheckedChanged);
            // 
            // lblUser
            // 
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUser.Enabled = false;
            this.lblUser.Location = new System.Drawing.Point(23, 120);
            this.lblUser.Name = "lblUser";
            this.lblUser.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblUser.Size = new System.Drawing.Size(170, 35);
            this.lblUser.TabIndex = 6;
            this.lblUser.Text = "User ID:";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.Enabled = false;
            this.txtUser.Location = new System.Drawing.Point(196, 125);
            this.txtUser.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(264, 27);
            this.txtUser.TabIndex = 7;
            // 
            // lblPass
            // 
            this.lblPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPass.Enabled = false;
            this.lblPass.Location = new System.Drawing.Point(23, 155);
            this.lblPass.Name = "lblPass";
            this.lblPass.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblPass.Size = new System.Drawing.Size(170, 35);
            this.lblPass.TabIndex = 8;
            this.lblPass.Text = "Password:";
            this.lblPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPass
            // 
            this.txtPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPass.Enabled = false;
            this.txtPass.Location = new System.Drawing.Point(196, 160);
            this.txtPass.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(264, 27);
            this.txtPass.TabIndex = 9;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLuu.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(116, 200);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 30);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnHuy.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(201, 200);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(5, 10, 10, 10);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 30);
            this.btnHuy.TabIndex = 11;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmCauHinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 250);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCauHinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cấu Hình Kết Nối CSDL";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}