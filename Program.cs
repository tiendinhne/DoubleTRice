using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoubleTRice.DAO;
using DoubleTRice.DT;
using DoubleTRice.UI;

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
            Application.ThreadException += (s, e) =>
            {
                File.AppendAllText("error.log", $"Error: {e.Exception.Message}\nStack Trace: {e.Exception.StackTrace}\n");
                MessageBox.Show("An error occurred. Check error.log for details.");
            };
            Application.Run(new MainUI());
        }
    }
}
