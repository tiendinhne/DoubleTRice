using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    partial class PaymentDialog
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
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlPaymentInput = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlActions = new Guna.UI2.WinForms.Guna2Panel();

            this.lblTitle = new Label();

            this.lblInvoiceInfo = new Label();
            this.lblCustomerInfo = new Label();
            this.lblTongTien = new Label();
            this.lblDaTra = new Label();
            this.lblConLai = new Label();

            this.lblSoTienTra = new Label();
            this.txtSoTienTra = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPhuongThuc = new Label();
            this.cboPhuongThuc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblConLaiSauTra = new Label();
            this.txtConLaiSauTra = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnTraHet = new Guna.UI2.WinForms.Guna2Button();

            this.btnXacNhan = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();

            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlPaymentInput.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();

            // ===================================================================
            // pnlMain
            // ===================================================================
            this.pnlMain.Controls.Add(this.pnlPaymentInput);
            this.pnlMain.Controls.Add(this.pnlActions);
            this.pnlMain.Controls.Add(this.pnlInfo);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.FillColor = Color.White;
            this.pnlMain.Size = new Size(600, 550);

            // ===================================================================
            // pnlHeader
            // ===================================================================
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.FillColor = Color.FromArgb(52, 152, 219);
            this.pnlHeader.Size = new Size(600, 70);
            this.pnlHeader.Padding = new Padding(20, 10, 20, 10);

            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Text = "💰 Thanh Toán Công Nợ";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // ===================================================================
            // pnlInfo
            // ===================================================================
            this.pnlInfo.Controls.Add(this.lblConLai);
            this.pnlInfo.Controls.Add(this.lblDaTra);
            this.pnlInfo.Controls.Add(this.lblTongTien);
            this.pnlInfo.Controls.Add(this.lblCustomerInfo);
            this.pnlInfo.Controls.Add(this.lblInvoiceInfo);
            this.pnlInfo.Dock = DockStyle.Top;
            this.pnlInfo.FillColor = Color.FromArgb(240, 248, 255);
            this.pnlInfo.Location = new Point(0, 70);
            this.pnlInfo.Padding = new Padding(20, 15, 20, 15);
            this.pnlInfo.Size = new Size(600, 180);

            int yPos = 15;
            int spacing = 30;

            this.lblInvoiceInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblInvoiceInfo.Location = new Point(20, yPos);
            this.lblInvoiceInfo.Size = new Size(560, 25);
            this.lblInvoiceInfo.Text = "Hóa đơn: HD...";

            yPos += spacing;
            this.lblCustomerInfo.Font = new Font("Segoe UI", 10F);
            this.lblCustomerInfo.Location = new Point(20, yPos);
            this.lblCustomerInfo.Size = new Size(560, 25);
            this.lblCustomerInfo.Text = "Khách hàng: ...";

            yPos += spacing;
            this.lblTongTien.Font = new Font("Segoe UI", 10F);
            this.lblTongTien.Location = new Point(20, yPos);
            this.lblTongTien.Size = new Size(560, 25);
            this.lblTongTien.Text = "Tổng tiền hóa đơn: 0 đ";

            yPos += spacing;
            this.lblDaTra.Font = new Font("Segoe UI", 10F);
            this.lblDaTra.ForeColor = Color.Green;
            this.lblDaTra.Location = new Point(20, yPos);
            this.lblDaTra.Size = new Size(560, 25);
            this.lblDaTra.Text = "Đã trả: 0 đ";

            yPos += spacing;
            this.lblConLai.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblConLai.ForeColor = Color.Red;
            this.lblConLai.Location = new Point(20, yPos);
            this.lblConLai.Size = new Size(560, 30);
            this.lblConLai.Text = "Còn lại: 0 đ";

            // ===================================================================
            // pnlPaymentInput
            // ===================================================================
            this.pnlPaymentInput.Controls.Add(this.txtConLaiSauTra);
            this.pnlPaymentInput.Controls.Add(this.lblConLaiSauTra);
            this.pnlPaymentInput.Controls.Add(this.cboPhuongThuc);
            this.pnlPaymentInput.Controls.Add(this.lblPhuongThuc);
            this.pnlPaymentInput.Controls.Add(this.btnTraHet);
            this.pnlPaymentInput.Controls.Add(this.txtSoTienTra);
            this.pnlPaymentInput.Controls.Add(this.lblSoTienTra);
            this.pnlPaymentInput.Dock = DockStyle.Fill;
            this.pnlPaymentInput.Location = new Point(0, 250);
            this.pnlPaymentInput.Padding = new Padding(20, 20, 20, 20);
            this.pnlPaymentInput.Size = new Size(600, 220);

            yPos = 20;
            spacing = 60;

            this.lblSoTienTra.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblSoTienTra.Location = new Point(20, yPos);
            this.lblSoTienTra.Size = new Size(150, 40);
            this.lblSoTienTra.Text = "Số tiền trả:";
            this.lblSoTienTra.TextAlign = ContentAlignment.MiddleLeft;

            this.txtSoTienTra.BorderRadius = 8;
            this.txtSoTienTra.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.txtSoTienTra.Location = new Point(170, yPos);
            this.txtSoTienTra.Size = new Size(280, 40);
            this.txtSoTienTra.Text = "0";
            this.txtSoTienTra.TextAlign = HorizontalAlignment.Right;
            this.txtSoTienTra.TextChanged += new EventHandler(this.TxtSoTienTra_TextChanged);

            this.btnTraHet.BorderRadius = 8;
            this.btnTraHet.FillColor = Color.FromArgb(46, 204, 113);
            this.btnTraHet.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnTraHet.ForeColor = Color.White;
            this.btnTraHet.Location = new Point(460, yPos);
            this.btnTraHet.Size = new Size(120, 40);
            this.btnTraHet.Text = "💯 Trả hết";
            this.btnTraHet.Click += new EventHandler(this.BtnTraHet_Click);

            yPos += spacing;
            this.lblPhuongThuc.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblPhuongThuc.Location = new Point(20, yPos);
            this.lblPhuongThuc.Size = new Size(150, 40);
            this.lblPhuongThuc.Text = "Phương thức:";
            this.lblPhuongThuc.TextAlign = ContentAlignment.MiddleLeft;

            this.cboPhuongThuc.BackColor = Color.Transparent;
            this.cboPhuongThuc.BorderRadius = 8;
            this.cboPhuongThuc.DrawMode = DrawMode.OwnerDrawFixed;
            this.cboPhuongThuc.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboPhuongThuc.Font = new Font("Segoe UI", 10F);
            this.cboPhuongThuc.Items.AddRange(new object[] {
                "Tiền mặt",
                "Chuyển khoản"
            });
            this.cboPhuongThuc.Location = new Point(170, yPos);
            this.cboPhuongThuc.Size = new Size(410, 40);
            this.cboPhuongThuc.StartIndex = 0;

            yPos += spacing;
            this.lblConLaiSauTra.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblConLaiSauTra.Location = new Point(20, yPos);
            this.lblConLaiSauTra.Size = new Size(150, 40);
            this.lblConLaiSauTra.Text = "Còn lại sau trả:";
            this.lblConLaiSauTra.TextAlign = ContentAlignment.MiddleLeft;

            this.txtConLaiSauTra.BorderRadius = 8;
            this.txtConLaiSauTra.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.txtConLaiSauTra.ForeColor = Color.Red;
            this.txtConLaiSauTra.Location = new Point(170, yPos);
            this.txtConLaiSauTra.ReadOnly = true;
            this.txtConLaiSauTra.Size = new Size(410, 40);
            this.txtConLaiSauTra.Text = "0";
            this.txtConLaiSauTra.TextAlign = HorizontalAlignment.Right;

            // ===================================================================
            // pnlActions
            // ===================================================================
            this.pnlActions.Controls.Add(this.btnHuy);
            this.pnlActions.Controls.Add(this.btnXacNhan);
            this.pnlActions.Dock = DockStyle.Bottom;
            this.pnlActions.FillColor = Color.FromArgb(240, 248, 255);
            this.pnlActions.Location = new Point(0, 470);
            this.pnlActions.Padding = new Padding(20, 15, 20, 15);
            this.pnlActions.Size = new Size(600, 80);

            this.btnXacNhan.BorderRadius = 10;
            this.btnXacNhan.FillColor = Color.FromArgb(0, 150, 120);
            this.btnXacNhan.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnXacNhan.ForeColor = Color.White;
            this.btnXacNhan.Location = new Point(310, 20);
            this.btnXacNhan.Size = new Size(270, 40);
            this.btnXacNhan.Text = "✅ Xác nhận thanh toán";
            this.btnXacNhan.Click += new EventHandler(this.BtnXacNhan_Click);

            this.btnHuy.BorderRadius = 10;
            this.btnHuy.FillColor = Color.FromArgb(231, 76, 60);
            this.btnHuy.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnHuy.ForeColor = Color.White;
            this.btnHuy.Location = new Point(20, 20);
            this.btnHuy.Size = new Size(270, 40);
            this.btnHuy.Text = "❌ Hủy";
            this.btnHuy.Click += new EventHandler(this.BtnHuy_Click);

            // ===================================================================
            // Form
            // ===================================================================
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            this.ClientSize = new Size(600, 550);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentDialog";
            this.StartPosition = FormStartPosition.CenterParent;
            this.pnlMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlPaymentInput.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlInfo;
        private Guna.UI2.WinForms.Guna2Panel pnlPaymentInput;
        private Guna.UI2.WinForms.Guna2Panel pnlActions;

        private Label lblTitle;
        private Label lblInvoiceInfo;
        private Label lblCustomerInfo;
        private Label lblTongTien;
        private Label lblDaTra;
        private Label lblConLai;

        private Label lblSoTienTra;
        private Guna.UI2.WinForms.Guna2TextBox txtSoTienTra;
        private Label lblPhuongThuc;
        private Guna.UI2.WinForms.Guna2ComboBox cboPhuongThuc;
        private Label lblConLaiSauTra;
        private Guna.UI2.WinForms.Guna2TextBox txtConLaiSauTra;
        private Guna.UI2.WinForms.Guna2Button btnTraHet;

        private Guna.UI2.WinForms.Guna2Button btnXacNhan;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
    }
}