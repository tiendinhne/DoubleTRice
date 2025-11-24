using DoubleTRice.DAO;
using DoubleTRice.LOGIC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DoubleTRice.UI
{
    public partial class ForgotPasswordUI : Form
    {
        private int currentStep = 1; // 1=Username, 2=Security, 3=NewPassword
        private string username = "";
        private string securityQuestion = "";
        public ForgotPasswordUI()
        {
            InitializeComponent();
            ShowStep1();
        }
        private void ForgotPasswordUI_Load(object sender, EventArgs e)
        {
            // Apply rounded corners
            ApplyRoundedCorners(pnlMain, 25);
        }
        //#region Step Navigation
        private void ShowStep1()
        {
            currentStep = 1;
            lblTitle.Text = "Quên mật khẩu";
            lblInstruction.Text = "Bước 1: Nhập tên đăng nhập của bạn";

            txtInput.Clear();
            txtInput.PlaceholderText = "Tên đăng nhập";
            txtInput.PasswordChar = '\0';

            btnNext.Text = "Tiếp tục";
            btnBack.Visible = false;

            lblError.Visible = false;
            txtInput.Focus();
        }

        private void ShowStep2(string question)
        {
            currentStep = 2;
            securityQuestion = question;

            lblTitle.Text = "Câu hỏi bảo mật";
            lblInstruction.Text = $"Bước 2: {question}";

            txtInput.Clear();
            txtInput.PlaceholderText = "Nhập câu trả lời";
            txtInput.PasswordChar = '\0';

            btnNext.Text = "Xác nhận";
            btnBack.Visible = true;

            lblError.Visible = false;
            txtInput.Focus();
        }

        private void ShowStep3()
        {
            currentStep = 3;
            lblTitle.Text = "Đặt mật khẩu mới";
            lblInstruction.Text = "Bước 3: Nhập mật khẩu mới (tối thiểu 6 ký tự)";

            txtInput.Clear();
            txtInput.PlaceholderText = "Mật khẩu mới";
            txtInput.PasswordChar = '●';

            btnNext.Text = "Hoàn tất";
            btnBack.Visible = true;

            lblError.Visible = false;
            txtInput.Focus();
        }

        #region Button Events
        private void BtnNext_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                ShowError("⚠️ Vui lòng nhập đầy đủ thông tin");
                return;
            }

            btnNext.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                switch (currentStep)
                {
                    case 1:
                        ProcessStep1(input);
                        break;
                    case 2:
                        ProcessStep2(input);
                        break;
                    case 3:
                        ProcessStep3(input);
                        break;
                }
            }
            finally
            {
                btnNext.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (currentStep == 2)
            {
                ShowStep1();
            }
            else if (currentStep == 3)
            {
                ShowStep2(securityQuestion);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Step Processing
        private void ProcessStep1(string input)
        {
            username = input;

            // Lấy câu hỏi bảo mật
            var result = UserDAO.Instance.GetSecurityQuestion(username);

            if (result.success)
            {
                ShowStep2(result.question);
            }
            else
            {
                ShowError("❌ Tên đăng nhập không tồn tại");
            }
        }

        private void ProcessStep2(string answer)
        {
            string answerHash = PasswordHelper.HashPassword(answer);

            var result = UserDAO.Instance.VerifySecurityAnswer(username, answerHash);

            if (result == 0)
            {
                ShowStep3();
            }
            else if (result == -2)
            {
                ShowError("❌ Câu trả lời không đúng");
            }
            else
            {
                ShowError("❌ Có lỗi xảy ra. Vui lòng thử lại");
            }
        }

        private void ProcessStep3(string newPassword)
        {
            // Validate password
            if (!PasswordHelper.ValidatePassword(newPassword, out string errorMsg))
            {
                ShowError($"❌ {errorMsg}");
                return;
            }

            string newPasswordHash = PasswordHelper.HashPassword(newPassword);

            int result = UserDAO.Instance.ResetPassword(username, newPasswordHash);

            if (result == 0)
            {
                ShowSuccess("✅ Đặt lại mật khẩu thành công!\n\nBạn có thể đăng nhập với mật khẩu mới.");

                Timer closeTimer = new Timer();
                closeTimer.Interval = 2000;
                closeTimer.Tick += (s, e) =>
                {
                    closeTimer.Stop();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                };
                closeTimer.Start();
            }
            else
            {
                ShowError("❌ Không thể đặt lại mật khẩu. Vui lòng thử lại");
            }
        }
        #endregion

        #region UI Helpers
        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.BackColor = Color.FromArgb(255, 80, 80);
            lblError.ForeColor = Color.White;
            lblError.Visible = true;
        }

        private void ShowSuccess(string message)
        {
            lblError.Text = message;
            lblError.BackColor = Color.FromArgb(80, 200, 120);
            lblError.ForeColor = Color.White;
            lblError.Visible = true;
        }

        private void ApplyRoundedCorners(Control control, int radius)
        {
            try
            {
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.StartFigure();
                path.AddArc(new Rectangle(0, 0, radius * 2, radius * 2), 180, 90);
                path.AddLine(radius, 0, control.Width - radius, 0);
                path.AddArc(new Rectangle(control.Width - radius * 2, 0, radius * 2, radius * 2), 270, 90);
                path.AddLine(control.Width, radius, control.Width, control.Height - radius);
                path.AddArc(new Rectangle(control.Width - radius * 2, control.Height - radius * 2, radius * 2, radius * 2), 0, 90);
                path.AddLine(control.Width - radius, control.Height, radius, control.Height);
                path.AddArc(new Rectangle(0, control.Height - radius * 2, radius * 2, radius * 2), 90, 90);
                path.CloseFigure();
                control.Region = new Region(path);
            }
            catch { }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnNext.PerformClick();
                return true;
            }
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}
