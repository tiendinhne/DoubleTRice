using DoubleTRice.LOGIC;
using DoubleTRice.UI.BASE;
using DoubleTRice.UI.ChildForms;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI
{
    public partial class MainUI : Form
    {
        #region Fields
        private Timer statusTimer;
        private Form currentChildForm; // Lưu form con hiện tại
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
            SetMenuVisibility(UserSession.VaiTro);  // ← Add dòng này
            //ap dung mode neu form con co
            if (currentChildForm != null)
            {
                currentChildForm.BackColor = Mode.GetBodyColor();
                currentChildForm.ForeColor = Mode.GetForeColor();
            }
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
                //lblSeparator1,
               // lblSeparator2,
                //lblSeparator3,
                lblSeparator4,
                //guna2HtmlLabel2,
                //guna2HtmlLabel1
            };

            // Collect navbar buttons
            Guna2Button[] navbarButtons = new Guna2Button[]
            {
                //btnNotification,
               // btnSettings
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
                txtSearch: null ,
                navbarButtons: navbarButtons,
                statusLabels: statusLabels,
                accountPanel: panel1,
                accountLabels: accountLabels
            );
            // Áp dụng màu cho 2 label nhóm menu
            ApplyGroupLabelMode(lblGroupDanhMuc);
            ApplyGroupLabelMode(lblGroupQuanLy);

            // Refresh lại controls trong body nếu có
            RefreshBodyContent();
        }
        private void ApplyGroupLabelMode(Label lbl)
        {
            if (lbl == null) return;

            if (Mode.IsDarkMode)
            {
                //Color DarkBackground = Color.FromArgb(0, 70, 67);     // #004643
                //Color LightBackground = Color.FromArgb(240, 237, 229); // #f0ede5
                lbl.ForeColor = Color.FromArgb(220, 220, 220);   // chữ sáng
                lbl.BackColor = Color.FromArgb(0, 70, 67);      // nền sidebar đậm
            }
            else
            {
                lbl.ForeColor = Color.FromArgb(0, 70, 67);
                lbl.BackColor = Color.FromArgb(240, 237, 229);   // nền sáng
            }
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

        #region Open Child Form Methods -------------------------------------
        /// <summary>
        /// Mở Form con trong panel body
        /// </summary>
        /// <param name="childForm">Form con cần mở</param>
        public void OpenChildForm(Form childForm)
        {
            // Đóng form con cũ nếu có
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                pnlBody.Controls.Remove(currentChildForm);
                currentChildForm.Dispose();
                currentChildForm = null;
            }

            // Khởi tạo form con mới
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.BackColor = Mode.GetBodyColor();
            childForm.ForeColor = Mode.GetForeColor();

            // Subscribe to mode change cho child form
            this.BackColorChanged += (s, e) =>
            {
                if (currentChildForm != null && !currentChildForm.IsDisposed)
                {
                    currentChildForm.BackColor = Mode.GetBodyColor();
                    currentChildForm.ForeColor = Mode.GetForeColor();
                }
            };

            // Add vào panel body
            pnlBody.Controls.Clear();
            pnlBody.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        /// <summary>
        /// Đóng form con hiện tại
        /// </summary>
        public void CloseChildForm()
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                pnlBody.Controls.Remove(currentChildForm);
                currentChildForm.Dispose();
                currentChildForm = null;
            }
        }
        #endregion

        #region Event Handlers - Sidebar Menu
        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                var productsForm = new TrangChuUI();
                OpenChildForm(productsForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form Sản phẩm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            // TODO: Thay thế bằng form thực tế
           

            // Tạm thời dùng placeholder
            //CloseChildForm();
            //LoadUserControl(CreatePlaceholder("Module Quản lý Sản phẩm"));
            /* Khi đã có form Products, sử dụng như sau:
            try
            */
            try
            {
                var productsForm = new ProductManagementUI();
                OpenChildForm(productsForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form Sản phẩm: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //----------- làm tương tự cho các form sau---------------------------
        private void BtnSuppliers_Click(object sender, EventArgs e)
        {
            try
            {
                var supplierForm = new SupplierManagementUI();
                OpenChildForm(supplierForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form Nhà cung cấp: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                var customerForm = new CustomerManagementUI();
                OpenChildForm(customerForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form Khách hàng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGoodsReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                var goodsReceiptForm = new GoodsReceiptManagementUI();
                OpenChildForm(goodsReceiptForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form nhap hang: {ex.Message}", "Lỗi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalesInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                var goodsReceiptForm = new SalesInvoiceManagementUI();
                OpenChildForm(goodsReceiptForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form nhap hang: {ex.Message}", "Lỗi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //them cong no
        }

        private void BtnInventory_Click(object sender, EventArgs e)
        {
            //CloseChildForm();

            try
            {
                var form = new DebtManagementUI(this); // ← TRUYỀN MainUI vào form con
                OpenChildForm(form);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form kho: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //LoadUserControl(CreatePlaceholder("Module Tồn kho"));
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            try
            {
                var adjustmentForm = new StockAdjustmentManagementUI();
                OpenChildForm(adjustmentForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form dieuchinhkho: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnHelp_Click(object sender, EventArgs e)
        {
            LoadUserControl(CreatePlaceholder("Module Trợ giúp"));
        }
        #endregion

        #region Event Handlers - Navbar----------------------------------

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
                CloseChildForm(); // Đóng form con trước khi thoát
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
           // btnNotification.Location = new Point(rightX, 38);
            //btnSettings.Location = new Point(rightX - 97, 38);
            //txtSearch.Location = new Point(15, 23);
            // Các nút bên phải (từ phải sang trái)
            pictureBox2.Location = new Point(pnlNavbar.Width-20, 0);
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
        /// 
        public void SetMenuVisibility(string role)
        {
            ResetMenuEnabled();  // bật hết lên trước rồi disable theo quyền

            switch (role.ToUpper())
            {
                case "ADMIN":
                    break;

                case "THU NGÂN": // Chỉ bán hàng
                    DisableButton(btnGoodsReceipt);  // Nhập hàng
                    DisableButton(btnReports);       // Điều chỉnh kho
                    DisableButton(btnSuppliers);     // NCC
                    DisableButton(btnInventory);     // Công nợ
                    DisableButton(BtnUsers);         // Nhân viên
                    break;

                case "THỦ KHO": // Chỉ nhập hàng + điều chỉnh kho
                    DisableButton(btnSalesInvoice);  // Bán hàng
                    DisableButton(btnCustomers);     // Khách hàng
                    DisableButton(btnInventory);     // Công nợ
                    DisableButton(BtnUsers);
                    break;

                case "KẾ TOÁN": // Chỉ công nợ
                    DisableButton(btnGoodsReceipt);
                    DisableButton(btnSuppliers);
                    DisableButton(btnSalesInvoice);
                    DisableButton(btnReports);
                    DisableButton(BtnUsers);
                    break;

                default:
                    DisableAllMenuExceptDashboard();
                    DisableButton(BtnUsers);
                    break;
            }
        }
        private void DisableAllMenuExceptDashboard()
        {
            foreach (Control ctrl in pnlMenu.Controls)
            {
                if (ctrl is Guna2Button btn && btn != btnDashboard)
                    DisableButton(btn);
            }
        }

        private void ResetMenuEnabled()
        {
            foreach (Control control in pnlMenu.Controls)
            {
                if (control is Guna2Button btn)
                {
                    btn.Enabled = true;

                    btn.FillColor = Color.Transparent;
                    btn.ForeColor = Mode.GetForeColor();

                    btn.HoverState.FillColor = Color.FromArgb(0, 180, 140);
                    btn.HoverState.ForeColor = Color.White;
                }
            }
        }

        private void DisableButton(Guna2Button btn)
        {
            btn.Enabled = false;

            if (Mode.IsDarkMode)
            {
                // DARK MODE
                btn.DisabledState.FillColor = Color.FromArgb(60, 60, 60);
                btn.DisabledState.ForeColor = Color.FromArgb(120, 120, 120);
                btn.DisabledState.CustomBorderColor = btn.DisabledState.FillColor;
                btn.DisabledState.BorderColor = btn.DisabledState.FillColor;
            }
            else
            {
                // LIGHT MODE
                btn.DisabledState.FillColor = Color.FromArgb(220, 220, 220);
                btn.DisabledState.ForeColor = Color.Gray;
                btn.DisabledState.CustomBorderColor = btn.DisabledState.FillColor;
                btn.DisabledState.BorderColor = btn.DisabledState.FillColor;
            }

            // Tắt hover để không đổi màu khi rê chuột
            btn.HoverState.FillColor = btn.DisabledState.FillColor;
            btn.HoverState.ForeColor = btn.DisabledState.ForeColor;
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

        /// <summary>
        /// Lấy form con hiện tại
        /// </summary>
        public Form GetCurrentChildForm()
        {
            return currentChildForm;
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

        /// <summary>
        /// Tạo placeholder cho module chưa hoàn thiện
        /// </summary>
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

        #region Form Events -----------------------------------------------------
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Cleanup child form trước
            try
            {
                CloseChildForm();
            }
            catch (Exception ex)
            {
                // Log error nhưng vẫn cho phép đóng
                System.Diagnostics.Debug.WriteLine($"Error closing child form: {ex.Message}");
            }

            // Stop timer
            if (statusTimer != null)
            {
                statusTimer.Stop();
                statusTimer.Dispose();
                statusTimer = null;
            }

            // Unsubscribe event
            try
            {
                Mode.DarkModeChanged -= OnDarkModeChanged;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error unsubscribing event: {ex.Message}");
            }

            base.OnFormClosing(e);
        }
        #endregion

        #region Other Events
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Tự động cleanup và thoát ứng dụng
            var result = MessageBox.Show(
                   "Bạn có chắc muốn thoát?",
                   "Xác nhận",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question
               );

            if (result == DialogResult.Yes)
            {
                this.Close(); // Trigger OnFormClosing → Cleanup
            }
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

        private void BtnUsers_Click_1(object sender, EventArgs e)
        {
            // Check admin permission
            if (!UserSession.IsAdmin())
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!",
                    "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var usersForm = new UserManagementForm();
                OpenChildForm(usersForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form Quản lý người dùng: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            //ReportForm form = new ReportForm();
            //form.ShowDialog();
            OpenChildForm(new ReportForm());
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var settingForm = new SettingForm())
                {
                    // Show as dialog (modal)
                    settingForm.ShowDialog(this);

                    // Nếu form được đóng do đổi mật khẩu thành công
                    // → Application sẽ tự restart trong SettingForm.OnPasswordChanged()
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở cài đặt: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}