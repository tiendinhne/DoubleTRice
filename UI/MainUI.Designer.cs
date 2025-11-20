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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.lblStatusDate = new System.Windows.Forms.Label();
            this.lblStatusUser = new System.Windows.Forms.Label();
            this.pnlNavbar = new Guna.UI2.WinForms.Guna2Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSettings = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnNotification = new Guna.UI2.WinForms.Guna2Button();
            this.pnlBody = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlBrand.SuspendLayout();
            this.pnlNavbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(250, 742);
            this.pnlSidebar.TabIndex = 0;
            // 
            // pnlMenu
            // 
            this.pnlMenu.AutoScroll = true;
            this.pnlMenu.BackColor = System.Drawing.Color.Teal;
            this.pnlMenu.Controls.Add(this.guna2Button1);
            this.pnlMenu.Controls.Add(this.panel1);
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
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 116);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(250, 626);
            this.pnlMenu.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.guna2CirclePictureBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 790);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 185);
            this.panel1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(109, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.label3.Size = new System.Drawing.Size(60, 35);
            this.label3.TabIndex = 5;
            this.label3.Text = "Role";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(96, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.label2.Size = new System.Drawing.Size(107, 35);
            this.label2.TabIndex = 4;
            this.label2.Text = "Username";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.label1.Size = new System.Drawing.Size(145, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Acount ABCCC";
            // 
            // lblSeparator4
            // 
            this.lblSeparator4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.lblSeparator4.Location = new System.Drawing.Point(0, 787);
            this.lblSeparator4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeparator4.Name = "lblSeparator4";
            this.lblSeparator4.Size = new System.Drawing.Size(250, 3);
            this.lblSeparator4.TabIndex = 11;
            // 
            // lblSeparator1
            // 
            this.lblSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.lblSeparator1.Location = new System.Drawing.Point(0, 403);
            this.lblSeparator1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeparator1.Name = "lblSeparator1";
            this.lblSeparator1.Size = new System.Drawing.Size(250, 3);
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
            this.btnReports.Location = new System.Drawing.Point(0, 434);
            this.btnReports.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(250, 62);
            this.btnReports.TabIndex = 9;
            this.btnReports.Text = "📈 Báo cáo";
            this.btnReports.Click += new System.EventHandler(this.BtnReports_Click);
            // 
            // lblSeparator3
            // 
            this.lblSeparator3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.lblSeparator3.Location = new System.Drawing.Point(0, 634);
            this.lblSeparator3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeparator3.Name = "lblSeparator3";
            this.lblSeparator3.Size = new System.Drawing.Size(250, 3);
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
            this.btnInventory.Location = new System.Drawing.Point(0, 372);
            this.btnInventory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(250, 62);
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
            this.btnSalesInvoice.Location = new System.Drawing.Point(0, 310);
            this.btnSalesInvoice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSalesInvoice.Name = "btnSalesInvoice";
            this.btnSalesInvoice.Size = new System.Drawing.Size(250, 62);
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
            this.btnGoodsReceipt.Location = new System.Drawing.Point(0, 248);
            this.btnGoodsReceipt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGoodsReceipt.Name = "btnGoodsReceipt";
            this.btnGoodsReceipt.Size = new System.Drawing.Size(250, 62);
            this.btnGoodsReceipt.TabIndex = 5;
            this.btnGoodsReceipt.Text = "📥 Nhập hàng";
            this.btnGoodsReceipt.Click += new System.EventHandler(this.BtnGoodsReceipt_Click);
            // 
            // lblSeparator2
            // 
            this.lblSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.lblSeparator2.Location = new System.Drawing.Point(0, 357);
            this.lblSeparator2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeparator2.Name = "lblSeparator2";
            this.lblSeparator2.Size = new System.Drawing.Size(250, 3);
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
            this.btnCustomers.Location = new System.Drawing.Point(0, 186);
            this.btnCustomers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(250, 62);
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
            this.btnSuppliers.Location = new System.Drawing.Point(0, 124);
            this.btnSuppliers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(250, 62);
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
            this.btnProducts.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnProducts.ForeColor = System.Drawing.Color.White;
            this.btnProducts.Location = new System.Drawing.Point(0, 62);
            this.btnProducts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(250, 62);
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
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 0);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(250, 62);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "📊 Dashboard";
            this.btnDashboard.Click += new System.EventHandler(this.BtnDashboard_Click);
            // 
            // pnlBrand
            // 
            this.pnlBrand.BackColor = System.Drawing.Color.White;
            this.pnlBrand.Controls.Add(this.pictureBox1);
            this.pnlBrand.Controls.Add(this.lblStatusDate);
            this.pnlBrand.Controls.Add(this.lblStatusUser);
            this.pnlBrand.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBrand.Location = new System.Drawing.Point(0, 0);
            this.pnlBrand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBrand.Name = "pnlBrand";
            this.pnlBrand.Size = new System.Drawing.Size(250, 116);
            this.pnlBrand.TabIndex = 0;
            // 
            // lblStatusDate
            // 
            this.lblStatusDate.AutoSize = true;
            this.lblStatusDate.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblStatusDate.ForeColor = System.Drawing.Color.White;
            this.lblStatusDate.Location = new System.Drawing.Point(40, 148);
            this.lblStatusDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusDate.Name = "lblStatusDate";
            this.lblStatusDate.Size = new System.Drawing.Size(163, 21);
            this.lblStatusDate.TabIndex = 3;
            this.lblStatusDate.Text = "📅 11/11/2025 23:04";
            // 
            // lblStatusUser
            // 
            this.lblStatusUser.AutoSize = true;
            this.lblStatusUser.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblStatusUser.ForeColor = System.Drawing.Color.White;
            this.lblStatusUser.Location = new System.Drawing.Point(60, 76);
            this.lblStatusUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusUser.Name = "lblStatusUser";
            this.lblStatusUser.Size = new System.Drawing.Size(132, 21);
            this.lblStatusUser.TabIndex = 4;
            this.lblStatusUser.Text = "Trạng thái: Online";
            // 
            // pnlNavbar
            // 
            this.pnlNavbar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlNavbar.Controls.Add(this.label4);
            this.pnlNavbar.Controls.Add(this.button1);
            this.pnlNavbar.Controls.Add(this.pictureBox2);
            this.pnlNavbar.Controls.Add(this.btnSettings);
            this.pnlNavbar.Controls.Add(this.txtSearch);
            this.pnlNavbar.Controls.Add(this.btnNotification);
            this.pnlNavbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavbar.Location = new System.Drawing.Point(250, 0);
            this.pnlNavbar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlNavbar.Name = "pnlNavbar";
            this.pnlNavbar.Size = new System.Drawing.Size(1050, 116);
            this.pnlNavbar.TabIndex = 1;
            this.pnlNavbar.Resize += new System.EventHandler(this.PnlNavbar_Resize);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(748, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 43);
            this.button1.TabIndex = 5;
            this.button1.Text = "Mode";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BorderRadius = 8;
            this.btnSettings.FillColor = System.Drawing.Color.Transparent;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Location = new System.Drawing.Point(867, 41);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 46);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "⚙️";
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Location = new System.Drawing.Point(192, 38);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm kiếm...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(429, 46);
            this.txtSearch.TabIndex = 4;
            // 
            // btnNotification
            // 
            this.btnNotification.BorderRadius = 8;
            this.btnNotification.FillColor = System.Drawing.Color.Transparent;
            this.btnNotification.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNotification.ForeColor = System.Drawing.Color.White;
            this.btnNotification.Location = new System.Drawing.Point(950, 38);
            this.btnNotification.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNotification.Name = "btnNotification";
            this.btnNotification.Size = new System.Drawing.Size(75, 46);
            this.btnNotification.TabIndex = 3;
            this.btnNotification.Text = "🔔";
            this.btnNotification.Click += new System.EventHandler(this.BtnNotification_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.LavenderBlush;
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(250, 116);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1050, 626);
            this.pnlBody.TabIndex = 2;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 8;
            this.guna2Button1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.guna2Button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(0, 496);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(250, 62);
            this.guna2Button1.TabIndex = 13;
            this.guna2Button1.Text = "Nhân viên";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = global::DoubleTRice.Properties.Resources.cancelred;
            this.pictureBox2.Location = new System.Drawing.Point(660, 42);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Image = global::DoubleTRice.Properties.Resources.smart_farm;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(12, 73);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(64, 64);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 6;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::DoubleTRice.Properties.Resources.LOGOCNPM_1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 116);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tên trang";
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 742);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlNavbar);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1278, 718);
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Cửa Hàng Gạo - Double T Rice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSidebar.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlBrand.ResumeLayout(false);
            this.pnlBrand.PerformLayout();
            this.pnlNavbar.ResumeLayout(false);
            this.pnlNavbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

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
        private Guna2TextBox txtSearch;
        private Guna2Button btnNotification;
        private Guna2Button btnSettings;
        private Label lblStatusDate;
        private Label lblStatusUser;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox2;
        private Label label2;
        private Label label3;
        private Guna2CirclePictureBox guna2CirclePictureBox1;
        private Button button1;
        private Guna2BorderlessForm guna2BorderlessForm1;
        private Guna2Button guna2Button1;
        private Label label4;
    }
}