using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoubleTRice.DT
{
    public class GoodsReceiptDetails
    {
        public int ReceiptDetailID { get; set; }
        public int ReceiptID { get; set; }
        public int ProductID { get; set; }
        public int UnitID { get; set; }
        public double SoLuong { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal? ThanhTien { get; set; }

        public GoodsReceiptDetails() { }

        public GoodsReceiptDetails(int receiptDetailID, int receiptID, int productID, int unitID, double soLuong, decimal donGiaNhap, decimal? thanhTien = null)
        {
            ReceiptDetailID = receiptDetailID;
            ReceiptID = receiptID;
            ProductID = productID;
            UnitID = unitID;
            SoLuong = soLuong;
            DonGiaNhap = donGiaNhap;
            ThanhTien = thanhTien;
        }

        public GoodsReceiptDetails(DataRow row)
        {
            ReceiptDetailID = row["ReceiptDetailID"] != DBNull.Value ? Convert.ToInt32(row["ReceiptDetailID"]) : 0;
            ReceiptID = row["ReceiptID"] != DBNull.Value ? Convert.ToInt32(row["ReceiptID"]) : 0;
            ProductID = row["ProductID"] != DBNull.Value ? Convert.ToInt32(row["ProductID"]) : 0;
            UnitID = row["UnitID"] != DBNull.Value ? Convert.ToInt32(row["UnitID"]) : 0;
            SoLuong = row["SoLuong"] != DBNull.Value ? Convert.ToDouble(row["SoLuong"]) : 0.0;
            DonGiaNhap = row["DonGiaNhap"] != DBNull.Value ? Convert.ToDecimal(row["DonGiaNhap"]) : 0m;
            ThanhTien = row.Table.Columns.Contains("ThanhTien") && row["ThanhTien"] != DBNull.Value ? Convert.ToDecimal(row["ThanhTien"]) : (decimal?)null;
        }
    }
}

