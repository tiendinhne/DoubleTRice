using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI
{
    partial class SettingForm
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
            this.picAvatar = new Guna2CirclePictureBox();
            this.lblUserNameLabel = new Label();
            this.lblUserName = new Label();
            this.lblUsernameLabel = new Label();
            this.lblUsername = new Label();
            this.lblRoleLabel = new Label();
            this.lblRole = new Label();
            this.lblLoginLabel = new Label();
            this.lblLoginTime = new Label();
            this.separator = new Panel();
            this.btnChangePassword = new Guna2Button();
            this.btnClose = new Guna2Button();

            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.picAvatar);
            this.pnlMain.Controls.Add(this.lblUserNameLabel);
            this.pnlMain.Controls.Add(this.lblUserName);
            this.pnlMain.Controls.Add(this.lblUsernameLabel);
            this.pnlMain.Controls.Add(this.lblUsername);
            this.pnlMain.Controls.Add(this.lblRoleLabel);
            this.pnlMain.Controls.Add(this.lblRole);
            this.pnlMain.Controls.Add(this.lblLoginLabel);
            this.pnlMain.Controls.Add(this.lblLoginTime);
            this.pnlMain.Controls.Add(this.separator);
            this.pnlMain.Controls.Add(this.btnChangePassword);
            this.pnlMain.Controls.Add(this.btnClose);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Location = new Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new Padding(20);
            this.pnlMain.Size = new Size(450, 480);
            this.pnlMain.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(410, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "⚙️ CÀI ĐẶT TÀI KHOẢN";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // picAvatar
            // 
            this.picAvatar.Location = new Point(175, 70);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picAvatar.Size = new Size(100, 100);
            this.picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 1;
            this.picAvatar.TabStop = false;
            this.picAvatar.Image = Properties.Resources.smart_farm;

            // 
            // lblUserNameLabel
            // 
            this.lblUserNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblUserNameLabel.Location = new Point(40, 190);
            this.lblUserNameLabel.Name = "lblUserNameLabel";
            this.lblUserNameLabel.Size = new Size(120, 25);
            this.lblUserNameLabel.TabIndex = 2;
            this.lblUserNameLabel.Text = "Họ và tên:";
            this.lblUserNameLabel.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // lblUserName
            // 
            this.lblUserName.Font = new Font("Segoe UI", 10F);
            this.lblUserName.Location = new Point(160, 190);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new Size(250, 25);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "...";
            this.lblUserName.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // lblUsernameLabel
            // 
            this.lblUsernameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblUsernameLabel.Location = new Point(40, 225);
            this.lblUsernameLabel.Name = "lblUsernameLabel";
            this.lblUsernameLabel.Size = new Size(120, 25);
            this.lblUsernameLabel.TabIndex = 4;
            this.lblUsernameLabel.Text = "Tên đăng nhập:";
            this.lblUsernameLabel.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // lblUsername
            // 
            this.lblUsername.Font = new Font("Segoe UI", 10F);
            this.lblUsername.Location = new Point(160, 225);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new Size(250, 25);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "...";
            this.lblUsername.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // lblRoleLabel
            // 
            this.lblRoleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblRoleLabel.Location = new Point(40, 260);
            this.lblRoleLabel.Name = "lblRoleLabel";
            this.lblRoleLabel.Size = new Size(120, 25);
            this.lblRoleLabel.TabIndex = 6;
            this.lblRoleLabel.Text = "Vai trò:";
            this.lblRoleLabel.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // lblRole
            // 
            this.lblRole.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblRole.ForeColor = Color.FromArgb(0, 180, 140);
            this.lblRole.Location = new Point(160, 260);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new Size(250, 25);
            this.lblRole.TabIndex = 7;
            this.lblRole.Text = "...";
            this.lblRole.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // lblLoginLabel
            // 
            this.lblLoginLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblLoginLabel.Location = new Point(40, 295);
            this.lblLoginLabel.Name = "lblLoginLabel";
            this.lblLoginLabel.Size = new Size(120, 25);
            this.lblLoginLabel.TabIndex = 8;
            this.lblLoginLabel.Text = "Đăng nhập lúc:";
            this.lblLoginLabel.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // lblLoginTime
            // 
            this.lblLoginTime.Font = new Font("Segoe UI", 9F);
            this.lblLoginTime.Location = new Point(160, 295);
            this.lblLoginTime.Name = "lblLoginTime";
            this.lblLoginTime.Size = new Size(250, 25);
            this.lblLoginTime.TabIndex = 9;
            this.lblLoginTime.Text = "...";
            this.lblLoginTime.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // separator
            // 
            this.separator.BackColor = Color.FromArgb(230, 230, 230);
            this.separator.Location = new Point(40, 340);
            this.separator.Name = "separator";
            this.separator.Size = new Size(370, 2);
            this.separator.TabIndex = 10;

            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BorderRadius = 8;
            this.btnChangePassword.FillColor = Color.FromArgb(0, 180, 140);
            this.btnChangePassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnChangePassword.ForeColor = Color.White;
            this.btnChangePassword.Location = new Point(40, 370);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new Size(180, 45);
            this.btnChangePassword.TabIndex = 11;
            this.btnChangePassword.Text = "🔒 Đổi mật khẩu";
            this.btnChangePassword.Click += new EventHandler(this.BtnChangePassword_Click);

            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 8;
            this.btnClose.FillColor = Color.FromArgb(220, 220, 220);
            this.btnClose.Font = new Font("Segoe UI", 10F);
            this.btnClose.ForeColor = Color.FromArgb(60, 60, 60);
            this.btnClose.Location = new Point(230, 370);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(180, 45);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new EventHandler(this.BtnClose_Click);

            // 
            // SettingForm
            // 
            this.ClientSize = new Size(450, 480);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Cài đặt tài khoản";

            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);

            //this.components = new System.ComponentModel.Container();
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(800, 450);
            //this.Text = "SettingForm";
        }
        private Guna2Panel pnlMain;
        private Label lblTitle;
        private Guna2CirclePictureBox picAvatar;
        private Label lblUserNameLabel;
        private Label lblUserName;
        private Label lblUsernameLabel;
        private Label lblUsername;
        private Label lblRoleLabel;
        private Label lblRole;
        private Label lblLoginLabel;
        private Label lblLoginTime;
        private Panel separator;
        private Guna2Button btnChangePassword;
        private Guna2Button btnClose;
        #endregion
    }
}