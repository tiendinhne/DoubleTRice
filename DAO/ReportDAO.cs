using DoubleTRice.DT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleTRice.DAO
{
    /// <summary>
    /// Data Access Object cho Báo cáo & Thống kê
    /// </summary>
    public class ReportDAO
    {
        #region Singleton
        private static ReportDAO instance;
        public static ReportDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ReportDAO();
                return instance;
            }
        }

        private ReportDAO() { }
        #endregion

        #region Báo cáo Doanh thu

        /// <summary>
        /// Lấy báo cáo doanh thu theo khoảng thời gian
        /// </summary>
        public List<RevenueReportItem> GetRevenueReport(DateTime startDate, DateTime endDate)
        {
            List<RevenueReportItem> list = new List<RevenueReportItem>();

            try
            {
                string procName = "sp_GetRevenueReport";
                object[] parameters = { startDate, endDate };
                DataTable data = DataProvider.Instance.ExecuteQuery(procName, parameters, true);

                foreach (DataRow row in data.Rows)
                {
                    list.Add(new RevenueReportItem
                    {
                        Ngay = Convert.ToDateTime(row["Ngay"]),
                        TongDoanhThu = Convert.ToDecimal(row["TongDoanhThu"]),
                        TongGiaVon = Convert.ToDecimal(row["TongGiaVon"]),
                        LoiNhuan = Convert.ToDecimal(row["LoiNhuan"]),
                        SoHoaDon = Convert.ToInt32(row["SoHoaDon"])
                    });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetRevenueReport error: {ex.Message}");
            }

            return list;
        }

        #endregion

        #region Báo cáo Tồn kho

        /// <summary>
        /// Lấy báo cáo tồn kho & cảnh báo
        /// </summary>
        public List<InventoryReportItem> GetInventoryReport()
        {
            List<InventoryReportItem> list = new List<InventoryReportItem>();

            try
            {
                string procName = "sp_GetInventoryReport";
                DataTable data = DataProvider.Instance.ExecuteQuery(procName, null, true);

                foreach (DataRow row in data.Rows)
                {
                    list.Add(new InventoryReportItem
                    {
                        ProductID = Convert.ToInt32(row["ProductID"]),
                        TenSanPham = row["TenSanPham"].ToString(),
                        DonViTinh = row["DonViTinh"].ToString(),
                        SoLuongTon = Convert.ToDouble(row["SoLuongTon"]),
                        TonKhoToiThieu = Convert.ToDouble(row["TonKhoToiThieu"]),
                        GiaTriTonKho = Convert.ToDecimal(row["GiaTriTonKho"]),
                        TrangThai = row["TrangThai"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetInventoryReport error: {ex.Message}");
            }

            return list;
        }

        #endregion

        #region Báo cáo Công nợ

        /// <summary>
        /// Báo cáo công nợ khách hàng
        /// </summary>
        public List<CustomerDebtReportItem> GetCustomerDebtReport()
        {
            List<CustomerDebtReportItem> list = new List<CustomerDebtReportItem>();

            try
            {
                string procName = "sp_GetCustomerDebtReport";
                DataTable data = DataProvider.Instance.ExecuteQuery(procName, null, true);

                foreach (DataRow row in data.Rows)
                {
                    list.Add(new CustomerDebtReportItem
                    {
                        CustomerID = Convert.ToInt32(row["CustomerID"]),
                        TenKhachHang = row["TenKhachHang"].ToString(),
                        SoDienThoai = row["SoDienThoai"].ToString(),
                        TongMuaHang = Convert.ToDecimal(row["TongMuaHang"]),
                        TongDaTra = Convert.ToDecimal(row["TongDaTra"]),
                        CongNo = Convert.ToDecimal(row["CongNo"]),
                        SoHoaDonChuaTra = Convert.ToInt32(row["SoHoaDonChuaTra"])
                    });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetCustomerDebtReport error: {ex.Message}");
            }

            return list;
        }

        /// <summary>
        /// Báo cáo công nợ nhà cung cấp
        /// </summary>
        public List<SupplierDebtReportItem> GetSupplierDebtReport()
        {
            List<SupplierDebtReportItem> list = new List<SupplierDebtReportItem>();

            try
            {
                string procName = "sp_GetSupplierDebtReport";
                DataTable data = DataProvider.Instance.ExecuteQuery(procName, null, true);

                foreach (DataRow row in data.Rows)
                {
                    list.Add(new SupplierDebtReportItem
                    {
                        SupplierID = Convert.ToInt32(row["SupplierID"]),
                        TenNhaCungCap = row["TenNhaCungCap"].ToString(),
                        SoDienThoai = row["SoDienThoai"].ToString(),
                        TongNhapHang = Convert.ToDecimal(row["TongNhapHang"]),
                        TongDaTra = Convert.ToDecimal(row["TongDaTra"]),
                        CongNo = Convert.ToDecimal(row["CongNo"]),
                        SoPhieuNhapChuaTra = Convert.ToInt32(row["SoPhieuNhapChuaTra"])
                    });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetSupplierDebtReport error: {ex.Message}");
            }

            return list;
        }

        #endregion

        #region Dashboard

        /// <summary>
        /// Lấy tổng quan dashboard cho tháng/năm
        /// </summary>
        public DashboardSummary GetDashboardSummary(int month, int year)
        {
            try
            {
                string procName = "sp_GetDashboardSummary";
                object[] parameters = { month, year };
                DataTable data = DataProvider.Instance.ExecuteQuery(procName, parameters, true);

                if (data.Rows.Count > 0)
                {
                    DataRow row = data.Rows[0];
                    return new DashboardSummary
                    {
                        TongDoanhThuThang = Convert.ToDecimal(row["TongDoanhThuThang"]),
                        TongLoiNhuanThang = Convert.ToDecimal(row["TongLoiNhuanThang"]),
                        TongCongNoKhach = Convert.ToDecimal(row["TongCongNoKhach"]),
                        TongCongNoNCC = Convert.ToDecimal(row["TongCongNoNCC"]),
                        SoSanPhamSapHet = Convert.ToInt32(row["SoSanPhamSapHet"]),
                        TongSoHoaDon = Convert.ToInt32(row["TongSoHoaDon"])
                    };
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetDashboardSummary error: {ex.Message}");
            }

            return null;
        }

        #endregion
    }
}
