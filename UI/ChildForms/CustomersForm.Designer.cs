using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using DoubleTRice.UI.BASE;

namespace DoubleTRice.UI.ChildForms
{
    partial class CustomersForm
    {
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();

            // Initialize components
            this.pnlHeader = new Guna2Panel();
            this.pnlContent = new Guna2Panel();
            this.pnlActions = new Guna2Panel();
            this.lblTitle = new Label();
            this.txtSearch = new Guna2TextBox();
            this.btnAdd = new Guna2Button();
            this.btnEdit = new Guna2Button();
            this.btnDelete = new Guna2Button();
            this.btnRefresh = new Guna2Button();
            this.btnExport = new Guna2Button();
            this.dgvCustomers = new Guna2DataGridView();
            this.colCustomerID = new DataGridViewTextBoxColumn();
            this.colCustomerName = new DataGridViewTextBoxColumn();
            this.colPhone = new DataGridViewTextBoxColumn();
            this.colAddress = new DataGridViewTextBoxColumn();

            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
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
            this.pnlHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = Mode.GetForeColor();
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(350, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "👥 Quản lý Khách hàng";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtSearch.FillColor = Mode.IsDarkMode ? System.Drawing.Color.FromArgb(30, 30, 30) : System.Drawing.Color.White;
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(0, 150, 120);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.ForeColor = Mode.GetForeColor();
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(0, 150, 120);
            this.txtSearch.IconLeft = null;
            this.txtSearch.Location = new System.Drawing.Point(400, 20);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "🔍 Tìm kiếm khách hàng...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(630, 40);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);

            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnExport);
            this.pnlActions.Controls.Add(this.btnRefresh);
            this.pnlActions.Controls.Add(this.btnDelete);
            this.pnlActions.Controls.Add(this.btnEdit);
            this.pnlActions.Controls.Add(this.btnAdd);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActions.FillColor = System.Drawing.Color.Transparent;
            this.pnlActions.Location = new System.Drawing.Point(0, 80);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlActions.Size = new System.Drawing.Size(1050, 70);
            this.pnlActions.TabIndex = 1;

            // 
            // btnAdd
            // 
            this.btnAdd.BorderRadius = 8;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(0, 150, 120);
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.HoverState.FillColor = System.Drawing.Color.FromArgb(0, 130, 100);
            this.btnAdd.Location = new System.Drawing.Point(20, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 40);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "➕ Thêm mới";
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);

