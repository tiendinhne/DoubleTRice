using System;
using System.Collections.Generic;
using System.Data;
using DoubleTRice.DT;

namespace DoubleTRice.DAO
{
    /// <summary>
    /// Data Access Object cho Users
    /// </summary>
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
        /// Đăng nhập - Trả về Users object và ResultCode
        /// </summary>
        /// <returns>
        /// Tuple: (Users object, ResultCode)
        /// ResultCode: 0 = Success, -1 = User not found, -2 = Wrong password, -3 = Locked
        /// </returns>
        public (Users user, int resultCode) Login(string username, string passwordHash)
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

                // OUTPUT parameters
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

                // Nếu thành công, tạo Users object
                if (resultCode == 0)
                {
                    var user = new Users
                    {
                        UserID = result["@UserID"] != null ? Convert.ToInt32(result["@UserID"]) : 0,
                        HoTen = result["@HoTen"]?.ToString(),
                        TenDangNhap = username,
                        VaiTro = result["@VaiTro"]?.ToString()
                    };
                    return (user, resultCode);
                }

                return (null, resultCode);
            }
            catch (Exception)
            {
                return (null, -99); // System error
            }
        }
        #endregion

        #region Change Password Methods
        /// <summary>
        /// Đổi mật khẩu
        /// </summary>
        /// <returns>
        /// ResultCode: 0 = Success, -1 = Wrong old password, -2 = Same password, -3 = User not found
        /// </returns>
        public int ChangePassword(int userID, string oldPasswordHash, string newPasswordHash)
        {
            try
            {
                string procName = "sp_ChangePassword";

                var inputParams = new Dictionary<string, object>
                {
                    { "@UserID", userID },
                    { "@MatKhauCuHash", oldPasswordHash },
                    { "@MatKhauMoiHash", newPasswordHash }
                };

                var outputParams = new Dictionary<string, SqlDbType>
                {
                    { "@Result", SqlDbType.Int }
                };

                var result = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    procName, inputParams, outputParams);

                return result["@Result"] != null ? Convert.ToInt32(result["@Result"]) : -99;
            }
            catch (Exception)
            {
                return -99; // System error
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
        public int UnlockAccount(int userID)
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

                return result["@Result"] != null ? Convert.ToInt32(result["@Result"]) : -99;
            }
            catch
            {
                return -99;
            }
        }

        /// <summary>
        /// Lấy thông tin user theo ID
        /// </summary>
        public Users GetUserByID(int userID)
        {
            try
            {
                string query = "SELECT * FROM Users WHERE UserID = @UserID";
                var parameters = new object[] { userID };

                DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

                if (data.Rows.Count > 0)
                {
                    return new Users(data.Rows[0]);
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách tất cả users
        /// </summary>
        public List<Users> GetAllUsers()
        {
            try
            {
                string query = "SELECT * FROM Users";
                DataTable data = DataProvider.Instance.ExecuteQuery(query);

                List<Users> users = new List<Users>();
                foreach (DataRow row in data.Rows)
                {
                    users.Add(new Users(row));
                }

                return users;
            }
            catch
            {
                return new List<Users>();
            }
        }
        #endregion
    }
}