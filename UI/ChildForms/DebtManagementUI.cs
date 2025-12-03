using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DoubleTRice.DAO;

namespace DoubleTRice.UI.ChildForms
{
    public partial class DebtManagementUI : BaseChildForm
    {
        #region Fields
        private List<CustomerDebtSummary> allDebts;
        private CustomerDebtSummary selectedDebt;
        #endregion

        #region Constructor
        public DebtManagementUI()
        {
            InitializeComponent();
            LoadData();
            LoadStatistics();
        }
        #endregion

        #region Load Data
        private void LoadData()
        {
            try
            {
                dgvDebts.Rows.Clear();
                this.Cursor = Cursors.WaitCursor;

                allDebts = DebtManagementDAO.Instance.GetAllCustomerDebts();
                DisplayDebts(allDebts);

                lblTotalDebts.Text = $"Tổng: {allDebts.Count} khách hàng còn nợ";
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

        private void DisplayDebts(List<CustomerDebtSummary> debts)
        {
            dgvDebts.Rows.Clear();

            foreach (var debt in debts)
            {
                int rowIndex = dgvDebts.Rows.Add(
                    debt.CustomerID,
                    debt.TenKhachHang,
                    debt.SoDienThoai ?? "",
                    $"{debt.TongMuaHang:N0}",
                    $"{debt.TongDaTra:N0}",
                    $"{debt.CongNoHienTai:N0}"
                );

                // Highlight công nợ cao
                var row = dgvDebts.Rows[rowIndex];
                if (debt.CongNoHienTai >= 10000000) // >= 10 triệu
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220);
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
                else if (debt.CongNoHienTai >= 5000000) // >= 5 triệu
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 220);
                }
            }
        }

        private void LoadStatistics()
        {
            try
            {
                var stats = DebtManagementDAO.Instance.GetDebtStatistics();
                if (stats != null)
                {
                    lblStats.Text = $"📊 Tổng công nợ: {stats.TongCongNo:N0} đ | " +
                                   $"Khách hàng: {stats.SoKhachHangNo} | " +
                                   $"Hóa đơn: {stats.SoHoaDonNo}";
                }
            }
            catch (Exception ex)
            {
                lblStats.Text = "Không thể tải thống kê";
                System.Diagnostics.Debug.WriteLine($"LoadStatistics error: {ex.Message}");
            }
        }
        #endregion

        #region Event Handlers - Search
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterDebts();
        }

        private void FilterDebts()
        {
            if (allDebts == null) return;

            string searchText = txtSearch.Text.ToLower().Trim();

            var filteredDebts = allDebts.Where(d =>
                d.TenKhachHang.ToLower().Contains(searchText) ||
                (d.SoDienThoai ?? "").ToLower().Contains(searchText)
            ).ToList();

            DisplayDebts(filteredDebts);
            lblTotalDebts.Text = $"Tổng: {filteredDebts.Count} khách hàng";
        }
        #endregion

        #region Event Handlers - Buttons
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadData();
            LoadStatistics();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng xuất Excel đang được phát triển",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            if (selectedDebt == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở form danh sách hóa đơn còn nợ để chọn và thanh toán
            var debtDetailForm = new DebtDetailDialog(selectedDebt.CustomerID);
            if (debtDetailForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                LoadStatistics();
            }
        }
        #endregion

        #region Event Handlers - DataGridView
        private void DgvDebts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int customerID = Convert.ToInt32(dgvDebts.Rows[e.RowIndex].Cells["colCustomerID"].Value);
            selectedDebt = allDebts.FirstOrDefault(d => d.CustomerID == customerID);

            if (selectedDebt == null) return;

            if (dgvDebts.Columns[e.ColumnIndex].Name == "colActions")
            {
                ShowActionsMenu(e.RowIndex);
            }
        }

        private void ShowActionsMenu(int rowIndex)
        {
            if (selectedDebt == null) return;

            var menu = new ContextMenuStrip();

            // Xem chi tiết
            var viewItem = new ToolStripMenuItem("👁️ Xem chi tiết công nợ");
            viewItem.Click += (s, e) => ViewDebtDetails();
            menu.Items.Add(viewItem);

            // Thanh toán
            var payItem = new ToolStripMenuItem("💰 Thanh toán");
            payItem.Click += (s, e) => BtnThanhToan_Click(s, e);
            payItem.Font = new Font(payItem.Font, FontStyle.Bold);
            menu.Items.Add(payItem);

            menu.Items.Add(new ToolStripSeparator());

            // Lịch sử giao dịch
            var historyItem = new ToolStripMenuItem("📜 Lịch sử giao dịch");
            historyItem.Click += (s, e) => ViewTransactionHistory();
            menu.Items.Add(historyItem);

            var cellRect = dgvDebts.GetCellDisplayRectangle(
                dgvDebts.Columns["colActions"].Index, rowIndex, true);
            menu.Show(dgvDebts, cellRect.Left, cellRect.Bottom);
        }

        private void DgvDebts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ViewDebtDetails();
            }
        }
        #endregion

        #region Actions
        private void ViewDebtDetails()
        {
            if (selectedDebt == null) return;

            var debtDetailForm = new DebtDetailDialog(selectedDebt.CustomerID);
            debtDetailForm.ShowDialog();
        }

        private void ViewTransactionHistory()
        {
            if (selectedDebt == null) return;

            MessageBox.Show(
                $"Lịch sử giao dịch của: {selectedDebt.TenKhachHang}\n\n" +
                "Chức năng đang được phát triển",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        #endregion
    }
}