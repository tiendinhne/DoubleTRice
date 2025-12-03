using DoubleTRice.LOGIC;
using DoubleTRice.UI.BASE;
using DoubleTRice.UI.ChildForms;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI
{
    public partial class SettingForm : Form
    {
        #region Constructor
        public SettingForm()
        {
            InitializeComponent();
            LoadUserInfo();
            ApplyMode();
        }
        #endregion
        #region Load User Info
        private void LoadUserInfo()
        {
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("Phiên đăng nhập đã hết hạn!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            lblUserName.Text = UserSession.HoTen ?? "N/A";
            lblUsername.Text = UserSession.TenDangNhap ?? "N/A";
            lblRole.Text = UserSession.VaiTro ?? "N/A";
            lblLoginTime.Text = UserSession.LoginTime.ToString("dd/MM/yyyy HH:mm:ss");
        }
        #endregion

        #region Apply Mode
        private void ApplyMode()
        {
            //bool isDark = Mode.IsDarkMode;

            //// Panel
            //pnlMain.FillColor = Mode.GetBodyColor();

            //// Title
            //lblTitle.ForeColor = isDark
            //    ? Color.FromArgb(0, 200, 150)
            //    : Color.FromArgb(0, 70, 67);

            //// Labels
            //Color labelColor = Mode.GetForeColor();
            //lblUserNameLabel.ForeColor = labelColor;
            //lblUserName.ForeColor = labelColor;
            //lblUsernameLabel.ForeColor = labelColor;
            //lblUsername.ForeColor = labelColor;
            //lblRoleLabel.ForeColor = labelColor;
            //lblLoginLabel.ForeColor = labelColor;
            //lblLoginTime.ForeColor = labelColor;

            //// Separator
            //separator.BackColor = isDark
            //    ? Color.FromArgb(60, 60, 60)
            //    : Color.FromArgb(230, 230, 230);

            //// Close button
            //btnClose.FillColor = isDark
            //    ? Color.FromArgb(60, 60, 60)
            //    : Color.FromArgb(220, 220, 220);
            //btnClose.ForeColor = isDark
            //    ? Color.White
            //    : Color.FromArgb(60, 60, 60);

            //this.BackColor = Mode.GetBodyColor();
        }
        #endregion

        #region Event Handlers
        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            using (var changePasswordForm = new ChangePasswordForm())
            {
                // Subscribe to password changed event
                changePasswordForm.PasswordChanged += OnPasswordChanged;

                var result = changePasswordForm.ShowDialog();

                // Unsubscribe
                changePasswordForm.PasswordChanged -= OnPasswordChanged;
            }
        }

        private void OnPasswordChanged(object sender, EventArgs e)
        {
            // Clear session
            UserSession.Clear();

            // Show message
            MessageBox.Show(
                "Đổi mật khẩu thành công!\n\nVì lý do bảo mật, bạn cần đăng nhập lại với mật khẩu mới.",
                "Đổi mật khẩu thành công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Close this form first
            this.Close();

            // Restart application to go back to login
            Application.Restart();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}