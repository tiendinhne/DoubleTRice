using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DoubleTRice.DAO;
using DoubleTRice.DT;

namespace DoubleTRice.UI.ChildForms
{
    public partial class SupplierDebtDetailDialog : Form
    {
        #region Fields
        private int supplierID;
        private SupplierDebtSummary debtSummary;
        private List<GoodsReceiptDebt> unpaidReceipts;
        private List<SupplierPaymentRecord> paymentHistory;
        private GoodsReceiptDebt selectedReceipt;
        #endregion

        #region Constructor
        public SupplierDebtDetailDialog(int supplierID)
        {
            InitializeComponent();
            this.supplierID = supplierID;
            LoadData();
        }
        #endregion

        #region Load Data
        private void LoadData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Load thông tin NCC
                var supplier = SupplierDAO.Instance.GetSupplierByID(supplierID);
                if (supplier == null)
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                lblSupplierName.Text = $"Nhà cung cấp: {supplier.TenNhaCungCap}";
                lblSupplierPhone.Text = $"SĐT: {supplier.SoDienThoai ?? "N/A"}";

                // Load công nợ từ DAO
                var allDebts = SupplierDebtDAO.Instance.GetAllSupplierDebts();
                debtSummary = allDebts.FirstOrDefault(d => d.SupplierID == supplierID);

