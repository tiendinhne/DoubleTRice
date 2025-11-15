using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DoubleTRice.LOGIC
{
    /// <summary>
    /// Helper class để xử lý mã hóa mật khẩu
    /// </summary>
    public static class PasswordHelper
    {
        /// <summary>
        /// Hash password sử dụng SHA256
        /// </summary>
        /// <param name="password">Mật khẩu gốc</param>
        /// <returns>Password đã hash (hex string)</returns>
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                // Convert password sang bytes
                byte[] bytes = Encoding.UTF8.GetBytes(password);

                // Hash
                byte[] hash = sha256.ComputeHash(bytes);

                // Convert sang hex string
                StringBuilder result = new StringBuilder();
                foreach (byte b in hash)
                {
                    result.Append(b.ToString("x2"));
                }

                return result.ToString();
            }
        }

        /// <summary>
        /// Verify password với hash đã lưu
        /// </summary>
        /// <param name="password">Password cần kiểm tra</param>
        /// <param name="hashedPassword">Hash đã lưu trong DB</param>
        /// <returns>True nếu khớp</returns>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword))
                return false;

            string hashOfInput = HashPassword(password);
            return string.Equals(hashOfInput, hashedPassword, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Validate password theo quy tắc
        /// </summary>
        /// <param name="password">Password cần validate</param>
        /// <param name="errorMessage">Thông báo lỗi nếu không hợp lệ</param>
        /// <returns>True nếu hợp lệ</returns>
        public static bool ValidatePassword(string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrEmpty(password))
            {
                errorMessage = "Mật khẩu không được để trống";
                return false;
            }

            if (password.Length < 6)
            {
                errorMessage = "Mật khẩu phải có ít nhất 6 ký tự";
                return false;
            }

            if (password.Length > 50)
            {
                errorMessage = "Mật khẩu không được quá 50 ký tự";
                return false;
            }

            // Có thể thêm các quy tắc khác như:
            // - Phải có ít nhất 1 chữ hoa
            // - Phải có ít nhất 1 số
            // - Phải có ít nhất 1 ký tự đặc biệt
            // Uncomment nếu cần:

            // if (!password.Any(char.IsUpper))
            // {
            //     errorMessage = "Mật khẩu phải có ít nhất 1 chữ hoa";
            //     return false;
            // }

            // if (!password.Any(char.IsDigit))
            // {
            //     errorMessage = "Mật khẩu phải có ít nhất 1 số";
            //     return false;
            // }

            return true;
        }

        /// <summary>
        /// Generate random password
        /// </summary>
        /// <param name="length">Độ dài password (default: 8)</param>
        /// <returns>Random password</returns>
        public static string GenerateRandomPassword(int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var password = new char[length];

            for (int i = 0; i < length; i++)
            {
                password[i] = chars[random.Next(chars.Length)];
            }

            return new string(password);
        }
    }
}