using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    partial class ProductManagementUI
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

            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlActions = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlFooter = new Guna.UI2.WinForms.Guna2Panel();

            this.lblTitle = new Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboStatusFilter = new Guna.UI2.WinForms.Guna2ComboBox();

            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();

            this.dgvProducts = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colProductID = new DataGridViewTextBoxColumn();
            this.colTenSanPham = new DataGridViewTextBoxColumn();
            this.colBaseUnit = new DataGridViewTextBoxColumn();
            this.colTonKhoToiThieu = new DataGridViewTextBoxColumn();
            this.colSoLuongTon = new DataGridViewTextBoxColumn();
            this.colTrangThai = new DataGridViewTextBoxColumn();
            this.colActions = new DataGridViewButtonColumn();

            this.lblTotalProducts = new Label();

            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.Controls.Add(this.cboStatusFilter);
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
            this.lblTitle.Text = "📦 Quản lý Sản phẩm";
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            // txtSearch
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Location = new Point(380, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "🔍 Tìm kiếm sản phẩm...";
            this.txtSearch.Size = new Size(400, 40);
            this.txtSearch.TextChanged += new EventHandler(this.TxtSearch_TextChanged);

            // cboStatusFilter
            this.cboStatusFilter.BackColor = Color.Transparent;
            this.cboStatusFilter.BorderRadius = 8;
            this.cboStatusFilter.DrawMode = DrawMode.OwnerDrawFixed;
            this.cboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboStatusFilter.Items.AddRange(new object[] { "Tất cả", "Còn hàng", "Sắp hết", "Hết hàng" });
            this.cboStatusFilter.Location = new Point(790, 20);
            this.cboStatusFilter.Name = "cboStatusFilter";
            this.cboStatusFilter.Size = new Size(240, 40);
            this.cboStatusFilter.StartIndex = 0;
            this.cboStatusFilter.SelectedIndexChanged += new EventHandler(this.CboStatusFilter_SelectedIndexChanged);

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
            this.btnAdd.Text = "➕ Thêm sản phẩm";
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

            // dgvProducts
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeight = 40;
            this.dgvProducts.Columns.AddRange(new DataGridViewColumn[] {
                this.colProductID, this.colTenSanPham, this.colBaseUnit,
                this.colTonKhoToiThieu, this.colSoLuongTon, this.colTrangThai, this.colActions
            });
            this.dgvProducts.Dock = DockStyle.Fill;
            this.dgvProducts.Location = new Point(20, 20);
            this.dgvProducts.RowTemplate.Height = 45;
            this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.CellContentClick += new DataGridViewCellEventHandler(this.DgvProducts_CellContentClick);
            this.dgvProducts.CellDoubleClick += new DataGridViewCellEventHandler(this.DgvProducts_CellDoubleClick);

            // Columns
            this.colProductID.HeaderText = "ID";
            this.colProductID.Name = "colProductID";
            this.colProductID.FillWeight = 60F;
            this.colProductID.ReadOnly = true;

            this.colTenSanPham.HeaderText = "Tên sản phẩm";
            this.colTenSanPham.Name = "colTenSanPham";
            this.colTenSanPham.FillWeight = 150F;
            this.colTenSanPham.ReadOnly = true;

            this.colBaseUnit.HeaderText = "ĐVT cơ sở";
            this.colBaseUnit.Name = "colBaseUnit";
            this.colBaseUnit.FillWeight = 80F;
            this.colBaseUnit.ReadOnly = true;

            this.colTonKhoToiThieu.HeaderText = "Tồn tối thiểu";
            this.colTonKhoToiThieu.Name = "colTonKhoToiThieu";
            this.colTonKhoToiThieu.FillWeight = 90F;
            this.colTonKhoToiThieu.ReadOnly = true;

            this.colSoLuongTon.HeaderText = "Tồn hiện tại";
            this.colSoLuongTon.Name = "colSoLuongTon";
            this.colSoLuongTon.FillWeight = 90F;
            this.colSoLuongTon.ReadOnly = true;

            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.FillWeight = 90F;
            this.colTrangThai.ReadOnly = true;

            this.colActions.HeaderText = "Thao tác";
            this.colActions.Name = "colActions";
            this.colActions.FillWeight = 100F;
            this.colActions.ReadOnly = true;
            this.colActions.Text = "⚙️ Hành động";
            this.colActions.UseColumnTextForButtonValue = true;

            // pnlContent
            this.pnlContent.Controls.Add(this.dgvProducts);
            this.pnlContent.Dock = DockStyle.Fill;
            this.pnlContent.Location = new Point(0, 150);
            this.pnlContent.Padding = new Padding(20);
            this.pnlContent.Size = new Size(1050, 426);

            // pnlFooter
            this.pnlFooter.Controls.Add(this.lblTotalProducts);
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Location = new Point(0, 576);
            this.pnlFooter.Padding = new Padding(20, 5, 20, 5);
            this.pnlFooter.Size = new Size(1050, 50);

            // lblTotalProducts
            this.lblTotalProducts.Dock = DockStyle.Left;
            this.lblTotalProducts.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTotalProducts.Location = new Point(20, 5);
            this.lblTotalProducts.Size = new Size(200, 40);
            this.lblTotalProducts.Text = "Tổng: 0 sản phẩm";
            this.lblTotalProducts.TextAlign = ContentAlignment.MiddleLeft;

            // Form
            this.ClientSize = new Size(1050, 626);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "ProductManagementUI";
            this.Text = "Quản lý Sản phẩm";

            this.pnlHeader.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
        }
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlContent;
        private Guna.UI2.WinForms.Guna2Panel pnlActions;
        private Guna.UI2.WinForms.Guna2Panel pnlFooter;
        private Label lblTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cboStatusFilter;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Button btnExport;
        private Guna.UI2.WinForms.Guna2DataGridView dgvProducts;
        private DataGridViewTextBoxColumn colProductID;
        private DataGridViewTextBoxColumn colTenSanPham;
        private DataGridViewTextBoxColumn colBaseUnit;
        private DataGridViewTextBoxColumn colTonKhoToiThieu;
        private DataGridViewTextBoxColumn colSoLuongTon;
        private DataGridViewTextBoxColumn colTrangThai;
        private DataGridViewButtonColumn colActions;
        private Label lblTotalProducts;
        #endregion
    }

}