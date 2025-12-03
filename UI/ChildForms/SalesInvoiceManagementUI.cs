using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DoubleTRice.DAO;
using DoubleTRice.DT;

namespace DoubleTRice.UI.ChildForms
{
    public partial class SalesInvoiceManagementUI : BaseChildForm
    {
        #region Fields
        private List<SalesInvoices> allInvoices;
        private SalesInvoices selectedInvoice;
        private DateTime filterStartDate;
        private DateTime filterEndDate;
        #endregion

        #region Constructor
        public SalesInvoiceManagementUI()
        {
            InitializeComponent();
            InitializeFilters();
            LoadData();
        }
        #endregion

        #region Initialize
        private void InitializeFilters()
        {
            // Mặc định lọc trong tháng hiện tại
            filterStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            filterEndDate = DateTime.Now.Date;

            dtpStartDate.Value = filterStartDate;
            dtpEndDate.Value = filterEndDate;
        }
        #endregion

        #region Load Data
        private void LoadData()
        {
            try
            {
                dgvInvoices.DataSource = null;
                this.Cursor = Cursors.WaitCursor;

                allInvoices = SalesInvoiceDAO.Instance.GetSalesInvoicesByDateRange(
                    filterStartDate, filterEndDate);

                DisplayInvoices(allInvoices);
                CalculateTotalAmount();

                lblTotalInvoices.Text = $"Tổng: {allInvoices.Count} hóa đơn";
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

        private void DisplayInvoices(List<SalesInvoices> invoices)
        {
            dgvInvoices.Rows.Clear();

            foreach (var inv in invoices)
            {
                int rowIndex = dgvInvoices.Rows.Add(
                    inv.InvoiceID,
                    inv.MaHoaDon ?? "",
                    inv.NgayBan?.ToString("dd/MM/yyyy HH:mm") ?? "",
                    inv.CustomerName ?? "N/A",
                    inv.UserName ?? "N/A",
                    inv.TongTien?.ToString("N0") + " đ" ?? "0 đ",
                    inv.SoTienDaTra?.ToString("N0") + " đ" ?? "0 đ",
                    inv.ConLai?.ToString("N0") + " đ" ?? "0 đ",
                    inv.TrangThaiThanhToan ?? "N/A"
                );

                // Highlight theo trạng thái
                var row = dgvInvoices.Rows[rowIndex];
                if (inv.TrangThaiThanhToan == "Đã thanh toán")
                {
                    row.Cells["colTrangThai"].Style.BackColor = Color.FromArgb(220, 255, 220);
                    row.Cells["colTrangThai"].Style.ForeColor = Color.DarkGreen;
                }
                else if (inv.TrangThaiThanhToan == "Ghi nợ")
                {
                    row.Cells["colTrangThai"].Style.BackColor = Color.FromArgb(255, 245, 220);
                    row.Cells["colTrangThai"].Style.ForeColor = Color.DarkOrange;
                }
            }
        }

        private void CalculateTotalAmount()
        {
            if (allInvoices == null || allInvoices.Count == 0)
            {
                lblTotalAmount.Text = "Tổng tiền: 0 đ";
                return;
            }

            decimal total = allInvoices.Sum(inv => inv.TongTien ?? 0);
            lblTotalAmount.Text = $"Tổng tiền: {total:N0} đ";
        }
        #endregion

        #region Event Handlers - Filters
        private void DtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            filterStartDate = dtpStartDate.Value.Date;
            if (filterStartDate > filterEndDate)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpStartDate.Value = filterEndDate;
                return;
            }
            LoadData();
        }

