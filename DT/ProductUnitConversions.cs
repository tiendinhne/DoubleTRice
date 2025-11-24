using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DoubleTRice.DT
{
    public class ProductUnitConversions
    {
        public int ConversionID { get; set; }
        public int ProductID { get; set; }
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public double GiaTriQuyDoi { get; set; }

        public ProductUnitConversions() { }

        public ProductUnitConversions(int conversionID, int productID, int unitID,
           string unitName, double giaTriQuyDoi)
        {
            ConversionID = conversionID;
            ProductID = productID;
            UnitID = unitID;
            UnitName = unitName;
            GiaTriQuyDoi = giaTriQuyDoi;
        }

        public ProductUnitConversions(DataRow row)
        {
            ConversionID = row["ConversionID"] != DBNull.Value ? Convert.ToInt32(row["ConversionID"]) : 0;
            ProductID = row["ProductID"] != DBNull.Value ? Convert.ToInt32(row["ProductID"]) : 0;
            UnitID = row["UnitID"] != DBNull.Value ? Convert.ToInt32(row["UnitID"]) : 0;
            UnitName = row.Table.Columns.Contains("UnitName") && row["UnitName"] != DBNull.Value
                ? row["UnitName"].ToString()
                : null;
            GiaTriQuyDoi = row["GiaTriQuyDoi"] != DBNull.Value ? Convert.ToDouble(row["GiaTriQuyDoi"]) : 0.0;
        }
    }
}
