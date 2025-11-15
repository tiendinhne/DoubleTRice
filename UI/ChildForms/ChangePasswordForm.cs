using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using DoubleTRice.DAO;
using DoubleTRice.LOGIC;


namespace DoubleTRice.UI.ChildForms
{
    public partial class ChangePasswordForm : Form
    {
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

            // Focus on old password
            txtOldPassword.Focus();
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
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // Hash passwords
                string oldPasswordHash = PasswordHelper.HashPassword(oldPassword);
                string newPasswordHash = PasswordHelper.HashPassword(newPassword);

                // Call DAO
                var result = UserDAO.Instance.ChangePassword(
                    UserSession.UserID,
                    oldPasswordHash,
                    newPasswordHash
                );

                if (result.Success)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ShowError(result.Message);
                }
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi: {ex.Message}");
            }
            finally
            {
                btnSave.Text = "💾 Lưu thay đổi";
                btnSave.Enabled = true;
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
                ShowError("Vui lòng nhập mật khẩu cũ");
                txtOldPassword.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                ShowError("Vui lòng nhập mật khẩu mới");
                txtNewPassword.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                ShowError("Vui lòng nhập lại mật khẩu mới");
                txtConfirmPassword.Focus();
                return false;
            }

            // Validate password rules
            if (!PasswordHelper.ValidatePassword(txtNewPassword.Text, out string error))
            {
                ShowError(error);
                txtNewPassword.Focus();
                return false;
            }

            // Check password match
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                ShowError("Mật khẩu mới và nhập lại không khớp");
                txtConfirmPassword.Focus();
                return false;
            }

            // Check new password != old password
            if (txtOldPassword.Text == txtNewPassword.Text)
            {
                ShowError("Mật khẩu mới không được trùng với mật khẩu cũ");
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
        }

        private void HideError()
        {
            lblError.Visible = false;
        }
        #endregion
    }
}
