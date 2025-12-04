namespace DoubleTRice.UI.ChildForms
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.pnlDashboardHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.nudMonth = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.nudYear = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.pnlDashboardContent = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlDashboardCards = new Guna.UI2.WinForms.Guna2Panel();
            this.cardRevenue = new Guna.UI2.WinForms.Guna2Panel();
            this.cardProfit = new Guna.UI2.WinForms.Guna2Panel();
            this.cardCustomerDebt = new Guna.UI2.WinForms.Guna2Panel();
            this.cardSupplierDebt = new Guna.UI2.WinForms.Guna2Panel();
            this.cardLowStock = new Guna.UI2.WinForms.Guna2Panel();
            this.cardInvoices = new Guna.UI2.WinForms.Guna2Panel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pnlSupplierDebtHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnViewSupplierDebtReport = new Guna.UI2.WinForms.Guna2Button();
            this.pnlSupplierDebtContent = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvSupplierDebt = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pnlCustomerDebtHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnViewCustomerDebtReport = new Guna.UI2.WinForms.Guna2Button();
            this.pnlCustomerDebtContent = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvCustomerDebt = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlInventoryHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnViewInventoryReport = new Guna.UI2.WinForms.Guna2Button();
            this.pnlInventoryContent = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvInventoryReport = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlRevenueHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnViewRevenueReport = new Guna.UI2.WinForms.Guna2Button();
            this.pnlRevenueFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlRevenueContent = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvRevenueReport = new Guna.UI2.WinForms.Guna2DataGridView();
            this.TabControl = new Guna.UI2.WinForms.Guna2TabControl();
            this.lblMonth = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblYear = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDashboardRevenue = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDashboardProfit = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDashboardCustomerDebt = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDashboardSupplierDebt = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDashboardLowStock = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDashboardInvoices = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblStartDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblEnddate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTotalRevenue = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTotalProfit = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.pnlDashboardHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            this.pnlDashboardContent.SuspendLayout();
            this.pnlDashboardCards.SuspendLayout();
            this.cardRevenue.SuspendLayout();
            this.cardProfit.SuspendLayout();
            this.cardCustomerDebt.SuspendLayout();
            this.cardSupplierDebt.SuspendLayout();
            this.cardLowStock.SuspendLayout();
            this.cardInvoices.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.pnlSupplierDebtHeader.SuspendLayout();
            this.pnlSupplierDebtContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplierDebt)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.pnlCustomerDebtHeader.SuspendLayout();
            this.pnlCustomerDebtContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerDebt)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.pnlInventoryHeader.SuspendLayout();
            this.pnlInventoryContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryReport)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.pnlRevenueHeader.SuspendLayout();
            this.pnlRevenueFooter.SuspendLayout();
            this.pnlRevenueContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenueReport)).BeginInit();
            this.TabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnExport);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(22, 19, 22, 12);
            this.pnlHeader.Size = new System.Drawing.Size(1181, 100);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.lblTitle.Location = new System.Drawing.Point(22, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(372, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊 Báo cáo thống kê";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // btnExport
            // 
            this.btnExport.BorderRadius = 8;
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(979, 19);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(180, 69);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "📥 Xuất Excel";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.TabControl);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 100);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(22, 0, 22, 25);
            this.pnlContent.Size = new System.Drawing.Size(1181, 682);
            this.pnlContent.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.White;
            this.tabPage5.Controls.Add(this.pnlDashboardContent);
            this.tabPage5.Controls.Add(this.pnlDashboardHeader);
            this.tabPage5.Location = new System.Drawing.Point(4, 49);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.tabPage5.Size = new System.Drawing.Size(1129, 604);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Dashboard";
            // 
            // pnlDashboardHeader
            // 
            this.pnlDashboardHeader.Controls.Add(this.nudYear);
            this.pnlDashboardHeader.Controls.Add(this.lblYear);
            this.pnlDashboardHeader.Controls.Add(this.nudMonth);
            this.pnlDashboardHeader.Controls.Add(this.lblMonth);
            this.pnlDashboardHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDashboardHeader.Location = new System.Drawing.Point(11, 12);
            this.pnlDashboardHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDashboardHeader.Name = "pnlDashboardHeader";
            this.pnlDashboardHeader.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.pnlDashboardHeader.Size = new System.Drawing.Size(1107, 88);
            this.pnlDashboardHeader.TabIndex = 0;
            // 
            // nudMonth
            // 
            this.nudMonth.BackColor = System.Drawing.Color.Transparent;
            this.nudMonth.BorderRadius = 8;
            this.nudMonth.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudMonth.Dock = System.Windows.Forms.DockStyle.Left;
            this.nudMonth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudMonth.Location = new System.Drawing.Point(91, 0);
            this.nudMonth.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.nudMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudMonth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMonth.Name = "nudMonth";
            this.nudMonth.Size = new System.Drawing.Size(140, 76);
            this.nudMonth.TabIndex = 1;
            this.nudMonth.UseTransparentBackground = true;
            this.nudMonth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudYear
            // 
            this.nudYear.BackColor = System.Drawing.Color.Transparent;
            this.nudYear.BorderRadius = 8;
            this.nudYear.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudYear.Dock = System.Windows.Forms.DockStyle.Left;
            this.nudYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudYear.Location = new System.Drawing.Point(330, 0);
            this.nudYear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.nudYear.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.nudYear.Minimum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.nudYear.Name = "nudYear";
            this.nudYear.Size = new System.Drawing.Size(135, 76);
            this.nudYear.TabIndex = 3;
            this.nudYear.Value = new decimal(new int[] {
            2025,
            0,
            0,
            0});
            // 
            // pnlDashboardContent
            // 
            this.pnlDashboardContent.Controls.Add(this.pnlDashboardCards);
            this.pnlDashboardContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboardContent.Location = new System.Drawing.Point(11, 100);
            this.pnlDashboardContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDashboardContent.Name = "pnlDashboardContent";
            this.pnlDashboardContent.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.pnlDashboardContent.Size = new System.Drawing.Size(1107, 492);
            this.pnlDashboardContent.TabIndex = 1;
            // 
            // pnlDashboardCards
            // 
            this.pnlDashboardCards.Controls.Add(this.cardInvoices);
            this.pnlDashboardCards.Controls.Add(this.cardLowStock);
            this.pnlDashboardCards.Controls.Add(this.cardSupplierDebt);
            this.pnlDashboardCards.Controls.Add(this.cardCustomerDebt);
            this.pnlDashboardCards.Controls.Add(this.cardProfit);
            this.pnlDashboardCards.Controls.Add(this.cardRevenue);
            this.pnlDashboardCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDashboardCards.Location = new System.Drawing.Point(0, 25);
            this.pnlDashboardCards.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDashboardCards.Name = "pnlDashboardCards";
            this.pnlDashboardCards.Size = new System.Drawing.Size(1107, 425);
            this.pnlDashboardCards.TabIndex = 0;
            // 
            // cardRevenue
            // 
            this.cardRevenue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.cardRevenue.BorderRadius = 12;
            this.cardRevenue.BorderThickness = 2;
            this.cardRevenue.Controls.Add(this.lblDashboardRevenue);
            this.cardRevenue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(250)))));
            this.cardRevenue.Location = new System.Drawing.Point(0, 0);
            this.cardRevenue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cardRevenue.Name = "cardRevenue";
            this.cardRevenue.Padding = new System.Windows.Forms.Padding(22, 25, 22, 25);
            this.cardRevenue.Size = new System.Drawing.Size(349, 188);
            this.cardRevenue.TabIndex = 0;
            // 
            // cardProfit
            // 
            this.cardProfit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.cardProfit.BorderRadius = 12;
            this.cardProfit.BorderThickness = 2;
            this.cardProfit.Controls.Add(this.lblDashboardProfit);
            this.cardProfit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(245)))));
            this.cardProfit.Location = new System.Drawing.Point(369, 0);
            this.cardProfit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cardProfit.Name = "cardProfit";
            this.cardProfit.Padding = new System.Windows.Forms.Padding(22, 25, 22, 25);
            this.cardProfit.Size = new System.Drawing.Size(349, 188);
            this.cardProfit.TabIndex = 1;
            // 
            // cardCustomerDebt
            // 
            this.cardCustomerDebt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.cardCustomerDebt.BorderRadius = 12;
            this.cardCustomerDebt.BorderThickness = 2;
            this.cardCustomerDebt.Controls.Add(this.lblDashboardCustomerDebt);
            this.cardCustomerDebt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.cardCustomerDebt.Location = new System.Drawing.Point(738, 0);
            this.cardCustomerDebt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cardCustomerDebt.Name = "cardCustomerDebt";
            this.cardCustomerDebt.Padding = new System.Windows.Forms.Padding(22, 25, 22, 25);
            this.cardCustomerDebt.Size = new System.Drawing.Size(369, 188);
            this.cardCustomerDebt.TabIndex = 2;
            // 
            // cardSupplierDebt
            // 
            this.cardSupplierDebt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.cardSupplierDebt.BorderRadius = 12;
            this.cardSupplierDebt.BorderThickness = 2;
            this.cardSupplierDebt.Controls.Add(this.lblDashboardSupplierDebt);
            this.cardSupplierDebt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.cardSupplierDebt.Location = new System.Drawing.Point(0, 212);
            this.cardSupplierDebt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cardSupplierDebt.Name = "cardSupplierDebt";
            this.cardSupplierDebt.Padding = new System.Windows.Forms.Padding(22, 25, 22, 25);
            this.cardSupplierDebt.Size = new System.Drawing.Size(349, 188);
            this.cardSupplierDebt.TabIndex = 3;
            // 
            // cardLowStock
            // 
            this.cardLowStock.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.cardLowStock.BorderRadius = 12;
            this.cardLowStock.BorderThickness = 2;
            this.cardLowStock.Controls.Add(this.lblDashboardLowStock);
            this.cardLowStock.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.cardLowStock.Location = new System.Drawing.Point(369, 212);
            this.cardLowStock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cardLowStock.Name = "cardLowStock";
            this.cardLowStock.Padding = new System.Windows.Forms.Padding(22, 25, 22, 25);
            this.cardLowStock.Size = new System.Drawing.Size(349, 188);
            this.cardLowStock.TabIndex = 4;
            // 
            // cardInvoices
            // 
            this.cardInvoices.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.cardInvoices.BorderRadius = 12;
            this.cardInvoices.BorderThickness = 2;
            this.cardInvoices.Controls.Add(this.lblDashboardInvoices);
            this.cardInvoices.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(250)))), ((int)(((byte)(245)))));
            this.cardInvoices.Location = new System.Drawing.Point(738, 212);
            this.cardInvoices.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cardInvoices.Name = "cardInvoices";
            this.cardInvoices.Padding = new System.Windows.Forms.Padding(22, 25, 22, 25);
            this.cardInvoices.Size = new System.Drawing.Size(366, 188);
            this.cardInvoices.TabIndex = 5;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.White;
            this.tabPage4.Controls.Add(this.pnlSupplierDebtContent);
            this.tabPage4.Controls.Add(this.pnlSupplierDebtHeader);
            this.tabPage4.Location = new System.Drawing.Point(4, 49);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.tabPage4.Size = new System.Drawing.Size(1129, 604);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Công nợ NCC";
            // 
            // pnlSupplierDebtHeader
            // 
            this.pnlSupplierDebtHeader.Controls.Add(this.btnViewSupplierDebtReport);
            this.pnlSupplierDebtHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSupplierDebtHeader.Location = new System.Drawing.Point(11, 12);
            this.pnlSupplierDebtHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlSupplierDebtHeader.Name = "pnlSupplierDebtHeader";
            this.pnlSupplierDebtHeader.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.pnlSupplierDebtHeader.Size = new System.Drawing.Size(1107, 75);
            this.pnlSupplierDebtHeader.TabIndex = 0;
            // 
            // btnViewSupplierDebtReport
            // 
            this.btnViewSupplierDebtReport.BorderRadius = 8;
            this.btnViewSupplierDebtReport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnViewSupplierDebtReport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.btnViewSupplierDebtReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewSupplierDebtReport.ForeColor = System.Drawing.Color.White;
            this.btnViewSupplierDebtReport.Location = new System.Drawing.Point(927, 0);
            this.btnViewSupplierDebtReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnViewSupplierDebtReport.Name = "btnViewSupplierDebtReport";
            this.btnViewSupplierDebtReport.Size = new System.Drawing.Size(180, 63);
            this.btnViewSupplierDebtReport.TabIndex = 0;
            this.btnViewSupplierDebtReport.Text = "🔍 Xem báo cáo";
            // 
            // pnlSupplierDebtContent
            // 
            this.pnlSupplierDebtContent.Controls.Add(this.dgvSupplierDebt);
            this.pnlSupplierDebtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSupplierDebtContent.Location = new System.Drawing.Point(11, 87);
            this.pnlSupplierDebtContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlSupplierDebtContent.Name = "pnlSupplierDebtContent";
            this.pnlSupplierDebtContent.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.pnlSupplierDebtContent.Size = new System.Drawing.Size(1107, 505);
            this.pnlSupplierDebtContent.TabIndex = 1;
            // 
            // dgvSupplierDebt
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgvSupplierDebt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSupplierDebt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvSupplierDebt.ColumnHeadersHeight = 40;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(237)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSupplierDebt.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvSupplierDebt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSupplierDebt.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSupplierDebt.Location = new System.Drawing.Point(0, 12);
            this.dgvSupplierDebt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSupplierDebt.Name = "dgvSupplierDebt";
            this.dgvSupplierDebt.RowHeadersVisible = false;
            this.dgvSupplierDebt.RowHeadersWidth = 62;
            this.dgvSupplierDebt.RowTemplate.Height = 35;
            this.dgvSupplierDebt.Size = new System.Drawing.Size(1107, 493);
            this.dgvSupplierDebt.TabIndex = 0;
            this.dgvSupplierDebt.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSupplierDebt.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvSupplierDebt.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvSupplierDebt.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvSupplierDebt.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvSupplierDebt.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvSupplierDebt.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSupplierDebt.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvSupplierDebt.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSupplierDebt.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSupplierDebt.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSupplierDebt.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSupplierDebt.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvSupplierDebt.ThemeStyle.ReadOnly = false;
            this.dgvSupplierDebt.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSupplierDebt.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSupplierDebt.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSupplierDebt.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSupplierDebt.ThemeStyle.RowsStyle.Height = 35;
            this.dgvSupplierDebt.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSupplierDebt.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.pnlCustomerDebtContent);
            this.tabPage3.Controls.Add(this.pnlCustomerDebtHeader);
            this.tabPage3.Location = new System.Drawing.Point(4, 49);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.tabPage3.Size = new System.Drawing.Size(1129, 604);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Công nợ KH";
            // 
            // pnlCustomerDebtHeader
            // 
            this.pnlCustomerDebtHeader.Controls.Add(this.btnViewCustomerDebtReport);
            this.pnlCustomerDebtHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCustomerDebtHeader.Location = new System.Drawing.Point(11, 12);
            this.pnlCustomerDebtHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlCustomerDebtHeader.Name = "pnlCustomerDebtHeader";
            this.pnlCustomerDebtHeader.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.pnlCustomerDebtHeader.Size = new System.Drawing.Size(1107, 75);
            this.pnlCustomerDebtHeader.TabIndex = 0;
            // 
            // btnViewCustomerDebtReport
            // 
            this.btnViewCustomerDebtReport.BorderRadius = 8;
            this.btnViewCustomerDebtReport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnViewCustomerDebtReport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.btnViewCustomerDebtReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewCustomerDebtReport.ForeColor = System.Drawing.Color.White;
            this.btnViewCustomerDebtReport.Location = new System.Drawing.Point(927, 0);
            this.btnViewCustomerDebtReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnViewCustomerDebtReport.Name = "btnViewCustomerDebtReport";
            this.btnViewCustomerDebtReport.Size = new System.Drawing.Size(180, 63);
            this.btnViewCustomerDebtReport.TabIndex = 0;
            this.btnViewCustomerDebtReport.Text = "🔍 Xem báo cáo";
            // 
            // pnlCustomerDebtContent
            // 
            this.pnlCustomerDebtContent.Controls.Add(this.dgvCustomerDebt);
            this.pnlCustomerDebtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCustomerDebtContent.Location = new System.Drawing.Point(11, 87);
            this.pnlCustomerDebtContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlCustomerDebtContent.Name = "pnlCustomerDebtContent";
            this.pnlCustomerDebtContent.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.pnlCustomerDebtContent.Size = new System.Drawing.Size(1107, 505);
            this.pnlCustomerDebtContent.TabIndex = 1;
            // 
            // dgvCustomerDebt
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvCustomerDebt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomerDebt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCustomerDebt.ColumnHeadersHeight = 40;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(237)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomerDebt.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvCustomerDebt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomerDebt.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCustomerDebt.Location = new System.Drawing.Point(0, 12);
            this.dgvCustomerDebt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvCustomerDebt.Name = "dgvCustomerDebt";
            this.dgvCustomerDebt.RowHeadersVisible = false;
            this.dgvCustomerDebt.RowHeadersWidth = 62;
            this.dgvCustomerDebt.RowTemplate.Height = 35;
            this.dgvCustomerDebt.Size = new System.Drawing.Size(1107, 493);
            this.dgvCustomerDebt.TabIndex = 0;
            this.dgvCustomerDebt.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCustomerDebt.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCustomerDebt.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCustomerDebt.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCustomerDebt.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCustomerDebt.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCustomerDebt.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCustomerDebt.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvCustomerDebt.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCustomerDebt.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCustomerDebt.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCustomerDebt.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCustomerDebt.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvCustomerDebt.ThemeStyle.ReadOnly = false;
            this.dgvCustomerDebt.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCustomerDebt.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCustomerDebt.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCustomerDebt.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCustomerDebt.ThemeStyle.RowsStyle.Height = 35;
            this.dgvCustomerDebt.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCustomerDebt.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.pnlInventoryContent);
            this.tabPage2.Controls.Add(this.pnlInventoryHeader);
            this.tabPage2.Location = new System.Drawing.Point(4, 49);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.tabPage2.Size = new System.Drawing.Size(1129, 604);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tồn kho";
            // 
            // pnlInventoryHeader
            // 
            this.pnlInventoryHeader.Controls.Add(this.btnViewInventoryReport);
            this.pnlInventoryHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInventoryHeader.Location = new System.Drawing.Point(11, 12);
            this.pnlInventoryHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlInventoryHeader.Name = "pnlInventoryHeader";
            this.pnlInventoryHeader.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.pnlInventoryHeader.Size = new System.Drawing.Size(1107, 75);
            this.pnlInventoryHeader.TabIndex = 0;
            // 
            // btnViewInventoryReport
            // 
            this.btnViewInventoryReport.BorderRadius = 8;
            this.btnViewInventoryReport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnViewInventoryReport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.btnViewInventoryReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewInventoryReport.ForeColor = System.Drawing.Color.White;
            this.btnViewInventoryReport.Location = new System.Drawing.Point(927, 0);
            this.btnViewInventoryReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnViewInventoryReport.Name = "btnViewInventoryReport";
            this.btnViewInventoryReport.Size = new System.Drawing.Size(180, 63);
            this.btnViewInventoryReport.TabIndex = 0;
            this.btnViewInventoryReport.Text = "🔍 Xem báo cáo";
            // 
            // pnlInventoryContent
            // 
            this.pnlInventoryContent.Controls.Add(this.dgvInventoryReport);
            this.pnlInventoryContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInventoryContent.Location = new System.Drawing.Point(11, 87);
            this.pnlInventoryContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlInventoryContent.Name = "pnlInventoryContent";
            this.pnlInventoryContent.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.pnlInventoryContent.Size = new System.Drawing.Size(1107, 505);
            this.pnlInventoryContent.TabIndex = 1;
            // 
            // dgvInventoryReport
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvInventoryReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventoryReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvInventoryReport.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(237)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInventoryReport.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvInventoryReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventoryReport.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvInventoryReport.Location = new System.Drawing.Point(0, 12);
            this.dgvInventoryReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvInventoryReport.Name = "dgvInventoryReport";
            this.dgvInventoryReport.RowHeadersVisible = false;
            this.dgvInventoryReport.RowHeadersWidth = 62;
            this.dgvInventoryReport.RowTemplate.Height = 35;
            this.dgvInventoryReport.Size = new System.Drawing.Size(1107, 493);
            this.dgvInventoryReport.TabIndex = 0;
            this.dgvInventoryReport.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvInventoryReport.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvInventoryReport.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvInventoryReport.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvInventoryReport.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvInventoryReport.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvInventoryReport.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvInventoryReport.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvInventoryReport.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInventoryReport.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvInventoryReport.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvInventoryReport.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInventoryReport.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvInventoryReport.ThemeStyle.ReadOnly = false;
            this.dgvInventoryReport.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvInventoryReport.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvInventoryReport.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvInventoryReport.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvInventoryReport.ThemeStyle.RowsStyle.Height = 35;
            this.dgvInventoryReport.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvInventoryReport.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.pnlRevenueContent);
            this.tabPage1.Controls.Add(this.pnlRevenueFooter);
            this.tabPage1.Controls.Add(this.pnlRevenueHeader);
            this.tabPage1.Location = new System.Drawing.Point(4, 49);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.tabPage1.Size = new System.Drawing.Size(1129, 604);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Doanh thu";
            // 
            // pnlRevenueHeader
            // 
            this.pnlRevenueHeader.Controls.Add(this.btnViewRevenueReport);
            this.pnlRevenueHeader.Controls.Add(this.dtpEndDate);
            this.pnlRevenueHeader.Controls.Add(this.lblEnddate);
            this.pnlRevenueHeader.Controls.Add(this.dtpStartDate);
            this.pnlRevenueHeader.Controls.Add(this.lblStartDate);
            this.pnlRevenueHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRevenueHeader.Location = new System.Drawing.Point(11, 12);
            this.pnlRevenueHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlRevenueHeader.Name = "pnlRevenueHeader";
            this.pnlRevenueHeader.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.pnlRevenueHeader.Size = new System.Drawing.Size(1107, 100);
            this.pnlRevenueHeader.TabIndex = 0;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.BorderRadius = 8;
            this.dtpStartDate.Checked = true;
            this.dtpStartDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(107, 0);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(202, 88);
            this.dtpStartDate.TabIndex = 1;
            this.dtpStartDate.Value = new System.DateTime(2025, 12, 4, 0, 0, 0, 0);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.BorderRadius = 8;
            this.dtpEndDate.Checked = true;
            this.dtpEndDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(449, 0);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(202, 88);
            this.dtpEndDate.TabIndex = 3;
            this.dtpEndDate.Value = new System.DateTime(2025, 12, 4, 0, 0, 0, 0);
            // 
            // btnViewRevenueReport
            // 
            this.btnViewRevenueReport.BorderRadius = 8;
            this.btnViewRevenueReport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnViewRevenueReport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.btnViewRevenueReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewRevenueReport.ForeColor = System.Drawing.Color.White;
            this.btnViewRevenueReport.Location = new System.Drawing.Point(927, 0);
            this.btnViewRevenueReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnViewRevenueReport.Name = "btnViewRevenueReport";
            this.btnViewRevenueReport.Size = new System.Drawing.Size(180, 88);
            this.btnViewRevenueReport.TabIndex = 4;
            this.btnViewRevenueReport.Text = "🔍 Xem báo cáo";
            // 
            // pnlRevenueFooter
            // 
            this.pnlRevenueFooter.Controls.Add(this.lblTotalProfit);
            this.pnlRevenueFooter.Controls.Add(this.lblTotalRevenue);
            this.pnlRevenueFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRevenueFooter.Location = new System.Drawing.Point(11, 517);
            this.pnlRevenueFooter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlRevenueFooter.Name = "pnlRevenueFooter";
            this.pnlRevenueFooter.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.pnlRevenueFooter.Size = new System.Drawing.Size(1107, 75);
            this.pnlRevenueFooter.TabIndex = 1;
            // 
            // pnlRevenueContent
            // 
            this.pnlRevenueContent.Controls.Add(this.dgvRevenueReport);
            this.pnlRevenueContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRevenueContent.Location = new System.Drawing.Point(11, 112);
            this.pnlRevenueContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlRevenueContent.Name = "pnlRevenueContent";
            this.pnlRevenueContent.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.pnlRevenueContent.Size = new System.Drawing.Size(1107, 405);
            this.pnlRevenueContent.TabIndex = 2;
            // 
            // dgvRevenueReport
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvRevenueReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRevenueReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRevenueReport.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(237)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRevenueReport.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRevenueReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRevenueReport.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRevenueReport.Location = new System.Drawing.Point(0, 12);
            this.dgvRevenueReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvRevenueReport.Name = "dgvRevenueReport";
            this.dgvRevenueReport.RowHeadersVisible = false;
            this.dgvRevenueReport.RowHeadersWidth = 62;
            this.dgvRevenueReport.RowTemplate.Height = 35;
            this.dgvRevenueReport.Size = new System.Drawing.Size(1107, 393);
            this.dgvRevenueReport.TabIndex = 0;
            this.dgvRevenueReport.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dgvRevenueReport.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvRevenueReport.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvRevenueReport.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvRevenueReport.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvRevenueReport.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvRevenueReport.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRevenueReport.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.dgvRevenueReport.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRevenueReport.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvRevenueReport.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRevenueReport.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRevenueReport.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvRevenueReport.ThemeStyle.ReadOnly = false;
            this.dgvRevenueReport.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRevenueReport.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRevenueReport.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvRevenueReport.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvRevenueReport.ThemeStyle.RowsStyle.Height = 35;
            this.dgvRevenueReport.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRevenueReport.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Controls.Add(this.tabPage3);
            this.TabControl.Controls.Add(this.tabPage4);
            this.TabControl.Controls.Add(this.tabPage5);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.ItemSize = new System.Drawing.Size(200, 45);
            this.TabControl.Location = new System.Drawing.Point(22, 0);
            this.TabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1137, 657);
            this.TabControl.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.TabControl.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.TabControl.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.TabControl.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.TabControl.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.TabControl.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.TabControl.TabButtonIdleState.FillColor = System.Drawing.Color.White;
            this.TabControl.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TabControl.TabButtonIdleState.ForeColor = System.Drawing.Color.Gray;
            this.TabControl.TabButtonIdleState.InnerColor = System.Drawing.Color.White;
            this.TabControl.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.TabControl.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.TabControl.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.TabControl.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.TabControl.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.TabControl.TabButtonSize = new System.Drawing.Size(200, 45);
            this.TabControl.TabIndex = 0;
            this.TabControl.TabMenuBackColor = System.Drawing.Color.White;
            this.TabControl.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // lblMonth
            // 
            this.lblMonth.BackColor = System.Drawing.Color.Transparent;
            this.lblMonth.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMonth.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMonth.Location = new System.Drawing.Point(0, 0);
            this.lblMonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.lblMonth.Size = new System.Drawing.Size(91, 76);
            this.lblMonth.TabIndex = 0;
            this.lblMonth.Text = "📅 Tháng:";
            // 
            // lblYear
            // 
            this.lblYear.BackColor = System.Drawing.Color.Transparent;
            this.lblYear.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblYear.Location = new System.Drawing.Point(231, 0);
            this.lblYear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblYear.Name = "lblYear";
            this.lblYear.Padding = new System.Windows.Forms.Padding(22, 12, 0, 0);
            this.lblYear.Size = new System.Drawing.Size(99, 76);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "📅 Năm:";
            // 
            // lblDashboardRevenue
            // 
            this.lblDashboardRevenue.BackColor = System.Drawing.Color.Transparent;
            this.lblDashboardRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDashboardRevenue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDashboardRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.lblDashboardRevenue.Location = new System.Drawing.Point(22, 25);
            this.lblDashboardRevenue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDashboardRevenue.Name = "lblDashboardRevenue";
            this.lblDashboardRevenue.Size = new System.Drawing.Size(305, 138);
            this.lblDashboardRevenue.TabIndex = 0;
            this.lblDashboardRevenue.Text = "💰 Doanh thu: 0 đ";
            this.lblDashboardRevenue.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDashboardProfit
            // 
            this.lblDashboardProfit.BackColor = System.Drawing.Color.Transparent;
            this.lblDashboardProfit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDashboardProfit.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDashboardProfit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblDashboardProfit.Location = new System.Drawing.Point(22, 25);
            this.lblDashboardProfit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDashboardProfit.Name = "lblDashboardProfit";
            this.lblDashboardProfit.Size = new System.Drawing.Size(305, 138);
            this.lblDashboardProfit.TabIndex = 0;
            this.lblDashboardProfit.Text = "📈 Lợi nhuận: 0 đ";
            this.lblDashboardProfit.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDashboardCustomerDebt
            // 
            this.lblDashboardCustomerDebt.BackColor = System.Drawing.Color.Transparent;
            this.lblDashboardCustomerDebt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDashboardCustomerDebt.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDashboardCustomerDebt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.lblDashboardCustomerDebt.Location = new System.Drawing.Point(22, 25);
            this.lblDashboardCustomerDebt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDashboardCustomerDebt.Name = "lblDashboardCustomerDebt";
            this.lblDashboardCustomerDebt.Size = new System.Drawing.Size(325, 138);
            this.lblDashboardCustomerDebt.TabIndex = 0;
            this.lblDashboardCustomerDebt.Text = "👥 Nợ phải thu: 0 đ";
            this.lblDashboardCustomerDebt.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDashboardSupplierDebt
            // 
            this.lblDashboardSupplierDebt.BackColor = System.Drawing.Color.Transparent;
            this.lblDashboardSupplierDebt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDashboardSupplierDebt.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDashboardSupplierDebt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.lblDashboardSupplierDebt.Location = new System.Drawing.Point(22, 25);
            this.lblDashboardSupplierDebt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDashboardSupplierDebt.Name = "lblDashboardSupplierDebt";
            this.lblDashboardSupplierDebt.Size = new System.Drawing.Size(305, 138);
            this.lblDashboardSupplierDebt.TabIndex = 0;
            this.lblDashboardSupplierDebt.Text = "🏭 Nợ phải trả: 0 đ";
            this.lblDashboardSupplierDebt.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDashboardLowStock
            // 
            this.lblDashboardLowStock.BackColor = System.Drawing.Color.Transparent;
            this.lblDashboardLowStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDashboardLowStock.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDashboardLowStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.lblDashboardLowStock.Location = new System.Drawing.Point(22, 25);
            this.lblDashboardLowStock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDashboardLowStock.Name = "lblDashboardLowStock";
            this.lblDashboardLowStock.Size = new System.Drawing.Size(305, 138);
            this.lblDashboardLowStock.TabIndex = 0;
            this.lblDashboardLowStock.Text = "⚠️ Sắp hết hàng: 0 SP";
            this.lblDashboardLowStock.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDashboardInvoices
            // 
            this.lblDashboardInvoices.BackColor = System.Drawing.Color.Transparent;
            this.lblDashboardInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDashboardInvoices.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDashboardInvoices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.lblDashboardInvoices.Location = new System.Drawing.Point(22, 25);
            this.lblDashboardInvoices.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDashboardInvoices.Name = "lblDashboardInvoices";
            this.lblDashboardInvoices.Size = new System.Drawing.Size(322, 138);
            this.lblDashboardInvoices.TabIndex = 0;
            this.lblDashboardInvoices.Text = "📄 Tổng hóa đơn: 0";
            this.lblDashboardInvoices.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStartDate
            // 
            this.lblStartDate.BackColor = System.Drawing.Color.Transparent;
            this.lblStartDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStartDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStartDate.Location = new System.Drawing.Point(0, 0);
            this.lblStartDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.lblStartDate.Size = new System.Drawing.Size(107, 88);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "📅 Từ ngày:";
            // 
            // lblEnddate
            // 
            this.lblEnddate.BackColor = System.Drawing.Color.Transparent;
            this.lblEnddate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblEnddate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEnddate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEnddate.Location = new System.Drawing.Point(309, 0);
            this.lblEnddate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblEnddate.Name = "lblEnddate";
            this.lblEnddate.Padding = new System.Windows.Forms.Padding(22, 12, 0, 0);
            this.lblEnddate.Size = new System.Drawing.Size(140, 88);
            this.lblEnddate.TabIndex = 2;
            this.lblEnddate.Text = "📅 Đến ngày:";
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRevenue.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.Green;
            this.lblTotalRevenue.Location = new System.Drawing.Point(11, 12);
            this.lblTotalRevenue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.lblTotalRevenue.Size = new System.Drawing.Size(213, 51);
            this.lblTotalRevenue.TabIndex = 0;
            this.lblTotalRevenue.Text = "Tổng doanh thu: 0 đ";
            // 
            // lblTotalProfit
            // 
            this.lblTotalProfit.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalProfit.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTotalProfit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalProfit.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalProfit.Location = new System.Drawing.Point(224, 12);
            this.lblTotalProfit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblTotalProfit.Name = "lblTotalProfit";
            this.lblTotalProfit.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.lblTotalProfit.Size = new System.Drawing.Size(203, 51);
            this.lblTotalProfit.TabIndex = 1;
            this.lblTotalProfit.Text = "Tổng lợi nhuận: 0 đ";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 782);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ReportForm";
            this.Text = "Báo cáo thống kê";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.pnlDashboardHeader.ResumeLayout(false);
            this.pnlDashboardHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            this.pnlDashboardContent.ResumeLayout(false);
            this.pnlDashboardCards.ResumeLayout(false);
            this.cardRevenue.ResumeLayout(false);
            this.cardRevenue.PerformLayout();
            this.cardProfit.ResumeLayout(false);
            this.cardProfit.PerformLayout();
            this.cardCustomerDebt.ResumeLayout(false);
            this.cardCustomerDebt.PerformLayout();
            this.cardSupplierDebt.ResumeLayout(false);
            this.cardSupplierDebt.PerformLayout();
            this.cardLowStock.ResumeLayout(false);
            this.cardLowStock.PerformLayout();
            this.cardInvoices.ResumeLayout(false);
            this.cardInvoices.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.pnlSupplierDebtHeader.ResumeLayout(false);
            this.pnlSupplierDebtContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplierDebt)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.pnlCustomerDebtHeader.ResumeLayout(false);
            this.pnlCustomerDebtContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerDebt)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.pnlInventoryHeader.ResumeLayout(false);
            this.pnlInventoryContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryReport)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.pnlRevenueHeader.ResumeLayout(false);
            this.pnlRevenueHeader.PerformLayout();
            this.pnlRevenueFooter.ResumeLayout(false);
            this.pnlRevenueFooter.PerformLayout();
            this.pnlRevenueContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenueReport)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnExport;
        private Guna.UI2.WinForms.Guna2Panel pnlContent;
        private Guna.UI2.WinForms.Guna2TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private Guna.UI2.WinForms.Guna2Panel pnlRevenueContent;
        private Guna.UI2.WinForms.Guna2DataGridView dgvRevenueReport;
        private Guna.UI2.WinForms.Guna2Panel pnlRevenueFooter;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalProfit;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalRevenue;
        private Guna.UI2.WinForms.Guna2Panel pnlRevenueHeader;
        private Guna.UI2.WinForms.Guna2Button btnViewRevenueReport;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEndDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEnddate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStartDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStartDate;
        private System.Windows.Forms.TabPage tabPage2;
        private Guna.UI2.WinForms.Guna2Panel pnlInventoryContent;
        private Guna.UI2.WinForms.Guna2DataGridView dgvInventoryReport;
        private Guna.UI2.WinForms.Guna2Panel pnlInventoryHeader;
        private Guna.UI2.WinForms.Guna2Button btnViewInventoryReport;
        private System.Windows.Forms.TabPage tabPage3;
        private Guna.UI2.WinForms.Guna2Panel pnlCustomerDebtContent;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCustomerDebt;
        private Guna.UI2.WinForms.Guna2Panel pnlCustomerDebtHeader;
        private Guna.UI2.WinForms.Guna2Button btnViewCustomerDebtReport;
        private System.Windows.Forms.TabPage tabPage4;
        private Guna.UI2.WinForms.Guna2Panel pnlSupplierDebtContent;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSupplierDebt;
        private Guna.UI2.WinForms.Guna2Panel pnlSupplierDebtHeader;
        private Guna.UI2.WinForms.Guna2Button btnViewSupplierDebtReport;
        private System.Windows.Forms.TabPage tabPage5;
        private Guna.UI2.WinForms.Guna2Panel pnlDashboardContent;
        private Guna.UI2.WinForms.Guna2Panel pnlDashboardCards;
        private Guna.UI2.WinForms.Guna2Panel cardInvoices;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDashboardInvoices;
        private Guna.UI2.WinForms.Guna2Panel cardLowStock;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDashboardLowStock;
        private Guna.UI2.WinForms.Guna2Panel cardSupplierDebt;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDashboardSupplierDebt;
        private Guna.UI2.WinForms.Guna2Panel cardCustomerDebt;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDashboardCustomerDebt;
        private Guna.UI2.WinForms.Guna2Panel cardProfit;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDashboardProfit;
        private Guna.UI2.WinForms.Guna2Panel cardRevenue;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDashboardRevenue;
        private Guna.UI2.WinForms.Guna2Panel pnlDashboardHeader;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudYear;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblYear;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudMonth;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMonth;
    }
}