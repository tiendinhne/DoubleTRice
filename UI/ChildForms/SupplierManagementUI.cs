using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DoubleTRice.DAO;
using DoubleTRice.DT;

namespace DoubleTRice.UI.ChildForms
{
    public partial class SupplierManagementUI : BaseChildForm
    {
        #region Fields
        private List<Suppliers> allSuppliers;
        private Suppliers selectedSupplier;
        #endregion

        #region Constructor
        public SupplierManagementUI()
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
                dgvSuppliers.DataSource = null;
                this.Cursor = Cursors.WaitCursor;

                allSuppliers = SupplierDAO.Instance.GetAllSuppliers();
                DisplaySuppliers(allSuppliers);

                lblTotalSuppliers.Text = $"Tổng: {allSuppliers.Count} nhà cung cấp";
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

        private void DisplaySuppliers(List<Suppliers> suppliers)
        {
            dgvSuppliers.Rows.Clear();

            foreach (var s in suppliers)
            {
                dgvSuppliers.Rows.Add(
                    s.SupplierID,
                    s.TenNhaCungCap,
                    s.SoDienThoai ?? "",
                    s.DiaChi ?? ""
                );
            }
        }
        #endregion

        #region Event Handlers - Search
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterSuppliers();
        }

        private void FilterSuppliers()
        {
            if (allSuppliers == null) return;

            string searchText = txtSearch.Text.ToLower().Trim();

            var filteredSuppliers = allSuppliers.Where(s =>
                s.TenNhaCungCap.ToLower().Contains(searchText) ||
                (s.SoDienThoai ?? "").ToLower().Contains(searchText) ||
                (s.DiaChi ?? "").ToLower().Contains(searchText)
            ).ToList();

            DisplaySuppliers(filteredSuppliers);
            lblTotalSuppliers.Text = $"Tổng: {filteredSuppliers.Count} nhà cung cấp";
        }
        #endregion

        #region Event Handlers - Buttons
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new SupplierAddEditDialog();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                MessageBox.Show("Thêm nhà cung cấp thành công!",
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
        private void DgvSuppliers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int supplierID = Convert.ToInt32(dgvSuppliers.Rows[e.RowIndex].Cells["colSupplierID"].Value);
            selectedSupplier = allSuppliers.FirstOrDefault(s => s.SupplierID == supplierID);

            if (selectedSupplier == null) return;

            if (dgvSuppliers.Columns[e.ColumnIndex].Name == "colActions")
            {
                ShowActionsMenu(e.RowIndex);
            }
        }

        private void ShowActionsMenu(int rowIndex)
        {
            if (selectedSupplier == null) return;

            var menu = new ContextMenuStrip();

            // Sửa
            var editItem = new ToolStripMenuItem("✏️ Sửa thông tin");
            editItem.Click += (s, e) => EditSupplier();
            menu.Items.Add(editItem);

            menu.Items.Add(new ToolStripSeparator());

            // Xóa
            var deleteItem = new ToolStripMenuItem("🗑️ Xóa nhà cung cấp");
            deleteItem.Click += (s, e) => DeleteSupplier();
            deleteItem.ForeColor = Color.Red;
            menu.Items.Add(deleteItem);

            var cellRect = dgvSuppliers.GetCellDisplayRectangle(
                dgvSuppliers.Columns["colActions"].Index, rowIndex, true);
            menu.Show(dgvSuppliers, cellRect.Left, cellRect.Bottom);
        }

        private void DgvSuppliers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditSupplier();
            }
        }
        #endregion

        #region CRUD Operations
        private void EditSupplier()
        {
            if (selectedSupplier == null) return;

            var editForm = new SupplierAddEditDialog(selectedSupplier);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                MessageBox.Show("Cập nhật nhà cung cấp thành công!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteSupplier()
        {
            if (selectedSupplier == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa nhà cung cấp '{selectedSupplier.TenNhaCungCap}'?\n\n" +
                "Lưu ý: Không thể xóa nhà cung cấp đã có phiếu nhập!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                int deleteResult = SupplierDAO.Instance.DeleteSupplier(selectedSupplier.SupplierID);

                if (deleteResult == 0)
                {
                    MessageBox.Show("Xóa nhà cung cấp thành công!",
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
                case -1: return "Nhà cung cấp không tồn tại";
                case -2: return "Tên không được để trống";
                case -3: return "Tên nhà cung cấp đã tồn tại";
                case -4: return "Không thể xóa nhà cung cấp đã có giao dịch";
                case -99: return "Lỗi hệ thống";
                default: return "Lỗi không xác định";
            }
        }
        #endregion
    }
}