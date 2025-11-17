using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoubleTRice.DAO;
using DoubleTRice.LOGIC;

namespace DoubleTRice.UI
{
    public partial class LoginUI : Form
    {
        #region Fields
        private bool isPasswordVisible = false;
        private int loginAttempts = 0;
        private const int MAX_LOGIN_ATTEMPTS = 3;  // so lan toi da duoc nhap mat khau
        #endregion

        #region Constructor
        public LoginUI()
        {
            InitializeComponent();
            InitializeUI();
        }
        #endregion

        #region Initialization
        private void InitializeUI()
        {
            // Hide error label
            label3.Visible = false;

            // Set password char
            guna2TextBox2.PasswordChar = '●';

            // Hide show password icon initially
            pictureBox1.Visible = false;
            pictureBox3.Visible = true;

            // Set placeholder text
            guna2TextBox1.PlaceholderText = "Nhập tên đăng nhập";
            guna2TextBox2.PlaceholderText = "Nhập mật khẩu";

            // Set enter key handler
            guna2TextBox1.KeyDown += TextBox_KeyDown;
            guna2TextBox2.KeyDown += TextBox_KeyDown;
            guna2TextBox1.TextChanged += (s, e) => HideError();
            guna2TextBox2.TextChanged += (s, e) => HideError();

            // Focus vào username
            guna2TextBox1.Focus();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                guna2GradientButton1.PerformClick();
            }
        }
        #endregion

        #region Login Logic
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void PerformLogin()
        {
            // Validate input
            string username = guna2TextBox1.Text.Trim();
            string password = guna2TextBox2.Text;

            if (string.IsNullOrEmpty(username))
            {
                ShowError("Vui lòng nhập tên đăng nhập");
                guna2TextBox1.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                ShowError("Vui lòng nhập mật khẩu");
                guna2TextBox2.Focus();
                return;
            }

            // Check max attempts
            if (loginAttempts >= MAX_LOGIN_ATTEMPTS)
            {
                ShowError("Đã vượt quá số lần đăng nhập. Ứng dụng sẽ đóng.");
                System.Threading.Thread.Sleep(2000);
                Application.Exit();
                return;
            }

            // Show loading
            guna2GradientButton1.Text = "Đang đăng nhập...";
            guna2GradientButton1.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // Hash password
                //string passwordHash = PasswordHelper.HashPassword(password);

                // Call login
                //var result = UserDAO.Instance.Login(username, passwordHash);
                var result = AuthenticationService.Login(username, password);

                if (result.Success)
                {
                    // Đăng nhập thành công
                    loginAttempts = 0;
                    HideError();

                    // Lưu session
                    UserSession.Initialize(result.UserID, result.HoTen, username, result.VaiTro);

                    // Show success
                    MessageBox.Show($"Đăng nhập thành công!\n\nXin chào {result.HoTen}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở MainUI
                    this.Hide();
                    MainUI mainUI = new MainUI();
                    mainUI.SetUserInfo(result.HoTen, result.VaiTro);
                    mainUI.SetMenuVisibility(result.VaiTro);
                    mainUI.FormClosed += (s, args) => this.Close();
                    mainUI.Show();
                }
                else
                {
                    // Login thất bại
                    loginAttempts++;
                    ShowError($"{result.Message}\n(Lần thử: {loginAttempts}/{MAX_LOGIN_ATTEMPTS})");

                    // Clear password
                    guna2TextBox2.Clear();
                    guna2TextBox2.Focus();
                }
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi: {ex.Message}");
            }
            finally
            {
                // Reset button
                guna2GradientButton1.Text = "LOGIN";
                guna2GradientButton1.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Show/Hide Password
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Hide password
            isPasswordVisible = false;
            guna2TextBox2.PasswordChar = '●';
            pictureBox1.Visible = false;
            pictureBox3.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Show password
            isPasswordVisible = true;
            guna2TextBox2.PasswordChar = '\0';
            pictureBox1.Visible = true;
            pictureBox3.Visible = false;
        }
        #endregion

        #region Helper Methods
        private void ShowError(string message)
        {
            label3.Text = message;
            label3.Visible = true;
            label3.ForeColor = Color.Red;
        }

        private void HideError()
        {
            label3.Visible = false;
        }
        #endregion

        #region Event Handlers
        private void label4_Click(object sender, EventArgs e)
        {
            // Forgot password
            MessageBox.Show("Vui lòng liên hệ quản trị viên để reset mật khẩu\nEmail: tiendinh@gmail.com",
                "Quên mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // Contact info - Already displayed on form
        }

        private void lbname_Click(object sender, EventArgs e)
        {
        }

        private void lbpwd_Click(object sender, EventArgs e)
        {
        }

        private void txBusername_TextChanged(object sender, EventArgs e)
        {
            HideError();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region Form Events
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Clear sensitive data
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            base.OnFormClosing(e);
        }
        #endregion

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}