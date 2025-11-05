using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoubleTRice.DT
{
    public class ProductInventory
    {
        public int ProductID { get; set; }
        public double SoLuongTon { get; set; }

        public ProductInventory() { }

        public ProductInventory(int productID, double soLuongTon)
        {
            ProductID = productID;
            SoLuongTon = soLuongTon;
        }

        public ProductInventory(DataRow row)
        {
            ProductID = row["ProductID"] != DBNull.Value ? Convert.ToInt32(row["ProductID"]) : 0;
            SoLuongTon = row["SoLuongTon"] != DBNull.Value ? Convert.ToDouble(row["SoLuongTon"]) : 0.0;
        }
    }

}