                if (debtSummary == null)
                {
                    MessageBox.Show("Nhà cung cấp không có công nợ!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }

                lblTongNhapHang.Text = $"Tổng nhập hàng: {debtSummary.TongNhapHang:N0} đ";
                lblTongDaTra.Text = $"Đã trả: {debtSummary.TongDaTra:N0} đ";
                lblCongNo.Text = $"Công nợ: {debtSummary.CongNoHienTai:N0} đ";

                // Load danh sách phiếu nhập còn nợ
                LoadUnpaidReceipts();

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

        private void LoadUnpaidReceipts()
        {
            dgvUnpaidReceipts.Rows.Clear();
            unpaidReceipts = new List<GoodsReceiptDebt>();

            try
            {
                // Lấy tất cả phiếu nhập của NCC
                var allReceipts = GoodsReceiptDAO.Instance.GetReceiptsBySupplier(supplierID);

                foreach (var receipt in allReceipts)
                {
                    // Tính số tiền đã trả cho phiếu này
                    decimal daTra = GetPaidAmountForReceipt(receipt.ReceiptID);
                    decimal conLai = (receipt.TongTien ?? 0) - daTra;

                    // Chỉ hiển thị phiếu còn nợ
                    if (conLai > 0)
                    {
                        var debtItem = new GoodsReceiptDebt
                        {
                            ReceiptID = receipt.ReceiptID,
                            MaPhieuNhap = receipt.MaPhieuNhap,
                            NgayNhap = receipt.NgayNhap ?? DateTime.Now,
                            TongTien = receipt.TongTien ?? 0,
                            DaTra = daTra,
                            ConLai = conLai
                        };

                        unpaidReceipts.Add(debtItem);

                        dgvUnpaidReceipts.Rows.Add(
                            debtItem.ReceiptID,
                            debtItem.MaPhieuNhap,
                            debtItem.NgayNhap.ToString("dd/MM/yyyy"),
                            $"{debtItem.TongTien:N0}",
                            $"{debtItem.DaTra:N0}",
                            $"{debtItem.ConLai:N0}"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load phiếu nhập: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPaymentHistory()
        {
            dgvPaymentHistory.Rows.Clear();
            paymentHistory = new List<SupplierPaymentRecord>();

            try
            {
                // Query lịch sử thanh toán từ DB
                string query = @"
                    SELECT 
                        sp.PaymentID,
                        gr.MaPhieuNhap,
                        sp.NgayThanhToan,
                        sp.SoTien,
                        sp.PhuongThuc
                    FROM SupplierPayments sp
                    LEFT JOIN GoodsReceipts gr ON sp.ReceiptID = gr.ReceiptID
                    WHERE sp.SupplierID = @SupplierID
                    ORDER BY sp.NgayThanhToan DESC";

                var data = DataProvider.Instance.ExecuteQuery(
                    query,
                    new object[] { supplierID },
                    isStoredProc: false
                );

                foreach (System.Data.DataRow row in data.Rows)
                {
                    var payment = new SupplierPaymentRecord
                    {
                        PaymentID = Convert.ToInt32(row["PaymentID"]),
                        MaPhieuNhap = row["MaPhieuNhap"]?.ToString() ?? "N/A",
                        NgayThanhToan = Convert.ToDateTime(row["NgayThanhToan"]),
                        SoTien = Convert.ToDecimal(row["SoTien"]),
                        PhuongThuc = row["PhuongThuc"]?.ToString() ?? ""
                    };

                    paymentHistory.Add(payment);

                    dgvPaymentHistory.Rows.Add(
                        payment.PaymentID,
                        payment.MaPhieuNhap,
                        payment.NgayThanhToan.ToString("dd/MM/yyyy HH:mm"),
                        $"{payment.SoTien:N0}",
                        payment.PhuongThuc
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load lịch sử: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetPaidAmountForReceipt(int receiptID)
        {
            try
            {
                string query = @"
                    SELECT ISNULL(SUM(SoTien), 0) AS TotalPaid
                    FROM SupplierPayments
                    WHERE ReceiptID = @ReceiptID";

                var result = DataProvider.Instance.ExecuteScalar(
                    query,
                    new Dictionary<string, object> { { "@ReceiptID", receiptID } }
                );

                return result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0;
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region Event Handlers - DataGridView
        private void DgvUnpaidReceipts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int receiptID = Convert.ToInt32(dgvUnpaidReceipts.Rows[e.RowIndex].Cells["colReceiptID"].Value);
            selectedReceipt = unpaidReceipts.FirstOrDefault(r => r.ReceiptID == receiptID);

            if (selectedReceipt == null) return;

            if (dgvUnpaidReceipts.Columns[e.ColumnIndex].Name == "colPayAction")
            {
                OpenPaymentDialog(selectedReceipt);
            }
        }

        private void DgvUnpaidReceipts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && selectedReceipt != null)
            {
                OpenPaymentDialog(selectedReceipt);
            }
        }
        #endregion

        #region Actions
        private void BtnTraNoTatCa_Click(object sender, EventArgs e)
        {
            if (debtSummary.CongNoHienTai <= 0)
            {
                MessageBox.Show("Không còn công nợ cần trả!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                $"Thanh toán toàn bộ công nợ?\n\n" +
                $"Nhà cung cấp: {debtSummary.TenNhaCungCap}\n" +
                $"Số tiền: {debtSummary.CongNoHienTai:N0} đ\n\n" +
                "Sẽ áp dụng cho phiếu nhập cũ nhất trước.",
                "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                ProcessFullPayment();
            }
        }

        private void OpenPaymentDialog(GoodsReceiptDebt receipt)
        {
            var confirmMessage = $"Trả nợ cho phiếu nhập:\n\n" +
                               $"Mã phiếu: {receipt.MaPhieuNhap}\n" +
                               $"Ngày nhập: {receipt.NgayNhap:dd/MM/yyyy}\n" +
                               $"Tổng tiền: {receipt.TongTien:N0} đ\n" +
                               $"Đã trả: {receipt.DaTra:N0} đ\n" +
                               $"Còn lại: {receipt.ConLai:N0} đ\n\n" +
                               "Nhập số tiền trả:";

            string input = Microsoft.VisualBasic.Interaction.InputBox(
                confirmMessage,
                "Trả nợ",
                receipt.ConLai.ToString("N0")
            );

            if (string.IsNullOrEmpty(input)) return;

            try
            {
                decimal soTien = decimal.Parse(input.Replace(",", "").Replace(".", ""));

                if (soTien <= 0)
                {
                    MessageBox.Show("Số tiền phải lớn hơn 0!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thực hiện thanh toán
                int result = SupplierDebtDAO.Instance.InsertSupplierPayment(
                    supplierID,
                    receipt.ReceiptID,
                    soTien,
                    "Chuyển khoản"
                );

                if (result == 0)
                {
                    MessageBox.Show($"✅ Thanh toán thành công!\n\nSố tiền: {soTien:N0} đ",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Refresh
                }
                else
                {
                    MessageBox.Show(GetErrorMessage(result),
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessFullPayment()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                decimal remainingAmount = debtSummary.CongNoHienTai;
                int successCount = 0;

                // Thanh toán từ phiếu cũ nhất
                foreach (var receipt in unpaidReceipts.OrderBy(r => r.NgayNhap))
                {
                    if (remainingAmount <= 0) break;

                    decimal payAmount = Math.Min(remainingAmount, receipt.ConLai);

                    int result = SupplierDebtDAO.Instance.InsertSupplierPayment(
                        supplierID,
                        receipt.ReceiptID,
                        payAmount,
                        "Chuyển khoản"
                    );

                    if (result == 0)
                    {
                        successCount++;
                        remainingAmount -= payAmount;
                    }
                }

                MessageBox.Show(
                    $"✅ Đã thanh toán thành công {successCount} phiếu nhập!\n\n" +
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

        #region Helper Methods
        private string GetErrorMessage(int resultCode)
        {
            switch (resultCode)
            {
                case -2: return "Số tiền không hợp lệ";
                case -3: return "Phiếu nhập không tồn tại";
                case -4: return "Cảnh báo: Số tiền trả vượt quá công nợ (đã được ghi nhận)";
                case -99: return "Lỗi hệ thống";
                default: return "Lỗi không xác định";
            }
        }
        #endregion
    }
}