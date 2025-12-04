using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleTRice.DT;
using DoubleTRice.DAO;

namespace DoubleTRice.LOGIC
{
    /// <summary>
    /// Service xử lý logic nghiệp vụ cho báo cáo & thống kê
    /// </summary>
    public static class ReportService
    {
        #region Doanh thu & Lợi nhuận

        /// <summary>
        /// Lấy báo cáo doanh thu với validation
        /// </summary>
        public static (bool success, List<RevenueReportItem> data, string message)
            GetRevenueReport(DateTime startDate, DateTime endDate)
        {
            // Validation
            if (startDate > endDate)
            {
                return (false, null, "Ngày bắt đầu không được lớn hơn ngày kết thúc");
            }

            if ((endDate - startDate).TotalDays > 366)
            {
                return (false, null, "Khoảng thời gian không được quá 1 năm");
            }

            try
            {
                var data = ReportDAO.Instance.GetRevenueReport(startDate, endDate);

                if (data == null || data.Count == 0)
                {
                    return (true, new List<RevenueReportItem>(),
                        "Không có dữ liệu trong khoảng thời gian này");
                }

                return (true, data, $"Tìm thấy {data.Count} bản ghi");
            }
            catch (Exception ex)
            {
                return (false, null, $"Lỗi: {ex.Message}");
            }
        }

        /// <summary>
        /// Tính tổng doanh thu trong khoảng thời gian
        /// </summary>
        public static decimal CalculateTotalRevenue(List<RevenueReportItem> data)
        {
            return data?.Sum(x => x.TongDoanhThu) ?? 0;
        }

        /// <summary>
        /// Tính tổng lợi nhuận
        /// </summary>
        public static decimal CalculateTotalProfit(List<RevenueReportItem> data)
        {
            return data?.Sum(x => x.LoiNhuan) ?? 0;
        }

        #endregion

        #region Tồn kho

        /// <summary>
        /// Lấy báo cáo tồn kho
        /// </summary>
        public static (bool success, List<InventoryReportItem> data, string message)
            GetInventoryReport()
        {
            try
            {
                var data = ReportDAO.Instance.GetInventoryReport();

                if (data == null || data.Count == 0)
                {
                    return (true, new List<InventoryReportItem>(),
                        "Chưa có sản phẩm nào trong kho");
                }

                return (true, data, $"Tìm thấy {data.Count} sản phẩm");
            }
            catch (Exception ex)
            {
                return (false, null, $"Lỗi: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy danh sách sản phẩm sắp hết hàng
        /// </summary>
        public static List<InventoryReportItem> GetLowStockProducts(
            List<InventoryReportItem> data)
        {
            return data?.Where(x => x.CanCanhBao).ToList()
                ?? new List<InventoryReportItem>();
        }

        #endregion

        #region Công nợ

        /// <summary>
        /// Lấy báo cáo công nợ khách hàng
        /// </summary>
        public static (bool success, List<CustomerDebtReportItem> data, string message)
            GetCustomerDebtReport()
        {
            try
            {
                var data = ReportDAO.Instance.GetCustomerDebtReport();

                if (data == null || data.Count == 0)
                {
                    return (true, new List<CustomerDebtReportItem>(),
                        "Không có khách hàng nào đang nợ");
                }

                return (true, data, $"Tìm thấy {data.Count} khách hàng");
            }
            catch (Exception ex)
            {
                return (false, null, $"Lỗi: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy báo cáo công nợ nhà ccấp
        /// </summary>
        /// 
        public static (bool success, List<SupplierDebtReportItem> data, string message) GetSupplierDebtReport()
        {
            try
            {
                var data = ReportDAO.Instance.GetSupplierDebtReport();
                if (data == null || data.Count == 0)
                {
                    return (true, new List<SupplierDebtReportItem>(),
                        "Không còn nợ nhà cung cấp nào");
                }

                return (true, data, $"Tìm thấy {data.Count} nhà cung cấp");
            }
            catch (Exception ex)
            {
                return (false, null, $"Lỗi: {ex.Message}");
            }
        }
        #endregion

        #region Dashboard

        /// <summary>
        /// Lấy tổng quan dashboard
        /// </summary>
        public static (bool success, DashboardSummary data, string message)
            GetDashboardSummary(int month, int year)
        {
            // Validation
            if (month < 1 || month > 12)
            {
                return (false, null, "Tháng không hợp lệ");
            }

            if (year < 2000 || year > 2100)
            {
                return (false, null, "Năm không hợp lệ");
            }

            try
            {
                var data = ReportDAO.Instance.GetDashboardSummary(month, year);

                if (data == null)
                {
                    return (false, null, "Không thể lấy dữ liệu tổng quan");
                }

                return (true, data, "Thành công");
            }
            catch (Exception ex)
            {
                return (false, null, $"Lỗi: {ex.Message}");
            }
        }

        #endregion

        #region Xuất file

        /// <summary>
        /// Xuất báo cáo ra Excel (placeholder - cần thư viện như EPPlus)
        /// </summary>
        public static bool ExportToExcel<T>(List<T> data, string filePath, string sheetName)
        {
            // TODO: Implement xuất Excel sử dụng EPPlus hoặc ClosedXML
            // Hiện tại chỉ là placeholder
            throw new NotImplementedException("Chức năng xuất Excel chưa được triển khai");
        }

        #endregion
    }
}

