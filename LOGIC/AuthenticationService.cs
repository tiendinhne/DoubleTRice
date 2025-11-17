using System;
using DoubleTRice.DAO;
using DoubleTRice.DT;

namespace DoubleTRice.LOGIC
{
    /// <summary>
    /// Service xử lý logic đăng nhập, đổi mật khẩu
    /// </summary>
    public static class AuthenticationService
    {
        #region Login
        /// <summary>
        /// Đăng nhập với validation và error handling
        /// </summary>
        public static LoginResult Login(string username, string password)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(username))
            {
                return new LoginResult
                {
                    Success = false,
                    ResultCode = -100,
                    Message = "Tên đăng nhập không được để trống"
                };
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return new LoginResult
                {
                    Success = false,
                    ResultCode = -101,
                    Message = "Mật khẩu không được để trống"
                };
            }

            try
            {
                // Hash password
                string passwordHash = PasswordHelper.HashPassword(password);

                // Gọi DAO
                var (user, resultCode) = UserDAO.Instance.Login(username, passwordHash);

                // Parse kết quả
                if (resultCode == 0 && user != null)
                {
                    return new LoginResult
                    {
                        Success = true,
                        ResultCode = 0,
                        UserID = user.UserID,
                        HoTen = user.HoTen,
                        VaiTro = user.VaiTro,
                        Message = "Đăng nhập thành công"
                    };
                }
                else
                {
                    return new LoginResult
                    {
                        Success = false,
                        ResultCode = resultCode,
                        Message = GetLoginErrorMessage(resultCode)
                    };
                }
            }
            catch (Exception ex)
            {
                return new LoginResult
                {
                    Success = false,
                    ResultCode = -99,
                    Message = $"Lỗi hệ thống: {ex.Message}"
                };
            }
        }

        private static string GetLoginErrorMessage(int resultCode)
        {
            switch (resultCode)
            {
                case -1: return "Tên đăng nhập không tồn tại";
                case -2: return "Mật khẩu không đúng";
                case -3: return "Tài khoản đã bị khóa. Vui lòng liên hệ quản trị viên";
                case -99: return "Lỗi hệ thống";
                default: return "Lỗi không xác định";
            }
        }
        #endregion

        #region Change Password
        /// <summary>
        /// Đổi mật khẩu với validation
        /// </summary>
        public static ChangePasswordResult ChangePassword(int userID, string oldPassword, string newPassword)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(oldPassword))
            {
                return new ChangePasswordResult
                {
                    Success = false,
                    ResultCode = -100,
                    Message = "Vui lòng nhập mật khẩu cũ"
                };
            }

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                return new ChangePasswordResult
                {
                    Success = false,
                    ResultCode = -101,
                    Message = "Vui lòng nhập mật khẩu mới"
                };
            }

            // Validate password rules
            if (!PasswordHelper.ValidatePassword(newPassword, out string validationError))
            {
                return new ChangePasswordResult
                {
                    Success = false,
                    ResultCode = -102,
                    Message = validationError
                };
            }

            // Check new != old
            if (oldPassword == newPassword)
            {
                return new ChangePasswordResult
                {
                    Success = false,
                    ResultCode = -2,
                    Message = "Mật khẩu mới không được trùng với mật khẩu cũ"
                };
            }

            try
            {
                // Hash passwords
                string oldPasswordHash = PasswordHelper.HashPassword(oldPassword);
                string newPasswordHash = PasswordHelper.HashPassword(newPassword);

                // Gọi DAO
                int resultCode = UserDAO.Instance.ChangePassword(userID, oldPasswordHash, newPasswordHash);

                return new ChangePasswordResult
                {
                    Success = resultCode == 0,
                    ResultCode = resultCode,
                    Message = GetChangePasswordMessage(resultCode)
                };
            }
            catch (Exception ex)
            {
                return new ChangePasswordResult
                {
                    Success = false,
                    ResultCode = -99,
                    Message = $"Lỗi hệ thống: {ex.Message}"
                };
            }
        }

        private static string GetChangePasswordMessage(int resultCode)
        {
            switch (resultCode)
            {
                case 0: return "Đổi mật khẩu thành công";
                case -1: return "Mật khẩu cũ không đúng";
                case -2: return "Mật khẩu mới không được trùng với mật khẩu cũ";
                case -3: return "Người dùng không tồn tại";
                case -99: return "Lỗi hệ thống";
                default: return "Lỗi không xác định";
            }
        }
        #endregion

        #region Unlock Account
        /// <summary>
        /// Mở khóa tài khoản (Admin only)
        /// </summary>
        public static UnlockAccountResult UnlockAccount(int userID)
        {
            try
            {
                int resultCode = UserDAO.Instance.UnlockAccount(userID);

                return new UnlockAccountResult
                {
                    Success = resultCode == 0,
                    ResultCode = resultCode,
                    Message = resultCode == 0 ? "Mở khóa tài khoản thành công" : "Mở khóa tài khoản thất bại"
                };
            }
            catch (Exception ex)
            {
                return new UnlockAccountResult
                {
                    Success = false,
                    ResultCode = -99,
                    Message = $"Lỗi hệ thống: {ex.Message}"
                };
            }
        }
        #endregion
        
    }
}