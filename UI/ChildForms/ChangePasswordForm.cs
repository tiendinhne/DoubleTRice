using DoubleTRice.LOGIC;
using DoubleTRice.UI.BASE;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    public partial class ChangePasswordForm : Form
    {
        #region Event
        /// <summary>
        /// Event được raise khi đổi mật khẩu thành công
        /// </summary>
        public event EventHandler PasswordChanged;

        /// <summary>
        /// Raise PasswordChanged event
        /// </summary>
        protected virtual void OnPasswordChanged()
        {
            PasswordChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Constructor
        public ChangePasswordForm()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Hide error initially
            lblError.Visible = false;

            // Apply mode colors
            ApplyMode();

            // Focus on old password
            txtOldPassword.Focus();

            // Wire up text changed events to hide error
            txtOldPassword.TextChanged += TxtPassword_TextChanged;
            txtNewPassword.TextChanged += TxtPassword_TextChanged;
            txtConfirmPassword.TextChanged += TxtPassword_TextChanged;

            // Wire up button events
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void ApplyMode()
        {
            bool isDark = Mode.IsDarkMode;

            // Panel
            pnlMain.FillColor = Mode.GetBodyColor();

            // Title
            lblTitle.ForeColor = isDark
                ? Color.FromArgb(0, 200, 150)
                : Color.FromArgb(0, 150, 120);

            // Labels
            Color labelColor = Mode.GetForeColor();
            lblOldPassword.ForeColor = labelColor;
            lblNewPassword.ForeColor = labelColor;
            lblConfirmPassword.ForeColor = labelColor;

            // TextBoxes
            Color textBoxBg = isDark ? Color.FromArgb(40, 40, 40) : Color.White;
            Color textBoxFore = Mode.GetForeColor();

            txtOldPassword.FillColor = textBoxBg;
            txtOldPassword.ForeColor = textBoxFore;
            txtNewPassword.FillColor = textBoxBg;
            txtNewPassword.ForeColor = textBoxFore;
            txtConfirmPassword.FillColor = textBoxBg;
            txtConfirmPassword.ForeColor = textBoxFore;

            this.BackColor = Mode.GetBodyColor();
        }
        #endregion

        #region Event Handlers
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            // Get values
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;

            // Show loading
            btnSave.Text = "Đang xử lý...";
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // GỌI LOGIC SERVICE
                var result = AuthenticationService.ChangePassword(
                    UserSession.UserID,
                    oldPassword,
                    newPassword
                );

                if (result.Success)
                {
                    // ✅ RAISE EVENT trước khi đóng form
                    OnPasswordChanged();

                    // Set DialogResult và đóng form
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ShowError(result.Message);
                    txtNewPassword.Clear();
                    txtConfirmPassword.Clear();
                    txtOldPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi hệ thống: {ex.Message}");
            }
            finally
            {
                btnSave.Text = "💾 Lưu thay đổi";
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            HideError();
        }
        #endregion

        #region Validation
        private bool ValidateInputs()
        {
            // Check empty
            if (string.IsNullOrWhiteSpace(txtOldPassword.Text))
            {
                ShowError("⚠️ Vui lòng nhập mật khẩu hiện tại");
                txtOldPassword.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                ShowError("⚠️ Vui lòng nhập mật khẩu mới");
                txtNewPassword.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                ShowError("⚠️ Vui lòng nhập lại mật khẩu mới");
                txtConfirmPassword.Focus();
                return false;
            }

            // Validate password rules
            if (!PasswordHelper.ValidatePassword(txtNewPassword.Text, out string error))
            {
                ShowError($"⚠️ {error}");
                txtNewPassword.Focus();
                return false;
            }

            // Check password match
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                ShowError("⚠️ Mật khẩu mới và nhập lại không khớp");
                txtConfirmPassword.Focus();
                return false;
            }

            // Check new password != old password
            if (txtOldPassword.Text == txtNewPassword.Text)
            {
                ShowError("⚠️ Mật khẩu mới không được trùng với mật khẩu hiện tại");
                txtNewPassword.Focus();
                return false;
            }

            HideError();
            return true;
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
            lblError.ForeColor = Color.FromArgb(220, 53, 69); // Red color
        }

        private void HideError()
        {
            lblError.Visible = false;
        }
        #endregion

        #region Designer Event Handlers (Keep for compatibility)
        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            HideError();
        }

        private void lblConfirmPassword_Click(object sender, EventArgs e)
        {
            // Empty - designer event
        }
        #endregion
    }
}