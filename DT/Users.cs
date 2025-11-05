using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleTRice.DT
{
    //internal class Users
    //{

    //}
    public class Users
    {
        public int UserID { get; set; }
        public string HoTen { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhauHash { get; set; }
        public string VaiTro { get; set; }

        public Users() { }
        public Users(int userID, string hoTen, string tenDangNhap, string matKhauHash, string vaiTro)
        {
            UserID = userID;
            HoTen = hoTen;
            TenDangNhap = tenDangNhap;
            MatKhauHash = matKhauHash;
            VaiTro = vaiTro;
        }
        public Users(DataRow row)
        {
            UserID = row["UserID"] != DBNull.Value ? Convert.ToInt32(row["UserID"]) : 0;
            HoTen = row["HoTen"] != DBNull.Value ? row["HoTen"].ToString() : null;
            TenDangNhap = row["TenDangNhap"] != DBNull.Value ? row["TenDangNhap"].ToString() : null;
            MatKhauHash = row["MatKhauHash"] != DBNull.Value ? row["MatKhauHash"].ToString() : null;
            VaiTro = row["VaiTro"] != DBNull.Value ? row["VaiTro"].ToString() : null;
        }

    }

}
