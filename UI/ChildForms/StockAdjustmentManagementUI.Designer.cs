using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    partial class StockAdjustmentManagementUI
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvAdjustments = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colAdjustmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayDieuChinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLyDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActions = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlActions = new Guna.UI2.WinForms.Guna2Panel();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.pnlFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalAdjustments = new System.Windows.Forms.Label();
            this.pnlFilters = new Guna.UI2.WinForms.Guna2Panel();
            this.cboTypeFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdjustments)).BeginInit();
            this.pnlActions.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.txtSearch);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.FillColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.pnlHeader.Size = new System.Drawing.Size(1050, 80);
            this.pnlHeader.TabIndex = 4;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(660, 20);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "🔍 Tìm kiếm theo mã phiếu, sản phẩm, lý do...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(370, 40);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(477, 50);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "🔧 Quản lý Điều chỉnh kho";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvAdjustments);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 210);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(1050, 366);
            this.pnlContent.TabIndex = 0;
            // 
            // dgvAdjustments
            // 
            this.dgvAdjustments.AllowUserToAddRows = false;
            this.dgvAdjustments.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvAdjustments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAdjustments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAdjustments.ColumnHeadersHeight = 40;
            this.dgvAdjustments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAdjustmentID,
            this.colMaPhieu,
            this.colNgayDieuChinh,
            this.colProductName,
            this.colLoaiPhieu,
            this.colSoLuong,
            this.colUserName,
            this.colLyDo,
            this.colActions});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAdjustments.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAdjustments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAdjustments.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvAdjustments.Location = new System.Drawing.Point(20, 20);
            this.dgvAdjustments.Name = "dgvAdjustments";
            this.dgvAdjustments.RowHeadersVisible = false;
            this.dgvAdjustments.RowHeadersWidth = 62;
            this.dgvAdjustments.RowTemplate.Height = 45;
            this.dgvAdjustments.Size = new System.Drawing.Size(1010, 326);
            this.dgvAdjustments.TabIndex = 0;
            this.dgvAdjustments.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvAdjustments.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvAdjustments.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvAdjustments.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvAdjustments.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvAdjustments.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvAdjustments.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvAdjustments.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvAdjustments.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAdjustments.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAdjustments.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvAdjustments.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAdjustments.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvAdjustments.ThemeStyle.ReadOnly = false;
            this.dgvAdjustments.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvAdjustments.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAdjustments.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAdjustments.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvAdjustments.ThemeStyle.RowsStyle.Height = 45;
            this.dgvAdjustments.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvAdjustments.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvAdjustments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAdjustments_CellContentClick);
            this.dgvAdjustments.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAdjustments_CellDoubleClick);
            // 
            // colAdjustmentID
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colAdjustmentID.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAdjustmentID.FillWeight = 50F;
            this.colAdjustmentID.HeaderText = "ID";
            this.colAdjustmentID.MinimumWidth = 8;
            this.colAdjustmentID.Name = "colAdjustmentID";
            this.colAdjustmentID.ReadOnly = true;
            // 
            // colMaPhieu
            // 
            this.colMaPhieu.FillWeight = 90F;
            this.colMaPhieu.HeaderText = "Mã phiếu";
            this.colMaPhieu.MinimumWidth = 8;
            this.colMaPhieu.Name = "colMaPhieu";
            this.colMaPhieu.ReadOnly = true;
            // 
            // colNgayDieuChinh
            // 
            this.colNgayDieuChinh.FillWeight = 120F;
            this.colNgayDieuChinh.HeaderText = "Ngày điều chỉnh";
            this.colNgayDieuChinh.MinimumWidth = 8;
            this.colNgayDieuChinh.Name = "colNgayDieuChinh";
            this.colNgayDieuChinh.ReadOnly = true;
            // 
            // colProductName
            // 
            this.colProductName.FillWeight = 120F;
            this.colProductName.HeaderText = "Sản phẩm";
            this.colProductName.MinimumWidth = 8;
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            // 
            // colLoaiPhieu
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colLoaiPhieu.DefaultCellStyle = dataGridViewCellStyle4;
            this.colLoaiPhieu.FillWeight = 90F;
            this.colLoaiPhieu.HeaderText = "Loại phiếu";
            this.colLoaiPhieu.MinimumWidth = 8;
            this.colLoaiPhieu.Name = "colLoaiPhieu";
            this.colLoaiPhieu.ReadOnly = true;
            // 
            // colSoLuong
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colSoLuong.DefaultCellStyle = dataGridViewCellStyle5;
            this.colSoLuong.HeaderText = "Số lượng (kg)";
            this.colSoLuong.MinimumWidth = 8;
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            // 
            // colUserName
            // 
            this.colUserName.HeaderText = "Người thực hiện";
            this.colUserName.MinimumWidth = 8;
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            // 
            // colLyDo
            // 
            this.colLyDo.FillWeight = 150F;
            this.colLyDo.HeaderText = "Lý do";
            this.colLyDo.MinimumWidth = 8;
            this.colLyDo.Name = "colLyDo";
            this.colLyDo.ReadOnly = true;
            // 
            // colActions
            // 
            this.colActions.FillWeight = 80F;
            this.colActions.HeaderText = "Thao tác";
            this.colActions.MinimumWidth = 8;
            this.colActions.Name = "colActions";
            this.colActions.ReadOnly = true;
            this.colActions.Text = "⚙️ Hành động";
            this.colActions.UseColumnTextForButtonValue = true;
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnExport);
            this.pnlActions.Controls.Add(this.btnRefresh);
            this.pnlActions.Controls.Add(this.btnAdd);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActions.Location = new System.Drawing.Point(0, 140);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlActions.Size = new System.Drawing.Size(1050, 70);
            this.pnlActions.TabIndex = 2;
            // 
            // btnExport
            // 
            this.btnExport.BorderRadius = 8;
            this.btnExport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(370, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 40);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "📊 Xuất Excel";
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BorderRadius = 8;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(140)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(210, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 40);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BorderRadius = 8;
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(20, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(180, 40);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "➕ Tạo phiếu điều chỉnh";
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.lblTotalAdjustments);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 576);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.pnlFooter.Size = new System.Drawing.Size(1050, 50);
            this.pnlFooter.TabIndex = 1;
            // 
            // lblTotalAdjustments
            // 
            this.lblTotalAdjustments.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTotalAdjustments.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalAdjustments.Location = new System.Drawing.Point(20, 5);
            this.lblTotalAdjustments.Name = "lblTotalAdjustments";
            this.lblTotalAdjustments.Size = new System.Drawing.Size(200, 40);
            this.lblTotalAdjustments.TabIndex = 0;
            this.lblTotalAdjustments.Text = "Tổng: 0 phiếu";
            this.lblTotalAdjustments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.cboTypeFilter);
            this.pnlFilters.Controls.Add(this.dtpEndDate);
            this.pnlFilters.Controls.Add(this.lblTo);
            this.pnlFilters.Controls.Add(this.dtpStartDate);
            this.pnlFilters.Controls.Add(this.lblDateRange);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 80);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Padding = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.pnlFilters.Size = new System.Drawing.Size(1050, 60);
            this.pnlFilters.TabIndex = 3;
            // 
            // cboTypeFilter
            // 
            this.cboTypeFilter.AutoRoundedCorners = true;
            this.cboTypeFilter.BackColor = System.Drawing.Color.Transparent;
            this.cboTypeFilter.BorderRadius = 17;
            this.cboTypeFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeFilter.FocusedColor = System.Drawing.Color.Empty;
            this.cboTypeFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboTypeFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboTypeFilter.ItemHeight = 30;
            this.cboTypeFilter.Items.AddRange(new object[] {
            "Tất cả",
            "Nhập thừa",
            "Xuất hủy"});
            this.cboTypeFilter.Location = new System.Drawing.Point(674, 12);
            this.cboTypeFilter.Name = "cboTypeFilter";
            this.cboTypeFilter.Size = new System.Drawing.Size(200, 36);
            this.cboTypeFilter.StartIndex = 0;
            this.cboTypeFilter.TabIndex = 0;
            this.cboTypeFilter.SelectedIndexChanged += new System.EventHandler(this.CboTypeFilter_SelectedIndexChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.BorderRadius = 8;
            this.dtpEndDate.Checked = true;
            this.dtpEndDate.FillColor = System.Drawing.Color.White;
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(433, 8);
            this.dtpEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 40);
            this.dtpEndDate.TabIndex = 1;
            this.dtpEndDate.Value = new System.DateTime(2025, 11, 28, 10, 58, 34, 358);
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.DtpEndDate_ValueChanged);
            // 
            // lblTo
            // 
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTo.Location = new System.Drawing.Point(372, 15);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(68, 30);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "đến";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.BorderRadius = 8;
            this.dtpStartDate.Checked = true;
            this.dtpStartDate.FillColor = System.Drawing.Color.White;
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(160, 8);
            this.dtpStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 40);
            this.dtpStartDate.TabIndex = 0;
            this.dtpStartDate.Value = new System.DateTime(2025, 11, 28, 10, 58, 34, 450);
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.DtpStartDate_ValueChanged);
            // 
            // lblDateRange
            // 
            this.lblDateRange.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDateRange.Location = new System.Drawing.Point(20, 15);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(145, 30);
            this.lblDateRange.TabIndex = 3;
            this.lblDateRange.Text = "📅 Thời gian:";
            this.lblDateRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StockAdjustmentManagementUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.ClientSize = new System.Drawing.Size(1050, 626);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlHeader);
            this.Name = "StockAdjustmentManagementUI";
            this.Text = "Quản lý Điều chỉnh kho";
            this.pnlHeader.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdjustments)).EndInit();
            this.pnlActions.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlContent;
        private Guna.UI2.WinForms.Guna2Panel pnlActions;
        private Guna.UI2.WinForms.Guna2Panel pnlFooter;
        private Guna.UI2.WinForms.Guna2Panel pnlFilters;
        private Label lblTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Label lblDateRange;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStartDate;
        private Label lblTo;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEndDate;
        private Guna.UI2.WinForms.Guna2ComboBox cboTypeFilter;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Button btnExport;
        private Guna.UI2.WinForms.Guna2DataGridView dgvAdjustments;
        private DataGridViewTextBoxColumn colAdjustmentID;
        private DataGridViewTextBoxColumn colMaPhieu;
        private DataGridViewTextBoxColumn colNgayDieuChinh;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colLoaiPhieu;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colUserName;
        private DataGridViewTextBoxColumn colLyDo;
        private DataGridViewButtonColumn colActions;
        private Label lblTotalAdjustments;
    }
}