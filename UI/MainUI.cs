using DoubleTRice.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoubleTRice.UI
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
            AdjustFormSize();
        }

        private void AdjustFormSize()
        {
            // Lấy kích thước màn hình hiện tại
            var screen = Screen.PrimaryScreen.WorkingArea;
            int width = (int)(screen.Width * 0.85);   // Form chiếm 85% chiều ngang
            int height = (int)(screen.Height * 0.85); // Form chiếm 85% chiều dọc

            // Cập nhật kích thước form
            this.Size = new Size(width, height);
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelBody_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            Application.Exit();
        }

        private void panelStatus_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelNav_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelInf_Paint(object sender, PaintEventArgs e)
        {

        }


        // test productDAO
        private void button1_Click(object sender, EventArgs e)
        {
            var list = ProductDAO.Instance.GetAllProducts();
            MessageBox.Show("Số lượng sản phẩm: " + list.Count.ToString());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
