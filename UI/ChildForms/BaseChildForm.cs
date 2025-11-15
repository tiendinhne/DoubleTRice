using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using DoubleTRice.UI.BASE;

namespace DoubleTRice.UI.ChildForms
{
    /// <summary>
    /// Base class cho tất cả Child Forms
    /// Tự động apply Dark/Light mode và có các methods cơ bản
    /// </summary>
    public partial class BaseChildForm : Form
    {
        #region Constructor
        public BaseChildForm()
        {
            InitializeComponent();
            InitializeMode();
        }
        #endregion

        #region Initialization
        private void InitializeMode()
        {
            // Subscribe to mode change
            Mode.DarkModeChanged += OnModeChanged;

            // Apply mode hiện tại
            ApplyMode();
        }

        private void ApplyMode()
        {
            this.BackColor = Mode.GetBodyColor();
            this.ForeColor = Mode.GetForeColor();

            // Apply cho tất cả controls
            ApplyModeToControls(this.Controls);
        }

        private void OnModeChanged(bool isDarkMode)
        {
            ApplyMode();
        }

        private void ApplyModeToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Guna2Panel panel)
                {
                    panel.FillColor = Mode.GetBodyColor();
                    panel.BackColor = Mode.GetBodyColor();
                }
                else if (control is Guna2Button button)
                {
                    button.ForeColor = Mode.GetForeColor();
                }
                else if (control is Label label)
                {
                    label.ForeColor = Mode.GetForeColor();
                }
                else if (control is Guna2TextBox textBox)
                {
                    textBox.FillColor = Mode.IsDarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
                    textBox.ForeColor = Mode.GetForeColor();
                }
                else if (control is Guna2DataGridView dgv)
                {
                    dgv.BackgroundColor = Mode.GetBodyColor();
                    dgv.DefaultCellStyle.BackColor = Mode.GetBodyColor();
                    dgv.DefaultCellStyle.ForeColor = Mode.GetForeColor();
                }

                // Recursive
                if (control.HasChildren)
                {
                    ApplyModeToControls(control.Controls);
                }
            }
        }
        #endregion

        #region Form Events
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Unsubscribe khi form đóng
            Mode.DarkModeChanged -= OnModeChanged; // Unsubscribe sớm
            base.OnFormClosing(e);
        }
        #endregion

    }
}