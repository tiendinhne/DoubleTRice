using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    partial class POSDialog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlRight = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlCart = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvCart = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colCartProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCartUnit = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCartQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCartPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCartTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCartDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlActions = new Guna.UI2.WinForms.Guna2Panel();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.btnThanhToan = new Guna.UI2.WinForms.Guna2Button();
            this.pnlPayment = new Guna.UI2.WinForms.Guna2Panel();
            this.chkGhiNo = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtTienThua = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTienThua = new System.Windows.Forms.Label();
            this.txtTienKhachDua = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTienKhachDua = new System.Windows.Forms.Label();
            this.txtTongTien = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.pnlRightHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlCustomerInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCustomerDebt = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.btnSearchCustomer = new Guna.UI2.WinForms.Guna2Button();
            this.txtCustomerPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblCartTitle = new System.Windows.Forms.Label();
            this.pnlLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlProductList = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvProducts = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBaseUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuongTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddToCart = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlLeftHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.txtProductSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblProductTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.pnlActions.SuspendLayout();
            this.pnlPayment.SuspendLayout();
            this.pnlRightHeader.SuspendLayout();
            this.pnlCustomerInfo.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlProductList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.pnlLeftHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(14, 936);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlCart);
            this.pnlRight.Controls.Add(this.pnlActions);
            this.pnlRight.Controls.Add(this.pnlPayment);
            this.pnlRight.Controls.Add(this.pnlRightHeader);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.FillColor = System.Drawing.Color.White;
            this.pnlRight.Location = new System.Drawing.Point(800, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(10);
            this.pnlRight.Size = new System.Drawing.Size(0, 936);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlCart
            // 
            this.pnlCart.Controls.Add(this.dgvCart);
            this.pnlCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCart.Location = new System.Drawing.Point(10, 200);
            this.pnlCart.Name = "pnlCart";
            this.pnlCart.Padding = new System.Windows.Forms.Padding(5);
            this.pnlCart.Size = new System.Drawing.Size(0, 466);
            this.pnlCart.TabIndex = 1;
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvCart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCart.ColumnHeadersHeight = 40;
            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCartProductName,
            this.colCartUnit,
            this.colCartQuantity,
            this.colCartPrice,
            this.colCartTotal,
            this.colCartDelete});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCart.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCart.Location = new System.Drawing.Point(5, 5);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.RowHeadersWidth = 62;
            this.dgvCart.RowTemplate.Height = 45;
            this.dgvCart.Size = new System.Drawing.Size(0, 456);
            this.dgvCart.TabIndex = 0;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCart.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCart.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCart.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvCart.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCart.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvCart.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCart.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvCart.ThemeStyle.ReadOnly = false;
            this.dgvCart.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCart.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCart.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvCart.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCart.ThemeStyle.RowsStyle.Height = 45;
            this.dgvCart.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCart.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCart_CellContentClick);
            this.dgvCart.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCart_CellEndEdit);
            // 
            // colCartProductName
            // 
            this.colCartProductName.FillWeight = 120F;
            this.colCartProductName.HeaderText = "Sản phẩm";
            this.colCartProductName.MinimumWidth = 8;
            this.colCartProductName.Name = "colCartProductName";
            this.colCartProductName.ReadOnly = true;
            // 
            // colCartUnit
            // 
            this.colCartUnit.FillWeight = 80F;
            this.colCartUnit.HeaderText = "ĐVT";
            this.colCartUnit.MinimumWidth = 8;
            this.colCartUnit.Name = "colCartUnit";
            // 
            // colCartQuantity
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colCartQuantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.colCartQuantity.FillWeight = 60F;
            this.colCartQuantity.HeaderText = "SL";
            this.colCartQuantity.MinimumWidth = 8;
            this.colCartQuantity.Name = "colCartQuantity";
            // 
            // colCartPrice
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colCartPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.colCartPrice.FillWeight = 90F;
            this.colCartPrice.HeaderText = "Đơn giá";
            this.colCartPrice.MinimumWidth = 8;
            this.colCartPrice.Name = "colCartPrice";
            // 
            // colCartTotal
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colCartTotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.colCartTotal.HeaderText = "Thành tiền";
            this.colCartTotal.MinimumWidth = 8;
            this.colCartTotal.Name = "colCartTotal";
            this.colCartTotal.ReadOnly = true;
            // 
            // colCartDelete
            // 
            this.colCartDelete.FillWeight = 50F;
            this.colCartDelete.HeaderText = "";
            this.colCartDelete.MinimumWidth = 8;
            this.colCartDelete.Name = "colCartDelete";
            this.colCartDelete.Text = "🗑️";
            this.colCartDelete.UseColumnTextForButtonValue = true;
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnHuy);
            this.pnlActions.Controls.Add(this.btnThanhToan);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(10, 666);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(10);
            this.pnlActions.Size = new System.Drawing.Size(580, 60);
            this.pnlActions.TabIndex = 3;
            // 
            // btnHuy
            // 
            this.btnHuy.BorderRadius = 10;
            this.btnHuy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHuy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHuy.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHuy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(10, 10);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(270, 40);
            this.btnHuy.TabIndex = 0;
            this.btnHuy.Text = "❌ HỦY";
            this.btnHuy.Click += new System.EventHandler(this.BtnHuy_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BorderRadius = 10;
            this.btnThanhToan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThanhToan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThanhToan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThanhToan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThanhToan.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThanhToan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(-290, 10);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(280, 40);
            this.btnThanhToan.TabIndex = 1;
            this.btnThanhToan.Text = "✅ THANH TOÁN";
            this.btnThanhToan.Click += new System.EventHandler(this.BtnThanhToan_Click);
            // 
            // pnlPayment
            // 
            this.pnlPayment.Controls.Add(this.chkGhiNo);
            this.pnlPayment.Controls.Add(this.txtTienThua);
            this.pnlPayment.Controls.Add(this.lblTienThua);
            this.pnlPayment.Controls.Add(this.txtTienKhachDua);
            this.pnlPayment.Controls.Add(this.lblTienKhachDua);
            this.pnlPayment.Controls.Add(this.txtTongTien);
            this.pnlPayment.Controls.Add(this.lblTongTien);
            this.pnlPayment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPayment.Location = new System.Drawing.Point(10, 726);
            this.pnlPayment.Name = "pnlPayment";
            this.pnlPayment.Padding = new System.Windows.Forms.Padding(10);
            this.pnlPayment.Size = new System.Drawing.Size(0, 200);
            this.pnlPayment.TabIndex = 2;
            // 
            // chkGhiNo
            // 
            this.chkGhiNo.AutoSize = true;
            this.chkGhiNo.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkGhiNo.CheckedState.BorderRadius = 0;
            this.chkGhiNo.CheckedState.BorderThickness = 0;
            this.chkGhiNo.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkGhiNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.chkGhiNo.Location = new System.Drawing.Point(160, 145);
            this.chkGhiNo.Name = "chkGhiNo";
            this.chkGhiNo.Size = new System.Drawing.Size(178, 29);
            this.chkGhiNo.TabIndex = 6;
            this.chkGhiNo.Text = "Cho phép ghi nợ";
            this.chkGhiNo.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkGhiNo.UncheckedState.BorderRadius = 0;
            this.chkGhiNo.UncheckedState.BorderThickness = 2;
            this.chkGhiNo.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // txtTienThua
            // 
            this.txtTienThua.BorderRadius = 8;
            this.txtTienThua.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTienThua.DefaultText = "0";
            this.txtTienThua.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtTienThua.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtTienThua.ForeColor = System.Drawing.Color.Green;
            this.txtTienThua.Location = new System.Drawing.Point(160, 100);
            this.txtTienThua.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtTienThua.Name = "txtTienThua";
            this.txtTienThua.PlaceholderText = "";
            this.txtTienThua.ReadOnly = true;
            this.txtTienThua.SelectedText = "";
            this.txtTienThua.Size = new System.Drawing.Size(410, 35);
            this.txtTienThua.TabIndex = 5;
            this.txtTienThua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTienThua
            // 
            this.lblTienThua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTienThua.Location = new System.Drawing.Point(10, 100);
            this.lblTienThua.Name = "lblTienThua";
            this.lblTienThua.Size = new System.Drawing.Size(150, 35);
            this.lblTienThua.TabIndex = 4;
            this.lblTienThua.Text = "Tiền thừa:";
            this.lblTienThua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTienKhachDua
            // 
            this.txtTienKhachDua.BorderRadius = 8;
            this.txtTienKhachDua.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTienKhachDua.DefaultText = "";
            this.txtTienKhachDua.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTienKhachDua.Location = new System.Drawing.Point(160, 55);
            this.txtTienKhachDua.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtTienKhachDua.Name = "txtTienKhachDua";
            this.txtTienKhachDua.PlaceholderText = "0";
            this.txtTienKhachDua.SelectedText = "";
            this.txtTienKhachDua.Size = new System.Drawing.Size(410, 35);
            this.txtTienKhachDua.TabIndex = 3;
            this.txtTienKhachDua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTienKhachDua.TextChanged += new System.EventHandler(this.TxtTienKhachDua_TextChanged);
            this.txtTienKhachDua.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTienKhachDua_KeyPress);
            // 
            // lblTienKhachDua
            // 
            this.lblTienKhachDua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTienKhachDua.Location = new System.Drawing.Point(10, 55);
            this.lblTienKhachDua.Name = "lblTienKhachDua";
            this.lblTienKhachDua.Size = new System.Drawing.Size(150, 35);
            this.lblTienKhachDua.TabIndex = 2;
            this.lblTienKhachDua.Text = "Tiền khách đưa:";
            this.lblTienKhachDua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTongTien
            // 
            this.txtTongTien.BorderRadius = 8;
            this.txtTongTien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTongTien.DefaultText = "0";
            this.txtTongTien.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtTongTien.Location = new System.Drawing.Point(160, 10);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.PlaceholderText = "";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.SelectedText = "";
            this.txtTongTien.Size = new System.Drawing.Size(410, 35);
            this.txtTongTien.TabIndex = 1;
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Location = new System.Drawing.Point(10, 10);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(150, 35);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "Tổng tiền:";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlRightHeader
            // 
            this.pnlRightHeader.Controls.Add(this.pnlCustomerInfo);
            this.pnlRightHeader.Controls.Add(this.lblCartTitle);
            this.pnlRightHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRightHeader.Location = new System.Drawing.Point(10, 10);
            this.pnlRightHeader.Name = "pnlRightHeader";
            this.pnlRightHeader.Padding = new System.Windows.Forms.Padding(10);
            this.pnlRightHeader.Size = new System.Drawing.Size(0, 190);
            this.pnlRightHeader.TabIndex = 0;
            // 
            // pnlCustomerInfo
            // 
            this.pnlCustomerInfo.Controls.Add(this.lblCustomerDebt);
            this.pnlCustomerInfo.Controls.Add(this.lblCustomerName);
            this.pnlCustomerInfo.Controls.Add(this.btnSearchCustomer);
            this.pnlCustomerInfo.Controls.Add(this.txtCustomerPhone);
            this.pnlCustomerInfo.Controls.Add(this.lblCustomer);
            this.pnlCustomerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCustomerInfo.Location = new System.Drawing.Point(10, 52);
            this.pnlCustomerInfo.Name = "pnlCustomerInfo";
            this.pnlCustomerInfo.Padding = new System.Windows.Forms.Padding(5);
            this.pnlCustomerInfo.Size = new System.Drawing.Size(0, 128);
            this.pnlCustomerInfo.TabIndex = 1;
            // 
            // lblCustomerDebt
            // 
            this.lblCustomerDebt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCustomerDebt.ForeColor = System.Drawing.Color.Red;
            this.lblCustomerDebt.Location = new System.Drawing.Point(13, 99);
            this.lblCustomerDebt.Name = "lblCustomerDebt";
            this.lblCustomerDebt.Size = new System.Drawing.Size(300, 24);
            this.lblCustomerDebt.TabIndex = 4;
            this.lblCustomerDebt.Text = "Công nợ: 0 đ";
            this.lblCustomerDebt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCustomerDebt.Visible = false;
            this.lblCustomerDebt.Click += new System.EventHandler(this.lblCustomerDebt_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCustomerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.lblCustomerName.Location = new System.Drawing.Point(8, 61);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(550, 29);
            this.lblCustomerName.TabIndex = 3;
            this.lblCustomerName.Text = "Khách hàng: Khách vãng lai";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.BorderRadius = 8;
            this.btnSearchCustomer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearchCustomer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearchCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearchCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearchCustomer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.btnSearchCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearchCustomer.ForeColor = System.Drawing.Color.White;
            this.btnSearchCustomer.Location = new System.Drawing.Point(452, 8);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(100, 35);
            this.btnSearchCustomer.TabIndex = 2;
            this.btnSearchCustomer.Text = "🔍 Tìm";
            this.btnSearchCustomer.Click += new System.EventHandler(this.BtnSearchCustomer_Click);
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.BorderRadius = 8;
            this.txtCustomerPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCustomerPhone.DefaultText = "";
            this.txtCustomerPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCustomerPhone.Location = new System.Drawing.Point(150, 10);
            this.txtCustomerPhone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.PlaceholderText = "Nhập SĐT khách hàng...";
            this.txtCustomerPhone.SelectedText = "";
            this.txtCustomerPhone.Size = new System.Drawing.Size(250, 35);
            this.txtCustomerPhone.TabIndex = 1;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCustomer.Location = new System.Drawing.Point(13, 8);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(137, 35);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Số điện thoại:";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCartTitle
            // 
            this.lblCartTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCartTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCartTitle.Location = new System.Drawing.Point(10, 10);
            this.lblCartTitle.Name = "lblCartTitle";
            this.lblCartTitle.Size = new System.Drawing.Size(0, 42);
            this.lblCartTitle.TabIndex = 0;
            this.lblCartTitle.Text = "🛒 Giỏ hàng";
            this.lblCartTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlProductList);
            this.pnlLeft.Controls.Add(this.pnlLeftHeader);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(10);
            this.pnlLeft.Size = new System.Drawing.Size(800, 936);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlProductList
            // 
            this.pnlProductList.Controls.Add(this.dgvProducts);
            this.pnlProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProductList.Location = new System.Drawing.Point(10, 122);
            this.pnlProductList.Name = "pnlProductList";
            this.pnlProductList.Padding = new System.Windows.Forms.Padding(5);
            this.pnlProductList.Size = new System.Drawing.Size(780, 804);
            this.pnlProductList.TabIndex = 1;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvProducts.ColumnHeadersHeight = 40;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductID,
            this.colProductName,
            this.colBaseUnit,
            this.colSoLuongTon,
            this.colGiaBan,
            this.colAddToCart});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducts.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvProducts.Location = new System.Drawing.Point(5, 5);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.RowHeadersWidth = 62;
            this.dgvProducts.RowTemplate.Height = 45;
            this.dgvProducts.Size = new System.Drawing.Size(770, 794);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvProducts.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvProducts.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvProducts.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvProducts.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvProducts.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvProducts.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvProducts.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvProducts.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProducts.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvProducts.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvProducts.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProducts.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvProducts.ThemeStyle.ReadOnly = true;
            this.dgvProducts.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvProducts.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProducts.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvProducts.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvProducts.ThemeStyle.RowsStyle.Height = 45;
            this.dgvProducts.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvProducts.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProducts_CellContentClick);
            this.dgvProducts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProducts_CellDoubleClick);
            // 
            // colProductID
            // 
            this.colProductID.HeaderText = "ID";
            this.colProductID.MinimumWidth = 8;
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            this.colProductID.Visible = false;
            // 
            // colProductName
            // 
            this.colProductName.FillWeight = 150F;
            this.colProductName.HeaderText = "Tên sản phẩm";
            this.colProductName.MinimumWidth = 8;
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            // 
            // colBaseUnit
            // 
            this.colBaseUnit.FillWeight = 70F;
            this.colBaseUnit.HeaderText = "ĐVT";
            this.colBaseUnit.MinimumWidth = 8;
            this.colBaseUnit.Name = "colBaseUnit";
            this.colBaseUnit.ReadOnly = true;
            // 
            // colSoLuongTon
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colSoLuongTon.DefaultCellStyle = dataGridViewCellStyle9;
            this.colSoLuongTon.FillWeight = 80F;
            this.colSoLuongTon.HeaderText = "Tồn kho";
            this.colSoLuongTon.MinimumWidth = 8;
            this.colSoLuongTon.Name = "colSoLuongTon";
            this.colSoLuongTon.ReadOnly = true;
            // 
            // colGiaBan
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colGiaBan.DefaultCellStyle = dataGridViewCellStyle10;
            this.colGiaBan.HeaderText = "Giá bán";
            this.colGiaBan.MinimumWidth = 8;
            this.colGiaBan.Name = "colGiaBan";
            this.colGiaBan.ReadOnly = true;
            // 
            // colAddToCart
            // 
            this.colAddToCart.FillWeight = 80F;
            this.colAddToCart.HeaderText = "";
            this.colAddToCart.MinimumWidth = 8;
            this.colAddToCart.Name = "colAddToCart";
            this.colAddToCart.ReadOnly = true;
            this.colAddToCart.Text = "➕ Thêm";
            this.colAddToCart.UseColumnTextForButtonValue = true;
            // 
            // pnlLeftHeader
            // 
            this.pnlLeftHeader.Controls.Add(this.txtProductSearch);
            this.pnlLeftHeader.Controls.Add(this.lblProductTitle);
            this.pnlLeftHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeftHeader.Location = new System.Drawing.Point(10, 10);
            this.pnlLeftHeader.Name = "pnlLeftHeader";
            this.pnlLeftHeader.Padding = new System.Windows.Forms.Padding(10);
            this.pnlLeftHeader.Size = new System.Drawing.Size(780, 112);
            this.pnlLeftHeader.TabIndex = 0;
            // 
            // txtProductSearch
            // 
            this.txtProductSearch.BorderRadius = 8;
            this.txtProductSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProductSearch.DefaultText = "";
            this.txtProductSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtProductSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtProductSearch.Location = new System.Drawing.Point(10, 57);
            this.txtProductSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProductSearch.Name = "txtProductSearch";
            this.txtProductSearch.PlaceholderText = "🔍 Tìm kiếm sản phẩm...";
            this.txtProductSearch.SelectedText = "";
            this.txtProductSearch.Size = new System.Drawing.Size(760, 45);
            this.txtProductSearch.TabIndex = 1;
            this.txtProductSearch.TextChanged += new System.EventHandler(this.TxtProductSearch_TextChanged);
            // 
            // lblProductTitle
            // 
            this.lblProductTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProductTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblProductTitle.Location = new System.Drawing.Point(10, 10);
            this.lblProductTitle.Name = "lblProductTitle";
            this.lblProductTitle.Size = new System.Drawing.Size(760, 39);
            this.lblProductTitle.TabIndex = 0;
            this.lblProductTitle.Text = "📦 Danh sách Sản phẩm";
            this.lblProductTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // POSDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1400, 936);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "POSDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bán hàng - POS";
            this.pnlMain.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlCart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.pnlActions.ResumeLayout(false);
            this.pnlPayment.ResumeLayout(false);
            this.pnlPayment.PerformLayout();
            this.pnlRightHeader.ResumeLayout(false);
            this.pnlCustomerInfo.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlProductList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlLeftHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2Panel pnlLeft;
        private Guna.UI2.WinForms.Guna2Panel pnlRight;

        private Guna.UI2.WinForms.Guna2Panel pnlLeftHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlProductList;
        private Label lblProductTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtProductSearch;
        private Guna.UI2.WinForms.Guna2DataGridView dgvProducts;
        private DataGridViewTextBoxColumn colProductID;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colBaseUnit;
        private DataGridViewTextBoxColumn colSoLuongTon;
        private DataGridViewTextBoxColumn colGiaBan;
        private DataGridViewButtonColumn colAddToCart;

        private Guna.UI2.WinForms.Guna2Panel pnlRightHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlCart;
        private Guna.UI2.WinForms.Guna2Panel pnlPayment;
        private Guna.UI2.WinForms.Guna2Panel pnlActions;

        private Label lblCartTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlCustomerInfo;
        private Label lblCustomer;
        private Guna.UI2.WinForms.Guna2TextBox txtCustomerPhone;
        private Guna.UI2.WinForms.Guna2Button btnSearchCustomer;
        private Label lblCustomerName;
        private Label lblCustomerDebt;

        private Guna.UI2.WinForms.Guna2DataGridView dgvCart;
        private DataGridViewTextBoxColumn colCartProductName;
        private DataGridViewComboBoxColumn colCartUnit;
        private DataGridViewTextBoxColumn colCartQuantity;
        private DataGridViewTextBoxColumn colCartPrice;
        private DataGridViewTextBoxColumn colCartTotal;
        private DataGridViewButtonColumn colCartDelete;

        private Label lblTongTien;
        private Guna.UI2.WinForms.Guna2TextBox txtTongTien;
        private Label lblTienKhachDua;
        private Guna.UI2.WinForms.Guna2TextBox txtTienKhachDua;
        private Label lblTienThua;
        private Guna.UI2.WinForms.Guna2TextBox txtTienThua;
        private Guna.UI2.WinForms.Guna2CheckBox chkGhiNo;

        private Guna.UI2.WinForms.Guna2Button btnThanhToan;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
    }
}