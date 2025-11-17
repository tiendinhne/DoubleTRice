using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleTRice.DT
{
    public class Result
    {
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

        /// <summary>
        /// Kết quả unlock account
        /// </summary>
        public class UnlockAccountResult
        {
            public bool Success { get; set; }
            public int ResultCode { get; set; }
            public string Message { get; set; }
        }
    }
}
