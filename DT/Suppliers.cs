using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoubleTRice.DT
{
    //internal class Suppliers
    //{
    //}
    public class Suppliers
    {
        public int SupplierID { get; set; }
        public string TenNhaCungCap { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }

        public Suppliers() { }

        public Suppliers(int supplierID, string tenNhaCungCap, string soDienThoai = null, string diaChi = null)
        {
            SupplierID = supplierID;
            TenNhaCungCap = tenNhaCungCap;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
        }

        public Suppliers(DataRow row)
        {
            SupplierID = row["SupplierID"] != DBNull.Value ? Convert.ToInt32(row["SupplierID"]) : 0;
            TenNhaCungCap = row["TenNhaCungCap"] != DBNull.Value ? row["TenNhaCungCap"].ToString() : null;
            SoDienThoai = row.Table.Columns.Contains("SoDienThoai") && row["SoDienThoai"] != DBNull.Value ? row["SoDienThoai"].ToString() : null;
            DiaChi = row.Table.Columns.Contains("DiaChi") && row["DiaChi"] != DBNull.Value ? row["DiaChi"].ToString() : null;
        }
    }

}
