using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    partial class SupplierDebtDetailDialog
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
            this.tabUnpaidReceipts = new TabPage(); // Đổi tên tab
            this.dgvUnpaidReceipts = new Guna.UI2.WinForms.Guna2DataGridView(); // Đổi tên DataGridView
            this.colReceiptID = new DataGridViewTextBoxColumn(); // Đổi tên cột
            this.colMaPhieuNhap = new DataGridViewTextBoxColumn(); // Đổi tên cột
            this.colNgayNhap = new DataGridViewTextBoxColumn(); // Đổi tên cột
            this.colTongTien = new DataGridViewTextBoxColumn();
            this.colDaTra = new DataGridViewTextBoxColumn();
            this.colConLai = new DataGridViewTextBoxColumn();
            this.colPayAction = new DataGridViewButtonColumn();
            this.tabPaymentHistory = new TabPage();
            this.dgvPaymentHistory = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colPaymentID = new DataGridViewTextBoxColumn();
            this.colPaymentInvoice = new DataGridViewTextBoxColumn(); // Giữ nguyên Invoice vì nó là tên cột chung cho hóa đơn/phiếu nhập
            this.colPaymentDate = new DataGridViewTextBoxColumn();
            this.colPaymentAmount = new DataGridViewTextBoxColumn();
            this.colPaymentMethod = new DataGridViewTextBoxColumn();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCongNo = new Label();
            this.lblTongDaTra = new Label();
            this.lblTongNhapHang = new Label(); // Đổi tên label
            this.lblSupplierPhone = new Label(); // Đổi tên label
            this.lblSupplierName = new Label(); // Đổi tên label
            this.pnlActions = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrint = new Guna.UI2.WinForms.Guna2Button();
            this.btnTraNoTatCa = new Guna.UI2.WinForms.Guna2Button(); // Đổi tên button

            this.pnlMain.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabUnpaidReceipts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnpaidReceipts)).BeginInit();
            this.tabPaymentHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistory)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();

            // pnlMain (Giữ nguyên)
            this.pnlMain.Controls.Add(this.tabControl);
            this.pnlMain.Controls.Add(this.pnlActions);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.FillColor = Color.White;
            this.pnlMain.Size = new Size(900, 700);

            // pnlHeader (Giữ nguyên cấu trúc, đổi tên control)
            this.pnlHeader.Controls.Add(this.lblCongNo);
            this.pnlHeader.Controls.Add(this.lblTongDaTra);
            this.pnlHeader.Controls.Add(this.lblTongNhapHang); // Thay đổi
            this.pnlHeader.Controls.Add(this.lblSupplierPhone); // Thay đổi
            this.pnlHeader.Controls.Add(this.lblSupplierName); // Thay đổi
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.FillColor = Color.FromArgb(240, 248, 255);
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Padding = new Padding(20, 15, 20, 15);
            this.pnlHeader.Size = new Size(900, 140);

            int yPos = 15;
            int spacing = 25;

            // lblSupplierName (Thay đổi Text)
            this.lblSupplierName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblSupplierName.Location = new Point(20, yPos);
            this.lblSupplierName.Size = new Size(860, 30);
            this.lblSupplierName.Text = "Nhà cung cấp: ..."; // THAY ĐỔI

            yPos += spacing;
            // lblSupplierPhone (Thay đổi Text, đổi tên control)
            this.lblSupplierPhone.Font = new Font("Segoe UI", 10F);
            this.lblSupplierPhone.Location = new Point(20, yPos);
            this.lblSupplierPhone.Size = new Size(860, 25);
            this.lblSupplierPhone.Text = "SĐT: ...";

            yPos += spacing + 5;
            // lblTongNhapHang (Thay đổi Text, đổi tên control)
            this.lblTongNhapHang.Font = new Font("Segoe UI", 10F);
            this.lblTongNhapHang.Location = new Point(20, yPos);
            this.lblTongNhapHang.Size = new Size(400, 25);
            this.lblTongNhapHang.Text = "Tổng nhập hàng: 0 đ"; // THAY ĐỔI

            // lblTongDaTra (Giữ nguyên)
            this.lblTongDaTra.Font = new Font("Segoe UI", 10F);
            this.lblTongDaTra.ForeColor = Color.Green;
            this.lblTongDaTra.Location = new Point(450, yPos);
            this.lblTongDaTra.Size = new Size(430, 25);
            this.lblTongDaTra.Text = "Đã trả: 0 đ";

            yPos += spacing;
            // lblCongNo (Thay đổi ForeColor)
            this.lblCongNo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblCongNo.ForeColor = Color.FromArgb(255, 87, 34); // THAY ĐỔI: Màu cam đậm
            this.lblCongNo.Location = new Point(20, yPos);
            this.lblCongNo.Size = new Size(860, 30);
            this.lblCongNo.Text = "Công nợ: 0 đ";

            // tabControl (Giữ nguyên)
            this.tabControl.Controls.Add(this.tabUnpaidReceipts); // Đổi tên tab
            this.tabControl.Controls.Add(this.tabPaymentHistory);
            this.tabControl.Dock = DockStyle.Fill;
            this.tabControl.Font = new Font("Segoe UI", 10F);
            this.tabControl.Location = new Point(0, 140);
            this.tabControl.Size = new Size(900, 490);

            // tabUnpaidReceipts (Đổi tên tab và Text)
            this.tabUnpaidReceipts.Controls.Add(this.dgvUnpaidReceipts); // Đổi tên DataGridView
            this.tabUnpaidReceipts.Location = new Point(4, 29);
            this.tabUnpaidReceipts.Padding = new Padding(10);
            this.tabUnpaidReceipts.Size = new Size(892, 457);
            this.tabUnpaidReceipts.Text = "📋 Phiếu nhập chưa thanh toán"; // THAY ĐỔI

            // dgvUnpaidReceipts (Đổi tên DataGridView và HeaderStyle BackColor)
            this.dgvUnpaidReceipts.AllowUserToAddRows = false;
            this.dgvUnpaidReceipts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            this.dgvUnpaidReceipts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 152, 0); // THAY ĐỔI: Màu Cam
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            this.dgvUnpaidReceipts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUnpaidReceipts.ColumnHeadersHeight = 40;
            this.dgvUnpaidReceipts.Columns.AddRange(new DataGridViewColumn[] {
            this.colReceiptID, // Đổi tên cột
            this.colMaPhieuNhap, // Đổi tên cột
            this.colNgayNhap, // Đổi tên cột
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
            this.dgvUnpaidReceipts.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUnpaidReceipts.Dock = DockStyle.Fill;
            this.dgvUnpaidReceipts.GridColor = Color.FromArgb(231, 229, 255);
            this.dgvUnpaidReceipts.RowHeadersVisible = false;
            this.dgvUnpaidReceipts.RowTemplate.Height = 40;
            this.dgvUnpaidReceipts.CellContentClick += new DataGridViewCellEventHandler(this.DgvUnpaidReceipts_CellContentClick); // Cần đổi tên handler trong code-behind
            this.dgvUnpaidReceipts.CellDoubleClick += new DataGridViewCellEventHandler(this.DgvUnpaidReceipts_CellDoubleClick); // Cần đổi tên handler trong code-behind

            // Cột của dgvUnpaidReceipts
            this.colReceiptID.HeaderText = "ID"; // Đổi tên cột
            this.colReceiptID.Name = "colReceiptID"; // Đổi tên cột
            this.colReceiptID.ReadOnly = true;
            this.colReceiptID.Visible = false;

            this.colMaPhieuNhap.HeaderText = "Mã phiếu nhập"; // THAY ĐỔI
            this.colMaPhieuNhap.Name = "colMaPhieuNhap"; // Đổi tên cột
            this.colMaPhieuNhap.ReadOnly = true;

            this.colNgayNhap.HeaderText = "Ngày nhập"; // THAY ĐỔI
            this.colNgayNhap.Name = "colNgayNhap"; // Đổi tên cột
            this.colNgayNhap.ReadOnly = true;

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
            this.colPayAction.Text = "💰 Trả"; // Giữ nguyên/Xác nhận "Trả"
            this.colPayAction.UseColumnTextForButtonValue = true;

            // tabPaymentHistory (Giữ nguyên Text)
            this.tabPaymentHistory.Controls.Add(this.dgvPaymentHistory);
            this.tabPaymentHistory.Location = new Point(4, 29);
            this.tabPaymentHistory.Padding = new Padding(10);
            this.tabPaymentHistory.Size = new Size(892, 457);
            this.tabPaymentHistory.Text = "📜 Lịch sử thanh toán";

            // dgvPaymentHistory (Giữ nguyên cấu trúc, HeaderStyle BackColor giữ nguyên màu Xanh)
            this.dgvPaymentHistory.AllowUserToAddRows = false;
            this.dgvPaymentHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = Color.White;
            this.dgvPaymentHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(52, 152, 219); // Giữ nguyên: Màu Xanh
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

            // Cột của dgvPaymentHistory (Giữ nguyên)
            this.colPaymentID.HeaderText = "ID";
            this.colPaymentID.Name = "colPaymentID";
            this.colPaymentID.Visible = false;

            this.colPaymentInvoice.HeaderText = "Hóa đơn"; // Giữ nguyên vì có thể dùng chung cho cả hóa đơn và phiếu nhập
            this.colPaymentInvoice.Name = "colPaymentInvoice";

            this.colPaymentDate.HeaderText = "Ngày thanh toán";
            this.colPaymentDate.Name = "colPaymentDate";

            this.colPaymentAmount.HeaderText = "Số tiền";
            this.colPaymentAmount.Name = "colPaymentAmount";

            this.colPaymentMethod.HeaderText = "Phương thức";
            this.colPaymentMethod.Name = "colPaymentMethod";

            // pnlActions (Giữ nguyên cấu trúc, đổi tên control)
            this.pnlActions.Controls.Add(this.btnClose);
            this.pnlActions.Controls.Add(this.btnPrint);
            this.pnlActions.Controls.Add(this.btnTraNoTatCa); // Thay đổi
            this.pnlActions.Dock = DockStyle.Bottom;
            this.pnlActions.FillColor = Color.FromArgb(240, 248, 255);
            this.pnlActions.Location = new Point(0, 630);
            this.pnlActions.Padding = new Padding(20, 15, 20, 15);
            this.pnlActions.Size = new Size(900, 70);

            // btnTraNoTatCa (Thay đổi Text và tên control)
            this.btnTraNoTatCa.BorderRadius = 10;
            this.btnTraNoTatCa.FillColor = Color.FromArgb(46, 204, 113);
            this.btnTraNoTatCa.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnTraNoTatCa.ForeColor = Color.White;
            this.btnTraNoTatCa.Location = new Point(20, 15);
            this.btnTraNoTatCa.Size = new Size(250, 40);
            this.btnTraNoTatCa.Text = "💰 Trả nợ tất cả"; // THAY ĐỔI
            this.btnTraNoTatCa.Click += new EventHandler(this.BtnTraNoTatCa_Click); // Cần đổi tên handler trong code-behind

            // btnPrint (Giữ nguyên)
            this.btnPrint.BorderRadius = 10;
            this.btnPrint.FillColor = Color.FromArgb(52, 152, 219);
            this.btnPrint.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnPrint.ForeColor = Color.White;
            this.btnPrint.Location = new Point(280, 15);
            this.btnPrint.Size = new Size(250, 40);
            this.btnPrint.Text = "🖨️ In báo cáo";
            this.btnPrint.Click += new EventHandler(this.BtnPrint_Click);

            // btnClose (Giữ nguyên)
            this.btnClose.BorderRadius = 10;
            this.btnClose.FillColor = Color.FromArgb(149, 165, 166);
            this.btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Location = new Point(630, 15);
            this.btnClose.Size = new Size(250, 40);
            this.btnClose.Text = "❌ Đóng";
            this.btnClose.Click += new EventHandler(this.BtnClose_Click);

            // Form (Thay đổi Text)
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            this.ClientSize = new Size(900, 700);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplierDebtDetailDialog"; // Thay đổi tên form
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Chi tiết Công Nợ Nhà Cung Cấp"; // THAY ĐỔI
            this.pnlMain.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabUnpaidReceipts.ResumeLayout(false); // Đổi tên tab
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnpaidReceipts)).EndInit(); // Đổi tên DataGridView
            this.tabPaymentHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistory)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        // Đổi tên các controls liên quan đến Khách hàng/Hóa đơn thành Nhà cung cấp/Phiếu nhập
        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlActions;
        private TabControl tabControl;
        private TabPage tabUnpaidReceipts; // Đổi tên
        private TabPage tabPaymentHistory;
        private Label lblSupplierName; // Đổi tên
        private Label lblSupplierPhone; // Đổi tên
        private Label lblTongNhapHang; // Đổi tên
        private Label lblTongDaTra;
        private Label lblCongNo;
        private Guna.UI2.WinForms.Guna2DataGridView dgvUnpaidReceipts; // Đổi tên
        private DataGridViewTextBoxColumn colReceiptID; // Đổi tên
        private DataGridViewTextBoxColumn colMaPhieuNhap; // Đổi tên
        private DataGridViewTextBoxColumn colNgayNhap; // Đổi tên
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
        private Guna.UI2.WinForms.Guna2Button btnTraNoTatCa; // Đổi tên
        private Guna.UI2.WinForms.Guna2Button btnPrint;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}