        private void DtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            filterEndDate = dtpEndDate.Value.Date;
            if (filterEndDate < filterStartDate)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpEndDate.Value = filterStartDate;
                return;
            }
            LoadData();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterInvoices();
        }

        private void CboStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterInvoices();
        }

        private void FilterInvoices()
        {
            if (allInvoices == null) return;

            string searchText = txtSearch.Text.ToLower().Trim();
            string selectedStatus = cboStatusFilter.SelectedItem?.ToString();

            var filteredInvoices = allInvoices.Where(inv =>
            {
                // Filter by search text
                bool matchSearch = string.IsNullOrEmpty(searchText) ||
                    (inv.MaHoaDon ?? "").ToLower().Contains(searchText) ||
                    (inv.CustomerName ?? "").ToLower().Contains(searchText);

                // Filter by status
                bool matchStatus = selectedStatus == "Tất cả" ||
                    string.IsNullOrEmpty(selectedStatus) ||
                    inv.TrangThaiThanhToan == selectedStatus;

                return matchSearch && matchStatus;
            }).ToList();

            DisplayInvoices(filteredInvoices);
            lblTotalInvoices.Text = $"Tổng: {filteredInvoices.Count} hóa đơn";

            // Tính lại tổng tiền cho filtered list
            decimal total = filteredInvoices.Sum(inv => inv.TongTien ?? 0);
            lblTotalAmount.Text = $"Tổng tiền: {total:N0} đ";
        }
        #endregion

        #region Event Handlers - Buttons
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var posForm = new POSDialog();
                if (posForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    MessageBox.Show("Tạo hóa đơn thành công!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form POS: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboStatusFilter.SelectedIndex = 0;
            InitializeFilters();
            LoadData();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng xuất Excel đang được phát triển",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Event Handlers - DataGridView
        private void DgvInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int invoiceID = Convert.ToInt32(dgvInvoices.Rows[e.RowIndex].Cells["colInvoiceID"].Value);
            selectedInvoice = allInvoices.FirstOrDefault(inv => inv.InvoiceID == invoiceID);

            if (selectedInvoice == null) return;

            if (dgvInvoices.Columns[e.ColumnIndex].Name == "colActions")
            {
                ShowActionsMenu(e.RowIndex);
            }
        }

        private void ShowActionsMenu(int rowIndex)
        {
            if (selectedInvoice == null) return;

            var menu = new ContextMenuStrip();

            // Xem chi tiết
            var viewItem = new ToolStripMenuItem("👁️ Xem chi tiết");
            viewItem.Click += (s, e) => ViewInvoiceDetails();
            menu.Items.Add(viewItem);

            // Trả nợ (nếu còn nợ)
            if (selectedInvoice.ConLai > 0)
            {
                var payItem = new ToolStripMenuItem("💰 Trả nợ");
                payItem.Click += (s, e) => PayDebt();
                menu.Items.Add(payItem);
            }

            menu.Items.Add(new ToolStripSeparator());

            // Xóa (chỉ cho phép trong ngày)
            if (selectedInvoice.NgayBan.HasValue &&
                selectedInvoice.NgayBan.Value.Date == DateTime.Now.Date)
            {
                var deleteItem = new ToolStripMenuItem("🗑️ Xóa hóa đơn");
                deleteItem.Click += (s, e) => DeleteInvoice();
                deleteItem.ForeColor = Color.Red;
                menu.Items.Add(deleteItem);
            }

            var cellRect = dgvInvoices.GetCellDisplayRectangle(
                dgvInvoices.Columns["colActions"].Index, rowIndex, true);
            menu.Show(dgvInvoices, cellRect.Left, cellRect.Bottom);
        }

        private void DgvInvoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ViewInvoiceDetails();
            }
        }
        #endregion

        #region CRUD Operations
        private void ViewInvoiceDetails()
        {
            if (selectedInvoice == null) return;

            try
            {
                var detailForm = new SalesInvoiceDetailDialog(selectedInvoice.InvoiceID);
                detailForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở chi tiết: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PayDebt()
        {
            if (selectedInvoice == null) return;

            try
            {
                var paymentForm = new PaymentDialog(selectedInvoice.InvoiceID, selectedInvoice.CustomerID);
                if (paymentForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    MessageBox.Show("Thanh toán thành công!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi trả nợ: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteInvoice()
        {
            if (selectedInvoice == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa hóa đơn '{selectedInvoice.MaHoaDon}'?\n\n" +
                "Lưu ý: Xóa hóa đơn sẽ cộng lại số lượng hàng đã bán vào kho!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    int deleteResult = SalesInvoiceDAO.Instance.DeleteSalesInvoice(selectedInvoice.InvoiceID);

                    if (deleteResult == 0)
                    {
                        MessageBox.Show("Xóa hóa đơn thành công!",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show(GetErrorMessage(deleteResult),
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa: {ex.Message}",
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
                case -1: return "Hóa đơn không tồn tại";
                case -2: return "Không thể xóa hóa đơn đã quá thời gian cho phép (chỉ được xóa trong ngày)";
                case -99: return "Lỗi hệ thống";
                default: return "Lỗi không xác định";
            }
        }
        #endregion
    }
}