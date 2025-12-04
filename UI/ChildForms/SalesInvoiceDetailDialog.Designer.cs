using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    partial class SalesInvoiceDetailDialog
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
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlDetails = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlPaymentHistory = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlFooter = new Guna.UI2.WinForms.Guna2Panel();

            this.lblTitle = new Label();

            this.lblMaHoaDon = new Label();
            this.lblNgayBan = new Label();
            this.lblCustomer = new Label();
            this.lblUser = new Label();
            this.lblTongTien = new Label();
            this.lblSoTienDaTra = new Label();
            this.lblConLai = new Label();
            this.lblTrangThai = new Label();

            this.lblDetailsTitle = new Label();
            this.dgvDetails = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colProductName = new DataGridViewTextBoxColumn();
            this.colUnitName = new DataGridViewTextBoxColumn();
            this.colSoLuong = new DataGridViewTextBoxColumn();
            this.colDonGia = new DataGridViewTextBoxColumn();
            this.colThanhTien = new DataGridViewTextBoxColumn();

            this.lblPaymentTitle = new Label();
            this.dgvPayments = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colPaymentDate = new DataGridViewTextBoxColumn();
            this.colPaymentAmount = new DataGridViewTextBoxColumn();
            this.colPaymentMethod = new DataGridViewTextBoxColumn();

            this.btnPrint = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();

            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.pnlPaymentHistory.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
            this.SuspendLayout();

            // ===================================================================
            // pnlMain
            // ===================================================================
            this.pnlMain.Controls.Add(this.pnlDetails);
            this.pnlMain.Controls.Add(this.pnlPaymentHistory);
            this.pnlMain.Controls.Add(this.pnlFooter);
            this.pnlMain.Controls.Add(this.pnlInfo);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.FillColor = Color.White;
            this.pnlMain.Size = new Size(1000, 700);

            // ===================================================================
            // pnlHeader
            // ===================================================================
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.FillColor = Color.FromArgb(0, 150, 120);
            this.pnlHeader.Size = new Size(1000, 70);
            this.pnlHeader.Padding = new Padding(20, 10, 20, 10);

            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Black;
            this.lblTitle.Text = "👁️ Chi Tiết Hóa Đơn Bán Hàng";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // ===================================================================
            // pnlInfo
            // ===================================================================
            this.pnlInfo.Controls.Add(this.lblTrangThai);
            this.pnlInfo.Controls.Add(this.lblConLai);
            this.pnlInfo.Controls.Add(this.lblSoTienDaTra);
            this.pnlInfo.Controls.Add(this.lblTongTien);
            this.pnlInfo.Controls.Add(this.lblUser);
            this.pnlInfo.Controls.Add(this.lblCustomer);
            this.pnlInfo.Controls.Add(this.lblNgayBan);
            this.pnlInfo.Controls.Add(this.lblMaHoaDon);
            this.pnlInfo.Dock = DockStyle.Top;
            this.pnlInfo.FillColor = Color.FromArgb(240, 248, 255);
            this.pnlInfo.Location = new Point(0, 70);
            this.pnlInfo.Padding = new Padding(20, 15, 20, 15);
            this.pnlInfo.Size = new Size(1000, 220);

            int yPos = 15;
            int spacing = 27;

            this.lblMaHoaDon.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblMaHoaDon.Location = new Point(20, yPos);
            this.lblMaHoaDon.Size = new Size(960, 25);
            this.lblMaHoaDon.Text = "Mã hóa đơn: HD...";

            yPos += spacing;
            this.lblNgayBan.Font = new Font("Segoe UI", 10F);
            this.lblNgayBan.Location = new Point(20, yPos);
            this.lblNgayBan.Size = new Size(960, 25);
            this.lblNgayBan.Text = "Ngày bán: ...";

            yPos += spacing;
            this.lblCustomer.Font = new Font("Segoe UI", 10F);
            this.lblCustomer.Location = new Point(20, yPos);
            this.lblCustomer.Size = new Size(960, 25);
            this.lblCustomer.Text = "Khách hàng: ...";

            yPos += spacing;
            this.lblUser.Font = new Font("Segoe UI", 10F);
            this.lblUser.Location = new Point(20, yPos);
            this.lblUser.Size = new Size(960, 25);
            this.lblUser.Text = "Nhân viên bán: ...";

            yPos += spacing + 5;
            this.lblTongTien.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTongTien.ForeColor = Color.FromArgb(0, 150, 120);
            this.lblTongTien.Location = new Point(20, yPos);
            this.lblTongTien.Size = new Size(960, 28);
            this.lblTongTien.Text = "Tổng tiền: 0 đ";

            yPos += spacing + 3;
            this.lblSoTienDaTra.Font = new Font("Segoe UI", 10F);
            this.lblSoTienDaTra.ForeColor = Color.Green;
            this.lblSoTienDaTra.Location = new Point(20, yPos);
            this.lblSoTienDaTra.Size = new Size(480, 25);
            this.lblSoTienDaTra.Text = "Đã trả: 0 đ";

            this.lblConLai.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblConLai.ForeColor = Color.Red;
            this.lblConLai.Location = new Point(500, yPos);
            this.lblConLai.Size = new Size(480, 25);
            this.lblConLai.Text = "Còn lại: 0 đ";

            yPos += spacing + 3;
            this.lblTrangThai.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTrangThai.Location = new Point(20, yPos);
            this.lblTrangThai.Size = new Size(960, 28);
            this.lblTrangThai.Text = "Trạng thái: ...";

            // ===================================================================
            // pnlDetails
            // ===================================================================
            this.pnlDetails.Controls.Add(this.dgvDetails);
            this.pnlDetails.Controls.Add(this.lblDetailsTitle);
            this.pnlDetails.Dock = DockStyle.Fill;
            this.pnlDetails.Location = new Point(0, 290);
            this.pnlDetails.Padding = new Padding(20, 10, 20, 10);
            this.pnlDetails.Size = new Size(1000, 210);

            this.lblDetailsTitle.Dock = DockStyle.Top;
            this.lblDetailsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblDetailsTitle.Location = new Point(20, 10);
            this.lblDetailsTitle.Size = new Size(960, 30);
            this.lblDetailsTitle.Text = "📦 Chi tiết sản phẩm:";
            this.lblDetailsTitle.TextAlign = ContentAlignment.MiddleLeft;

            // dgvDetails
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetails.ColumnHeadersHeight = 40;
            this.dgvDetails.Columns.AddRange(new DataGridViewColumn[] {
                this.colProductName, this.colUnitName, this.colSoLuong,
                this.colDonGia, this.colThanhTien
            });
            this.dgvDetails.Dock = DockStyle.Fill;
            this.dgvDetails.Location = new Point(20, 40);
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowTemplate.Height = 40;

            this.colProductName.HeaderText = "Sản phẩm";
            this.colProductName.Name = "colProductName";
            this.colProductName.FillWeight = 150F;

            this.colUnitName.HeaderText = "Đơn vị";
            this.colUnitName.Name = "colUnitName";
            this.colUnitName.FillWeight = 80F;

            this.colSoLuong.HeaderText = "Số lượng";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.FillWeight = 90F;
            this.colSoLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.FillWeight = 110F;
            this.colDonGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.FillWeight = 120F;
            this.colThanhTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // ===================================================================
            // pnlPaymentHistory
            // ===================================================================
            this.pnlPaymentHistory.Controls.Add(this.dgvPayments);
            this.pnlPaymentHistory.Controls.Add(this.lblPaymentTitle);
            this.pnlPaymentHistory.Dock = DockStyle.Bottom;
            this.pnlPaymentHistory.Location = new Point(0, 500);
            this.pnlPaymentHistory.Padding = new Padding(20, 10, 20, 10);
            this.pnlPaymentHistory.Size = new Size(1000, 120);

            this.lblPaymentTitle.Dock = DockStyle.Top;
            this.lblPaymentTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblPaymentTitle.Location = new Point(20, 10);
            this.lblPaymentTitle.Size = new Size(960, 30);
            this.lblPaymentTitle.Text = "💰 Lịch sử thanh toán:";
            this.lblPaymentTitle.TextAlign = ContentAlignment.MiddleLeft;

            // dgvPayments
            this.dgvPayments.AllowUserToAddRows = false;
            this.dgvPayments.AllowUserToDeleteRows = false;
            this.dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPayments.ColumnHeadersHeight = 35;
            this.dgvPayments.Columns.AddRange(new DataGridViewColumn[] {
                this.colPaymentDate, this.colPaymentAmount, this.colPaymentMethod
            });
            this.dgvPayments.Dock = DockStyle.Fill;
            this.dgvPayments.Location = new Point(20, 40);
            this.dgvPayments.ReadOnly = true;
            this.dgvPayments.RowTemplate.Height = 35;

            this.colPaymentDate.HeaderText = "Ngày thanh toán";
            this.colPaymentDate.Name = "colPaymentDate";
            this.colPaymentDate.FillWeight = 150F;

            this.colPaymentAmount.HeaderText = "Số tiền";
            this.colPaymentAmount.Name = "colPaymentAmount";
            this.colPaymentAmount.FillWeight = 120F;
            this.colPaymentAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.colPaymentMethod.HeaderText = "Phương thức";
            this.colPaymentMethod.Name = "colPaymentMethod";
            this.colPaymentMethod.FillWeight = 100F;

            // ===================================================================
            // pnlFooter
            // ===================================================================
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Controls.Add(this.btnPrint);
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.FillColor = Color.FromArgb(240, 248, 255);
            this.pnlFooter.Location = new Point(0, 620);
            this.pnlFooter.Padding = new Padding(20, 10, 20, 10);
            this.pnlFooter.Size = new Size(1000, 80);

            this.btnPrint.BorderRadius = 8;
            this.btnPrint.FillColor = Color.FromArgb(52, 152, 219);
            this.btnPrint.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnPrint.ForeColor = Color.White;
            this.btnPrint.Location = new Point(600, 20);
            this.btnPrint.Size = new Size(180, 40);
            this.btnPrint.Text = "🖨️ In hóa đơn";
            this.btnPrint.Click += new EventHandler(this.BtnPrint_Click);

            this.btnClose.BorderRadius = 8;
            this.btnClose.FillColor = Color.FromArgb(100, 120, 140);
            this.btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Location = new Point(800, 20);
            this.btnClose.Size = new Size(180, 40);
            this.btnClose.Text = "✖️ Đóng";
            this.btnClose.Click += new EventHandler(this.BtnClose_Click);


            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            this.ClientSize = new Size(900, 700);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SalesInvoiceDetailDialog";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "SalesInvoiceDetailDialog";
            this.pnlMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.pnlPaymentHistory.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlInfo;
        private Guna.UI2.WinForms.Guna2Panel pnlDetails;
        private Guna.UI2.WinForms.Guna2Panel pnlPaymentHistory;
        private Guna.UI2.WinForms.Guna2Panel pnlFooter;

        private Label lblTitle;
        private Label lblMaHoaDon;
        private Label lblNgayBan;
        private Label lblCustomer;
        private Label lblUser;
        private Label lblTongTien;
        private Label lblSoTienDaTra;
        private Label lblConLai;
        private Label lblTrangThai;

        private Label lblDetailsTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDetails;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colUnitName;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colDonGia;
        private DataGridViewTextBoxColumn colThanhTien;

        private Label lblPaymentTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPayments;
        private DataGridViewTextBoxColumn colPaymentDate;
        private DataGridViewTextBoxColumn colPaymentAmount;
        private DataGridViewTextBoxColumn colPaymentMethod;

        private Guna.UI2.WinForms.Guna2Button btnPrint;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}