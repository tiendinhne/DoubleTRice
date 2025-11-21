using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    partial class ResetPasswordDialog
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
            this.lblUserInfo = new Label();
            this.lblNewPassword = new Label();
            this.txtNewPassword = new Guna2TextBox();
            this.lblConfirmPassword = new Label();
            this.txtConfirmPassword = new Guna2TextBox();
            this.chkShowPassword = new Guna2CheckBox();
            this.lblNote = new Label();
            this.lblError = new Label();
            this.btnSave = new Guna2Button();
            this.btnCancel = new Guna2Button();

            //
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            // pnlMain
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.lblUserInfo);
            this.pnlMain.Controls.Add(this.lblNewPassword);
            this.pnlMain.Controls.Add(this.txtNewPassword);
            this.pnlMain.Controls.Add(this.lblConfirmPassword);
            this.pnlMain.Controls.Add(this.txtConfirmPassword);
            this.pnlMain.Controls.Add(this.chkShowPassword);
            this.pnlMain.Controls.Add(this.lblNote);
            this.pnlMain.Controls.Add(this.lblError);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.FillColor = Color.White;
            this.pnlMain.Location = new Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new Padding(30);
            this.pnlMain.Size = new Size(500, 450);
            this.pnlMain.TabIndex = 0;

            // lblTitle
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(0, 150, 120);
            this.lblTitle.Location = new Point(30, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(440, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔑 Đặt lại mật khẩu";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblUserInfo
            this.lblUserInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblUserInfo.ForeColor = Color.FromArgb(0, 70, 67);
            this.lblUserInfo.Location = new Point(30, 90);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new Size(440, 30);
            this.lblUserInfo.Text = "Đặt lại mật khẩu cho: ...";
            this.lblUserInfo.TextAlign = ContentAlignment.MiddleCenter;

            // lblNewPassword
            this.lblNewPassword.Font = new Font("Segoe UI", 10F);
            this.lblNewPassword.Location = new Point(30, 140);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new Size(200, 25);
            this.lblNewPassword.Text = "Mật khẩu mới *";

            this.txtNewPassword.BorderRadius = 8;
            this.txtNewPassword.Location = new Point(30, 170);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '●';
            this.txtNewPassword.PlaceholderText = "Nhập mật khẩu mới (tối thiểu 6 ký tự)";
            this.txtNewPassword.Size = new Size(440, 40);

            // lblConfirmPassword
            this.lblConfirmPassword.Font = new Font("Segoe UI", 10F);
            this.lblConfirmPassword.Location = new Point(30, 220);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new Size(200, 25);
            this.lblConfirmPassword.Text = "Nhập lại mật khẩu mới *";

            this.txtConfirmPassword.BorderRadius = 8;
            this.txtConfirmPassword.Location = new Point(30, 250);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '●';
            this.txtConfirmPassword.PlaceholderText = "Nhập lại mật khẩu mới";
            this.txtConfirmPassword.Size = new Size(440, 40);

            // chkShowPassword
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.CheckedState.BorderColor = Color.FromArgb(0, 150, 120);
            this.chkShowPassword.CheckedState.BorderRadius = 0;
            this.chkShowPassword.CheckedState.BorderThickness = 0;
            this.chkShowPassword.CheckedState.FillColor = Color.FromArgb(0, 150, 120);
            this.chkShowPassword.Font = new Font("Segoe UI", 9F);
            this.chkShowPassword.Location = new Point(30, 300);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new Size(150, 24);
            this.chkShowPassword.TabIndex = 7;
            this.chkShowPassword.Text = "👁️ Hiện mật khẩu";
            this.chkShowPassword.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            this.chkShowPassword.UncheckedState.BorderRadius = 0;
            this.chkShowPassword.UncheckedState.BorderThickness = 0;
            this.chkShowPassword.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            this.chkShowPassword.CheckedChanged += new EventHandler(this.ChkShowPassword_CheckedChanged);

            // lblNote
            this.lblNote.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            this.lblNote.ForeColor = Color.Gray;
            this.lblNote.Location = new Point(30, 330);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new Size(440, 20);
            this.lblNote.Text = "Lưu ý: Người dùng sẽ cần đổi mật khẩu này sau lần đăng nhập tiếp theo";

            // lblError
            this.lblError.Font = new Font("Segoe UI", 9F);
            this.lblError.ForeColor = Color.Red;
            this.lblError.Location = new Point(30, 355);
            this.lblError.Name = "lblError";
            this.lblError.Size = new Size(440, 30);
            this.lblError.Visible = false;

            // btnSave
            this.btnSave.BorderRadius = 8;
            this.btnSave.FillColor = Color.FromArgb(0, 150, 120);
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(30, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(205, 45);
            this.btnSave.Text = "💾 Đặt lại mật khẩu";
            this.btnSave.Click += new EventHandler(this.BtnSave_Click);

            this.btnCancel.BorderRadius = 8;
            this.btnCancel.FillColor = Color.FromArgb(220, 53, 69);
            this.btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(265, 390);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(205, 45);
            this.btnCancel.Text = "❌ Hủy";
            this.btnCancel.Click += new EventHandler(this.BtnCancel_Click);

            // Form
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(500, 450);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResetPasswordDialog";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "ResetPasswordDialog";

            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
        }

        // Controls
        private Guna2Panel pnlMain;
        private Label lblTitle;
        private Label lblUserInfo;
        private Label lblNewPassword;
        private Guna2TextBox txtNewPassword;
        private Label lblConfirmPassword;
        private Guna2TextBox txtConfirmPassword;
        private Guna2CheckBox chkShowPassword;
        private Label lblNote;
        private Label lblError;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;
        #endregion
    }
}