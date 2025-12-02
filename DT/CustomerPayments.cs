using System;
using System.Data;

namespace DoubleTRice.DT
{
    /// <summary>
    /// DTO cho bảng CustomerPayments - Lịch sử thanh toán khách hàng
    /// </summary>
    public class CustomerPayments
    {
        #region Properties
        public int PaymentID { get; set; }
        public int CustomerID { get; set; }
        public int InvoiceID { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        public decimal SoTien { get; set; }
        public string PhuongThuc { get; set; }

        // Extended properties (không có trong DB, dùng cho hiển thị)
        public string CustomerName { get; set; }
        public string MaHoaDon { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor mặc định
        /// </summary>
        public CustomerPayments() { }

        /// <summary>
        /// Constructor từ DataRow
        /// </summary>
        public CustomerPayments(DataRow row)
        {
            PaymentID = row["PaymentID"] != DBNull.Value ? (int)row["PaymentID"] : 0;
            CustomerID = row["CustomerID"] != DBNull.Value ? (int)row["CustomerID"] : 0;
            InvoiceID = row["InvoiceID"] != DBNull.Value ? (int)row["InvoiceID"] : 0;
            NgayThanhToan = row["NgayThanhToan"] != DBNull.Value ? (DateTime?)row["NgayThanhToan"] : null;
            SoTien = row["SoTien"] != DBNull.Value ? (decimal)row["SoTien"] : 0;
            PhuongThuc = row["PhuongThuc"] != DBNull.Value ? row["PhuongThuc"].ToString() : "Tiền mặt";

            // Extended properties (nếu có trong query JOIN)
            if (row.Table.Columns.Contains("CustomerName"))
                CustomerName = row["CustomerName"] != DBNull.Value ? row["CustomerName"].ToString() : string.Empty;

            if (row.Table.Columns.Contains("MaHoaDon"))
                MaHoaDon = row["MaHoaDon"] != DBNull.Value ? row["MaHoaDon"].ToString() : string.Empty;
        }

        /// <summary>
        /// Constructor đầy đủ tham số
        /// </summary>
        public CustomerPayments(int paymentID, int customerID, int invoiceID,
            DateTime? ngayThanhToan, decimal soTien, string phuongThuc)
        {
            PaymentID = paymentID;
            CustomerID = customerID;
            InvoiceID = invoiceID;
            NgayThanhToan = ngayThanhToan;
            SoTien = soTien;
            PhuongThuc = phuongThuc;
        }

        /// <summary>
        /// Constructor cho việc tạo payment mới (chưa có ID)
        /// </summary>
        public CustomerPayments(int customerID, int invoiceID, decimal soTien, string phuongThuc)
        {
            CustomerID = customerID;
            InvoiceID = invoiceID;
            SoTien = soTien;
            PhuongThuc = phuongThuc;
            NgayThanhToan = DateTime.Now;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Thanh toán: {SoTien:N0}đ - {PhuongThuc} - {NgayThanhToan:dd/MM/yyyy}";
        }
        #endregion
    }
}