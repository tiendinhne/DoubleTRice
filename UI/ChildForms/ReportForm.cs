using System;
using System.Drawing;
using System.Windows.Forms;
using DoubleTRice.DT;
using DoubleTRice.LOGIC; // Namespace chứa ExportHelper
using Guna.UI2.WinForms;

namespace DoubleTRice.UI.ChildForms
{
    public partial class ReportForm : BaseChildForm
    {
        // Màu chủ đạo (Teal)
        private Color primaryColor = Color.FromArgb(0, 150, 120);

        public ReportForm()
        {
            InitializeComponent();

            // 1. ĐẶT TÊN TAB THEO YÊU CẦU
            tabPage1.Text = "Doanh Thu";
            tabPage2.Text = "Tồn kho";
            tabPage3.Text = "Công nợ KH";
            tabPage4.Text = "Công nợ NCC";
            tabPage5.Text = "Dashboard";

            // 2. KẾT NỐI SỰ KIỆN NÚT BẤM (Fix lỗi bấm không chạy)
            this.btnViewRevenueReport.Click += new EventHandler(this.btnViewRevenueReport_Click);
            this.btnViewInventoryReport.Click += new EventHandler(this.btnViewInventoryReport_Click);
            this.btnViewCustomerDebtReport.Click += new EventHandler(this.btnViewCustomerDebtReport_Click);
            this.btnViewSupplierDebtReport.Click += new EventHandler(this.btnViewSupplierDebtReport_Click);
            this.btnViewDashboard.Click += new EventHandler(this.btnViewDashboard_Click);
            this.btnExport.Click += new EventHandler(this.btnExport_Click);

            // 3. Làm đẹp và khởi tạo dữ liệu
            ApplyProfessionalStyle();
            InitializeDefaults();

            // QUAN TRỌNG KHI LÀM CHILDFORM:
            // Đảm bảo Form tự động resize theo Panel cha
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.Dock = DockStyle.Fill;
        }

        private void InitializeDefaults()
        {
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;

            nudMonth.Minimum = 1; nudMonth.Maximum = 12;
            nudMonth.Value = DateTime.Now.Month;

            nudYear.Minimum = 2020; nudYear.Maximum = DateTime.Now.Year + 5;
            nudYear.Value = DateTime.Now.Year;

            // Load Dashboard ngay khi mở form
            LoadDashboard();
        }

        private void ApplyProfessionalStyle()
        {
            // Style TabControl
            TabControl.TabButtonIdleState.FillColor = Color.White;
            TabControl.TabButtonIdleState.ForeColor = Color.Gray;
            TabControl.TabButtonSelectedState.FillColor = primaryColor;
            TabControl.TabButtonSelectedState.ForeColor = Color.White;

            // Style Buttons
            StyleButton(btnViewRevenueReport);
            StyleButton(btnViewInventoryReport);
            StyleButton(btnViewCustomerDebtReport);
            StyleButton(btnViewSupplierDebtReport);
            StyleButton(btnViewDashboard);
            StyleButton(btnExport);

            // Style Grids
            StyleGrid(dgvRevenueReport);
            StyleGrid(dgvInventoryReport);
            StyleGrid(dgvCustomerDebt);
            StyleGrid(dgvSupplierDebt);

            // Style Labels Dashboard
            StyleDashboardLabel(lblDashboardRevenue);
            StyleDashboardLabel(lblDashboardProfit);
            StyleDashboardLabel(lblDashboardInvoices);
            StyleDashboardLabel(lblDashboardLowStock);
            StyleDashboardLabel(lblDashboardCustomerDebt);
            StyleDashboardLabel(lblDashboardSupplierDebt);
        }

        private void StyleButton(Guna2Button btn)
        {
            if (btn == null) return;
            btn.BorderRadius = 6;
            btn.FillColor = primaryColor;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        }

