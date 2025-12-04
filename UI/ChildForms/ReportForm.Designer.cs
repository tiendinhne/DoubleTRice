namespace DoubleTRice.UI.ChildForms
{
    partial class ReportForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabControl = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblTotalProfit = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTotalRevenue = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnViewRevenueReport = new Guna.UI2.WinForms.Guna2Button();
            this.dgvRevenueReport = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblEnddate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblStartDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvInventoryReport = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnViewInventoryReport = new Guna.UI2.WinForms.Guna2Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnViewCustomerDebtReport = new Guna.UI2.WinForms.Guna2Button();
            this.dgvCustomerDebt = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvSupplierDebt = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnViewSupplierDebtReport = new Guna.UI2.WinForms.Guna2Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.lblDashboardInvoices = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDashboardLowStock = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDashboardSupplierDebt = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDashboardCustomerDebt = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDashboardProfit = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDashboardRevenue = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnViewDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.nudYear = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.nudMonth = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenueReport)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryReport)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerDebt)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplierDebt)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonth)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Controls.Add(this.tabPage3);
            this.TabControl.Controls.Add(this.tabPage4);
            this.TabControl.Controls.Add(this.tabPage5);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.ItemSize = new System.Drawing.Size(180, 40);
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(828, 376);
            this.TabControl.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.TabControl.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.TabControl.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.TabControl.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.TabControl.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.TabControl.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.TabControl.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.TabControl.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.TabControl.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.TabControl.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.TabControl.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.TabControl.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.TabControl.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.TabControl.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.TabControl.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.TabControl.TabButtonSize = new System.Drawing.Size(180, 40);
            this.TabControl.TabIndex = 0;
            this.TabControl.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblTotalProfit);
            this.tabPage1.Controls.Add(this.lblTotalRevenue);
            this.tabPage1.Controls.Add(this.btnViewRevenueReport);
            this.tabPage1.Controls.Add(this.dgvRevenueReport);
            this.tabPage1.Controls.Add(this.dtpEndDate);
            this.tabPage1.Controls.Add(this.lblEnddate);
            this.tabPage1.Controls.Add(this.lblStartDate);
            this.tabPage1.Controls.Add(this.dtpStartDate);
            this.tabPage1.Location = new System.Drawing.Point(184, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(640, 368);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblTotalProfit
            // 
            this.lblTotalProfit.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalProfit.Location = new System.Drawing.Point(206, 85);
            this.lblTotalProfit.Name = "lblTotalProfit";
            this.lblTotalProfit.Size = new System.Drawing.Size(91, 18);
            this.lblTotalProfit.TabIndex = 7;
            this.lblTotalProfit.Text = "Tổng lợi nhuận";
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRevenue.Location = new System.Drawing.Point(14, 85);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(96, 18);
            this.lblTotalRevenue.TabIndex = 6;
            this.lblTotalRevenue.Text = "Tổng doanh thu";
            // 
            // btnViewRevenueReport
            // 
            this.btnViewRevenueReport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewRevenueReport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewRevenueReport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewRevenueReport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewRevenueReport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnViewRevenueReport.ForeColor = System.Drawing.Color.White;
            this.btnViewRevenueReport.Location = new System.Drawing.Point(522, 72);
            this.btnViewRevenueReport.Name = "btnViewRevenueReport";
            this.btnViewRevenueReport.Size = new System.Drawing.Size(110, 31);
            this.btnViewRevenueReport.TabIndex = 5;
            this.btnViewRevenueReport.Text = "Xem ";
            // 
            // dgvRevenueReport
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvRevenueReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRevenueReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRevenueReport.ColumnHeadersHeight = 4;
            this.dgvRevenueReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(237)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRevenueReport.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRevenueReport.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRevenueReport.Location = new System.Drawing.Point(6, 122);
            this.dgvRevenueReport.Name = "dgvRevenueReport";
            this.dgvRevenueReport.RowHeadersVisible = false;
            this.dgvRevenueReport.RowHeadersWidth = 51;
            this.dgvRevenueReport.RowTemplate.Height = 24;
            this.dgvRevenueReport.Size = new System.Drawing.Size(626, 227);
            this.dgvRevenueReport.TabIndex = 4;
            this.dgvRevenueReport.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRevenueReport.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvRevenueReport.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvRevenueReport.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvRevenueReport.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvRevenueReport.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvRevenueReport.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRevenueReport.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvRevenueReport.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRevenueReport.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRevenueReport.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRevenueReport.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvRevenueReport.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvRevenueReport.ThemeStyle.ReadOnly = false;
            this.dgvRevenueReport.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRevenueReport.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRevenueReport.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRevenueReport.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvRevenueReport.ThemeStyle.RowsStyle.Height = 24;
            this.dgvRevenueReport.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRevenueReport.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Checked = true;
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpEndDate.Location = new System.Drawing.Point(301, 37);
            this.dtpEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(264, 29);
            this.dtpEndDate.TabIndex = 3;
            this.dtpEndDate.Value = new System.DateTime(2025, 12, 3, 13, 19, 17, 48);
            // 
            // lblEnddate
            // 
            this.lblEnddate.BackColor = System.Drawing.Color.Transparent;
            this.lblEnddate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnddate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEnddate.Location = new System.Drawing.Point(301, 9);
            this.lblEnddate.Name = "lblEnddate";
            this.lblEnddate.Size = new System.Drawing.Size(101, 22);
            this.lblEnddate.TabIndex = 2;
            this.lblEnddate.Text = "Ngày kết thúc";
            // 
            // lblStartDate
            // 
            this.lblStartDate.BackColor = System.Drawing.Color.Transparent;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.Location = new System.Drawing.Point(14, 9);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(97, 22);
            this.lblStartDate.TabIndex = 1;
            this.lblStartDate.Text = "Ngày bắt đầu";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Checked = true;
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpStartDate.Location = new System.Drawing.Point(14, 37);
            this.dtpStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(264, 29);
            this.dtpStartDate.TabIndex = 0;
            this.dtpStartDate.Value = new System.DateTime(2025, 12, 3, 13, 19, 17, 48);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvInventoryReport);
            this.tabPage2.Controls.Add(this.btnViewInventoryReport);
            this.tabPage2.Location = new System.Drawing.Point(184, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(640, 368);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvInventoryReport
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvInventoryReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventoryReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvInventoryReport.ColumnHeadersHeight = 4;
            this.dgvInventoryReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(237)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInventoryReport.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvInventoryReport.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvInventoryReport.Location = new System.Drawing.Point(6, 52);
            this.dgvInventoryReport.Name = "dgvInventoryReport";
            this.dgvInventoryReport.RowHeadersVisible = false;
            this.dgvInventoryReport.RowHeadersWidth = 51;
            this.dgvInventoryReport.RowTemplate.Height = 24;
            this.dgvInventoryReport.Size = new System.Drawing.Size(590, 284);
            this.dgvInventoryReport.TabIndex = 13;
            this.dgvInventoryReport.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvInventoryReport.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvInventoryReport.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvInventoryReport.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvInventoryReport.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvInventoryReport.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvInventoryReport.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvInventoryReport.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvInventoryReport.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInventoryReport.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvInventoryReport.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvInventoryReport.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvInventoryReport.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvInventoryReport.ThemeStyle.ReadOnly = false;
            this.dgvInventoryReport.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvInventoryReport.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvInventoryReport.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvInventoryReport.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvInventoryReport.ThemeStyle.RowsStyle.Height = 24;
            this.dgvInventoryReport.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvInventoryReport.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnViewInventoryReport
            // 
            this.btnViewInventoryReport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewInventoryReport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewInventoryReport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewInventoryReport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewInventoryReport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnViewInventoryReport.ForeColor = System.Drawing.Color.White;
            this.btnViewInventoryReport.Location = new System.Drawing.Point(428, 6);
            this.btnViewInventoryReport.Name = "btnViewInventoryReport";
            this.btnViewInventoryReport.Size = new System.Drawing.Size(168, 40);
            this.btnViewInventoryReport.TabIndex = 12;
            this.btnViewInventoryReport.Text = "Xem ";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnViewCustomerDebtReport);
            this.tabPage3.Controls.Add(this.dgvCustomerDebt);
            this.tabPage3.Location = new System.Drawing.Point(184, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(640, 368);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnViewCustomerDebtReport
            // 
            this.btnViewCustomerDebtReport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewCustomerDebtReport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewCustomerDebtReport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewCustomerDebtReport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewCustomerDebtReport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnViewCustomerDebtReport.ForeColor = System.Drawing.Color.White;
            this.btnViewCustomerDebtReport.Location = new System.Drawing.Point(409, 6);
            this.btnViewCustomerDebtReport.Name = "btnViewCustomerDebtReport";
            this.btnViewCustomerDebtReport.Size = new System.Drawing.Size(180, 45);
            this.btnViewCustomerDebtReport.TabIndex = 1;
            this.btnViewCustomerDebtReport.Text = "Xem";
            // 
            // dgvCustomerDebt
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvCustomerDebt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomerDebt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCustomerDebt.ColumnHeadersHeight = 4;
            this.dgvCustomerDebt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(237)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomerDebt.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvCustomerDebt.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCustomerDebt.Location = new System.Drawing.Point(6, 71);
            this.dgvCustomerDebt.Name = "dgvCustomerDebt";
            this.dgvCustomerDebt.RowHeadersVisible = false;
            this.dgvCustomerDebt.RowHeadersWidth = 51;
            this.dgvCustomerDebt.RowTemplate.Height = 24;
            this.dgvCustomerDebt.Size = new System.Drawing.Size(599, 281);
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
            this.dgvCustomerDebt.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCustomerDebt.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCustomerDebt.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCustomerDebt.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvCustomerDebt.ThemeStyle.ReadOnly = false;
            this.dgvCustomerDebt.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCustomerDebt.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCustomerDebt.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCustomerDebt.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCustomerDebt.ThemeStyle.RowsStyle.Height = 24;
            this.dgvCustomerDebt.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCustomerDebt.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvSupplierDebt);
            this.tabPage4.Controls.Add(this.btnViewSupplierDebtReport);
            this.tabPage4.Location = new System.Drawing.Point(184, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(640, 368);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvSupplierDebt
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgvSupplierDebt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSupplierDebt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvSupplierDebt.ColumnHeadersHeight = 4;
            this.dgvSupplierDebt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSupplierDebt.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvSupplierDebt.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSupplierDebt.Location = new System.Drawing.Point(6, 70);
            this.dgvSupplierDebt.Name = "dgvSupplierDebt";
            this.dgvSupplierDebt.RowHeadersVisible = false;
            this.dgvSupplierDebt.RowHeadersWidth = 51;
            this.dgvSupplierDebt.RowTemplate.Height = 24;
            this.dgvSupplierDebt.Size = new System.Drawing.Size(592, 282);
            this.dgvSupplierDebt.TabIndex = 1;
            this.dgvSupplierDebt.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSupplierDebt.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvSupplierDebt.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvSupplierDebt.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvSupplierDebt.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvSupplierDebt.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvSupplierDebt.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSupplierDebt.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvSupplierDebt.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSupplierDebt.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSupplierDebt.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSupplierDebt.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvSupplierDebt.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvSupplierDebt.ThemeStyle.ReadOnly = false;
            this.dgvSupplierDebt.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSupplierDebt.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSupplierDebt.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSupplierDebt.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSupplierDebt.ThemeStyle.RowsStyle.Height = 24;
            this.dgvSupplierDebt.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSupplierDebt.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnViewSupplierDebtReport
            // 
            this.btnViewSupplierDebtReport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewSupplierDebtReport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewSupplierDebtReport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewSupplierDebtReport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewSupplierDebtReport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnViewSupplierDebtReport.ForeColor = System.Drawing.Color.White;
            this.btnViewSupplierDebtReport.Location = new System.Drawing.Point(409, 6);
            this.btnViewSupplierDebtReport.Name = "btnViewSupplierDebtReport";
            this.btnViewSupplierDebtReport.Size = new System.Drawing.Size(180, 45);
            this.btnViewSupplierDebtReport.TabIndex = 0;
            this.btnViewSupplierDebtReport.Text = "Xem";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.lblDashboardInvoices);
            this.tabPage5.Controls.Add(this.lblDashboardLowStock);
            this.tabPage5.Controls.Add(this.lblDashboardSupplierDebt);
            this.tabPage5.Controls.Add(this.lblDashboardCustomerDebt);
            this.tabPage5.Controls.Add(this.lblDashboardProfit);
            this.tabPage5.Controls.Add(this.lblDashboardRevenue);
            this.tabPage5.Controls.Add(this.btnViewDashboard);
            this.tabPage5.Controls.Add(this.nudYear);
            this.tabPage5.Controls.Add(this.nudMonth);
            this.tabPage5.Location = new System.Drawing.Point(184, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(640, 368);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // lblDashboardInvoices
            // 
            this.lblDashboardInvoices.BackColor = System.Drawing.Color.Transparent;
            this.lblDashboardInvoices.Location = new System.Drawing.Point(317, 202);
            this.lblDashboardInvoices.Name = "lblDashboardInvoices";
            this.lblDashboardInvoices.Size = new System.Drawing.Size(55, 18);
            this.lblDashboardInvoices.TabIndex = 8;
            this.lblDashboardInvoices.Text = "Hóa đơn";
            this.lblDashboardInvoices.Click += new System.EventHandler(this.lblDashboardInvoices_Click);
            // 
            // lblDashboardLowStock
            // 
            this.lblDashboardLowStock.BackColor = System.Drawing.Color.Transparent;
            this.lblDashboardLowStock.Location = new System.Drawing.Point(13, 202);
            this.lblDashboardLowStock.Name = "lblDashboardLowStock";
            this.lblDashboardLowStock.Size = new System.Drawing.Size(66, 18);
            this.lblDashboardLowStock.TabIndex = 7;
            this.lblDashboardLowStock.Text = "Hàng tồn ít";
            // 
            // lblDashboardSupplierDebt
            // 
            this.lblDashboardSupplierDebt.BackColor = System.Drawing.Color.Transparent;
            this.lblDashboardSupplierDebt.Location = new System.Drawing.Point(16, 314);
            this.lblDashboardSupplierDebt.Name = "lblDashboardSupplierDebt";
            this.lblDashboardSupplierDebt.Size = new System.Drawing.Size(53, 18);
            this.lblDashboardSupplierDebt.TabIndex = 6;
            this.lblDashboardSupplierDebt.Text = "CN NCC";
            // 
            // lblDashboardCustomerDebt
            // 
            this.lblDashboardCustomerDebt.BackColor = System.Drawing.Color.Transparent;
            this.lblDashboardCustomerDebt.Location = new System.Drawing.Point(317, 314);
            this.lblDashboardCustomerDebt.Name = "lblDashboardCustomerDebt";
            this.lblDashboardCustomerDebt.Size = new System.Drawing.Size(62, 18);
            this.lblDashboardCustomerDebt.TabIndex = 5;
            this.lblDashboardCustomerDebt.Text = "CN Khách";
            // 
            // lblDashboardProfit
            // 
            this.lblDashboardProfit.BackColor = System.Drawing.Color.Transparent;
            this.lblDashboardProfit.Location = new System.Drawing.Point(317, 105);
            this.lblDashboardProfit.Name = "lblDashboardProfit";
            this.lblDashboardProfit.Size = new System.Drawing.Size(60, 18);
            this.lblDashboardProfit.TabIndex = 4;
            this.lblDashboardProfit.Text = "Lợi nhuận";
            // 
            // lblDashboardRevenue
            // 
            this.lblDashboardRevenue.BackColor = System.Drawing.Color.Transparent;
            this.lblDashboardRevenue.Location = new System.Drawing.Point(16, 105);
            this.lblDashboardRevenue.Name = "lblDashboardRevenue";
            this.lblDashboardRevenue.Size = new System.Drawing.Size(63, 18);
            this.lblDashboardRevenue.TabIndex = 3;
            this.lblDashboardRevenue.Text = "Doanh thu";
            // 
            // btnViewDashboard
            // 
            this.btnViewDashboard.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewDashboard.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewDashboard.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewDashboard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewDashboard.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnViewDashboard.ForeColor = System.Drawing.Color.White;
            this.btnViewDashboard.Location = new System.Drawing.Point(409, 21);
            this.btnViewDashboard.Name = "btnViewDashboard";
            this.btnViewDashboard.Size = new System.Drawing.Size(180, 45);
            this.btnViewDashboard.TabIndex = 2;
            this.btnViewDashboard.Text = "Xem";
            // 
            // nudYear
            // 
            this.nudYear.BackColor = System.Drawing.Color.Transparent;
            this.nudYear.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudYear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudYear.Location = new System.Drawing.Point(240, 21);
            this.nudYear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudYear.Name = "nudYear";
            this.nudYear.Size = new System.Drawing.Size(114, 48);
            this.nudYear.TabIndex = 1;
            // 
            // nudMonth
            // 
            this.nudMonth.BackColor = System.Drawing.Color.Transparent;
            this.nudMonth.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudMonth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudMonth.Location = new System.Drawing.Point(59, 21);
            this.nudMonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudMonth.Name = "nudMonth";
            this.nudMonth.Size = new System.Drawing.Size(114, 48);
            this.nudMonth.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(341, 50);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "📦 Báo cáo thống kê";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // btnExport
            // 
            this.btnExport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(636, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(180, 45);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Xuất file";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click_1);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnExport);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(828, 69);
            this.pnlHeader.TabIndex = 4;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.TabControl);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 69);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(828, 376);
            this.pnlContent.TabIndex = 5;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(828, 445);
            this.ControlBox = false;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ReportForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenueReport)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryReport)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerDebt)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplierDebt)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonth)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStartDate;
        private System.Windows.Forms.TabPage tabPage5;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEndDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEnddate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStartDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalProfit;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalRevenue;
        private Guna.UI2.WinForms.Guna2Button btnViewRevenueReport;
        private Guna.UI2.WinForms.Guna2DataGridView dgvRevenueReport;
        private Guna.UI2.WinForms.Guna2DataGridView dgvInventoryReport;
        private Guna.UI2.WinForms.Guna2Button btnViewInventoryReport;
        private Guna.UI2.WinForms.Guna2Button btnViewCustomerDebtReport;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCustomerDebt;
        private Guna.UI2.WinForms.Guna2Button btnViewSupplierDebtReport;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSupplierDebt;
        private Guna.UI2.WinForms.Guna2Button btnViewDashboard;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudYear;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudMonth;
        private Guna.UI2.WinForms.Guna2Button btnExport;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDashboardLowStock;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDashboardSupplierDebt;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDashboardCustomerDebt;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDashboardProfit;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDashboardRevenue;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDashboardInvoices;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlContent;
    }
}