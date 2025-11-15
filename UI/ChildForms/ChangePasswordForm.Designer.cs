using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DoubleTRice.UI.ChildForms
{
    partial class ChangePasswordForm
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
            this.lblOldPassword = new Label();
            this.txtOldPassword = new Guna2TextBox();
            this.lblNewPassword = new Label();
            this.txtNewPassword = new Guna2TextBox();
            this.lblConfirmPassword = new Label();
            this.txtConfirmPassword = new Guna2TextBox();
            this.lblError = new Label();
            this.btnSave = new Guna2Button();
            this.btnCancel = new Guna2Button();

            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            // 
            // ChangePasswordForm
            // 
            this.ClientSize = new Size(500, 550);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Đổi mật khẩu";
            this.BackColor = Color.White;

            // 
            // pnlMain
            // 
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.FillColor = Color.White;
            this.pnlMain.Padding = new Padding(30);
            this.pnlMain.Location = new Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new Size(500, 550);
            this.pnlMain.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.Location = new Point(30, 20);
            this.lblTitle.Size = new Size(440, 40);
            this.lblTitle.Text = "🔒 Đổi mật khẩu";
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(0, 150, 120);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;

            // 
            // lblOldPassword
            // 
            this.lblOldPassword.Location = new Point(30, 80);
            this.lblOldPassword.Size = new Size(200, 20);
            this.lblOldPassword.Text = "Mật khẩu cũ *";
            this.lblOldPassword.Font = new Font("Segoe UI", 10F);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.TabIndex = 1;

            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new Point(30, 105);
            this.txtOldPassword.Size = new Size(410, 40);
            this.txtOldPassword.BorderRadius = 8;
            this.txtOldPassword.PasswordChar = '●';
            this.txtOldPassword.PlaceholderText = "Nhập mật khẩu cũ";
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.TabIndex = 2;
            this.txtOldPassword.TextChanged += TxtPassword_TextChanged;

            // 
            // lblNewPassword
            // 
            this.lblNewPassword.Location = new Point(30, 160);
            this.lblNewPassword.Size = new Size(200, 20);
            this.lblNewPassword.Text = "Mật khẩu mới *";
            this.lblNewPassword.Font = new Font("Segoe UI", 10F);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.TabIndex = 3;

            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new Point(30, 185);
            this.txtNewPassword.Size = new Size(410, 40);
            this.txtNewPassword.BorderRadius = 8;
            this.txtNewPassword.PasswordChar = '●';
            this.txtNewPassword.PlaceholderText = "Nhập mật khẩu mới (tối thiểu 6 ký tự)";
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.TabIndex = 4;
            this.txtNewPassword.TextChanged += TxtPassword_TextChanged;

            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Location = new Point(30, 240);
            this.lblConfirmPassword.Size = new Size(200, 20);
            this.lblConfirmPassword.Text = "Nhập lại mật khẩu mới *";
            this.lblConfirmPassword.Font = new Font("Segoe UI", 10F);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.TabIndex = 5;

            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new Point(30, 265);
            this.txtConfirmPassword.Size = new Size(410, 40);
            this.txtConfirmPassword.BorderRadius = 8;
            this.txtConfirmPassword.PasswordChar = '●';
            this.txtConfirmPassword.PlaceholderText = "Nhập lại mật khẩu mới";
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.TabIndex = 6;
            this.txtConfirmPassword.TextChanged += TxtPassword_TextChanged;

            // 
            // lblError
            // 
            this.lblError.Location = new Point(30, 320);
            this.lblError.Size = new Size(440, 60);
            this.lblError.Font = new Font("Segoe UI", 9F);
            this.lblError.ForeColor = Color.Red;
            this.lblError.Visible = false;
            this.lblError.TextAlign = ContentAlignment.TopLeft;
            this.lblError.Name = "lblError";
            this.lblError.TabIndex = 7;

            // 
            // btnSave
            // 
            this.btnSave.Location = new Point(30, 400);
            this.btnSave.Size = new Size(195, 45);
            this.btnSave.Text = "💾 Lưu thay đổi";
            this.btnSave.BorderRadius = 8;
            this.btnSave.FillColor = Color.FromArgb(0, 150, 120);
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Name = "btnSave";
            this.btnSave.TabIndex = 8;
            this.btnSave.Click += BtnSave_Click;

            // 
            // btnCancel
            // 
            this.btnCancel.Location = new Point(245, 400);
            this.btnCancel.Size = new Size(195, 45);
            this.btnCancel.Text = "❌ Hủy";
            this.btnCancel.BorderRadius = 8;
            this.btnCancel.FillColor = Color.FromArgb(220, 53, 69);
            this.btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Click += BtnCancel_Click;

            // Add controls to pnlMain
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.lblOldPassword);
            this.pnlMain.Controls.Add(this.txtOldPassword);
            this.pnlMain.Controls.Add(this.lblNewPassword);
            this.pnlMain.Controls.Add(this.txtNewPassword);
            this.pnlMain.Controls.Add(this.lblConfirmPassword);
            this.pnlMain.Controls.Add(this.txtConfirmPassword);
            this.pnlMain.Controls.Add(this.lblError);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Controls.Add(this.btnCancel);

            // Add pnlMain to form
            this.Controls.Add(this.pnlMain);

            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion
        #region Windows Form Designer generated code - Fields
        private Guna2Panel pnlMain;
        private Guna2TextBox txtOldPassword;
        private Guna2TextBox txtNewPassword;
        private Guna2TextBox txtConfirmPassword;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;
        private Label lblTitle;
        private Label lblOldPassword;
        private Label lblNewPassword;
        private Label lblConfirmPassword;
        private Label lblError;
        #endregion

    }
}