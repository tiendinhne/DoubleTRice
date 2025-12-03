using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DoubleTRice.DAO
{
    /// <summary>
    /// Data Access Object cho Quản lý Công Nợ Nhà Cung Cấp
    /// </summary>
    public class SupplierDebtDAO
    {
        #region Singleton
        private static SupplierDebtDAO instance;
        public static SupplierDebtDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new SupplierDebtDAO();
                return instance;
            }
        }

        private SupplierDebtDAO() { }
        #endregion

        #region 1. Lấy tổng hợp công nợ tất cả NCC
        public List<SupplierDebtSummary> GetAllSupplierDebts()
        {
            List<SupplierDebtSummary> list = new List<SupplierDebtSummary>();

            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(
                    "sp_GetAllSupplierDebts",
                    null,
                    isStoredProc: true
                );

                foreach (DataRow row in data.Rows)
                {
                    list.Add(new SupplierDebtSummary(row));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách công nợ NCC: {ex.Message}");
            }

            return list;
        }
        #endregion

        #region 2. Lấy chi tiết công nợ 1 NCC
        public SupplierDebtDetails GetSupplierDebtDetails(int supplierID)
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(
                    "sp_GetSupplierDebtDetails",
                    new object[] { supplierID },
                    isStoredProc: true
                );

                if (data.Rows.Count > 0)
                {
                    return new SupplierDebtDetails
                    {
                        Summary = new SupplierDebtSummary(data.Rows[0]),
                        UnpaidReceipts = new List<GoodsReceiptDebt>(),
                        PaymentHistory = new List<SupplierPaymentRecord>()
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy chi tiết công nợ NCC: {ex.Message}");
            }
        }
        #endregion

        #region 3. Lấy lịch sử công nợ theo thời gian
        public List<SupplierDebtHistoryRecord> GetDebtHistoryByDateRange(
            DateTime startDate,
            DateTime endDate,
            int? supplierID = null)
        {
            List<SupplierDebtHistoryRecord> list = new List<SupplierDebtHistoryRecord>();

            try
            {
                object[] parameters = supplierID.HasValue
                    ? new object[] { startDate, endDate, supplierID.Value }
                    : new object[] { startDate, endDate, DBNull.Value };

                DataTable data = DataProvider.Instance.ExecuteQuery(
                    "sp_GetSupplierDebtHistory",
                    parameters,
                    isStoredProc: true
                );

                foreach (DataRow row in data.Rows)
                {
                    list.Add(new SupplierDebtHistoryRecord(row));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy lịch sử công nợ NCC: {ex.Message}");
            }

            return list;
        }
        #endregion

        #region 4. Lấy thống kê công nợ NCC
        public SupplierDebtStatistics GetDebtStatistics()
        {
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(
                    "sp_GetSupplierDebtStatistics",
                    null,
                    isStoredProc: true
                );

                if (data.Rows.Count > 0)
                {
                    return new SupplierDebtStatistics(data.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thống kê công nợ NCC: {ex.Message}");
            }
        }
        #endregion

        #region 5. Trả nợ NCC
        public int InsertSupplierPayment(
            int supplierID,
            int receiptID,
            decimal soTien,
            string phuongThuc)
        {
            try
            {
                var outputs = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    "sp_InsertSupplierPayment",
                    inputParams: new Dictionary<string, object>
                    {
                        { "@SupplierID", supplierID },
                        { "@ReceiptID", receiptID },
                        { "@SoTien", soTien },
                        { "@PhuongThuc", phuongThuc }
                    },
                    outputParams: new Dictionary<string, SqlDbType>
                    {
                        { "@Result", SqlDbType.Int }
                    }
                );

                return outputs["@Result"] != DBNull.Value ? (int)outputs["@Result"] : -99;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi trả nợ NCC: {ex.Message}");
            }
        }
        #endregion

        #region 6. Xóa thanh toán (Admin)
        public int DeleteSupplierPayment(int paymentID)
        {
            try
            {
                var outputs = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    "sp_DeleteSupplierPayment",
                    inputParams: new Dictionary<string, object>
                    {
                        { "@PaymentID", paymentID }
                    },
                    outputParams: new Dictionary<string, SqlDbType>
                    {
                        { "@Result", SqlDbType.Int }
                    }
                );

                return outputs["@Result"] != DBNull.Value ? (int)outputs["@Result"] : -99;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa thanh toán NCC: {ex.Message}");
            }
        }
        #endregion
    }

    #region DTO Classes cho Supplier Debt
    /// <summary>
    /// Tổng hợp công nợ nhà cung cấp
    /// </summary>
    public class SupplierDebtSummary
    {
        public int SupplierID { get; set; }
        public string TenNhaCungCap { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public decimal TongNhapHang { get; set; }
        public decimal TongDaTra { get; set; }
        public decimal CongNoHienTai { get; set; }

        public SupplierDebtSummary() { }

        public SupplierDebtSummary(DataRow row)
        {
            SupplierID = row["SupplierID"] != DBNull.Value ? (int)row["SupplierID"] : 0;
            TenNhaCungCap = row["TenNhaCungCap"]?.ToString() ?? "";
            SoDienThoai = row["SoDienThoai"]?.ToString() ?? "";
            DiaChi = row["DiaChi"]?.ToString() ?? "";
            TongNhapHang = row["TongNhapHang"] != DBNull.Value ? (decimal)row["TongNhapHang"] : 0;
            TongDaTra = row["TongDaTra"] != DBNull.Value ? (decimal)row["TongDaTra"] : 0;
            CongNoHienTai = row["CongNoHienTai"] != DBNull.Value ? (decimal)row["CongNoHienTai"] : 0;
        }
    }

    /// <summary>
    /// Chi tiết công nợ NCC
    /// </summary>
    public class SupplierDebtDetails
    {
        public SupplierDebtSummary Summary { get; set; }
        public List<GoodsReceiptDebt> UnpaidReceipts { get; set; }
        public List<SupplierPaymentRecord> PaymentHistory { get; set; }
    }

    /// <summary>
    /// Phiếu nhập chưa trả đủ
    /// </summary>
    public class GoodsReceiptDebt
    {
        public int ReceiptID { get; set; }
        public string MaPhieuNhap { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal TongTien { get; set; }
        public decimal DaTra { get; set; }
        public decimal ConLai { get; set; }

        public GoodsReceiptDebt() { }

        public GoodsReceiptDebt(DataRow row)
        {
            ReceiptID = row["ReceiptID"] != DBNull.Value ? (int)row["ReceiptID"] : 0;
            MaPhieuNhap = row["MaPhieuNhap"]?.ToString() ?? "";
            NgayNhap = row["NgayNhap"] != DBNull.Value ? (DateTime)row["NgayNhap"] : DateTime.Now;
            TongTien = row["TongTien"] != DBNull.Value ? (decimal)row["TongTien"] : 0;
            DaTra = row["DaTra"] != DBNull.Value ? (decimal)row["DaTra"] : 0;
            ConLai = row["ConLai"] != DBNull.Value ? (decimal)row["ConLai"] : 0;
        }
    }

    /// <summary>
    /// Bản ghi thanh toán NCC
    /// </summary>
    public class SupplierPaymentRecord
    {
        public int PaymentID { get; set; }
        public string MaPhieuNhap { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public decimal SoTien { get; set; }
        public string PhuongThuc { get; set; }

        public SupplierPaymentRecord() { }

        public SupplierPaymentRecord(DataRow row)
        {
            PaymentID = row["PaymentID"] != DBNull.Value ? (int)row["PaymentID"] : 0;
            MaPhieuNhap = row["MaPhieuNhap"]?.ToString() ?? "";
            NgayThanhToan = row["NgayThanhToan"] != DBNull.Value ? (DateTime)row["NgayThanhToan"] : DateTime.Now;
            SoTien = row["SoTien"] != DBNull.Value ? (decimal)row["SoTien"] : 0;
            PhuongThuc = row["PhuongThuc"]?.ToString() ?? "";
        }
    }

    /// <summary>
    /// Bản ghi lịch sử công nợ NCC
    /// </summary>
    public class SupplierDebtHistoryRecord
    {
        public int ReceiptID { get; set; }
        public string MaPhieuNhap { get; set; }
        public DateTime NgayNhap { get; set; }
        public int SupplierID { get; set; }
        public string TenNhaCungCap { get; set; }
        public string SoDienThoai { get; set; }
        public decimal TongTien { get; set; }
        public decimal DaTra { get; set; }
        public decimal ConLai { get; set; }
        public string TrangThai { get; set; }

        public SupplierDebtHistoryRecord() { }

        public SupplierDebtHistoryRecord(DataRow row)
        {
            ReceiptID = row["ReceiptID"] != DBNull.Value ? (int)row["ReceiptID"] : 0;
            MaPhieuNhap = row["MaPhieuNhap"]?.ToString() ?? "";
            NgayNhap = row["NgayNhap"] != DBNull.Value ? (DateTime)row["NgayNhap"] : DateTime.Now;
            SupplierID = row["SupplierID"] != DBNull.Value ? (int)row["SupplierID"] : 0;
            TenNhaCungCap = row["TenNhaCungCap"]?.ToString() ?? "";
            SoDienThoai = row["SoDienThoai"]?.ToString() ?? "";
            TongTien = row["TongTien"] != DBNull.Value ? (decimal)row["TongTien"] : 0;
            DaTra = row["DaTra"] != DBNull.Value ? (decimal)row["DaTra"] : 0;
            ConLai = row["ConLai"] != DBNull.Value ? (decimal)row["ConLai"] : 0;
            TrangThai = row["TrangThai"]?.ToString() ?? "";
        }
    }

    /// <summary>
    /// Thống kê công nợ NCC
    /// </summary>
    public class SupplierDebtStatistics
    {
        public int SoNhaCungCapNo { get; set; }
        public int SoPhieuNhapNo { get; set; }
        public decimal TongGiaTriNhapHang { get; set; }
        public decimal TongDaTra { get; set; }
        public decimal TongCongNo { get; set; }

        public SupplierDebtStatistics() { }

        public SupplierDebtStatistics(DataRow row)
        {
            SoNhaCungCapNo = row["SoNhaCungCapNo"] != DBNull.Value ? (int)row["SoNhaCungCapNo"] : 0;
            SoPhieuNhapNo = row["SoPhieuNhapNo"] != DBNull.Value ? (int)row["SoPhieuNhapNo"] : 0;
            TongGiaTriNhapHang = row["TongGiaTriNhapHang"] != DBNull.Value ? (decimal)row["TongGiaTriNhapHang"] : 0;
            TongDaTra = row["TongDaTra"] != DBNull.Value ? (decimal)row["TongDaTra"] : 0;
            TongCongNo = row["TongCongNo"] != DBNull.Value ? (decimal)row["TongCongNo"] : 0;
        }
    }
    #endregion
}