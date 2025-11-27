using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    partial class StockAdjustmentAddDialog
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
            this.pnlMain = new Guna2Panel();
            this.lblTitle = new Label();

            this.lblLoaiPhieu = new Label();
            this.rdoXuatHuy = new RadioButton();
            this.rdoNhapThua = new RadioButton();

            this.lblProduct = new Label();
            this.cboProduct = new Guna2ComboBox();
            this.lblCurrentStock = new Label();

            this.lblSoLuong = new Label();
            this.txtSoLuong = new Guna2TextBox();

            this.lblNgayDieuChinh = new Label();
            this.dtpNgayDieuChinh = new Guna2DateTimePicker();

            this.lblLyDo = new Label();
            this.txtLyDo = new Guna2TextBox();

            this.lblNote = new Label();
            this.lblWarning = new Label();
            this.lblError = new Label();

            this.btnSave = new Guna2Button();
            this.btnCancel = new Guna2Button();

            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            // pnlMain
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Controls.Add(this.lblError);
            this.pnlMain.Controls.Add(this.lblWarning);
            this.pnlMain.Controls.Add(this.lblNote);
            this.pnlMain.Controls.Add(this.txtLyDo);
            this.pnlMain.Controls.Add(this.lblLyDo);
            this.pnlMain.Controls.Add(this.dtpNgayDieuChinh);
            this.pnlMain.Controls.Add(this.lblNgayDieuChinh);
            this.pnlMain.Controls.Add(this.txtSoLuong);
            this.pnlMain.Controls.Add(this.lblSoLuong);
            this.pnlMain.Controls.Add(this.lblCurrentStock);
            this.pnlMain.Controls.Add(this.cboProduct);
            this.pnlMain.Controls.Add(this.lblProduct);
            this.pnlMain.Controls.Add(this.rdoNhapThua);
            this.pnlMain.Controls.Add(this.rdoXuatHuy);
            this.pnlMain.Controls.Add(this.lblLoaiPhieu);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.FillColor = Color.White;
            this.pnlMain.Location = new Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new Padding(30);
            this.pnlMain.Size = new Size(600, 650);

            // lblTitle
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(220, 53, 69);
            this.lblTitle.Location = new Point(30, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(540, 50);
            this.lblTitle.Text = "🔧 Tạo Phiếu Điều Chỉnh Kho";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            int y = 100;
            int spacing = 75;

            // Loại phiếu
            this.lblLoaiPhieu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblLoaiPhieu.ForeColor = Color.FromArgb(220, 53, 69);
            this.lblLoaiPhieu.Location = new Point(30, y);
            this.lblLoaiPhieu.Size = new Size(200, 25);
            this.lblLoaiPhieu.Text = "Loại phiếu *";

            this.rdoXuatHuy.Font = new Font("Segoe UI", 9F);
            this.rdoXuatHuy.Location = new Point(30, y + 30);
            this.rdoXuatHuy.Size = new Size(200, 30);
            this.rdoXuatHuy.Text = "🔴 Xuất hủy (giảm kho)";
            this.rdoXuatHuy.CheckedChanged += new EventHandler(this.RdoLoaiPhieu_CheckedChanged);

            this.rdoNhapThua.Font = new Font("Segoe UI", 9F);
            this.rdoNhapThua.Location = new Point(250, y + 30);
            this.rdoNhapThua.Size = new Size(200, 30);
            this.rdoNhapThua.Text = "🟢 Nhập thừa (tăng kho)";
            this.rdoNhapThua.CheckedChanged += new EventHandler(this.RdoLoaiPhieu_CheckedChanged);

            // Sản phẩm
            y += spacing;
            this.lblProduct.Font = new Font("Segoe UI", 10F);
            this.lblProduct.Location = new Point(30, y);
            this.lblProduct.Size = new Size(200, 25);
            this.lblProduct.Text = "Sản phẩm *";

            this.cboProduct.BackColor = Color.Transparent;
            this.cboProduct.BorderRadius = 8;
            this.cboProduct.DrawMode = DrawMode.OwnerDrawFixed;
            this.cboProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboProduct.Font = new Font("Segoe UI", 9F);
            this.cboProduct.Location = new Point(30, y + 30);
            this.cboProduct.Size = new Size(540, 36);
            this.cboProduct.SelectedIndexChanged += new EventHandler(this.CboProduct_SelectedIndexChanged);

            this.lblCurrentStock.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblCurrentStock.ForeColor = Color.FromArgb(0, 100, 180);
            this.lblCurrentStock.Location = new Point(30, y + 70);
            this.lblCurrentStock.Size = new Size(540, 20);
            this.lblCurrentStock.Text = "Tồn kho hiện tại: 0 kg";
            this.lblCurrentStock.Visible = false;

            // Số lượng và Ngày
            y += spacing + 15;
            this.lblSoLuong.Font = new Font("Segoe UI", 10F);
            this.lblSoLuong.Location = new Point(30, y);
            this.lblSoLuong.Size = new Size(250, 25);
            this.lblSoLuong.Text = "Số lượng xuất hủy (kg) *";

            this.txtSoLuong.BorderRadius = 8;
            this.txtSoLuong.Location = new Point(30, y + 30);
            this.txtSoLuong.PlaceholderText = "Nhập số lượng (kg)";
            this.txtSoLuong.Size = new Size(250, 36);
            this.txtSoLuong.TextChanged += new EventHandler(this.TxtSoLuong_TextChanged);

            this.lblNgayDieuChinh.Font = new Font("Segoe UI", 10F);
            this.lblNgayDieuChinh.Location = new Point(290, y);
            this.lblNgayDieuChinh.Size = new Size(150, 25);
            this.lblNgayDieuChinh.Text = "Ngày điều chỉnh *";

            this.dtpNgayDieuChinh.BorderRadius = 8;
            this.dtpNgayDieuChinh.Checked = true;
            this.dtpNgayDieuChinh.FillColor = Color.White;
            this.dtpNgayDieuChinh.Font = new Font("Segoe UI", 9F);
            this.dtpNgayDieuChinh.Format = DateTimePickerFormat.Custom;
            this.dtpNgayDieuChinh.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpNgayDieuChinh.Location = new Point(290, y + 30);
            this.dtpNgayDieuChinh.Size = new Size(280, 36);

            // Lý do
            y += spacing;
            this.lblLyDo.Font = new Font("Segoe UI", 10F);
            this.lblLyDo.Location = new Point(30, y);
            this.lblLyDo.Size = new Size(300, 25);
            this.lblLyDo.Text = "Lý do điều chỉnh * (tối thiểu 10 ký tự)";

            this.txtLyDo.BorderRadius = 8;
            this.txtLyDo.Location = new Point(30, y + 30);
            this.txtLyDo.Multiline = true;
            this.txtLyDo.PlaceholderText = "Nhập lý do chi tiết (VD: Hao hụt tự nhiên, Hàng hỏng do chuột cắn...)";
            this.txtLyDo.Size = new Size(540, 80);

            // Note
            y += 120;
            this.lblNote.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            this.lblNote.ForeColor = Color.Gray;
            this.lblNote.Location = new Point(30, y);
            this.lblNote.Size = new Size(540, 40);
            this.lblNote.Text = "Lưu ý: Phiếu điều chỉnh được dùng khi cần cập nhật số liệu tồn kho cho khớp với\n" +
                                "thực tế sau kiểm kê. Cần ghi rõ lý do để có thể truy vết sau này.";

            // Warning
            this.lblWarning.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblWarning.ForeColor = Color.Red;
            this.lblWarning.Location = new Point(30, y + 45);
            this.lblWarning.Size = new Size(540, 25);
            this.lblWarning.Visible = false;

            // Error
            this.lblError.Font = new Font("Segoe UI", 9F);
            this.lblError.ForeColor = Color.Red;
            this.lblError.Location = new Point(30, y + 70);
            this.lblError.Size = new Size(540, 30);
            this.lblError.Visible = false;

            // Buttons
            this.btnSave.BorderRadius = 8;
            this.btnSave.FillColor = Color.FromArgb(220, 53, 69);
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(170, 580);
            this.btnSave.Size = new Size(190, 45);
            this.btnSave.Text = "💾 Lưu phiếu";
            this.btnSave.Click += new EventHandler(this.BtnSave_Click);

            this.btnCancel.BorderRadius = 8;
            this.btnCancel.FillColor = Color.FromArgb(100, 120, 140);
            this.btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(370, 580);
            this.btnCancel.Size = new Size(200, 45);
            this.btnCancel.Text = "❌ Hủy bỏ";
            this.btnCancel.Click += new EventHandler(this.BtnCancel_Click);

            // Form
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.BackColor = Color.White;
            this.ClientSize = new Size(600, 650);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockAdjustmentAddDialog";
            this.StartPosition = FormStartPosition.CenterParent;

            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "StockAdjustmentAddDialog";
        }

        private Guna2Panel pnlMain;
        private Label lblTitle;
        private Label lblLoaiPhieu;
        private RadioButton rdoXuatHuy;
        private RadioButton rdoNhapThua;
        private Label lblProduct;
        private Guna2ComboBox cboProduct;
        private Label lblCurrentStock;
        private Label lblSoLuong;
        private Guna2TextBox txtSoLuong;
        private Label lblNgayDieuChinh;
        private Guna2DateTimePicker dtpNgayDieuChinh;
        private Label lblLyDo;
        private Guna2TextBox txtLyDo;
        private Label lblNote;
        private Label lblWarning;
        private Label lblError;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;
        #endregion
    }
}