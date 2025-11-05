using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoubleTRice.DAO;

namespace DoubleTRice
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LoginUI());
            // 🔍 Test kết nối SQL trước khi mở form
            if (DataProvider.Instance.TestConnection())
            {
                MessageBox.Show("✅ Kết nối cơ sở dữ liệu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("❌ Không thể kết nối đến SQL Server!\n" +
                    "Vui lòng kiểm tra lại connection string.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // dừng chương trình nếu chưa kết nối được
            }
            //Application.Run(new MainUI());
        }
    }
}
