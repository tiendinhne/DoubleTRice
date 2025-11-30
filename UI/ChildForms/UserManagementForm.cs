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
    public partial class UserManagementForm : BaseChildForm
    {
        #region Fields
        private List<Users> allUsers;
        private Users selectedUser;
        #endregion

        //contructor
        public UserManagementForm()
        {
            InitializeComponent();
            this.Load += UserManagementForm_Load;
        }
        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            CheckAdminPermission();
            // VÔ HIỆU HÓA INLINE EDITING
            dgvUsers.ReadOnly = true;  // Ngăn chặn edit trực tiếp
            dgvUsers.EditMode = DataGridViewEditMode.EditProgrammatically;
            // NGĂN DOUBLE CLICK ĐỂ EDIT
            dgvUsers.CellDoubleClick += (s, args) =>
            {
                if (args.RowIndex >= 0)
                {
                    // Có thể mở form edit nếu muốn
                    // EditUser();
                }
            };
            LoadData();
        }
        private void CheckAdminPermission()
        {
            if (!UserSession.IsAdmin())
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!",
                    "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        //load ddata
        private void LoadData()
        {
            try
            {
                // Show loading
                dgvUsers.DataSource = null;
                this.Cursor = Cursors.WaitCursor;
                allUsers = UserDAO.Instance.GetAllUsersAdmin();

                // THÊM KIỂM TRA NÀY
                if (allUsers == null || allUsers.Count == 0)
                {
                    dgvUsers.Rows.Clear();
                    // Có thể thêm thông báo nếu cần
                    return;
                }
                // Bind to DataGridView
                DisplayUsers(allUsers);

                // Format cells
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void DisplayUsers(List<Users> users)
        {
            dgvUsers.Rows.Clear();

            foreach (var user in users)
            {
                int rowIndex = dgvUsers.Rows.Add(
                    user.UserID,
                    user.HoTen,
                    user.TenDangNhap,
                    user.VaiTro,
                    user.IsLocked ? "🔒 Khóa" : "✅ Hoạt động",
                    user.FailedLoginAttempts,
                    user.LastLoginDate?.ToString("dd/MM/yyyy HH:mm") ?? "Chưa đăng nhập",
                    user.CreatedDate?.ToString("dd/MM/yyyy")
                );

                // Highlight locked users
                if (user.IsLocked)
                {
                    dgvUsers.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220);
                    dgvUsers.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                }
            }
        }
        private void FormatDataGridView()
        {
            // Center align cho các cột số
            colUserID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colIsLocked.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colFailedAttempts.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        #region Event Handlers - Search & Filter
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterUsers();
        }

        private void CboRoleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterUsers();
        }

        private void FilterUsers()
        {
            if (allUsers == null) return;

            string searchText = txtSearch.Text.ToLower().Trim();
            string selectedRole = cboRoleFilter.SelectedItem?.ToString();

            var filteredUsers = allUsers.Where(u =>
            {
                // Filter by search text
                bool matchSearch = string.IsNullOrEmpty(searchText) ||
                    u.HoTen.ToLower().Contains(searchText) ||
                    u.TenDangNhap.ToLower().Contains(searchText);

                // Filter by role
                bool matchRole = selectedRole == "Tất cả vai trò" ||
                    string.IsNullOrEmpty(selectedRole) ||
                    u.VaiTro == selectedRole;

                return matchSearch && matchRole;
            }).ToList();

            DisplayUsers(filteredUsers);
        }
        #endregion

        #region Event Handlers - Buttons
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new UserAddEditDialog();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                MessageBox.Show("Thêm người dùng thành công!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboRoleFilter.SelectedIndex = 0;
            LoadData();
        }
        #endregion

        #region Event Handlers - DataGridView
        private void DgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Get selected user
            int userID = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["colUserID"].Value);
            selectedUser = allUsers.FirstOrDefault(u => u.UserID == userID);

            if (selectedUser == null) return;

            // Check if clicked on Actions column
            if (dgvUsers.Columns[e.ColumnIndex].Name == "colActions")
            {
                ShowActionsMenu(e.RowIndex);
            }
        }

        private void ShowActionsMenu(int rowIndex)
        {
            if (selectedUser == null) return;

            var menu = new ContextMenuStrip();

            // Edit
            var editItem = new ToolStripMenuItem("✏️ Sửa thông tin");
            editItem.Click += (s, e) => EditUser();
            menu.Items.Add(editItem);

            // Reset Password
            var resetItem = new ToolStripMenuItem("🔑 Đặt lại mật khẩu");
            resetItem.Click += (s, e) => ResetPassword();
            menu.Items.Add(resetItem);

            // Lock/Unlock
            if (selectedUser.IsLocked)
            {
                var unlockItem = new ToolStripMenuItem("🔓 Mở khóa tài khoản");
                unlockItem.Click += (s, e) => ToggleLock(false);
                menu.Items.Add(unlockItem);
            }
            else
            {
                var lockItem = new ToolStripMenuItem("🔒 Khóa tài khoản");
                lockItem.Click += (s, e) => ToggleLock(true);
                menu.Items.Add(lockItem);
            }

            menu.Items.Add(new ToolStripSeparator());

            // Delete
            var deleteItem = new ToolStripMenuItem("🗑️ Xóa người dùng");
            deleteItem.Click += (s, e) => DeleteUser();
            deleteItem.ForeColor = Color.Red;
            menu.Items.Add(deleteItem);

            // Show menu
            var cellRect = dgvUsers.GetCellDisplayRectangle(dgvUsers.Columns["colActions"].Index, rowIndex, true);
            menu.Show(dgvUsers, cellRect.Left, cellRect.Bottom);
        }

        //private void DgvUsers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    // Inline editing - tự động save khi edit xong
        //    if (e.RowIndex < 0) return;

        //    try
        //    {
        //        int userID = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["colUserID"].Value);
        //        string hoTen = dgvUsers.Rows[e.RowIndex].Cells["colHoTen"].Value?.ToString();
        //        string tenDangNhap = dgvUsers.Rows[e.RowIndex].Cells["colTenDangNhap"].Value?.ToString();
        //        string vaiTro = dgvUsers.Rows[e.RowIndex].Cells["colVaiTro"].Value?.ToString();

        //        // Validate
        //        if (string.IsNullOrWhiteSpace(hoTen) ||
        //            string.IsNullOrWhiteSpace(tenDangNhap) ||
        //            string.IsNullOrWhiteSpace(vaiTro))
        //        {
        //            MessageBox.Show("Vui lòng điền đầy đủ thông tin!",
        //                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            LoadData(); // Rollback
        //            return;
        //        }

        //        // Update
        //        int result = UserDAO.Instance.UpdateUser(userID, hoTen, tenDangNhap, vaiTro);

        //        if (result == 0)
        //        {
        //            MessageBox.Show("Cập nhật thành công!",
        //                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            LoadData();
        //        }
        //        else
        //        {
        //            MessageBox.Show(GetErrorMessage(result),
        //                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            LoadData(); // Rollback
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi: {ex.Message}",
        //            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        LoadData();
        //    }
        //}
        #endregion

        #region CRUD Operations
        private void EditUser()
        {
            if (selectedUser == null) return;

            var editForm = new UserAddEditDialog(selectedUser);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                MessageBox.Show("Cập nhật thông tin thành công!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteUser()
        {
            if (selectedUser == null) return;

            // Không cho xóa chính mình
            if (selectedUser.UserID == UserSession.UserID)
            {
                MessageBox.Show("Bạn không thể xóa chính mình!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa người dùng '{selectedUser.HoTen}'?\n\n" +
                "Hành động này không thể hoàn tác!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                int deleteResult = UserDAO.Instance.DeleteUser(selectedUser.UserID);

                if (deleteResult == 0)
                {
                    MessageBox.Show("Xóa người dùng thành công!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show(GetErrorMessage(deleteResult),
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ResetPassword()
        {
            if (selectedUser == null) return;

            var resetForm = new ResetPasswordDialog(selectedUser);
            if (resetForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Đặt lại mật khẩu thành công!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ToggleLock(bool isLocked)
        {
            if (selectedUser == null) return;

            // Không cho lock chính mình
            if (selectedUser.UserID == UserSession.UserID)
            {
                MessageBox.Show("Bạn không thể khóa chính mình!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string action = isLocked ? "khóa" : "mở khóa";
            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn {action} tài khoản '{selectedUser.HoTen}'?",
                $"Xác nhận {action}",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                int toggleResult = UserDAO.Instance.ToggleLockUser(selectedUser.UserID, isLocked);

                if (toggleResult == 0)
                {
                    MessageBox.Show($"{(isLocked ? "Khóa" : "Mở khóa")} tài khoản thành công!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show(GetErrorMessage(toggleResult),
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Helper Methods
        private string GetErrorMessage(int resultCode)
        {
            switch (resultCode)
            {
                case -1: return "Người dùng không tồn tại";
                case -2: return "Tên đăng nhập đã tồn tại";
                case -3: return "Không thể xóa người dùng cuối cùng";
                case -99: return "Lỗi hệ thống";
                default: return "Lỗi không xác định";
            }
        }
        #endregion

    }
}
