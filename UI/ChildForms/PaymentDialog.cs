using System;
using System.Drawing;
using System.Windows.Forms;
using DoubleTRice.DAO;
using DoubleTRice.DT;

namespace DoubleTRice.UI.ChildForms
{
    public partial class PaymentDialog : Form
    {
        #region Fields
        private int invoiceID;
        private int customerID;
        private SalesInvoices invoice;
        private decimal tongTien;
        private decimal daTra;
        private decimal conLai;
        #endregion

        #region Constructor
        public PaymentDialog(int invoiceID, int customerID)
        {
            InitializeComponent();
            this.invoiceID = invoiceID;
            this.customerID = customerID;
            LoadInvoiceData();
        }
        #endregion

        #region Load Data
        private void LoadInvoiceData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Lấy thông tin hóa đơn
                invoice = SalesInvoiceDAO.Instance.GetSalesInvoiceByID(invoiceID);
                if (invoice == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Lấy thông tin khách hàng
                var customer = CustomerDAO.Instance.GetCustomerByID(customerID);
                string customerName = customer?.TenKhachHang ?? "N/A";
                string customerPhone = customer?.SoDienThoai ?? "";

                // Tính toán số tiền
                tongTien = invoice.TongTien ?? 0;
                daTra = invoice.SoTienDaTra ?? 0;
                conLai = invoice.ConLai ?? 0;

                // Hiển thị thông tin
                lblInvoiceInfo.Text = $"Hóa đơn: {invoice.MaHoaDon ?? "N/A"}";
                lblCustomerInfo.Text = $"Khách hàng: {customerName} ({customerPhone})";
                lblTongTien.Text = $"Tổng tiền hóa đơn: {tongTien:N0} đ";
                lblDaTra.Text = $"Đã trả: {daTra:N0} đ";
                lblConLai.Text = $"Còn lại: {conLai:N0} đ";

                // Kiểm tra đã thanh toán đủ chưa
                if (conLai <= 0)
                {
                    MessageBox.Show("Hóa đơn này đã được thanh toán đủ!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }

                // Set giá trị mặc định cho txtSoTienTra
                txtSoTienTra.Text = "0";
                CalculateConLaiSauTra();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Event Handlers
        private void TxtSoTienTra_TextChanged(object sender, EventArgs e)
        {
            CalculateConLaiSauTra();
        }

        private void BtnTraHet_Click(object sender, EventArgs e)
        {
            txtSoTienTra.Text = conLai.ToString("N0");
        }

        private void CalculateConLaiSauTra()
        {
            try
            {
                string soTienTraText = txtSoTienTra.Text.Replace(",", "").Trim();
                decimal soTienTra = string.IsNullOrEmpty(soTienTraText) ? 0 : decimal.Parse(soTienTraText);

                decimal conLaiSauTra = conLai - soTienTra;
                txtConLaiSauTra.Text = conLaiSauTra.ToString("N0");

                // Đổi màu
                if (conLaiSauTra <= 0)
                {
                    txtConLaiSauTra.ForeColor = Color.Green;
                }
                else
                {
                    txtConLaiSauTra.ForeColor = Color.Red;
                }
            }
            catch
            {
                txtConLaiSauTra.Text = conLai.ToString("N0");
                txtConLaiSauTra.ForeColor = Color.Red;
            }
        }
        #endregion

        #region Payment Processing
        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            // Validate số tiền trả
            decimal soTienTra;
            try
            {
                string soTienTraText = txtSoTienTra.Text.Replace(",", "").Trim();
                soTienTra = string.IsNullOrEmpty(soTienTraText) ? 0 : decimal.Parse(soTienTraText);
            }
            catch
            {
                MessageBox.Show("Số tiền trả không hợp lệ!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTienTra.Focus();
                return;
            }

            // Kiểm tra số tiền > 0
            if (soTienTra <= 0)
            {
                MessageBox.Show("Số tiền trả phải lớn hơn 0!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTienTra.Focus();
                return;
            }

            // Kiểm tra số tiền không vượt quá công nợ
            if (soTienTra > conLai)
            {
                var result = MessageBox.Show(
                    $"Số tiền trả ({soTienTra:N0} đ) lớn hơn công nợ ({conLai:N0} đ).\n\n" +
                    "Bạn có chắc chắn muốn tiếp tục?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            // Lấy phương thức thanh toán
            string phuongThuc = cboPhuongThuc.SelectedItem?.ToString() ?? "Tiền mặt";

            // Xác nhận thanh toán
            decimal conLaiSauTra = conLai - soTienTra;
            string confirmMessage = $"Xác nhận thanh toán:\n\n" +
                                  $"Hóa đơn: {invoice.MaHoaDon}\n" +
                                  $"Khách hàng: {lblCustomerInfo.Text.Replace("Khách hàng: ", "")}\n" +
                                  $"Công nợ hiện tại: {conLai:N0} đ\n" +
                                  $"Số tiền trả: {soTienTra:N0} đ\n" +
                                  $"Phương thức: {phuongThuc}\n" +
                                  $"Còn lại sau trả: {conLaiSauTra:N0} đ\n\n";

            if (conLaiSauTra <= 0)
            {
                confirmMessage += "✅ Hóa đơn sẽ được đánh dấu ĐÃ THANH TOÁN";
            }
            else
            {
                confirmMessage += $"⚠️ Vẫn còn nợ: {conLaiSauTra:N0} đ";
            }

            var confirmResult = MessageBox.Show(confirmMessage, "Xác nhận thanh toán",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                ProcessPayment(soTienTra, phuongThuc);
            }
        }

        private void ProcessPayment(decimal soTienTra, string phuongThuc)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Gọi DAO để thêm thanh toán
                int result = SalesInvoiceDAO.Instance.InsertCustomerPayment(
                    customerID,
                    invoiceID,
                    soTienTra,
                    phuongThuc
                );

                if (result == 0)
                {
                    // Thành công
                    decimal conLaiSauTra = conLai - soTienTra;
                    string successMessage = $"✅ Thanh toán thành công!\n\n" +
                                          $"Số tiền đã trả: {soTienTra:N0} đ\n" +
                                          $"Phương thức: {phuongThuc}\n";

                    if (conLaiSauTra <= 0)
                    {
                        successMessage += $"\n🎉 Hóa đơn đã được thanh toán đủ!";
                    }
                    else
                    {
                        successMessage += $"\nCòn lại: {conLaiSauTra:N0} đ";
                    }

                    MessageBox.Show(successMessage, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        #endregion

        #region Button Actions
        private void BtnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region Helper Methods
        private string GetErrorMessage(int resultCode)
        {
            switch (resultCode)
            {
                case -2: return "Số tiền không hợp lệ";
                case -99: return "Lỗi hệ thống";
                default: return "Lỗi không xác định";
            }
        }
        #endregion
    }
}