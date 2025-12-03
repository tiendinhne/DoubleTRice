using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DoubleTRice.DAO;
using DoubleTRice.DT;

namespace DoubleTRice.UI.ChildForms
{
    public partial class DebtDetailDialog : Form
    {
        #region Fields
        private int customerID;
        private CustomerDebtSummary debtSummary;
        private List<SalesInvoices> unpaidInvoices;
        private List<CustomerPayments> paymentHistory;
        private SalesInvoices selectedInvoice;
        #endregion

        #region Constructor
        public DebtDetailDialog(int customerID)
        {
            InitializeComponent();
            this.customerID = customerID;
            LoadData();
        }
        #endregion

        #region Load Data
        private void LoadData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Load thông tin khách hàng
                var customer = CustomerDAO.Instance.GetCustomerByID(customerID);
                if (customer == null)
                {
                    MessageBox.Show("Không tìm thấy khách hàng!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                lblCustomerName.Text = $"Khách hàng: {customer.TenKhachHang}";
                lblCustomerPhone.Text = $"SĐT: {customer.SoDienThoai ?? "N/A"}";

                // Load công nợ
                decimal tongMuaHang, tongDaTra, congNo;
                SalesInvoiceDAO.Instance.GetCustomerDebt(
                    customerID, out tongMuaHang, out tongDaTra, out congNo);

                debtSummary = new CustomerDebtSummary
                {
                    CustomerID = customerID,
                    TenKhachHang = customer.TenKhachHang,
                    TongMuaHang = tongMuaHang,
                    TongDaTra = tongDaTra,
                    CongNoHienTai = congNo
                };

                lblTongMuaHang.Text = $"Tổng mua hàng: {tongMuaHang:N0} đ";
                lblTongDaTra.Text = $"Đã trả: {tongDaTra:N0} đ";
                lblCongNo.Text = $"Công nợ: {congNo:N0} đ";

                // Load danh sách hóa đơn còn nợ
                LoadUnpaidInvoices();

                // Load lịch sử thanh toán
                LoadPaymentHistory();
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

        private void LoadUnpaidInvoices()
        {
            dgvUnpaidInvoices.Rows.Clear();

            // Lấy tất cả hóa đơn của khách, filter những hóa đơn còn nợ
            var allInvoices = SalesInvoiceDAO.Instance.GetSalesInvoicesByDateRange(
                DateTime.Now.AddYears(-5), DateTime.Now)
                .Where(inv => inv.CustomerID == customerID && inv.ConLai > 0)
                .ToList();

            unpaidInvoices = allInvoices;

            foreach (var invoice in unpaidInvoices)
            {
                dgvUnpaidInvoices.Rows.Add(
                    invoice.InvoiceID,
                    invoice.MaHoaDon,
                    invoice.NgayBan?.ToString("dd/MM/yyyy") ?? "N/A",
                    $"{invoice.TongTien:N0}",
                    $"{invoice.SoTienDaTra:N0}",
                    $"{invoice.ConLai:N0}"
                );
            }
        }

        private void LoadPaymentHistory()
        {
            dgvPaymentHistory.Rows.Clear();

            // Lấy lịch sử thanh toán của khách hàng
            var allPayments = new List<CustomerPayments>();

            // Get tất cả hóa đơn của khách
            var customerInvoices = SalesInvoiceDAO.Instance.GetSalesInvoicesByDateRange(
                DateTime.Now.AddYears(-5), DateTime.Now)
                .Where(inv => inv.CustomerID == customerID)
                .ToList();

            // Get payment của từng hóa đơn
            foreach (var invoice in customerInvoices)
            {
                var payments = SalesInvoiceDAO.Instance.GetPaymentsByInvoiceID(invoice.InvoiceID);
                allPayments.AddRange(payments);
            }

            paymentHistory = allPayments.OrderByDescending(p => p.NgayThanhToan).ToList();

            foreach (var payment in paymentHistory)
            {
                dgvPaymentHistory.Rows.Add(
                    payment.PaymentID,
                    payment.MaHoaDon ?? "N/A",
                    payment.NgayThanhToan?.ToString("dd/MM/yyyy HH:mm") ?? "N/A",
                    $"{payment.SoTien:N0}",
                    payment.PhuongThuc
                );
            }
        }
        #endregion

        #region Event Handlers - DataGridView
        private void DgvUnpaidInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int invoiceID = Convert.ToInt32(dgvUnpaidInvoices.Rows[e.RowIndex].Cells["colInvoiceID"].Value);
            selectedInvoice = unpaidInvoices.FirstOrDefault(inv => inv.InvoiceID == invoiceID);

            if (selectedInvoice == null) return;

            if (dgvUnpaidInvoices.Columns[e.ColumnIndex].Name == "colPayAction")
            {
                OpenPaymentDialog(selectedInvoice);
            }
        }

        private void DgvUnpaidInvoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && selectedInvoice != null)
            {
                OpenPaymentDialog(selectedInvoice);
            }
        }
        #endregion

        #region Actions
        private void BtnThanhToanTatCa_Click(object sender, EventArgs e)
        {
            if (debtSummary.CongNoHienTai <= 0)
            {
                MessageBox.Show("Khách hàng không còn công nợ!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                $"Thanh toán toàn bộ công nợ?\n\n" +
                $"Số tiền: {debtSummary.CongNoHienTai:N0} đ\n\n" +
                "Sẽ áp dụng cho hóa đơn cũ nhất trước.",
                "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                ProcessFullPayment();
            }
        }

        private void OpenPaymentDialog(SalesInvoices invoice)
        {
            var paymentDialog = new PaymentDialog(invoice.InvoiceID, customerID);
            if (paymentDialog.ShowDialog() == DialogResult.OK)
            {
                LoadData(); // Refresh
                MessageBox.Show("Thanh toán thành công!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ProcessFullPayment()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                decimal remainingAmount = debtSummary.CongNoHienTai;
                int successCount = 0;

                // Thanh toán từ hóa đơn cũ nhất
                foreach (var invoice in unpaidInvoices.OrderBy(inv => inv.NgayBan))
                {
                    if (remainingAmount <= 0) break;

                    decimal payAmount = Math.Min(remainingAmount, invoice.ConLai ?? 0);

                    int result = SalesInvoiceDAO.Instance.InsertCustomerPayment(
                        customerID,
                        invoice.InvoiceID,
                        payAmount,
                        "Tiền mặt"
                    );

                    if (result == 0)
                    {
                        successCount++;
                        remainingAmount -= payAmount;
                    }
                }

                MessageBox.Show(
                    $"✅ Đã thanh toán thành công {successCount} hóa đơn!\n\n" +
                    $"Tổng số tiền: {(debtSummary.CongNoHienTai - remainingAmount):N0} đ",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadData(); // Refresh
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thanh toán: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng in báo cáo công nợ đang được phát triển",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}