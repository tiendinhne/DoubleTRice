using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    partial class DebtDetailDialog
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();

            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.tabControl = new TabControl();
            this.tabUnpaidInvoices = new TabPage();
            this.dgvUnpaidInvoices = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colInvoiceID = new DataGridViewTextBoxColumn();
            this.colMaHoaDon = new DataGridViewTextBoxColumn();
            this.colNgayBan = new DataGridViewTextBoxColumn();
            this.colTongTien = new DataGridViewTextBoxColumn();
            this.colDaTra = new DataGridViewTextBoxColumn();
            this.colConLai = new DataGridViewTextBoxColumn();
            this.colPayAction = new DataGridViewButtonColumn();
            this.tabPaymentHistory = new TabPage();
            this.dgvPaymentHistory = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colPaymentID = new DataGridViewTextBoxColumn();
            this.colPaymentInvoice = new DataGridViewTextBoxColumn();
            this.colPaymentDate = new DataGridViewTextBoxColumn();
            this.colPaymentAmount = new DataGridViewTextBoxColumn();
            this.colPaymentMethod = new DataGridViewTextBoxColumn();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCongNo = new Label();
            this.lblTongDaTra = new Label();
            this.lblTongMuaHang = new Label();
            this.lblCustomerPhone = new Label();
            this.lblCustomerName = new Label();
            this.pnlActions = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrint = new Guna.UI2.WinForms.Guna2Button();
            this.btnThanhToanTatCa = new Guna.UI2.WinForms.Guna2Button();

            this.pnlMain.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabUnpaidInvoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnpaidInvoices)).BeginInit();
            this.tabPaymentHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistory)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();

            // pnlMain
            this.pnlMain.Controls.Add(this.tabControl);
            this.pnlMain.Controls.Add(this.pnlActions);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.FillColor = Color.White;
            this.pnlMain.Size = new Size(900, 700);

            // pnlHeader
            this.pnlHeader.Controls.Add(this.lblCongNo);
            this.pnlHeader.Controls.Add(this.lblTongDaTra);
            this.pnlHeader.Controls.Add(this.lblTongMuaHang);
            this.pnlHeader.Controls.Add(this.lblCustomerPhone);
            this.pnlHeader.Controls.Add(this.lblCustomerName);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.FillColor = Color.FromArgb(240, 248, 255);
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Padding = new Padding(20, 15, 20, 15);
            this.pnlHeader.Size = new Size(900, 140);

            int yPos = 15;
            int spacing = 25;

            this.lblCustomerName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblCustomerName.Location = new Point(20, yPos);
            this.lblCustomerName.Size = new Size(860, 30);
            this.lblCustomerName.Text = "Khách hàng: ...";

            yPos += spacing;
            this.lblCustomerPhone.Font = new Font("Segoe UI", 10F);
            this.lblCustomerPhone.Location = new Point(20, yPos);
            this.lblCustomerPhone.Size = new Size(860, 25);
            this.lblCustomerPhone.Text = "SĐT: ...";

            yPos += spacing + 5;
            this.lblTongMuaHang.Font = new Font("Segoe UI", 10F);
            this.lblTongMuaHang.Location = new Point(20, yPos);
            this.lblTongMuaHang.Size = new Size(400, 25);
            this.lblTongMuaHang.Text = "Tổng mua hàng: 0 đ";

            this.lblTongDaTra.Font = new Font("Segoe UI", 10F);
            this.lblTongDaTra.ForeColor = Color.Green;
            this.lblTongDaTra.Location = new Point(450, yPos);
            this.lblTongDaTra.Size = new Size(430, 25);
            this.lblTongDaTra.Text = "Đã trả: 0 đ";

            yPos += spacing;
            this.lblCongNo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblCongNo.ForeColor = Color.Red;
            this.lblCongNo.Location = new Point(20, yPos);
            this.lblCongNo.Size = new Size(860, 30);
            this.lblCongNo.Text = "Công nợ: 0 đ";

            // tabControl
            this.tabControl.Controls.Add(this.tabUnpaidInvoices);
            this.tabControl.Controls.Add(this.tabPaymentHistory);
            this.tabControl.Dock = DockStyle.Fill;
            this.tabControl.Font = new Font("Segoe UI", 10F);
            this.tabControl.Location = new Point(0, 140);
            this.tabControl.Size = new Size(900, 490);

            // tabUnpaidInvoices
            this.tabUnpaidInvoices.Controls.Add(this.dgvUnpaidInvoices);
            this.tabUnpaidInvoices.Location = new Point(4, 29);
            this.tabUnpaidInvoices.Padding = new Padding(10);
            this.tabUnpaidInvoices.Size = new Size(892, 457);
            this.tabUnpaidInvoices.Text = "📋 Hóa đơn chưa thanh toán";

            // dgvUnpaidInvoices
            this.dgvUnpaidInvoices.AllowUserToAddRows = false;
            this.dgvUnpaidInvoices.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            this.dgvUnpaidInvoices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(231, 76, 60);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            this.dgvUnpaidInvoices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUnpaidInvoices.ColumnHeadersHeight = 40;
            this.dgvUnpaidInvoices.Columns.AddRange(new DataGridViewColumn[] {
            this.colInvoiceID,
            this.colMaHoaDon,
            this.colNgayBan,
            this.colTongTien,
            this.colDaTra,
            this.colConLai,
            this.colPayAction});
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            this.dgvUnpaidInvoices.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUnpaidInvoices.Dock = DockStyle.Fill;
            this.dgvUnpaidInvoices.GridColor = Color.FromArgb(231, 229, 255);
            this.dgvUnpaidInvoices.RowHeadersVisible = false;
            this.dgvUnpaidInvoices.RowTemplate.Height = 40;
            this.dgvUnpaidInvoices.CellContentClick += new DataGridViewCellEventHandler(this.DgvUnpaidInvoices_CellContentClick);
            this.dgvUnpaidInvoices.CellDoubleClick += new DataGridViewCellEventHandler(this.DgvUnpaidInvoices_CellDoubleClick);

            this.colInvoiceID.HeaderText = "ID";
            this.colInvoiceID.Name = "colInvoiceID";
            this.colInvoiceID.ReadOnly = true;
            this.colInvoiceID.Visible = false;

            this.colMaHoaDon.HeaderText = "Mã hóa đơn";
            this.colMaHoaDon.Name = "colMaHoaDon";
            this.colMaHoaDon.ReadOnly = true;

            this.colNgayBan.HeaderText = "Ngày bán";
            this.colNgayBan.Name = "colNgayBan";
            this.colNgayBan.ReadOnly = true;

            this.colTongTien.HeaderText = "Tổng tiền";
            this.colTongTien.Name = "colTongTien";
            this.colTongTien.ReadOnly = true;

            this.colDaTra.HeaderText = "Đã trả";
            this.colDaTra.Name = "colDaTra";
            this.colDaTra.ReadOnly = true;

            this.colConLai.HeaderText = "Còn lại";
            this.colConLai.Name = "colConLai";
            this.colConLai.ReadOnly = true;

            this.colPayAction.HeaderText = "Thanh toán";
            this.colPayAction.Name = "colPayAction";
            this.colPayAction.Text = "💰 Trả";
            this.colPayAction.UseColumnTextForButtonValue = true;

            // tabPaymentHistory
            this.tabPaymentHistory.Controls.Add(this.dgvPaymentHistory);
            this.tabPaymentHistory.Location = new Point(4, 29);
            this.tabPaymentHistory.Padding = new Padding(10);
            this.tabPaymentHistory.Size = new Size(892, 457);
            this.tabPaymentHistory.Text = "📜 Lịch sử thanh toán";

            // dgvPaymentHistory
            this.dgvPaymentHistory.AllowUserToAddRows = false;
            this.dgvPaymentHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = Color.White;
            this.dgvPaymentHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            this.dgvPaymentHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPaymentHistory.ColumnHeadersHeight = 40;
            this.dgvPaymentHistory.Columns.AddRange(new DataGridViewColumn[] {
            this.colPaymentID,
            this.colPaymentInvoice,
            this.colPaymentDate,
            this.colPaymentAmount,
            this.colPaymentMethod});
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            this.dgvPaymentHistory.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPaymentHistory.Dock = DockStyle.Fill;
            this.dgvPaymentHistory.GridColor = Color.FromArgb(231, 229, 255);
            this.dgvPaymentHistory.ReadOnly = true;
            this.dgvPaymentHistory.RowHeadersVisible = false;
            this.dgvPaymentHistory.RowTemplate.Height = 40;

            this.colPaymentID.HeaderText = "ID";
            this.colPaymentID.Name = "colPaymentID";
            this.colPaymentID.Visible = false;

            this.colPaymentInvoice.HeaderText = "Hóa đơn";
            this.colPaymentInvoice.Name = "colPaymentInvoice";

            this.colPaymentDate.HeaderText = "Ngày thanh toán";
            this.colPaymentDate.Name = "colPaymentDate";

            this.colPaymentAmount.HeaderText = "Số tiền";
            this.colPaymentAmount.Name = "colPaymentAmount";

            this.colPaymentMethod.HeaderText = "Phương thức";
            this.colPaymentMethod.Name = "colPaymentMethod";

            // pnlActions
            this.pnlActions.Controls.Add(this.btnClose);
            this.pnlActions.Controls.Add(this.btnPrint);
            this.pnlActions.Controls.Add(this.btnThanhToanTatCa);
            this.pnlActions.Dock = DockStyle.Bottom;
            this.pnlActions.FillColor = Color.FromArgb(240, 248, 255);
            this.pnlActions.Location = new Point(0, 630);
            this.pnlActions.Padding = new Padding(20, 15, 20, 15);
            this.pnlActions.Size = new Size(900, 70);

            this.btnThanhToanTatCa.BorderRadius = 10;
            this.btnThanhToanTatCa.FillColor = Color.FromArgb(46, 204, 113);
            this.btnThanhToanTatCa.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnThanhToanTatCa.ForeColor = Color.White;
            this.btnThanhToanTatCa.Location = new Point(20, 15);
            this.btnThanhToanTatCa.Size = new Size(250, 40);
            this.btnThanhToanTatCa.Text = "💰 Thanh toán tất cả";
            this.btnThanhToanTatCa.Click += new EventHandler(this.BtnThanhToanTatCa_Click);

            this.btnPrint.BorderRadius = 10;
            this.btnPrint.FillColor = Color.FromArgb(52, 152, 219);
            this.btnPrint.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnPrint.ForeColor = Color.White;
            this.btnPrint.Location = new Point(280, 15);
            this.btnPrint.Size = new Size(250, 40);
            this.btnPrint.Text = "🖨️ In báo cáo";
            this.btnPrint.Click += new EventHandler(this.BtnPrint_Click);

            this.btnClose.BorderRadius = 10;
            this.btnClose.FillColor = Color.FromArgb(149, 165, 166);
            this.btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Location = new Point(630, 15);
            this.btnClose.Size = new Size(250, 40);
            this.btnClose.Text = "❌ Đóng";
            this.btnClose.Click += new EventHandler(this.BtnClose_Click);

            // Form
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            this.ClientSize = new Size(900, 700);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DebtDetailDialog";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Chi tiết Công Nợ";
            this.pnlMain.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabUnpaidInvoices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnpaidInvoices)).EndInit();
            this.tabPaymentHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistory)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlActions;
        private TabControl tabControl;
        private TabPage tabUnpaidInvoices;
        private TabPage tabPaymentHistory;
        private Label lblCustomerName;
        private Label lblCustomerPhone;
        private Label lblTongMuaHang;
        private Label lblTongDaTra;
        private Label lblCongNo;
        private Guna.UI2.WinForms.Guna2DataGridView dgvUnpaidInvoices;
        private DataGridViewTextBoxColumn colInvoiceID;
        private DataGridViewTextBoxColumn colMaHoaDon;
        private DataGridViewTextBoxColumn colNgayBan;
        private DataGridViewTextBoxColumn colTongTien;
        private DataGridViewTextBoxColumn colDaTra;
        private DataGridViewTextBoxColumn colConLai;
        private DataGridViewButtonColumn colPayAction;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPaymentHistory;
        private DataGridViewTextBoxColumn colPaymentID;
        private DataGridViewTextBoxColumn colPaymentInvoice;
        private DataGridViewTextBoxColumn colPaymentDate;
        private DataGridViewTextBoxColumn colPaymentAmount;
        private DataGridViewTextBoxColumn colPaymentMethod;
        private Guna.UI2.WinForms.Guna2Button btnThanhToanTatCa;
        private Guna.UI2.WinForms.Guna2Button btnPrint;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}