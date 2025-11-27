using DoubleTRice.DT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleTRice.LOGIC
{
    /// <summary>
    /// Static class lưu thông tin người dùng hiện tại
    /// </summary>
    public static class UserSession
    {
        #region Properties
        /// <summary>
        /// ID người dùng
        /// </summary>
        public static int UserID { get; private set; }

        /// <summary>
        /// Họ tên người dùng
        /// </summary>
        public static string HoTen { get; private set; }

        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        public static string TenDangNhap { get; private set; }

        /// <summary>
        /// Vai trò (Admin, Thu Ngân, Thủ Kho, Kế Toán)
        /// </summary>
        public static string VaiTro { get; private set; }

        /// <summary>
        /// Thời gian đăng nhập
        /// </summary>
        public static DateTime LoginTime { get; private set; }

        /// <summary>
        /// Kiểm tra đã đăng nhập chưa
        /// </summary>
        public static bool IsLoggedIn => UserID > 0;
        #endregion

        #region Methods
        /// <summary>
        /// Khởi tạo session khi đăng nhập thành công
        /// </summary>
        public static void Initialize(int userID, string hoTen, string tenDangNhap, string vaiTro)
        {
            UserID = userID;
            HoTen = hoTen;
            TenDangNhap = tenDangNhap;
            VaiTro = vaiTro;
            LoginTime = DateTime.Now;
        }

        /// <summary>
        /// Xóa session khi đăng xuất
        /// </summary>
        public static void Clear()
        {
            UserID = 0;
            HoTen = null;
            TenDangNhap = null;
            VaiTro = null;
            LoginTime = DateTime.MinValue;
        }

        /// <summary>
        /// Kiểm tra quyền Admin
        /// </summary>
        public static bool IsAdmin()
        {
            return VaiTro?.ToUpper() == "ADMIN";
        }

        /// <summary>
        /// Kiểm tra quyền Thu Ngân
        /// </summary>
        public static bool IsThuNgan()
        {
            return VaiTro?.ToUpper() == "THU NGÂN";
        }

        /// <summary>
        /// Kiểm tra quyền Thủ Kho
        /// </summary>
        public static bool IsThuKho()
        {
            return VaiTro?.ToUpper() == "THỦ KHO";
        }

        /// <summary>
        /// Kiểm tra quyền Kế Toán
        /// </summary>
        public static bool IsKeToan()
        {
            return VaiTro?.ToUpper() == "KẾ TOÁN";
        }

        /// <summary>
        /// Kiểm tra có quyền truy cập chức năng không
        /// </summary>
        public static bool HasPermission(params string[] allowedRoles)
        {
            if (allowedRoles == null || allowedRoles.Length == 0)
                return true;

            foreach (var role in allowedRoles)
            {
                if (VaiTro?.Equals(role, StringComparison.OrdinalIgnoreCase) == true)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Lấy thông tin session dưới dạng string
        /// </summary>
        public static string GetSessionInfo()
        {
            if (!IsLoggedIn)
                return "Chưa đăng nhập";

            return $"User: {HoTen} | Role: {VaiTro} | Login: {LoginTime:dd/MM/yyyy HH:mm}";
        }
        #endregion

        //class SessionManager để lưu thông tin user đang đăng nhập:
        public static class SessionManager
        {
            public static Users CurrentUser { get; set; }
        }
    }
}
