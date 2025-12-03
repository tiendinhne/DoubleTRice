using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    partial class GoodsReceiptDetailDialog
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
            this.pnlMain = new Guna2Panel();
            this.pnlHeader = new Guna2Panel();
            this.pnlInfo = new Guna2Panel();
            this.pnlDetails = new Guna2Panel();
            this.pnlFooter = new Guna2Panel();

            this.lblTitle = new Label();
            this.lblMaPhieu = new Label();
            this.lblNgayNhap = new Label();
            this.lblSupplier = new Label();
            this.lblUser = new Label();
            this.lblGhiChu = new Label();
            this.lblTongTien = new Label();

            this.dgvDetails = new Guna2DataGridView();
            this.colProductName = new DataGridViewTextBoxColumn();
            this.colUnitName = new DataGridViewTextBoxColumn();
            this.colSoLuong = new DataGridViewTextBoxColumn();
            this.colDonGia = new DataGridViewTextBoxColumn();
            this.colThanhTien = new DataGridViewTextBoxColumn();

            this.btnPrint = new Guna2Button();
            this.btnClose = new Guna2Button();

            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();

            // pnlMain
            this.pnlMain.Controls.Add(this.pnlDetails);
            this.pnlMain.Controls.Add(this.pnlFooter);
            this.pnlMain.Controls.Add(this.pnlInfo);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.FillColor = Color.White;
            this.pnlMain.Size = new Size(800, 600);

            // pnlHeader
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.FillColor = Color.FromArgb(0, 150, 120);
            this.pnlHeader.Size = new Size(800, 60);
            this.pnlHeader.Padding = new Padding(20, 10, 20, 10);

            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Text = "👁️ Chi Tiết Phiếu Nhập Kho";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // pnlInfo
            this.pnlInfo.Controls.Add(this.lblTongTien);
            this.pnlInfo.Controls.Add(this.lblGhiChu);
            this.pnlInfo.Controls.Add(this.lblUser);
            this.pnlInfo.Controls.Add(this.lblSupplier);
            this.pnlInfo.Controls.Add(this.lblNgayNhap);
            this.pnlInfo.Controls.Add(this.lblMaPhieu);
            this.pnlInfo.Dock = DockStyle.Top;
            this.pnlInfo.FillColor = Color.FromArgb(240, 248, 255);
            this.pnlInfo.Location = new Point(0, 60);
            this.pnlInfo.Padding = new Padding(20, 15, 20, 15);
            this.pnlInfo.Size = new Size(800, 180);

            int y = 15;
            int spacing = 25;

            this.lblMaPhieu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblMaPhieu.Location = new Point(20, y);
            this.lblMaPhieu.Size = new Size(760, 22);
            this.lblMaPhieu.Text = "Mã phiếu: PN...";

            y += spacing;
            this.lblNgayNhap.Font = new Font("Segoe UI", 10F);
            this.lblNgayNhap.Location = new Point(20, y);
            this.lblNgayNhap.Size = new Size(760, 22);
            this.lblNgayNhap.Text = "Ngày nhập: ...";

            y += spacing;
            this.lblSupplier.Font = new Font("Segoe UI", 10F);
            this.lblSupplier.Location = new Point(20, y);
            this.lblSupplier.Size = new Size(760, 22);
            this.lblSupplier.Text = "Nhà cung cấp: ...";

            y += spacing;
            this.lblUser.Font = new Font("Segoe UI", 10F);
            this.lblUser.Location = new Point(20, y);
            this.lblUser.Size = new Size(760, 22);
            this.lblUser.Text = "Người nhập: ...";

            y += spacing;
            this.lblGhiChu.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            this.lblGhiChu.ForeColor = Color.Gray;
            this.lblGhiChu.Location = new Point(20, y);
            this.lblGhiChu.Size = new Size(760, 22);
            this.lblGhiChu.Text = "Ghi chú: ...";

            y += spacing + 5;
            this.lblTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTongTien.ForeColor = Color.FromArgb(0, 150, 120);
            this.lblTongTien.Location = new Point(20, y);
            this.lblTongTien.Size = new Size(760, 28);
            this.lblTongTien.Text = "Tổng tiền: 0 đ";

            // pnlDetails
            this.pnlDetails.Controls.Add(this.dgvDetails);
            this.pnlDetails.Dock = DockStyle.Fill;
            this.pnlDetails.Location = new Point(0, 240);
            this.pnlDetails.Padding = new Padding(20);
            this.pnlDetails.Size = new Size(800, 280);

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

            // pnlFooter
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Controls.Add(this.btnPrint);
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.FillColor = Color.FromArgb(240, 248, 255);
            this.pnlFooter.Location = new Point(0, 520);
            this.pnlFooter.Padding = new Padding(20, 10, 20, 10);
            this.pnlFooter.Size = new Size(800, 80);

            this.btnPrint.BorderRadius = 8;
            this.btnPrint.FillColor = Color.FromArgb(52, 152, 219);
            this.btnPrint.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnPrint.ForeColor = Color.White;
            this.btnPrint.Location = new Point(430, 20);
            this.btnPrint.Size = new Size(160, 40);
            this.btnPrint.Text = "🖨️ In phiếu";
            this.btnPrint.Click += new EventHandler(this.BtnPrint_Click);

            this.btnClose.BorderRadius = 8;
            this.btnClose.FillColor = Color.FromArgb(100, 120, 140);
            this.btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Location = new Point(600, 20);
            this.btnClose.Size = new Size(180, 40);
            this.btnClose.Text = "✖️ Đóng";
            this.btnClose.Click += new EventHandler(this.BtnClose_Click);

            // Form
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            this.ClientSize = new Size(800, 600);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GoodsReceiptDetailDialog";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Chi Tiết Phiếu Nhập";

            this.pnlMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna2Panel pnlMain;
        private Guna2Panel pnlHeader;
        private Guna2Panel pnlInfo;
        private Guna2Panel pnlDetails;
        private Guna2Panel pnlFooter;

        private Label lblTitle;
        private Label lblMaPhieu;
        private Label lblNgayNhap;
        private Label lblSupplier;
        private Label lblUser;
        private Label lblGhiChu;
        private Label lblTongTien;

        private Guna2DataGridView dgvDetails;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colUnitName;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colDonGia;
        private DataGridViewTextBoxColumn colThanhTien;

        private Guna2Button btnPrint;
        private Guna2Button btnClose;
    }
}