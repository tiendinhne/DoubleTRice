using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoubleTRice.DTO
{
    public class GoodsReceipts
    {
        public int ReceiptID { get; set; }
        public string MaPhieuNhap { get; set; }
        public int SupplierID { get; set; }
        public int UserID { get; set; }
        public DateTime? NgayNhap { get; set; }
        public decimal? TongTien { get; set; }
        public string GhiChu { get; set; }

        public GoodsReceipts() { }

        public GoodsReceipts(int receiptID, string maPhieuNhap, int supplierID, int userID, DateTime? ngayNhap, decimal? tongTien = null, string ghiChu = null)
        {
            this.ReceiptID = receiptID;
            this.MaPhieuNhap = maPhieuNhap;
            this.SupplierID = supplierID;
            this.UserID = userID;
            this.NgayNhap = ngayNhap;
            this.TongTien = tongTien;
            this.GhiChu = ghiChu;
        }

        public GoodsReceipts(DataRow row)
        {
            ReceiptID = row["ReceiptID"] != DBNull.Value ? Convert.ToInt32(row["ReceiptID"]) : 0;
            MaPhieuNhap = row.Table.Columns.Contains("MaPhieuNhap") && row["MaPhieuNhap"] != DBNull.Value ? row["MaPhieuNhap"].ToString() : null;
            SupplierID = row["SupplierID"] != DBNull.Value ? Convert.ToInt32(row["SupplierID"]) : 0;
            UserID = row["UserID"] != DBNull.Value ? Convert.ToInt32(row["UserID"]) : 0;
            NgayNhap = row.Table.Columns.Contains("NgayNhap") && row["NgayNhap"] != DBNull.Value ? Convert.ToDateTime(row["NgayNhap"]) : (DateTime?)null;
            TongTien = row.Table.Columns.Contains("TongTien") && row["TongTien"] != DBNull.Value ? Convert.ToDecimal(row["TongTien"]) : (decimal?)null;
            GhiChu = row.Table.Columns.Contains("GhiChu") && row["GhiChu"] != DBNull.Value ? row["GhiChu"].ToString() : null;
        }
    }
}

