using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    partial class CustomerAddEditDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlMain = new Guna2Panel();
            this.lblTitle = new Label();
            this.lblTenKhachHang = new Label();
            this.txtTenKhachHang = new Guna2TextBox();
            this.lblSoDienThoai = new Label();
            this.txtSoDienThoai = new Guna2TextBox();
            this.lblDiaChi = new Label();
            this.txtDiaChi = new Guna2TextBox();
            this.lblNote = new Label();
            this.lblError = new Label();
            this.btnSave = new Guna2Button();
            this.btnCancel = new Guna2Button();

            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            // pnlMain
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.lblTenKhachHang);
            this.pnlMain.Controls.Add(this.txtTenKhachHang);
            this.pnlMain.Controls.Add(this.lblSoDienThoai);
            this.pnlMain.Controls.Add(this.txtSoDienThoai);
            this.pnlMain.Controls.Add(this.lblDiaChi);
            this.pnlMain.Controls.Add(this.txtDiaChi);
            this.pnlMain.Controls.Add(this.lblNote);
            this.pnlMain.Controls.Add(this.lblError);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.FillColor = Color.White;
            this.pnlMain.Location = new Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new Padding(30);
            this.pnlMain.Size = new Size(500, 550);
            this.pnlMain.TabIndex = 0;

            // lblTitle
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(0, 150, 120);
            this.lblTitle.Location = new Point(30, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(440, 50);
            this.lblTitle.Text = "➕ Thêm khách hàng mới";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            int startY = 100;
            int spacing = 90;

            // Tên khách hàng
            this.lblTenKhachHang.Font = new Font("Segoe UI", 10F);
            this.lblTenKhachHang.Location = new Point(30, startY);
            this.lblTenKhachHang.Name = "lblTenKhachHang";
            this.lblTenKhachHang.Size = new Size(200, 25);
            this.lblTenKhachHang.Text = "Tên khách hàng *";

            this.txtTenKhachHang.BorderRadius = 8;
            this.txtTenKhachHang.Location = new Point(30, startY + 30);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.PlaceholderText = "Nhập tên khách hàng";
            this.txtTenKhachHang.Size = new Size(440, 40);

            // Số điện thoại
            startY += spacing;
            this.lblSoDienThoai.Font = new Font("Segoe UI", 10F);
            this.lblSoDienThoai.Location = new Point(30, startY);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new Size(200, 25);
            this.lblSoDienThoai.Text = "Số điện thoại";

            this.txtSoDienThoai.BorderRadius = 8;
            this.txtSoDienThoai.Location = new Point(30, startY + 30);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.PlaceholderText = "Nhập số điện thoại (10-11 số)";
            this.txtSoDienThoai.Size = new Size(440, 40);

            // Địa chỉ
            startY += spacing;
            this.lblDiaChi.Font = new Font("Segoe UI", 10F);
            this.lblDiaChi.Location = new Point(30, startY);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new Size(200, 25);
            this.lblDiaChi.Text = "Địa chỉ";

            this.txtDiaChi.BorderRadius = 8;
            this.txtDiaChi.Location = new Point(30, startY + 30);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.PlaceholderText = "Nhập địa chỉ";
            this.txtDiaChi.Size = new Size(440, 60);

            // Note
            startY += 70;
            this.lblNote.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            this.lblNote.ForeColor = Color.Gray;
            this.lblNote.Location = new Point(30, startY);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new Size(440, 40);
            this.lblNote.Text = "Lưu ý: Chỉ có Tên khách hàng là bắt buộc.\nSố điện thoại và Địa chỉ có thể để trống.";

            // Error label
            this.lblError.Font = new Font("Segoe UI", 9F);
            this.lblError.ForeColor = Color.Red;
            this.lblError.Location = new Point(30, startY + 45);
            this.lblError.Name = "lblError";
            this.lblError.Size = new Size(440, 40);
            this.lblError.Visible = false;

            // Buttons
            this.btnSave.BorderRadius = 8;
            this.btnSave.FillColor = Color.FromArgb(0, 150, 120);
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(30, 480);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(205, 45);
            this.btnSave.Text = "💾 Lưu";
            this.btnSave.Click += new EventHandler(this.BtnSave_Click);

            this.btnCancel.BorderRadius = 8;
            this.btnCancel.FillColor = Color.FromArgb(220, 53, 69);
            this.btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(265, 480);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(205, 45);
            this.btnCancel.Text = "❌ Hủy";
            this.btnCancel.Click += new EventHandler(this.BtnCancel_Click);

            // Form
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(500, 550);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerAddEditDialog";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Quản lý khách hàng";

            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Guna2Panel pnlMain;
        private Label lblTitle;
        private Label lblTenKhachHang;
        private Guna2TextBox txtTenKhachHang;
        private Label lblSoDienThoai;
        private Guna2TextBox txtSoDienThoai;
        private Label lblDiaChi;
        private Guna2TextBox txtDiaChi;
        private Label lblNote;
        private Label lblError;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;
    }
}