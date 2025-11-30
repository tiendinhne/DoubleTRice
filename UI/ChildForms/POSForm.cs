using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DoubleTRice.DAO;
using DoubleTRice.DT;
using DoubleTRice.LOGIC;
using Guna.UI2.WinForms;

namespace DoubleTRice.UI.ChildForms
{
    public partial class POSForm : BaseChildForm
    {
        #region Fields
        private List<Products> allProducts;
        private List<Customers> allCustomers;
        private Customers selectedCustomer;
        private List<CartItem> cartItems;
        private int currentUserID;
        #endregion

        #region Constructor
        public POSForm()
        {
            InitializeComponent();
            Initialize();
        }
        #endregion

        #region Initialization
        private void Initialize()
        {
            cartItems = new List<CartItem>();
            currentUserID = UserSession.CurrentUser?.UserID ?? 0;

            LoadProducts();
            LoadCustomers();
            SetDefaultCustomer();
            UpdateSummary();
        }

        private void LoadProducts()
        {
            try
            {
                allProducts = ProductDAO.Instance.GetAllProductsDetail();
                DisplayProducts(allProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải sản phẩm: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCustomers()
        {
            try
            {
                allCustomers = CustomerDAO.Instance.GetAllCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải khách hàng: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDefaultCustomer()
        {
            // Khách vãng lai (CustomerID = 1)
            selectedCustomer = allCustomers?.FirstOrDefault(c => c.SoDienThoai == "000000000");
            if (selectedCustomer != null)
            {
                lblCustomerName.Text = $"✅ {selectedCustomer.TenKhachHang}";
                lblCustomerName.ForeColor = Color.FromArgb(0, 150, 120);
            }
        }

        private void DisplayProducts(List<Products> products)
        {
            flpProducts.Controls.Clear();

            foreach (var product in products)
            {
                var productCard = CreateProductCard(product);
                flpProducts.Controls.Add(productCard);
            }
        }

        private Guna2Button CreateProductCard(Products product)
        {
            var btn = new Guna2Button
            {
                Size = new Size(150, 80),
                Text = $"{product.TenSanPham}\n\nTồn: {product.SoLuongTon} {product.BaseUnitName}",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                FillColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                BorderRadius = 10,
                Margin = new Padding(5),
                Tag = product,
                TextAlign = HorizontalAlignment.Center
            };

            // Đổi màu nếu sắp hết hàng
            if (product.TrangThaiTonKho == "Sắp hết")
                btn.FillColor = Color.FromArgb(255, 152, 0);
            else if (product.TrangThaiTonKho == "Hết hàng")
                btn.FillColor = Color.FromArgb(220, 53, 69);

            btn.Click += (s, e) => SelectProduct(product);

            return btn;
        }
        #endregion

        #region Product Selection
        private void SelectProduct(Products product)
        {
            try
            {
                // Lấy danh sách đơn vị tính
                var conversions = ProductDAO.Instance.GetProductUnitConversions(product.ProductID);

                if (conversions.Count == 0)
                {
                    MessageBox.Show("Sản phẩm chưa có đơn vị tính!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Nếu chỉ có 1 đơn vị, thêm luôn
                if (conversions.Count == 1)
                {
                    AddToCart(product, conversions[0], 1);
                    return;
                }

                // Hiển thị dialog chọn đơn vị và số lượng
                using (var dialog = new ProductSelectionDialog(product, conversions))
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        AddToCart(product, dialog.SelectedConversion, dialog.Quantity);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chọn sản phẩm: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToCart(Products product, ProductUnitConversions conversion, double quantity)
        {
            try
            {
                // Kiểm tra tồn kho
                double requiredStock = quantity * conversion.GiaTriQuyDoi;
                if (requiredStock > product.SoLuongTon)
                {
                    MessageBox.Show($"Không đủ hàng!\nTồn kho: {product.SoLuongTon} {product.BaseUnitName}",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy giá bán
                var priceList = ProductDAO.Instance.GetPriceByProductAndUnit(product.ProductID, conversion.UnitID);
                decimal unitPrice = priceList?.GiaBan ?? 0;

                if (unitPrice == 0)
                {
                    MessageBox.Show("Sản phẩm chưa có giá bán!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem đã có trong giỏ chưa
                var existingItem = cartItems.FirstOrDefault(
                    i => i.ProductID == product.ProductID && i.UnitID == conversion.UnitID);

                if (existingItem != null)
                {
                    existingItem.Quantity += quantity;
                    existingItem.Total = (decimal)existingItem.Quantity * existingItem.UnitPrice;
                }
                else
                {
                    cartItems.Add(new CartItem
                    {
                        ProductID = product.ProductID,
                        ProductName = product.TenSanPham,
                        UnitID = conversion.UnitID,
                        UnitName = conversion.UnitName,
                        ConversionValue = conversion.GiaTriQuyDoi,
                        Quantity = quantity,
                        UnitPrice = unitPrice,
                        Total = (decimal)quantity * unitPrice
                    });
                }

                RefreshCart();
                UpdateSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm vào giỏ: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Cart Management
        private void RefreshCart()
        {
            dgvCart.Rows.Clear();

            foreach (var item in cartItems)
            {
                dgvCart.Rows.Add(
                    item.ProductName,
                    item.UnitName,
                    item.Quantity,
                    item.UnitPrice.ToString("N0"),
                    item.Total.ToString("N0")
                );
            }
        }

        private void UpdateSummary()
        {
            decimal subTotal = cartItems.Sum(i => i.Total);
            decimal discount = 0;

            if (decimal.TryParse(txtDiscount.Text, out decimal discountValue))
                discount = discountValue;

            decimal grandTotal = subTotal - discount;
            if (grandTotal < 0) grandTotal = 0;

            lblSubTotalValue.Text = $"{subTotal:N0} đ";
            lblGrandTotalValue.Text = $"{grandTotal:N0} đ";

            CalculateChange();
        }

        private void CalculateChange()
        {
            decimal grandTotal = GetGrandTotal();
            decimal amountPaid = 0;

            if (decimal.TryParse(txtAmountPaid.Text, out decimal paid))
                amountPaid = paid;

            decimal change = amountPaid - grandTotal;
            if (change < 0) change = 0;

            lblChangeValue.Text = $"{change:N0} đ";
            lblChangeValue.ForeColor = change >= 0 ? Color.FromArgb(0, 150, 120) : Color.Red;
        }

        private decimal GetGrandTotal()
        {
            string text = lblGrandTotalValue.Text.Replace(" đ", "").Replace(",", "");
            if (decimal.TryParse(text, out decimal total))
                return total;
            return 0;
        }
        #endregion

        #region Event Handlers - Customer
        private void TxtCustomerPhone_TextChanged(object sender, EventArgs e)
        {
            // Auto search khi nhập đủ 10 số
            if (txtCustomerPhone.Text.Length >= 10)
            {
                SearchCustomer();
            }
        }

        private void BtnSearchCustomer_Click(object sender, EventArgs e)
        {
            SearchCustomer();
        }

        private void SearchCustomer()
        {
            try
            {
                string phone = txtCustomerPhone.Text.Trim();
                if (string.IsNullOrEmpty(phone))
                {
                    SetDefaultCustomer();
                    return;
                }

                var customer = allCustomers?.FirstOrDefault(c => c.SoDienThoai == phone);
                if (customer != null)
                {
                    selectedCustomer = customer;
                    lblCustomerName.Text = $"✅ {customer.TenKhachHang}";
                    if (!string.IsNullOrEmpty(customer.DiaChi))
                        lblCustomerName.Text += $" - {customer.DiaChi}";
                    lblCustomerName.ForeColor = Color.FromArgb(0, 150, 120);
                }
                else
                {
                    lblCustomerName.Text = "❌ Không tìm thấy khách hàng";
                    lblCustomerName.ForeColor = Color.Red;
                    selectedCustomer = allCustomers?.FirstOrDefault(c => c.SoDienThoai == "000000000");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm khách hàng: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNewCustomer_Click(object sender, EventArgs e)
        {
            var addForm = new CustomerAddEditDialog();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadCustomers();
                MessageBox.Show("Thêm khách hàng thành công!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Event Handlers - Products
        private void TxtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchProduct.Text.ToLower().Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                DisplayProducts(allProducts);
            }
            else
            {
                var filtered = allProducts.Where(p =>
                    p.TenSanPham.ToLower().Contains(searchText)).ToList();
                DisplayProducts(filtered);
            }
        }
        #endregion

        #region Event Handlers - Cart
        private void DgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Cập nhật số lượng hoặc giá
            if (e.ColumnIndex == dgvCart.Columns["colQuantity"].Index ||
                e.ColumnIndex == dgvCart.Columns["colUnitPrice"].Index)
            {
                try
                {
                    var item = cartItems[e.RowIndex];

                    double newQty = Convert.ToDouble(dgvCart.Rows[e.RowIndex].Cells["colQuantity"].Value);
                    decimal newPrice = Convert.ToDecimal(dgvCart.Rows[e.RowIndex].Cells["colUnitPrice"].Value);

                    item.Quantity = newQty;
                    item.UnitPrice = newPrice;
                    item.Total = (decimal)newQty * newPrice;

                    dgvCart.Rows[e.RowIndex].Cells["colTotal"].Value = item.Total.ToString("N0");
                    UpdateSummary();
                }
                catch { }
            }
        }

        private void DgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvCart.Columns[e.ColumnIndex].Name == "colDelete")
            {
                cartItems.RemoveAt(e.RowIndex);
                RefreshCart();
                UpdateSummary();
            }
        }
        #endregion

        #region Event Handlers - Payment
        private void TxtDiscount_TextChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void TxtAmountPaid_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        private void RdoPayment_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu chọn Ghi nợ, không cần nhập tiền
            if (rdoDebt.Checked)
            {
                txtAmountPaid.Enabled = false;
                txtAmountPaid.Text = "0";
                lblChange.Visible = false;
                lblChangeValue.Visible = false;
            }
            else
            {
                txtAmountPaid.Enabled = true;
                lblChange.Visible = true;
                lblChangeValue.Visible = true;
            }
        }

        private void BtnCompletePayment_Click(object sender, EventArgs e)
        {
            if (!ValidateOrder()) return;

            var result = MessageBox.Show(
                "Xác nhận thanh toán đơn hàng?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            ProcessPayment();
        }

        private void BtnCancelOrder_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0) return;

            var result = MessageBox.Show(
                "Bạn có chắc muốn hủy đơn hàng?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                ClearOrder();
            }
        }
        #endregion

        #region Payment Processing
        private bool ValidateOrder()
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (selectedCustomer == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!rdoDebt.Checked)
            {
                decimal grandTotal = GetGrandTotal();
                decimal amountPaid = 0;
                if (decimal.TryParse(txtAmountPaid.Text, out decimal paid))
                    amountPaid = paid;

                if (amountPaid < grandTotal)
                {
                    MessageBox.Show("Số tiền khách đưa không đủ!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void ProcessPayment()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // Tạo hóa đơn
                string trangThai = rdoDebt.Checked ? "Ghi nợ" : "Đã thanh toán";
                var (result, newInvoiceID) = SalesInvoiceDAO.Instance.InsertSalesInvoice(
                    selectedCustomer.CustomerID,
                    currentUserID,
                    DateTime.Now,
                    trangThai);

                if (result != 0)
                {
                    MessageBox.Show("Lỗi tạo hóa đơn!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thêm chi tiết hóa đơn
                foreach (var item in cartItems)
                {
                    SalesInvoiceDAO.Instance.InsertInvoiceDetail(
                        newInvoiceID,
                        item.ProductID,
                        item.UnitID,
                        item.Quantity,
                        item.UnitPrice);
                }

                // Cập nhật tổng tiền
                SalesInvoiceDAO.Instance.UpdateInvoiceTotalAmount(newInvoiceID);

                // Tự động trừ kho
                SalesInvoiceDAO.Instance.ProcessInventoryDeduction(newInvoiceID);

                // Thông báo thành công
                decimal change = 0;
                if (!rdoDebt.Checked)
                {
                    decimal grandTotal = GetGrandTotal();
                    decimal amountPaid = decimal.Parse(txtAmountPaid.Text);
                    change = amountPaid - grandTotal;
                }

                string message = $"✅ Thanh toán thành công!\n\n" +
                                $"Mã hóa đơn: HD{newInvoiceID:D6}\n" +
                                $"Tổng tiền: {GetGrandTotal():N0} đ";

                if (!rdoDebt.Checked && change > 0)
                    message += $"\nTiền thừa: {change:N0} đ";

                MessageBox.Show(message, "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // In hóa đơn (tùy chọn)
                var printResult = MessageBox.Show("Bạn có muốn in hóa đơn?",
                    "In hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (printResult == DialogResult.Yes)
                {
                    PrintInvoice(newInvoiceID);
                }

                ClearOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thanh toán: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void PrintInvoice(int invoiceID)
        {
            // TODO: Implement invoice printing
            MessageBox.Show("Chức năng in hóa đơn đang được phát triển",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearOrder()
        {
            cartItems.Clear();
            RefreshCart();
            UpdateSummary();
            txtCustomerPhone.Clear();
            txtSearchProduct.Clear();
            txtDiscount.Text = "0";
            txtAmountPaid.Text = "0";
            rdoCash.Checked = true;
            SetDefaultCustomer();
            DisplayProducts(allProducts);
        }
        #endregion
    }

    #region Helper Classes
    public class CartItem
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public double ConversionValue { get; set; }
        public double Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
    }
    #endregion
}