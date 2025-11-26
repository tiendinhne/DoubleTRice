using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DoubleTRice.DAO;
using DoubleTRice.DT;

namespace DoubleTRice.UI.ChildForms
{
    public partial class CustomerManagementUI : BaseChildForm
    {
        #region Fields
        private List<Customers> allCustomers;
        private Customers selectedCustomer;
        #endregion

        #region Constructor
        public CustomerManagementUI()
        {
            InitializeComponent();
            LoadData();
        }
        #endregion

        #region Load Data
        private void LoadData()
        {
            try
            {
                dgvCustomers.DataSource = null;
                this.Cursor = Cursors.WaitCursor;

                allCustomers = CustomerDAO.Instance.GetAllCustomers();
                DisplayCustomers(allCustomers);

                lblTotalCustomers.Text = $"Tổng: {allCustomers.Count} khách hàng";
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

        private void DisplayCustomers(List<Customers> customers)
        {
            dgvCustomers.Rows.Clear();

            foreach (var c in customers)
            {
                dgvCustomers.Rows.Add(
                    c.CustomerID,
                    c.TenKhachHang,
                    c.SoDienThoai ?? "",
                    c.DiaChi ?? ""
                );
            }
        }
        #endregion

        #region Event Handlers - Search
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterCustomers();
        }

        private void FilterCustomers()
        {
            if (allCustomers == null) return;

            string searchText = txtSearch.Text.ToLower().Trim();

            var filteredCustomers = allCustomers.Where(c =>
                c.TenKhachHang.ToLower().Contains(searchText) ||
                (c.SoDienThoai ?? "").ToLower().Contains(searchText) ||
                (c.DiaChi ?? "").ToLower().Contains(searchText)
            ).ToList();

            DisplayCustomers(filteredCustomers);
            lblTotalCustomers.Text = $"Tổng: {filteredCustomers.Count} khách hàng";
        }
        #endregion

        #region Event Handlers - Buttons
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new CustomerAddEditDialog();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                MessageBox.Show("Thêm khách hàng thành công!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadData();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng xuất Excel đang được phát triển",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Event Handlers - DataGridView
        private void DgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int customerID = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["colCustomerID"].Value);
            selectedCustomer = allCustomers.FirstOrDefault(c => c.CustomerID == customerID);

            if (selectedCustomer == null) return;

            if (dgvCustomers.Columns[e.ColumnIndex].Name == "colActions")
            {
                ShowActionsMenu(e.RowIndex);
            }
        }

        private void ShowActionsMenu(int rowIndex)
        {
            if (selectedCustomer == null) return;

            var menu = new ContextMenuStrip();

            // Sửa
            var editItem = new ToolStripMenuItem("✏️ Sửa thông tin");
            editItem.Click += (s, e) => EditCustomer();
            menu.Items.Add(editItem);

            menu.Items.Add(new ToolStripSeparator());

            // Xóa (không cho xóa Khách vãng lai)
            if (selectedCustomer.TenKhachHang != "Khách vãng lai")
            {
                var deleteItem = new ToolStripMenuItem("🗑️ Xóa khách hàng");
                deleteItem.Click += (s, e) => DeleteCustomer();
                deleteItem.ForeColor = Color.Red;
                menu.Items.Add(deleteItem);
            }

            var cellRect = dgvCustomers.GetCellDisplayRectangle(
                dgvCustomers.Columns["colActions"].Index, rowIndex, true);
            menu.Show(dgvCustomers, cellRect.Left, cellRect.Bottom);
        }

        private void DgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditCustomer();
            }
        }
        #endregion

        #region CRUD Operations
        private void EditCustomer()
        {
            if (selectedCustomer == null) return;

            var editForm = new CustomerAddEditDialog(selectedCustomer);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                MessageBox.Show("Cập nhật khách hàng thành công!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteCustomer()
        {
            if (selectedCustomer == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khách hàng '{selectedCustomer.TenKhachHang}'?\n\n" +
                "Lưu ý: Không thể xóa khách hàng đã có hóa đơn!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                int deleteResult = CustomerDAO.Instance.DeleteCustomer(selectedCustomer.CustomerID);

                if (deleteResult == 0)
                {
                    MessageBox.Show("Xóa khách hàng thành công!",
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
        #endregion

        #region Helper Methods
        private string GetErrorMessage(int resultCode)
        {
            switch (resultCode)
            {
                case -1: return "Khách hàng không tồn tại";
                case -2: return "Tên không được để trống";
                case -3: return "Tên khách hàng đã tồn tại";
                case -4: return "Không thể xóa khách hàng đã có giao dịch";
                case -5: return "Không thể sửa/xóa Khách vãng lai";
                case -99: return "Lỗi hệ thống";
                default: return "Lỗi không xác định";
            }
        }
        #endregion
    }
}