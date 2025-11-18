using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace DoubleTRice.DT
{
    public class SalesInvoiceDetails
    {
        public int InvoiceDetailID { get; set; }
        public int InvoiceID { get; set; }
        public int ProductID { get; set; }
        public int UnitID { get; set; }
        public double SoLuong { get; set; }
        public decimal DonGiaBan { get; set; }
        public decimal? ThanhTien { get; set; }

        public SalesInvoiceDetails() { }

        public SalesInvoiceDetails(int invoiceDetailID, int invoiceID, int productID, int unitID, double soLuong, decimal donGiaBan, decimal? thanhTien = null)
        {
            InvoiceDetailID = invoiceDetailID;
            InvoiceID = invoiceID;
            ProductID = productID;
            UnitID = unitID;
            SoLuong = soLuong;
            DonGiaBan = donGiaBan;
            ThanhTien = thanhTien;
        }

        public SalesInvoiceDetails(DataRow row)
        {
            InvoiceDetailID = row["InvoiceDetailID"] != DBNull.Value ? Convert.ToInt32(row["InvoiceDetailID"]) : 0;
            InvoiceID = row["InvoiceID"] != DBNull.Value ? Convert.ToInt32(row["InvoiceID"]) : 0;
            ProductID = row["ProductID"] != DBNull.Value ? Convert.ToInt32(row["ProductID"]) : 0;
            UnitID = row["UnitID"] != DBNull.Value ? Convert.ToInt32(row["UnitID"]) : 0;
            SoLuong = row["SoLuong"] != DBNull.Value ? Convert.ToDouble(row["SoLuong"]) : 0.0;
            DonGiaBan = row["DonGiaBan"] != DBNull.Value ? Convert.ToDecimal(row["DonGiaBan"]) : 0m;
            ThanhTien = row.Table.Columns.Contains("ThanhTien") && row["ThanhTien"] != DBNull.Value ? Convert.ToDecimal(row["ThanhTien"]) : (decimal?)null;
        }
    }
}

