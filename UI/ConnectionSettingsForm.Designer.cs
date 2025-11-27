using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace DoubleTRice.UI
{
    public partial class ConnectionSettingsForm : Form
    {
        private TextBox txtServerName;
        private ComboBox cboAuthentication;
        private TextBox txtUserName;
        private TextBox txtPassword;
        private CheckBox chkRememberPassword;
        private ComboBox cboDatabaseName;
        private ComboBox cboEncrypt;
        private ComboBox cboTrustCertificate;
        private Button btnConnect;
        private Button btnCancel;
        private Button btnAdvanced;
        private Label lblStatus;

        public ConnectionSettingsForm()
        {
            InitializeControls();
            LoadSavedSettings();
        }

        private void InitializeControls()
        {
            this.Text = "Database Connection Settings";
            this.Size = new System.Drawing.Size(650, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Server Name
            Label lblServer = new Label { Text = "Server Name:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            txtServerName = new TextBox { Location = new System.Drawing.Point(200, 17), Width = 400 };

            // Authentication
            Label lblAuth = new Label { Text = "Authentication:", Location = new System.Drawing.Point(20, 55), AutoSize = true };
            cboAuthentication = new ComboBox
            {
                Location = new System.Drawing.Point(200, 52),
                Width = 400,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboAuthentication.Items.AddRange(new object[] { "Windows Authentication", "SQL Server Authentication" });
            cboAuthentication.SelectedIndex = 0;
            cboAuthentication.SelectedIndexChanged += CboAuthentication_SelectedIndexChanged;

            // User Name
            Label lblUser = new Label { Text = "User Name:", Location = new System.Drawing.Point(20, 90), AutoSize = true };
            txtUserName = new TextBox { Location = new System.Drawing.Point(200, 87), Width = 400, Enabled = false };

            // Password
            Label lblPassword = new Label { Text = "Password:", Location = new System.Drawing.Point(20, 125), AutoSize = true };
            txtPassword = new TextBox
            {
                Location = new System.Drawing.Point(200, 122),
                Width = 400,
                UseSystemPasswordChar = true,
                Enabled = false
            };

            // Remember Password
            chkRememberPassword = new CheckBox
            {
                Text = "Remember Password",
                Location = new System.Drawing.Point(200, 155),
                AutoSize = true,
                Enabled = false
            };

            // Database Name
            Label lblDatabase = new Label { Text = "Database Name:", Location = new System.Drawing.Point(20, 190), AutoSize = true };
            cboDatabaseName = new ComboBox
            {
                Location = new System.Drawing.Point(200, 187),
                Width = 400,
                DropDownStyle = ComboBoxStyle.DropDown
            };
            cboDatabaseName.DropDown += CboDatabaseName_DropDown;

            // Encrypt
            Label lblEncrypt = new Label { Text = "Encrypt:", Location = new System.Drawing.Point(20, 225), AutoSize = true };
            cboEncrypt = new ComboBox
            {
                Location = new System.Drawing.Point(200, 222),
                Width = 400,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboEncrypt.Items.AddRange(new object[] { "Mandatory (True)", "Optional (False)", "Strict" });
            cboEncrypt.SelectedIndex = 0;

            // Trust Server Certificate
            Label lblTrust = new Label { Text = "Trust Server Certificate:", Location = new System.Drawing.Point(20, 260), AutoSize = true };
            cboTrustCertificate = new ComboBox
            {
                Location = new System.Drawing.Point(200, 257),
                Width = 400,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboTrustCertificate.Items.AddRange(new object[] { "False", "True" });
            cboTrustCertificate.SelectedIndex = 0;

            // Advanced Button
            btnAdvanced = new Button
            {
                Text = "Advanced...",
                Location = new System.Drawing.Point(500, 295),
                Width = 100
            };
            btnAdvanced.Click += BtnAdvanced_Click;

            // Status Label
            lblStatus = new Label
            {
                Location = new System.Drawing.Point(20, 340),
                Width = 580,
                Height = 40,
                ForeColor = System.Drawing.Color.Red,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };

            // Connect Button
            btnConnect = new Button
            {
                Text = "Connect",
                Location = new System.Drawing.Point(390, 390),
                Width = 100,
                Height = 30
            };
            btnConnect.Click += BtnConnect_Click;

            // Cancel Button
            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new System.Drawing.Point(500, 390),
                Width = 100,
                Height = 30,
                DialogResult = DialogResult.Cancel
            };

            // Add controls to form
            this.Controls.AddRange(new Control[]
            {
                lblServer, txtServerName,
                lblAuth, cboAuthentication,
                lblUser, txtUserName,
                lblPassword, txtPassword,
                chkRememberPassword,
                lblDatabase, cboDatabaseName,
                lblEncrypt, cboEncrypt,
                lblTrust, cboTrustCertificate,
                btnAdvanced,
                lblStatus,
                btnConnect, btnCancel
            });

            this.CancelButton = btnCancel;
        }

        private void CboAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isSqlAuth = cboAuthentication.SelectedIndex == 1;
            txtUserName.Enabled = isSqlAuth;
            txtPassword.Enabled = isSqlAuth;
            chkRememberPassword.Enabled = isSqlAuth;

            if (!isSqlAuth)
            {
                txtUserName.Clear();
                txtPassword.Clear();
                chkRememberPassword.Checked = false;
            }
        }

        private void CboDatabaseName_DropDown(object sender, EventArgs e)
        {
            cboDatabaseName.Items.Clear();
            try
            {
                string connString = BuildConnectionString(true);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT name FROM sys.databases ORDER BY name", conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cboDatabaseName.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading databases: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServerName.Text))
            {
                MessageBox.Show("Please enter a server name.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtServerName.Focus();
                return;
            }

            if (cboAuthentication.SelectedIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(txtUserName.Text))
                {
                    MessageBox.Show("Please enter a user name.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserName.Focus();
                    return;
                }
            }

            try
            {
                lblStatus.Text = "Connecting...";
                lblStatus.ForeColor = System.Drawing.Color.Blue;
                Application.DoEvents();

                string connString = BuildConnectionString(false);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    lblStatus.Text = "Connection successful!";
                    lblStatus.ForeColor = System.Drawing.Color.Green;

                    SaveSettings();

                    MessageBox.Show("Connected successfully to SQL Server!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Connection failed: {ex.Message}";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show($"Connection failed:\n\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string BuildConnectionString(bool forDatabaseList)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = txtServerName.Text.Trim();

            if (forDatabaseList)
            {
                builder.InitialCatalog = "master";
            }
            else if (!string.IsNullOrWhiteSpace(cboDatabaseName.Text))
            {
                builder.InitialCatalog = cboDatabaseName.Text.Trim();
            }

            if (cboAuthentication.SelectedIndex == 0) // Windows Auth
            {
                builder.IntegratedSecurity = true;
            }
            else // SQL Server Auth
            {
                builder.IntegratedSecurity = false;
                builder.UserID = txtUserName.Text.Trim();
                builder.Password = txtPassword.Text;
            }

            // Encrypt setting
            builder.Encrypt = cboEncrypt.SelectedIndex == 0 || cboEncrypt.SelectedIndex == 2;

            // Trust Server Certificate
            builder.TrustServerCertificate = cboTrustCertificate.SelectedIndex == 1;

            builder.ConnectTimeout = 30;

            return builder.ConnectionString;
        }

        private void BtnAdvanced_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Advanced settings dialog would open here.\n\nAdditional options like:\n• Connection timeout\n• Application name\n• Packet size\n• etc.",
                "Advanced Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveSettings()
        {
            try
            {
                var settings = new
                {
                    ServerName = txtServerName.Text,
                    AuthenticationType = cboAuthentication.SelectedIndex,
                    UserName = cboAuthentication.SelectedIndex == 1 ? txtUserName.Text : "",
                    Password = (cboAuthentication.SelectedIndex == 1 && chkRememberPassword.Checked)
                        ? EncryptPassword(txtPassword.Text) : "",
                    DatabaseName = cboDatabaseName.Text,
                    Encrypt = cboEncrypt.SelectedIndex,
                    TrustCertificate = cboTrustCertificate.SelectedIndex
                };

                string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
                string path = Path.Combine(Application.StartupPath, "connection_settings.json");
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                // Silent fail - settings just won't be saved
                System.Diagnostics.Debug.WriteLine($"Error saving settings: {ex.Message}");
            }
        }

        private void LoadSavedSettings()
        {
            try
            {
                string path = Path.Combine(Application.StartupPath, "connection_settings.json");
                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    dynamic settings = JsonConvert.DeserializeObject(json);

                    txtServerName.Text = settings.ServerName;
                    cboAuthentication.SelectedIndex = settings.AuthenticationType;
                    txtUserName.Text = settings.UserName;

                    if (!string.IsNullOrEmpty((string)settings.Password))
                    {
                        txtPassword.Text = DecryptPassword(settings.Password.ToString());
                        chkRememberPassword.Checked = true;
                    }

                    cboDatabaseName.Text = settings.DatabaseName;
                    cboEncrypt.SelectedIndex = settings.Encrypt;
                    cboTrustCertificate.SelectedIndex = settings.TrustCertificate;
                }
            }
            catch
            {
                // Silent fail - just use defaults
            }
        }

        private string EncryptPassword(string password)
        {
            // Simple encryption - for production use AES or DPAPI
            byte[] data = System.Text.Encoding.UTF8.GetBytes(password);
            using (Aes aes = Aes.Create())
            {
                aes.Key = GetEncryptionKey();
                aes.GenerateIV();

                using (var encryptor = aes.CreateEncryptor())
                {
                    byte[] encrypted = encryptor.TransformFinalBlock(data, 0, data.Length);
                    byte[] combined = new byte[aes.IV.Length + encrypted.Length];
                    Array.Copy(aes.IV, 0, combined, 0, aes.IV.Length);
                    Array.Copy(encrypted, 0, combined, aes.IV.Length, encrypted.Length);
                    return Convert.ToBase64String(combined);
                }
            }
        }

        private string DecryptPassword(string encryptedPassword)
        {
            try
            {
                byte[] combined = Convert.FromBase64String(encryptedPassword);
                using (Aes aes = Aes.Create())
                {
                    aes.Key = GetEncryptionKey();

                    byte[] iv = new byte[16];
                    byte[] encrypted = new byte[combined.Length - 16];
                    Array.Copy(combined, 0, iv, 0, 16);
                    Array.Copy(combined, 16, encrypted, 0, encrypted.Length);

                    aes.IV = iv;

                    using (var decryptor = aes.CreateDecryptor())
                    {
                        byte[] decrypted = decryptor.TransformFinalBlock(encrypted, 0, encrypted.Length);
                        return System.Text.Encoding.UTF8.GetString(decrypted);
                    }
                }
            }
            catch
            {
                return "";
            }
        }

        private byte[] GetEncryptionKey()
        {
            // Generate key from machine/user info - in production use better key management
            string keySource = Environment.MachineName + Environment.UserName;
            using (SHA256 sha = SHA256.Create())
            {
                return sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(keySource));
            }
        }

        public string GetConnectionString()
        {
            return BuildConnectionString(false);
        }
    }

    // Usage example in Program.cs:
    /*
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            using (ConnectionSettingsForm form = new ConnectionSettingsForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string connectionString = form.GetConnectionString();
                    // Use the connection string for your application
                    Application.Run(new MainForm(connectionString));
                }
            }
        }
    }
    */
}