using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    partial class UserAddEditDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new Guna2Panel();
            this.lblTitle = new Label();
            this.lblHoTen = new Label();
            this.txtHoTen = new Guna2TextBox();
            this.lblTenDangNhap = new Label();
            this.txtTenDangNhap = new Guna2TextBox();
            this.lblVaiTro = new Label();
            this.cboVaiTro = new Guna2ComboBox();
            this.lblPassword = new Label();
            this.txtPassword = new Guna2TextBox();
            this.lblConfirmPassword = new Label();
            this.txtConfirmPassword = new Guna2TextBox();
            this.lblPasswordNote = new Label();
            this.lblError = new Label();
            this.btnSave = new Guna2Button();
            this.btnCancel = new Guna2Button();

            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // pnlMain
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.lblHoTen);
            this.pnlMain.Controls.Add(this.txtHoTen);
            this.pnlMain.Controls.Add(this.lblTenDangNhap);
            this.pnlMain.Controls.Add(this.txtTenDangNhap);
            this.pnlMain.Controls.Add(this.lblVaiTro);
            this.pnlMain.Controls.Add(this.cboVaiTro);
            this.pnlMain.Controls.Add(this.lblPassword);
            this.pnlMain.Controls.Add(this.txtPassword);
            this.pnlMain.Controls.Add(this.lblConfirmPassword);
            this.pnlMain.Controls.Add(this.txtConfirmPassword);
            this.pnlMain.Controls.Add(this.lblPasswordNote);
            this.pnlMain.Controls.Add(this.lblError);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.FillColor = Color.White;
            this.pnlMain.Location = new Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new Padding(30);
            this.pnlMain.Size = new Size(500, 650);
            this.pnlMain.TabIndex = 0;

            // lblTitle
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(0, 150, 120);
            this.lblTitle.Location = new Point(30, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(440, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "➕ Thêm người dùng mới";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Labels & TextBoxes (Y positions)
            int startY = 100;
            int spacing = 80;

            // Họ tên
            this.lblHoTen.Font = new Font("Segoe UI", 10F);
            this.lblHoTen.Location = new Point(30, startY);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new Size(200, 25);
            this.lblHoTen.Text = "Họ và tên *";

            this.txtHoTen.BorderRadius = 8;
            this.txtHoTen.Location = new Point(30, startY + 30);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.PlaceholderText = "Nhập họ và tên";
            this.txtHoTen.Size = new Size(440, 40);

            // Tên đăng nhập
            startY += spacing;
            this.lblTenDangNhap.Font = new Font("Segoe UI", 10F);
            this.lblTenDangNhap.Location = new Point(30, startY);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new Size(200, 25);
            this.lblTenDangNhap.Text = "Tên đăng nhập *";

            this.txtTenDangNhap.BorderRadius = 8;
            this.txtTenDangNhap.Location = new Point(30, startY + 30);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.PlaceholderText = "Nhập tên đăng nhập";
            this.txtTenDangNhap.Size = new Size(440, 40);

            // Vai trò
            startY += spacing;
            this.lblVaiTro.Font = new Font("Segoe UI", 10F);
            this.lblVaiTro.Location = new Point(30, startY);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new Size(200, 25);
            this.lblVaiTro.Text = "Vai trò *";

            this.cboVaiTro.BackColor = Color.Transparent;
            this.cboVaiTro.BorderRadius = 8;
            this.cboVaiTro.DrawMode = DrawMode.OwnerDrawFixed;
            this.cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboVaiTro.Font = new Font("Segoe UI", 9F);
            this.cboVaiTro.Location = new Point(30, startY + 30);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size = new Size(440, 40);

            // Mật khẩu
            startY += spacing;
            this.lblPassword.Font = new Font("Segoe UI", 10F);
            this.lblPassword.Location = new Point(30, startY);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(200, 25);
            this.lblPassword.Text = "Mật khẩu *";

            this.txtPassword.BorderRadius = 8;
            this.txtPassword.Location = new Point(30, startY + 30);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PlaceholderText = "Nhập mật khẩu (tối thiểu 6 ký tự)";
            this.txtPassword.Size = new Size(440, 40);
            this.txtPassword.Text = "123456"; // Default password

            // Nhập lại mật khẩu
            startY += spacing;
            this.lblConfirmPassword.Font = new Font("Segoe UI", 10F);
            this.lblConfirmPassword.Location = new Point(30, startY);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new Size(200, 25);
            this.lblConfirmPassword.Text = "Nhập lại mật khẩu *";

            this.txtConfirmPassword.BorderRadius = 8;
            this.txtConfirmPassword.Location = new Point(30, startY + 30);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '●';
            this.txtConfirmPassword.PlaceholderText = "Nhập lại mật khẩu";
            this.txtConfirmPassword.Size = new Size(440, 40);
            this.txtConfirmPassword.Text = "123456"; // Default password

            // Password note
            startY += 50;
            this.lblPasswordNote.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            this.lblPasswordNote.ForeColor = Color.Gray;
            this.lblPasswordNote.Location = new Point(30, startY);
            this.lblPasswordNote.Name = "lblPasswordNote";
            this.lblPasswordNote.Size = new Size(440, 20);
            this.lblPasswordNote.Text = "(Mật khẩu mặc định: 123456)";

            // Error label
            this.lblError.Font = new Font("Segoe UI", 9F);
            this.lblError.ForeColor = Color.Red;
            this.lblError.Location = new Point(30, startY + 25);
            this.lblError.Name = "lblError";
            this.lblError.Size = new Size(440, 40);
            this.lblError.Visible = false;

            // Buttons
            this.btnSave.BorderRadius = 8;
            this.btnSave.FillColor = Color.FromArgb(0, 150, 120);
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(30, 570);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(205, 45);
            this.btnSave.Text = "💾 Lưu";
            this.btnSave.Click += new EventHandler(this.BtnSave_Click);

            this.btnCancel.BorderRadius = 8;
            this.btnCancel.FillColor = Color.FromArgb(220, 53, 69);
            this.btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(265, 570);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(205, 45);
            this.btnCancel.Text = "❌ Hủy";
            this.btnCancel.Click += new EventHandler(this.BtnCancel_Click);

            // Form
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(500, 650);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserAddEditDialog";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Quản lý người dùng";

            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        // Controls
        private Guna2Panel pnlMain;
        private Label lblTitle;
        private Label lblHoTen;
        private Guna2TextBox txtHoTen;
        private Label lblTenDangNhap;
        private Guna2TextBox txtTenDangNhap;
        private Label lblVaiTro;
        private Guna2ComboBox cboVaiTro;
        private Label lblPassword;
        private Guna2TextBox txtPassword;
        private Label lblConfirmPassword;
        private Guna2TextBox txtConfirmPassword;
        private Label lblPasswordNote;
        private Label lblError;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;

        #endregion
    }
}