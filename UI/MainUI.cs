using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DoubleTRice.UI
{
    public partial class MainUI : Form
    {
        #region Fields
        private Timer statusTimer;
        private bool isDarkMode = true; // Giả định ban đầu là nền tối
        #endregion

        #region Constructor
        public MainUI()
        {
            InitializeComponent();
            InitializeStatusTimer();
            //SetupButtonIcons(); // Thiết lập icon và text cho các nút
            LoadDashboard(); // Load trang chủ mặc định
        }
        #endregion

        #region Initialization
        private void InitializeStatusTimer()
        {
            statusTimer = new Timer { Interval = 1000 };
            statusTimer.Tick += (s, e) => lblStatusDate.Text = $"📅 {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
            statusTimer.Start();
        }

        //private void SetupButtonIcons()
        //{
        //    // Thiết lập icon từ resource (thay bằng tài nguyên thực tế của bạn)
        //    btnDashboard.Image = isDarkMode ? Properties.Resources.dashboard_icon_white : Properties.Resources.dashboard_icon_black;
        //    btnDashboard.Text = "Dashboard";
        //    btnProducts.Image = isDarkMode ? Properties.Resources.product_icon_white : Properties.Resources.product_icon_black;
        //    btnProducts.Text = "Sản phẩm";
        //    btnSuppliers.Image = isDarkMode ? Properties.Resources.supplier_icon_white : Properties.Resources.supplier_icon_black;
        //    btnSuppliers.Text = "Nhà cung cấp";
        //    btnCustomers.Image = isDarkMode ? Properties.Resources.customer_icon_white : Properties.Resources.customer_icon_black;
        //    btnCustomers.Text = "Khách hàng";
        //    btnGoodsReceipt.Image = isDarkMode ? Properties.Resources.receipt_icon_white : Properties.Resources.receipt_icon_black;
        //    btnGoodsReceipt.Text = "Nhập hàng";
        //    btnSalesInvoice.Image = isDarkMode ? Properties.Resources.invoice_icon_white : Properties.Resources.invoice_icon_black;
        //    btnSalesInvoice.Text = "Bán hàng";
        //    btnInventory.Image = isDarkMode ? Properties.Resources.inventory_icon_white : Properties.Resources.inventory_icon_black;
        //    btnInventory.Text = "Tồn kho";
        //    btnReports.Image = isDarkMode ? Properties.Resources.report_icon_white : Properties.Resources.report_icon_black;
        //    btnReports.Text = "Báo cáo";

        //    // Căn lề trái cho icon và text
        //    foreach (Guna2Button btn in new[] { btnDashboard, btnProducts, btnSuppliers, btnCustomers, btnGoodsReceipt, btnSalesInvoice, btnInventory, btnReports })
        //    {
        //        btn.ImageAlign = HorizontalAlignment.Left;
        //        btn.TextAlign = HorizontalAlignment.Left;
        //        btn.ImageSize = new Size(20, 20); // Kích thước icon
        //        btn.Padding = new Padding(25, 0, 0, 0); // Đẩy text ra khỏi icon, căn lề trái
        //    }
        //}
        #endregion

        #region Event Handlers - Sidebar Menu
        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            LoadDashboard();
            //lblSubNavbarTitle.Text = "Dashboard";
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            LoadUserControl(CreatePlaceholder("Module Quản lý Sản phẩm"));
           // lblSubNavbarTitle.Text = "Sản phẩm";
        }

        private void BtnSuppliers_Click(object sender, EventArgs e)
        {
            LoadUserControl(CreatePlaceholder("Module Quản lý Nhà cung cấp"));
            //lblSubNavbarTitle.Text = "Nhà cung cấp";
        }

        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            LoadUserControl(CreatePlaceholder("Module Quản lý Khách hàng"));
            //lblSubNavbarTitle.Text = "Khách hàng";
        }

        private void BtnGoodsReceipt_Click(object sender, EventArgs e)
        {
            LoadUserControl(CreatePlaceholder("Module Nhập hàng"));
           // lblSubNavbarTitle.Text = "Nhập hàng";
        }

        private void BtnSalesInvoice_Click(object sender, EventArgs e)
        {
            LoadUserControl(CreatePlaceholder("Module Bán hàng"));
           // lblSubNavbarTitle.Text = "Bán hàng";
        }

        private void BtnInventory_Click(object sender, EventArgs e)
        {
            LoadUserControl(CreatePlaceholder("Module Tồn kho"));
            //lblSubNavbarTitle.Text = "Tồn kho";
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            LoadUserControl(CreatePlaceholder("Module Báo cáo"));
           // lblSubNavbarTitle.Text = "Báo cáo";
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            LoadUserControl(CreatePlaceholder("Module Quản lý Người dùng"));
           // lblSubNavbarTitle.Text = "Người dùng";
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            LoadUserControl(CreatePlaceholder("Module Trợ giúp"));
           // lblSubNavbarTitle.Text = "Trợ giúp";
        }
        #endregion

        #region Event Handlers - Navbar
        private void BtnNotification_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có 3 thông báo mới!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Cài đặt đang được phát triển", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                statusTimer?.Stop();
                Application.Exit();
            }
        }
        #endregion

        #region Event Handlers - Resize
        private void PnlNavbar_Resize(object sender, EventArgs e)
        {
            UpdateNavbarControlsPosition();
        }

        private void UpdateNavbarControlsPosition()
        {
            int rightX = pnlNavbar.Width - 320;
            btnNotification.Location = new Point(rightX, 15);
            btnSettings.Location = new Point(rightX + 50, 15);
            picAvatar.Location = new Point(rightX + 100, 15);
            lblUsername.Location = new Point(rightX + 150, 18);
            lblRole.Location = new Point(rightX + 150, 38);

            txtSearch.Location = new Point(10, 15); // Cố định vì không toggle sidebar
        }
        #endregion

        #region Public Methods
        public void SetUserInfo(string username, string role, Image avatar = null)
        {
            lblUsername.Text = username;
            lblRole.Text = role;
            if (avatar != null) picAvatar.Image = avatar;
            else CreateDefaultAvatar();
        }

        public void SetMenuVisibility(string role)
        {
            ResetMenuVisibility();

            switch (role.ToUpper())
            {
                case "ADMIN":
                    break;
                case "THU NGÂN":
                    btnGoodsReceipt.Visible = false;
                    btnReports.Visible = false;
                    btnSuppliers.Visible = false;
                    btnInventory.Visible = false;
                    break;
                case "THỦ KHO":
                    btnSalesInvoice.Visible = false;
                    btnCustomers.Visible = false;
                    btnReports.Visible = false;
                    break;
                case "KẾ TOÁN":
                    break;
                default:
                    HideAllMenuExceptDashboard();
                    break;
            }
        }

        // Phương thức để thay đổi chế độ màu nền (tính năng tương lai)
        public void SetDarkMode(bool darkMode)
        {
            isDarkMode = darkMode;
            pnlSidebar.FillColor = darkMode ? Color.FromArgb(24, 48, 48) : Color.White;
            pnlNavbar.FillColor = darkMode ? Color.FromArgb(18, 38, 38) : Color.LightGray;
            pnlBody.FillColor = darkMode ? Color.FromArgb(248, 249, 250) : Color.White;
           // subNavbar.FillColor = darkMode ? Color.FromArgb(18, 38, 38) : Color.LightGray;

            // Cập nhật icon theo chế độ màu
            //SetupButtonIcons();

            // Cập nhật màu chữ và icon
            foreach (Guna2Button btn in new[] { btnDashboard, btnProducts, btnSuppliers, btnCustomers, btnGoodsReceipt, btnSalesInvoice, btnInventory, btnReports })
            {
                btn.ForeColor = darkMode ? Color.White : Color.Black;
            }
            lblUsername.ForeColor = darkMode ? Color.White : Color.Black;
            lblRole.ForeColor = darkMode ? Color.White : Color.Black;
            lblStatusDate.ForeColor = darkMode ? Color.White : Color.Black;
            lblStatusUser.ForeColor = darkMode ? Color.White : Color.Black;
           // lblSubNavbarTitle.ForeColor = darkMode ? Color.White : Color.Black;
        }
        #endregion

        #region Private Methods
        private void LoadDashboard()
        {
            var dashboardPanel = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                FillColor = Color.FromArgb(248, 249, 250)
            };

            var lblWelcome = new Label
            {
                Text = "🌾 Chào mừng đến với\nHệ thống Quản lý Cửa hàng Gạo",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 150, 120),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Size = new Size(600, 100),
                Anchor = AnchorStyles.None
            };

            var lblInstruction = new Label
            {
                Text = "Vui lòng chọn chức năng từ menu bên trái để bắt đầu",
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.FromArgb(100, 100, 100),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Size = new Size(600, 40),
                Anchor = AnchorStyles.None
            };

            dashboardPanel.Resize += (s, e) =>
            {
                lblWelcome.Location = new Point((dashboardPanel.Width - 600) / 2, (dashboardPanel.Height - 100) / 2 - 50);
                lblInstruction.Location = new Point((dashboardPanel.Width - 600) / 2, (dashboardPanel.Height - 40) / 2 + 70);
            };

            dashboardPanel.Controls.Add(lblWelcome);
            dashboardPanel.Controls.Add(lblInstruction);

            LoadUserControl(dashboardPanel);
        }

        private void LoadUserControl(Control control)
        {
            pnlBody.Controls.Clear();
           // pnlBody.Controls.Add(subNavbar); // Giữ navbar phụ
            control.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(control);
            control.BringToFront();
        }

        private Control CreatePlaceholder(string moduleName)
        {
            var placeholder = new Label
            {
                Text = $"📦 {moduleName}\n\n(Đang phát triển)",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 150, 120),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(248, 249, 250)
            };
            return placeholder;
        }

        private void CreateDefaultAvatar()
        {
            Bitmap bmp = new Bitmap(40, 40);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(0, 180, 140));
                g.DrawString(
                    lblUsername.Text.Substring(0, 1).ToUpper(),
                    new Font("Segoe UI", 16, FontStyle.Bold),
                    Brushes.White,
                    new PointF(10, 5)
                );
            }
            picAvatar.Image = bmp;
        }

        private void ResetMenuVisibility()
        {
            btnDashboard.Visible = true;
            btnProducts.Visible = true;
            btnSuppliers.Visible = true;
            btnCustomers.Visible = true;
            btnGoodsReceipt.Visible = true;
            btnSalesInvoice.Visible = true;
            btnInventory.Visible = true;
            btnReports.Visible = true;
        }

        private void HideAllMenuExceptDashboard()
        {
            btnProducts.Visible = false;
            btnSuppliers.Visible = false;
            btnCustomers.Visible = false;
            btnGoodsReceipt.Visible = false;
            btnSalesInvoice.Visible = false;
            btnInventory.Visible = false;
            btnReports.Visible = false;
        }
        #endregion

        #region Form Events
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            statusTimer?.Stop();
            base.OnFormClosing(e);
        }
        #endregion
    }
}