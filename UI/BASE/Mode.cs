using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DoubleTRice.UI.BASE
{
    /// <summary>
    /// Quản lý chế độ Dark/Light Mode cho toàn ứng dụng
    /// </summary>
    public static class Mode
    {
        #region Events
        /// <summary>
        /// Event được trigger khi chế độ Dark Mode thay đổi
        /// </summary>
        public static event Action<bool> DarkModeChanged;
        #endregion

        #region Fields
        private static bool _isDarkMode = true; // Mặc định là Dark Mode

        // Màu sắc theo yêu cầu
        private static readonly Color DarkBackground = Color.FromArgb(0, 70, 67);     // #004643
        private static readonly Color LightBackground = Color.FromArgb(240, 237, 229); // #f0ede5

        // Màu cho Sidebar
        private static readonly Color DarkSidebar = Color.FromArgb(0, 70, 67);        // #004643
        private static readonly Color LightSidebar = Color.FromArgb(240, 237, 229);   // #f0ede5

        // Màu cho Navbar
        private static readonly Color DarkNavbar = Color.FromArgb(0, 70, 67);         // #004643
        private static readonly Color LightNavbar = Color.FromArgb(240, 237, 229);    // #f0ede5

        // Màu chữ
        private static readonly Color DarkText = Color.FromArgb(240, 237, 229);       // #f0ede5
        private static readonly Color LightText = Color.FromArgb(0, 70, 67);          // #004643

        // Màu cho Body
        private static readonly Color DarkBody = Color.FromArgb(18, 18, 18);
        private static readonly Color LightBody = Color.FromArgb(255, 255, 255);

        // Màu button hover
        private static readonly Color DarkButtonHover = Color.FromArgb(0, 100, 97);
        private static readonly Color LightButtonHover = Color.FromArgb(220, 217, 209);

        // Màu button checked
        private static readonly Color DarkButtonChecked = Color.FromArgb(0, 120, 117);
        private static readonly Color LightButtonChecked = Color.FromArgb(200, 197, 189);
        #endregion

        #region Properties
        /// <summary>
        /// Trạng thái Dark Mode hiện tại
        /// </summary>
        public static bool IsDarkMode
        {
            get => _isDarkMode;
            set
            {
                if (_isDarkMode != value)
                {
                    _isDarkMode = value;
                    DarkModeChanged?.Invoke(value);
                }
            }
        }
        #endregion

        #region Public Methods - Get Colors
        /// <summary>
        /// Lấy màu nền chính
        /// </summary>
        public static Color GetBackgroundColor() => IsDarkMode ? DarkBackground : LightBackground;

        /// <summary>
        /// Lấy màu chữ chính
        /// </summary>
        public static Color GetForeColor() => IsDarkMode ? DarkText : LightText;

        /// <summary>
        /// Lấy màu cho Sidebar
        /// </summary>
        public static Color GetSidebarColor() => IsDarkMode ? DarkSidebar : LightSidebar;

        /// <summary>
        /// Lấy màu cho Navbar
        /// </summary>
        public static Color GetNavbarColor() => IsDarkMode ? DarkNavbar : LightNavbar;

        /// <summary>
        /// Lấy màu cho Body
        /// </summary>
        public static Color GetBodyColor() => IsDarkMode ? DarkBody : LightBody;

        /// <summary>
        /// Lấy màu hover cho button
        /// </summary>
        public static Color GetButtonHoverColor() => IsDarkMode ? DarkButtonHover : LightButtonHover;

        /// <summary>
        /// Lấy màu checked cho button
        /// </summary>
        public static Color GetButtonCheckedColor() => IsDarkMode ? DarkButtonChecked : LightButtonChecked;

        /// <summary>
        /// Lấy màu separator
        /// </summary>
        public static Color GetSeparatorColor() => IsDarkMode ? Color.FromArgb(100, 120, 120) : Color.FromArgb(180, 180, 180);
        #endregion

        #region Public Methods - Apply Mode
        /// <summary>
        /// Áp dụng Dark/Light Mode cho toàn bộ Form
        /// </summary>
        public static void ApplyModeToForm(Form form)
        {
            if (form == null) return;

            form.BackColor = GetBodyColor();
            ApplyModeToControls(form.Controls);
        }

        /// <summary>
        /// Áp dụng mode cho MainUI (custom implementation)
        /// </summary>
        public static void ApplyModeToMainUI(
            Guna2Panel pnlSidebar,
            Guna2Panel pnlNavbar,
            Guna2Panel pnlBody,
            Guna2Panel pnlBrand,
            Guna2Panel pnlMenu,
            Guna2Button[] menuButtons,
            Label[] separators,
            Guna2TextBox txtSearch,
            Guna2Button[] navbarButtons,
            Label[] statusLabels,
            Panel accountPanel = null,
            Label[] accountLabels = null)
        {
            // Apply Sidebar
            if (pnlSidebar != null)
            {
                pnlSidebar.FillColor = GetSidebarColor();
                pnlSidebar.BackColor = GetSidebarColor();
            }

            // Apply Brand Panel (giữ nguyên màu trắng hoặc theo thiết kế)
            if (pnlBrand != null)
            {
                pnlBrand.FillColor = IsDarkMode ? Color.White : Color.FromArgb(230, 230, 230);
                pnlBrand.BackColor = IsDarkMode ? Color.White : Color.FromArgb(230, 230, 230);
            }

            // Apply Menu Panel
            if (pnlMenu != null)
            {
                pnlMenu.FillColor = GetSidebarColor();
                pnlMenu.BackColor = GetSidebarColor();
            }

            // Apply Menu Buttons
            if (menuButtons != null)
            {
                foreach (var btn in menuButtons)
                {
                    if (btn != null)
                    {
                        btn.FillColor = Color.Transparent;
                        btn.ForeColor = GetForeColor();
                        btn.HoverState.FillColor = GetButtonHoverColor();
                        btn.CheckedState.FillColor = GetButtonCheckedColor();
                    }
                }
            }

            // Apply Separators
            if (separators != null)
            {
                foreach (var sep in separators)
                {
                    if (sep != null)
                    {
                        sep.BackColor = GetButtonCheckedColor();
                        sep.ForeColor = GetSeparatorColor();
                    }
                }
            }

            // Apply Navbar
            if (pnlNavbar != null)
            {
                pnlNavbar.FillColor = GetNavbarColor();
                pnlNavbar.BackColor = GetNavbarColor();
            }

            // Apply Search Box
            if (txtSearch != null)
            {
                txtSearch.FillColor = IsDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
                txtSearch.ForeColor = GetForeColor();
                txtSearch.PlaceholderForeColor = GetSeparatorColor();
                txtSearch.BorderColor = GetButtonCheckedColor();
            }

            // Apply Navbar Buttons
            if (navbarButtons != null)
            {
                foreach (var btn in navbarButtons)
                {
                    if (btn != null)
                    {
                        btn.FillColor = Color.Transparent;
                        btn.ForeColor = GetForeColor();
                        btn.HoverState.FillColor = GetButtonHoverColor();
                    }
                }
            }

            // Apply Status Labels
            if (statusLabels != null)
            {
                foreach (var lbl in statusLabels)
                {
                    if (lbl != null)
                    {
                        lbl.ForeColor = GetForeColor();
                    }
                }
            }

            // Apply Account Panel
            if (accountPanel != null)
            {
                accountPanel.BackColor = GetSidebarColor();
            }

            // Apply Account Labels
            if (accountLabels != null)
            {
                foreach (var lbl in accountLabels)
                {
                    if (lbl != null)
                    {
                        lbl.ForeColor = GetForeColor();
                    }
                }
            }

            // Apply Body
            if (pnlBody != null)
            {
                pnlBody.FillColor = GetBodyColor();
                pnlBody.BackColor = GetBodyColor();
            }
        }

        /// <summary>
        /// Toggle giữa Dark và Light mode
        /// </summary>
        public static void ToggleMode()
        {
            IsDarkMode = !IsDarkMode;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Áp dụng mode cho tất cả controls
        /// </summary>
        private static void ApplyModeToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // Guna2Button
                if (control is Guna2Button btn)
                {
                    btn.ForeColor = GetForeColor();
                    btn.HoverState.FillColor = GetButtonHoverColor();
                    btn.CheckedState.FillColor = GetButtonCheckedColor();
                }
                // Guna2Panel
                else if (control is Guna2Panel panel)
                {
                    panel.BackColor = GetBackgroundColor();
                    ApplyModeToControls(panel.Controls);
                }
                // Label
                else if (control is Label label)
                {
                    label.ForeColor = GetForeColor();
                }
                // TextBox
                else if (control is Guna2TextBox textBox)
                {
                    textBox.FillColor = IsDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
                    textBox.ForeColor = GetForeColor();
                }
                // Panel thường
                else if (control is Panel regularPanel)
                {
                    regularPanel.BackColor = GetBackgroundColor();
                    ApplyModeToControls(regularPanel.Controls);
                }

                // Recursive cho các container khác
                if (control.HasChildren)
                {
                    ApplyModeToControls(control.Controls);
                }
            }
        }
        #endregion
    }
}