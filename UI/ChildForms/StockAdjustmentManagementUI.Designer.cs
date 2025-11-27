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
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlActions = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlFilters = new Guna.UI2.WinForms.Guna2Panel();

            this.lblTitle = new Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDateRange = new Label();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblTo = new Label();
            this.dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cboTypeFilter = new Guna.UI2.WinForms.Guna2ComboBox();

            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();

            this.dgvAdjustments = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colAdjustmentID = new DataGridViewTextBoxColumn();
            this.colMaPhieu = new DataGridViewTextBoxColumn();
            this.colNgayDieuChinh = new DataGridViewTextBoxColumn();
            this.colProductName = new DataGridViewTextBoxColumn();
            this.colLoaiPhieu = new DataGridViewTextBoxColumn();
            this.colSoLuong = new DataGridViewTextBoxColumn();
            this.colUserName = new DataGridViewTextBoxColumn();
            this.colLyDo = new DataGridViewTextBoxColumn();
            this.colActions = new DataGridViewButtonColumn();

            this.lblTotalAdjustments = new Label();

            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdjustments)).BeginInit();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.Controls.Add(this.txtSearch);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.FillColor = Color.Transparent;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new Padding(20, 15, 20, 15);
            this.pnlHeader.Size = new Size(1050, 80);

            // lblTitle
            this.lblTitle.Dock = DockStyle.Left;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(350, 50);
            this.lblTitle.Text = "🔧 Quản lý Điều chỉnh kho";
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            // txtSearch
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Location = new Point(380, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "🔍 Tìm kiếm theo mã phiếu, sản phẩm, lý do...";
            this.txtSearch.Size = new Size(650, 40);
            this.txtSearch.TextChanged += new EventHandler(this.TxtSearch_TextChanged);

            // pnlFilters
            this.pnlFilters.Controls.Add(this.cboTypeFilter);
            this.pnlFilters.Controls.Add(this.dtpEndDate);
            this.pnlFilters.Controls.Add(this.lblTo);
            this.pnlFilters.Controls.Add(this.dtpStartDate);
            this.pnlFilters.Controls.Add(this.lblDateRange);
            this.pnlFilters.Dock = DockStyle.Top;
            this.pnlFilters.Location = new Point(0, 80);
            this.pnlFilters.Padding = new Padding(20, 5, 20, 5);
            this.pnlFilters.Size = new Size(1050, 60);

            // lblDateRange
            this.lblDateRange.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDateRange.Location = new Point(20, 15);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new Size(120, 30);
            this.lblDateRange.Text = "📅 Thời gian:";
            this.lblDateRange.TextAlign = ContentAlignment.MiddleLeft;

            // dtpStartDate
            this.dtpStartDate.BorderRadius = 8;
            this.dtpStartDate.Checked = true;
            this.dtpStartDate.FillColor = Color.White;
            this.dtpStartDate.Font = new Font("Segoe UI", 9F);
            this.dtpStartDate.Format = DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new Point(140, 10);
            this.dtpStartDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new Size(200, 40);
            this.dtpStartDate.TabIndex = 0;
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpStartDate.ValueChanged += new EventHandler(this.DtpStartDate_ValueChanged);

            // lblTo
            this.lblTo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTo.Location = new Point(350, 15);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new Size(40, 30);
            this.lblTo.Text = "đến";
            this.lblTo.TextAlign = ContentAlignment.MiddleCenter;

            // dtpEndDate
            this.dtpEndDate.BorderRadius = 8;
            this.dtpEndDate.Checked = true;
            this.dtpEndDate.FillColor = Color.White;
            this.dtpEndDate.Font = new Font("Segoe UI", 9F);
            this.dtpEndDate.Format = DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new Point(400, 10);
            this.dtpEndDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEndDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new Size(200, 40);
            this.dtpEndDate.TabIndex = 1;
            this.dtpEndDate.Value = DateTime.Now;
            this.dtpEndDate.ValueChanged += new EventHandler(this.DtpEndDate_ValueChanged);

            // cboTypeFilter
            this.cboTypeFilter.BackColor = Color.Transparent;
            this.cboTypeFilter.BorderRadius = 8;
            this.cboTypeFilter.DrawMode = DrawMode.OwnerDrawFixed;
            this.cboTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTypeFilter.Font = new Font("Segoe UI", 9F);
            this.cboTypeFilter.Items.AddRange(new object[] { "Tất cả", "Nhập thừa", "Xuất hủy" });
            this.cboTypeFilter.Location = new Point(620, 10);
            this.cboTypeFilter.Name = "cboTypeFilter";
            this.cboTypeFilter.Size = new Size(200, 40);
            this.cboTypeFilter.StartIndex = 0;
            this.cboTypeFilter.SelectedIndexChanged += new EventHandler(this.CboTypeFilter_SelectedIndexChanged);

            // pnlActions
            this.pnlActions.Controls.Add(this.btnExport);
            this.pnlActions.Controls.Add(this.btnRefresh);
            this.pnlActions.Controls.Add(this.btnAdd);
            this.pnlActions.Dock = DockStyle.Top;
            this.pnlActions.Location = new Point(0, 140);
            this.pnlActions.Padding = new Padding(20, 10, 20, 10);
            this.pnlActions.Size = new Size(1050, 70);

            // btnAdd
            this.btnAdd.BorderRadius = 8;
            this.btnAdd.FillColor = Color.FromArgb(220, 53, 69);
            this.btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.Location = new Point(20, 15);
            this.btnAdd.Size = new Size(180, 40);
            this.btnAdd.Text = "➕ Tạo phiếu điều chỉnh";
            this.btnAdd.Click += new EventHandler(this.BtnAdd_Click);

            // btnRefresh
            this.btnRefresh.BorderRadius = 8;
            this.btnRefresh.FillColor = Color.FromArgb(100, 120, 140);
            this.btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Location = new Point(210, 15);
            this.btnRefresh.Size = new Size(150, 40);
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.Click += new EventHandler(this.BtnRefresh_Click);

            // btnExport
            this.btnExport.BorderRadius = 8;
            this.btnExport.FillColor = Color.FromArgb(76, 175, 80);
            this.btnExport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnExport.ForeColor = Color.White;
            this.btnExport.Location = new Point(370, 15);
            this.btnExport.Size = new Size(150, 40);
            this.btnExport.Text = "📊 Xuất Excel";
            this.btnExport.Click += new EventHandler(this.BtnExport_Click);

            // dgvAdjustments
            this.dgvAdjustments.AllowUserToAddRows = false;
            this.dgvAdjustments.AllowUserToDeleteRows = false;
            this.dgvAdjustments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAdjustments.ColumnHeadersHeight = 40;
            this.dgvAdjustments.Columns.AddRange(new DataGridViewColumn[] {
                this.colAdjustmentID, this.colMaPhieu, this.colNgayDieuChinh,
                this.colProductName, this.colLoaiPhieu, this.colSoLuong,
                this.colUserName, this.colLyDo, this.colActions
            });
            this.dgvAdjustments.Dock = DockStyle.Fill;
            this.dgvAdjustments.Location = new Point(20, 20);
            this.dgvAdjustments.RowTemplate.Height = 45;
            this.dgvAdjustments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdjustments.CellContentClick += new DataGridViewCellEventHandler(this.DgvAdjustments_CellContentClick);
            this.dgvAdjustments.CellDoubleClick += new DataGridViewCellEventHandler(this.DgvAdjustments_CellDoubleClick);

            // Columns
            this.colAdjustmentID.HeaderText = "ID";
            this.colAdjustmentID.Name = "colAdjustmentID";
            this.colAdjustmentID.FillWeight = 50F;
            this.colAdjustmentID.ReadOnly = true;
            this.colAdjustmentID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.colMaPhieu.HeaderText = "Mã phiếu";
            this.colMaPhieu.Name = "colMaPhieu";
            this.colMaPhieu.FillWeight = 90F;
            this.colMaPhieu.ReadOnly = true;

            this.colNgayDieuChinh.HeaderText = "Ngày điều chỉnh";
            this.colNgayDieuChinh.Name = "colNgayDieuChinh";
            this.colNgayDieuChinh.FillWeight = 120F;
            this.colNgayDieuChinh.ReadOnly = true;

            this.colProductName.HeaderText = "Sản phẩm";
            this.colProductName.Name = "colProductName";
            this.colProductName.FillWeight = 120F;
            this.colProductName.ReadOnly = true;

            this.colLoaiPhieu.HeaderText = "Loại phiếu";
            this.colLoaiPhieu.Name = "colLoaiPhieu";
            this.colLoaiPhieu.FillWeight = 90F;
            this.colLoaiPhieu.ReadOnly = true;
            this.colLoaiPhieu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.colSoLuong.HeaderText = "Số lượng (kg)";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.FillWeight = 100F;
            this.colSoLuong.ReadOnly = true;
            this.colSoLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.colUserName.HeaderText = "Người thực hiện";
            this.colUserName.Name = "colUserName";
            this.colUserName.FillWeight = 100F;
            this.colUserName.ReadOnly = true;

            this.colLyDo.HeaderText = "Lý do";
            this.colLyDo.Name = "colLyDo";
            this.colLyDo.FillWeight = 150F;
            this.colLyDo.ReadOnly = true;

            this.colActions.HeaderText = "Thao tác";
            this.colActions.Name = "colActions";
            this.colActions.FillWeight = 80F;
            this.colActions.ReadOnly = true;
            this.colActions.Text = "⚙️ Hành động";
            this.colActions.UseColumnTextForButtonValue = true;

            // pnlContent
            this.pnlContent.Controls.Add(this.dgvAdjustments);
            this.pnlContent.Dock = DockStyle.Fill;
            this.pnlContent.Location = new Point(0, 210);
            this.pnlContent.Padding = new Padding(20);
            this.pnlContent.Size = new Size(1050, 366);

            // pnlFooter
            this.pnlFooter.Controls.Add(this.lblTotalAdjustments);
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Location = new Point(0, 576);
            this.pnlFooter.Padding = new Padding(20, 5, 20, 5);
            this.pnlFooter.Size = new Size(1050, 50);

            // lblTotalAdjustments
            this.lblTotalAdjustments.Dock = DockStyle.Left;
            this.lblTotalAdjustments.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTotalAdjustments.Location = new Point(20, 5);
            this.lblTotalAdjustments.Size = new Size(200, 40);
            this.lblTotalAdjustments.Text = "Tổng: 0 phiếu";
            this.lblTotalAdjustments.TextAlign = ContentAlignment.MiddleLeft;

            // Form
            this.ClientSize = new Size(1050, 626);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "StockAdjustmentManagementUI";
            this.Text = "Quản lý Điều chỉnh kho";

            this.pnlHeader.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdjustments)).EndInit();
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