            // 
            // btnEdit
            // 
            this.btnEdit.BorderRadius = 8;
            this.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            this.btnEdit.FillColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.HoverState.FillColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnEdit.Location = new System.Drawing.Point(180, 15);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(150, 40);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "✏️ Sửa";
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);

            // 
            // btnDelete
            // 
            this.btnDelete.BorderRadius = 8;
            this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            this.btnDelete.FillColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.HoverState.FillColor = System.Drawing.Color.FromArgb(211, 47, 47);
            this.btnDelete.Location = new System.Drawing.Point(340, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "🗑️ Xóa";
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            // 
            // btnRefresh
            // 
            this.btnRefresh.BorderRadius = 8;
            this.btnRefresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnRefresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(100, 120, 140);
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.HoverState.FillColor = System.Drawing.Color.FromArgb(80, 100, 120);
            this.btnRefresh.Location = new System.Drawing.Point(500, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 40);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);

            // 
            // btnExport
            // 
            this.btnExport.BorderRadius = 8;
            this.btnExport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnExport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            this.btnExport.FillColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.HoverState.FillColor = System.Drawing.Color.FromArgb(56, 142, 60);
            this.btnExport.Location = new System.Drawing.Point(660, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 40);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "📊 Xuất Excel";
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);

            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvCustomers);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.FillColor = System.Drawing.Color.Transparent;
            this.pnlContent.Location = new System.Drawing.Point(0, 150);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(1050, 476);
            this.pnlContent.TabIndex = 2;

            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Mode.IsDarkMode ? System.Drawing.Color.FromArgb(30, 30, 30) : System.Drawing.Color.FromArgb(245, 245, 245);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Mode.GetForeColor();
            dataGridViewCellStyle1.SelectionBackColor = Mode.GetButtonCheckedColor();
            dataGridViewCellStyle1.SelectionForeColor = Mode.GetForeColor();
            this.dgvCustomers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.BackgroundColor = Mode.GetBodyColor();
            this.dgvCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCustomers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCustomers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Mode.GetButtonCheckedColor();
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Mode.GetButtonCheckedColor();
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCustomers.ColumnHeadersHeight = 40;
            this.dgvCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCustomerID,
            this.colCustomerName,
            this.colPhone,
            this.colAddress});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Mode.GetBodyColor();
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Mode.GetForeColor();
            dataGridViewCellStyle3.SelectionBackColor = Mode.GetButtonCheckedColor();
            dataGridViewCellStyle3.SelectionForeColor = Mode.GetForeColor();
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomers.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.EnableHeadersVisualStyles = false;
            this.dgvCustomers.GridColor = Mode.GetSeparatorColor();
            this.dgvCustomers.Location = new System.Drawing.Point(20, 20);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersVisible = false;
            this.dgvCustomers.RowHeadersWidth = 62;
            this.dgvCustomers.RowTemplate.Height = 40;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(1010, 436);
            this.dgvCustomers.TabIndex = 0;
            this.dgvCustomers.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCustomers.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCustomers.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCustomers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCustomers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCustomers.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCustomers.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(231, 229, 255);
            this.dgvCustomers.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(100, 88, 255);
            this.dgvCustomers.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCustomers.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvCustomers.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCustomers.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCustomers.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvCustomers.ThemeStyle.ReadOnly = true;
            this.dgvCustomers.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCustomers.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCustomers.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvCustomers.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            this.dgvCustomers.ThemeStyle.RowsStyle.Height = 40;
            this.dgvCustomers.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(231, 229, 255);
            this.dgvCustomers.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            this.dgvCustomers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCustomers_CellDoubleClick);

            // 
            // colCustomerID
            // 
            this.colCustomerID.FillWeight = 80F;
            this.colCustomerID.HeaderText = "Mã KH";
            this.colCustomerID.MinimumWidth = 8;
            this.colCustomerID.Name = "colCustomerID";
            this.colCustomerID.ReadOnly = true;

            // 
            // colCustomerName
            // 
            this.colCustomerName.FillWeight = 120F;
            this.colCustomerName.HeaderText = "Tên khách hàng";
            this.colCustomerName.MinimumWidth = 8;
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.ReadOnly = true;

            // 
            // colPhone
            // 
            this.colPhone.FillWeight = 100F;
            this.colPhone.HeaderText = "Số điện thoại";
            this.colPhone.MinimumWidth = 8;
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;

            // 
            // colAddress
            // 
            this.colAddress.FillWeight = 150F;
            this.colAddress.HeaderText = "Địa chỉ";
            this.colAddress.MinimumWidth = 8;
            this.colAddress.Name = "colAddress";
            this.colAddress.ReadOnly = true;

            // 
            // CustomersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 626);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomersForm";
            this.Text = "Quản lý Khách hàng";
            this.pnlHeader.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);
        }
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code - Fields

        // Panels
        private Guna2Panel pnlHeader;
        private Guna2Panel pnlContent;
        private Guna2Panel pnlActions;

        // Header Controls
        private Label lblTitle;
        private Guna2TextBox txtSearch;

        // Action Buttons
        private Guna2Button btnAdd;
        private Guna2Button btnEdit;
        private Guna2Button btnDelete;
        private Guna2Button btnRefresh;
        private Guna2Button btnExport;

        // DataGridView
        private Guna2DataGridView dgvCustomers;

        // DataGridView Columns
        private DataGridViewTextBoxColumn colCustomerID;
        private DataGridViewTextBoxColumn colCustomerName;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colAddress;

        #endregion
        #endregion
    }
}