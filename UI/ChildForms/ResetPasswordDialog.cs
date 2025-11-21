using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoubleTRice.DAO;
using DoubleTRice.DT;
using DoubleTRice.LOGIC;

namespace DoubleTRice.UI.ChildForms
{

    public partial class ResetPasswordDialog : Form
    {
        #region Fields
        private Users targetUser;
        #endregion
        public ResetPasswordDialog( Users user)
        {
            InitializeComponent();
            targetUser = user;
            lblUserInfo.Text = $"Đặt lại mật khẩu cho: {user.HoTen} ({user.TenDangNhap})";
        }

        #region Event Handlers
        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            char passwordChar = chkShowPassword.Checked ? '\0' : '●';
            txtNewPassword.PasswordChar = passwordChar;
            txtConfirmPassword.PasswordChar = passwordChar;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            this.Cursor = Cursors.WaitCursor;
            btnSave.Enabled = false;

            try
            {
                string newPassword = txtNewPassword.Text;
                string newPasswordHash = PasswordHelper.HashPassword(newPassword);

                int result = UserDAO.Instance.ResetPasswordAdmin(targetUser.UserID, newPasswordHash);

                if (result == 0)
                {
                    MessageBox.Show(
                        $"Đã đặt lại mật khẩu cho {targetUser.HoTen} thành công!\n\n" +
                        $"Mật khẩu mới: {newPassword}",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ShowError(GetErrorMessage(result));
                }
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi: {ex.Message}");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnSave.Enabled = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region Validation
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                ShowError("Vui lòng nhập mật khẩu mới");
                txtNewPassword.Focus();
                return false;
            }

            if (!PasswordHelper.ValidatePassword(txtNewPassword.Text, out string error))
            {
                ShowError(error);
                txtNewPassword.Focus();
                return false;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                ShowError("Mật khẩu nhập lại không khớp");
                txtConfirmPassword.Focus();
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

        private string GetErrorMessage(int resultCode)
        {
            switch (resultCode)
            {
                case -1: return "Người dùng không tồn tại";
                case -99: return "Lỗi hệ thống";
                default: return "Lỗi không xác định";
            }
        }
        #endregion
    }
}
