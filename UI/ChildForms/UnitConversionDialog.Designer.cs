using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    partial class UnitConversionDialog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlList = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvConversions = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colConversionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConversionValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlAdd = new Guna.UI2.WinForms.Guna2Panel();
            this.lblUnit = new System.Windows.Forms.Label();
            this.cboUnit = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblConversionValue = new System.Windows.Forms.Label();
            this.txtConversionValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAddConversion = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblProductInfo = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMain.SuspendLayout();
            this.pnlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConversions)).BeginInit();
            this.pnlAdd.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.pnlList);
            this.pnlMain.Controls.Add(this.pnlAdd);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Controls.Add(this.lblError);
            this.pnlMain.Controls.Add(this.btnClose);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(700, 600);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlList
            // 
            this.pnlList.Controls.Add(this.dgvConversions);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlList.Location = new System.Drawing.Point(20, 249);
            this.pnlList.Name = "pnlList";
            this.pnlList.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlList.Size = new System.Drawing.Size(660, 291);
            this.pnlList.TabIndex = 0;
            // 
            // dgvConversions
            // 
            this.dgvConversions.AllowUserToAddRows = false;
            this.dgvConversions.AllowUserToDeleteRows = false;
            this.dgvConversions.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvConversions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvConversions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvConversions.ColumnHeadersHeight = 40;
            this.dgvConversions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colConversionID,
            this.colUnitName,
            this.colConversionValue,
            this.colEdit,
            this.colDelete});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConversions.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvConversions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConversions.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvConversions.Location = new System.Drawing.Point(0, 10);
            this.dgvConversions.MultiSelect = false;
            this.dgvConversions.Name = "dgvConversions";
            this.dgvConversions.ReadOnly = true;
            this.dgvConversions.RowHeadersVisible = false;
            this.dgvConversions.RowHeadersWidth = 62;
            this.dgvConversions.RowTemplate.Height = 40;
            this.dgvConversions.Size = new System.Drawing.Size(660, 281);
            this.dgvConversions.TabIndex = 0;
            this.dgvConversions.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvConversions.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvConversions.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvConversions.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvConversions.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvConversions.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvConversions.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvConversions.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvConversions.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvConversions.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvConversions.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvConversions.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvConversions.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvConversions.ThemeStyle.ReadOnly = true;
            this.dgvConversions.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvConversions.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvConversions.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvConversions.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvConversions.ThemeStyle.RowsStyle.Height = 40;
            this.dgvConversions.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvConversions.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvConversions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvConversions_CellContentClick);
            // 
            // colConversionID
            // 
            this.colConversionID.DataPropertyName = "ConversionID";
            this.colConversionID.FillWeight = 60F;
            this.colConversionID.HeaderText = "ID";
            this.colConversionID.MinimumWidth = 8;
            this.colConversionID.Name = "colConversionID";
            this.colConversionID.ReadOnly = true;
            this.colConversionID.Visible = false;
            // 
            // colUnitName
            // 
            this.colUnitName.DataPropertyName = "UnitName";
            this.colUnitName.FillWeight = 150F;
            this.colUnitName.HeaderText = "Đơn vị tính";
            this.colUnitName.MinimumWidth = 8;
            this.colUnitName.Name = "colUnitName";
            this.colUnitName.ReadOnly = true;
            // 
            // colConversionValue
            // 
            this.colConversionValue.DataPropertyName = "GiaTriQuyDoi";
            this.colConversionValue.FillWeight = 120F;
            this.colConversionValue.HeaderText = "= Bao nhiêu kg";
            this.colConversionValue.MinimumWidth = 8;
            this.colConversionValue.Name = "colConversionValue";
            this.colConversionValue.ReadOnly = true;
            // 
            // colEdit
            // 
            this.colEdit.FillWeight = 80F;
            this.colEdit.HeaderText = "Sửa";
            this.colEdit.MinimumWidth = 8;
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Text = "✏️";
            this.colEdit.UseColumnTextForButtonValue = true;
            // 
            // colDelete
            // 
            this.colDelete.FillWeight = 80F;
            this.colDelete.HeaderText = "Xóa";
            this.colDelete.MinimumWidth = 8;
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Text = "🗑️";
            this.colDelete.UseColumnTextForButtonValue = true;
            // 
            // pnlAdd
            // 
            this.pnlAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pnlAdd.BorderRadius = 10;
            this.pnlAdd.Controls.Add(this.lblUnit);
            this.pnlAdd.Controls.Add(this.cboUnit);
            this.pnlAdd.Controls.Add(this.lblConversionValue);
            this.pnlAdd.Controls.Add(this.txtConversionValue);
            this.pnlAdd.Controls.Add(this.btnAddConversion);
            this.pnlAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAdd.Location = new System.Drawing.Point(20, 99);
            this.pnlAdd.Name = "pnlAdd";
            this.pnlAdd.Padding = new System.Windows.Forms.Padding(15);
            this.pnlAdd.Size = new System.Drawing.Size(660, 150);
            this.pnlAdd.TabIndex = 1;
            // 
            // lblUnit
            // 
            this.lblUnit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUnit.Location = new System.Drawing.Point(15, 40);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(150, 20);
            this.lblUnit.TabIndex = 1;
            this.lblUnit.Text = "Đơn vị tính *";
            // 
            // cboUnit
            // 
            this.cboUnit.BackColor = System.Drawing.Color.Transparent;
            this.cboUnit.BorderRadius = 8;
            this.cboUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FocusedColor = System.Drawing.Color.Empty;
            this.cboUnit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboUnit.ItemHeight = 30;
            this.cboUnit.Location = new System.Drawing.Point(15, 75);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(200, 36);
            this.cboUnit.TabIndex = 2;
            // 
            // lblConversionValue
            // 
            this.lblConversionValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConversionValue.Location = new System.Drawing.Point(230, 40);
            this.lblConversionValue.Name = "lblConversionValue";
            this.lblConversionValue.Size = new System.Drawing.Size(200, 33);
            this.lblConversionValue.TabIndex = 3;
            this.lblConversionValue.Text = "Giá trị quy đổi (kg) *";
            // 
            // txtConversionValue
            // 
            this.txtConversionValue.BorderRadius = 8;
            this.txtConversionValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConversionValue.DefaultText = "";
            this.txtConversionValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtConversionValue.Location = new System.Drawing.Point(230, 76);
            this.txtConversionValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConversionValue.Name = "txtConversionValue";
            this.txtConversionValue.PlaceholderText = "VD: 25 (= 25kg)";
            this.txtConversionValue.SelectedText = "";
            this.txtConversionValue.Size = new System.Drawing.Size(200, 35);
            this.txtConversionValue.TabIndex = 4;
            this.txtConversionValue.TextChanged += new System.EventHandler(this.txtConversionValue_TextChanged);
            // 
            // btnAddConversion
            // 
            this.btnAddConversion.BorderRadius = 8;
            this.btnAddConversion.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.btnAddConversion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddConversion.ForeColor = System.Drawing.Color.White;
            this.btnAddConversion.Location = new System.Drawing.Point(493, 57);
            this.btnAddConversion.Name = "btnAddConversion";
            this.btnAddConversion.Size = new System.Drawing.Size(122, 54);
            this.btnAddConversion.TabIndex = 5;
            this.btnAddConversion.Text = "➕ Thêm";
            this.btnAddConversion.Click += new System.EventHandler(this.BtnAddConversion_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.MistyRose;
            this.pnlHeader.BorderRadius = 10;
            this.pnlHeader.Controls.Add(this.lblProductInfo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(20, 20);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(15);
            this.pnlHeader.Size = new System.Drawing.Size(660, 79);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblProductInfo
            // 
            this.lblProductInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblProductInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblProductInfo.ForeColor = System.Drawing.Color.Red;
            this.lblProductInfo.Location = new System.Drawing.Point(15, 15);
            this.lblProductInfo.Name = "lblProductInfo";
            this.lblProductInfo.Size = new System.Drawing.Size(630, 49);
            this.lblProductInfo.TabIndex = 1;
            this.lblProductInfo.Text = "Sản phẩm: ...";
            this.lblProductInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblError.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblError.ForeColor = System.Drawing.Color.DarkRed;
            this.lblError.Location = new System.Drawing.Point(20, 540);
            this.lblError.Name = "lblError";
            this.lblError.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.lblError.Size = new System.Drawing.Size(660, 0);
            this.lblError.TabIndex = 3;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 8;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(140)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(20, 540);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(660, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // UnitConversionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UnitConversionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý Quy đổi Đơn vị";
            this.pnlMain.ResumeLayout(false);
            this.pnlList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConversions)).EndInit();
            this.pnlAdd.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna2Panel pnlMain;
        private Guna2Panel pnlHeader;
        private Label lblProductInfo;
        private Guna2Panel pnlAdd;
        private Label lblUnit;
        private Guna2ComboBox cboUnit;
        private Label lblConversionValue;
        private Guna2TextBox txtConversionValue;
        private Guna2Button btnAddConversion;
        private Guna2Panel pnlList;
        private Guna2DataGridView dgvConversions;
        private DataGridViewTextBoxColumn colConversionID;
        private DataGridViewTextBoxColumn colUnitName;
        private DataGridViewTextBoxColumn colConversionValue;
        private DataGridViewButtonColumn colEdit;
        private DataGridViewButtonColumn colDelete;
        private Label lblError;
        private Guna2Button btnClose;
    }
}