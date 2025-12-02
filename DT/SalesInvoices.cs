using System;
using System.Data;

namespace DoubleTRice.DT
{
    /// <summary>
    /// DTO cho bảng SalesInvoices - Hóa đơn bán hàng
    /// </summary>
    public class SalesInvoices
    {
        #region Properties
        public int InvoiceID { get; set; }
        public string MaHoaDon { get; set; }
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public DateTime? NgayBan { get; set; }
        public decimal? TongTien { get; set; }

        // Extended properties (không có trong DB, dùng cho hiển thị)
        public string CustomerName { get; set; }
        public string UserName { get; set; }
        public string TrangThaiThanhToan { get; set; } // "Đã thanh toán" / "Ghi nợ"
        public decimal? SoTienDaTra { get; set; }
        public decimal? ConLai { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor mặc định
        /// </summary>
        public SalesInvoices() { }

        /// <summary>
        /// Constructor từ DataRow
        /// </summary>
        public SalesInvoices(DataRow row)
        {
            InvoiceID = row["InvoiceID"] != DBNull.Value ? (int)row["InvoiceID"] : 0;
            MaHoaDon = row["MaHoaDon"] != DBNull.Value ? row["MaHoaDon"].ToString() : string.Empty;
            CustomerID = row["CustomerID"] != DBNull.Value ? (int)row["CustomerID"] : 0;
            UserID = row["UserID"] != DBNull.Value ? (int)row["UserID"] : 0;
            NgayBan = row["NgayBan"] != DBNull.Value ? (DateTime?)row["NgayBan"] : null;
            TongTien = row["TongTien"] != DBNull.Value ? (decimal?)row["TongTien"] : null;

            // Extended properties (nếu có trong query JOIN)
            if (row.Table.Columns.Contains("CustomerName"))
                CustomerName = row["CustomerName"] != DBNull.Value ? row["CustomerName"].ToString() : string.Empty;

            if (row.Table.Columns.Contains("UserName"))
                UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : string.Empty;

            if (row.Table.Columns.Contains("TrangThaiThanhToan"))
                TrangThaiThanhToan = row["TrangThaiThanhToan"] != DBNull.Value ? row["TrangThaiThanhToan"].ToString() : string.Empty;

            if (row.Table.Columns.Contains("SoTienDaTra"))
                SoTienDaTra = row["SoTienDaTra"] != DBNull.Value ? (decimal?)row["SoTienDaTra"] : null;

            if (row.Table.Columns.Contains("ConLai"))
                ConLai = row["ConLai"] != DBNull.Value ? (decimal?)row["ConLai"] : null;
        }

        /// <summary>
        /// Constructor đầy đủ tham số
        /// </summary>
        public SalesInvoices(int invoiceID, string maHoaDon, int customerID, int userID,
            DateTime? ngayBan, decimal? tongTien)
        {
            InvoiceID = invoiceID;
            MaHoaDon = maHoaDon;
            CustomerID = customerID;
            UserID = userID;
            NgayBan = ngayBan;
            TongTien = tongTien;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"HD: {MaHoaDon} - Khách: {CustomerName ?? "N/A"} - Tổng: {TongTien:N0}đ";
        }
        #endregion
    }
}