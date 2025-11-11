using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace DoubleTRice.UI
{
    partial class MainUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlSidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlMenu = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSeparator4 = new System.Windows.Forms.Label();
            this.lblSeparator1 = new System.Windows.Forms.Label();
            this.btnReports = new Guna.UI2.WinForms.Guna2Button();
            this.lblSeparator3 = new System.Windows.Forms.Label();
            this.btnInventory = new Guna.UI2.WinForms.Guna2Button();
            this.btnSalesInvoice = new Guna.UI2.WinForms.Guna2Button();
            this.btnGoodsReceipt = new Guna.UI2.WinForms.Guna2Button();
            this.lblSeparator2 = new System.Windows.Forms.Label();
            this.btnCustomers = new Guna.UI2.WinForms.Guna2Button();
            this.btnSuppliers = new Guna.UI2.WinForms.Guna2Button();
            this.btnProducts = new Guna.UI2.WinForms.Guna2Button();
            this.btnDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.pnlBrand = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlNavbar = new Guna.UI2.WinForms.Guna2Panel();
            this.btnToggleSidebar = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnNotification = new Guna.UI2.WinForms.Guna2Button();
            this.btnSettings = new Guna.UI2.WinForms.Guna2Button();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.pnlBody = new Guna.UI2.WinForms.Guna2Panel();
            this.subNavbar = new Guna.UI2.WinForms.Guna2Panel(); // Navbar phụ trong body
            this.lblSubNavbarTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblStatusDate = new System.Windows.Forms.Label();
            this.lblStatusUser = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.subNavbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.pnlSidebar.Controls.Add(this.pnlMenu);
            this.pnlSidebar.Controls.Add(this.pnlBrand);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(167, 482);
            this.pnlSidebar.TabIndex = 0;
            // 
            // pnlMenu
            // 
            this.pnlMenu.AutoScroll = true;
            this.pnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenu.Controls.Add(this.lblSeparator4);
            this.pnlMenu.Controls.Add(this.lblSeparator1);
            this.pnlMenu.Controls.Add(this.btnReports);
            this.pnlMenu.Controls.Add(this.lblSeparator3);
            this.pnlMenu.Controls.Add(this.btnInventory);
            this.pnlMenu.Controls.Add(this.btnSalesInvoice);
            this.pnlMenu.Controls.Add(this.btnGoodsReceipt);
            this.pnlMenu.Controls.Add(this.lblSeparator2);
            this.pnlMenu.Controls.Add(this.btnCustomers);
            this.pnlMenu.Controls.Add(this.btnSuppliers);
            this.pnlMenu.Controls.Add(this.btnProducts);
            this.pnlMenu.Controls.Add(this.btnDashboard);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.Location = new System.Drawing.Point(0, 50);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(167, 432);
            this.pnlMenu.TabIndex = 0;
            // 
            // lblSeparator4
            // 
            this.lblSeparator4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.lblSeparator4.Location = new System.Drawing.Point(0, 400);
            this.lblSeparator4.Name = "lblSeparator4";
            this.lblSeparator4.Size = new System.Drawing.Size(167, 2);
            this.lblSeparator4.TabIndex = 11;
            // 
            // lblSeparator1
            // 
            this.lblSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.lblSeparator1.Location = new System.Drawing.Point(0, 150);
            this.lblSeparator1.Name = "lblSeparator1";
            this.lblSeparator1.Size = new System.Drawing.Size(167, 2);
            this.lblSeparator1.TabIndex = 10;
            // 
            // btnReports
            // 
            this.btnReports.BorderRadius = 8;
            this.btnReports.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReports.FillColor = System.Drawing.Color.Transparent;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(0, 360);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(167, 40);
            this.btnReports.TabIndex = 9;
            this.btnReports.Text = "📈 Báo cáo";
            this.btnReports.Click += new System.EventHandler(this.BtnReports_Click);
            // 
            // lblSeparator3
            // 
            this.lblSeparator3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.lblSeparator3.Location = new System.Drawing.Point(0, 300);
            this.lblSeparator3.Name = "lblSeparator3";
            this.lblSeparator3.Size = new System.Drawing.Size(167, 2);
            this.lblSeparator3.TabIndex = 8;
            // 
            // btnInventory
            // 
            this.btnInventory.BorderRadius = 8;
            this.btnInventory.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.btnInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventory.FillColor = System.Drawing.Color.Transparent;
            this.btnInventory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnInventory.ForeColor = System.Drawing.Color.White;
            this.btnInventory.Location = new System.Drawing.Point(0, 260);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(167, 40);
            this.btnInventory.TabIndex = 7;
            this.btnInventory.Text = "📊 Tồn kho";
            this.btnInventory.Click += new System.EventHandler(this.BtnInventory_Click);
            // 
            // btnSalesInvoice
            // 
            this.btnSalesInvoice.BorderRadius = 8;
            this.btnSalesInvoice.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.btnSalesInvoice.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSalesInvoice.FillColor = System.Drawing.Color.Transparent;
            this.btnSalesInvoice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSalesInvoice.ForeColor = System.Drawing.Color.White;
            this.btnSalesInvoice.Location = new System.Drawing.Point(0, 220);
            this.btnSalesInvoice.Name = "btnSalesInvoice";
            this.btnSalesInvoice.Size = new System.Drawing.Size(167, 40);
            this.btnSalesInvoice.TabIndex = 6;
            this.btnSalesInvoice.Text = "🛒 Bán hàng";
            this.btnSalesInvoice.Click += new System.EventHandler(this.BtnSalesInvoice_Click);
            // 
            // btnGoodsReceipt
            // 
            this.btnGoodsReceipt.BorderRadius = 8;
            this.btnGoodsReceipt.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.btnGoodsReceipt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGoodsReceipt.FillColor = System.Drawing.Color.Transparent;
            this.btnGoodsReceipt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGoodsReceipt.ForeColor = System.Drawing.Color.White;
            this.btnGoodsReceipt.Location = new System.Drawing.Point(0, 180);
            this.btnGoodsReceipt.Name = "btnGoodsReceipt";
            this.btnGoodsReceipt.Size = new System.Drawing.Size(167, 40);
            this.btnGoodsReceipt.TabIndex = 5;
            this.btnGoodsReceipt.Text = "📥 Nhập hàng";
            this.btnGoodsReceipt.Click += new System.EventHandler(this.BtnGoodsReceipt_Click);
            // 
            // lblSeparator2
            // 
            this.lblSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.lblSeparator2.Location = new System.Drawing.Point(0, 120);
            this.lblSeparator2.Name = "lblSeparator2";
            this.lblSeparator2.Size = new System.Drawing.Size(167, 2);
            this.lblSeparator2.TabIndex = 4;
            // 
            // btnCustomers
            // 
            this.btnCustomers.BorderRadius = 8;
            this.btnCustomers.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.btnCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomers.FillColor = System.Drawing.Color.Transparent;
            this.btnCustomers.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCustomers.ForeColor = System.Drawing.Color.White;
            this.btnCustomers.Location = new System.Drawing.Point(0, 80);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(167, 40);
            this.btnCustomers.TabIndex = 3;
            this.btnCustomers.Text = "👥 Khách hàng";
            this.btnCustomers.Click += new System.EventHandler(this.BtnCustomers_Click);
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.BorderRadius = 8;
            this.btnSuppliers.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.btnSuppliers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSuppliers.FillColor = System.Drawing.Color.Transparent;
            this.btnSuppliers.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSuppliers.ForeColor = System.Drawing.Color.White;
            this.btnSuppliers.Location = new System.Drawing.Point(0, 40);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(167, 40);
            this.btnSuppliers.TabIndex = 2;
            this.btnSuppliers.Text = "🏭 Nhà cung cấp";
            this.btnSuppliers.Click += new System.EventHandler(this.BtnSuppliers_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.BorderRadius = 8;
            this.btnProducts.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.btnProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProducts.FillColor = System.Drawing.Color.Transparent;
            this.btnProducts.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnProducts.ForeColor = System.Drawing.Color.White;
            this.btnProducts.Location = new System.Drawing.Point(0, 152);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(167, 40);
            this.btnProducts.TabIndex = 1;
            this.btnProducts.Text = "📦 Sản phẩm";
            this.btnProducts.Click += new System.EventHandler(this.BtnProducts_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BorderRadius = 8;
            this.btnDashboard.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FillColor = System.Drawing.Color.Transparent;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 112);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(167, 40);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "📊 Dashboard";
            this.btnDashboard.Click += new System.EventHandler(this.BtnDashboard_Click);
            // 
            // pnlBrand
            // 
            this.pnlBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.pnlBrand.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBrand.Location = new System.Drawing.Point(0, 0);
            this.pnlBrand.Name = "pnlBrand";
            this.pnlBrand.Size = new System.Drawing.Size(167, 50);
            this.pnlBrand.TabIndex = 0;
            // 
            // pnlNavbar
            // 
            this.pnlNavbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pnlNavbar.Controls.Add(this.btnToggleSidebar);
            this.pnlNavbar.Controls.Add(this.txtSearch);
            this.pnlNavbar.Controls.Add(this.btnNotification);
            this.pnlNavbar.Controls.Add(this.btnSettings);
            this.pnlNavbar.Controls.Add(this.picAvatar);
            this.pnlNavbar.Controls.Add(this.lblUsername);
            this.pnlNavbar.Controls.Add(this.lblRole);
            this.pnlNavbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavbar.Location = new System.Drawing.Point(167, 0);
            this.pnlNavbar.Name = "pnlNavbar";
            this.pnlNavbar.Size = new System.Drawing.Size(700, 60);
            this.pnlNavbar.TabIndex = 1;
            this.pnlNavbar.Resize += new System.EventHandler(this.PnlNavbar_Resize);
            // 
            // btnToggleSidebar
            // 
            this.btnToggleSidebar.BorderRadius = 8;
            this.btnToggleSidebar.FillColor = System.Drawing.Color.Transparent;
            this.btnToggleSidebar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnToggleSidebar.ForeColor = System.Drawing.Color.White;
            this.btnToggleSidebar.Location = new System.Drawing.Point(10, 15);
            this.btnToggleSidebar.Name = "btnToggleSidebar";
            this.btnToggleSidebar.Size = new System.Drawing.Size(40, 30);
            this.btnToggleSidebar.TabIndex = 5;
            this.btnToggleSidebar.Text = "☰";
            this.btnToggleSidebar.Click += new System.EventHandler(this.BtnToggleSidebar_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.FillColor = System.Drawing.Color.White;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Location = new System.Drawing.Point(60, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm kiếm...";
            this.txtSearch.Size = new System.Drawing.Size(286, 30);
            this.txtSearch.TabIndex = 4;
            // 
            // btnNotification
            // 
            this.btnNotification.BorderRadius = 8;
            this.btnNotification.FillColor = System.Drawing.Color.Transparent;
            this.btnNotification.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNotification.ForeColor = System.Drawing.Color.White;
            this.btnNotification.Location = new System.Drawing.Point(380, 15);
            this.btnNotification.Name = "btnNotification";
            this.btnNotification.Size = new System.Drawing.Size(50, 30);
            this.btnNotification.TabIndex = 3;
            this.btnNotification.Text = "🔔";
            this.btnNotification.Click += new System.EventHandler(this.BtnNotification_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BorderRadius = 8;
            this.btnSettings.FillColor = System.Drawing.Color.Transparent;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Location = new System.Drawing.Point(440, 15);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(50, 30);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "⚙️";
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // picAvatar
            // 
            this.picAvatar.Location = new System.Drawing.Point(500, 15);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(40, 30);
            this.picAvatar.TabIndex = 1;
            this.picAvatar.TabStop = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(550, 18);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(60, 15);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "User Name";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRole.ForeColor = System.Drawing.Color.White;
            this.lblRole.Location = new System.Drawing.Point(550, 38);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(30, 13);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "Role";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlBody.Controls.Add(this.subNavbar);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(167, 60);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(700, 422);
            this.pnlBody.TabIndex = 2;
            // 
            // subNavbar
            // 
            this.subNavbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.subNavbar.Controls.Add(this.lblSubNavbarTitle);
            this.subNavbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.subNavbar.Location = new System.Drawing.Point(0, 0);
            this.subNavbar.Name = "subNavbar";
            this.subNavbar.Size = new System.Drawing.Size(700, 40);
            this.subNavbar.TabIndex = 0;
            // 
            // lblSubNavbarTitle
            // 
            this.lblSubNavbarTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubNavbarTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubNavbarTitle.ForeColor = System.Drawing.Color.White;
            this.lblSubNavbarTitle.Location = new System.Drawing.Point(10, 10);
            this.lblSubNavbarTitle.Name = "lblSubNavbarTitle";
            this.lblSubNavbarTitle.Size = new System.Drawing.Size(100, 20);
            this.lblSubNavbarTitle.TabIndex = 0;
            this.lblSubNavbarTitle.Text = "Dashboard";
            // 
            // lblStatusDate
            // 
            this.lblStatusDate.AutoSize = true;
            this.lblStatusDate.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblStatusDate.ForeColor = System.Drawing.Color.White;
            this.lblStatusDate.Location = new System.Drawing.Point(10, 450);
            this.lblStatusDate.Name = "lblStatusDate";
            this.lblStatusDate.Size = new System.Drawing.Size(100, 13);
            this.lblStatusDate.TabIndex = 3;
            this.lblStatusDate.Text = "📅 11/11/2025 23:04";
            // 
            // lblStatusUser
            // 
            this.lblStatusUser.AutoSize = true;
            this.lblStatusUser.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblStatusUser.ForeColor = System.Drawing.Color.White;
            this.lblStatusUser.Location = new System.Drawing.Point(120, 450);
            this.lblStatusUser.Name = "lblStatusUser";
            this.lblStatusUser.Size = new System.Drawing.Size(100, 13);
            this.lblStatusUser.TabIndex = 4;
            this.lblStatusUser.Text = "Trạng thái: Online";
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 482);
            this.Controls.Add(this.lblStatusUser);
            this.Controls.Add(this.lblStatusDate);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlNavbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(852, 467);
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Cửa Hàng Gạo - Double T Rice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSidebar.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.subNavbar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna2Panel pnlSidebar;
        private Guna2Panel pnlNavbar;
        private Guna2Panel pnlBody;
        private Guna2Panel pnlBrand;
        private Guna2Panel pnlMenu;
        private Label lblSeparator1;
        private Label lblSeparator2;
        private Label lblSeparator3;
        private Label lblSeparator4;
        private Guna2Button btnDashboard;
        private Guna2Button btnProducts;
        private Guna2Button btnSuppliers;
        private Guna2Button btnCustomers;
        private Guna2Button btnGoodsReceipt;
        private Guna2Button btnSalesInvoice;
        private Guna2Button btnInventory;
        private Guna2Button btnReports;
        private Guna2Button btnToggleSidebar;
        private Guna2TextBox txtSearch;
        private Guna2Button btnNotification;
        private Guna2Button btnSettings;
        private PictureBox picAvatar;
        private Label lblUsername;
        private Label lblRole;
        private Label lblStatusDate;
        private Label lblStatusUser;
        private Guna2Panel subNavbar; // Navbar phụ trong body
        private Guna2HtmlLabel lblSubNavbarTitle;
    }
}