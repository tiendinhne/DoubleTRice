using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    partial class SupplierManagementUI
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

            this.dgvSuppliers = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colSupplierID = new DataGridViewTextBoxColumn();
            this.colTenNhaCungCap = new DataGridViewTextBoxColumn();
            this.colSoDienThoai = new DataGridViewTextBoxColumn();
            this.colDiaChi = new DataGridViewTextBoxColumn();
            this.colActions = new DataGridViewButtonColumn();

            this.lblTotalSuppliers = new Label();

            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).BeginInit();
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
            this.lblTitle.Text = "🏭 Quản lý Nhà cung cấp";
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            // txtSearch
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Location = new Point(380, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "🔍 Tìm kiếm nhà cung cấp (Tên, SĐT, Địa chỉ)...";
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
            this.btnAdd.Size = new Size(200, 40);
            this.btnAdd.Text = "➕ Thêm nhà cung cấp";
            this.btnAdd.Click += new EventHandler(this.BtnAdd_Click);

            // btnRefresh
            this.btnRefresh.BorderRadius = 8;
            this.btnRefresh.FillColor = Color.FromArgb(100, 120, 140);
            this.btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Location = new Point(230, 15);
            this.btnRefresh.Size = new Size(150, 40);
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.Click += new EventHandler(this.BtnRefresh_Click);

            // btnExport
            this.btnExport.BorderRadius = 8;
            this.btnExport.FillColor = Color.FromArgb(76, 175, 80);
            this.btnExport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnExport.ForeColor = Color.White;
            this.btnExport.Location = new Point(390, 15);
            this.btnExport.Size = new Size(150, 40);
            this.btnExport.Text = "📊 Xuất Excel";
            this.btnExport.Click += new EventHandler(this.BtnExport_Click);

            // dgvSuppliers
            this.dgvSuppliers.AllowUserToAddRows = false;
            this.dgvSuppliers.AllowUserToDeleteRows = false;
            this.dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSuppliers.ColumnHeadersHeight = 40;
            this.dgvSuppliers.Columns.AddRange(new DataGridViewColumn[] {
                this.colSupplierID, this.colTenNhaCungCap, this.colSoDienThoai,
                this.colDiaChi, this.colActions
            });
            this.dgvSuppliers.Dock = DockStyle.Fill;
            this.dgvSuppliers.Location = new Point(20, 20);
            this.dgvSuppliers.RowTemplate.Height = 45;
            this.dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSuppliers.CellContentClick += new DataGridViewCellEventHandler(this.DgvSuppliers_CellContentClick);
            this.dgvSuppliers.CellDoubleClick += new DataGridViewCellEventHandler(this.DgvSuppliers_CellDoubleClick);

            // Columns
            this.colSupplierID.HeaderText = "ID";
            this.colSupplierID.Name = "colSupplierID";
            this.colSupplierID.FillWeight = 60F;
            this.colSupplierID.ReadOnly = true;
            this.colSupplierID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.colTenNhaCungCap.HeaderText = "Tên nhà cung cấp";
            this.colTenNhaCungCap.Name = "colTenNhaCungCap";
            this.colTenNhaCungCap.FillWeight = 150F;
            this.colTenNhaCungCap.ReadOnly = true;

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
            this.pnlContent.Controls.Add(this.dgvSuppliers);
            this.pnlContent.Dock = DockStyle.Fill;
            this.pnlContent.Location = new Point(0, 150);
            this.pnlContent.Padding = new Padding(20);
            this.pnlContent.Size = new Size(1050, 426);

            // pnlFooter
            this.pnlFooter.Controls.Add(this.lblTotalSuppliers);
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Location = new Point(0, 576);
            this.pnlFooter.Padding = new Padding(20, 5, 20, 5);
            this.pnlFooter.Size = new Size(1050, 50);

            // lblTotalSuppliers
            this.lblTotalSuppliers.Dock = DockStyle.Left;
            this.lblTotalSuppliers.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTotalSuppliers.Location = new Point(20, 5);
            this.lblTotalSuppliers.Size = new Size(250, 40);
            this.lblTotalSuppliers.Text = "Tổng: 0 nhà cung cấp";
            this.lblTotalSuppliers.TextAlign = ContentAlignment.MiddleLeft;

            // Form
            this.ClientSize = new Size(1050, 626);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "SupplierManagementUI";
            this.Text = "Quản lý Nhà cung cấp";

            this.pnlHeader.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).EndInit();
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
        private Guna.UI2.WinForms.Guna2DataGridView dgvSuppliers;
        private DataGridViewTextBoxColumn colSupplierID;
        private DataGridViewTextBoxColumn colTenNhaCungCap;
        private DataGridViewTextBoxColumn colSoDienThoai;
        private DataGridViewTextBoxColumn colDiaChi;
        private DataGridViewButtonColumn colActions;
        private Label lblTotalSuppliers;
    }
}