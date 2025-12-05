using System;
using System.Drawing;
using System.Windows.Forms;
using DoubleTRice.DT;
using DoubleTRice.LOGIC;
using Guna.UI2.WinForms;

namespace DoubleTRice.UI.ChildForms
{
    public partial class ReportForm : BaseChildForm
    {
        private Color primaryColor = Color.FromArgb(0, 150, 120);
        private Color accentColor = Color.FromArgb(0, 180, 140);

        public ReportForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            // 1. Set tab names
            tabPage1.Text = "Doanh Thu";
            tabPage2.Text = "Tồn kho";
            tabPage3.Text = "Công nợ KH";
            tabPage4.Text = "Công nợ NCC";
            tabPage5.Text = "Dashboard";

            // 2. Wire up events
            this.btnViewRevenueReport.Click += new EventHandler(this.btnViewRevenueReport_Click);
            this.btnViewInventoryReport.Click += new EventHandler(this.btnViewInventoryReport_Click);
            this.btnViewCustomerDebtReport.Click += new EventHandler(this.btnViewCustomerDebtReport_Click);
            this.btnViewSupplierDebtReport.Click += new EventHandler(this.btnViewSupplierDebtReport_Click);
            this.btnExport.Click += new EventHandler(this.btnExport_Click);

            // 3. Apply professional styling
            ApplyProfessionalStyle();
            InitializeDefaults();

            // 4. IMPORTANT: ChildForm configuration
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.Dock = DockStyle.Fill;
        }

        private void InitializeDefaults()
        {
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;

            nudMonth.Minimum = 1;
            nudMonth.Maximum = 12;
            nudMonth.Value = DateTime.Now.Month;

            nudYear.Minimum = 2020;
            nudYear.Maximum = DateTime.Now.Year + 5;
            nudYear.Value = DateTime.Now.Year;

            LoadDashboard();
        }

        private void ApplyProfessionalStyle()
        {
            // Style main panels
            pnlHeader.FillColor = Color.Transparent;
            pnlContent.FillColor = Color.Transparent;

            // Style TabControl
            TabControl.TabButtonIdleState.FillColor = Color.White;
            TabControl.TabButtonIdleState.ForeColor = Color.Gray;
            TabControl.TabButtonSelectedState.FillColor = primaryColor;
            TabControl.TabButtonSelectedState.ForeColor = Color.White;

            // Style all buttons
            StyleButton(btnViewRevenueReport);
            StyleButton(btnViewInventoryReport);
            StyleButton(btnViewCustomerDebtReport);
            StyleButton(btnViewSupplierDebtReport);
            StyleButton(btnExport);

            // Style all grids
            StyleGrid(dgvRevenueReport);
            StyleGrid(dgvInventoryReport);
            StyleGrid(dgvCustomerDebt);
            StyleGrid(dgvSupplierDebt);

            // Style dashboard labels
            StyleDashboardLabel(lblDashboardRevenue);
            StyleDashboardLabel(lblDashboardProfit);
            StyleDashboardLabel(lblDashboardInvoices);
            StyleDashboardLabel(lblDashboardLowStock);
            StyleDashboardLabel(lblDashboardCustomerDebt);
            StyleDashboardLabel(lblDashboardSupplierDebt);

            // Style title
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = primaryColor;
        }

        private void StyleButton(Guna2Button btn)
        {
            if (btn == null) return;
            btn.BorderRadius = 8;
            btn.FillColor = primaryColor;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btn.HoverState.FillColor = accentColor;
        }

        private void StyleGrid(Guna2DataGridView dgv)
        {
            if (dgv == null) return;

            // Header styling
            dgv.ThemeStyle.HeaderStyle.BackColor = primaryColor;
            dgv.ThemeStyle.HeaderStyle.Height = 40;
            dgv.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ThemeStyle.HeaderStyle.ForeColor = Color.White;

            // Row styling - FIXED TEXT COLOR
            dgv.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgv.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            dgv.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgv.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;

            // Default cell style
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Alternating rows
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            dgv.RowTemplate.Height = 35;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(230, 230, 230);
        }

        private void StyleDashboardLabel(Guna2HtmlLabel lbl)
        {
            if (lbl == null) return;
            lbl.ForeColor = primaryColor;
            lbl.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        }

        #region Event Handlers

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

                lblTotalRevenue.Text = $"Tổng doanh thu: {ReportService.CalculateTotalRevenue(result.data):N0} đ";
                lblTotalRevenue.ForeColor = Color.Green;
                lblTotalProfit.Text = $"Tổng lợi nhuận: {ReportService.CalculateTotalProfit(result.data):N0} đ";
                lblTotalProfit.ForeColor = Color.Blue;
            }
            else MessageBox.Show(result.message);
        }

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

        private void btnViewDashboard_Click(object sender, EventArgs e) => LoadDashboard();

        private void LoadDashboard()
        {
            var result = ReportService.GetDashboardSummary((int)nudMonth.Value, (int)nudYear.Value);
            if (result.success && result.data != null)
            {
                var d = result.data;
                lblDashboardRevenue.Text = $"💰 Doanh thu: {d.TongDoanhThuThang:N0} đ";
                lblDashboardProfit.Text = $"📈 Lợi nhuận: {d.TongLoiNhuanThang:N0} đ";
                lblDashboardCustomerDebt.Text = $"👥 Nợ phải thu: {d.TongCongNoKhach:N0} đ";
                lblDashboardSupplierDebt.Text = $"🏭 Nợ phải trả: {d.TongCongNoNCC:N0} đ";
                lblDashboardLowStock.Text = $"⚠️ Sắp hết hàng: {d.SoSanPhamSapHet} SP";
                lblDashboardInvoices.Text = $"📄 Tổng hóa đơn: {d.TongSoHoaDon}";
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
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Helper Methods

        private void SetHeader(DataGridView dgv, string col, string text)
        {
            if (dgv.Columns[col] != null)
                dgv.Columns[col].HeaderText = text;
        }

        private void FormatMoney(DataGridView dgv, string col)
        {
            if (dgv.Columns[col] != null)
                dgv.Columns[col].DefaultCellStyle.Format = "N0";
        }

        private void HideCol(DataGridView dgv, string col)
        {
            if (dgv.Columns[col] != null)
                dgv.Columns[col].Visible = false;
        }

        #endregion

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}