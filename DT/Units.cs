using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoubleTRice.DT
{

    public class Units
    {
        public int UnitID { get; set; }
        public string TenDVT { get; set; }

        public Units() { }

        public Units(int unitID, string tenDVT)
        {
            UnitID = unitID;
            TenDVT = tenDVT;
        }

        public Units(DataRow row)
        {
            UnitID = row["UnitID"] != DBNull.Value ? Convert.ToInt32(row["UnitID"]) : 0;
            TenDVT = row["TenDVT"] != DBNull.Value ? row["TenDVT"].ToString() : null;
        }
    }

}
