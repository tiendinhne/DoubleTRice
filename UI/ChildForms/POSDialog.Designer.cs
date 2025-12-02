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
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlRight = new Guna.UI2.WinForms.Guna2Panel();

            // Left Panel Components
            this.pnlLeftHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlProductList = new Guna.UI2.WinForms.Guna2Panel();
            this.lblProductTitle = new Label();
            this.txtProductSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvProducts = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colProductID = new DataGridViewTextBoxColumn();
            this.colProductName = new DataGridViewTextBoxColumn();
            this.colBaseUnit = new DataGridViewTextBoxColumn();
            this.colSoLuongTon = new DataGridViewTextBoxColumn();
            this.colGiaBan = new DataGridViewTextBoxColumn();
            this.colAddToCart = new DataGridViewButtonColumn();

            // Right Panel Components
            this.pnlRightHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlCart = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlPayment = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlActions = new Guna.UI2.WinForms.Guna2Panel();

            this.lblCartTitle = new Label();
            this.pnlCustomerInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCustomer = new Label();
            this.txtCustomerPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearchCustomer = new Guna.UI2.WinForms.Guna2Button();
            this.lblCustomerName = new Label();
            this.lblCustomerDebt = new Label();

            this.dgvCart = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colCartProductName = new DataGridViewTextBoxColumn();
            this.colCartUnit = new DataGridViewComboBoxColumn();
            this.colCartQuantity = new DataGridViewTextBoxColumn();
            this.colCartPrice = new DataGridViewTextBoxColumn();
            this.colCartTotal = new DataGridViewTextBoxColumn();
            this.colCartDelete = new DataGridViewButtonColumn();

            this.lblTongTien = new Label();
            this.txtTongTien = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTienKhachDua = new Label();
            this.txtTienKhachDua = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTienThua = new Label();
            this.txtTienThua = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkGhiNo = new Guna.UI2.WinForms.Guna2CheckBox();

            this.btnThanhToan = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();

            this.pnlMain.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlLeftHeader.SuspendLayout();
            this.pnlProductList.SuspendLayout();
            this.pnlRightHeader.SuspendLayout();
            this.pnlCustomerInfo.SuspendLayout();
            this.pnlCart.SuspendLayout();
            this.pnlPayment.SuspendLayout();
            this.pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();

            // ===================================================================
            // pnlMain
            // ===================================================================
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Location = new Point(0, 0);
            this.pnlMain.Size = new Size(1400, 800);

            // ===================================================================
            // LEFT PANEL - Danh sách sản phẩm
            // ===================================================================
            this.pnlLeft.Controls.Add(this.pnlProductList);
            this.pnlLeft.Controls.Add(this.pnlLeftHeader);
            this.pnlLeft.Dock = DockStyle.Left;
            this.pnlLeft.FillColor = Color.FromArgb(240, 248, 255);
            this.pnlLeft.Size = new Size(800, 800);
            this.pnlLeft.Padding = new Padding(10);

            // pnlLeftHeader
            this.pnlLeftHeader.Controls.Add(this.txtProductSearch);
            this.pnlLeftHeader.Controls.Add(this.lblProductTitle);
            this.pnlLeftHeader.Dock = DockStyle.Top;
            this.pnlLeftHeader.Size = new Size(780, 80);
            this.pnlLeftHeader.Padding = new Padding(10);

            this.lblProductTitle.Dock = DockStyle.Top;
            this.lblProductTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblProductTitle.Location = new Point(10, 10);
            this.lblProductTitle.Size = new Size(760, 30);
            this.lblProductTitle.Text = "📦 Danh sách Sản phẩm";

            this.txtProductSearch.BorderRadius = 8;
            this.txtProductSearch.Dock = DockStyle.Bottom;
            this.txtProductSearch.Location = new Point(10, 40);
            this.txtProductSearch.PlaceholderText = "🔍 Tìm kiếm sản phẩm...";
            this.txtProductSearch.Size = new Size(760, 30);
            this.txtProductSearch.TextChanged += new EventHandler(this.TxtProductSearch_TextChanged);

            // pnlProductList
            this.pnlProductList.Controls.Add(this.dgvProducts);
            this.pnlProductList.Dock = DockStyle.Fill;
            this.pnlProductList.Location = new Point(10, 90);
            this.pnlProductList.Padding = new Padding(5);

            // dgvProducts
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeight = 40;
            this.dgvProducts.Columns.AddRange(new DataGridViewColumn[] {
                this.colProductID, this.colProductName, this.colBaseUnit,
                this.colSoLuongTon, this.colGiaBan, this.colAddToCart
            });
            this.dgvProducts.Dock = DockStyle.Fill;
            this.dgvProducts.RowTemplate.Height = 45;
            this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.CellContentClick += new DataGridViewCellEventHandler(this.DgvProducts_CellContentClick);
            this.dgvProducts.CellDoubleClick += new DataGridViewCellEventHandler(this.DgvProducts_CellDoubleClick);

            // Columns for dgvProducts
            this.colProductID.HeaderText = "ID";
            this.colProductID.Name = "colProductID";
            this.colProductID.Visible = false;

            this.colProductName.HeaderText = "Tên sản phẩm";
            this.colProductName.Name = "colProductName";
            this.colProductName.FillWeight = 150F;
            this.colProductName.ReadOnly = true;

            this.colBaseUnit.HeaderText = "ĐVT";
            this.colBaseUnit.Name = "colBaseUnit";
            this.colBaseUnit.FillWeight = 70F;
            this.colBaseUnit.ReadOnly = true;

            this.colSoLuongTon.HeaderText = "Tồn kho";
            this.colSoLuongTon.Name = "colSoLuongTon";
            this.colSoLuongTon.FillWeight = 80F;
            this.colSoLuongTon.ReadOnly = true;
            this.colSoLuongTon.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.colGiaBan.HeaderText = "Giá bán";
            this.colGiaBan.Name = "colGiaBan";
            this.colGiaBan.FillWeight = 100F;
            this.colGiaBan.ReadOnly = true;
            this.colGiaBan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.colAddToCart.HeaderText = "";
            this.colAddToCart.Name = "colAddToCart";
            this.colAddToCart.FillWeight = 80F;
            this.colAddToCart.Text = "➕ Thêm";
            this.colAddToCart.UseColumnTextForButtonValue = true;

            // ===================================================================
            // RIGHT PANEL - Giỏ hàng & Thanh toán
            // ===================================================================
            this.pnlRight.Controls.Add(this.pnlCart);
            this.pnlRight.Controls.Add(this.pnlActions);
            this.pnlRight.Controls.Add(this.pnlPayment);
            this.pnlRight.Controls.Add(this.pnlRightHeader);
            this.pnlRight.Dock = DockStyle.Fill;
            this.pnlRight.FillColor = Color.White;
            this.pnlRight.Size = new Size(600, 800);
            this.pnlRight.Padding = new Padding(10);

            // pnlRightHeader
            this.pnlRightHeader.Controls.Add(this.pnlCustomerInfo);
            this.pnlRightHeader.Controls.Add(this.lblCartTitle);
            this.pnlRightHeader.Dock = DockStyle.Top;
            this.pnlRightHeader.Size = new Size(580, 150);
            this.pnlRightHeader.Padding = new Padding(10);

            this.lblCartTitle.Dock = DockStyle.Top;
            this.lblCartTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblCartTitle.Location = new Point(10, 10);
            this.lblCartTitle.Size = new Size(560, 30);
            this.lblCartTitle.Text = "🛒 Giỏ hàng";

            // pnlCustomerInfo
            this.pnlCustomerInfo.Controls.Add(this.lblCustomerDebt);
            this.pnlCustomerInfo.Controls.Add(this.lblCustomerName);
            this.pnlCustomerInfo.Controls.Add(this.btnSearchCustomer);
            this.pnlCustomerInfo.Controls.Add(this.txtCustomerPhone);
            this.pnlCustomerInfo.Controls.Add(this.lblCustomer);
            this.pnlCustomerInfo.Dock = DockStyle.Fill;
            this.pnlCustomerInfo.Location = new Point(10, 40);
            this.pnlCustomerInfo.Padding = new Padding(5);

            this.lblCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCustomer.Location = new Point(5, 5);
            this.lblCustomer.Size = new Size(120, 30);
            this.lblCustomer.Text = "Số điện thoại:";
            this.lblCustomer.TextAlign = ContentAlignment.MiddleLeft;

            this.txtCustomerPhone.BorderRadius = 8;
            this.txtCustomerPhone.Location = new Point(125, 5);
            this.txtCustomerPhone.PlaceholderText = "Nhập SĐT khách hàng...";
            this.txtCustomerPhone.Size = new Size(250, 35);

            this.btnSearchCustomer.BorderRadius = 8;
            this.btnSearchCustomer.FillColor = Color.FromArgb(0, 150, 120);
            this.btnSearchCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnSearchCustomer.ForeColor = Color.White;
            this.btnSearchCustomer.Location = new Point(385, 5);
            this.btnSearchCustomer.Size = new Size(100, 35);
            this.btnSearchCustomer.Text = "🔍 Tìm";
            this.btnSearchCustomer.Click += new EventHandler(this.BtnSearchCustomer_Click);

            this.lblCustomerName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblCustomerName.ForeColor = Color.FromArgb(0, 150, 120);
            this.lblCustomerName.Location = new Point(5, 50);
            this.lblCustomerName.Size = new Size(550, 25);
            this.lblCustomerName.Text = "Khách hàng: Khách vãng lai";
            this.lblCustomerName.TextAlign = ContentAlignment.MiddleLeft;

            this.lblCustomerDebt.Font = new Font("Segoe UI", 9F);
            this.lblCustomerDebt.ForeColor = Color.Red;
            this.lblCustomerDebt.Location = new Point(5, 80);
            this.lblCustomerDebt.Size = new Size(550, 25);
            this.lblCustomerDebt.Text = "Công nợ: 0 đ";
            this.lblCustomerDebt.TextAlign = ContentAlignment.MiddleLeft;
            this.lblCustomerDebt.Visible = false;

            // pnlCart
            this.pnlCart.Controls.Add(this.dgvCart);
            this.pnlCart.Dock = DockStyle.Fill;
            this.pnlCart.Location = new Point(10, 160);
            this.pnlCart.Padding = new Padding(5);

            // dgvCart
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.ColumnHeadersHeight = 40;
            this.dgvCart.Columns.AddRange(new DataGridViewColumn[] {
                this.colCartProductName, this.colCartUnit, this.colCartQuantity,
                this.colCartPrice, this.colCartTotal, this.colCartDelete
            });
            this.dgvCart.Dock = DockStyle.Fill;
            this.dgvCart.RowTemplate.Height = 45;
            this.dgvCart.CellEndEdit += new DataGridViewCellEventHandler(this.DgvCart_CellEndEdit);
            this.dgvCart.CellContentClick += new DataGridViewCellEventHandler(this.DgvCart_CellContentClick);

            // Columns for dgvCart
            this.colCartProductName.HeaderText = "Sản phẩm";
            this.colCartProductName.Name = "colCartProductName";
            this.colCartProductName.FillWeight = 120F;
            this.colCartProductName.ReadOnly = true;

            this.colCartUnit.HeaderText = "ĐVT";
            this.colCartUnit.Name = "colCartUnit";
            this.colCartUnit.FillWeight = 80F;

            this.colCartQuantity.HeaderText = "SL";
            this.colCartQuantity.Name = "colCartQuantity";
            this.colCartQuantity.FillWeight = 60F;
            this.colCartQuantity.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.colCartPrice.HeaderText = "Đơn giá";
            this.colCartPrice.Name = "colCartPrice";
            this.colCartPrice.FillWeight = 90F;
            this.colCartPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.colCartTotal.HeaderText = "Thành tiền";
            this.colCartTotal.Name = "colCartTotal";
            this.colCartTotal.FillWeight = 100F;
            this.colCartTotal.ReadOnly = true;
            this.colCartTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.colCartDelete.HeaderText = "";
            this.colCartDelete.Name = "colCartDelete";
            this.colCartDelete.FillWeight = 50F;
            this.colCartDelete.Text = "🗑️";
            this.colCartDelete.UseColumnTextForButtonValue = true;

            // pnlPayment
            this.pnlPayment.Controls.Add(this.chkGhiNo);
            this.pnlPayment.Controls.Add(this.txtTienThua);
            this.pnlPayment.Controls.Add(this.lblTienThua);
            this.pnlPayment.Controls.Add(this.txtTienKhachDua);
            this.pnlPayment.Controls.Add(this.lblTienKhachDua);
            this.pnlPayment.Controls.Add(this.txtTongTien);
            this.pnlPayment.Controls.Add(this.lblTongTien);
            this.pnlPayment.Dock = DockStyle.Bottom;
            this.pnlPayment.Location = new Point(10, 560);
            this.pnlPayment.Size = new Size(580, 160);
            this.pnlPayment.Padding = new Padding(10);

            int yPos = 10;

            this.lblTongTien.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTongTien.Location = new Point(10, yPos);
            this.lblTongTien.Size = new Size(150, 35);
            this.lblTongTien.Text = "Tổng tiền:";
            this.lblTongTien.TextAlign = ContentAlignment.MiddleLeft;

            this.txtTongTien.BorderRadius = 8;
            this.txtTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.txtTongTien.Location = new Point(160, yPos);
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new Size(410, 35);
            this.txtTongTien.Text = "0";
            this.txtTongTien.TextAlign = HorizontalAlignment.Right;

            yPos += 40;

            this.lblTienKhachDua.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTienKhachDua.Location = new Point(10, yPos);
            this.lblTienKhachDua.Size = new Size(150, 35);
            this.lblTienKhachDua.Text = "Tiền khách đưa:";
            this.lblTienKhachDua.TextAlign = ContentAlignment.MiddleLeft;

            this.txtTienKhachDua.BorderRadius = 8;
            this.txtTienKhachDua.Font = new Font("Segoe UI", 12F);
            this.txtTienKhachDua.Location = new Point(160, yPos);
            this.txtTienKhachDua.Size = new Size(410, 35);
            this.txtTienKhachDua.Text = "0";
            this.txtTienKhachDua.TextAlign = HorizontalAlignment.Right;
            this.txtTienKhachDua.TextChanged += new EventHandler(this.TxtTienKhachDua_TextChanged);

            yPos += 40;

            this.lblTienThua.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTienThua.Location = new Point(10, yPos);
            this.lblTienThua.Size = new Size(150, 35);
            this.lblTienThua.Text = "Tiền thừa:";
            this.lblTienThua.TextAlign = ContentAlignment.MiddleLeft;

            this.txtTienThua.BorderRadius = 8;
            this.txtTienThua.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.txtTienThua.ForeColor = Color.Green;
            this.txtTienThua.Location = new Point(160, yPos);
            this.txtTienThua.ReadOnly = true;
            this.txtTienThua.Size = new Size(410, 35);
            this.txtTienThua.Text = "0";
            this.txtTienThua.TextAlign = HorizontalAlignment.Right;

            yPos += 40;

            this.chkGhiNo.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            this.chkGhiNo.CheckedState.BorderRadius = 2;
            this.chkGhiNo.CheckedState.BorderThickness = 0;
            this.chkGhiNo.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            this.chkGhiNo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.chkGhiNo.Location = new Point(160, yPos);
            this.chkGhiNo.Size = new Size(200, 25);
            this.chkGhiNo.Text = "💳 Cho phép ghi nợ";
            this.chkGhiNo.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            this.chkGhiNo.UncheckedState.BorderRadius = 2;
            this.chkGhiNo.UncheckedState.BorderThickness = 2;
            this.chkGhiNo.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);

            // pnlActions
            this.pnlActions.Controls.Add(this.btnHuy);
            this.pnlActions.Controls.Add(this.btnThanhToan);
            this.pnlActions.Dock = DockStyle.Bottom;
            this.pnlActions.Location = new Point(10, 720);
            this.pnlActions.Size = new Size(580, 70);
            this.pnlActions.Padding = new Padding(10);

            this.btnThanhToan.BorderRadius = 10;
            this.btnThanhToan.Dock = DockStyle.Right;
            this.btnThanhToan.FillColor = Color.FromArgb(0, 150, 120);
            this.btnThanhToan.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnThanhToan.ForeColor = Color.White;
            this.btnThanhToan.Location = new Point(280, 10);
            this.btnThanhToan.Size = new Size(290, 50);
            this.btnThanhToan.Text = "✅ THANH TOÁN";
            this.btnThanhToan.Click += new EventHandler(this.BtnThanhToan_Click);

            this.btnHuy.BorderRadius = 10;
            this.btnHuy.Dock = DockStyle.Left;
            this.btnHuy.FillColor = Color.FromArgb(231, 76, 60);
            this.btnHuy.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnHuy.ForeColor = Color.White;
            this.btnHuy.Location = new Point(10, 10);
            this.btnHuy.Size = new Size(260, 50);
            this.btnHuy.Text = "❌ HỦY";
            this.btnHuy.Click += new EventHandler(this.BtnHuy_Click);

            // ===================================================================
            // Form
            // ===================================================================
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1400, 800);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "POSDialog";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Bán hàng - POS";

            this.pnlMain.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlLeftHeader.ResumeLayout(false);
            this.pnlProductList.ResumeLayout(false);
            this.pnlRightHeader.ResumeLayout(false);
            this.pnlCustomerInfo.ResumeLayout(false);
            this.pnlCart.ResumeLayout(false);
            this.pnlPayment.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
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