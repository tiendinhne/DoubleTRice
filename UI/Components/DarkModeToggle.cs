using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using DoubleTRice.UI.BASE;

namespace DoubleTRice.UI.Components
{
    /// <summary>
    /// UserControl cho nút toggle Dark/Light mode với animation
    /// </summary>
    public class DarkModeToggle : UserControl
    {
        #region Fields
        private Guna2ToggleSwitch toggleSwitch;
        private Label lblMode;
        private Timer animationTimer;
        private int animationStep = 0;
        #endregion

        #region Constructor
        public DarkModeToggle()
        {
            InitializeComponent();
            InitializeAnimation();
            UpdateModeDisplay();

            // Subscribe to Mode change event
            Mode.DarkModeChanged += OnModeChanged;
        }
        #endregion

        #region Initialize
        private void InitializeComponent()
        {
            this.Size = new Size(120, 40);
            this.BackColor = Color.Transparent;

            // Toggle Switch
            toggleSwitch = new Guna2ToggleSwitch
            {
                Location = new Point(10, 8),
                Size = new Size(45, 25),
                CheckedState =
                {
                    FillColor = Color.FromArgb(0, 120, 117),
                    BorderColor = Color.FromArgb(0, 120, 117)
                },
                UncheckedState =
                {
                    FillColor = Color.FromArgb(180, 180, 180),
                    BorderColor = Color.FromArgb(180, 180, 180)
                },
                Animated = true,
                Checked = Mode.IsDarkMode
            };
            toggleSwitch.CheckedChanged += ToggleSwitch_CheckedChanged;

            // Label Mode
            lblMode = new Label
            {
                Location = new Point(60, 10),
                Size = new Size(55, 20),
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = Mode.GetForeColor(),
                Text = Mode.IsDarkMode ? "🌙" : "☀️",
                TextAlign = ContentAlignment.MiddleLeft
            };

            this.Controls.Add(toggleSwitch);
            this.Controls.Add(lblMode);
        }

        private void InitializeAnimation()
        {
            animationTimer = new Timer { Interval = 50 };
            animationTimer.Tick += AnimationTimer_Tick;
        }
        #endregion

        #region Event Handlers
        private void ToggleSwitch_CheckedChanged(object sender, EventArgs e)
        {
            Mode.IsDarkMode = toggleSwitch.Checked;
            StartAnimation();
        }

        private void OnModeChanged(bool isDarkMode)
        {
            if (toggleSwitch.Checked != isDarkMode)
            {
                toggleSwitch.Checked = isDarkMode;
            }
            UpdateModeDisplay();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            animationStep++;

            // Simple rotation animation for icon
            if (animationStep >= 10)
            {
                animationTimer.Stop();
                animationStep = 0;
            }

            this.Invalidate();
        }
        #endregion

        #region Private Methods
        private void UpdateModeDisplay()
        {
            lblMode.Text = Mode.IsDarkMode ? "🌙 Dark" : "☀️ Light";
            lblMode.ForeColor = Mode.GetForeColor();
        }

        private void StartAnimation()
        {
            animationStep = 0;
            animationTimer.Start();
        }
        #endregion

        #region Cleanup
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Mode.DarkModeChanged -= OnModeChanged;
                animationTimer?.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}