using DoubleTRice.DAO;
using DoubleTRice.DT;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    public partial class StockAdjustmentAddDialog : Form
    {
        #region Fields
        private List<Products> allProducts;
        private int currentUserID;
        #endregion

        #region Constructor
        public StockAdjustmentAddDialog()
        {
            InitializeComponent();
            InitializeData();
            currentUserID = SessionManager.CurrentUser?.UserID ?? 0;
        }
        #endregion

        #region Initialize
        private void InitializeData()
        {
            // Load sản phẩm
            LoadProducts();

            // Set ngày hiện tại
            dtpNgayDieuChinh.Value = DateTime.Now;

            // Mặc định chọn Xuất hủy
            rdoXuatHuy.Checked = true;
        }

        private void LoadProducts()
        {
            try
            {
                allProducts = ProductDAO.Instance.GetAllProductsDetail();
                cboProduct.Items.Clear();
                cboProduct.Items.Add("-- Chọn sản phẩm --");

                foreach (var product in allProducts)
                {
                    // Hiển thị cả tồn kho hiện tại
                    string displayText = $"{product.TenSanPham} (Tồn: {product.SoLuongTon} kg)";
                    cboProduct.Items.Add(displayText);
                }

                cboProduct.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải sản phẩm: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Event Handlers - Product Selection
        private void CboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduct.SelectedIndex <= 0) return;

            // Lấy sản phẩm đã chọn
            var product = allProducts[cboProduct.SelectedIndex - 1];

            // Hiển thị tồn kho hiện tại
            lblCurrentStock.Text = $"Tồn kho hiện tại: {product.SoLuongTon} kg";
            lblCurrentStock.Visible = true;

            // Cảnh báo nếu xuất hủy mà không đủ hàng
            if (rdoXuatHuy.Checked)
            {
                ShowStockWarning(product);
            }
        }

        private void RdoLoaiPhieu_CheckedChanged(object sender, EventArgs e)
        {
            if (cboProduct.SelectedIndex > 0)
            {
                var product = allProducts[cboProduct.SelectedIndex - 1];
                ShowStockWarning(product);
            }

            // Đổi màu label
            if (rdoXuatHuy.Checked)
            {
                lblLoaiPhieu.ForeColor = Color.FromArgb(220, 53, 69);
                lblSoLuong.Text = "Số lượng xuất hủy (kg) *";
            }
            else
            {
                lblLoaiPhieu.ForeColor = Color.FromArgb(0, 150, 120);
                lblSoLuong.Text = "Số lượng nhập thừa (kg) *";
            }
        }

        private void TxtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (cboProduct.SelectedIndex > 0 && rdoXuatHuy.Checked)
            {
                var product = allProducts[cboProduct.SelectedIndex - 1];
                ShowStockWarning(product);
            }
        }

        private void ShowStockWarning(Products product)
        {
            if (!rdoXuatHuy.Checked)
            {
                lblWarning.Visible = false;
                return;
            }

            if (double.TryParse(txtSoLuong.Text, out double soLuong))
            {
                if (soLuong > product.SoLuongTon)
                {
                    lblWarning.Text = $"⚠️ Cảnh báo: Số lượng xuất ({soLuong} kg) lớn hơn tồn kho ({product.SoLuongTon} kg)!";
                    lblWarning.ForeColor = Color.Red;
                    lblWarning.Visible = true;
                }
                else
                {
                    lblWarning.Visible = false;
                }
            }
        }
        #endregion

        #region Event Handlers - Save/Cancel
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            // Confirm
            string loaiPhieu = rdoXuatHuy.Checked ? "XUẤT HỦY" : "NHẬP THỪA";
            var confirmResult = MessageBox.Show(
                $"Xác nhận tạo phiếu {loaiPhieu}?\n\n" +
                $"Sản phẩm: {cboProduct.SelectedItem.ToString().Split('(')[0].Trim()}\n" +
                $"Số lượng: {txtSoLuong.Text} kg\n" +
                $"Lý do: {txtLyDo.Text}",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes) return;

            this.Cursor = Cursors.WaitCursor;
            btnSave.Enabled = false;

            try
            {
                // Lấy thông tin
                var product = allProducts[cboProduct.SelectedIndex - 1];
                DateTime ngayDieuChinh = dtpNgayDieuChinh.Value;
                double soLuong = double.Parse(txtSoLuong.Text);

                // Số âm nếu xuất hủy, số dương nếu nhập thừa
                double soLuongDieuChinh = rdoXuatHuy.Checked ? -soLuong : soLuong;

                string lyDo = txtLyDo.Text.Trim();

                // Tạo phiếu điều chỉnh
                var (result, newAdjustmentID) = StockAdjustmentDAO.Instance.InsertStockAdjustment(
                    product.ProductID,
                    currentUserID,
                    ngayDieuChinh,
                    soLuongDieuChinh,
                    lyDo);

                if (result == 0)
                {
                    string successMsg = rdoXuatHuy.Checked ?
                        $"Tạo phiếu xuất hủy thành công!\nĐã trừ {soLuong} kg khỏi kho." :
                        $"Tạo phiếu nhập thừa thành công!\nĐã cộng {soLuong} kg vào kho.";

                    MessageBox.Show(successMsg,
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ShowError(GetErrorMessage(result));
                }
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi lưu phiếu điều chỉnh: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Save adjustment error: {ex}");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnSave.Enabled = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region Validation
        private bool ValidateInputs()
        {
            if (cboProduct.SelectedIndex <= 0)
            {
                ShowError("Vui lòng chọn sản phẩm");
                cboProduct.Focus();
                return false;
            }

            if (!double.TryParse(txtSoLuong.Text, out double soLuong) || soLuong <= 0)
            {
                ShowError("Số lượng phải là số dương");
                txtSoLuong.Focus();
                return false;
            }

            // Kiểm tra tồn kho nếu xuất hủy
            if (rdoXuatHuy.Checked)
            {
                var product = allProducts[cboProduct.SelectedIndex - 1];
                if (soLuong > product.SoLuongTon)
                {
                    var result = MessageBox.Show(
                        $"Số lượng xuất hủy ({soLuong} kg) lớn hơn tồn kho ({product.SoLuongTon} kg)!\n\n" +
                        "Bạn có chắc muốn tiếp tục?",
                        "Cảnh báo",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result != DialogResult.Yes)
                    {
                        txtSoLuong.Focus();
                        return false;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(txtLyDo.Text))
            {
                ShowError("Vui lòng nhập lý do điều chỉnh");
                txtLyDo.Focus();
                return false;
            }

            if (txtLyDo.Text.Trim().Length < 10)
            {
                ShowError("Lý do phải có ít nhất 10 ký tự");
                txtLyDo.Focus();
                return false;
            }

            HideError();
            return true;
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }

        private void HideError()
        {
            lblError.Visible = false;
        }

        private string GetErrorMessage(int resultCode)
        {
            switch (resultCode)
            {
                case -1: return "Sản phẩm không tồn tại";
                case -2: return "Lý do không được để trống";
                case -99: return "Lỗi hệ thống";
                default: return "Lỗi không xác định";
            }
        }
        #endregion
    }
}