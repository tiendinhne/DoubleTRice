using DoubleTRice.DAO;
using DoubleTRice.DT;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    public partial class ProductAddEditDialog : Form
    {
        #region Fields
        private Products editingProduct;
        private bool isEditMode;
        private List<Units> allUnits;
        #endregion

        #region Constructor
        public ProductAddEditDialog(Products product = null)
        {
            InitializeComponent();
            editingProduct = product;
            isEditMode = (product != null);

            LoadUnits();

            if (isEditMode)
            {
                LoadProductData();
                lblTitle.Text = "✏️ Sửa thông tin sản phẩm";
            }
            else
            {
                lblTitle.Text = "➕ Thêm sản phẩm mới";
            }
        }
        #endregion

        #region Methods
        private void LoadUnits()
        {
            try
            {
                allUnits = ProductDAO.Instance.GetAllUnits();
                cboBaseUnit.Items.Clear();

                foreach (var unit in allUnits)
                {
                    cboBaseUnit.Items.Add(unit.TenDVT);
                }

                if (cboBaseUnit.Items.Count > 0)
                {
                    // Default chọn "kg" nếu có
                    int kgIndex = cboBaseUnit.Items.IndexOf("kg");
                    cboBaseUnit.SelectedIndex = kgIndex >= 0 ? kgIndex : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải đơn vị tính: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductData()
        {
            if (editingProduct == null) return;

            txtTenSanPham.Text = editingProduct.TenSanPham;
            txtTonKhoToiThieu.Text = editingProduct.TonKhoToiThieu.ToString();

            // Select đơn vị tính hiện tại
            int unitIndex = cboBaseUnit.Items.IndexOf(editingProduct.BaseUnitName);
            if (unitIndex >= 0)
            {
                cboBaseUnit.SelectedIndex = unitIndex;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            this.Cursor = Cursors.WaitCursor;
            btnSave.Enabled = false;

            try
            {
                string tenSanPham = txtTenSanPham.Text.Trim();
                int baseUnitID = GetSelectedUnitID();
                double tonKhoToiThieu = double.Parse(txtTonKhoToiThieu.Text);

                if (isEditMode)
                {
                    // UPDATE
                    int result = ProductDAO.Instance.UpdateProduct(
                        editingProduct.ProductID, tenSanPham, baseUnitID, tonKhoToiThieu);

                    if (result == 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ShowError(GetErrorMessage(result));
                    }
                }
                else
                {
                    // INSERT
                    var (result, newProductID) = ProductDAO.Instance.InsertProduct(
                        tenSanPham, baseUnitID, tonKhoToiThieu);

                    if (result == 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ShowError(GetErrorMessage(result));
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Save product error: {ex}");
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

        private bool ValidateInputs()
        {
            // Tên sản phẩm
            if (string.IsNullOrWhiteSpace(txtTenSanPham.Text))
            {
                ShowError("Vui lòng nhập tên sản phẩm");
                txtTenSanPham.Focus();
                return false;
            }

            // Đơn vị tính
            if (cboBaseUnit.SelectedIndex < 0)
            {
                ShowError("Vui lòng chọn đơn vị tính cơ sở");
                cboBaseUnit.Focus();
                return false;
            }

            // Tồn kho tối thiểu
            if (!double.TryParse(txtTonKhoToiThieu.Text, out double tonKho) || tonKho < 0)
            {
                ShowError("Tồn kho tối thiểu phải là số >= 0");
                txtTonKhoToiThieu.Focus();
                return false;
            }

            HideError();
            return true;
        }

        private int GetSelectedUnitID()
        {
            if (cboBaseUnit.SelectedIndex < 0) return 0;

            string selectedUnitName = cboBaseUnit.SelectedItem.ToString();
            var unit = allUnits.Find(u => u.TenDVT == selectedUnitName);
            return unit?.UnitID ?? 0;
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
                case -2: return "Tên sản phẩm đã tồn tại";
                case -3: return "Đơn vị tính không tồn tại";
                case -99: return "Lỗi hệ thống";
                default: return "Lỗi không xác định";
            }
        }
        #endregion
    }
}
