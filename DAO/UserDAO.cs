using DoubleTRice.DT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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

                // 🔍 THÊM DEBUG Ở ĐÂY:
                System.Diagnostics.Debug.WriteLine("=== UserDAO.Login() START ===");
                System.Diagnostics.Debug.WriteLine($"Calling: {procName}");
                System.Diagnostics.Debug.WriteLine($"@TenDangNhap: {username}");
                System.Diagnostics.Debug.WriteLine($"@MatKhauHash: {passwordHash}");

                // Gọi stored procedure
                var result = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    procName, inputParams, outputParams);
                // 🔍 THÊM DEBUG RESULT:
                System.Diagnostics.Debug.WriteLine("=== OUTPUT PARAMETERS ===");
                foreach (var kvp in result)
                {
                    System.Diagnostics.Debug.WriteLine($"{kvp.Key} = {kvp.Value ?? "NULL"}");
                }

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
            catch (Exception ex)
            {
// 🔍 THÊM DEBUG EXCEPTION:
                System.Diagnostics.Debug.WriteLine("=== UserDAO.Login() EXCEPTION ===");
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return (null, -99);
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
        //public List<Users> GetAllUsers()
        //{
        //    try
        //    {
        //        string query = "SELECT * FROM Users";
        //        DataTable data = DataProvider.Instance.ExecuteQuery(query);

        //        List<Users> users = new List<Users>();
        //        foreach (DataRow row in data.Rows)
        //        {
        //            users.Add(new Users(row));
        //        }

        //        return users;
        //    }
        //    catch
        //    {
        //        return new List<Users>();
        //    }
        //}
        #endregion


        #region Admin User Management Methods

        /// <summary>
        /// Lấy tất cả users (Admin only) - với thông tin đầy đủ
        /// </summary>
        public List<Users> GetAllUsersAdmin()
        {
            try
            {
                string procName = "sp_GetAllUsersAdmin";

                // BƯỚC 1: Kiểm tra SP có tồn tại không
                System.Diagnostics.Debug.WriteLine("=== BẮT ĐẦU GỌI GetAllUsersAdmin() ===");
                System.Diagnostics.Debug.WriteLine($"Stored Procedure: {procName}");

                // Gọi thử query kiểm tra SP có tồn tại không (rất quan trọng!)
                string checkSP = "SELECT COUNT(*) FROM sys.procedures WHERE name = 'sp_GetAllUsersAdmin'";
                var spExists = DataProvider.Instance.ExecuteScalar(checkSP);
                System.Diagnostics.Debug.WriteLine($"SP có tồn tại không? -> {spExists} (1 = có, 0 = không)");

                if (Convert.ToInt32(spExists) == 0)
                {
                    MessageBox.Show("LỖI: Stored Procedure 'sp_GetAllUsersAdmin' KHÔNG TỒN TẠI trong CSDL!",
                                  "Lỗi SP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<Users>();
                }

                // BƯỚC 2: Gọi thực thi SP
                System.Diagnostics.Debug.WriteLine("Đang gọi ExecuteQuery...");
                DataTable data = DataProvider.Instance.ExecuteQuery(procName, null, true);

                // BƯỚC 3: Kiểm tra kết quả trả về
                System.Diagnostics.Debug.WriteLine($"DataTable.Rows.Count = {data?.Rows.Count ?? -1}");
                System.Diagnostics.Debug.WriteLine($"DataTable.Columns.Count = {data?.Columns.Count ?? 0}");

                if (data == null || data.Rows.Count == 0)
                {
                    MessageBox.Show("SP chạy thành công nhưng KHÔNG TRẢ VỀ DỮ LIỆU nào!\n" +
                                  "Kiểm tra: Có user nào trong bảng Users chưa?\n" +
                                  "Hoặc SP có bị lỗi logic SELECT không?",
                                  "Không có dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // In ra cấu trúc bảng để kiểm tra
                    System.Diagnostics.Debug.WriteLine("Cấu trúc bảng trả về:");
                    if (data != null)
                        foreach (DataColumn col in data.Columns)
                            System.Diagnostics.Debug.WriteLine($"  Column: {col.ColumnName} - {col.DataType}");

                    return new List<Users>();
                }

                // BƯỚC 4: Duyệt và convert
                List<Users> users = new List<Users>();
                int index = 1;
                foreach (DataRow row in data.Rows)
                {
                    try
                    {
                        var user = new Users(row);
                        users.Add(user);

                        System.Diagnostics.Debug.WriteLine($"[OK] User {index}: {user.HoTen} - {user.TenDangNhap} - {user.VaiTro}");
                        index++;
                    }
                    catch (Exception rowEx)
                    {
                        System.Diagnostics.Debug.WriteLine($"[LỖI] Dòng {index} bị lỗi khi convert: {rowEx.Message}");
                    }
                }

                System.Diagnostics.Debug.WriteLine($"=== HOÀN TẤT: Trả về {users.Count} user(s) ===");
                return users;
            }
            catch (Exception ex)
            {
                // BƯỚC 5: Bắt lỗi chi tiết
                string errorMsg = $"GetAllUsersAdmin() LỖI TOÀN DIỆN:\n{ex.Message}\n\nStackTrace:\n{ex.StackTrace}";
                System.Diagnostics.Debug.WriteLine(errorMsg);
                MessageBox.Show("Lỗi nghiêm trọng khi lấy danh sách user admin:\n" + ex.Message,
                               "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new List<Users>();
            }
        }
        /// <summary>
        /// Thêm user mới (Admin only)
        /// </summary>
        public (int result, int newUserID) InsertUser(string hoTen, string tenDangNhap, string passwordHash, string vaiTro)
        {
            try
            {
                string procName = "sp_InsertUser";

                var inputParams = new Dictionary<string, object>
        {
            { "@HoTen", hoTen },
            { "@TenDangNhap", tenDangNhap },
            { "@MatKhauHash", passwordHash },
            { "@VaiTro", vaiTro }
        };

                var outputParams = new Dictionary<string, SqlDbType>
        {
            { "@Result", SqlDbType.Int },
            { "@NewUserID", SqlDbType.Int }
        };

                var result = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    procName, inputParams, outputParams);

                int resultCode = result["@Result"] != null ? Convert.ToInt32(result["@Result"]) : -99;
                int newUserID = result["@NewUserID"] != null ? Convert.ToInt32(result["@NewUserID"]) : 0;

                return (resultCode, newUserID);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"InsertUser error: {ex.Message}");
                return (-99, 0);
            }
        }

        /// <summary>
        /// Cập nhật thông tin user (Admin only)
        /// </summary>
        public int UpdateUser(int userID, string hoTen, string tenDangNhap, string vaiTro)
        {
            try
            {
                string procName = "sp_UpdateUser";

                var inputParams = new Dictionary<string, object>
        {
            { "@UserID", userID },
            { "@HoTen", hoTen },
            { "@TenDangNhap", tenDangNhap },
            { "@VaiTro", vaiTro }
        };

                var outputParams = new Dictionary<string, SqlDbType>
        {
            { "@Result", SqlDbType.Int }
        };

                var result = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    procName, inputParams, outputParams);

                return result["@Result"] != null ? Convert.ToInt32(result["@Result"]) : -99;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"UpdateUser error: {ex.Message}");
                return -99;
            }
        }

        /// <summary>
        /// Xóa user (Admin only)
        /// </summary>
        public int DeleteUser(int userID)
        {
            try
            {
                string procName = "sp_DeleteUser";

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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DeleteUser error: {ex.Message}");
                return -99;
            }
        }

        /// <summary>
        /// Reset password user (Admin only)
        /// </summary>
        public int ResetPasswordAdmin(int userID, string newPasswordHash)
        {
            try
            {
                string procName = "sp_ResetPasswordAdmin";

                var inputParams = new Dictionary<string, object>
        {
            { "@UserID", userID },
            { "@NewPasswordHash", newPasswordHash }
        };

                var outputParams = new Dictionary<string, SqlDbType>
        {
            { "@Result", SqlDbType.Int }
        };

                var result = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    procName, inputParams, outputParams);

                return result["@Result"] != null ? Convert.ToInt32(result["@Result"]) : -99;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ResetPasswordAdmin error: {ex.Message}");
                return -99;
            }
        }

        /// <summary>
        /// Toggle Lock/Unlock user (Admin only)
        /// </summary>
        public int ToggleLockUser(int userID, bool isLocked)
        {
            try
            {
                string procName = "sp_ToggleLockUser";

                var inputParams = new Dictionary<string, object>
        {
            { "@UserID", userID },
            { "@IsLocked", isLocked }
        };

                var outputParams = new Dictionary<string, SqlDbType>
        {
            { "@Result", SqlDbType.Int }
        };

                var result = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    procName, inputParams, outputParams);

                return result["@Result"] != null ? Convert.ToInt32(result["@Result"]) : -99;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ToggleLockUser error: {ex.Message}");
                return -99;
            }
        }

        #endregion
    }
}