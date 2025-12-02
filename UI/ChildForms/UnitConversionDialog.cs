using DoubleTRice.DAO;
using DoubleTRice.DT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace DoubleTRice.UI.ChildForms
{
    public partial class UnitConversionDialog : Form
    {
        #region Fields
        private int productID;
        private string productName;
        private int baseUnitID;
        private List<Units> allUnits;
        private List<ProductUnitConversions> conversions;
        #endregion

        #region Constructor
        public UnitConversionDialog(int productID, string productName)
        {
            InitializeComponent();
            this.productID = productID;
            this.productName = productName;

            // ✅ Khởi tạo các list trước
            allUnits = new List<Units>();
            conversions = new List<ProductUnitConversions>();
            LoadData();
        }
        #endregion

        #region Load Data
        private void LoadData()
        {
            try
            {
                // ✅ KHỞI TẠO conversions TRƯỚC KHI SỬ DỤNG
                conversions = new List<ProductUnitConversions>();
                // Load product info
                var product = ProductDAO.Instance.GetProductByID(productID);
                if (product != null)
                {
                    baseUnitID = product.BaseUnitID;
                    lblProductInfo.Text = $"Sản phẩm: {productName} | Đơn vị cơ sở: {product.BaseUnitName}";
                }

                // Load all units
                allUnits = ProductDAO.Instance.GetAllUnits();
                // ✅ Load conversions TRƯỚC KHI gọi LoadUnitsComboBox
                conversions = ProductDAO.Instance.GetProductUnitConversions(productID);

                LoadUnitsComboBox();

                // Load existing conversions
                LoadConversions();
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi tải dữ liệu: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"LoadData error: {ex}");
            }
        }

        private void LoadUnitsComboBox()
        {
            cboUnit.Items.Clear();

            // ✅ Kiểm tra null cho conversions và allUnits
            if (conversions == null)
                conversions = new List<ProductUnitConversions>();

            if (allUnits == null || allUnits.Count == 0)
            {
                ShowError("Không có đơn vị tính nào trong hệ thống");
                return;
            }

            // Chỉ hiển thị các đơn vị chưa có quy đổi (trừ base unit)
            var availableUnits = allUnits.Where(u =>
                u.UnitID != baseUnitID &&
                !conversions.Any(c => c.UnitID == u.UnitID)
            ).ToList();

            foreach (var unit in availableUnits)
            {
                cboUnit.Items.Add(unit.TenDVT);
            }

            if (cboUnit.Items.Count > 0)
            {
                cboUnit.SelectedIndex = 0;
            }
            else
            {
                // Thông báo nếu không còn đơn vị nào để thêm
                ShowError("Đã thêm tất cả các đơn vị tính có sẵn");
            }
        }

        private void LoadConversions()
        {
            try
            {
                // ✅ Lấy lại conversions nếu chưa có
                if (conversions == null)
                {
                    conversions = ProductDAO.Instance.GetProductUnitConversions(productID);
                }

                dgvConversions.Rows.Clear();

                if (conversions == null || conversions.Count == 0)
                {
                    // Không có quy đổi nào
                    return;
                }

                foreach (var conv in conversions)
                {
                    // Không hiển thị quy đổi cơ sở (1:1)
                    if (conv.GiaTriQuyDoi == 1.0)
                        continue;

                    dgvConversions.Rows.Add(
                        conv.ConversionID,
                        conv.UnitName,
                        $"{conv.GiaTriQuyDoi} kg"
                    );
                }
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi tải quy đổi: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"LoadConversions error: {ex}");
            }
        }        
        #endregion

        #region Event Handlers
        private void BtnAddConversion_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                string selectedUnitName = cboUnit.SelectedItem.ToString();
                var selectedUnit = allUnits.FirstOrDefault(u => u.TenDVT == selectedUnitName);

                if (selectedUnit == null)
                {
                    ShowError("Đơn vị tính không hợp lệ");
                    return;
                }

                double conversionValue = double.Parse(txtConversionValue.Text);

                // Thêm quy đổi
                int result = ProductDAO.Instance.InsertUnitConversion(
                    productID,
                    selectedUnit.UnitID,
                    conversionValue
                );

                if (result == 0)
                {
                    MessageBox.Show("Thêm quy đổi thành công!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtConversionValue.Clear();
                    LoadData();
                }
                else
                {
                    ShowError(GetErrorMessage(result));
                }
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi: {ex.Message}");
            }
        }

        private void DgvConversions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int conversionID = Convert.ToInt32(dgvConversions.Rows[e.RowIndex].Cells["colConversionID"].Value);
            var conversion = conversions.FirstOrDefault(c => c.ConversionID == conversionID);

            if (conversion == null) return;

            // Edit
            if (dgvConversions.Columns[e.ColumnIndex].Name == "colEdit")
            {
                EditConversion(conversion);
            }
            // Delete
            else if (dgvConversions.Columns[e.ColumnIndex].Name == "colDelete")
            {
                DeleteConversion(conversion);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region CRUD Operations
        private void EditConversion(ProductUnitConversions conversion)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                $"Nhập giá trị quy đổi mới cho {conversion.UnitName}:\n(Hiện tại: {conversion.GiaTriQuyDoi} kg)",
                "Sửa Quy đổi",
                conversion.GiaTriQuyDoi.ToString()
            );

            if (string.IsNullOrWhiteSpace(input)) return;

            if (!double.TryParse(input, out double newValue) || newValue <= 0)
            {
                ShowError("Giá trị quy đổi phải là số dương");
                return;
            }

            try
            {
                int result = ProductDAO.Instance.UpdateUnitConversion(
                    conversion.ConversionID,
                    newValue
                );

                if (result == 0)
                {
                    MessageBox.Show("Cập nhật quy đổi thành công!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    ShowError(GetErrorMessage(result));
                }
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi: {ex.Message}");
            }
        }

        private void DeleteConversion(ProductUnitConversions conversion)
        {
            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa quy đổi '{conversion.UnitName}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    int deleteResult = ProductDAO.Instance.DeleteUnitConversion(conversion.ConversionID);

                    if (deleteResult == 0)
                    {
                        MessageBox.Show("Xóa quy đổi thành công!",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        ShowError(GetErrorMessage(deleteResult));
                    }
                }
                catch (Exception ex)
                {
                    ShowError($"Lỗi: {ex.Message}");
                }
            }
        }
        #endregion

        #region Validation
        private bool ValidateInput()
        {
            if (cboUnit.SelectedIndex < 0)
            {
                ShowError("Vui lòng chọn đơn vị tính");
                cboUnit.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtConversionValue.Text))
            {
                ShowError("Vui lòng nhập giá trị quy đổi");
                txtConversionValue.Focus();
                return false;
            }

            if (!double.TryParse(txtConversionValue.Text, out double value) || value <= 0)
            {
                ShowError("Giá trị quy đổi phải là số dương");
                txtConversionValue.Focus();
                return false;
            }

            HideError();
            return true;
        }
        #endregion

        #region Helper Methods
        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
            lblError.Height = 40;
        }

        private void HideError()
        {
            lblError.Visible = false;
            lblError.Height = 0;
        }

        private string GetErrorMessage(int resultCode)
        {
            switch (resultCode)
            {
                case -2: return "Quy đổi này đã tồn tại";
                case -3: return "Không thể xóa quy đổi cơ sở";
                case -99: return "Lỗi hệ thống";
                default: return "Lỗi không xác định";
            }
        }
        #endregion

        private void txtConversionValue_TextChanged(object sender, EventArgs e)
        {

        }
    }
}