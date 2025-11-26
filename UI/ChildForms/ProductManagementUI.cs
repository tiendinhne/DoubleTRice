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

namespace DoubleTRice.UI.ChildForms
{
    public partial class ProductManagementUI : BaseChildForm
    {
        #region Fields
        private List<Products> allProducts;
        private Products selectedProduct;
        #endregion

        #region Constructor
        public ProductManagementUI()
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
                dgvProducts.DataSource = null;
                this.Cursor = Cursors.WaitCursor;

                allProducts = ProductDAO.Instance.GetAllProductsDetail();
                DisplayProducts(allProducts);
                FormatDataGridView();

                lblTotalProducts.Text = $"Tổng: {allProducts.Count} sản phẩm";
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

        private void DisplayProducts(List<Products> products)
        {
            dgvProducts.Rows.Clear();

            foreach (var p in products)
            {
                int rowIndex = dgvProducts.Rows.Add(
                    p.ProductID,
                    p.TenSanPham,
                    p.BaseUnitName,
                    p.TonKhoToiThieu,
                    p.SoLuongTon,
                    p.TrangThaiTonKho
                );

                // Highlight theo trạng thái
                var row = dgvProducts.Rows[rowIndex];
                switch (p.TrangThaiTonKho)
                {
                    case "Hết hàng":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220);
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                        break;
                    case "Sắp hết":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 220);
                        row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                        break;
                }
            }
        }

        private void FormatDataGridView()
        {
            colProductID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTonKhoToiThieu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colSoLuongTon.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colTrangThai.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        #endregion

        #region Event Handlers - Search & Filter
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void CboStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void FilterProducts()
        {
            if (allProducts == null) return;

            string searchText = txtSearch.Text.ToLower().Trim();
            string selectedStatus = cboStatusFilter.SelectedItem?.ToString();

            var filteredProducts = allProducts.Where(p =>
            {
                bool matchSearch = string.IsNullOrEmpty(searchText) ||
                    p.TenSanPham.ToLower().Contains(searchText);

                bool matchStatus = selectedStatus == "Tất cả" ||
                    string.IsNullOrEmpty(selectedStatus) ||
                    p.TrangThaiTonKho == selectedStatus;

                return matchSearch && matchStatus;
            }).ToList();

            DisplayProducts(filteredProducts);
            lblTotalProducts.Text = $"Tổng: {filteredProducts.Count} sản phẩm";
        }
        #endregion

        #region Event Handlers - Buttons
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new ProductAddEditDialog();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                MessageBox.Show("Thêm sản phẩm thành công!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboStatusFilter.SelectedIndex = 0;
            LoadData();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng xuất Excel đang được phát triển",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Event Handlers - DataGridView
        private void DgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int productID = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["colProductID"].Value);
            selectedProduct = allProducts.FirstOrDefault(p => p.ProductID == productID);

            if (selectedProduct == null) return;

            if (dgvProducts.Columns[e.ColumnIndex].Name == "colActions")
            {
                ShowActionsMenu(e.RowIndex);
            }
        }

        private void ShowActionsMenu(int rowIndex)
        {
            if (selectedProduct == null) return;

            var menu = new ContextMenuStrip();

            // Sửa
            var editItem = new ToolStripMenuItem("✏️ Sửa thông tin");
            editItem.Click += (s, e) => EditProduct();
            menu.Items.Add(editItem);

            // Quản lý đơn vị tính
            var unitItem = new ToolStripMenuItem("📦 Quản lý đơn vị tính");
            unitItem.Click += (s, e) => ManageUnitConversions();
            menu.Items.Add(unitItem);

            menu.Items.Add(new ToolStripSeparator());

            // Xóa
            var deleteItem = new ToolStripMenuItem("🗑️ Xóa sản phẩm");
            deleteItem.Click += (s, e) => DeleteProduct();
            deleteItem.ForeColor = Color.Red;
            menu.Items.Add(deleteItem);

            var cellRect = dgvProducts.GetCellDisplayRectangle(
                dgvProducts.Columns["colActions"].Index, rowIndex, true);
            menu.Show(dgvProducts, cellRect.Left, cellRect.Bottom);
        }

        private void DgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditProduct();
            }
        }
        #endregion

        #region CRUD Operations
        private void EditProduct()
        {
            if (selectedProduct == null) return;

            var editForm = new ProductAddEditDialog(selectedProduct);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                MessageBox.Show("Cập nhật sản phẩm thành công!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteProduct()
        {
            if (selectedProduct == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sản phẩm '{selectedProduct.TenSanPham}'?\n\n" +
                "Lưu ý: Không thể xóa sản phẩm đã có giao dịch!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                int deleteResult = ProductDAO.Instance.DeleteProduct(selectedProduct.ProductID);

                if (deleteResult == 0)
                {
                    MessageBox.Show("Xóa sản phẩm thành công!",
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

        private void ManageUnitConversions()
        {
            if (selectedProduct == null) return;

            var unitForm = new UnitConversionDialog(selectedProduct.ProductID, selectedProduct.TenSanPham);
            unitForm.ShowDialog();
        }
        #endregion

        #region Helper Methods
        private string GetErrorMessage(int resultCode)
        {
            switch (resultCode)
            {
                case -1: return "Sản phẩm không tồn tại";
                case -2: return "Tên sản phẩm đã tồn tại";
                case -3: return "Đơn vị tính không tồn tại";
                case -4: return "Không thể xóa sản phẩm đã có giao dịch";
                case -99: return "Lỗi hệ thống";
                default: return "Lỗi không xác định";
            }
        }
        #endregion


    }
}
