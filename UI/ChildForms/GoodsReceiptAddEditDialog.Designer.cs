using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    partial class GoodsReceiptAddEditDialog
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
            this.pnlReceiptInfo = new Guna2Panel();
            this.pnlProductInput = new Guna2Panel();
            this.pnlItems = new Guna2Panel();
            this.pnlFooter = new Guna2Panel();

            this.lblTitle = new Label();

            // Receipt Info
            this.lblSupplier = new Label();
            this.cboSupplier = new Guna2ComboBox();
            this.lblNgayNhap = new Label();
            this.dtpNgayNhap = new Guna2DateTimePicker();
            this.lblGhiChu = new Label();
            this.txtGhiChu = new Guna2TextBox();

            // Product Input
            this.lblProductSection = new Label();
            this.lblProduct = new Label();
            this.cboProduct = new Guna2ComboBox();
            this.lblUnit = new Label();
            this.cboUnit = new Guna2ComboBox();
            this.lblSoLuong = new Label();
            this.txtSoLuong = new Guna2TextBox();
            this.lblDonGia = new Label();
            this.txtDonGia = new Guna2TextBox();
            this.btnAddItem = new Guna2Button();

            // Items Grid
            this.lblItemsList = new Label();
            this.dgvItems = new Guna2DataGridView();
            this.colProductName = new DataGridViewTextBoxColumn();
            this.colUnitName = new DataGridViewTextBoxColumn();
            this.colSoLuong = new DataGridViewTextBoxColumn();
            this.colDonGia = new DataGridViewTextBoxColumn();
            this.colThanhTien = new DataGridViewTextBoxColumn();
            this.colDelete = new DataGridViewButtonColumn();

            // Footer
            this.lblTotal = new Label();
            this.lblError = new Label();
            this.btnSave = new Guna2Button();
            this.btnCancel = new Guna2Button();

            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlReceiptInfo.SuspendLayout();
            this.pnlProductInput.SuspendLayout();
            this.pnlItems.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();

            // pnlMain
            this.pnlMain.Controls.Add(this.pnlItems);
            this.pnlMain.Controls.Add(this.pnlFooter);
            this.pnlMain.Controls.Add(this.pnlProductInput);
            this.pnlMain.Controls.Add(this.pnlReceiptInfo);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.FillColor = Color.White;
            this.pnlMain.Location = new Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new Size(900, 750);

            // pnlHeader
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.FillColor = Color.FromArgb(240, 248, 255);
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Size = new Size(900, 60);
            this.pnlHeader.Padding = new Padding(20, 10, 20, 10);

            // lblTitle
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(0, 150, 120);
            this.lblTitle.Text = "📦 Tạo Phiếu Nhập Kho";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // pnlReceiptInfo
            this.pnlReceiptInfo.Controls.Add(this.txtGhiChu);
            this.pnlReceiptInfo.Controls.Add(this.lblGhiChu);
            this.pnlReceiptInfo.Controls.Add(this.dtpNgayNhap);
            this.pnlReceiptInfo.Controls.Add(this.lblNgayNhap);
            this.pnlReceiptInfo.Controls.Add(this.cboSupplier);
            this.pnlReceiptInfo.Controls.Add(this.lblSupplier);
            this.pnlReceiptInfo.Dock = DockStyle.Top;
            this.pnlReceiptInfo.Location = new Point(0, 60);
            this.pnlReceiptInfo.Padding = new Padding(20, 10, 20, 10);
            this.pnlReceiptInfo.Size = new Size(900, 120);

            int x = 20, y = 15;

            // Nhà cung cấp
            this.lblSupplier.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblSupplier.Location = new Point(x, y);
            this.lblSupplier.Size = new Size(120, 25);
            this.lblSupplier.Text = "Nhà cung cấp *";
            this.lblSupplier.TextAlign = ContentAlignment.MiddleLeft;

            this.cboSupplier.BackColor = Color.Transparent;
            this.cboSupplier.BorderRadius = 6;
            this.cboSupplier.DrawMode = DrawMode.OwnerDrawFixed;
            this.cboSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboSupplier.Font = new Font("Segoe UI", 9F);
            this.cboSupplier.Location = new Point(x, y + 30);
            this.cboSupplier.Size = new Size(300, 36);

            // Ngày nhập
            this.lblNgayNhap.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblNgayNhap.Location = new Point(x + 320, y);
            this.lblNgayNhap.Size = new Size(100, 25);
            this.lblNgayNhap.Text = "Ngày nhập *";
            this.lblNgayNhap.TextAlign = ContentAlignment.MiddleLeft;

            this.dtpNgayNhap.BorderRadius = 6;
            this.dtpNgayNhap.Checked = true;
            this.dtpNgayNhap.FillColor = Color.White;
            this.dtpNgayNhap.Font = new Font("Segoe UI", 9F);
            this.dtpNgayNhap.Format = DateTimePickerFormat.Custom;
            this.dtpNgayNhap.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpNgayNhap.Location = new Point(x + 320, y + 30);
            this.dtpNgayNhap.Size = new Size(220, 36);

            // Ghi chú
            this.lblGhiChu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblGhiChu.Location = new Point(x + 560, y);
            this.lblGhiChu.Size = new Size(100, 25);
            this.lblGhiChu.Text = "Ghi chú";
            this.lblGhiChu.TextAlign = ContentAlignment.MiddleLeft;

            this.txtGhiChu.BorderRadius = 6;
            this.txtGhiChu.Location = new Point(x + 560, y + 30);
            this.txtGhiChu.PlaceholderText = "Ghi chú (nếu có)";
            this.txtGhiChu.Size = new Size(300, 36);

            // pnlProductInput
            this.pnlProductInput.Controls.Add(this.btnAddItem);
            this.pnlProductInput.Controls.Add(this.txtDonGia);
            this.pnlProductInput.Controls.Add(this.lblDonGia);
            this.pnlProductInput.Controls.Add(this.txtSoLuong);
            this.pnlProductInput.Controls.Add(this.lblSoLuong);
            this.pnlProductInput.Controls.Add(this.cboUnit);
            this.pnlProductInput.Controls.Add(this.lblUnit);
            this.pnlProductInput.Controls.Add(this.cboProduct);
            this.pnlProductInput.Controls.Add(this.lblProduct);
            this.pnlProductInput.Controls.Add(this.lblProductSection);
            this.pnlProductInput.Dock = DockStyle.Top;
            this.pnlProductInput.FillColor = Color.FromArgb(250, 250, 250);
            this.pnlProductInput.Location = new Point(0, 180);
            this.pnlProductInput.Padding = new Padding(20, 10, 20, 10);
            this.pnlProductInput.Size = new Size(900, 140);

            y = 10;

            // Section label
            this.lblProductSection.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblProductSection.ForeColor = Color.FromArgb(0, 100, 180);
            this.lblProductSection.Location = new Point(20, y);
            this.lblProductSection.Size = new Size(300, 25);
            this.lblProductSection.Text = "➕ Thêm sản phẩm vào phiếu";

            y += 35;

            // Sản phẩm
            this.lblProduct.Font = new Font("Segoe UI", 8.5F);
            this.lblProduct.Location = new Point(20, y);
            this.lblProduct.Size = new Size(100, 20);
            this.lblProduct.Text = "Sản phẩm *";

            this.cboProduct.BackColor = Color.Transparent;
            this.cboProduct.BorderRadius = 6;
            this.cboProduct.DrawMode = DrawMode.OwnerDrawFixed;
            this.cboProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboProduct.Font = new Font("Segoe UI", 9F);
            this.cboProduct.Location = new Point(20, y + 22);
            this.cboProduct.Size = new Size(220, 36);
            this.cboProduct.SelectedIndexChanged += new EventHandler(this.CboProduct_SelectedIndexChanged);

            // Đơn vị
            this.lblUnit.Font = new Font("Segoe UI", 8.5F);
            this.lblUnit.Location = new Point(250, y);
            this.lblUnit.Size = new Size(80, 20);
            this.lblUnit.Text = "Đơn vị *";

            this.cboUnit.BackColor = Color.Transparent;
            this.cboUnit.BorderRadius = 6;
            this.cboUnit.DrawMode = DrawMode.OwnerDrawFixed;
            this.cboUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboUnit.Font = new Font("Segoe UI", 9F);
            this.cboUnit.Location = new Point(250, y + 22);
            this.cboUnit.Size = new Size(130, 36);

            // Số lượng
            this.lblSoLuong.Font = new Font("Segoe UI", 8.5F);
            this.lblSoLuong.Location = new Point(390, y);
            this.lblSoLuong.Size = new Size(80, 20);
            this.lblSoLuong.Text = "Số lượng *";

            this.txtSoLuong.BorderRadius = 6;
            this.txtSoLuong.Location = new Point(390, y + 22);
            this.txtSoLuong.PlaceholderText = "0";
            this.txtSoLuong.Size = new Size(110, 36);

            // Đơn giá
            this.lblDonGia.Font = new Font("Segoe UI", 8.5F);
            this.lblDonGia.Location = new Point(510, y);
            this.lblDonGia.Size = new Size(100, 20);
            this.lblDonGia.Text = "Đơn giá (đ) *";

            this.txtDonGia.BorderRadius = 6;
            this.txtDonGia.Location = new Point(510, y + 22);
            this.txtDonGia.PlaceholderText = "0";
            this.txtDonGia.Size = new Size(150, 36);

            // Button Add
            this.btnAddItem.BorderRadius = 6;
            this.btnAddItem.FillColor = Color.FromArgb(52, 152, 219);
            this.btnAddItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnAddItem.ForeColor = Color.White;
            this.btnAddItem.Location = new Point(670, y + 22);
            this.btnAddItem.Size = new Size(200, 36);
            this.btnAddItem.Text = "➕ Thêm vào danh sách";
            this.btnAddItem.Click += new EventHandler(this.BtnAddItem_Click);

            // pnlItems
            this.pnlItems.Controls.Add(this.dgvItems);
            this.pnlItems.Controls.Add(this.lblItemsList);
            this.pnlItems.Dock = DockStyle.Fill;
            this.pnlItems.Location = new Point(0, 320);
            this.pnlItems.Padding = new Padding(20, 10, 20, 10);
            this.pnlItems.Size = new Size(900, 310);

            // lblItemsList
            this.lblItemsList.Dock = DockStyle.Top;
            this.lblItemsList.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblItemsList.Location = new Point(20, 10);
            this.lblItemsList.Size = new Size(860, 25);
            this.lblItemsList.Text = "📋 Danh sách hàng nhập";

            // dgvItems
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.ColumnHeadersHeight = 35;
            this.dgvItems.Columns.AddRange(new DataGridViewColumn[] {
                this.colProductName, this.colUnitName, this.colSoLuong,
                this.colDonGia, this.colThanhTien, this.colDelete
            });
            this.dgvItems.Dock = DockStyle.Fill;
            this.dgvItems.Location = new Point(20, 35);
            this.dgvItems.RowTemplate.Height = 40;
            this.dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.CellContentClick += new DataGridViewCellEventHandler(this.DgvItems_CellContentClick);

            // Columns
            this.colProductName.HeaderText = "Sản phẩm";
            this.colProductName.Name = "colProductName";
            this.colProductName.FillWeight = 140F;
            this.colProductName.ReadOnly = true;

            this.colUnitName.HeaderText = "Đơn vị";
            this.colUnitName.Name = "colUnitName";
            this.colUnitName.FillWeight = 80F;
            this.colUnitName.ReadOnly = true;

            this.colSoLuong.HeaderText = "Số lượng";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.FillWeight = 80F;
            this.colSoLuong.ReadOnly = true;
            this.colSoLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.FillWeight = 100F;
            this.colDonGia.ReadOnly = true;
            this.colDonGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.FillWeight = 100F;
            this.colThanhTien.ReadOnly = true;
            this.colThanhTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.colDelete.HeaderText = "";
            this.colDelete.Name = "colDelete";
            this.colDelete.FillWeight = 60F;
            this.colDelete.ReadOnly = true;
            this.colDelete.Text = "🗑️ Xóa";
            this.colDelete.UseColumnTextForButtonValue = true;

            // pnlFooter
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Controls.Add(this.lblError);
            this.pnlFooter.Controls.Add(this.lblTotal);
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.FillColor = Color.FromArgb(240, 248, 255);
            this.pnlFooter.Location = new Point(0, 630);
            this.pnlFooter.Padding = new Padding(20, 10, 20, 10);
            this.pnlFooter.Size = new Size(900, 120);

            // lblTotal
            this.lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTotal.ForeColor = Color.FromArgb(0, 150, 120);
            this.lblTotal.Location = new Point(20, 10);
            this.lblTotal.Size = new Size(400, 35);
            this.lblTotal.Text = "Tổng tiền: 0 đ";
            this.lblTotal.TextAlign = ContentAlignment.MiddleLeft;

            // lblError
            this.lblError.Font = new Font("Segoe UI", 9F);
            this.lblError.ForeColor = Color.Red;
            this.lblError.Location = new Point(20, 50);
            this.lblError.Size = new Size(860, 25);
            this.lblError.TextAlign = ContentAlignment.MiddleLeft;
            this.lblError.Visible = false;

            // Buttons
            this.btnSave.BorderRadius = 8;
            this.btnSave.FillColor = Color.FromArgb(0, 150, 120);
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(500, 70);
            this.btnSave.Size = new Size(180, 40);
            this.btnSave.Text = "💾 Lưu phiếu nhập";
            this.btnSave.Click += new EventHandler(this.BtnSave_Click);

            this.btnCancel.BorderRadius = 8;
            this.btnCancel.FillColor = Color.FromArgb(220, 53, 69);
            this.btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(690, 70);
            this.btnCancel.Size = new Size(180, 40);
            this.btnCancel.Text = "❌ Hủy bỏ";
            this.btnCancel.Click += new EventHandler(this.BtnCancel_Click);

            // Form
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            this.ClientSize = new Size(850, 750);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GoodsReceiptAddEditDialog";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Tạo Phiếu Nhập Kho";

            this.pnlMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlReceiptInfo.ResumeLayout(false);
            this.pnlProductInput.ResumeLayout(false);
            this.pnlItems.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna2Panel pnlMain;
        private Guna2Panel pnlHeader;
        private Guna2Panel pnlReceiptInfo;
        private Guna2Panel pnlProductInput;
        private Guna2Panel pnlItems;
        private Guna2Panel pnlFooter;

        private Label lblTitle;
        private Label lblSupplier;
        private Guna2ComboBox cboSupplier;
        private Label lblNgayNhap;
        private Guna2DateTimePicker dtpNgayNhap;
        private Label lblGhiChu;
        private Guna2TextBox txtGhiChu;

        private Label lblProductSection;
        private Label lblProduct;
        private Guna2ComboBox cboProduct;
        private Label lblUnit;
        private Guna2ComboBox cboUnit;
        private Label lblSoLuong;
        private Guna2TextBox txtSoLuong;
        private Label lblDonGia;
        private Guna2TextBox txtDonGia;
        private Guna2Button btnAddItem;

        private Label lblItemsList;
        private Guna2DataGridView dgvItems;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colUnitName;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colDonGia;
        private DataGridViewTextBoxColumn colThanhTien;
        private DataGridViewButtonColumn colDelete;

        private Label lblTotal;
        private Label lblError;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;
    }
}