using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DoubleTRice.DAO;
using DoubleTRice.DT;

namespace DoubleTRice.UI.ChildForms
{
    public partial class SalesInvoiceDetailDialog : Form
    {
        #region Fields
        private int invoiceID;
        private SalesInvoices invoice;
        private List<SalesInvoiceDetails> details;
        private List<CustomerPayments> payments;
        #endregion

        #region Constructor
        public SalesInvoiceDetailDialog(int invoiceID)
        {
            InitializeComponent();
            this.invoiceID = invoiceID;
            LoadInvoiceData();
        }
        #endregion

        #region Load Data
        private void LoadInvoiceData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 1. Lấy thông tin header
                invoice = SalesInvoiceDAO.Instance.GetSalesInvoiceByID(invoiceID);
                if (invoice == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // 2. Hiển thị thông tin header
                DisplayInvoiceInfo();

                // 3. Lấy chi tiết sản phẩm
                details = SalesInvoiceDAO.Instance.GetInvoiceDetails(invoiceID);
                DisplayInvoiceDetails();

                // 4. Lấy lịch sử thanh toán
                payments = SalesInvoiceDAO.Instance.GetPaymentsByInvoiceID(invoiceID);
                DisplayPaymentHistory();
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

        private void DisplayInvoiceInfo()
        {
            // Lấy tên khách hàng
            var customer = CustomerDAO.Instance.GetCustomerByID(invoice.CustomerID);
            string customerName = customer?.TenKhachHang ?? "N/A";
            string customerPhone = customer?.SoDienThoai ?? "";

            // Lấy tên nhân viên
            var user = UserDAO.Instance.GetUserByID(invoice.UserID);
            string userName = user?.HoTen ?? "N/A";

            // Hiển thị thông tin
            lblMaHoaDon.Text = $"Mã hóa đơn: {invoice.MaHoaDon ?? "N/A"}";
            lblNgayBan.Text = $"Ngày bán: {invoice.NgayBan?.ToString("dd/MM/yyyy HH:mm") ?? "N/A"}";
            lblCustomer.Text = $"Khách hàng: {customerName} ({customerPhone})";
            lblUser.Text = $"Nhân viên bán: {userName}";

            lblTongTien.Text = $"Tổng tiền: {invoice.TongTien?.ToString("N0") ?? "0"} đ";
            lblSoTienDaTra.Text = $"Đã trả: {invoice.SoTienDaTra?.ToString("N0") ?? "0"} đ";
            lblConLai.Text = $"Còn lại: {invoice.ConLai?.ToString("N0") ?? "0"} đ";

            // Trạng thái
            string trangThai = invoice.TrangThaiThanhToan ?? "N/A";
            lblTrangThai.Text = $"Trạng thái: {trangThai}";

            if (trangThai == "Đã thanh toán")
            {
                lblTrangThai.ForeColor = Color.Green;
                lblConLai.Visible = false;
            }
            else if (trangThai == "Ghi nợ")
            {
                lblTrangThai.ForeColor = Color.Red;
                lblConLai.Visible = true;
            }
        }

        private void DisplayInvoiceDetails()
        {
            dgvDetails.Rows.Clear();

            if (details == null || details.Count == 0)
            {
                return;
            }

            foreach (var detail in details)
            {
                dgvDetails.Rows.Add(
                    detail.ProductName ?? "N/A",
                    detail.UnitName ?? "N/A",
                    detail.SoLuong,
                    detail.DonGiaBan.ToString("N0"),
                    detail.ThanhTien?.ToString("N0") ?? "0"
                );
            }
        }

        private void DisplayPaymentHistory()
        {
            dgvPayments.Rows.Clear();

            if (payments == null || payments.Count == 0)
            {
                dgvPayments.Rows.Add(
                    "Chưa có thanh toán",
                    "",
                    ""
                );
                return;
            }

            foreach (var payment in payments)
            {
                dgvPayments.Rows.Add(
                    payment.NgayThanhToan?.ToString("dd/MM/yyyy HH:mm") ?? "N/A",
                    payment.SoTien.ToString("N0") + " đ",
                    payment.PhuongThuc ?? "Tiền mặt"
                );
            }
        }
        #endregion

        #region Event Handlers
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintInvoice();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in hóa đơn: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Print Invoice
        private void PrintInvoice()
        {
            // TODO: Implement PDF generation
            // Tạm thời hiển thị thông báo
            string invoiceContent = GenerateInvoiceContent();

            MessageBox.Show(
                "Chức năng in hóa đơn PDF đang được phát triển.\n\n" +
                "Nội dung hóa đơn:\n\n" + invoiceContent,
                "In hóa đơn",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private string GenerateInvoiceContent()
        {
            string content = "=====================================\n";
            content += "         HÓA ĐƠN BÁN HÀNG\n";
            content += "=====================================\n\n";

            content += $"Mã HĐ: {invoice.MaHoaDon}\n";
            content += $"Ngày: {invoice.NgayBan?.ToString("dd/MM/yyyy HH:mm")}\n";

            var customer = CustomerDAO.Instance.GetCustomerByID(invoice.CustomerID);
            content += $"Khách hàng: {customer?.TenKhachHang}\n";
            content += $"SĐT: {customer?.SoDienThoai}\n\n";

            content += "-------------------------------------\n";
            content += "Sản phẩm            SL    Đơn giá    Thành tiền\n";
            content += "-------------------------------------\n";

            foreach (var detail in details)
            {
                content += $"{detail.ProductName,-15} {detail.SoLuong,4} {detail.DonGiaBan,10:N0} {detail.ThanhTien,12:N0}\n";
            }

            content += "-------------------------------------\n";
            content += $"Tổng tiền:                {invoice.TongTien,12:N0} đ\n";
            content += $"Đã trả:                   {invoice.SoTienDaTra,12:N0} đ\n";
            content += $"Còn lại:                  {invoice.ConLai,12:N0} đ\n";
            content += "=====================================\n";
            content += "         Cảm ơn quý khách!\n";
            content += "=====================================\n";

            return content;
        }
        #endregion
    }
}