using System;
using System.Data;

namespace DoubleTRice.DT
{
    /// <summary>
    /// DTO cho bảng SalesInvoiceDetails - Chi tiết hóa đơn bán hàng
    /// </summary>
    public class SalesInvoiceDetails
    {
        #region Properties
        public int InvoiceDetailID { get; set; }
        public int InvoiceID { get; set; }
        public int ProductID { get; set; }
        public int UnitID { get; set; }
        public double SoLuong { get; set; }
        public decimal DonGiaBan { get; set; }
        public decimal? ThanhTien { get; set; }

        // Extended properties (không có trong DB, dùng cho hiển thị)
        public string ProductName { get; set; }
        public string UnitName { get; set; }
        public double GiaTriQuyDoi { get; set; } // Để tính toán khi trừ kho
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor mặc định
        /// </summary>
        public SalesInvoiceDetails() { }

        /// <summary>
        /// Constructor từ DataRow
        /// </summary>
        public SalesInvoiceDetails(DataRow row)
        {
            InvoiceDetailID = row["InvoiceDetailID"] != DBNull.Value ? (int)row["InvoiceDetailID"] : 0;
            InvoiceID = row["InvoiceID"] != DBNull.Value ? (int)row["InvoiceID"] : 0;
            ProductID = row["ProductID"] != DBNull.Value ? (int)row["ProductID"] : 0;
            UnitID = row["UnitID"] != DBNull.Value ? (int)row["UnitID"] : 0;
            SoLuong = row["SoLuong"] != DBNull.Value ? Convert.ToDouble(row["SoLuong"]) : 0;
            DonGiaBan = row["DonGiaBan"] != DBNull.Value ? (decimal)row["DonGiaBan"] : 0;
            ThanhTien = row["ThanhTien"] != DBNull.Value ? (decimal?)row["ThanhTien"] : null;

            // Extended properties (nếu có trong query JOIN)
            if (row.Table.Columns.Contains("ProductName"))
                ProductName = row["ProductName"] != DBNull.Value ? row["ProductName"].ToString() : string.Empty;

            if (row.Table.Columns.Contains("UnitName"))
                UnitName = row["UnitName"] != DBNull.Value ? row["UnitName"].ToString() : string.Empty;

            if (row.Table.Columns.Contains("GiaTriQuyDoi"))
                GiaTriQuyDoi = row["GiaTriQuyDoi"] != DBNull.Value ? Convert.ToDouble(row["GiaTriQuyDoi"]) : 0;
        }

        /// <summary>
        /// Constructor đầy đủ tham số
        /// </summary>
        public SalesInvoiceDetails(int invoiceDetailID, int invoiceID, int productID,
            int unitID, double soLuong, decimal donGiaBan)
        {
            InvoiceDetailID = invoiceDetailID;
            InvoiceID = invoiceID;
            ProductID = productID;
            UnitID = unitID;
            SoLuong = soLuong;
            DonGiaBan = donGiaBan;
            ThanhTien = (decimal)soLuong * donGiaBan;
        }

        /// <summary>
        /// Constructor cho việc thêm vào giỏ hàng (chưa có ID)
        /// </summary>
        public SalesInvoiceDetails(int productID, int unitID, double soLuong, decimal donGiaBan,
            string productName = "", string unitName = "")
        {
            ProductID = productID;
            UnitID = unitID;
            SoLuong = soLuong;
            DonGiaBan = donGiaBan;
            ThanhTien = (decimal)soLuong * donGiaBan;
            ProductName = productName;
            UnitName = unitName;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Tính lại thành tiền
        /// </summary>
        public void CalculateThanhTien()
        {
            ThanhTien = (decimal)SoLuong * DonGiaBan;
        }

        public override string ToString()
        {
            return $"{ProductName ?? "N/A"} - {SoLuong} {UnitName ?? ""} x {DonGiaBan:N0}đ = {ThanhTien:N0}đ";
        }
        #endregion
    }
}