using DoubleTRice.DAO;
using DoubleTRice.DT;
using DoubleTRice.LOGIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    public partial class GoodsReceiptAddEditDialog : Form
    {
        #region Fields
        private List<Suppliers> allSuppliers;
        private List<Products> allProducts;
        private List<Units> allUnits;
        private List<GoodsReceiptDetailDisplay> receiptItems; // Danh sách hàng đang nhập (dùng cho hiển thị)
        private int currentUserID; // ID người dùng hiện tại
        #endregion

        #region Constructor
        public GoodsReceiptAddEditDialog()
        {
            InitializeComponent();
            InitializeData();
            currentUserID = UserSession.CurrentUser?.UserID ?? 0; // Lấy từ session
        }
        #endregion

        #region Initialize
        private void InitializeData()
        {
            receiptItems = new List<GoodsReceiptDetailDisplay>();

            // Load nhà cung cấp
            LoadSuppliers();

            // Load sản phẩm
            LoadProducts();

            // Set ngày hiện tại
            dtpNgayNhap.Value = DateTime.Now;
        }

        private void LoadSuppliers()
        {
            try
            {
                allSuppliers = SupplierDAO.Instance.GetAllSuppliers();
                cboSupplier.Items.Clear();
                cboSupplier.Items.Add("-- Chọn nhà cung cấp --");

                foreach (var supplier in allSuppliers)
                {
                    cboSupplier.Items.Add(supplier.TenNhaCungCap);
                }

                cboSupplier.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải nhà cung cấp: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            try
            {
                allProducts = ProductDAO.Instance.GetAllProductsDetail();
                cboProduct.Items.Clear();
                cboProduct.Items.Add("-- Chọn sản phẩm --");

                foreach (var product in allProducts)
                {
                    cboProduct.Items.Add(product.TenSanPham);
                }

                cboProduct.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải sản phẩm: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUnitsForProduct(int productID)
        {
            try
            {
                var conversions = ProductDAO.Instance.GetProductUnitConversions(productID);
                cboUnit.Items.Clear();
                cboUnit.Items.Add("-- Chọn đơn vị --");

                foreach (var conv in conversions)
                {
                    cboUnit.Items.Add(conv.UnitName);
                }

                cboUnit.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải đơn vị tính: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Event Handlers - Product Selection
        private void CboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduct.SelectedIndex <= 0) return;

            string productName = cboProduct.SelectedItem.ToString();
            var product = allProducts.FirstOrDefault(p => p.TenSanPham == productName);

            if (product != null)
            {
                LoadUnitsForProduct(product.ProductID);
            }
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            if (!ValidateProductInput()) return;

            try
            {
                // Lấy thông tin sản phẩm
                string productName = cboProduct.SelectedItem.ToString();
                var product = allProducts.FirstOrDefault(p => p.TenSanPham == productName);

                // Lấy thông tin đơn vị
                string unitName = cboUnit.SelectedItem.ToString();
                var conversion = ProductDAO.Instance.GetProductUnitConversions(product.ProductID)
                    .FirstOrDefault(u => u.UnitName == unitName);

                double soLuong = double.Parse(txtSoLuong.Text);
                decimal donGia = decimal.Parse(txtDonGia.Text);
                decimal thanhTien = (decimal)soLuong * donGia;

                // Kiểm tra sản phẩm đã có trong danh sách chưa
                var existingItem = receiptItems.FirstOrDefault(
                    i => i.ProductID == product.ProductID && i.UnitID == conversion.UnitID);

                if (existingItem != null)
                {
                    // Cập nhật số lượng
                    existingItem.SoLuong += soLuong;
                    existingItem.ThanhTien = (decimal)existingItem.SoLuong * existingItem.DonGiaNhap;
                }
                else
                {
                    // Thêm mới
                    receiptItems.Add(new GoodsReceiptDetailDisplay
                    {
                        ProductID = product.ProductID,
                        ProductName = product.TenSanPham,
                        UnitID = conversion.UnitID,
                        UnitName = unitName,
                        SoLuong = soLuong,
                        DonGiaNhap = donGia,
                        ThanhTien = thanhTien
                    });
                }

                // Refresh danh sách
                DisplayReceiptItems();
                ClearProductInputs();
                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm sản phẩm: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayReceiptItems()
        {
            dgvItems.Rows.Clear();

            foreach (var item in receiptItems)
            {
                dgvItems.Rows.Add(
                    item.ProductName,
                    item.UnitName,
                    item.SoLuong,
                    item.DonGiaNhap.ToString("N0"),
                    (item.ThanhTien ?? 0).ToString("N0")
                );
            }
        }

        private void ClearProductInputs()
        {
            cboProduct.SelectedIndex = 0;
            cboUnit.Items.Clear();
            cboUnit.Items.Add("-- Chọn đơn vị --");
            cboUnit.SelectedIndex = 0;
            txtSoLuong.Clear();
            txtDonGia.Clear();
        }

        private void CalculateTotal()
        {
            decimal total = receiptItems.Sum(i => i.ThanhTien ?? 0);
            lblTotal.Text = $"Tổng tiền: {total:N0} đ";
        }
        #endregion

        #region Event Handlers - DataGridView
        private void DgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvItems.Columns[e.ColumnIndex].Name == "colDelete")
            {
                var result = MessageBox.Show(
                    "Bạn có chắc muốn xóa sản phẩm này khỏi phiếu nhập?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    receiptItems.RemoveAt(e.RowIndex);
                    DisplayReceiptItems();
                    CalculateTotal();
                }
            }
        }
        #endregion

        #region Event Handlers - Save/Cancel
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateReceipt()) return;

            this.Cursor = Cursors.WaitCursor;
            btnSave.Enabled = false;

            try
            {
                // Lấy thông tin
                string supplierName = cboSupplier.SelectedItem.ToString();
                var supplier = allSuppliers.FirstOrDefault(s => s.TenNhaCungCap == supplierName);
                DateTime ngayNhap = dtpNgayNhap.Value;
                string ghiChu = txtGhiChu.Text.Trim();

                // Tạo phiếu nhập
                var (result, newReceiptID) = GoodsReceiptDAO.Instance.InsertGoodsReceipt(
                    supplier.SupplierID, currentUserID, ngayNhap,
                    string.IsNullOrWhiteSpace(ghiChu) ? null : ghiChu);

                if (result != 0)
                {
                    ShowError("Lỗi tạo phiếu nhập!");
                    return;
                }

                // Thêm chi tiết - Chuyển đổi sang GoodsReceiptDetails
                foreach (var item in receiptItems)
                {
                    // Sử dụng class GoodsReceiptDetails đúng chuẩn
                    GoodsReceiptDAO.Instance.InsertGoodsReceiptDetail(
                        newReceiptID,
                        item.ProductID,
                        item.UnitID,
                        item.SoLuong,
                        item.DonGiaNhap);
                }

                // Cập nhật tổng tiền
                GoodsReceiptDAO.Instance.UpdateGoodsReceiptTotalAmount(newReceiptID);

                MessageBox.Show("Tạo phiếu nhập thành công!\nKho đã được cập nhật tự động.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi lưu phiếu nhập: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Save receipt error: {ex}");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnSave.Enabled = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (receiptItems.Count > 0)
            {
                var result = MessageBox.Show(
                    "Bạn có chắc muốn hủy? Dữ liệu đã nhập sẽ bị mất!",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No) return;
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region Validation
        private bool ValidateProductInput()
        {
            if (cboProduct.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboProduct.Focus();
                return false;
            }

            if (cboUnit.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboUnit.Focus();
                return false;
            }

            if (!double.TryParse(txtSoLuong.Text, out double soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số dương", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return false;
            }

            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá phải là số dương", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateReceipt()
        {
            if (cboSupplier.SelectedIndex <= 0)
            {
                ShowError("Vui lòng chọn nhà cung cấp");
                cboSupplier.Focus();
                return false;
            }

            if (receiptItems.Count == 0)
            {
                ShowError("Vui lòng thêm ít nhất 1 sản phẩm");
                cboProduct.Focus();
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

    #region Helper Classes
    /// <summary>
    /// Class để hiển thị thông tin sản phẩm trong DataGridView
    /// Chứa thêm thông tin tên sản phẩm và đơn vị để hiển thị
    /// </summary>
    public class GoodsReceiptDetailDisplay
    {
        // Các thuộc tính từ GoodsReceiptDetails
        public int ProductID { get; set; }
        public int UnitID { get; set; }
        public double SoLuong { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal? ThanhTien { get; set; }

        // Các thuộc tính bổ sung để hiển thị
        public string ProductName { get; set; }
        public string UnitName { get; set; }

        /// <summary>
        /// Chuyển đổi sang GoodsReceiptDetails để lưu vào database
        /// </summary>
        public GoodsReceiptDetails ToGoodsReceiptDetails(int receiptID)
        {
            return new GoodsReceiptDetails
            {
                ReceiptID = receiptID,
                ProductID = this.ProductID,
                UnitID = this.UnitID,
                SoLuong = this.SoLuong,
                DonGiaNhap = this.DonGiaNhap,
                ThanhTien = this.ThanhTien
            };
        }
    }
    #endregion
}