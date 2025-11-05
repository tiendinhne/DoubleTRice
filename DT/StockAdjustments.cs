using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoubleTRice.DTO
{
    public class StockAdjustments
    {
        public int AdjustmentID { get; set; }
        public string MaPhieu { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public DateTime? NgayDieuChinh { get; set; }
        public double SoLuongDieuChinh { get; set; }
        public string LyDo { get; set; }

        public StockAdjustments() { }

        public StockAdjustments(int adjustmentID, string maPhieu, int productID, int userID, DateTime? ngayDieuChinh, double soLuongDieuChinh, string lyDo = null)
        {
            AdjustmentID = adjustmentID;
            MaPhieu = maPhieu;
            ProductID = productID;
            UserID = userID;
            NgayDieuChinh = ngayDieuChinh;
            SoLuongDieuChinh = soLuongDieuChinh;
            LyDo = lyDo;
        }

        public StockAdjustments(DataRow row)
        {
            AdjustmentID = row["AdjustmentID"] != DBNull.Value ? Convert.ToInt32(row["AdjustmentID"]) : 0;
            MaPhieu = row.Table.Columns.Contains("MaPhieu") && row["MaPhieu"] != DBNull.Value ? row["MaPhieu"].ToString() : null;
            ProductID = row["ProductID"] != DBNull.Value ? Convert.ToInt32(row["ProductID"]) : 0;
            UserID = row["UserID"] != DBNull.Value ? Convert.ToInt32(row["UserID"]) : 0;
            NgayDieuChinh = row.Table.Columns.Contains("NgayDieuChinh") && row["NgayDieuChinh"] != DBNull.Value ? Convert.ToDateTime(row["NgayDieuChinh"]) : (DateTime?)null;
            SoLuongDieuChinh = row["SoLuongDieuChinh"] != DBNull.Value ? Convert.ToDouble(row["SoLuongDieuChinh"]) : 0.0;
            LyDo = row.Table.Columns.Contains("LyDo") && row["LyDo"] != DBNull.Value ? row["LyDo"].ToString() : null;
        }
    }
}
