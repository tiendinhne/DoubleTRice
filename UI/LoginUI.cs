using DoubleTRice.DAO;
using DoubleTRice.LOGIC;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoubleTRice.UI
{
    public partial class LoginUI : Form
    {
        #region Fields
        private bool isPasswordVisible = false;
        private int loginAttempts = 0;
        private const int MAX_LOGIN_ATTEMPTS = 5;
        private double formOpacity = 0;
        #endregion

        #region Constructor
        public LoginUI()
        {
            InitializeComponent();
            //this.Opacity = 0;
            //pnlLogin.BackColor = Color.FromArgb(10, Color.Black);
        }
        #endregion

        #region Form Load & Initialization
        private void LoginUI_Load(object sender, EventArgs e)
        {
            InitializeUI();
            StartFadeInAnimation();
            LoadRememberedCredentials();
        }

        private void InitializeUI()
        {
            // Hide error initially
            lblError.Visible = false;
            lblError.Height = 0;

            // Set password visibility
            txtPassword.PasswordChar = '●';
            isPasswordVisible = false;

            // Set placeholders
            txtUsername.PlaceholderText = "Username";
            txtPassword.PlaceholderText = "Password";

            // Set enter key handlers
            txtUsername.KeyDown += TextBox_KeyDown;
            txtPassword.KeyDown += TextBox_KeyDown;

            // Hide error when typing
            txtUsername.TextChanged += (s, e) => HideError();
            txtPassword.TextChanged += (s, e) => HideError();

            ApplyRoundedCorners(pnlLogin, 25);
            // Focus on username
            txtUsername.Focus();

            // Set version
            lblVersion.Text = $"v{Application.ProductVersion}";
        }
        // METHOD MỚI - Bo tròn góc
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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ApplyRoundedCorners error: {ex.Message}");
            }

        }

        private void StartFadeInAnimation()
        {
            fadeInTimer.Start();
        }

        private void FadeInTimer_Tick(object sender, EventArgs e)
        {
            if (formOpacity < 1)
            {
                formOpacity += 0.05;
                this.Opacity = formOpacity;
            }
            else
            {
                fadeInTimer.Stop();
            }
        }
        #endregion

        #region Remember Me Functionality
        private void LoadRememberedCredentials()
        {
            try
            {
                string savedUsername = Properties.Settings.Default.RememberedUsername ?? "";
                bool rememberMe = Properties.Settings.Default.RememberMe;

                if (rememberMe && !string.IsNullOrEmpty(savedUsername))
                {
                    txtUsername.Text = savedUsername;
                    chkRememberMe.Checked = true;
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Load credentials error: {ex.Message}");
            }
        }

        private void SaveRememberedCredentials()
        {
            try
            {
                if (chkRememberMe.Checked)
                {
                    Properties.Settings.Default.RememberedUsername = txtUsername.Text.Trim();
                    Properties.Settings.Default.RememberMe = true;
                }
                else
                {
                    Properties.Settings.Default.RememberedUsername = "";
                    Properties.Settings.Default.RememberMe = false;
                }
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Save credentials error: {ex.Message}");
            }
        }
        #endregion

        #region Event Handlers - Login Button
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnLogin.PerformClick();
            }
        }
        #endregion

        #region Login Logic
        private void PerformLogin()
        {
            // TEST CONNECTION
            try
            {
                bool connected = DataProvider.Instance.TestConnection();
                if (!connected)
                {
                    ShowError("❌ Không kết nối được database!\nKiểm tra SQL Server đã chạy chưa.");
                    return;
                }
                MessageBox.Show("✅ Kết nối DB thành công!", "Debug");
            }
            catch (Exception ex)
            {
                ShowError($"❌ Lỗi kết nối:\n{ex.Message}");
                return;
            }
            // Validate input
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // DEBUG: Kiểm tra hash
            string hashedPassword = PasswordHelper.HashPassword(password);
            MessageBox.Show(
                $"Username: {username}\n" +
                $"Password: {password}\n" +
                $"Hashed: {hashedPassword}",
                "Debug - Password Hash"
            );

            if (string.IsNullOrEmpty(username))
            {
                ShowError("⚠️ Vui lòng nhập tên đăng nhập");
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                ShowError("⚠️ Vui lòng nhập mật khẩu");
                txtPassword.Focus();
                return;
            }

            // Check max attempts
            if (loginAttempts >= MAX_LOGIN_ATTEMPTS)
            {
                ShowError($"❌ Đã vượt quá {MAX_LOGIN_ATTEMPTS} lần đăng nhập sai.\nỨng dụng sẽ đóng trong 3 giây...");

                Timer closeTimer = new Timer();
                closeTimer.Interval = 3000;
                closeTimer.Tick += (s, e) =>
                {
                    closeTimer.Stop();
                    Application.Exit();
                };
                closeTimer.Start();
                return;
            }

            // Show loading state
            SetLoadingState(true);

            try
            {
                // Call login service
                var result = AuthenticationService.Login(username, password);
                MessageBox.Show(
                    $"Success: {result.Success}\n" +
                    $"ResultCode: {result.ResultCode}\n" +
                    $"UserID: {result.UserID}\n" +
                    $"HoTen: {result.HoTen}\n" +
                    $"VaiTro: {result.VaiTro}\n" +
                    $"Message: {result.Message}",
                    "Debug - Login Result"
                );

                if (result.Success)
                {
                    // Login successful
                    loginAttempts = 0;
                    HideError();

                    // Save remember me
                    SaveRememberedCredentials();

                    // Save session
                    UserSession.Initialize(result.UserID, result.HoTen, username, result.VaiTro);

                    // Show success message
                    ShowSuccess($"✅ Đăng nhập thành công!\nChào mừng {result.HoTen}");

                    // Delay before opening main form
                    Timer successTimer = new Timer();
                    successTimer.Interval = 1000;
                    successTimer.Tick += (s, e) =>
                    {
                        successTimer.Stop();
                        OpenMainUI(result.HoTen, result.VaiTro);
                    };
                    successTimer.Start();
                }
                else
                {
                    // Login failed
                    loginAttempts++;

                    string errorMsg = $"❌ {result.Message}";

                    if (result.ResultCode == -3)
                    {
                        errorMsg += "\n\n🔒 Tài khoản đã bị khóa do đăng nhập sai quá nhiều lần.\nVui lòng liên hệ quản trị viên.";
                    }
                    else
                    {
                        errorMsg += $"\n\n(Lần thử: {loginAttempts}/{MAX_LOGIN_ATTEMPTS})";

                        if (loginAttempts >= MAX_LOGIN_ATTEMPTS - 2)
                        {
                            errorMsg += $"\n⚠️ Còn {MAX_LOGIN_ATTEMPTS - loginAttempts} lần thử!";
                        }
                    }

                    ShowError(errorMsg);

                    // Clear password
                    txtPassword.Clear();
                    txtPassword.Focus();

                    // Shake animation
                    ShakeForm();
                }
            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                ShowError($"❌ Lỗi kết nối database:\n{sqlEx.Message}\n\nKiểm tra:\n- SQL Server đã khởi động\n- Connection string đúng");
            }
            catch (Exception ex)
            {
                ShowError($"❌ Lỗi hệ thống:\n{ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Login error: {ex}");
            }
            finally
            {
                SetLoadingState(false);
            }
        }

        private void OpenMainUI(string hoTen, string vaiTro)
        {
            this.Hide();
            MainUI mainUI = new MainUI();
            mainUI.SetUserInfo(hoTen, vaiTro);
            mainUI.SetMenuVisibility(vaiTro);
            mainUI.FormClosed += (s, args) => this.Close();
            mainUI.Show();
        }
        #endregion

        #region UI State Management
        private void SetLoadingState(bool isLoading)
        {
            if (isLoading)
            {
                btnLogin.Text = "Đang đăng nhập...";
                btnLogin.Enabled = false;
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
                chkRememberMe.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
            }
            else
            {
                btnLogin.Text = "LOGIN";
                btnLogin.Enabled = true;
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
                chkRememberMe.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Event Handlers - Toggle Password
        private void TxtPassword_IconRightClick(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            txtPassword.PasswordChar = isPasswordVisible ? '\0' : '●';

            // Change icon color when visible
            //if (isPasswordVisible)
            //{
            //    txtPassword.IconRightImage = Properties.Resources.eye_slash_icon; // Icon mắt gạch
            //}
            //else
            //{
            //    txtPassword.IconRightImage = Properties.Resources.eye_icon; // Icon mắt thường
            //}
        }
        #endregion

        #region Event Handlers - Forgot Password
        private void LblForgotPassword_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Để reset mật khẩu, vui lòng liên hệ quản trị viên:\n\n" +
                "📧 Email: tiendinh@gmail.com\n" +
                "📱 Hotline: 0123-456-789\n\n" +
                "Bạn có muốn mở email không?",
                "Quên mật khẩu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process.Start("mailto:tiendinh@gmail.com?subject=Reset Password Request");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể mở email client:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LblForgotPassword_MouseEnter(object sender, EventArgs e)
        {
            //lblForgotPassword.ForeColor = Color.FromArgb(120, 210, 255);
            lblForgotPassword.Font = new Font(lblForgotPassword.Font, FontStyle.Underline);
        }

        private void LblForgotPassword_MouseLeave(object sender, EventArgs e)
        {
            //lblForgotPassword.ForeColor = Color.FromArgb(100, 200, 255);
            lblForgotPassword.Font = new Font(lblForgotPassword.Font, FontStyle.Regular);
        }
        #endregion

        #region Window Control Buttons
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Timer fadeOutTimer = new Timer();
            fadeOutTimer.Interval = 20;
            fadeOutTimer.Tick += (s, e2) =>
            {
                if (this.Opacity > 0)
                {
                    this.Opacity -= 0.1;
                }
                else
                {
                    fadeOutTimer.Stop();
                    Application.Exit();
                }
            };
            fadeOutTimer.Start();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Helper Methods - Error/Success Display
        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
            lblError.BackColor = Color.FromArgb(255, 80, 80);
            lblError.ForeColor = Color.White;

            // Auto-resize based on text
            using (Graphics g = this.CreateGraphics())
            {
                SizeF size = g.MeasureString(message, lblError.Font, lblError.Width - 24);
                lblError.Height = (int)Math.Ceiling(size.Height) + 20;
            }
        }

        private void ShowSuccess(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
            lblError.BackColor = Color.FromArgb(80, 200, 120);
            lblError.ForeColor = Color.White;

            using (Graphics g = this.CreateGraphics())
            {
                SizeF size = g.MeasureString(message, lblError.Font, lblError.Width - 24);
                lblError.Height = (int)Math.Ceiling(size.Height) + 20;
            }
        }

        private void HideError()
        {
            lblError.Visible = false;
            lblError.Height = 0;
        }
        #endregion

        #region Animations
        private void ShakeForm()
        {
            int originalX = this.Location.X;
            int shakeDistance = 10;
            int shakeCount = 0;
            int maxShakes = 6;

            Timer shakeTimer = new Timer();
            shakeTimer.Interval = 50;
            shakeTimer.Tick += (s, e) =>
            {
                if (shakeCount < maxShakes)
                {
                    this.Location = new Point(
                        originalX + (shakeCount % 2 == 0 ? shakeDistance : -shakeDistance),
                        this.Location.Y
                    );
                    shakeCount++;
                }
                else
                {
                    this.Location = new Point(originalX, this.Location.Y);
                    shakeTimer.Stop();
                }
            };
            shakeTimer.Start();
        }
        #endregion

        #region Form Events
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            base.OnFormClosing(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CenterLoginPanel();
        }

        private void CenterLoginPanel()
        {
            if (pnlLogin != null && this.ClientSize.Height > 0)
            {
                int centerY = (this.ClientSize.Height - pnlLogin.Height) / 2;// can giua
                int rightMargin = 30; //30px

                pnlLogin.Location = new Point(
                    this.ClientSize.Width - pnlLogin.Width - rightMargin,
                    centerY
                );
            }
        }
        #endregion

        #region Keyboard Shortcuts
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                BtnClose_Click(null, null);
                return true;
            }

            if (keyData == Keys.F1)
            {
                LblForgotPassword_Click(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}