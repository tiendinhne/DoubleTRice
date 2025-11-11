// ===================================================================
// FILE: MainForm.Designer.cs
// Chứa code khởi tạo giao diện (Designer generated code)
// ===================================================================
using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

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
            this.ResumeLayout();
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
            this.pnlBody = new Guna.UI2.WinForms.Guna2Panel();
            this.btnToggleSidebar = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnNotification = new Guna.UI2.WinForms.Guna2Button();
            this.btnSettings = new Guna.UI2.WinForms.Guna2Button();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblStatusDate = new System.Windows.Forms.Label();
            this.lblStatusUser = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
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
            this.pnlMenu.FillColor = System.Drawing.Color.Transparent;
            this.pnlMenu.Location = new System.Drawing.Point(0, 90);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.pnlMenu.Size = new System.Drawing.Size(167, 392);
            this.pnlMenu.TabIndex = 1;
            // 
            // lblSeparator4
            // 
            this.lblSeparator4.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSeparator4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSeparator4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblSeparator4.Location = new System.Drawing.Point(7, 369);
            this.lblSeparator4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSeparator4.Name = "lblSeparator4";
            this.lblSeparator4.Size = new System.Drawing.Size(136, 25);
            this.lblSeparator4.TabIndex = 11;
            this.lblSeparator4.Text = "HỆ THỐNG";
            this.lblSeparator4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSeparator1
            // 
            this.lblSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSeparator1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblSeparator1.Location = new System.Drawing.Point(7, 344);
            this.lblSeparator1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSeparator1.Name = "lblSeparator1";
            this.lblSeparator1.Size = new System.Drawing.Size(136, 25);
            this.lblSeparator1.TabIndex = 1;
            this.lblSeparator1.Text = "QUẢN LÝ DANH MỤC";
            this.lblSeparator1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnReports
            // 
            this.btnReports.BorderRadius = 8;
            this.btnReports.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnReports.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.btnReports.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReports.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReports.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReports.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReports.FillColor = System.Drawing.Color.Transparent;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnReports.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.btnReports.Location = new System.Drawing.Point(7, 308);
            this.btnReports.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(136, 36);
            this.btnReports.TabIndex = 10;
            this.btnReports.Text = "📈 Báo cáo";
            this.btnReports.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReports.Click += new System.EventHandler(this.BtnReports_Click);
            // 
            // lblSeparator3
            // 
            this.lblSeparator3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSeparator3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSeparator3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblSeparator3.Location = new System.Drawing.Point(7, 283);
            this.lblSeparator3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSeparator3.Name = "lblSeparator3";
            this.lblSeparator3.Size = new System.Drawing.Size(136, 25);
            this.lblSeparator3.TabIndex = 9;
            this.lblSeparator3.Text = "BÁO CÁO";
            this.lblSeparator3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnInventory
            // 
            this.btnInventory.BorderRadius = 8;
            this.btnInventory.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnInventory.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.btnInventory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInventory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInventory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInventory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventory.FillColor = System.Drawing.Color.Transparent;
            this.btnInventory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnInventory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnInventory.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.btnInventory.Location = new System.Drawing.Point(7, 247);
            this.btnInventory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(136, 36);
            this.btnInventory.TabIndex = 8;
            this.btnInventory.Text = "📊 Tồn kho";
            this.btnInventory.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInventory.Click += new System.EventHandler(this.BtnInventory_Click);
            // 
            // btnSalesInvoice
            // 
            this.btnSalesInvoice.BorderRadius = 8;
            this.btnSalesInvoice.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnSalesInvoice.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.btnSalesInvoice.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSalesInvoice.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSalesInvoice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSalesInvoice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSalesInvoice.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSalesInvoice.FillColor = System.Drawing.Color.Transparent;
            this.btnSalesInvoice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSalesInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnSalesInvoice.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.btnSalesInvoice.Location = new System.Drawing.Point(7, 211);
            this.btnSalesInvoice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSalesInvoice.Name = "btnSalesInvoice";
            this.btnSalesInvoice.Size = new System.Drawing.Size(136, 36);
            this.btnSalesInvoice.TabIndex = 7;
            this.btnSalesInvoice.Text = "🛒 Bán hàng";
            this.btnSalesInvoice.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSalesInvoice.Click += new System.EventHandler(this.BtnSalesInvoice_Click);
            // 
            // btnGoodsReceipt
            // 
            this.btnGoodsReceipt.BorderRadius = 8;
            this.btnGoodsReceipt.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnGoodsReceipt.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.btnGoodsReceipt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGoodsReceipt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGoodsReceipt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGoodsReceipt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGoodsReceipt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGoodsReceipt.FillColor = System.Drawing.Color.Transparent;
            this.btnGoodsReceipt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGoodsReceipt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnGoodsReceipt.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.btnGoodsReceipt.Location = new System.Drawing.Point(7, 175);
            this.btnGoodsReceipt.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnGoodsReceipt.Name = "btnGoodsReceipt";
            this.btnGoodsReceipt.Size = new System.Drawing.Size(136, 36);
            this.btnGoodsReceipt.TabIndex = 6;
            this.btnGoodsReceipt.Text = "📥 Nhập hàng";
            this.btnGoodsReceipt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnGoodsReceipt.Click += new System.EventHandler(this.BtnGoodsReceipt_Click);
            // 
            // lblSeparator2
            // 
            this.lblSeparator2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSeparator2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSeparator2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblSeparator2.Location = new System.Drawing.Point(7, 150);
            this.lblSeparator2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSeparator2.Name = "lblSeparator2";
            this.lblSeparator2.Size = new System.Drawing.Size(136, 25);
            this.lblSeparator2.TabIndex = 5;
            this.lblSeparator2.Text = "NGHIỆP VỤ";
            this.lblSeparator2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCustomers
            // 
            this.btnCustomers.BorderRadius = 8;
            this.btnCustomers.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnCustomers.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.btnCustomers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCustomers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCustomers.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCustomers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomers.FillColor = System.Drawing.Color.Transparent;
            this.btnCustomers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCustomers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnCustomers.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.btnCustomers.Location = new System.Drawing.Point(7, 114);
            this.btnCustomers.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(136, 36);
            this.btnCustomers.TabIndex = 4;
            this.btnCustomers.Text = "👥 Khách hàng";
            this.btnCustomers.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCustomers.Click += new System.EventHandler(this.BtnCustomers_Click);
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.BorderRadius = 8;
            this.btnSuppliers.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnSuppliers.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.btnSuppliers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSuppliers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSuppliers.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSuppliers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSuppliers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSuppliers.FillColor = System.Drawing.Color.Transparent;
            this.btnSuppliers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSuppliers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnSuppliers.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.btnSuppliers.Location = new System.Drawing.Point(7, 78);
            this.btnSuppliers.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(136, 36);
            this.btnSuppliers.TabIndex = 3;
            this.btnSuppliers.Text = "🏭 Nhà cung cấp";
            this.btnSuppliers.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSuppliers.Click += new System.EventHandler(this.BtnSuppliers_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.BorderRadius = 8;
            this.btnProducts.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnProducts.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.btnProducts.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnProducts.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnProducts.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnProducts.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProducts.FillColor = System.Drawing.Color.Transparent;
            this.btnProducts.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnProducts.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.btnProducts.Location = new System.Drawing.Point(7, 42);
            this.btnProducts.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(136, 36);
            this.btnProducts.TabIndex = 2;
            this.btnProducts.Text = "📦 Sản phẩm";
            this.btnProducts.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProducts.Click += new System.EventHandler(this.BtnProducts_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BorderRadius = 8;
            this.btnDashboard.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnDashboard.Checked = true;
            this.btnDashboard.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.btnDashboard.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDashboard.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDashboard.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDashboard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FillColor = System.Drawing.Color.Transparent;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnDashboard.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.btnDashboard.Location = new System.Drawing.Point(7, 6);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(136, 36);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "📊 Dashboard";
            this.btnDashboard.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDashboard.Click += new System.EventHandler(this.BtnDashboard_Click);
            // 
            // pnlBrand
            // 
            this.pnlBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pnlBrand.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBrand.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pnlBrand.Location = new System.Drawing.Point(0, 0);
            this.pnlBrand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlBrand.Name = "pnlBrand";
            this.pnlBrand.Size = new System.Drawing.Size(167, 90);
            this.pnlBrand.TabIndex = 0;
            // 
            // pnlNavbar
            // 
            this.pnlNavbar.Location = new System.Drawing.Point(0, 0);
            this.pnlNavbar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlNavbar.Name = "pnlNavbar";
            this.pnlNavbar.Size = new System.Drawing.Size(133, 65);
            this.pnlNavbar.TabIndex = 4;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlBody.Location = new System.Drawing.Point(167, 0);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.pnlBody.Size = new System.Drawing.Size(700, 482);
            this.pnlBody.TabIndex = 3;
            // 
            // btnToggleSidebar
            // 
            this.btnToggleSidebar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnToggleSidebar.ForeColor = System.Drawing.Color.White;
            this.btnToggleSidebar.Location = new System.Drawing.Point(0, 0);
            this.btnToggleSidebar.Name = "btnToggleSidebar";
            this.btnToggleSidebar.Size = new System.Drawing.Size(180, 45);
            this.btnToggleSidebar.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(286, 60);
            this.txtSearch.TabIndex = 0;
            // 
            // btnNotification
            // 
            this.btnNotification.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNotification.ForeColor = System.Drawing.Color.White;
            this.btnNotification.Location = new System.Drawing.Point(0, 0);
            this.btnNotification.Name = "btnNotification";
            this.btnNotification.Size = new System.Drawing.Size(180, 45);
            this.btnNotification.TabIndex = 0;
            // 
            // btnSettings
            // 
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Location = new System.Drawing.Point(0, 0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(180, 45);
            this.btnSettings.TabIndex = 0;
            // 
            // picAvatar
            // 
            this.picAvatar.Location = new System.Drawing.Point(0, 0);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(100, 50);
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(0, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(100, 23);
            this.lblUsername.TabIndex = 0;
            // 
            // lblRole
            // 
            this.lblRole.Location = new System.Drawing.Point(0, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(100, 23);
            this.lblRole.TabIndex = 0;
            // 
            // lblStatusDate
            // 
            this.lblStatusDate.Location = new System.Drawing.Point(0, 0);
            this.lblStatusDate.Name = "lblStatusDate";
            this.lblStatusDate.Size = new System.Drawing.Size(100, 23);
            this.lblStatusDate.TabIndex = 0;
            // 
            // lblStatusUser
            // 
            this.lblStatusUser.Location = new System.Drawing.Point(0, 0);
            this.lblStatusUser.Name = "lblStatusUser";
            this.lblStatusUser.Size = new System.Drawing.Size(100, 23);
            this.lblStatusUser.TabIndex = 0;
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 482);
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
            this.ResumeLayout(false);

        }
        
        
        #endregion
        // Panels
        private Guna2Panel pnlSidebar;
        private Guna2Panel pnlNavbar;
        private Guna2Panel pnlBody;
        private Guna2Panel pnlBrand;
        private Guna2Panel pnlMenu;
        private Label lblSeparator1;
        private Label lblSeparator2;
        private Label lblSeparator3;
        private Label lblSeparator4;

        // Menu Buttons
        private Guna2Button btnDashboard;
        private Guna2Button btnProducts;
        private Guna2Button btnSuppliers;
        private Guna2Button btnCustomers;
        private Guna2Button btnGoodsReceipt;
        private Guna2Button btnSalesInvoice;
        private Guna2Button btnInventory;
        private Guna2Button btnReports;

        // Navbar Components
        private Guna2Button btnToggleSidebar;
        private Guna2TextBox txtSearch;
        private Guna2Button btnNotification;
        private Guna2Button btnSettings;
        private PictureBox picAvatar;
        private Label lblUsername;
        private Label lblRole;

        // StatusBar Components
        private Label lblStatusDate;
        private Label lblStatusUser;
    }

}