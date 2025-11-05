using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoubleTRice.DTO
{
    public class PriceList
    {
        public int PriceID { get; set; }
        public int ProductID { get; set; }
        public int UnitID { get; set; }
        public decimal GiaBan { get; set; }
        public DateTime? NgayApDung { get; set; }

        public PriceList() { }

        public PriceList(int priceID, int productID, int unitID, decimal giaBan, DateTime? ngayApDung = null)
        {
            PriceID = priceID;
            ProductID = productID;
            UnitID = unitID;
            GiaBan = giaBan;
            NgayApDung = ngayApDung;
        }

        public PriceList(DataRow row)
        {
            PriceID = row["PriceID"] != DBNull.Value ? Convert.ToInt32(row["PriceID"]) : 0;
            ProductID = row["ProductID"] != DBNull.Value ? Convert.ToInt32(row["ProductID"]) : 0;
            UnitID = row["UnitID"] != DBNull.Value ? Convert.ToInt32(row["UnitID"]) : 0;
            GiaBan = row["GiaBan"] != DBNull.Value ? Convert.ToDecimal(row["GiaBan"]) : 0m;
            NgayApDung = row.Table.Columns.Contains("NgayApDung") && row["NgayApDung"] != DBNull.Value ? Convert.ToDateTime(row["NgayApDung"]) : (DateTime?)null;
        }
    }
}
