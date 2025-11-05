using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoubleTRice.DT
{

    public class Customers
    {
        public int CustomerID { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }

        public Customers() { }

        public Customers(int customerID, string tenKhachHang, string soDienThoai = null, string diaChi = null)
        {
            CustomerID = customerID;
            TenKhachHang = tenKhachHang;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
        }

        public Customers(DataRow row)
        {
            CustomerID = row["CustomerID"] != DBNull.Value ? Convert.ToInt32(row["CustomerID"]) : 0;
            TenKhachHang = row["TenKhachHang"] != DBNull.Value ? row["TenKhachHang"].ToString() : null;
            SoDienThoai = row.Table.Columns.Contains("SoDienThoai") && row["SoDienThoai"] != DBNull.Value ? row["SoDienThoai"].ToString() : null;
            DiaChi = row.Table.Columns.Contains("DiaChi") && row["DiaChi"] != DBNull.Value ? row["DiaChi"].ToString() : null;
        }
    }

}
