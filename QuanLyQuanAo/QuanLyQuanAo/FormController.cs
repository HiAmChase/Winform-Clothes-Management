using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAo
{
    public partial class FormController : Form
    {
        public FormController()
        {
            InitializeComponent();
        }

        private void FormController_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*if (MessageBox.Show("Chọn OK để thoát", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;    
            } */
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            this.Hide();
            productForm.ShowDialog();
            this.Show();
        }

        private void buttonClient_Click(object sender, EventArgs e)
        {
            ClientForm clientForm = new ClientForm();
            this.Hide();
            clientForm.ShowDialog();
            this.Show();
        }
    }
}
