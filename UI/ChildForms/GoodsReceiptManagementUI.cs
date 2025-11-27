using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DoubleTRice.DAO;
using DoubleTRice.DT;

namespace DoubleTRice.UI.ChildForms
{
    public partial class GoodsReceiptManagementUI : BaseChildForm
    {
        #region Fields
        private List<GoodsReceipts> allReceipts;
        private GoodsReceipts selectedReceipt;
        private DateTime filterStartDate;
        private DateTime filterEndDate;
        #endregion

        #region Constructor
        public GoodsReceiptManagementUI()
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
                dgvReceipts.DataSource = null;
                this.Cursor = Cursors.WaitCursor;

                allReceipts = GoodsReceiptDAO.Instance.GetGoodsReceiptsByDateRange(
                    filterStartDate, filterEndDate);

                DisplayReceipts(allReceipts);
                CalculateTotalAmount();

                lblTotalReceipts.Text = $"Tổng: {allReceipts.Count} phiếu";
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

        private void DisplayReceipts(List<GoodsReceipts> receipts)
        {
            dgvReceipts.Rows.Clear();

            foreach (var r in receipts)
            {
                // Lấy tên NCC
                var supplier = SupplierDAO.Instance.GetSupplierByID(r.SupplierID);
                string supplierName = supplier?.TenNhaCungCap ?? "N/A";

                // Lấy tên User
                var user = UserDAO.Instance.GetUserByID(r.UserID);
                string userName = user?.HoTen ?? "N/A";

                dgvReceipts.Rows.Add(
                    r.ReceiptID,
                    r.MaPhieuNhap ?? "",
                    r.NgayNhap?.ToString("dd/MM/yyyy HH:mm") ?? "",
                    supplierName,
                    userName,
                    r.TongTien.HasValue ? r.TongTien.Value.ToString("N0") + " đ" : "0 đ",
                    r.GhiChu ?? ""
                );
            }
        }

        private void CalculateTotalAmount()
        {
            if (allReceipts == null || allReceipts.Count == 0)
            {
                lblTotalAmount.Text = "Tổng tiền: 0 đ";
                return;
            }

            decimal total = allReceipts.Sum(r => r.TongTien ?? 0);
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
            FilterReceipts();
        }

        private void FilterReceipts()
        {
            if (allReceipts == null) return;

            string searchText = txtSearch.Text.ToLower().Trim();

            var filteredReceipts = allReceipts.Where(r =>
            {
                var supplier = SupplierDAO.Instance.GetSupplierByID(r.SupplierID);
                string supplierName = supplier?.TenNhaCungCap ?? "";

                return (r.MaPhieuNhap ?? "").ToLower().Contains(searchText) ||
                       supplierName.ToLower().Contains(searchText) ||
                       (r.GhiChu ?? "").ToLower().Contains(searchText);
            }).ToList();

            DisplayReceipts(filteredReceipts);
            lblTotalReceipts.Text = $"Tổng: {filteredReceipts.Count} phiếu";
        }
        #endregion

        #region Event Handlers - Buttons
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new GoodsReceiptAddEditDialog();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                MessageBox.Show("Tạo phiếu nhập thành công!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
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
        private void DgvReceipts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int receiptID = Convert.ToInt32(dgvReceipts.Rows[e.RowIndex].Cells["colReceiptID"].Value);
            selectedReceipt = allReceipts.FirstOrDefault(r => r.ReceiptID == receiptID);

            if (selectedReceipt == null) return;

            if (dgvReceipts.Columns[e.ColumnIndex].Name == "colActions")
            {
                ShowActionsMenu(e.RowIndex);
            }
        }

        private void ShowActionsMenu(int rowIndex)
        {
            if (selectedReceipt == null) return;

            var menu = new ContextMenuStrip();

            // Xem chi tiết
            var viewItem = new ToolStripMenuItem("👁️ Xem chi tiết");
            viewItem.Click += (s, e) => ViewReceiptDetails();
            menu.Items.Add(viewItem);

            menu.Items.Add(new ToolStripSeparator());

            // Xóa (chỉ cho phép trong ngày)
            if (selectedReceipt.NgayNhap.HasValue &&
                selectedReceipt.NgayNhap.Value.Date == DateTime.Now.Date)
            {
                var deleteItem = new ToolStripMenuItem("🗑️ Xóa phiếu nhập");
                deleteItem.Click += (s, e) => DeleteReceipt();
                deleteItem.ForeColor = Color.Red;
                menu.Items.Add(deleteItem);
            }

            var cellRect = dgvReceipts.GetCellDisplayRectangle(
                dgvReceipts.Columns["colActions"].Index, rowIndex, true);
            menu.Show(dgvReceipts, cellRect.Left, cellRect.Bottom);
        }

        private void DgvReceipts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ViewReceiptDetails();
            }
        }
        #endregion

        #region CRUD Operations
        private void ViewReceiptDetails()
        {
            if (selectedReceipt == null) return;

            //var detailForm = new GoodsReceiptDetailDialog(selectedReceipt.ReceiptID);
            //detailForm.ShowDialog();
        }

        private void DeleteReceipt()
        {
            if (selectedReceipt == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa phiếu nhập '{selectedReceipt.MaPhieuNhap}'?\n\n" +
                "Lưu ý: Xóa phiếu sẽ trừ lại số lượng hàng đã nhập vào kho!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                int deleteResult = GoodsReceiptDAO.Instance.DeleteGoodsReceipt(selectedReceipt.ReceiptID);

                if (deleteResult == 0)
                {
                    MessageBox.Show("Xóa phiếu nhập thành công!",
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
                case -1: return "Phiếu nhập không tồn tại";
                case -2: return "Không thể xóa phiếu nhập đã quá thời gian cho phép";
                case -99: return "Lỗi hệ thống";
                default: return "Lỗi không xác định";
            }
        }
        #endregion
    }
}