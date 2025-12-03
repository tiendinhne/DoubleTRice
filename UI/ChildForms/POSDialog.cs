using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DoubleTRice.DAO;
using DoubleTRice.DT;
using DoubleTRice.LOGIC;

namespace DoubleTRice.UI.ChildForms
{
    public partial class POSDialog : Form
    {
        #region Fields & Cart Item Class
        private List<Products> allProducts;
        private List<CartItem> cartItems;
        private Customers currentCustomer;
        private int currentCustomerID = 1; // Default: Khách vãng lai

        /// <summary>
        /// Class đại diện cho 1 item trong giỏ hàng
        /// </summary>
        private class CartItem
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public int UnitID { get; set; }
            public string UnitName { get; set; }
            public double SoLuong { get; set; }
            public decimal DonGiaBan { get; set; }
            public decimal ThanhTien => (decimal)SoLuong * DonGiaBan;
            public double GiaTriQuyDoi { get; set; }
            public List<ProductUnitConversions> AvailableUnits { get; set; }
        }
        #endregion

        #region Constructor
        public POSDialog()
        {
            InitializeComponent();
            InitializeData();
            LoadProducts();
            LoadDefaultCustomer();
        }
        #endregion

        #region Initialize
        private void InitializeData()
        {
            cartItems = new List<CartItem>();
            allProducts = new List<Products>();
        }

