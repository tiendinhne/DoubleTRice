using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DoubleTRice.DT;
using Guna.UI2.WinForms;

namespace DoubleTRice.UI.ChildForms
{
    public partial class ProductSelectionDialog : Form
    {
        #region Fields
        private Products product;
        private List<ProductUnitConversions> conversions;

        public ProductUnitConversions SelectedConversion { get; private set; }
        public double Quantity { get; private set; }
        #endregion

        #region Constructor
        public ProductSelectionDialog(Products product, List<ProductUnitConversions> conversions)
        {
            this.product = product;
            this.conversions = conversions;
            InitializeComponent();
            LoadData();
        }
        #endregion

        private void LoadData()
        {
            lblProductName.Text = $"Sản phẩm: {product.TenSanPham}";

            cboUnit.Items.Clear();
            foreach (var conv in conversions)
            {
                cboUnit.Items.Add(conv.UnitName);
            }

            if (cboUnit.Items.Count > 0)
                cboUnit.SelectedIndex = 0;

            UpdateStockInfo();
        }

        private void CboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStockInfo();
        }

        private void TxtQuantity_TextChanged(object sender, EventArgs e)
        {
            UpdateStockInfo();
        }

        private void UpdateStockInfo()
        {
            if (cboUnit.SelectedIndex < 0) return;

            var conversion = conversions[cboUnit.SelectedIndex];
            double availableQty = product.SoLuongTon / conversion.GiaTriQuyDoi;

            lblStock.Text = $"Tồn kho: {availableQty:N2} {conversion.UnitName} " +
                          $"({product.SoLuongTon:N2} {product.BaseUnitName})";

            // Kiểm tra số lượng
            if (double.TryParse(txtQuantity.Text, out double qty))
            {
                double required = qty * conversion.GiaTriQuyDoi;
                if (required > product.SoLuongTon)
                {
                    lblStock.ForeColor = Color.Red;
                    lblStock.Text += " ⚠️ Không đủ hàng!";
                }
                else
                {
                    lblStock.ForeColor = Color.FromArgb(0, 150, 120);
                }
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (cboUnit.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtQuantity.Text, out double qty) || qty <= 0)
            {
                MessageBox.Show("Số lượng phải là số dương!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SelectedConversion = conversions[cboUnit.SelectedIndex];
            Quantity = qty;

            // Kiểm tra tồn kho
            double required = qty * SelectedConversion.GiaTriQuyDoi;
            if (required > product.SoLuongTon)
            {
                var result = MessageBox.Show(
                    $"Không đủ hàng trong kho!\n\n" +
                    $"Yêu cầu: {required:N2} {product.BaseUnitName}\n" +
                    $"Tồn kho: {product.SoLuongTon:N2} {product.BaseUnitName}\n\n" +
                    $"Bạn có muốn tiếp tục?",
                    "Cảnh báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}