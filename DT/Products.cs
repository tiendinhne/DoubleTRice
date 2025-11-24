 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoubleTRice.DT
{

    public class Products
    {
        public int ProductID { get; set; }
        public string TenSanPham { get; set; }
        public int BaseUnitID { get; set; }
        public string BaseUnitName { get; set; }
        public double? TonKhoToiThieu { get; set; }
        public double SoLuongTon { get; set; }
        public string TrangThaiTonKho { get; set; }

        public Products() { }

        public Products(int productID, string tenSanPham, int baseUnitID, string baseUnitName,
            double tonKhoToiThieu, double soLuongTon, string trangThaiTonKho)
        {
            ProductID = productID;
            TenSanPham = tenSanPham;
            BaseUnitID = baseUnitID;
            BaseUnitName = baseUnitName;
            TonKhoToiThieu = tonKhoToiThieu;
            SoLuongTon = soLuongTon;
            TrangThaiTonKho = trangThaiTonKho;
        }

        public Products(DataRow row)
        {
            ProductID = row["ProductID"] != DBNull.Value ? Convert.ToInt32(row["ProductID"]) : 0;
            TenSanPham = row["TenSanPham"] != DBNull.Value ? row["TenSanPham"].ToString() : null;
            BaseUnitID = row["BaseUnitID"] != DBNull.Value ? Convert.ToInt32(row["BaseUnitID"]) : 0;
            BaseUnitName = row.Table.Columns.Contains("BaseUnitName") && row["BaseUnitName"] != DBNull.Value
                ? row["BaseUnitName"].ToString()
                : null;
            TonKhoToiThieu = row.Table.Columns.Contains("TonKhoToiThieu") && row["TonKhoToiThieu"] != DBNull.Value
                ? Convert.ToDouble(row["TonKhoToiThieu"])
                : 0.0;
            SoLuongTon = row.Table.Columns.Contains("SoLuongTon") && row["SoLuongTon"] != DBNull.Value
                ? Convert.ToDouble(row["SoLuongTon"])
                : 0.0;
            TrangThaiTonKho = row.Table.Columns.Contains("TrangThaiTonKho") && row["TrangThaiTonKho"] != DBNull.Value
                ? row["TrangThaiTonKho"].ToString()
                : "Không xác định";
        }
    }

}
