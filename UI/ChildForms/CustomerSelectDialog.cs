using DoubleTRice.DT;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DoubleTRice.UI.ChildForms
{
    public partial class CustomerSelectDialog : Form
    {
        public Customers SelectedCustomer { get; private set; }

        public CustomerSelectDialog(List<Customers> customers)
        {
            InitializeComponent();

            foreach (var c in customers)
            {
                var item = new ListViewItem(new[]
                {
                    c.CustomerID.ToString(),
                    c.TenKhachHang,
                    c.SoDienThoai,
                    c.DiaChi
                });
                item.Tag = c;

                listViewCustomers.Items.Add(item);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ListViewCustomers_DoubleClick(object sender, EventArgs e)
        {
            if (listViewCustomers.SelectedItems.Count > 0)
            {
                SelectedCustomer = (Customers)listViewCustomers.SelectedItems[0].Tag;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
