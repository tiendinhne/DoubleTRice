using DoubleTRice.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DoubleTRice.UI
{
    public partial class MainUI : Form
    {
        private bool isSidebarExpanded = true;
        private const int SIDEBAR_WIDTH_EXPANDED = 250;
        private const int SIDEBAR_WIDTH_COLLAPSED = 70;
        private Timer statusTimer;
        public MainUI()
        {
            InitializeComponent();
            //AdjustFormSize();
            InitializeStatusTimer();
            LoadDashboard(); // Load trang chủ mặc định
        }
        private void InitializeStatusTimer()
        {
            statusTimer = new Timer { Interval = 1000 };
            statusTimer.Tick += (s, e) => lblStatusDate.Text = $"📅 {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
            statusTimer.Start();
        }
        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            // TODO: Load Products UserControl
            LoadUserControl(CreatePlaceholder("Module Quản lý Sản phẩm"));
        }

        private void BtnSuppliers_Click(object sender, EventArgs e)
        {
            // TODO: Load Suppliers UserControl
            LoadUserControl(CreatePlaceholder("Module Quản lý Nhà cung cấp"));
        }

        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            // TODO: Load Customers UserControl
            LoadUserControl(CreatePlaceholder("Module Quản lý Khách hàng"));
        }

        private void BtnGoodsReceipt_Click(object sender, EventArgs e)
        {
            // TODO: Load GoodsReceipt UserControl
            LoadUserControl(CreatePlaceholder("Module Nhập hàng"));
        }

        private void BtnSalesInvoice_Click(object sender, EventArgs e)
        {
            // TODO: Load SalesInvoice UserControl
            LoadUserControl(CreatePlaceholder("Module Bán hàng"));
        }

        private void BtnInventory_Click(object sender, EventArgs e)
        {
            // TODO: Load Inventory UserControl
            LoadUserControl(CreatePlaceholder("Module Tồn kho"));
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            // TODO: Load Reports UserControl
            LoadUserControl(CreatePlaceholder("Module Báo cáo"));
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            // TODO: Load Users UserControl
            LoadUserControl(CreatePlaceholder("Module Quản lý Người dùng"));
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            // TODO: Load Help UserControl
            LoadUserControl(CreatePlaceholder("Module Trợ giúp"));
        }

        private void BtnToggleSidebar_Click(object sender, EventArgs e)
        {
            isSidebarExpanded = !isSidebarExpanded;
            pnlSidebar.Width = isSidebarExpanded ? SIDEBAR_WIDTH_EXPANDED : SIDEBAR_WIDTH_COLLAPSED;

            // Cập nhật vị trí các control trên navbar
            UpdateNavbarControlsPosition();
        }

        private void BtnNotification_Click(object sender, EventArgs e)
        {
            // TODO: Hiển thị thông báo
            MessageBox.Show("Bạn có 3 thông báo mới!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            // TODO: Mở form Settings
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
                // TODO: Clear session data
                // TODO: Return to LoginForm
                Application.Exit();
            }
        }

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

            // Cập nhật vị trí toggle button
            btnToggleSidebar.Location = new Point(pnlSidebar.Width + 20, 15);
            txtSearch.Location = new Point(pnlSidebar.Width + 80, 15);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Load UserControl vào body panel
        /// </summary>
        /// <param name="control">UserControl cần load</param>
        public void LoadUserControl(Control control)
        {
            pnlBody.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(control);
        }

        /// <summary>
        /// Cập nhật thông tin người dùng trên navbar
        /// </summary>
        public void SetUserInfo(string username, string role, Image avatar = null)
        {
            lblUsername.Text = username;
            lblRole.Text = role;
            lblStatusUser.Text = $"👤 Đăng nhập: {username} ({role})";

            if (avatar != null)
                picAvatar.Image = avatar;
            else
                CreateDefaultAvatar();
        }

        /// <summary>
        /// Hiển thị/ẩn các menu theo role
        /// </summary>
        public void SetMenuVisibility(string role)
        {
            // Reset tất cả về visible
            ResetMenuVisibility();

            switch (role.ToUpper())
            {
                case "ADMIN":
                    // Admin xem được tất cả
                    break;

                case "THU NGÂN":
                    // Chỉ cho phép bán hàng và xem khách hàng
                    btnGoodsReceipt.Visible = false;
                    btnUsers.Visible = false;
                    btnReports.Visible = false;
                    btnSuppliers.Visible = false;
                    btnInventory.Visible = false;
                    break;

                case "THỦ KHO":
                    // Chỉ cho phép nhập hàng, tồn kho, sản phẩm
                    btnSalesInvoice.Visible = false;
                    btnUsers.Visible = false;
                    btnCustomers.Visible = false;
                    btnReports.Visible = false;
                    break;

                case "KẾ TOÁN":
                    // Cho phép xem báo cáo, khách hàng, nhà cung cấp
                    btnUsers.Visible = false;
                    break;

                default:
                    // Nếu role không xác định, chỉ hiển thị dashboard
                    HideAllMenuExceptDashboard();
                    break;
            }
        }
        #endregion

        #region Private Methods
        private void LoadDashboard()
        {
            var dashboardPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(248, 249, 250)
            };

            var lblWelcome = new Label
            {
                Text = "🌾 Chào mừng đến với\nHệ thống Quản lý Cửa hàng Gạo",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 150, 120),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Size = new Size(600, 100),
                Location = new Point((dashboardPanel.Width - 600) / 2, 150)
            };

            var lblInstruction = new Label
            {
                Text = "Vui lòng chọn chức năng từ menu bên trái để bắt đầu",
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.FromArgb(100, 100, 100),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Size = new Size(600, 40),
                Location = new Point((dashboardPanel.Width - 600) / 2, 270)
            };

            dashboardPanel.Controls.Add(lblWelcome);
            dashboardPanel.Controls.Add(lblInstruction);

            LoadUserControl(dashboardPanel);
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
            // Tạo avatar mặc định với chữ cái đầu
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
            btnUsers.Visible = true;
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
            btnUsers.Visible = false;
        }
        #endregion

        #region Form Events
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            statusTimer?.Stop();
            base.OnFormClosing(e);
        }
        #endregion

        //private void AdjustFormSize()
        //{
        //    // Lấy kích thước màn hình hiện tại
        //    var screen = Screen.PrimaryScreen.WorkingArea;
        //    int width = (int)(screen.Width * 0.85);   // Form chiếm 85% chiều ngang
        //    int height = (int)(screen.Height * 0.85); // Form chiếm 85% chiều dọc

        //    // Cập nhật kích thước form
        //    this.Size = new Size(width, height);
        //    this.StartPosition = FormStartPosition.CenterScreen;
        //}
        //private void panelLogo_Paint(object sender, PaintEventArgs e)
        //{

        //}

        //private void panelBody_Paint(object sender, PaintEventArgs e)
        //{

        //}

        //private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        //{

        //}

        //private void guna2Button2_Click(object sender, EventArgs e)
        //{

        //}

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}

        //private void pictureBox3_Click(object sender, EventArgs e)
        //{
        //    this.ActiveControl = null;
        //    Application.Exit();
        //}

        //private void panelStatus_Paint(object sender, PaintEventArgs e)
        //{

        //}

        //private void panelNav_Paint(object sender, PaintEventArgs e)
        //{

        //}

        //private void guna2ImageButton2_Click(object sender, EventArgs e)
        //{

        //}

        //private void panelMenu_Paint(object sender, PaintEventArgs e)
        //{

        //}

        //private void panelInf_Paint(object sender, PaintEventArgs e)
        //{

        //}


        //// test productDAO
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    var list = ProductDAO.Instance.GetAllProducts();
        //    MessageBox.Show("Số lượng sản phẩm: " + list.Count.ToString());
        //}

        //private void pictureBox2_Click(object sender, EventArgs e)
        //{

        //}
    }
}
