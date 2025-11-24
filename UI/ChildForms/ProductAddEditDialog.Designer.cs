using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    partial class ProductAddEditDialog
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
            this.lblTenSanPham = new Label();
            this.txtTenSanPham = new Guna2TextBox();
            this.lblBaseUnit = new Label();
            this.cboBaseUnit = new Guna2ComboBox();
            this.lblTonKhoToiThieu = new Label();
            this.txtTonKhoToiThieu = new Guna2TextBox();
            this.lblNote = new Label();
            this.lblError = new Label();
            this.btnSave = new Guna2Button();
            this.btnCancel = new Guna2Button();

            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            // pnlMain
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.lblTenSanPham);
            this.pnlMain.Controls.Add(this.txtTenSanPham);
            this.pnlMain.Controls.Add(this.lblBaseUnit);
            this.pnlMain.Controls.Add(this.cboBaseUnit);
            this.pnlMain.Controls.Add(this.lblTonKhoToiThieu);
            this.pnlMain.Controls.Add(this.txtTonKhoToiThieu);
            this.pnlMain.Controls.Add(this.lblNote);
            this.pnlMain.Controls.Add(this.lblError);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.FillColor = Color.White;
            this.pnlMain.Location = new Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new Padding(30);
            this.pnlMain.Size = new Size(500, 500);
            this.pnlMain.TabIndex = 0;

            // lblTitle
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(0, 150, 120);
            this.lblTitle.Location = new Point(30, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(440, 50);
            this.lblTitle.Text = "➕ Thêm sản phẩm mới";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            int startY = 100;
            int spacing = 80;

            // Tên sản phẩm
            this.lblTenSanPham.Font = new Font("Segoe UI", 10F);
            this.lblTenSanPham.Location = new Point(30, startY);
            this.lblTenSanPham.Name = "lblTenSanPham";
            this.lblTenSanPham.Size = new Size(200, 25);
            this.lblTenSanPham.Text = "Tên sản phẩm *";

            this.txtTenSanPham.BorderRadius = 8;
            this.txtTenSanPham.Location = new Point(30, startY + 30);
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.PlaceholderText = "Nhập tên sản phẩm (VD: Gạo ST25)";
            this.txtTenSanPham.Size = new Size(440, 40);

            // Đơn vị tính cơ sở
            startY += spacing;
            this.lblBaseUnit.Font = new Font("Segoe UI", 10F);
            this.lblBaseUnit.Location = new Point(30, startY);
            this.lblBaseUnit.Name = "lblBaseUnit";
            this.lblBaseUnit.Size = new Size(200, 25);
            this.lblBaseUnit.Text = "Đơn vị tính cơ sở *";

            this.cboBaseUnit.BackColor = Color.Transparent;
            this.cboBaseUnit.BorderRadius = 8;
            this.cboBaseUnit.DrawMode = DrawMode.OwnerDrawFixed;
            this.cboBaseUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboBaseUnit.Font = new Font("Segoe UI", 9F);
            this.cboBaseUnit.Location = new Point(30, startY + 30);
            this.cboBaseUnit.Name = "cboBaseUnit";
            this.cboBaseUnit.Size = new Size(440, 40);

            // Tồn kho tối thiểu
            startY += spacing;
            this.lblTonKhoToiThieu.Font = new Font("Segoe UI", 10F);
            this.lblTonKhoToiThieu.Location = new Point(30, startY);
            this.lblTonKhoToiThieu.Name = "lblTonKhoToiThieu";
            this.lblTonKhoToiThieu.Size = new Size(200, 25);
            this.lblTonKhoToiThieu.Text = "Tồn kho tối thiểu *";

            this.txtTonKhoToiThieu.BorderRadius = 8;
            this.txtTonKhoToiThieu.Location = new Point(30, startY + 30);
            this.txtTonKhoToiThieu.Name = "txtTonKhoToiThieu";
            this.txtTonKhoToiThieu.PlaceholderText = "Nhập số lượng tối thiểu (VD: 100)";
            this.txtTonKhoToiThieu.Size = new Size(440, 40);
            this.txtTonKhoToiThieu.Text = "0";

            // Note
            startY += 50;
            this.lblNote.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            this.lblNote.ForeColor = Color.Gray;
            this.lblNote.Location = new Point(30, startY);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new Size(440, 40);
            this.lblNote.Text = "Lưu ý: Đơn vị tính cơ sở thường là 'kg'. Sau khi thêm, bạn có thể\nquản lý các đơn vị quy đổi khác (Bao 10kg, Bao 25kg...)";

            // Error label
            this.lblError.Font = new Font("Segoe UI", 9F);
            this.lblError.ForeColor = Color.Red;
            this.lblError.Location = new Point(30, startY + 45);
            this.lblError.Name = "lblError";
            this.lblError.Size = new Size(440, 40);
            this.lblError.Visible = false;

            // Buttons
            this.btnSave.BorderRadius = 8;
            this.btnSave.FillColor = Color.FromArgb(0, 150, 120);
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(30, 430);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(205, 45);
            this.btnSave.Text = "💾 Lưu";
            this.btnSave.Click += new EventHandler(this.BtnSave_Click);

            this.btnCancel.BorderRadius = 8;
            this.btnCancel.FillColor = Color.FromArgb(220, 53, 69);
            this.btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(265, 430);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(205, 45);
            this.btnCancel.Text = "❌ Hủy";
            this.btnCancel.Click += new EventHandler(this.BtnCancel_Click);

            // Form
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(500, 500);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductAddEditDialog";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Quản lý sản phẩm";

            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        // Controls
        private Guna2Panel pnlMain;
        private Label lblTitle;
        private Label lblTenSanPham;
        private Guna2TextBox txtTenSanPham;
        private Label lblBaseUnit;
        private Guna2ComboBox cboBaseUnit;
        private Label lblTonKhoToiThieu;
        private Guna2TextBox txtTonKhoToiThieu;
        private Label lblNote;
        private Label lblError;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;
        #endregion
    }
}