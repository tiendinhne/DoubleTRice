using DoubleTRice.DAO;
using DoubleTRice.DT;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    public partial class GoodsReceiptDetailDialog : Form
    {
        #region Fields
        private int receiptID;
        private GoodsReceipts receipt;
        private List<GoodsReceiptDetails> details;
        #endregion

        #region Constructor
        public GoodsReceiptDetailDialog(int receiptID)
        {
            InitializeComponent();
            this.receiptID = receiptID;
            LoadReceiptData();
        }
        #endregion

        #region Load Data
        private void LoadReceiptData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Lấy thông tin phiếu nhập
                receipt = GoodsReceiptDAO.Instance.GetGoodsReceiptByID(receiptID);
                if (receipt == null)
                {
                    MessageBox.Show("Không tìm thấy phiếu nhập!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Hiển thị thông tin header
                DisplayReceiptInfo();

                // Lấy chi tiết
                details = GoodsReceiptDAO.Instance.GetGoodsReceiptDetails(receiptID);
                DisplayReceiptDetails();
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

        private void DisplayReceiptInfo()
        {
            // Lấy tên NCC
            var supplier = SupplierDAO.Instance.GetSupplierByID(receipt.SupplierID);
            string supplierName = supplier?.TenNhaCungCap ?? "N/A";
            string supplierPhone = supplier?.SoDienThoai ?? "N/A";

            // Lấy tên User
            var user = UserDAO.Instance.GetUserByID(receipt.UserID);
            string userName = user?.HoTen ?? "N/A";

            lblMaPhieu.Text = $"Mã phiếu: {receipt.MaPhieuNhap ?? "N/A"}";
            lblNgayNhap.Text = $"Ngày nhập: {receipt.NgayNhap?.ToString("dd/MM/yyyy HH:mm") ?? "N/A"}";
            lblSupplier.Text = $"Nhà cung cấp: {supplierName} ({supplierPhone})";
            lblUser.Text = $"Người nhập: {userName}";
            lblGhiChu.Text = $"Ghi chú: {receipt.GhiChu ?? "Không có"}";
            lblTongTien.Text = $"Tổng tiền: {receipt.TongTien?.ToString("N0") ?? "0"} đ";
        }

        private void DisplayReceiptDetails()
        {
            dgvDetails.Rows.Clear();

            foreach (var detail in details)
            {
                // Lấy tên sản phẩm
                var product = ProductDAO.Instance.GetProductByID(detail.ProductID);
                string productName = product?.TenSanPham ?? "N/A";

                // Lấy tên đơn vị
                var conversion = ProductDAO.Instance.GetProductUnitConversions(detail.ProductID)
                    .Find(u => u.UnitID == detail.UnitID);
                string unitName = conversion?.UnitName ?? "N/A";

                dgvDetails.Rows.Add(
                    productName,
                    unitName,
                    detail.SoLuong,
                    detail.DonGiaNhap.ToString("N0"),
                    detail.ThanhTien?.ToString("N0") ?? "0"
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
            MessageBox.Show("Chức năng in phiếu đang được phát triển",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}