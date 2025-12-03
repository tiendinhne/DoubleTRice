using System;
using System.Collections.Generic;
using System.Data;
using DoubleTRice.DT;
using System.Data.SqlClient;

namespace DoubleTRice.DAO
{
    /// <summary>
    /// Data Access Object cho Quản lý Công Nợ
    /// </summary>
    public class DebtManagementDAO
    {
        #region Singleton
        private static DebtManagementDAO instance;
        public static DebtManagementDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DebtManagementDAO();
                return instance;
            }
        }

        private DebtManagementDAO() { }
        #endregion

        #region 1. Lấy tổng hợp công nợ tất cả khách hàng
        public List<CustomerDebtSummary> GetAllCustomerDebts()
        {
            List<CustomerDebtSummary> list = new List<CustomerDebtSummary>();

            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(
                    "sp_GetAllCustomerDebts",
                    null,
                    isStoredProc: true
                );

                foreach (DataRow row in data.Rows)
                {
                    list.Add(new CustomerDebtSummary(row));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách công nợ: {ex.Message}");
            }

            return list;
        }
        #endregion

        #region 2. Lấy chi tiết công nợ 1 khách hàng
        public CustomerDebtDetails GetCustomerDebtDetails(int customerID)
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(
                    "sp_GetCustomerDebtDetails",
                    new object[] { customerID },
                    isStoredProc: true
                );

                // DataSet chứa 3 bảng: Summary, Invoices, Payments
                if (data.Rows.Count > 0)
                {
                    return new CustomerDebtDetails
                    {
                        Summary = new CustomerDebtSummary(data.Rows[0]),
                        Invoices = new List<SalesInvoices>(),
                        Payments = new List<CustomerPayments>()
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy chi tiết công nợ: {ex.Message}");
            }
        }
        #endregion

        #region 3. Lấy lịch sử công nợ theo thời gian
        public List<DebtHistoryRecord> GetDebtHistoryByDateRange(
            DateTime startDate,
            DateTime endDate,
            int? customerID = null)
        {
            List<DebtHistoryRecord> list = new List<DebtHistoryRecord>();

            try
            {
                object[] parameters = customerID.HasValue
                    ? new object[] { startDate, endDate, customerID.Value }
                    : new object[] { startDate, endDate, DBNull.Value };

                DataTable data = DataProvider.Instance.ExecuteQuery(
                    "sp_GetDebtHistoryByDateRange",
                    parameters,
                    isStoredProc: true
                );

                foreach (DataRow row in data.Rows)
                {
                    list.Add(new DebtHistoryRecord(row));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy lịch sử công nợ: {ex.Message}");
            }

            return list;
        }
        #endregion

        #region 4. Lấy thống kê công nợ
        public DebtStatistics GetDebtStatistics()
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(
                    "sp_GetDebtStatistics",
                    null,
                    isStoredProc: true
                );

                if (data.Rows.Count > 0)
                {
                    return new DebtStatistics(data.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thống kê công nợ: {ex.Message}");
            }
        }
        #endregion

        #region 5. Xóa thanh toán (Admin)
        public int DeleteCustomerPayment(int paymentID)
        {
            try
            {
                var outputs = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    "sp_DeleteCustomerPayment",
                    inputParams: new Dictionary<string, object>
                    {
                        { "@PaymentID", paymentID }
                    },
                    outputParams: new Dictionary<string, System.Data.SqlDbType>
                    {
                        { "@Result", System.Data.SqlDbType.Int }
                    }
                );

                return outputs["@Result"] != DBNull.Value ? (int)outputs["@Result"] : -99;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa thanh toán: {ex.Message}");
            }
        }
        #endregion
    }

    #region DTO Classes chủ yếu hổx trợ hiện thị UI
    /// <summary>
    /// Tổng hợp công nợ khách hàng
    /// </summary>
    public class CustomerDebtSummary
    {
        public int CustomerID { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public decimal TongMuaHang { get; set; }
        public decimal TongDaTra { get; set; }
        public decimal CongNoHienTai { get; set; }

        public CustomerDebtSummary() { }

        public CustomerDebtSummary(DataRow row)
        {
            CustomerID = row["CustomerID"] != DBNull.Value ? (int)row["CustomerID"] : 0;
            TenKhachHang = row["TenKhachHang"]?.ToString() ?? "";
            SoDienThoai = row["SoDienThoai"]?.ToString() ?? "";
            DiaChi = row["DiaChi"]?.ToString() ?? "";
            TongMuaHang = row["TongMuaHang"] != DBNull.Value ? (decimal)row["TongMuaHang"] : 0;
            TongDaTra = row["TongDaTra"] != DBNull.Value ? (decimal)row["TongDaTra"] : 0;
            CongNoHienTai = row["CongNoHienTai"] != DBNull.Value ? (decimal)row["CongNoHienTai"] : 0;
        }
    }

    /// <summary>
    /// Chi tiết công nợ khách hàng
    /// </summary>
    public class CustomerDebtDetails
    {
        public CustomerDebtSummary Summary { get; set; }
        public List<SalesInvoices> Invoices { get; set; }
        public List<CustomerPayments> Payments { get; set; }
    }

    /// <summary>
    /// Bản ghi lịch sử công nợ
    /// </summary>
    public class DebtHistoryRecord
    {
        public int InvoiceID { get; set; }
        public string MaHoaDon { get; set; }
        public DateTime NgayBan { get; set; }
        public int CustomerID { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public decimal TongTien { get; set; }
        public decimal DaTra { get; set; }
        public decimal ConLai { get; set; }
        public string TrangThai { get; set; }

        public DebtHistoryRecord() { }

        public DebtHistoryRecord(DataRow row)
        {
            InvoiceID = row["InvoiceID"] != DBNull.Value ? (int)row["InvoiceID"] : 0;
            MaHoaDon = row["MaHoaDon"]?.ToString() ?? "";
            NgayBan = row["NgayBan"] != DBNull.Value ? (DateTime)row["NgayBan"] : DateTime.Now;
            CustomerID = row["CustomerID"] != DBNull.Value ? (int)row["CustomerID"] : 0;
            TenKhachHang = row["TenKhachHang"]?.ToString() ?? "";
            SoDienThoai = row["SoDienThoai"]?.ToString() ?? "";
            TongTien = row["TongTien"] != DBNull.Value ? (decimal)row["TongTien"] : 0;
            DaTra = row["DaTra"] != DBNull.Value ? (decimal)row["DaTra"] : 0;
            ConLai = row["ConLai"] != DBNull.Value ? (decimal)row["ConLai"] : 0;
            TrangThai = row["TrangThai"]?.ToString() ?? "";
        }
    }

    /// <summary>
    /// Thống kê công nợ
    /// </summary>
    public class DebtStatistics
    {
        public int SoKhachHangNo { get; set; }
        public int SoHoaDonNo { get; set; }
        public decimal TongGiaTriHoaDon { get; set; }
        public decimal TongDaTra { get; set; }
        public decimal TongCongNo { get; set; }

        public DebtStatistics() { }

        public DebtStatistics(DataRow row)
        {
            SoKhachHangNo = row["SoKhachHangNo"] != DBNull.Value ? (int)row["SoKhachHangNo"] : 0;
            SoHoaDonNo = row["SoHoaDonNo"] != DBNull.Value ? (int)row["SoHoaDonNo"] : 0;
            TongGiaTriHoaDon = row["TongGiaTriHoaDon"] != DBNull.Value ? (decimal)row["TongGiaTriHoaDon"] : 0;
            TongDaTra = row["TongDaTra"] != DBNull.Value ? (decimal)row["TongDaTra"] : 0;
            TongCongNo = row["TongCongNo"] != DBNull.Value ? (decimal)row["TongCongNo"] : 0;
        }
    }
    #endregion
}