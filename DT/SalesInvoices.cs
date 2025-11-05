using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoubleTRice.DTO
{
    public class SalesInvoices
    {
        public int InvoiceID { get; set; }
        public string MaHoaDon { get; set; }
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public DateTime? NgayBan { get; set; }
        public decimal? TongTien { get; set; }
        public string TrangThai { get; set; }

        public SalesInvoices() { }

        public SalesInvoices(int invoiceID, string maHoaDon, int customerID, int userID, DateTime? ngayBan, decimal? tongTien = null, string trangThai = null)
        {
            InvoiceID = invoiceID;
            MaHoaDon = maHoaDon;
            CustomerID = customerID;
            UserID = userID;
            NgayBan = ngayBan;
            TongTien = tongTien;
            TrangThai = trangThai;
        }

        public SalesInvoices(DataRow row)
        {
            InvoiceID = row["InvoiceID"] != DBNull.Value ? Convert.ToInt32(row["InvoiceID"]) : 0;
            MaHoaDon = row.Table.Columns.Contains("MaHoaDon") && row["MaHoaDon"] != DBNull.Value ? row["MaHoaDon"].ToString() : null;
            CustomerID = row["CustomerID"] != DBNull.Value ? Convert.ToInt32(row["CustomerID"]) : 0;
            UserID = row["UserID"] != DBNull.Value ? Convert.ToInt32(row["UserID"]) : 0;
            NgayBan = row.Table.Columns.Contains("NgayBan") && row["NgayBan"] != DBNull.Value ? Convert.ToDateTime(row["NgayBan"]) : (DateTime?)null;
            TongTien = row.Table.Columns.Contains("TongTien") && row["TongTien"] != DBNull.Value ? Convert.ToDecimal(row["TongTien"]) : (decimal?)null;
            TrangThai = row.Table.Columns.Contains("TrangThai") && row["TrangThai"] != DBNull.Value ? row["TrangThai"].ToString() : null;
        }
    }
}

