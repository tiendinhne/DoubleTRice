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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvDebts = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colCustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongMuaHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongDaTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCongNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActions = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlActions = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnThanhToan = new Guna.UI2.WinForms.Guna2Button();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.pnlFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStats = new System.Windows.Forms.Label();
            this.lblTotalDebts = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebts)).BeginInit();
            this.pnlActions.SuspendLayout();
            this.pnlFooter.SuspendLayout();
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
            this.pnlHeader.TabIndex = 3;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(581, 20);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "🔍 Tìm kiếm khách hàng...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(449, 40);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(487, 50);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "💰 Quản lý Sổ Công Nợ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvDebts);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 150);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(1050, 376);
            this.pnlContent.TabIndex = 0;
            // 
            // dgvDebts
            // 
            this.dgvDebts.AllowUserToAddRows = false;
            this.dgvDebts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDebts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDebts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDebts.ColumnHeadersHeight = 40;
            this.dgvDebts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCustomerID,
            this.colTenKhachHang,
            this.colSoDienThoai,
            this.colTongMuaHang,
            this.colTongDaTra,
            this.colCongNo,
            this.colActions});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDebts.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDebts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDebts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDebts.Location = new System.Drawing.Point(20, 20);
            this.dgvDebts.Name = "dgvDebts";
            this.dgvDebts.RowHeadersVisible = false;
            this.dgvDebts.RowHeadersWidth = 62;
            this.dgvDebts.RowTemplate.Height = 45;
            this.dgvDebts.Size = new System.Drawing.Size(1010, 336);
            this.dgvDebts.TabIndex = 0;
            this.dgvDebts.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDebts.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDebts.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDebts.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDebts.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDebts.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDebts.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDebts.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.dgvDebts.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDebts.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDebts.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDebts.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDebts.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvDebts.ThemeStyle.ReadOnly = false;
            this.dgvDebts.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDebts.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDebts.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDebts.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDebts.ThemeStyle.RowsStyle.Height = 45;
            this.dgvDebts.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDebts.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDebts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDebts_CellContentClick);
            this.dgvDebts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDebts_CellDoubleClick);
            // 
            // colCustomerID
            // 
            this.colCustomerID.FillWeight = 60F;
            this.colCustomerID.HeaderText = "ID";
            this.colCustomerID.MinimumWidth = 8;
            this.colCustomerID.Name = "colCustomerID";
            this.colCustomerID.ReadOnly = true;
            // 
            // colTenKhachHang
            // 
            this.colTenKhachHang.FillWeight = 150F;
            this.colTenKhachHang.HeaderText = "Khách hàng";
            this.colTenKhachHang.MinimumWidth = 8;
            this.colTenKhachHang.Name = "colTenKhachHang";
            this.colTenKhachHang.ReadOnly = true;
            // 
            // colSoDienThoai
            // 
            this.colSoDienThoai.FillWeight = 110F;
            this.colSoDienThoai.HeaderText = "Số điện thoại";
            this.colSoDienThoai.MinimumWidth = 8;
            this.colSoDienThoai.Name = "colSoDienThoai";
            this.colSoDienThoai.ReadOnly = true;
            // 
            // colTongMuaHang
            // 
            this.colTongMuaHang.FillWeight = 110F;
            this.colTongMuaHang.HeaderText = "Tổng mua hàng";
            this.colTongMuaHang.MinimumWidth = 8;
            this.colTongMuaHang.Name = "colTongMuaHang";
            this.colTongMuaHang.ReadOnly = true;
            // 
            // colTongDaTra
            // 
            this.colTongDaTra.FillWeight = 110F;
            this.colTongDaTra.HeaderText = "Đã trả";
            this.colTongDaTra.MinimumWidth = 8;
            this.colTongDaTra.Name = "colTongDaTra";
            this.colTongDaTra.ReadOnly = true;
            // 
            // colCongNo
            // 
            this.colCongNo.FillWeight = 120F;
            this.colCongNo.HeaderText = "Công nợ";
            this.colCongNo.MinimumWidth = 8;
            this.colCongNo.Name = "colCongNo";
            this.colCongNo.ReadOnly = true;
            // 
            // colActions
            // 
            this.colActions.HeaderText = "Thao tác";
            this.colActions.MinimumWidth = 8;
            this.colActions.Name = "colActions";
            this.colActions.ReadOnly = true;
            this.colActions.Text = "⚙️ Hành động";
            this.colActions.UseColumnTextForButtonValue = true;
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.guna2Button1);
            this.pnlActions.Controls.Add(this.btnThanhToan);
            this.pnlActions.Controls.Add(this.btnExport);
            this.pnlActions.Controls.Add(this.btnRefresh);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActions.Location = new System.Drawing.Point(0, 80);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlActions.Size = new System.Drawing.Size(1050, 70);
            this.pnlActions.TabIndex = 2;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 8;
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(564, 17);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(244, 40);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.Text = "Công nợ nhà cung cấp";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BorderRadius = 8;
            this.btnThanhToan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(20, 15);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(180, 40);
            this.btnThanhToan.TabIndex = 0;
            this.btnThanhToan.Text = "💰 Thanh toán";
            this.btnThanhToan.Click += new System.EventHandler(this.BtnThanhToan_Click);
            // 
            // btnExport
            // 
            this.btnExport.BorderRadius = 8;
            this.btnExport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(390, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 40);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "📊 Xuất Excel";
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BorderRadius = 8;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(140)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(220, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 40);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.lblStats);
            this.pnlFooter.Controls.Add(this.lblTotalDebts);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 526);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.pnlFooter.Size = new System.Drawing.Size(1050, 100);
            this.pnlFooter.TabIndex = 1;
            // 
            // lblStats
            // 
            this.lblStats.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStats.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblStats.Location = new System.Drawing.Point(20, 55);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(1010, 40);
            this.lblStats.TabIndex = 1;
            this.lblStats.Text = "Đang tải thống kê...";
            this.lblStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalDebts
            // 
            this.lblTotalDebts.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalDebts.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalDebts.Location = new System.Drawing.Point(20, 5);
            this.lblTotalDebts.Name = "lblTotalDebts";
            this.lblTotalDebts.Size = new System.Drawing.Size(1010, 40);
            this.lblTotalDebts.TabIndex = 0;
            this.lblTotalDebts.Text = "Tổng: 0 khách hàng";
            this.lblTotalDebts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DebtManagementUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.ClientSize = new System.Drawing.Size(1050, 626);
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
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}