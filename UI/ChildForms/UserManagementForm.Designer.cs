using DoubleTRice.UI.BASE;
using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    partial class UserManagementForm
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
         
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();

            // Initialize components
            this.pnlHeader = new Guna2Panel();
            this.pnlContent = new Guna2Panel();
            this.pnlActions = new Guna2Panel();
            this.lblTitle = new Label();
            this.txtSearch = new Guna2TextBox();
            this.cboRoleFilter = new Guna2ComboBox();
            this.btnAdd = new Guna2Button();
            this.btnRefresh = new Guna2Button();
            this.dgvUsers = new Guna2DataGridView();

            // DataGridView Columns
            this.colUserID = new DataGridViewTextBoxColumn();
            this.colHoTen = new DataGridViewTextBoxColumn();
            this.colTenDangNhap = new DataGridViewTextBoxColumn();
            this.colVaiTro = new DataGridViewTextBoxColumn();
            this.colIsLocked = new DataGridViewTextBoxColumn();
            this.colFailedAttempts = new DataGridViewTextBoxColumn();
            this.colLastLogin = new DataGridViewTextBoxColumn();
            this.colCreatedDate = new DataGridViewTextBoxColumn();
            this.colActions = new DataGridViewButtonColumn();

            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.txtSearch);
            this.pnlHeader.Controls.Add(this.cboRoleFilter);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.FillColor = Color.Transparent;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new Padding(20, 15, 20, 15);
            this.pnlHeader.Size = new Size(1050, 80);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.Dock = DockStyle.Left;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Mode.GetForeColor();
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(400, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "👥 Quản lý Người dùng";
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.FillColor = Color.FromArgb(30, 30, 30);
            this.txtSearch.FocusedState.BorderColor = Color.FromArgb(0, 150, 120);
            this.txtSearch.Font = new Font("Segoe UI", 9F);
            this.txtSearch.ForeColor = Mode.GetForeColor();
            this.txtSearch.Location = new Point(430, 20);
            this.txtSearch.Margin = new Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "🔍 Tìm kiếm theo tên, username...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new Size(400, 40);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);

            // 
            // cboRoleFilter
            // 
            this.cboRoleFilter.BackColor = Color.Transparent;
            this.cboRoleFilter.BorderRadius = 8;
            this.cboRoleFilter.DrawMode = DrawMode.OwnerDrawFixed;
            this.cboRoleFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboRoleFilter.FillColor = Color.FromArgb(30, 30, 30);
            this.cboRoleFilter.FocusedColor = Color.FromArgb(0, 150, 120);
            this.cboRoleFilter.Font = new Font("Segoe UI", 9F);
            this.cboRoleFilter.ForeColor = Mode.GetForeColor();
            this.cboRoleFilter.Items.AddRange(new object[] {
            "Tất cả vai trò",
            "Admin",
            "Thu Ngân",
            "Thủ Kho",
            "Kế Toán"
        });
            this.cboRoleFilter.Location = new Point(840, 20);
            this.cboRoleFilter.Name = "cboRoleFilter";
            this.cboRoleFilter.Size = new Size(190, 40);
            this.cboRoleFilter.StartIndex = 0;
            this.cboRoleFilter.TabIndex = 2;
            this.cboRoleFilter.SelectedIndexChanged += new System.EventHandler(this.CboRoleFilter_SelectedIndexChanged);

            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnRefresh);
            this.pnlActions.Controls.Add(this.btnAdd);
            this.pnlActions.Dock = DockStyle.Top;
            this.pnlActions.FillColor = Color.Transparent;
            this.pnlActions.Location = new Point(0, 80);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new Padding(20, 10, 20, 10);
            this.pnlActions.Size = new Size(1050, 70);
            this.pnlActions.TabIndex = 1;

            // 
            // btnAdd
            // 
            this.btnAdd.BorderRadius = 8;
            this.btnAdd.FillColor = Color.FromArgb(0, 150, 120);
            this.btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.HoverState.FillColor = Color.FromArgb(0, 130, 100);
            this.btnAdd.Location = new Point(20, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(180, 40);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "➕ Thêm người dùng";
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);

            // 
            // btnRefresh
            // 
            this.btnRefresh.BorderRadius = 8;
            this.btnRefresh.FillColor = Color.FromArgb(100, 120, 140);
            this.btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.HoverState.FillColor = Color.FromArgb(80, 100, 120);
            this.btnRefresh.Location = new Point(210, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(150, 40);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);

            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvUsers);
            this.pnlContent.Dock = DockStyle.Fill;
            this.pnlContent.FillColor = Color.Transparent;
            this.pnlContent.Location = new Point(0, 150);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new Padding(20);
            this.pnlContent.Size = new Size(1050, 476);
            this.pnlContent.TabIndex = 2;

            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(30, 30, 30);
            this.dgvUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = Mode.GetBodyColor();
            this.dgvUsers.BorderStyle = BorderStyle.None;
            this.dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Mode.GetButtonCheckedColor();
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Mode.GetButtonCheckedColor();
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsers.ColumnHeadersHeight = 40;
            this.dgvUsers.Columns.AddRange(new DataGridViewColumn[] {
            this.colUserID,
            this.colHoTen,
            this.colTenDangNhap,
            this.colVaiTro,
            this.colIsLocked,
            this.colFailedAttempts,
            this.colLastLogin,
            this.colCreatedDate,
            this.colActions
        });

            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Mode.GetBodyColor();
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Mode.GetForeColor();
            dataGridViewCellStyle3.SelectionBackColor = Mode.GetButtonCheckedColor();
            dataGridViewCellStyle3.SelectionForeColor = Mode.GetForeColor();
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            this.dgvUsers.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUsers.Dock = DockStyle.Fill;
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.GridColor = Mode.GetSeparatorColor();
            this.dgvUsers.Location = new Point(20, 20);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = false;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowTemplate.Height = 45;
            this.dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new Size(1010, 436);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.CellContentClick += new DataGridViewCellEventHandler(this.DgvUsers_CellContentClick);
            this.dgvUsers.CellEndEdit += new DataGridViewCellEventHandler(this.DgvUsers_CellEndEdit);

            // 
            // colUserID
            // 
            this.colUserID.DataPropertyName = "UserID";
            this.colUserID.FillWeight = 60F;
            this.colUserID.HeaderText = "ID";
            this.colUserID.Name = "colUserID";
            this.colUserID.ReadOnly = true;

            // 
            // colHoTen
            // 
            this.colHoTen.DataPropertyName = "HoTen";
            this.colHoTen.FillWeight = 120F;
            this.colHoTen.HeaderText = "Họ tên";
            this.colHoTen.Name = "colHoTen";

            // 
            // colTenDangNhap
            // 
            this.colTenDangNhap.DataPropertyName = "TenDangNhap";
            this.colTenDangNhap.FillWeight = 100F;
            this.colTenDangNhap.HeaderText = "Tên đăng nhập";
            this.colTenDangNhap.Name = "colTenDangNhap";

            // 
            // colVaiTro
            // 
            this.colVaiTro.DataPropertyName = "VaiTro";
            this.colVaiTro.FillWeight = 90F;
            this.colVaiTro.HeaderText = "Vai trò";
            this.colVaiTro.Name = "colVaiTro";

            // 
            // colIsLocked
            // 
            this.colIsLocked.DataPropertyName = "IsLocked";
            this.colIsLocked.FillWeight = 80F;
            this.colIsLocked.HeaderText = "Trạng thái";
            this.colIsLocked.Name = "colIsLocked";
            this.colIsLocked.ReadOnly = true;

            // 
            // colFailedAttempts
            // 
            this.colFailedAttempts.DataPropertyName = "FailedLoginAttempts";
            this.colFailedAttempts.FillWeight = 70F;
            this.colFailedAttempts.HeaderText = "Lỗi đăng nhập";
            this.colFailedAttempts.Name = "colFailedAttempts";
            this.colFailedAttempts.ReadOnly = true;

            // 
            // colLastLogin
            // 
            this.colLastLogin.DataPropertyName = "LastLoginDate";
            this.colLastLogin.FillWeight = 110F;
            this.colLastLogin.HeaderText = "Đăng nhập gần nhất";
            this.colLastLogin.Name = "colLastLogin";
            this.colLastLogin.ReadOnly = true;

            // 
            // colCreatedDate
            // 
            this.colCreatedDate.DataPropertyName = "CreatedDate";
            this.colCreatedDate.FillWeight = 110F;
            this.colCreatedDate.HeaderText = "Ngày tạo";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.ReadOnly = true;

            // 
            // colActions
            // 
            this.colActions.FillWeight = 150F;
            this.colActions.HeaderText = "Thao tác";
            this.colActions.Name = "colActions";
            this.colActions.ReadOnly = true;
            this.colActions.Text = "⚙️ Hành động";
            this.colActions.UseColumnTextForButtonValue = true;

            // 
            // UserManagementForm
            // 
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1050, 626);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "UserManagementForm";
            this.Text = "Quản lý Người dùng";

            this.pnlHeader.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        // Panels
        private Guna2Panel pnlHeader;
        private Guna2Panel pnlContent;
        private Guna2Panel pnlActions;

        // Header Controls
        private Label lblTitle;
        private Guna2TextBox txtSearch;
        private Guna2ComboBox cboRoleFilter;

        // Action Buttons
        private Guna2Button btnAdd;
        private Guna2Button btnRefresh;

        // DataGridView
        private Guna2DataGridView dgvUsers;

        // DataGridView Columns
        private DataGridViewTextBoxColumn colUserID;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colTenDangNhap;
        private DataGridViewTextBoxColumn colVaiTro;
        private DataGridViewTextBoxColumn colIsLocked;
        private DataGridViewTextBoxColumn colFailedAttempts;
        private DataGridViewTextBoxColumn colLastLogin;
        private DataGridViewTextBoxColumn colCreatedDate;
        private DataGridViewButtonColumn colActions;
    }
}