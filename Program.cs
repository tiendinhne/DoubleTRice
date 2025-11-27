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
                // --- BẮT ĐẦU LOGIC CẤU HÌNH KẾT NỐI DATABASE ---
                string finalConnectionString = null;
                bool isConnected = false;

                // 1. Tải cấu hình đã lưu và thử kết nối
                // Ta dùng ConnectionSettingsForm để tận dụng LoadSavedSettings và GetConnectionString.
                using (ConnectionSettingsForm configLoader = new ConnectionSettingsForm())
                {
                    string savedConnStr = configLoader.GetConnectionString();

                    if (!string.IsNullOrEmpty(savedConnStr))
                    {
                        // Set tạm chuỗi kết nối để kiểm tra
                        DataProvider.ConnectionString = savedConnStr;
                        if (DataProvider.Instance.TestConnection())
                        {
                            finalConnectionString = savedConnStr;
                            isConnected = true;
                        }
                    }
                }
                // 2. Nếu chưa kết nối thành công, hiển thị Form Cấu hình để người dùng nhập/chỉnh sửa
                if (!isConnected)
                {
                    // Tạo một instance mới để hiển thị dialog (nếu chưa kết nối lần đầu)
                    using (ConnectionSettingsForm configForm = new ConnectionSettingsForm())
                    {
                        DialogResult result = configForm.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            // Nếu người dùng kết nối thành công, lấy chuỗi kết nối mới
                            finalConnectionString = configForm.GetConnectionString();
                            isConnected = true;
                        }
                        else
                        {
                            // Nếu người dùng Cancel/Đóng Form mà chưa kết nối thành công, thoát ứng dụng
                            MessageBox.Show("Ứng dụng không thể kết nối đến CSDL. Chương trình sẽ thoát.",
                                "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }

                // 3. Set chuỗi kết nối cuối cùng cho DataProvider và chạy LoginUI
                if (isConnected)
                {
                    DataProvider.ConnectionString = finalConnectionString;
                }
                else
                {
                    // Should not happen if previous logic is correct
                    return;
                }

                // --- KẾT THÚC LOGIC CẤU HÌNH KẾT NỐI DATABASE ---

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
