using DoubleTRice.UI.BASE;

namespace DoubleTRice.UI.ChildForms
{
    partial class BaseChildForm
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
                // Unsubscribe event trước khi dispose
                Mode.DarkModeChanged -= OnModeChanged; // Backup nếu OnFormClosing không chạy

                if (components != null)
                {
                    components.Dispose();
                }
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
            this.SuspendLayout();
            // 
            // BaseChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 626);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BaseChildForm";
            this.Text = "BaseChildForm";
            this.ResumeLayout(false);
        }
        #endregion

    }
}