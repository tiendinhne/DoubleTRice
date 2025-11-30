using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    partial class POSForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlMain = new Guna2Panel();
            this.pnlLeft = new Guna2Panel();
            this.pnlRight = new Guna2Panel();

            // Left panels
            this.pnlCustomerInfo = new Guna2Panel();
            this.pnlProducts = new Guna2Panel();
            this.pnlCart = new Guna2Panel();

            // Right panels
            this.pnlSummary = new Guna2Panel();
            this.pnlPayment = new Guna2Panel();

            // Customer Info Controls
            this.lblCustomerTitle = new Label();
            this.txtCustomerPhone = new Guna2TextBox();
            this.lblCustomerName = new Label();
            this.btnSearchCustomer = new Guna2Button();
            this.btnNewCustomer = new Guna2Button();

            // Product Controls
            this.lblProductsTitle = new Label();
            this.txtSearchProduct = new Guna2TextBox();
            this.flpProducts = new FlowLayoutPanel();

            // Cart Controls
            this.lblCartTitle = new Label();
            this.dgvCart = new Guna2DataGridView();
            this.colProductName = new DataGridViewTextBoxColumn();
            this.colUnitName = new DataGridViewTextBoxColumn();
            this.colQuantity = new DataGridViewTextBoxColumn();
            this.colUnitPrice = new DataGridViewTextBoxColumn();
            this.colTotal = new DataGridViewTextBoxColumn();
            this.colDelete = new DataGridViewButtonColumn();

            // Summary Controls
            this.lblSummaryTitle = new Label();
            this.lblSubTotal = new Label();
            this.lblSubTotalValue = new Label();
            this.lblDiscount = new Label();
            this.txtDiscount = new Guna2TextBox();
            this.lblGrandTotal = new Label();
            this.lblGrandTotalValue = new Label();

            // Payment Controls
            this.lblPaymentTitle = new Label();
            this.rdoCash = new RadioButton();
            this.rdoTransfer = new RadioButton();
            this.rdoDebt = new RadioButton();
            this.lblAmountPaid = new Label();
            this.txtAmountPaid = new Guna2TextBox();
            this.lblChange = new Label();
            this.lblChangeValue = new Label();
            this.btnCompletePayment = new Guna2Button();
            this.btnCancelOrder = new Guna2Button();

            this.pnlMain.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlCustomerInfo.SuspendLayout();
            this.pnlProducts.SuspendLayout();
            this.pnlCart.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();

            // ===============================================
            // pnlMain
            // ===============================================
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Location = new Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new Size(1050, 626);

            // ===============================================
            // pnlLeft (Customer + Products + Cart)
            // ===============================================
            this.pnlLeft.Controls.Add(this.pnlCart);
            this.pnlLeft.Controls.Add(this.pnlProducts);
            this.pnlLeft.Controls.Add(this.pnlCustomerInfo);
            this.pnlLeft.Dock = DockStyle.Left;
            this.pnlLeft.Location = new Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new Padding(10);
            this.pnlLeft.Size = new Size(700, 626);

            // ===============================================
            // pnlRight (Summary + Payment)
            // ===============================================
            this.pnlRight.Controls.Add(this.pnlPayment);
            this.pnlRight.Controls.Add(this.pnlSummary);
            this.pnlRight.Dock = DockStyle.Fill;
            this.pnlRight.Location = new Point(700, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new Padding(10);
            this.pnlRight.Size = new Size(350, 626);

            // ===============================================
            // pnlCustomerInfo
            // ===============================================
            this.pnlCustomerInfo.BorderRadius = 10;
            this.pnlCustomerInfo.Controls.Add(this.btnNewCustomer);
            this.pnlCustomerInfo.Controls.Add(this.btnSearchCustomer);
            this.pnlCustomerInfo.Controls.Add(this.lblCustomerName);
            this.pnlCustomerInfo.Controls.Add(this.txtCustomerPhone);
            this.pnlCustomerInfo.Controls.Add(this.lblCustomerTitle);
            this.pnlCustomerInfo.Dock = DockStyle.Top;
            this.pnlCustomerInfo.FillColor = Color.FromArgb(240, 248, 255);
            this.pnlCustomerInfo.Location = new Point(10, 10);
            this.pnlCustomerInfo.Name = "pnlCustomerInfo";
            this.pnlCustomerInfo.Padding = new Padding(15);
            this.pnlCustomerInfo.Size = new Size(680, 120);

            this.lblCustomerTitle.Dock = DockStyle.Top;
            this.lblCustomerTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblCustomerTitle.ForeColor = Color.FromArgb(0, 100, 180);
            this.lblCustomerTitle.Location = new Point(15, 15);
            this.lblCustomerTitle.Size = new Size(650, 25);
            this.lblCustomerTitle.Text = "👤 THÔNG TIN KHÁCH HÀNG";

            this.txtCustomerPhone.BorderRadius = 8;
            this.txtCustomerPhone.Location = new Point(15, 50);
            this.txtCustomerPhone.PlaceholderText = "Nhập số điện thoại khách hàng...";
            this.txtCustomerPhone.Size = new Size(400, 40);
            this.txtCustomerPhone.TextChanged += new EventHandler(this.TxtCustomerPhone_TextChanged);

            this.btnSearchCustomer.BorderRadius = 8;
            this.btnSearchCustomer.FillColor = Color.FromArgb(0, 150, 120);
            this.btnSearchCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnSearchCustomer.ForeColor = Color.White;
            this.btnSearchCustomer.Location = new Point(425, 50);
            this.btnSearchCustomer.Size = new Size(120, 40);
            this.btnSearchCustomer.Text = "🔍 Tìm";
            this.btnSearchCustomer.Click += new EventHandler(this.BtnSearchCustomer_Click);

            this.btnNewCustomer.BorderRadius = 8;
            this.btnNewCustomer.FillColor = Color.FromArgb(52, 152, 219);
            this.btnNewCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnNewCustomer.ForeColor = Color.White;
            this.btnNewCustomer.Location = new Point(555, 50);
            this.btnNewCustomer.Size = new Size(110, 40);
            this.btnNewCustomer.Text = "➕ Mới";
            this.btnNewCustomer.Click += new EventHandler(this.BtnNewCustomer_Click);

            this.lblCustomerName.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblCustomerName.ForeColor = Color.FromArgb(0, 150, 120);
            this.lblCustomerName.Location = new Point(15, 95);
            this.lblCustomerName.Size = new Size(650, 20);
            this.lblCustomerName.Text = "Khách vãng lai";

            // ===============================================
            // pnlProducts
            // ===============================================
            this.pnlProducts.BorderRadius = 10;
            this.pnlProducts.Controls.Add(this.flpProducts);
            this.pnlProducts.Controls.Add(this.txtSearchProduct);
            this.pnlProducts.Controls.Add(this.lblProductsTitle);
            this.pnlProducts.Dock = DockStyle.Top;
            this.pnlProducts.FillColor = Color.FromArgb(250, 250, 250);
            this.pnlProducts.Location = new Point(10, 130);
            this.pnlProducts.Name = "pnlProducts";
            this.pnlProducts.Padding = new Padding(15);
            this.pnlProducts.Size = new Size(680, 200);

            this.lblProductsTitle.Dock = DockStyle.Top;
            this.lblProductsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblProductsTitle.ForeColor = Color.FromArgb(220, 53, 69);
            this.lblProductsTitle.Location = new Point(15, 15);
            this.lblProductsTitle.Size = new Size(650, 25);
            this.lblProductsTitle.Text = "🌾 CHỌN SẢN PHẨM";

            this.txtSearchProduct.BorderRadius = 8;
            this.txtSearchProduct.Dock = DockStyle.Top;
            this.txtSearchProduct.Location = new Point(15, 40);
            this.txtSearchProduct.PlaceholderText = "🔍 Tìm kiếm sản phẩm...";
            this.txtSearchProduct.Size = new Size(650, 36);
            this.txtSearchProduct.TextChanged += new EventHandler(this.TxtSearchProduct_TextChanged);

            this.flpProducts.AutoScroll = true;
            this.flpProducts.Dock = DockStyle.Fill;
            this.flpProducts.Location = new Point(15, 76);
            this.flpProducts.Size = new Size(650, 109);
            this.flpProducts.Padding = new Padding(5);

            // ===============================================
            // pnlCart
            // ===============================================
            this.pnlCart.BorderRadius = 10;
            this.pnlCart.Controls.Add(this.dgvCart);
            this.pnlCart.Controls.Add(this.lblCartTitle);
            this.pnlCart.Dock = DockStyle.Fill;
            this.pnlCart.FillColor = Color.White;
            this.pnlCart.Location = new Point(10, 330);
            this.pnlCart.Name = "pnlCart";
            this.pnlCart.Padding = new Padding(15);
            this.pnlCart.Size = new Size(680, 286);

            this.lblCartTitle.Dock = DockStyle.Top;
            this.lblCartTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblCartTitle.ForeColor = Color.FromArgb(0, 150, 120);
            this.lblCartTitle.Location = new Point(15, 15);
            this.lblCartTitle.Size = new Size(650, 25);
            this.lblCartTitle.Text = "🛒 GIỎ HÀNG";

            // dgvCart
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            this.dgvCart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 150, 120);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            this.dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCart.ColumnHeadersHeight = 35;
            this.dgvCart.Columns.AddRange(new DataGridViewColumn[] {
                this.colProductName, this.colUnitName, this.colQuantity,
                this.colUnitPrice, this.colTotal, this.colDelete
            });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            this.dgvCart.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCart.Dock = DockStyle.Fill;
            this.dgvCart.Location = new Point(15, 40);
            this.dgvCart.RowTemplate.Height = 40;
            this.dgvCart.Size = new Size(650, 231);
            this.dgvCart.CellValueChanged += new DataGridViewCellEventHandler(this.DgvCart_CellValueChanged);
            this.dgvCart.CellContentClick += new DataGridViewCellEventHandler(this.DgvCart_CellContentClick);

            // Columns
            this.colProductName.HeaderText = "Sản phẩm";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.FillWeight = 120F;

            this.colUnitName.HeaderText = "ĐVT";
            this.colUnitName.Name = "colUnitName";
            this.colUnitName.ReadOnly = true;
            this.colUnitName.FillWeight = 70F;

            this.colQuantity.HeaderText = "SL";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.FillWeight = 60F;
            this.colQuantity.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.colUnitPrice.HeaderText = "Đơn giá";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.FillWeight = 90F;
            this.colUnitPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.colTotal.HeaderText = "Thành tiền";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.FillWeight = 100F;
            this.colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.colDelete.HeaderText = "";
            this.colDelete.Name = "colDelete";
            this.colDelete.FillWeight = 50F;
            this.colDelete.Text = "🗑️";
            this.colDelete.UseColumnTextForButtonValue = true;

            // ===============================================
            // pnlSummary
            // ===============================================
            this.pnlSummary.BorderRadius = 10;
            this.pnlSummary.Controls.Add(this.lblGrandTotalValue);
            this.pnlSummary.Controls.Add(this.lblGrandTotal);
            this.pnlSummary.Controls.Add(this.txtDiscount);
            this.pnlSummary.Controls.Add(this.lblDiscount);
            this.pnlSummary.Controls.Add(this.lblSubTotalValue);
            this.pnlSummary.Controls.Add(this.lblSubTotal);
            this.pnlSummary.Controls.Add(this.lblSummaryTitle);
            this.pnlSummary.Dock = DockStyle.Top;
            this.pnlSummary.FillColor = Color.FromArgb(240, 248, 255);
            this.pnlSummary.Location = new Point(10, 10);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Padding = new Padding(15);
            this.pnlSummary.Size = new Size(330, 220);

            this.lblSummaryTitle.Dock = DockStyle.Top;
            this.lblSummaryTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblSummaryTitle.ForeColor = Color.FromArgb(0, 100, 180);
            this.lblSummaryTitle.Location = new Point(15, 15);
            this.lblSummaryTitle.Size = new Size(300, 25);
            this.lblSummaryTitle.Text = "💰 TỔNG TIỀN";

            int yPos = 50;
            this.lblSubTotal.Font = new Font("Segoe UI", 10F);
            this.lblSubTotal.Location = new Point(15, yPos);
            this.lblSubTotal.Size = new Size(150, 25);
            this.lblSubTotal.Text = "Tạm tính:";

            this.lblSubTotalValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblSubTotalValue.ForeColor = Color.FromArgb(0, 150, 120);
            this.lblSubTotalValue.Location = new Point(165, yPos);
            this.lblSubTotalValue.Size = new Size(150, 25);
            this.lblSubTotalValue.Text = "0 đ";
            this.lblSubTotalValue.TextAlign = ContentAlignment.MiddleRight;

            yPos += 40;
            this.lblDiscount.Font = new Font("Segoe UI", 10F);
            this.lblDiscount.Location = new Point(15, yPos);
            this.lblDiscount.Size = new Size(150, 25);
            this.lblDiscount.Text = "Giảm giá:";

            this.txtDiscount.BorderRadius = 8;
            this.txtDiscount.Location = new Point(165, yPos - 5);
            this.txtDiscount.PlaceholderText = "0";
            this.txtDiscount.Size = new Size(150, 35);
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextChanged += new EventHandler(this.TxtDiscount_TextChanged);

            yPos += 50;
            this.lblGrandTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblGrandTotal.Location = new Point(15, yPos);
            this.lblGrandTotal.Size = new Size(150, 30);
            this.lblGrandTotal.Text = "TỔNG CỘNG:";

            this.lblGrandTotalValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblGrandTotalValue.ForeColor = Color.FromArgb(220, 53, 69);
            this.lblGrandTotalValue.Location = new Point(165, yPos);
            this.lblGrandTotalValue.Size = new Size(150, 30);
            this.lblGrandTotalValue.Text = "0 đ";
            this.lblGrandTotalValue.TextAlign = ContentAlignment.MiddleRight;

            // ===============================================
            // pnlPayment
            // ===============================================
            this.pnlPayment.BorderRadius = 10;
            this.pnlPayment.Controls.Add(this.btnCancelOrder);
            this.pnlPayment.Controls.Add(this.btnCompletePayment);
            this.pnlPayment.Controls.Add(this.lblChangeValue);
            this.pnlPayment.Controls.Add(this.lblChange);
            this.pnlPayment.Controls.Add(this.txtAmountPaid);
            this.pnlPayment.Controls.Add(this.lblAmountPaid);
            this.pnlPayment.Controls.Add(this.rdoDebt);
            this.pnlPayment.Controls.Add(this.rdoTransfer);
            this.pnlPayment.Controls.Add(this.rdoCash);
            this.pnlPayment.Controls.Add(this.lblPaymentTitle);
            this.pnlPayment.Dock = DockStyle.Fill;
            this.pnlPayment.FillColor = Color.White;
            this.pnlPayment.Location = new Point(10, 230);
            this.pnlPayment.Name = "pnlPayment";
            this.pnlPayment.Padding = new Padding(15);
            this.pnlPayment.Size = new Size(330, 386);

            this.lblPaymentTitle.Dock = DockStyle.Top;
            this.lblPaymentTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblPaymentTitle.ForeColor = Color.FromArgb(0, 150, 120);
            this.lblPaymentTitle.Location = new Point(15, 15);
            this.lblPaymentTitle.Size = new Size(300, 25);
            this.lblPaymentTitle.Text = "💳 THANH TOÁN";

            yPos = 50;
            this.rdoCash.Checked = true;
            this.rdoCash.Font = new Font("Segoe UI", 9F);
            this.rdoCash.Location = new Point(15, yPos);
            this.rdoCash.Size = new Size(120, 30);
            this.rdoCash.Text = "💵 Tiền mặt";
            this.rdoCash.CheckedChanged += new EventHandler(this.RdoPayment_CheckedChanged);

            this.rdoTransfer.Font = new Font("Segoe UI", 9F);
            this.rdoTransfer.Location = new Point(140, yPos);
            this.rdoTransfer.Size = new Size(130, 30);
            this.rdoTransfer.Text = "🏦 Chuyển khoản";
            this.rdoTransfer.CheckedChanged += new EventHandler(this.RdoPayment_CheckedChanged);

            yPos += 35;
            this.rdoDebt.Font = new Font("Segoe UI", 9F);
            this.rdoDebt.Location = new Point(15, yPos);
            this.rdoDebt.Size = new Size(120, 30);
            this.rdoDebt.Text = "📝 Ghi nợ";
            this.rdoDebt.CheckedChanged += new EventHandler(this.RdoPayment_CheckedChanged);

            yPos += 45;
            this.lblAmountPaid.Font = new Font("Segoe UI", 10F);
            this.lblAmountPaid.Location = new Point(15, yPos);
            this.lblAmountPaid.Size = new Size(300, 25);
            this.lblAmountPaid.Text = "Tiền khách đưa:";

            this.txtAmountPaid.BorderRadius = 8;
            this.txtAmountPaid.Font = new Font("Segoe UI", 11F);
            this.txtAmountPaid.Location = new Point(15, yPos + 30);
            this.txtAmountPaid.PlaceholderText = "Nhập số tiền...";
            this.txtAmountPaid.Size = new Size(300, 40);
            this.txtAmountPaid.Text = "0";
            this.txtAmountPaid.TextChanged += new EventHandler(this.TxtAmountPaid_TextChanged);

            yPos += 80;
            this.lblChange.Font = new Font("Segoe UI", 10F);
            this.lblChange.Location = new Point(15, yPos);
            this.lblChange.Size = new Size(150, 25);
            this.lblChange.Text = "Tiền thừa:";

            this.lblChangeValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblChangeValue.ForeColor = Color.FromArgb(52, 152, 219);
            this.lblChangeValue.Location = new Point(165, yPos);
            this.lblChangeValue.Size = new Size(150, 25);
            this.lblChangeValue.Text = "0 đ";
            this.lblChangeValue.TextAlign = ContentAlignment.MiddleRight;

            yPos += 50;
            this.btnCompletePayment.BorderRadius = 10;
            this.btnCompletePayment.FillColor = Color.FromArgb(0, 150, 120);
            this.btnCompletePayment.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnCompletePayment.ForeColor = Color.White;
            this.btnCompletePayment.Location = new Point(15, yPos);
            this.btnCompletePayment.Size = new Size(300, 50);
            this.btnCompletePayment.Text = "✅ THANH TOÁN";
            this.btnCompletePayment.Click += new EventHandler(this.BtnCompletePayment_Click);

            yPos += 60;
            this.btnCancelOrder.BorderRadius = 10;
            this.btnCancelOrder.FillColor = Color.FromArgb(220, 53, 69);
            this.btnCancelOrder.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCancelOrder.ForeColor = Color.White;
            this.btnCancelOrder.Location = new Point(15, yPos);
            this.btnCancelOrder.Size = new Size(300, 45);
            this.btnCancelOrder.Text = "❌ Hủy đơn";
            this.btnCancelOrder.Click += new EventHandler(this.BtnCancelOrder_Click);

            // ===============================================
            // Form
            // ===============================================
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1050, 626);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "POSForm";
            this.Text = "Bán hàng - POS";

            this.pnlMain.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlCustomerInfo.ResumeLayout(false);
            this.pnlProducts.ResumeLayout(false);
            this.pnlCart.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            this.pnlPayment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna2Panel pnlMain;
        private Guna2Panel pnlLeft;
        private Guna2Panel pnlRight;
        private Guna2Panel pnlCustomerInfo;
        private Guna2Panel pnlProducts;
        private Guna2Panel pnlCart;
        private Guna2Panel pnlSummary;
        private Guna2Panel pnlPayment;

        private Label lblCustomerTitle;
        private Guna2TextBox txtCustomerPhone;
        private Label lblCustomerName;
        private Guna2Button btnSearchCustomer;
        private Guna2Button btnNewCustomer;

        private Label lblProductsTitle;
        private Guna2TextBox txtSearchProduct;
        private FlowLayoutPanel flpProducts;

        private Label lblCartTitle;
        private Guna2DataGridView dgvCart;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colUnitName;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colUnitPrice;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewButtonColumn colDelete;

        private Label lblSummaryTitle;
        private Label lblSubTotal;
        private Label lblSubTotalValue;
        private Label lblDiscount;
        private Guna2TextBox txtDiscount;
        private Label lblGrandTotal;
        private Label lblGrandTotalValue;

        private Label lblPaymentTitle;
        private RadioButton rdoCash;
        private RadioButton rdoTransfer;
        private RadioButton rdoDebt;
        private Label lblAmountPaid;
        private Guna2TextBox txtAmountPaid;
        private Label lblChange;
        private Label lblChangeValue;
        private Guna2Button btnCompletePayment;
        private Guna2Button btnCancelOrder;
    }
}