        private void StyleGrid(Guna2DataGridView dgv)
        {
            if (dgv == null) return;
            //dgv.ThemeStyle.HeaderStyle.BackColor = primaryColor;
            //dgv.ThemeStyle.HeaderStyle.Height = 40;
            //dgv.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            //dgv.RowTemplate.Height = 35;
            //dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Header Style
            dgv.ThemeStyle.HeaderStyle.BackColor = primaryColor;
            dgv.ThemeStyle.HeaderStyle.Height = 40;
            dgv.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Row Style (FIX THE TEXT COLOR HERE)
            dgv.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgv.ThemeStyle.RowsStyle.ForeColor = Color.Black; // Force text to be Black
            dgv.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgv.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);

            // Default Cell Style (Double check)
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Alternating Rows
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            // Row Height
            dgv.RowTemplate.Height = 35;
        }

        private void StyleDashboardLabel(Guna2HtmlLabel lbl)
        {
            if (lbl != null)
            {
                lbl.ForeColor = primaryColor;
                lbl.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            }
        }

        #region Xử lý sự kiện

        // 1. DOANH THU
        private void btnViewRevenueReport_Click(object sender, EventArgs e)
        {
            var result = ReportService.GetRevenueReport(dtpStartDate.Value, dtpEndDate.Value);
            if (result.success)
            {
                dgvRevenueReport.DataSource = result.data;
                SetHeader(dgvRevenueReport, "Ngay", "Ngày");
                SetHeader(dgvRevenueReport, "TongDoanhThu", "Doanh thu");
                SetHeader(dgvRevenueReport, "TongGiaVon", "Giá vốn");
                SetHeader(dgvRevenueReport, "LoiNhuan", "Lợi nhuận");
                SetHeader(dgvRevenueReport, "SoHoaDon", "Số HĐ");
                HideCol(dgvRevenueReport, "TyLeLoiNhuan");

                FormatMoney(dgvRevenueReport, "TongDoanhThu");
                FormatMoney(dgvRevenueReport, "TongGiaVon");
                FormatMoney(dgvRevenueReport, "LoiNhuan");

                lblTotalRevenue.Text = $"Doanh thu: {ReportService.CalculateTotalRevenue(result.data):N0} đ";
                lblTotalRevenue.ForeColor = Color.Green;
                lblTotalProfit.Text = $"Lợi nhuận: {ReportService.CalculateTotalProfit(result.data):N0} đ";
                lblTotalProfit.ForeColor = Color.Blue; 
            }
            else MessageBox.Show(result.message);
        }

        // 2. TỒN KHO
        private void btnViewInventoryReport_Click(object sender, EventArgs e)
        {
            var result = ReportService.GetInventoryReport();
            if (result.success)
            {
                dgvInventoryReport.DataSource = result.data;
                SetHeader(dgvInventoryReport, "TenSanPham", "Tên SP");
                SetHeader(dgvInventoryReport, "DonViTinh", "ĐVT");
                SetHeader(dgvInventoryReport, "SoLuongTon", "Tồn kho");
                SetHeader(dgvInventoryReport, "TonKhoToiThieu", "Min Tồn");
                SetHeader(dgvInventoryReport, "GiaTriTonKho", "Giá trị");
                SetHeader(dgvInventoryReport, "TrangThai", "Trạng thái");
                HideCol(dgvInventoryReport, "ProductID");
                HideCol(dgvInventoryReport, "CanCanhBao");

                FormatMoney(dgvInventoryReport, "GiaTriTonKho");

                foreach (DataGridViewRow row in dgvInventoryReport.Rows)
                {
                    var item = row.DataBoundItem as InventoryReportItem;
                    if (item != null && item.CanCanhBao)
                        row.DefaultCellStyle.BackColor = (item.SoLuongTon <= 0) ? Color.MistyRose : Color.LightYellow;
                }
            }
            else MessageBox.Show(result.message);
        }

