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
        public double? TonKhoToiThieu { get; set; }

        public Products() { }

        public Products(int productID, string tenSanPham, int baseUnitID, double? tonKhoToiThieu = null)
        {
            ProductID = productID;
            TenSanPham = tenSanPham;
            BaseUnitID = baseUnitID;
            TonKhoToiThieu = tonKhoToiThieu;
        }

        public Products(DataRow row)
        {
            ProductID = row["ProductID"] != DBNull.Value ? Convert.ToInt32(row["ProductID"]) : 0;
            TenSanPham = row["TenSanPham"] != DBNull.Value ? row["TenSanPham"].ToString() : null;
            BaseUnitID = row["BaseUnitID"] != DBNull.Value ? Convert.ToInt32(row["BaseUnitID"]) : 0;
            TonKhoToiThieu = row.Table.Columns.Contains("TonKhoToiThieu") && row["TonKhoToiThieu"] != DBNull.Value ? Convert.ToDouble(row["TonKhoToiThieu"]) : (double?)null;
        }
    }

}
