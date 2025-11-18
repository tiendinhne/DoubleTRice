using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleTRice.DT
{
    public class SupplierPayments
    {
        public int PaymentID { get; set; }
        public int SupplierID { get; set; }
        public int? ReceiptID { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        public decimal SoTien { get; set; }
        public string PhuongThuc { get; set; }

        public SupplierPayments() { }

        public SupplierPayments(int paymentID, int supplierID, int? receiptID, DateTime? ngayThanhToan, decimal soTien, string phuongThuc = null)
        {
            PaymentID = paymentID;
            SupplierID = supplierID;
            ReceiptID = receiptID;
            NgayThanhToan = ngayThanhToan;
            SoTien = soTien;
            PhuongThuc = phuongThuc;
        }

        public SupplierPayments(DataRow row)
        {
            PaymentID = row["PaymentID"] != DBNull.Value ? Convert.ToInt32(row["PaymentID"]) : 0;
            SupplierID = row["SupplierID"] != DBNull.Value ? Convert.ToInt32(row["SupplierID"]) : 0;
            ReceiptID = row.Table.Columns.Contains("ReceiptID") && row["ReceiptID"] != DBNull.Value ? Convert.ToInt32(row["ReceiptID"]) : (int?)null;
            NgayThanhToan = row.Table.Columns.Contains("NgayThanhToan") && row["NgayThanhToan"] != DBNull.Value ? Convert.ToDateTime(row["NgayThanhToan"]) : (DateTime?)null;
            SoTien = row["SoTien"] != DBNull.Value ? Convert.ToDecimal(row["SoTien"]) : 0m;
            PhuongThuc = row.Table.Columns.Contains("PhuongThuc") && row["PhuongThuc"] != DBNull.Value ? row["PhuongThuc"].ToString() : null;
        }
    }
}
