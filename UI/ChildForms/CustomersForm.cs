using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using DoubleTRice.UI.BASE;

namespace DoubleTRice.UI.ChildForms
{
    /// <summary>
    /// Form Quản lý Khách hàng
    /// </summary>
    public partial class CustomersForm : BaseChildForm
    {
        #region Constructor
        public CustomersForm()
        {
            InitializeComponent();
            LoadData();
        }
        #endregion

        #region Load Data
        private void LoadData()
        {
            // TODO: Load data from CustomerDAO
            //var customers = CustomerDAO.Instance.GetAllCustomers();
           // dgvCustomers.DataSource = customers;

            // Data mẫu để demo
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            dgvCustomers.Rows.Clear();
            dgvCustomers.Rows.Add("KH001", "Nguyễn Văn A", "0901234567", "123 Đường ABC, Q1, TP.HCM");
            dgvCustomers.Rows.Add("KH002", "Trần Thị B", "0912345678", "456 Đường XYZ, Q2, TP.HCM");
            dgvCustomers.Rows.Add("KH003", "Lê Văn C", "0923456789", "789 Đường DEF, Q3, TP.HCM");
            dgvCustomers.Rows.Add("KH004", "Phạm Thị D", "0934567890", "321 Đường GHI, Q4, TP.HCM");
            dgvCustomers.Rows.Add("KH005", "Hoàng Văn E", "0945678901", "654 Đường JKL, Q5, TP.HCM");
        }
        #endregion

        #region Event Handlers
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                // Hiển thị tất cả
                foreach (DataGridViewRow row in dgvCustomers.Rows)
                {
                    row.Visible = true;
                }
                return;
            }

            // Tìm kiếm trong tất cả các cột
            foreach (DataGridViewRow row in dgvCustomers.Rows)
            {
                bool visible = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(keyword))
                    {
                        visible = true;
                        break;
                    }
                }
                row.Visible = visible;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // TODO: Mở form thêm khách hàng
            // var addForm = new CustomerAddEditForm();
            // if (addForm.ShowDialog() == DialogResult.OK)
            // {
            //     LoadData();
            // }

            MessageBox.Show("Chức năng thêm khách hàng đang được phát triển",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: Mở form sửa khách hàng
            // var customerID = dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value.ToString();
            // var editForm = new CustomerAddEditForm(customerID);
            // if (editForm.ShowDialog() == DialogResult.OK)
            // {
            //     LoadData();
            // }

            MessageBox.Show("Chức năng sửa khách hàng đang được phát triển",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa khách hàng này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // TODO: Xóa khách hàng
                // var customerID = dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value.ToString();
                // if (CustomerDAO.Instance.DeleteCustomer(customerID))
                // {
                //     MessageBox.Show("Xóa thành công", "Thông báo", 
                //         MessageBoxButtons.OK, MessageBoxIcon.Information);
                //     LoadData();
                // }

                dgvCustomers.Rows.Remove(dgvCustomers.SelectedRows[0]);
                MessageBox.Show("Đã xóa khách hàng (demo)",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            txtSearch.Clear();
            MessageBox.Show("Đã làm mới dữ liệu",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            // TODO: Export to Excel
            MessageBox.Show("Chức năng xuất Excel đang được phát triển",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Double click để xem chi tiết hoặc sửa
                BtnEdit_Click(sender, e);
            }
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Lấy thông tin khách hàng đang chọn
        /// </summary>
        private string GetSelectedCustomerID()
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                return dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value?.ToString();
            }
            return null;
        }

        /// <summary>
        /// Làm nổi bật row được chọn
        /// </summary>
        private void HighlightSelectedRow()
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                dgvCustomers.FirstDisplayedScrollingRowIndex = dgvCustomers.SelectedRows[0].Index;
            }
        }
        #endregion
    }
}