using DoubleTRice.DAO;
using DoubleTRice.DT;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    public partial class CustomerAddEditDialog : Form
    {
        #region Fields
        private Customers editingCustomer;
        private bool isEditMode;
        #endregion

        #region Constructor
        public CustomerAddEditDialog(Customers customer = null)
        {
            InitializeComponent();
            editingCustomer = customer;
            isEditMode = (customer != null);

            if (isEditMode)
            {
                LoadCustomerData();
                lblTitle.Text = "✏️ Sửa thông tin khách hàng";

                // Không cho sửa Khách vãng lai
                if (customer.TenKhachHang == "Khách vãng lai")
                {
                    txtTenKhachHang.Enabled = false;
                    txtSoDienThoai.Enabled = false;
                    txtDiaChi.Enabled = false;
                    btnSave.Enabled = false;
                    ShowError("Không thể sửa thông tin Khách vãng lai");
                }
            }
            else
            {
                lblTitle.Text = "➕ Thêm khách hàng mới";
            }
        }
        #endregion

        #region Methods
        private void LoadCustomerData()
        {
            if (editingCustomer == null) return;

            txtTenKhachHang.Text = editingCustomer.TenKhachHang;
            txtSoDienThoai.Text = editingCustomer.SoDienThoai ?? "";
            txtDiaChi.Text = editingCustomer.DiaChi ?? "";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            this.Cursor = Cursors.WaitCursor;
            btnSave.Enabled = false;

            try
            {
                string tenKhachHang = txtTenKhachHang.Text.Trim();
                string soDienThoai = string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ?
                    null : txtSoDienThoai.Text.Trim();
                string diaChi = string.IsNullOrWhiteSpace(txtDiaChi.Text) ?
                    null : txtDiaChi.Text.Trim();

                if (isEditMode)
                {
                    // UPDATE
                    int result = CustomerDAO.Instance.UpdateCustomer(
                        editingCustomer.CustomerID, tenKhachHang, soDienThoai, diaChi);

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
                    var (result, newCustomerID) = CustomerDAO.Instance.InsertCustomer(
                        tenKhachHang, soDienThoai, diaChi);

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
                System.Diagnostics.Debug.WriteLine($"Save customer error: {ex}");
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
            // Tên khách hàng
            if (string.IsNullOrWhiteSpace(txtTenKhachHang.Text))
            {
                ShowError("Vui lòng nhập tên khách hàng");
                txtTenKhachHang.Focus();
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
                case -1: return "Khách hàng không tồn tại";
                case -2: return "Tên không được để trống";
                case -3: return "Tên khách hàng đã tồn tại";
                case -5: return "Không thể sửa Khách vãng lai";
                case -99: return "Lỗi hệ thống";
                default: return "Lỗi không xác định";
            }
        }
        #endregion
    }
}