        // 3. CÔNG NỢ KH
        private void btnViewCustomerDebtReport_Click(object sender, EventArgs e)
        {
            var result = ReportService.GetCustomerDebtReport();
            if (result.success)
            {
                dgvCustomerDebt.DataSource = result.data;
                SetHeader(dgvCustomerDebt, "TenKhachHang", "Khách hàng");
                SetHeader(dgvCustomerDebt, "SoDienThoai", "SĐT");
                SetHeader(dgvCustomerDebt, "TongMuaHang", "Tổng mua");
                SetHeader(dgvCustomerDebt, "TongDaTra", "Đã trả");
                SetHeader(dgvCustomerDebt, "CongNo", "Còn nợ");
                HideCol(dgvCustomerDebt, "CustomerID");

                FormatMoney(dgvCustomerDebt, "TongMuaHang");
                FormatMoney(dgvCustomerDebt, "TongDaTra");
                FormatMoney(dgvCustomerDebt, "CongNo");
            }
            else
            {
                dgvCustomerDebt.DataSource = null;
                MessageBox.Show(result.message);
            }
        }

        // 4. CÔNG NỢ NCC
        private void btnViewSupplierDebtReport_Click(object sender, EventArgs e)
        {
            var result = ReportService.GetSupplierDebtReport();
            if (result.success)
            {
                dgvSupplierDebt.DataSource = result.data;
                SetHeader(dgvSupplierDebt, "TenNhaCungCap", "Nhà cung cấp");
                SetHeader(dgvSupplierDebt, "TongNhapHang", "Tổng nhập");
                SetHeader(dgvSupplierDebt, "TongDaTra", "Đã trả");
                SetHeader(dgvSupplierDebt, "CongNo", "Còn nợ");
                HideCol(dgvSupplierDebt, "SupplierID");

                FormatMoney(dgvSupplierDebt, "TongNhapHang");
                FormatMoney(dgvSupplierDebt, "TongDaTra");
                FormatMoney(dgvSupplierDebt, "CongNo");
            }
            else
            {
                dgvSupplierDebt.DataSource = null;
                MessageBox.Show(result.message);
            }
        }

        // 5. DASHBOARD
        private void btnViewDashboard_Click(object sender, EventArgs e) => LoadDashboard();

        private void LoadDashboard()
        {
            var result = ReportService.GetDashboardSummary((int)nudMonth.Value, (int)nudYear.Value);
            if (result.success && result.data != null)
            {
                var d = result.data;
                lblDashboardRevenue.Text = $"Doanh thu: {d.TongDoanhThuThang:N0} đ";
                lblDashboardProfit.Text = $"Lợi nhuận: {d.TongLoiNhuanThang:N0} đ";
                lblDashboardCustomerDebt.Text = $"Nợ phải thu: {d.TongCongNoKhach:N0} đ";
                lblDashboardSupplierDebt.Text = $"Nợ phải trả: {d.TongCongNoNCC:N0} đ";
                lblDashboardLowStock.Text = $"Sắp hết hàng: {d.SoSanPhamSapHet} SP";
                lblDashboardInvoices.Text = $"Tổng hóa đơn: {d.TongSoHoaDon}";
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataGridView target = null;
            string name = "Report";

            if (TabControl.SelectedTab == tabPage1) { target = dgvRevenueReport; name = "DoanhThu"; }
            else if (TabControl.SelectedTab == tabPage2) { target = dgvInventoryReport; name = "TonKho"; }
            else if (TabControl.SelectedTab == tabPage3) { target = dgvCustomerDebt; name = "CongNoKH"; }
            else if (TabControl.SelectedTab == tabPage4) { target = dgvSupplierDebt; name = "CongNoNCC"; }

            if (target != null && target.DataSource != null)
                ExportHelper.ExportToExcel(target, name);
            else
                MessageBox.Show("Không có dữ liệu để xuất.");
        }
        #endregion

        #region Helpers
        private void SetHeader(DataGridView dgv, string col, string text)
        {
            if (dgv.Columns[col] != null) dgv.Columns[col].HeaderText = text;
        }
        private void FormatMoney(DataGridView dgv, string col)
        {
            if (dgv.Columns[col] != null) dgv.Columns[col].DefaultCellStyle.Format = "N0";
        }
        private void HideCol(DataGridView dgv, string col)
        {
            if (dgv.Columns[col] != null) dgv.Columns[col].Visible = false;
        }
        private void lblDashboardInvoices_Click(object sender, EventArgs e) { }
        private void lblTitle_Click(object sender, EventArgs e) { }
        #endregion

        private void btnExport_Click_1(object sender, EventArgs e)
        {

        }
    }
}