using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleTRice.DT
{
    public class CustomerPayments
    {
        public int PaymentID { get; set; }
        public int CustomerID { get; set; }
        public int? InvoiceID { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        public decimal SoTien { get; set; }
        public string PhuongThuc { get; set; }

        public CustomerPayments() { }

        public CustomerPayments(int paymentID, int customerID, int? invoiceID, DateTime? ngayThanhToan, decimal soTien, string phuongThuc = null)
        {
            PaymentID = paymentID;
            CustomerID = customerID;
            InvoiceID = invoiceID;
            NgayThanhToan = ngayThanhToan;
            SoTien = soTien;
            PhuongThuc = phuongThuc;
        }

        public CustomerPayments(DataRow row)
        {
            PaymentID = row["PaymentID"] != DBNull.Value ? Convert.ToInt32(row["PaymentID"]) : 0;
            CustomerID = row["CustomerID"] != DBNull.Value ? Convert.ToInt32(row["CustomerID"]) : 0;
            InvoiceID = row.Table.Columns.Contains("InvoiceID") && row["InvoiceID"] != DBNull.Value ? Convert.ToInt32(row["InvoiceID"]) : (int?)null;
            NgayThanhToan = row.Table.Columns.Contains("NgayThanhToan") && row["NgayThanhToan"] != DBNull.Value ? Convert.ToDateTime(row["NgayThanhToan"]) : (DateTime?)null;
            SoTien = row["SoTien"] != DBNull.Value ? Convert.ToDecimal(row["SoTien"]) : 0m;
            PhuongThuc = row.Table.Columns.Contains("PhuongThuc") && row["PhuongThuc"] != DBNull.Value ? row["PhuongThuc"].ToString() : null;
        }
    }
}


