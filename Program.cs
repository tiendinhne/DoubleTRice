//using DoubleTRice.DAO;
//using DoubleTRice.UI;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace DoubleTRice
//{
//    internal static class Program
//    {
//        /// <summary>
//        /// The main entry point for the application.
//        /// </summary>
//        [STAThread]
//        static void Main()
//        {
//            Application.EnableVisualStyles();
//            Application.SetCompatibleTextRenderingDefault(false);
//            //Application.ThreadException += (s, e) =>
//            //{
//            //    File.AppendAllText("error.log", $"Error: {e.Exception.Message}\nStack Trace: {e.Exception.StackTrace}\n");
//            //    MessageBox.Show("An error occurred. Check error.log for details.");
//            //};
//            // Test connection
//            if (!DataProvider.Instance.TestConnection())
//            {
//                MessageBox.Show("Không kết nối được database!\nVui lòng kiểm tra connection string",
//                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }
//            Application.Run(new LoginUI());
//            //Application.Run(new MainUI());
//        }
//    }
//}

using DoubleTRice.DAO;
using DoubleTRice.UI;
using System;
using System.IO;
using System.Windows.Forms;

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
            // Enable visual styles
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ✅ XỬ LÝ EXCEPTION TOÀN CỤC
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            try
            {
                // ✅ TEST CONNECTION TRƯỚC KHI CHẠY
                if (!DataProvider.Instance.TestConnection())
                {
                    MessageBox.Show(
                        "❌ Không thể kết nối đến database!\n\n" +
                        "Vui lòng kiểm tra:\n" +
                        "1. SQL Server đang chạy\n" +
                        "2. Database 'QuanLyBanGao' đã được tạo\n" +
                        "3. Connection string trong DataProvider.cs",
                        "Lỗi kết nối Database",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                // ✅ CHẠY ỨNG DỤNG
                Application.Run(new LoginUI());
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show(
                    $"Lỗi khởi động ứng dụng:\n{ex.Message}\n\nChi tiết đã được ghi vào error.log",
                    "Lỗi nghiêm trọng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        /// <summary>
        /// Xử lý exception từ UI thread
        /// </summary>
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            LogError(e.Exception);
            MessageBox.Show(
                $"Lỗi ứng dụng:\n{e.Exception.Message}\n\nChi tiết đã được ghi vào error.log",
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        /// <summary>
        /// Xử lý exception từ non-UI thread
        /// </summary>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            LogError(ex);
            MessageBox.Show(
                $"Lỗi hệ thống nghiêm trọng:\n{ex?.Message}\n\nỨng dụng sẽ đóng.",
                "Lỗi nghiêm trọng",
                MessageBoxButtons.OK,
                MessageBoxIcon.Stop
            );
        }

        /// <summary>
        /// Ghi log lỗi ra file
        /// </summary>
        private static void LogError(Exception ex)
        {
            try
            {
                string logPath = Path.Combine(Application.StartupPath, "error.log");
                string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR\n" +
                                  $"Message: {ex?.Message}\n" +
                                  $"Source: {ex?.Source}\n" +
                                  $"StackTrace:\n{ex?.StackTrace}\n" +
                                  $"{"".PadRight(80, '=')}\n";

                File.AppendAllText(logPath, logEntry);
            }
            catch
            {
                // Nếu không ghi được log, bỏ qua
            }
        }
    }
}
