using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoubleTRice.DT;
using DoubleTRice.LOGIC;

namespace DoubleTRice.UI
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Set default dates
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;

            // Set default month/year
            nudMonth.Value = DateTime.Now.Month;
            nudYear.Value = DateTime.Now.Year;
        }

        #region Button Handlers

        private void btnViewRevenueReport_Click(object sender, EventArgs e)
        {
            var (success, data, message) = ReportService.GetRevenueReport(
                dtpStartDate.Value, dtpEndDate.Value);

            if (!success)
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hiển thị dữ liệu
            dgvRevenueReport.DataSource = data;
            FormatRevenueGrid();

            // Hiển thị tổng
            var totalRevenue = ReportService.CalculateTotalRevenue(data);
            var totalProfit = ReportService.CalculateTotalProfit(data);

            lblTotalRevenue.Text = $"Tổng doanh thu: {totalRevenue:N0} đ";
            lblTotalProfit.Text = $"Tổng lợi nhuận: {totalProfit:N0} đ";
        }

        private void btnViewInventoryReport_Click(object sender, EventArgs e)
        {
            var (success, data, message) = ReportService.GetInventoryReport();

            if (!success)
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvInventoryReport.DataSource = data;
            FormatInventoryGrid();

            // Highlight sản phẩm sắp hết
            HighlightLowStockProducts();
        }

        private void btnViewCustomerDebtReport_Click(object sender, EventArgs e)
        {
            var (success, data, message) = ReportService.GetCustomerDebtReport();

            if (!success)
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvCustomerDebt.DataSource = data;
            FormatDebtGrid(dgvCustomerDebt);
        }

        private void btnViewSupplierDebtReport_Click(object sender, EventArgs e)
        {
            var (success, data, message) = ReportService.GetSupplierDebtReport();

            if (!success)
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvSupplierDebt.DataSource = data;
            FormatDebtGrid(dgvSupplierDebt);
        }

        private void btnViewDashboard_Click(object sender, EventArgs e)
        {
            int month = (int)nudMonth.Value;
            int year = (int)nudYear.Value;

            var (success, data, message) = ReportService.GetDashboardSummary(month, year);

            if (!success)
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hiển thị dashboard
            lblDashboardRevenue.Text = $"{data.TongDoanhThuThang:N0} đ";
            lblDashboardProfit.Text = $"{data.TongLoiNhuanThang:N0} đ";
            lblDashboardCustomerDebt.Text = $"{data.TongCongNoKhach:N0} đ";
            lblDashboardSupplierDebt.Text = $"{data.TongCongNoNCC:N0} đ";
            lblDashboardLowStock.Text = $"{data.SoSanPhamSapHet} sản phẩm";
            lblDashboardInvoices.Text = $"{data.TongSoHoaDon} hóa đơn";
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng xuất Excel đang được phát triển",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // TODO: Implement Excel export
        }

        #endregion

        #region Helper Methods

        private void FormatRevenueGrid()
        {
            dgvRevenueReport.Columns["Ngay"].HeaderText = "Ngày";
            dgvRevenueReport.Columns["Ngay"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvRevenueReport.Columns["TongDoanhThu"].HeaderText = "Doanh thu";
            dgvRevenueReport.Columns["TongDoanhThu"].DefaultCellStyle.Format = "N0";
            dgvRevenueReport.Columns["TongGiaVon"].HeaderText = "Giá vốn";
            dgvRevenueReport.Columns["TongGiaVon"].DefaultCellStyle.Format = "N0";
            dgvRevenueReport.Columns["LoiNhuan"].HeaderText = "Lợi nhuận";
            dgvRevenueReport.Columns["LoiNhuan"].DefaultCellStyle.Format = "N0";
            dgvRevenueReport.Columns["SoHoaDon"].HeaderText = "Số HĐ";

            dgvRevenueReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FormatInventoryGrid()
        {
            dgvInventoryReport.Columns["ProductID"].Visible = false;
            dgvInventoryReport.Columns["TenSanPham"].HeaderText = "Sản phẩm";
            dgvInventoryReport.Columns["DonViTinh"].HeaderText = "Đơn vị";
            dgvInventoryReport.Columns["SoLuongTon"].HeaderText = "Tồn kho";
            dgvInventoryReport.Columns["TonKhoToiThieu"].HeaderText = "Tồn tối thiểu";
            dgvInventoryReport.Columns["GiaTriTonKho"].HeaderText = "Giá trị";
            dgvInventoryReport.Columns["GiaTriTonKho"].DefaultCellStyle.Format = "N0";
            dgvInventoryReport.Columns["TrangThai"].HeaderText = "Trạng thái";

            dgvInventoryReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FormatDebtGrid(DataGridView dgv)
        {
            dgv.Columns[0].Visible = false; // Hide ID
            dgv.Columns["TongMuaHang"].DefaultCellStyle.Format = "N0";
            dgv.Columns["TongDaTra"].DefaultCellStyle.Format = "N0";
            dgv.Columns["CongNo"].DefaultCellStyle.Format = "N0";

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void HighlightLowStockProducts()
        {
            foreach (DataGridViewRow row in dgvInventoryReport.Rows)
            {
                string trangThai = row.Cells["TrangThai"].Value?.ToString();
                if (trangThai == "Hết hàng")
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                }
                else if (trangThai == "Sắp hết")
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                }
            }
        }

        #endregion

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblDashboardInvoices_Click(object sender, EventArgs e)
        {

        }
    }

}

