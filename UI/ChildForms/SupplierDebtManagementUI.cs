using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DoubleTRice.DAO;

namespace DoubleTRice.UI.ChildForms
{
    public partial class SupplierDebtManagementUI : BaseChildForm
    {
        #region Fields
        private List<SupplierDebtSummary> allDebts;
        private SupplierDebtSummary selectedDebt;
        private MainUI main;
        #endregion

        #region Constructor
        public SupplierDebtManagementUI(MainUI mainUI)
        {
            InitializeComponent();
            this.main = mainUI;
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

                allDebts = SupplierDebtDAO.Instance.GetAllSupplierDebts();
                DisplayDebts(allDebts);

                lblTotalDebts.Text = $"Tổng: {allDebts.Count} nhà cung cấp đang nợ";
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

        private void DisplayDebts(List<SupplierDebtSummary> debts)
        {
            dgvDebts.Rows.Clear();

            foreach (var debt in debts)
            {
                int rowIndex = dgvDebts.Rows.Add(
                    debt.SupplierID,
                    debt.TenNhaCungCap,
                    debt.SoDienThoai ?? "",
                    $"{debt.TongNhapHang:N0}",
                    $"{debt.TongDaTra:N0}",
                    $"{debt.CongNoHienTai:N0}"
                );

                // Highlight công nợ cần ưu tiên trả
                var row = dgvDebts.Rows[rowIndex];
                if (debt.CongNoHienTai >= 50000000) // >= 50 triệu - Cần ưu tiên cao
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220);
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
                else if (debt.CongNoHienTai >= 20000000) // >= 20 triệu - Cần ưu tiên
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 220);
                }
            }
        }

        private void LoadStatistics()
        {
            try
            {
                var stats = SupplierDebtDAO.Instance.GetDebtStatistics();
                if (stats != null)
                {
                    lblStats.Text = $"📊 Tổng công nợ phải trả: {stats.TongCongNo:N0} đ | " +
                                   $"Nhà cung cấp: {stats.SoNhaCungCapNo} | " +
                                   $"Phiếu nhập: {stats.SoPhieuNhapNo}";
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
                d.TenNhaCungCap.ToLower().Contains(searchText) ||
                (d.SoDienThoai ?? "").ToLower().Contains(searchText)
            ).ToList();

            DisplayDebts(filteredDebts);
            lblTotalDebts.Text = $"Tổng: {filteredDebts.Count} nhà cung cấp";
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

        private void BtnTraNo_Click(object sender, EventArgs e)
        {
            if (selectedDebt == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở form chi tiết công nợ NCC
            var debtDetailForm = new SupplierDebtDetailDialog(selectedDebt.SupplierID);
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

            int supplierID = Convert.ToInt32(dgvDebts.Rows[e.RowIndex].Cells["colSupplierID"].Value);
            selectedDebt = allDebts.FirstOrDefault(d => d.SupplierID == supplierID);

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

            // Trả nợ
            var payItem = new ToolStripMenuItem("💰 Trả nợ");
            payItem.Click += (s, e) => BtnTraNo_Click(s, e);
            payItem.Font = new Font(payItem.Font, FontStyle.Bold);
            payItem.ForeColor = Color.Green;
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

            var debtDetailForm = new SupplierDebtDetailDialog(selectedDebt.SupplierID);
            debtDetailForm.ShowDialog();
            LoadData();
            LoadStatistics();
        }

        private void ViewTransactionHistory()
        {
            if (selectedDebt == null) return;

            MessageBox.Show(
                $"Lịch sử giao dịch với: {selectedDebt.TenNhaCungCap}\n\n" +
                "Chức năng đang được phát triển",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        #endregion

        #region Helper Methods
        private string GetErrorMessage(int resultCode)
        {
            switch (resultCode)
            {
                case -2: return "Số tiền không hợp lệ";
                case -3: return "Phiếu nhập không tồn tại";
                case -4: return "Số tiền trả vượt quá công nợ";
                case -99: return "Lỗi hệ thống";
                default: return "Lỗi không xác định";
            }
        }
        #endregion

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            main.OpenChildForm(new DebtManagementUI(main));
        }
    }
}