using System.Drawing;

namespace DoubleTRice.UI
{
    partial class LoginUI
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
            this.components = new System.ComponentModel.Container();
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.pnlLogin = new Guna.UI2.WinForms.Guna2Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlRememberForgot = new System.Windows.Forms.Panel();
            this.chkRememberMe = new Guna.UI2.WinForms.Guna2CheckBox();
            this.lblForgotPassword = new System.Windows.Forms.Label();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.lblError = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.dragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.shadowForm = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.fadeInTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlBackground.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.pnlRememberForgot.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(25)))));
            this.pnlBackground.Controls.Add(this.pnlLogin);
            this.pnlBackground.Controls.Add(this.picBackground);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(1400, 800);
            this.pnlBackground.TabIndex = 0;
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogin.BorderColor = System.Drawing.Color.White;
            this.pnlLogin.BorderRadius = 25;
            this.pnlLogin.Controls.Add(this.pictureBox1);
            this.pnlLogin.Controls.Add(this.lblWelcome);
            this.pnlLogin.Controls.Add(this.lblSubtitle);
            this.pnlLogin.Controls.Add(this.txtUsername);
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(this.pnlRememberForgot);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.lblError);
            this.pnlLogin.Controls.Add(this.pnlFooter);
            this.pnlLogin.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pnlLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlLogin.Location = new System.Drawing.Point(800, 40);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Padding = new System.Windows.Forms.Padding(40);
            this.pnlLogin.ShadowDecoration.BorderRadius = 25;
            this.pnlLogin.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlLogin.ShadowDecoration.Enabled = true;
            this.pnlLogin.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 8, 30, 30);
            this.pnlLogin.Size = new System.Drawing.Size(476, 600);
            this.pnlLogin.TabIndex = 1;
            // 
            // lblWelcome
            // 
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Stencil", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(44, 46);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(415, 88);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Rockwell", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.White;
            this.lblSubtitle.Location = new System.Drawing.Point(54, 120);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(397, 85);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "To DoubleTRice Management";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUsername
            // 
            this.txtUsername.Animated = true;
            this.txtUsername.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.txtUsername.BorderRadius = 12;
            this.txtUsername.BorderThickness = 2;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultText = "";
            this.txtUsername.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.txtUsername.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.ForeColor = System.Drawing.Color.White;
            this.txtUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.txtUsername.IconLeftOffset = new System.Drawing.Point(12, 0);
            this.txtUsername.Location = new System.Drawing.Point(71, 236);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(140)))));
            this.txtUsername.PlaceholderText = "Username or Email";
            this.txtUsername.SelectedText = "";
            this.txtUsername.Size = new System.Drawing.Size(340, 50);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.TextOffset = new System.Drawing.Point(8, 0);
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Animated = true;
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.txtPassword.BorderRadius = 12;
            this.txtPassword.BorderThickness = 2;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.txtPassword.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.ForeColor = System.Drawing.Color.White;
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.txtPassword.IconLeftOffset = new System.Drawing.Point(12, 0);
            this.txtPassword.IconRight = global::DoubleTRice.Properties.Resources.show;
            this.txtPassword.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.txtPassword.IconRightOffset = new System.Drawing.Point(12, 0);
            this.txtPassword.Location = new System.Drawing.Point(71, 301);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(140)))));
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(340, 50);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.TextOffset = new System.Drawing.Point(8, 0);
            this.txtPassword.IconRightClick += new System.EventHandler(this.TxtPassword_IconRightClick);
            // 
            // pnlRememberForgot
            // 
            this.pnlRememberForgot.BackColor = System.Drawing.Color.Transparent;
            this.pnlRememberForgot.Controls.Add(this.chkRememberMe);
            this.pnlRememberForgot.Controls.Add(this.lblForgotPassword);
            this.pnlRememberForgot.Location = new System.Drawing.Point(71, 366);
            this.pnlRememberForgot.Name = "pnlRememberForgot";
            this.pnlRememberForgot.Size = new System.Drawing.Size(340, 30);
            this.pnlRememberForgot.TabIndex = 5;
            // 
            // chkRememberMe
            // 
            this.chkRememberMe.AutoSize = true;
            this.chkRememberMe.BackColor = System.Drawing.Color.Transparent;
            this.chkRememberMe.CheckedState.BorderColor = System.Drawing.Color.White;
            this.chkRememberMe.CheckedState.BorderRadius = 0;
            this.chkRememberMe.CheckedState.BorderThickness = 0;
            this.chkRememberMe.CheckedState.FillColor = System.Drawing.Color.Blue;
            this.chkRememberMe.CheckMarkColor = System.Drawing.Color.Teal;
            this.chkRememberMe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkRememberMe.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkRememberMe.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.chkRememberMe.ForeColor = System.Drawing.Color.Teal;
            this.chkRememberMe.Location = new System.Drawing.Point(0, 0);
            this.chkRememberMe.Name = "chkRememberMe";
            this.chkRememberMe.Size = new System.Drawing.Size(157, 30);
            this.chkRememberMe.TabIndex = 0;
            this.chkRememberMe.Text = "Remember me";
            this.chkRememberMe.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.chkRememberMe.UncheckedState.BorderRadius = 0;
            this.chkRememberMe.UncheckedState.BorderThickness = 0;
            this.chkRememberMe.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.chkRememberMe.UseVisualStyleBackColor = false;
            this.chkRememberMe.CheckedChanged += new System.EventHandler(this.chkRememberMe_CheckedChanged);
            // 
            // lblForgotPassword
            // 
            this.lblForgotPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblForgotPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblForgotPassword.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblForgotPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblForgotPassword.ForeColor = System.Drawing.Color.Teal;
            this.lblForgotPassword.Location = new System.Drawing.Point(268, 0);
            this.lblForgotPassword.Name = "lblForgotPassword";
            this.lblForgotPassword.Size = new System.Drawing.Size(72, 30);
            this.lblForgotPassword.TabIndex = 1;
            this.lblForgotPassword.Text = "Forgot Password?";
            this.lblForgotPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblForgotPassword.Click += new System.EventHandler(this.LblForgotPassword_Click);
            this.lblForgotPassword.MouseEnter += new System.EventHandler(this.LblForgotPassword_MouseEnter);
            this.lblForgotPassword.MouseLeave += new System.EventHandler(this.LblForgotPassword_MouseLeave);
            // 
            // btnLogin
            // 
            this.btnLogin.Animated = true;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BorderRadius = 12;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.FillColor = System.Drawing.Color.IndianRed;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btnLogin.Location = new System.Drawing.Point(71, 416);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(235)))));
            this.btnLogin.Size = new System.Drawing.Size(340, 62);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblError.ForeColor = System.Drawing.Color.White;
            this.lblError.Location = new System.Drawing.Point(71, 481);
            this.lblError.Name = "lblError";
            this.lblError.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.lblError.Size = new System.Drawing.Size(340, 0);
            this.lblError.TabIndex = 7;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.Visible = false;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFooter.Controls.Add(this.lblFooter);
            this.pnlFooter.Controls.Add(this.lblVersion);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(40, 527);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(396, 33);
            this.pnlFooter.TabIndex = 8;
            // 
            // lblFooter
            // 
            this.lblFooter.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.lblFooter.Location = new System.Drawing.Point(0, 0);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(346, 33);
            this.lblFooter.TabIndex = 0;
            this.lblFooter.Text = "© 2025 by tiendinh & tienpham";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVersion
            // 
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.lblVersion.Location = new System.Drawing.Point(346, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(50, 33);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "v1.1.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // picBackground
            // 
            this.picBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBackground.Image = global::DoubleTRice.Properties.Resources.anhnenmoi;
            this.picBackground.Location = new System.Drawing.Point(0, 0);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(1400, 800);
            this.picBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBackground.TabIndex = 0;
            this.picBackground.TabStop = false;
            // 
            // dragControl
            // 
            this.dragControl.DockIndicatorTransparencyValue = 0.6D;
            this.dragControl.TargetControl = this.pnlBackground;
            this.dragControl.UseTransparentDrag = true;
            // 
            // shadowForm
            // 
            this.shadowForm.BorderRadius = 0;
            this.shadowForm.TargetForm = this;
            // 
            // fadeInTimer
            // 
            this.fadeInTimer.Interval = 20;
            this.fadeInTimer.Tick += new System.EventHandler(this.FadeInTimer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = global::DoubleTRice.Properties.Resources.cancelred;
            this.pictureBox1.Location = new System.Drawing.Point(435, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // LoginUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - Double T Rice";
            this.Load += new System.EventHandler(this.LoginUI_Load);
            this.pnlBackground.ResumeLayout(false);
            this.pnlLogin.ResumeLayout(false);
            this.pnlRememberForgot.ResumeLayout(false);
            this.pnlRememberForgot.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.PictureBox picBackground;
        private Guna.UI2.WinForms.Guna2Panel pnlLogin;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubtitle;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private System.Windows.Forms.Panel pnlRememberForgot;
        private Guna.UI2.WinForms.Guna2CheckBox chkRememberMe;
        private System.Windows.Forms.Label lblForgotPassword;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Label lblVersion;
        private Guna.UI2.WinForms.Guna2DragControl dragControl;
        private Guna.UI2.WinForms.Guna2ShadowForm shadowForm;
        private System.Windows.Forms.Timer fadeInTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}