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
        // ✅ Giữ nguyên property này
        public static Users CurrentUser { get; set; }

        #region Properties - SỬ DỤNG CurrentUser thay vì lưu riêng lẻ

        public static int UserID => CurrentUser?.UserID ?? 0;

        public static string HoTen => CurrentUser?.HoTen;

        public static string TenDangNhap => CurrentUser?.TenDangNhap;

        public static string VaiTro => CurrentUser?.VaiTro;

        public static DateTime LoginTime { get; private set; }

        public static bool IsLoggedIn => CurrentUser != null && CurrentUser.UserID > 0;
        #endregion

        #region Methods
        /// <summary>
        /// Khởi tạo session khi đăng nhập thành công
        /// </summary>
        public static void Initialize(int userID, string hoTen, string tenDangNhap, string vaiTro)
        {
            // ✅ Set CurrentUser
            CurrentUser = new Users
            {
                UserID = userID,
                HoTen = hoTen,
                TenDangNhap = tenDangNhap,
                VaiTro = vaiTro
            };

            LoginTime = DateTime.Now;
        }

        /// <summary>
        /// Xóa session khi đăng xuất
        /// </summary>
        public static void Clear()
        {
            CurrentUser = null;
            LoginTime = DateTime.MinValue;
        }

        // ✅ Giữ nguyên các phương thức còn lại
        public static bool IsAdmin() => VaiTro?.ToUpper() == "ADMIN";

        public static bool IsThuNgan() => VaiTro?.ToUpper() == "THU NGÂN";

        public static bool IsThuKho() => VaiTro?.ToUpper() == "THỦ KHO";

        public static bool IsKeToan() => VaiTro?.ToUpper() == "KẾ TOÁN";

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

        public static string GetSessionInfo()
        {
            if (!IsLoggedIn)
                return "Chưa đăng nhập";

            return $"User: {HoTen} | Role: {VaiTro} | Login: {LoginTime:dd/MM/yyyy HH:mm}";
        }
        #endregion
    }
}
