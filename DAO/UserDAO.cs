using System;
using System.Collections.Generic;
using System.Data;

namespace DoubleTRice.DAO
{
    public class UserDAO
    {
        #region Singleton
        private static UserDAO instance;
        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserDAO();
                return instance;
            }
        }

        private UserDAO() { }
        #endregion

        #region Login Methods
        /// <summary>
        /// Đăng nhập
        /// </summary>
        public LoginResult Login(string username, string passwordHash)
        {
            try
            {
                string procName = "sp_Login";

                // INPUT parameters
                var inputParams = new Dictionary<string, object>
                {
                    { "@TenDangNhap", username },
                    { "@MatKhauHash", passwordHash }
                };

                // OUTPUT parameters với SqlDbType
                var outputParams = new Dictionary<string, SqlDbType>
                {
                    { "@Result", SqlDbType.Int },
                    { "@UserID", SqlDbType.Int },
                    { "@HoTen", SqlDbType.NVarChar },
                    { "@VaiTro", SqlDbType.NVarChar }
                };

                // Gọi stored procedure
                var result = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    procName, inputParams, outputParams);

                // Parse kết quả
                int resultCode = result["@Result"] != null ? Convert.ToInt32(result["@Result"]) : -99;

                return new LoginResult
                {
                    Success = resultCode == 0,
                    ResultCode = resultCode,
                    UserID = resultCode == 0 && result["@UserID"] != null ? Convert.ToInt32(result["@UserID"]) : 0,
                    HoTen = resultCode == 0 && result["@HoTen"] != null ? result["@HoTen"].ToString() : null,
                    VaiTro = resultCode == 0 && result["@VaiTro"] != null ? result["@VaiTro"].ToString() : null,
                    Message = GetLoginMessage(resultCode)
                };
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

        private string GetLoginMessage(int resultCode)
        {
            switch (resultCode)
            {
                case 0: return "Đăng nhập thành công";
                case -1: return "Tên đăng nhập không tồn tại";
                case -2: return "Mật khẩu không đúng";
                case -3: return "Tài khoản đã bị khóa. Vui lòng liên hệ quản trị viên";
                default: return "Lỗi không xác định";
            }
        }
        #endregion

        #region Change Password Methods
        /// <summary>
        /// Đổi mật khẩu
        /// </summary>
        public ChangePasswordResult ChangePassword(int userID, string oldPasswordHash, string newPasswordHash)
        {
            try
            {
                string procName = "sp_ChangePassword";

                // INPUT parameters
                var inputParams = new Dictionary<string, object>
                {
                    { "@UserID", userID },
                    { "@MatKhauCuHash", oldPasswordHash },
                    { "@MatKhauMoiHash", newPasswordHash }
                };

                // OUTPUT parameters
                var outputParams = new Dictionary<string, SqlDbType>
                {
                    { "@Result", SqlDbType.Int }
                };

                var result = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    procName, inputParams, outputParams);

                int resultCode = result["@Result"] != null ? Convert.ToInt32(result["@Result"]) : -99;

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

        private string GetChangePasswordMessage(int resultCode)
        {
            switch (resultCode)
            {
                case 0: return "Đổi mật khẩu thành công";
                case -1: return "Mật khẩu cũ không đúng";
                case -2: return "Mật khẩu mới không được trùng với mật khẩu cũ";
                case -3: return "Người dùng không tồn tại";
                default: return "Lỗi không xác định";
            }
        }
        #endregion

        #region Other Methods
        /// <summary>
        /// Kiểm tra username đã tồn tại chưa
        /// </summary>
        public bool CheckUsernameExists(string username)
        {
            try
            {
                string procName = "sp_CheckUsernameExists";

                var inputParams = new Dictionary<string, object>
                {
                    { "@TenDangNhap", username }
                };

                var outputParams = new Dictionary<string, SqlDbType>
                {
                    { "@Exists", SqlDbType.Bit }
                };

                var result = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    procName, inputParams, outputParams);

                return result["@Exists"] != null && Convert.ToBoolean(result["@Exists"]);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Mở khóa tài khoản (Admin only)
        /// </summary>
        public bool UnlockAccount(int userID)
        {
            try
            {
                string procName = "sp_UnlockAccount";

                var inputParams = new Dictionary<string, object>
                {
                    { "@UserID", userID }
                };

                var outputParams = new Dictionary<string, SqlDbType>
                {
                    { "@Result", SqlDbType.Int }
                };

                var result = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    procName, inputParams, outputParams);

                return result["@Result"] != null && Convert.ToInt32(result["@Result"]) == 0;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }

    #region Result Classes
    /// <summary>
    /// Kết quả đăng nhập
    /// </summary>
    public class LoginResult
    {
        public bool Success { get; set; }
        public int ResultCode { get; set; }
        public int UserID { get; set; }
        public string HoTen { get; set; }
        public string VaiTro { get; set; }
        public string Message { get; set; }
    }

    /// <summary>
    /// Kết quả đổi mật khẩu
    /// </summary>
    public class ChangePasswordResult
    {
        public bool Success { get; set; }
        public int ResultCode { get; set; }
        public string Message { get; set; }
    }
    #endregion
}