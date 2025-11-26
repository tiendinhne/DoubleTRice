using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    partial class CustomerManagementUI
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

            this.lblTitle = new Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();

            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();

            this.dgvCustomers = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colCustomerID = new DataGridViewTextBoxColumn();
            this.colTenKhachHang = new DataGridViewTextBoxColumn();
            this.colSoDienThoai = new DataGridViewTextBoxColumn();
            this.colDiaChi = new DataGridViewTextBoxColumn();
            this.colActions = new DataGridViewButtonColumn();

            this.lblTotalCustomers = new Label();

            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
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
            this.lblTitle.Text = "👥 Quản lý Khách hàng";
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            // txtSearch
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Location = new Point(380, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "🔍 Tìm kiếm khách hàng (Tên, SĐT, Địa chỉ)...";
            this.txtSearch.Size = new Size(650, 40);
            this.txtSearch.TextChanged += new EventHandler(this.TxtSearch_TextChanged);

            // pnlActions
            this.pnlActions.Controls.Add(this.btnExport);
            this.pnlActions.Controls.Add(this.btnRefresh);
            this.pnlActions.Controls.Add(this.btnAdd);
            this.pnlActions.Dock = DockStyle.Top;
            this.pnlActions.Location = new Point(0, 80);
            this.pnlActions.Padding = new Padding(20, 10, 20, 10);
            this.pnlActions.Size = new Size(1050, 70);

            // btnAdd
            this.btnAdd.BorderRadius = 8;
            this.btnAdd.FillColor = Color.FromArgb(0, 150, 120);
            this.btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.Location = new Point(20, 15);
            this.btnAdd.Size = new Size(180, 40);
            this.btnAdd.Text = "➕ Thêm khách hàng";
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

            // dgvCustomers
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.ColumnHeadersHeight = 40;
            this.dgvCustomers.Columns.AddRange(new DataGridViewColumn[] {
                this.colCustomerID, this.colTenKhachHang, this.colSoDienThoai,
                this.colDiaChi, this.colActions
            });
            this.dgvCustomers.Dock = DockStyle.Fill;
            this.dgvCustomers.Location = new Point(20, 20);
            this.dgvCustomers.RowTemplate.Height = 45;
            this.dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.CellContentClick += new DataGridViewCellEventHandler(this.DgvCustomers_CellContentClick);
            this.dgvCustomers.CellDoubleClick += new DataGridViewCellEventHandler(this.DgvCustomers_CellDoubleClick);

            // Columns
            this.colCustomerID.HeaderText = "ID";
            this.colCustomerID.Name = "colCustomerID";
            this.colCustomerID.FillWeight = 60F;
            this.colCustomerID.ReadOnly = true;
            this.colCustomerID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.colTenKhachHang.HeaderText = "Tên khách hàng";
            this.colTenKhachHang.Name = "colTenKhachHang";
            this.colTenKhachHang.FillWeight = 150F;
            this.colTenKhachHang.ReadOnly = true;

            this.colSoDienThoai.HeaderText = "Số điện thoại";
            this.colSoDienThoai.Name = "colSoDienThoai";
            this.colSoDienThoai.FillWeight = 120F;
            this.colSoDienThoai.ReadOnly = true;

            this.colDiaChi.HeaderText = "Địa chỉ";
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.FillWeight = 200F;
            this.colDiaChi.ReadOnly = true;

            this.colActions.HeaderText = "Thao tác";
            this.colActions.Name = "colActions";
            this.colActions.FillWeight = 100F;
            this.colActions.ReadOnly = true;
            this.colActions.Text = "⚙️ Hành động";
            this.colActions.UseColumnTextForButtonValue = true;

            // pnlContent
            this.pnlContent.Controls.Add(this.dgvCustomers);
            this.pnlContent.Dock = DockStyle.Fill;
            this.pnlContent.Location = new Point(0, 150);
            this.pnlContent.Padding = new Padding(20);
            this.pnlContent.Size = new Size(1050, 426);

            // pnlFooter
            this.pnlFooter.Controls.Add(this.lblTotalCustomers);
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Location = new Point(0, 576);
            this.pnlFooter.Padding = new Padding(20, 5, 20, 5);
            this.pnlFooter.Size = new Size(1050, 50);

            // lblTotalCustomers
            this.lblTotalCustomers.Dock = DockStyle.Left;
            this.lblTotalCustomers.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTotalCustomers.Location = new Point(20, 5);
            this.lblTotalCustomers.Size = new Size(250, 40);
            this.lblTotalCustomers.Text = "Tổng: 0 khách hàng";
            this.lblTotalCustomers.TextAlign = ContentAlignment.MiddleLeft;

            // Form
            this.ClientSize = new Size(1050, 626);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "CustomerManagementUI";
            this.Text = "Quản lý Khách hàng";

            this.pnlHeader.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlContent;
        private Guna.UI2.WinForms.Guna2Panel pnlActions;
        private Guna.UI2.WinForms.Guna2Panel pnlFooter;
        private Label lblTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Button btnExport;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCustomers;
        private DataGridViewTextBoxColumn colCustomerID;
        private DataGridViewTextBoxColumn colTenKhachHang;
        private DataGridViewTextBoxColumn colSoDienThoai;
        private DataGridViewTextBoxColumn colDiaChi;
        private DataGridViewButtonColumn colActions;
        private Label lblTotalCustomers;
    }
}