using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DoubleTRice.DAO;
using DoubleTRice.DT;

namespace DoubleTRice.UI.ChildForms
{
    public partial class StockAdjustmentManagementUI : BaseChildForm
    {
        #region Fields
        private List<StockAdjustments> allAdjustments;
        private StockAdjustments selectedAdjustment;
        private DateTime filterStartDate;
        private DateTime filterEndDate;
        #endregion

        #region Constructor
        public StockAdjustmentManagementUI()
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
                dgvAdjustments.DataSource = null;
                this.Cursor = Cursors.WaitCursor;

                allAdjustments = StockAdjustmentDAO.Instance.GetStockAdjustmentsByDateRange(
                    filterStartDate, filterEndDate);

                DisplayAdjustments(allAdjustments);

                lblTotalAdjustments.Text = $"Tổng: {allAdjustments.Count} phiếu";
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

        private void DisplayAdjustments(List<StockAdjustments> adjustments)
        {
            dgvAdjustments.Rows.Clear();

            foreach (var adj in adjustments)
            {
                // Lấy tên sản phẩm
                var product = ProductDAO.Instance.GetProductByID(adj.ProductID);
                string productName = product?.TenSanPham ?? "N/A";

                // Lấy tên User
                var user = UserDAO.Instance.GetUserByID(adj.UserID);
                string userName = user?.HoTen ?? "N/A";

                // Xác định loại phiếu
                string loaiPhieu = adj.SoLuongDieuChinh > 0 ? "Nhập thừa" : "Xuất hủy";
                Color rowColor = adj.SoLuongDieuChinh > 0 ?
                    Color.FromArgb(220, 255, 220) : Color.FromArgb(255, 220, 220);

                int rowIndex = dgvAdjustments.Rows.Add(
                    adj.AdjustmentID,
                    adj.MaPhieu ?? "",
                    adj.NgayDieuChinh?.ToString("dd/MM/yyyy HH:mm") ?? "",
                    productName,
                    loaiPhieu,
                    Math.Abs(adj.SoLuongDieuChinh),
                    userName,
                    adj.LyDo ?? ""
                );

                // Tô màu dòng
                dgvAdjustments.Rows[rowIndex].DefaultCellStyle.BackColor = rowColor;
            }
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
            FilterAdjustments();
        }

        private void CboTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterAdjustments();
        }

        private void FilterAdjustments()
        {
            if (allAdjustments == null) return;

            string searchText = txtSearch.Text.ToLower().Trim();
            string selectedType = cboTypeFilter.SelectedItem?.ToString();

            var filteredAdjustments = allAdjustments.Where(adj =>
            {
                var product = ProductDAO.Instance.GetProductByID(adj.ProductID);
                string productName = product?.TenSanPham ?? "";

                bool matchSearch = string.IsNullOrEmpty(searchText) ||
                    (adj.MaPhieu ?? "").ToLower().Contains(searchText) ||
                    productName.ToLower().Contains(searchText) ||
                    (adj.LyDo ?? "").ToLower().Contains(searchText);

                bool matchType = selectedType == "Tất cả" || string.IsNullOrEmpty(selectedType) ||
                    (selectedType == "Nhập thừa" && adj.SoLuongDieuChinh > 0) ||
                    (selectedType == "Xuất hủy" && adj.SoLuongDieuChinh < 0);

                return matchSearch && matchType;
            }).ToList();

            DisplayAdjustments(filteredAdjustments);
            lblTotalAdjustments.Text = $"Tổng: {filteredAdjustments.Count} phiếu";
        }
        #endregion

        #region Event Handlers - Buttons
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new StockAdjustmentAddDialog();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                MessageBox.Show("Tạo phiếu điều chỉnh thành công!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboTypeFilter.SelectedIndex = 0;
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
        private void DgvAdjustments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int adjustmentID = Convert.ToInt32(dgvAdjustments.Rows[e.RowIndex].Cells["colAdjustmentID"].Value);
            selectedAdjustment = allAdjustments.FirstOrDefault(a => a.AdjustmentID == adjustmentID);

            if (selectedAdjustment == null) return;

            if (dgvAdjustments.Columns[e.ColumnIndex].Name == "colActions")
            {
                ShowActionsMenu(e.RowIndex);
            }
        }

        private void ShowActionsMenu(int rowIndex)
        {
            if (selectedAdjustment == null) return;

            var menu = new ContextMenuStrip();

            // Xem chi tiết
            var viewItem = new ToolStripMenuItem("👁️ Xem chi tiết");
            viewItem.Click += (s, e) => ViewAdjustmentDetails();
            menu.Items.Add(viewItem);

            menu.Items.Add(new ToolStripSeparator());

            // Xóa (chỉ cho phép trong ngày)
            if (selectedAdjustment.NgayDieuChinh.HasValue &&
                selectedAdjustment.NgayDieuChinh.Value.Date == DateTime.Now.Date)
            {
                var deleteItem = new ToolStripMenuItem("🗑️ Xóa phiếu");
                deleteItem.Click += (s, e) => DeleteAdjustment();
                deleteItem.ForeColor = Color.Red;
                menu.Items.Add(deleteItem);
            }

            var cellRect = dgvAdjustments.GetCellDisplayRectangle(
                dgvAdjustments.Columns["colActions"].Index, rowIndex, true);
            menu.Show(dgvAdjustments, cellRect.Left, cellRect.Bottom);
        }

        private void DgvAdjustments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ViewAdjustmentDetails();
            }
        }
        #endregion

        #region CRUD Operations
        private void ViewAdjustmentDetails()
        {
            if (selectedAdjustment == null) return;

            // Lấy thông tin chi tiết
            var product = ProductDAO.Instance.GetProductByID(selectedAdjustment.ProductID);
            var user = UserDAO.Instance.GetUserByID(selectedAdjustment.UserID);

            string loaiPhieu = selectedAdjustment.SoLuongDieuChinh > 0 ? "Nhập thừa" : "Xuất hủy";
            string message = $"Mã phiếu: {selectedAdjustment.MaPhieu}\n" +
                           $"Loại: {loaiPhieu}\n" +
                           $"Sản phẩm: {product?.TenSanPham ?? "N/A"}\n" +
                           $"Số lượng: {Math.Abs(selectedAdjustment.SoLuongDieuChinh)} kg\n" +
                           $"Ngày điều chỉnh: {selectedAdjustment.NgayDieuChinh?.ToString("dd/MM/yyyy HH:mm")}\n" +
                           $"Người thực hiện: {user?.HoTen ?? "N/A"}\n\n" +
                           $"Lý do:\n{selectedAdjustment.LyDo ?? "Không có"}";

            MessageBox.Show(message, "Chi tiết phiếu điều chỉnh",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeleteAdjustment()
        {
            if (selectedAdjustment == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa phiếu điều chỉnh '{selectedAdjustment.MaPhieu}'?\n\n" +
                "Lưu ý: Xóa phiếu sẽ hoàn tác lại số lượng đã điều chỉnh!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                int deleteResult = StockAdjustmentDAO.Instance.DeleteStockAdjustment(selectedAdjustment.AdjustmentID);

                if (deleteResult == 0)
                {
                    MessageBox.Show("Xóa phiếu điều chỉnh thành công!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show(GetErrorMessage(deleteResult),
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
                case -1: return "Phiếu điều chỉnh không tồn tại";
                case -2: return "Không thể xóa phiếu đã quá thời gian cho phép";
                case -99: return "Lỗi hệ thống";
                default: return "Lỗi không xác định";
            }
        }
        #endregion
    }
}