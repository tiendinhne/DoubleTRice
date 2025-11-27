using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleTRice.DT
{
    public class Users
    {
        public int UserID { get; set; }
        public string HoTen { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhauHash { get; set; }
        public string VaiTro { get; set; }

        // NEW PROPERTIES cho User Management 21-11 edit by tiendinh 
        public bool IsLocked { get; set; }
        public int FailedLoginAttempts { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? CreatedDate { get; set; }


        public Users() { }
        public Users(int userID, string hoTen, string tenDangNhap, string matKhauHash, string vaiTro)
        {
            UserID = userID;
            HoTen = hoTen;
            TenDangNhap = tenDangNhap;
            MatKhauHash = matKhauHash;
            VaiTro = vaiTro;
            IsLocked = false;
            FailedLoginAttempts = 0;
            LastLoginDate = null;
            CreatedDate = DateTime.Now;
        }

        public Users(DataRow row)
        {
            UserID = row["UserID"] != DBNull.Value ? Convert.ToInt32(row["UserID"]) : 0;
            HoTen = row["HoTen"] != DBNull.Value ? row["HoTen"].ToString() : null;
            TenDangNhap = row["TenDangNhap"] != DBNull.Value ? row["TenDangNhap"].ToString() : null;
            MatKhauHash = row["MatKhauHash"] != DBNull.Value ? row["MatKhauHash"].ToString() : null;
            VaiTro = row["VaiTro"] != DBNull.Value ? row["VaiTro"].ToString() : null;

            // NEW FIELDS
            IsLocked = row.Table.Columns.Contains("IsLocked") && row["IsLocked"] != DBNull.Value
                ? Convert.ToBoolean(row["IsLocked"])
                : false;

            FailedLoginAttempts = row.Table.Columns.Contains("FailedLoginAttempts") && row["FailedLoginAttempts"] != DBNull.Value
                ? Convert.ToInt32(row["FailedLoginAttempts"])
                : 0;

            LastLoginDate = row.Table.Columns.Contains("LastLoginDate") && row["LastLoginDate"] != DBNull.Value
                ? Convert.ToDateTime(row["LastLoginDate"])
                : (DateTime?)null;

            CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value
                ? Convert.ToDateTime(row["CreatedDate"])
                : (DateTime?)null;
        }

    }

}
