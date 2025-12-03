using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    partial class DebtManagementUI
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

        #region Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();

            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTitle = new Label();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvDebts = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colCustomerID = new DataGridViewTextBoxColumn();
            this.colTenKhachHang = new DataGridViewTextBoxColumn();
            this.colSoDienThoai = new DataGridViewTextBoxColumn();
            this.colTongMuaHang = new DataGridViewTextBoxColumn();
            this.colTongDaTra = new DataGridViewTextBoxColumn();
            this.colCongNo = new DataGridViewTextBoxColumn();
            this.colActions = new DataGridViewButtonColumn();
            this.pnlActions = new Guna.UI2.WinForms.Guna2Panel();
            this.btnThanhToan = new Guna.UI2.WinForms.Guna2Button();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.pnlFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStats = new Label();
            this.lblTotalDebts = new Label();

            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebts)).BeginInit();
            this.pnlActions.SuspendLayout();
            this.pnlFooter.SuspendLayout();
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
            this.pnlHeader.TabIndex = 3;

            // txtSearch
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Font = new Font("Segoe UI", 9F);
            this.txtSearch.Location = new Point(467, 20);
            this.txtSearch.Margin = new Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "🔍 Tìm kiếm khách hàng...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new Size(563, 40);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new EventHandler(this.TxtSearch_TextChanged);

            // lblTitle
            this.lblTitle.Dock = DockStyle.Left;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(426, 50);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "💰 Quản lý Sổ Công Nợ";
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            // pnlContent
            this.pnlContent.Controls.Add(this.dgvDebts);
            this.pnlContent.Dock = DockStyle.Fill;
            this.pnlContent.Location = new Point(0, 150);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new Padding(20);
            this.pnlContent.Size = new Size(1050, 376);
            this.pnlContent.TabIndex = 0;

            // dgvDebts
            this.dgvDebts.AllowUserToAddRows = false;
            this.dgvDebts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            this.dgvDebts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(231, 76, 60);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            this.dgvDebts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDebts.ColumnHeadersHeight = 40;
            this.dgvDebts.Columns.AddRange(new DataGridViewColumn[] {
            this.colCustomerID,
            this.colTenKhachHang,
            this.colSoDienThoai,
            this.colTongMuaHang,
            this.colTongDaTra,
            this.colCongNo,
            this.colActions});
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            this.dgvDebts.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDebts.Dock = DockStyle.Fill;
            this.dgvDebts.GridColor = Color.FromArgb(231, 229, 255);
            this.dgvDebts.Location = new Point(20, 20);
            this.dgvDebts.Name = "dgvDebts";
            this.dgvDebts.RowHeadersVisible = false;
            this.dgvDebts.RowHeadersWidth = 62;
            this.dgvDebts.RowTemplate.Height = 45;
            this.dgvDebts.Size = new Size(1010, 336);
            this.dgvDebts.TabIndex = 0;
            this.dgvDebts.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            this.dgvDebts.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDebts.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            this.dgvDebts.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            this.dgvDebts.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            this.dgvDebts.ThemeStyle.BackColor = Color.White;
            this.dgvDebts.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            this.dgvDebts.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(231, 76, 60);
            this.dgvDebts.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvDebts.ThemeStyle.HeaderStyle.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.dgvDebts.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            this.dgvDebts.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDebts.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvDebts.ThemeStyle.ReadOnly = false;
            this.dgvDebts.ThemeStyle.RowsStyle.BackColor = Color.White;
            this.dgvDebts.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDebts.ThemeStyle.RowsStyle.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.dgvDebts.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            this.dgvDebts.ThemeStyle.RowsStyle.Height = 45;
            this.dgvDebts.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            this.dgvDebts.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            this.dgvDebts.CellContentClick += new DataGridViewCellEventHandler(this.DgvDebts_CellContentClick);
            this.dgvDebts.CellDoubleClick += new DataGridViewCellEventHandler(this.DgvDebts_CellDoubleClick);

            // colCustomerID
            this.colCustomerID.FillWeight = 60F;
            this.colCustomerID.HeaderText = "ID";
            this.colCustomerID.Name = "colCustomerID";
            this.colCustomerID.ReadOnly = true;

            // colTenKhachHang
            this.colTenKhachHang.FillWeight = 150F;
            this.colTenKhachHang.HeaderText = "Khách hàng";
            this.colTenKhachHang.Name = "colTenKhachHang";
            this.colTenKhachHang.ReadOnly = true;

            // colSoDienThoai
            this.colSoDienThoai.FillWeight = 110F;
            this.colSoDienThoai.HeaderText = "Số điện thoại";
            this.colSoDienThoai.Name = "colSoDienThoai";
            this.colSoDienThoai.ReadOnly = true;

            // colTongMuaHang
            this.colTongMuaHang.FillWeight = 110F;
            this.colTongMuaHang.HeaderText = "Tổng mua hàng";
            this.colTongMuaHang.Name = "colTongMuaHang";
            this.colTongMuaHang.ReadOnly = true;

            // colTongDaTra
            this.colTongDaTra.FillWeight = 110F;
            this.colTongDaTra.HeaderText = "Đã trả";
            this.colTongDaTra.Name = "colTongDaTra";
            this.colTongDaTra.ReadOnly = true;

            // colCongNo
            this.colCongNo.FillWeight = 120F;
            this.colCongNo.HeaderText = "Công nợ";
            this.colCongNo.Name = "colCongNo";
            this.colCongNo.ReadOnly = true;

            // colActions
            this.colActions.HeaderText = "Thao tác";
            this.colActions.Name = "colActions";
            this.colActions.ReadOnly = true;
            this.colActions.Text = "⚙️ Hành động";
            this.colActions.UseColumnTextForButtonValue = true;

            // pnlActions
            this.pnlActions.Controls.Add(this.btnThanhToan);
            this.pnlActions.Controls.Add(this.btnExport);
            this.pnlActions.Controls.Add(this.btnRefresh);
            this.pnlActions.Dock = DockStyle.Top;
            this.pnlActions.Location = new Point(0, 80);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new Padding(20, 10, 20, 10);
            this.pnlActions.Size = new Size(1050, 70);
            this.pnlActions.TabIndex = 2;

            // btnThanhToan
            this.btnThanhToan.BorderRadius = 8;
            this.btnThanhToan.FillColor = Color.FromArgb(46, 204, 113);
            this.btnThanhToan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnThanhToan.ForeColor = Color.White;
            this.btnThanhToan.Location = new Point(20, 15);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new Size(180, 40);
            this.btnThanhToan.TabIndex = 0;
            this.btnThanhToan.Text = "💰 Thanh toán";
            this.btnThanhToan.Click += new EventHandler(this.BtnThanhToan_Click);

            // btnExport
            this.btnExport.BorderRadius = 8;
            this.btnExport.FillColor = Color.FromArgb(76, 175, 80);
            this.btnExport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnExport.ForeColor = Color.White;
            this.btnExport.Location = new Point(390, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new Size(150, 40);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "📊 Xuất Excel";
            this.btnExport.Click += new EventHandler(this.BtnExport_Click);

            // btnRefresh
            this.btnRefresh.BorderRadius = 8;
            this.btnRefresh.FillColor = Color.FromArgb(100, 120, 140);
            this.btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Location = new Point(220, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(150, 40);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.Click += new EventHandler(this.BtnRefresh_Click);

            // pnlFooter
            this.pnlFooter.Controls.Add(this.lblStats);
            this.pnlFooter.Controls.Add(this.lblTotalDebts);
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Location = new Point(0, 526);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new Padding(20, 5, 20, 5);
            this.pnlFooter.Size = new Size(1050, 100);
            this.pnlFooter.TabIndex = 1;

            // lblTotalDebts
            this.lblTotalDebts.Dock = DockStyle.Top;
            this.lblTotalDebts.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTotalDebts.Location = new Point(20, 5);
            this.lblTotalDebts.Name = "lblTotalDebts";
            this.lblTotalDebts.Size = new Size(1010, 40);
            this.lblTotalDebts.TabIndex = 0;
            this.lblTotalDebts.Text = "Tổng: 0 khách hàng";
            this.lblTotalDebts.TextAlign = ContentAlignment.MiddleLeft;

            // lblStats
            this.lblStats.Dock = DockStyle.Bottom;
            this.lblStats.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblStats.ForeColor = Color.FromArgb(192, 0, 0);
            this.lblStats.Location = new Point(20, 55);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new Size(1010, 40);
            this.lblStats.TabIndex = 1;
            this.lblStats.Text = "Đang tải thống kê...";
            this.lblStats.TextAlign = ContentAlignment.MiddleLeft;

            // DebtManagementUI
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.ClientSize = new Size(1050, 626);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlHeader);
            this.Name = "DebtManagementUI";
            this.Text = "Quản lý Sổ Công Nợ";
            this.pnlHeader.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebts)).EndInit();
            this.pnlActions.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlContent;
        private Guna.UI2.WinForms.Guna2Panel pnlActions;
        private Guna.UI2.WinForms.Guna2Panel pnlFooter;
        private Label lblTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnThanhToan;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Button btnExport;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDebts;
        private DataGridViewTextBoxColumn colCustomerID;
        private DataGridViewTextBoxColumn colTenKhachHang;
        private DataGridViewTextBoxColumn colSoDienThoai;
        private DataGridViewTextBoxColumn colTongMuaHang;
        private DataGridViewTextBoxColumn colTongDaTra;
        private DataGridViewTextBoxColumn colCongNo;
        private DataGridViewButtonColumn colActions;
        private Label lblTotalDebts;
        private Label lblStats;
    }
}