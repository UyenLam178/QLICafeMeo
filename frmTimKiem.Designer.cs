using System.Windows.Forms;
using System.Drawing;

namespace QLICafeMeo
{
    partial class frmTimKiem
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cbLoai;
        private TextBox txtTuKhoa;
        private Button btnTim;
        private DataGridView dgv;
        private Label lblTieuDe;
        private Panel pnlTopControls;

        private void InitializeComponent()
        {
            this.cbLoai = new System.Windows.Forms.ComboBox();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlTopControls = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnlTopControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbLoai
            // 
            this.cbLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoai.Items.AddRange(new object[] {
            "Món",
            "Khách hàng",
            "Hóa đơn",
            "Nhân viên"});
            this.cbLoai.Location = new System.Drawing.Point(130, 8);
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Size = new System.Drawing.Size(121, 31);
            this.cbLoai.TabIndex = 0;
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Location = new System.Drawing.Point(270, 8);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(250, 30);
            this.txtTuKhoa.TabIndex = 1;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(10, 5);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(100, 30);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm kiếm";
            // 
            // dgv
            // 
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(10, 85);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 62;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(908, 342);
            this.dgv.TabIndex = 3;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblTieuDe.Location = new System.Drawing.Point(10, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(908, 40);
            this.lblTieuDe.TabIndex = 4;
            this.lblTieuDe.Text = "TÌM KIẾM";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTopControls
            // 
            this.pnlTopControls.Controls.Add(this.btnTim);
            this.pnlTopControls.Controls.Add(this.cbLoai);
            this.pnlTopControls.Controls.Add(this.txtTuKhoa);
            this.pnlTopControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopControls.Location = new System.Drawing.Point(10, 40);
            this.pnlTopControls.Name = "pnlTopControls";
            this.pnlTopControls.Size = new System.Drawing.Size(908, 45);
            this.pnlTopControls.TabIndex = 5;
            // 
            // frmTimKiem
            // 
            this.ClientSize = new System.Drawing.Size(928, 437);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlTopControls);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "frmTimKiem";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.Text = "Tìm kiếm";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnlTopControls.ResumeLayout(false);
            this.pnlTopControls.PerformLayout();
            this.ResumeLayout(false);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
    }
}