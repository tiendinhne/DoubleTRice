using DoubleTRice.DAO;
using DoubleTRice.DT;
using System;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    public partial class SupplierAddEditDialog : Form
    {
        #region Fields
        private Suppliers editingSupplier;
        private bool isEditMode;
        #endregion

        #region Constructor
        public SupplierAddEditDialog(Suppliers supplier = null)
        {
            InitializeComponent();
            editingSupplier = supplier;
            isEditMode = (supplier != null);

            if (isEditMode)
            {
                LoadSupplierData();
                lblTitle.Text = "✏️ Sửa thông tin nhà cung cấp";
            }
            else
            {
                lblTitle.Text = "➕ Thêm nhà cung cấp mới";
            }
        }
        #endregion

        #region Methods
        private void LoadSupplierData()
        {
            if (editingSupplier == null) return;

            txtTenNhaCungCap.Text = editingSupplier.TenNhaCungCap;
            txtSoDienThoai.Text = editingSupplier.SoDienThoai ?? "";
            txtDiaChi.Text = editingSupplier.DiaChi ?? "";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            this.Cursor = Cursors.WaitCursor;
            btnSave.Enabled = false;

            try
            {
                string tenNhaCungCap = txtTenNhaCungCap.Text.Trim();
                string soDienThoai = string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ?
                    null : txtSoDienThoai.Text.Trim();
                string diaChi = string.IsNullOrWhiteSpace(txtDiaChi.Text) ?
                    null : txtDiaChi.Text.Trim();

                if (isEditMode)
                {
                    // UPDATE
                    int result = SupplierDAO.Instance.UpdateSupplier(
                        editingSupplier.SupplierID, tenNhaCungCap, soDienThoai, diaChi);

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
                    var (result, newSupplierID) = SupplierDAO.Instance.InsertSupplier(
                        tenNhaCungCap, soDienThoai, diaChi);

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
                System.Diagnostics.Debug.WriteLine($"Save supplier error: {ex}");
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
            // Tên nhà cung cấp
            if (string.IsNullOrWhiteSpace(txtTenNhaCungCap.Text))
            {
                ShowError("Vui lòng nhập tên nhà cung cấp");
                txtTenNhaCungCap.Focus();
                return false;
            }

            // Validate số điện thoại nếu có nhập
            if (!string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                string phone = txtSoDienThoai.Text.Trim();
                if (phone.Length < 10 || phone.Length > 11)
                {
                    ShowError("Số điện thoại phải có 10-11 chữ số");
                    txtSoDienThoai.Focus();
                    return false;
                }
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
                case -1: return "Nhà cung cấp không tồn tại";
                case -2: return "Tên không được để trống";
                case -3: return "Tên nhà cung cấp đã tồn tại";
                case -99: return "Lỗi hệ thống";
                default: return "Lỗi không xác định";
            }
        }
        #endregion
    }
}