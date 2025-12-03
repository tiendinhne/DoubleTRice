using DoubleTRice.DAO;
using DoubleTRice.DT;
using DoubleTRice.LOGIC;
using DoubleTRice.UI.ChildForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoubleTRice.UI
{
    public partial class TrangChuUI : Form
    {
        public TrangChuUI()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                // ============================
                // ⭐ TEST 1: Lấy hóa đơn theo ngày
                // ============================
                var invoices = SalesInvoiceDAO.Instance.GetSalesInvoicesByDateRange(
                    new DateTime(2025, 12, 1),
                    DateTime.Now
                );

                MessageBox.Show($"[TEST 1]\nCó {invoices.Count} hóa đơn từ 1/12/2025 → hôm nay");



                // ============================
                // ⭐ TEST 2: Kiểm tra tồn kho
                // ============================
                double tonKho;
                bool duHang = SalesInvoiceDAO.Instance.CheckStockAvailability(
                    productID: 30,
                    unitID: 2,
                    soLuong: 2,
                    out tonKho
                );

                MessageBox.Show($"[TEST 2]\nĐủ hàng: {duHang}\nTồn kho hiện tại: {tonKho} kg");



                // ============================
                // ⭐ TEST 3: Tạo hóa đơn mới
                // ============================
                var details = new List<SalesInvoiceDetails>
        {
            new SalesInvoiceDetails
            {
                ProductID = 1,
                UnitID = 1,
                SoLuong = 2,
                DonGiaBan = 25000
            }
        };

                int newID;
                int result = SalesInvoiceDAO.Instance.InsertSalesInvoice(
                    customerID: 1,
                    userID: UserSession.UserID,
                    tongTien: 50000, // tổng tiền phải trùng với details
                    details: details,
                    newInvoiceID: out newID
                );

                MessageBox.Show($"[TEST 3]\nKết quả: {result}\nID hóa đơn mới: {newID}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Test DAO: " + ex.Message);
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