        private void LoadDefaultCustomer()
        {
            try
            {
                // Load khách vãng lai (CustomerID = 1)
                currentCustomer = CustomerDAO.Instance.GetCustomerByID(1);
                currentCustomerID = 1;

                lblCustomerName.Text = "Khách hàng: Khách vãng lai";
                lblCustomerDebt.Visible = false;
                txtCustomerPhone.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load khách hàng mặc định: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Load Products
        private void LoadProducts()
        {
            try
            {
                dgvProducts.Rows.Clear();
                this.Cursor = Cursors.WaitCursor;

                // Load tất cả sản phẩm (có tồn kho > 0)
                allProducts = ProductDAO.Instance.GetAllProductsDetail()
                    .Where(p => p.SoLuongTon > 0)
                    .ToList();

                DisplayProducts(allProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách sản phẩm: {ex.Message}",
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

            foreach (var product in products)
            {
                // Lấy giá bán mặc định (theo BaseUnit)
                decimal giaBan = GetProductPrice(product.ProductID, product.BaseUnitID);

                int rowIndex = dgvProducts.Rows.Add(
                    product.ProductID,
                    product.TenSanPham,
                    product.BaseUnitName,
                    $"{product.SoLuongTon} kg",
                    $"{giaBan:N0} đ"
                );

                // Highlight nếu sắp hết hàng
                if (product.TrangThaiTonKho == "Sắp hết")
                {
                    dgvProducts.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 220);
                }
            }
        }

        //private decimal GetProductPrice(int productID, int unitID)
        //{
        //    try
        //    {
        //        // Lấy giá vãng lai (8%) từ PriceList
        //        string query = @"SELECT TOP 1 GiaBan FROM PriceList 
        //                 WHERE ProductID = @ProductID 
        //                   AND UnitID = @UnitID 
        //                 ORDER BY NgayApDung DESC";

        //        var result = DataProvider.Instance.ExecuteScalar(
        //            query,
        //            new Dictionary<string, object> {
        //        { "@ProductID", productID },
        //        { "@UnitID", unitID }
        //            }
        //        );

        //        if (result == null || result == DBNull.Value)
        //            return 0;

        //        decimal giaVangLai = Convert.ToDecimal(result); // Giá đã +8%

        //        // ✅ TÍNH GIÁ THEO LOẠI KHÁCH
        //        // CustomerID = 1 → Khách vãng lai (giữ nguyên giá 8%)
        //        // CustomerID khác → Khách quen (giảm xuống 5%)
        //        if (currentCustomerID != 1) // Khách quen
        //        {
        //            // Công thức: Giá quen = (Giá vãng lai / 1.08) * 1.05
        //            // Giải thích: 
        //            // - Chia 1.08 để quay về giá nhập
        //            // - Nhân 1.05 để áp dụng markup 5%
        //            decimal giaNhap = giaVangLai / 1.08m;
        //            decimal giaQuen = giaNhap * 1.05m;

        //            // Làm tròn đến hàng nghìn
        //            giaQuen = Math.Round(giaQuen / 1000, 0) * 1000;

        //            return giaQuen;
        //        }

        //        return giaVangLai; // Khách vãng lai
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine($"GetProductPrice error: {ex.Message}");
        //        return 0;
        //    }
        //}
        /// <summary>
        /// Tính giá bán dựa trên loại khách hàng
        /// </summary>
        private decimal CalculatePriceByCustomerType(decimal basePrice, int customerID)
        {
            // CustomerID = 1: Khách vãng lai (markup 8%)
            // CustomerID khác: Khách quen (markup 5%)

            if (customerID == 1)
            {
                // Khách vãng lai - giữ nguyên giá từ DB (đã +8%)
                return basePrice;
            }
            else
            {
                // Khách quen - chuyển đổi từ giá 8% xuống 5%
                const decimal MARKUP_VANGLAI = 1.08m;
                const decimal MARKUP_QUEN = 1.05m;

                // Quay về giá nhập
                decimal giaNhap = basePrice / MARKUP_VANGLAI;

                // Tính giá quen
                decimal giaQuen = giaNhap * MARKUP_QUEN;

                // Làm tròn đến hàng nghìn
                return Math.Round(giaQuen / 1000, 0) * 1000;
            }
        }

        // Sửa lại GetProductPrice
        private decimal GetProductPrice(int productID, int unitID)
        {
            try
            {
                string query = @"SELECT TOP 1 GiaBan FROM PriceList 
                         WHERE ProductID = @ProductID 
                           AND UnitID = @UnitID 
                         ORDER BY NgayApDung DESC";

                var result = DataProvider.Instance.ExecuteScalar(
                    query,
                    new Dictionary<string, object> {
                { "@ProductID", productID },
                { "@UnitID", unitID }
                    }
                );

                if (result == null || result == DBNull.Value)
                    return 0;

                decimal basePrice = Convert.ToDecimal(result);

                // ✅ Tính giá theo loại khách
                return CalculatePriceByCustomerType(basePrice, currentCustomerID);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetProductPrice error: {ex.Message}");
                return 0;
            }
        }

        #endregion

        #region Event Handlers - Product Search & Add
        private void TxtProductSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtProductSearch.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                DisplayProducts(allProducts);
                return;
            }

            var filteredProducts = allProducts.Where(p =>
                p.TenSanPham.ToLower().Contains(searchText)
            ).ToList();

            DisplayProducts(filteredProducts);
        }

        private void DgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvProducts.Columns[e.ColumnIndex].Name == "colAddToCart")
            {
                AddProductToCart(e.RowIndex);
            }
        }

        private void DgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AddProductToCart(e.RowIndex);
            }
        }

        private void AddProductToCart(int rowIndex)
        {
            try
            {
                int productID = Convert.ToInt32(dgvProducts.Rows[rowIndex].Cells["colProductID"].Value);
                var product = allProducts.FirstOrDefault(p => p.ProductID == productID);

                if (product == null) return;

                // Kiểm tra sản phẩm đã có trong giỏ chưa
                var existingItem = cartItems.FirstOrDefault(item => item.ProductID == productID);

                if (existingItem != null)
                {
                    // Tăng số lượng
                    existingItem.SoLuong += 1;
                }
                else
                {
                    // Load đơn vị tính có thể bán
                    var availableUnits = ProductDAO.Instance.GetProductUnitConversions(productID);
                    if (availableUnits.Count == 0)
                    {
                        MessageBox.Show("Sản phẩm chưa có đơn vị tính để bán!",
                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Lấy giá bán
                    decimal giaBan = GetProductPrice(productID, product.BaseUnitID);

                    // Thêm mới vào giỏ
                    cartItems.Add(new CartItem
                    {
                        ProductID = productID,
                        ProductName = product.TenSanPham,
                        UnitID = product.BaseUnitID,
                        UnitName = product.BaseUnitName,
                        SoLuong = 1,
                        DonGiaBan = giaBan,
                        GiaTriQuyDoi = 1.0,
                        AvailableUnits = availableUnits
                    });
                }

                RefreshCart();
                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sản phẩm: {ex.Message}",
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
                int rowIndex = dgvCart.Rows.Add(
                    item.ProductName,
                    item.UnitName,
                    item.SoLuong,
                    item.DonGiaBan.ToString("N0"),
                    item.ThanhTien.ToString("N0")
                );

                // Populate đơn vị tính
                var unitCell = (DataGridViewComboBoxCell)dgvCart.Rows[rowIndex].Cells["colCartUnit"];
                unitCell.Items.Clear();
                foreach (var unit in item.AvailableUnits)
                {
                    unitCell.Items.Add(unit.UnitName);
                }
                unitCell.Value = item.UnitName;

                // Store ProductID trong Tag
                dgvCart.Rows[rowIndex].Tag = item;
            }
        }

        private void DgvCart_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var item = (CartItem)dgvCart.Rows[e.RowIndex].Tag;
                var columnName = dgvCart.Columns[e.ColumnIndex].Name;

                if (columnName == "colCartUnit")
                {
                    // Đổi đơn vị tính
                    string newUnitName = dgvCart.Rows[e.RowIndex].Cells["colCartUnit"].Value?.ToString();
                    var newUnit = item.AvailableUnits.FirstOrDefault(u => u.UnitName == newUnitName);

                    if (newUnit != null)
                    {
                        item.UnitID = newUnit.UnitID;
                        item.UnitName = newUnit.UnitName;
                        item.GiaTriQuyDoi = newUnit.GiaTriQuyDoi;

                        // Cập nhật giá bán theo đơn vị mới
                        item.DonGiaBan = GetProductPrice(item.ProductID, newUnit.UnitID);
                    }
                }
                else if (columnName == "colCartQuantity")
                {
                    // Đổi số lượng
                    string qtyText = dgvCart.Rows[e.RowIndex].Cells["colCartQuantity"].Value?.ToString();
                    if (double.TryParse(qtyText, out double newQty) && newQty > 0)
                    {
                        // Kiểm tra tồn kho
                        double tonKho;
                        bool duHang = SalesInvoiceDAO.Instance.CheckStockAvailability(
                            item.ProductID, item.UnitID, newQty, out tonKho);

                        if (!duHang)
                        {
                            MessageBox.Show($"Không đủ hàng!\nTồn kho hiện tại: {tonKho} kg",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvCart.Rows[e.RowIndex].Cells["colCartQuantity"].Value = item.SoLuong;
                            return;
                        }

                        item.SoLuong = newQty;
                    }
                    else
                    {
                        dgvCart.Rows[e.RowIndex].Cells["colCartQuantity"].Value = item.SoLuong;
                    }
                }
                else if (columnName == "colCartPrice")
                {
                    // Đổi giá bán
                    string priceText = dgvCart.Rows[e.RowIndex].Cells["colCartPrice"].Value?.ToString().Replace(",", "");
                    if (decimal.TryParse(priceText, out decimal newPrice) && newPrice >= 0)
                    {
                        item.DonGiaBan = newPrice;
                    }
                    else
                    {
                        dgvCart.Rows[e.RowIndex].Cells["colCartPrice"].Value = item.DonGiaBan.ToString("N0");
                    }
                }

                RefreshCart();
                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvCart.Columns[e.ColumnIndex].Name == "colCartDelete")
            {
                var item = (CartItem)dgvCart.Rows[e.RowIndex].Tag;
                cartItems.Remove(item);
                RefreshCart();
                CalculateTotal();
            }
        }

        private void CalculateTotal()
        {
            try
            {
                // ✅ Fix: Tính tổng với handling null/empty
                decimal tongTien = 0;

                foreach (var item in cartItems)
                {
                    if (item != null && item.SoLuong > 0 && item.DonGiaBan > 0)
                    {
                        tongTien += item.ThanhTien;
                    }
                }

                // ✅ Format rõ ràng với thousand separator
                txtTongTien.Text = tongTien.ToString("N0") + " đ";

                // Debug
                System.Diagnostics.Debug.WriteLine($"Tổng tiền: {tongTien:N0}");

                CalculateTienThua();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tính tổng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTongTien.Text = "0 đ";
            }
        }
        #endregion

        // ... Continue in Part 2
        // ===================================================================
        // PART 2/2 - TIẾP TỤC TỪ POSDialog.cs
        // Thêm các methods sau vào class POSDialog
        // ===================================================================

        #region Customer Management
        private void BtnSearchCustomer_Click(object sender, EventArgs e)
        {
            string phone = txtCustomerPhone.Text.Trim();

            if (string.IsNullOrEmpty(phone))
            {
                LoadDefaultCustomer();
                return;
            }

            try
            {
                // Tìm khách hàng theo SĐT
                var customers = CustomerDAO.Instance.SearchCustomers(phone);
                var customer = customers.FirstOrDefault(c => c.SoDienThoai == phone);

                if (customer == null)
                {
                    var result = MessageBox.Show(
                        $"Không tìm thấy khách hàng có SĐT: {phone}\n\nBạn có muốn thêm khách hàng mới?",
                        "Không tìm thấy",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        // Mở form thêm khách hàng
                        var addCustomerForm = new CustomerAddEditDialog();
                        if (addCustomerForm.ShowDialog() == DialogResult.OK)
                        {
                            // Reload và tìm lại
                            BtnSearchCustomer_Click(sender, e);
                        }
                    }
                    else
                    {
                        LoadDefaultCustomer();
                    }
                    return;
                }

                // Tìm thấy khách hàng
                currentCustomer = customer;
                currentCustomerID = customer.CustomerID;

                lblCustomerName.Text = $"Khách hàng: {customer.TenKhachHang}";

                // Tính công nợ
                decimal tongMuaHang, tongDaTra, congNo;
                SalesInvoiceDAO.Instance.GetCustomerDebt(
                    customer.CustomerID,
                    out tongMuaHang,
                    out tongDaTra,
                    out congNo
                );

                if (congNo > 0)
                {
                    lblCustomerDebt.Text = $"Công nợ hiện tại: {congNo:N0} đ";
                    lblCustomerDebt.ForeColor = Color.Red;
                    lblCustomerDebt.Visible = true;
                }
                else
                {
                    lblCustomerDebt.Visible = false;
                }

                MessageBox.Show($"Đã tìm thấy khách hàng: {customer.TenKhachHang}",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm khách hàng: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Payment Calculation
        private void TxtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            CalculateTienThua();
        }

        private void TxtTienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím điều khiển
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CalculateTienThua()
        {
            try
            {
                // Lấy số tiền, bỏ dấu phẩy
                string tienKhachDuaText = txtTienKhachDua.Text.Replace(",", "").Replace(".", "").Trim();
                string tongTienText = txtTongTien.Text.Replace(",", "").Replace(".", "").Trim();

                decimal tienKhachDua = 0;
                decimal tongTien = 0;

                // Parse an toàn
                if (!string.IsNullOrEmpty(tienKhachDuaText))
                {
                    decimal.TryParse(tienKhachDuaText, out tienKhachDua);
                }

                if (!string.IsNullOrEmpty(tongTienText))
                {
                    decimal.TryParse(tongTienText, out tongTien);
                }

                decimal tienThua = tienKhachDua - tongTien;

                txtTienThua.Text = tienThua.ToString("N0");

                // Đổi màu
                if (tienThua < 0)
                {
                    txtTienThua.ForeColor = Color.Red;
                }
                else if (tienThua > 0)
                {
                    txtTienThua.ForeColor = Color.Green;
                }
                else
                {
                    txtTienThua.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                txtTienThua.Text = "0";
                System.Diagnostics.Debug.WriteLine($"Error calculating change: {ex.Message}");
            }
        }
        #endregion

        #region Payment Processing
        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            // Validate giỏ hàng
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống! Vui lòng chọn sản phẩm.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate số lượng
            foreach (var item in cartItems)
            {
                if (item.SoLuong <= 0)
                {
                    MessageBox.Show($"Số lượng của {item.ProductName} phải lớn hơn 0!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Kiểm tra tồn kho lần cuối
            if (!ValidateStockBeforePayment())
            {
                return;
            }

            // Lấy thông tin thanh toán
            decimal tongTien = decimal.Parse(txtTongTien.Text.Replace(",", ""));
            decimal tienKhachDua = 0;

            try
            {
                string tienKhachDuaText = txtTienKhachDua.Text.Replace(",", "").Trim();
                tienKhachDua = string.IsNullOrEmpty(tienKhachDuaText) ? 0 : decimal.Parse(tienKhachDuaText);
            }
            catch
            {
                tienKhachDua = 0;
            }

            // Kiểm tra thanh toán
            if (!chkGhiNo.Checked && tienKhachDua < tongTien)
            {
                MessageBox.Show("Số tiền khách đưa không đủ!\n\nNếu muốn ghi nợ, vui lòng tích vào 'Cho phép ghi nợ'.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận thanh toán
            string confirmMessage = $"Xác nhận thanh toán:\n\n" +
                                  $"Khách hàng: {currentCustomer?.TenKhachHang ?? "Khách vãng lai"}\n" +
                                  $"Tổng tiền: {tongTien:N0} đ\n" +
                                  $"Tiền khách đưa: {tienKhachDua:N0} đ\n";

            if (tienKhachDua < tongTien)
            {
                confirmMessage += $"\n⚠️ GHI NỢ: {(tongTien - tienKhachDua):N0} đ";
            }

            var result = MessageBox.Show(confirmMessage, "Xác nhận thanh toán",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ProcessPayment(tongTien, tienKhachDua);
            }
        }

        private bool ValidateStockBeforePayment()
        {
            foreach (var item in cartItems)
            {
                double tonKho;
                bool duHang = SalesInvoiceDAO.Instance.CheckStockAvailability(
                    item.ProductID, item.UnitID, item.SoLuong, out tonKho);

                if (!duHang)
                {
                    MessageBox.Show(
                        $"Không đủ hàng cho sản phẩm: {item.ProductName}\n\n" +
                        $"Số lượng cần: {item.SoLuong} {item.UnitName}\n" +
                        $"Tồn kho hiện tại: {tonKho} kg",
                        "Không đủ hàng",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return false;
                }
            }
            return true;
        }

        private void ProcessPayment(decimal tongTien, decimal tienKhachDua)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Tạo danh sách chi tiết
                var details = cartItems.Select(item => new SalesInvoiceDetails
                {
                    ProductID = item.ProductID,
                    UnitID = item.UnitID,
                    SoLuong = item.SoLuong,
                    DonGiaBan = item.DonGiaBan
                }).ToList();

                // Tạo hóa đơn
                int newInvoiceID;
                int result = SalesInvoiceDAO.Instance.InsertSalesInvoice(
                    currentCustomerID,
                    UserSession.UserID,
                    tongTien,
                    details,
                    out newInvoiceID
                );

                if (result == 0)
                {
                    // Tạo hóa đơn thành công
                    // Ghi nhận thanh toán (nếu có)
                    if (tienKhachDua > 0)
                    {
                        string phuongThuc = "Tiền mặt"; // Có thể thêm combobox để chọn

                        int paymentResult = SalesInvoiceDAO.Instance.InsertCustomerPayment(
                            currentCustomerID,
                            newInvoiceID,
                            tienKhachDua,
                            phuongThuc
                        );
                    }

                    // Hiển thị thông báo thành công
                    decimal tienThua = tienKhachDua - tongTien;
                    string successMessage = $"✅ Thanh toán thành công!\n\n" +
                                          $"Mã hóa đơn: HD{DateTime.Now:ddMMyy}xxx\n" +
                                          $"Tổng tiền: {tongTien:N0} đ\n" +
                                          $"Tiền khách đưa: {tienKhachDua:N0} đ\n";

                    if (tienThua > 0)
                    {
                        successMessage += $"Tiền thừa: {tienThua:N0} đ";
                    }
                    else if (tienThua < 0)
                    {
                        successMessage += $"\n⚠️ Ghi nợ: {Math.Abs(tienThua):N0} đ";
                    }

                    MessageBox.Show(successMessage, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Hỏi in hóa đơn
                    var printResult = MessageBox.Show("Bạn có muốn in hóa đơn không?",
                        "In hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (printResult == DialogResult.Yes)
                    {
                        PrintInvoice(newInvoiceID);
                    }

                    // Đóng form và trả về OK
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(GetErrorMessage(result), "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý thanh toán: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void PrintInvoice(int invoiceID)
        {
            MessageBox.Show("Chức năng in hóa đơn đang được phát triển.\n\nID Hóa đơn: " + invoiceID,
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Button Actions
        private void BtnHuy_Click(object sender, EventArgs e)
        {
            if (cartItems.Count > 0)
            {
                var result = MessageBox.Show(
                    "Bạn có chắc chắn muốn hủy?\n\nGiỏ hàng sẽ bị xóa!",
                    "Xác nhận hủy",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        #endregion

        #region Helper Methods
        private string GetErrorMessage(int resultCode)
        {
            switch (resultCode)
            {
                case -3: return "Không tìm thấy quy đổi đơn vị tính cho sản phẩm";
                case -4: return "Không đủ hàng trong kho";
                case -99: return "Lỗi hệ thống";
                default: return "Lỗi không xác định";
            }
        }
        #endregion

        private void lblCustomerDebt_Click(object sender, EventArgs e)
        {

        }
    }
}