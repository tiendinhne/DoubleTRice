using DoubleTRice.DAO;
using DoubleTRice.DT;
using DoubleTRice.LOGIC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    public partial class UserAddEditDialog : Form
    {
        #region Fields
        private Users editingUser;
        private bool isEditMode;
        #endregion
        public UserAddEditDialog( Users user = null)
        {
            InitializeComponent();
            editingUser = user;
            isEditMode = (user != null);

            LoadRoles();

            if (isEditMode)
            {
                LoadUserData();
                lblTitle.Text = "✏️ Sửa thông tin người dùng";
                txtPassword.Enabled = false;
                txtConfirmPassword.Enabled = false;
                lblPasswordNote.Text = "(Không thể đổi mật khẩu ở đây. Dùng chức năng 'Đặt lại mật khẩu')";
            }
            else
            {
                lblTitle.Text = "➕ Thêm người dùng mới";
                lblPasswordNote.Text = "(Mật khẩu mặc định: 123456)";
            }
        }

        #region Methods
        private void LoadRoles()
        {
            cboVaiTro.Items.Clear();
            cboVaiTro.Items.AddRange(new object[] { "Admin", "Thu Ngân", "Thủ Kho", "Kế Toán" });
            cboVaiTro.SelectedIndex = 1; // Default: Thu Ngân
        }

        private void LoadUserData()
        {
            if (editingUser == null) return;

            txtHoTen.Text = editingUser.HoTen;
            txtTenDangNhap.Text = editingUser.TenDangNhap;
            cboVaiTro.SelectedItem = editingUser.VaiTro;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            this.Cursor = Cursors.WaitCursor;
            btnSave.Enabled = false;

            try
            {
                string hoTen = txtHoTen.Text.Trim();
                string tenDangNhap = txtTenDangNhap.Text.Trim();
                string vaiTro = cboVaiTro.SelectedItem.ToString();

                if (isEditMode)
                {
                    // UPDATE
                    int result = UserDAO.Instance.UpdateUser(editingUser.UserID, hoTen, tenDangNhap, vaiTro);

                    if (result == 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ShowError(GetErrorMessage(result));
                    }
                }
                else
                {
                    // INSERT
                    string password = txtPassword.Text;
                    string passwordHash = PasswordHelper.HashPassword(password);

                    var (result, newUserID) = UserDAO.Instance.InsertUser(hoTen, tenDangNhap, passwordHash, vaiTro);

                    if (result == 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ShowError(GetErrorMessage(result));
                    }
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

        private bool ValidateInputs()
        {
            // Họ tên
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                ShowError("Vui lòng nhập họ và tên");
                txtHoTen.Focus();
                return false;
            }

            // Tên đăng nhập
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                ShowError("Vui lòng nhập tên đăng nhập");
                txtTenDangNhap.Focus();
                return false;
            }

            // Vai trò
            if (cboVaiTro.SelectedIndex < 0)
            {
                ShowError("Vui lòng chọn vai trò");
                cboVaiTro.Focus();
                return false;
            }

            // Password (chỉ khi thêm mới)
            if (!isEditMode)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    ShowError("Vui lòng nhập mật khẩu");
                    txtPassword.Focus();
                    return false;
                }

                if (!PasswordHelper.ValidatePassword(txtPassword.Text, out string error))
                {
                    ShowError(error);
                    txtPassword.Focus();
                    return false;
                }

                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    ShowError("Mật khẩu nhập lại không khớp");
                    txtConfirmPassword.Focus();
                    return false;
                }
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
                case -2: return "Tên đăng nhập đã tồn tại";
                case -99: return "Lỗi hệ thống";
                default: return "Lỗi không xác định";
            }
        }
        #endregion
    }
}
