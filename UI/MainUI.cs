using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using DoubleTRice.UI.BASE;

namespace DoubleTRice.UI
{
    public partial class MainUI : Form
    {
        #region Fields
        private Timer statusTimer;
        #endregion

        #region Constructor
        public MainUI()
        {
            InitializeComponent();
            InitializeStatusTimer();
            InitializeDarkModeToggle();
            ApplyCurrentMode(); // Áp dụng mode hiện tại
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

        private void InitializeDarkModeToggle()
        {
            // Subscribe to Dark Mode change event
            Mode.DarkModeChanged += OnDarkModeChanged;
        }

        /// <summary>
        /// Event handler khi Dark Mode thay đổi
        /// </summary>
        private void OnDarkModeChanged(bool isDarkMode)
        {
            ApplyCurrentMode();
        }

        /// <summary>
        /// Áp dụng mode hiện tại cho toàn bộ UI
        /// </summary>
        private void ApplyCurrentMode()
        {
            // Collect all menu buttons
            Guna2Button[] menuButtons = new Guna2Button[]
            {
                btnDashboard,
                btnProducts,
                btnSuppliers,
                btnCustomers,
                btnGoodsReceipt,
                btnSalesInvoice,
                btnInventory,
                btnReports
            };

            // Collect all separators
            Label[] separators = new Label[]
            {
                lblSeparator1,
                lblSeparator2,
                lblSeparator3,
                lblSeparator4
            };

            // Collect navbar buttons
            Guna2Button[] navbarButtons = new Guna2Button[]
            {
                btnNotification,
                btnSettings
            };

            // Collect status labels (không bao gồm lblStatusDate, lblStatusUser vì đã ẩn)
            Label[] statusLabels = new Label[] { };

            // Collect account labels
            Label[] accountLabels = new Label[]
            {
                label1,  // Account label
                label2,  // Username
                label3   // Role
            };

            // Apply mode
            Mode.ApplyModeToMainUI(
                pnlSidebar: pnlSidebar,
                pnlNavbar: pnlNavbar,
                pnlBody: pnlBody,
                pnlBrand: pnlBrand,
                pnlMenu: pnlMenu,
                menuButtons: menuButtons,
                separators: separators,
                txtSearch: txtSearch,
                navbarButtons: navbarButtons,
                statusLabels: statusLabels,
                accountPanel: panel1,
                accountLabels: accountLabels
            );

            // Refresh lại controls trong body nếu có
            RefreshBodyContent();
        }

        /// <summary>
        /// Refresh lại nội dung trong body panel
        /// </summary>
        private void RefreshBodyContent()
        {
            foreach (Control control in pnlBody.Controls)
            {
                if (control is Guna2Panel panel)
                {
                    panel.FillColor = Mode.GetBodyColor();
                    panel.BackColor = Mode.GetBodyColor();

                    foreach (Control child in panel.Controls)
                    {
                        if (child is Label label)
                        {
                            label.ForeColor = Mode.GetForeColor();
                        }
                    }
                }
                else if (control is Label label)
                {
                    label.ForeColor = Mode.GetForeColor();
                    label.BackColor = Mode.GetBodyColor();
                }
            }
        }
        #endregion

        #region Event Handlers - Sidebar Menu
        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            LoadUserControl(CreatePlaceholder("Module Quản lý Sản phẩm"));
        }

        private void BtnSuppliers_Click(object sender, EventArgs e)
        {
            LoadUserControl(CreatePlaceholder("Module Quản lý Nhà cung cấp"));
        }

        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            LoadUserControl(CreatePlaceholder("Module Quản lý Khách hàng"));
        }

        private void BtnGoodsReceipt_Click(object sender, EventArgs e)
        {
            LoadUserControl(CreatePlaceholder("Module Nhập hàng"));
        }

        private void BtnSalesInvoice_Click(object sender, EventArgs e)
        {
            LoadUserControl(CreatePlaceholder("Module Bán hàng"));
        }

        private void BtnInventory_Click(object sender, EventArgs e)
        {
            LoadUserControl(CreatePlaceholder("Module Tồn kho"));
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            LoadUserControl(CreatePlaceholder("Module Báo cáo"));
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            LoadUserControl(CreatePlaceholder("Module Quản lý Người dùng"));
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            LoadUserControl(CreatePlaceholder("Module Trợ giúp"));
        }
        #endregion

        #region Event Handlers - Navbar
        private void BtnNotification_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có 3 thông báo mới!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            // Toggle Dark/Light Mode
            Mode.ToggleMode();

            string modeText = Mode.IsDarkMode ? "Dark Mode" : "Light Mode";
            MessageBox.Show($"Đã chuyển sang {modeText}", "Cài đặt",
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
                Mode.DarkModeChanged -= OnDarkModeChanged; // Unsubscribe
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
            btnNotification.Location = new Point(rightX, 38);
            btnSettings.Location = new Point(rightX - 97, 38);
            txtSearch.Location = new Point(15, 23);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Set thông tin user và role
        /// </summary>
        public void SetUserInfo(string username, string role, Image avatar = null)
        {
            label2.Text = username;
            label3.Text = role;

            if (avatar != null)
                guna2CirclePictureBox1.Image = avatar;
            else
                CreateDefaultAvatar();
        }

        /// <summary>
        /// Phân quyền menu theo role
        /// </summary>
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

        /// <summary>
        /// Chuyển đổi Dark/Light Mode thủ công
        /// </summary>
        public void ToggleDarkMode()
        {
            Mode.ToggleMode();
        }

        /// <summary>
        /// Set Dark Mode
        /// </summary>
        public void SetDarkMode(bool darkMode)
        {
            Mode.IsDarkMode = darkMode;
        }
        #endregion

        #region Private Methods
        private void LoadDashboard()
        {
            var dashboardPanel = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                FillColor = Mode.GetBodyColor(),
                BackColor = Mode.GetBodyColor()
            };

            var lblWelcome = new Label
            {
                Text = "🌾 Chào mừng đến với\nHệ thống Quản lý Cửa hàng Gạo",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Mode.IsDarkMode ? Color.FromArgb(0, 200, 150) : Color.FromArgb(0, 70, 67),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Size = new Size(600, 100),
                Anchor = AnchorStyles.None,
                BackColor = Color.Transparent
            };

            var lblInstruction = new Label
            {
                Text = "Vui lòng chọn chức năng từ menu bên trái để bắt đầu",
                Font = new Font("Segoe UI", 12),
                ForeColor = Mode.GetForeColor(),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Size = new Size(600, 40),
                Anchor = AnchorStyles.None,
                BackColor = Color.Transparent
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
                ForeColor = Mode.GetForeColor(),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Mode.GetBodyColor()
            };
            return placeholder;
        }

        private void CreateDefaultAvatar()
        {
            Bitmap bmp = new Bitmap(64, 64);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(0, 180, 140));
                string initial = !string.IsNullOrEmpty(label2.Text) ? label2.Text.Substring(0, 1).ToUpper() : "U";
                g.DrawString(
                    initial,
                    new Font("Segoe UI", 24, FontStyle.Bold),
                    Brushes.White,
                    new PointF(18, 12)
                );
            }
            guna2CirclePictureBox1.Image = bmp;
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
            Mode.DarkModeChanged -= OnDarkModeChanged; // Unsubscribe event
            base.OnFormClosing(e);
        }
        #endregion

        #region Other Events
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Click vào username - có thể mở profile
        }
        #endregion


        // test mode
        private void button1_Click(object sender, EventArgs e)
        {
            Mode.ToggleMode(); // Đã implement sẵn
        }
    }
}