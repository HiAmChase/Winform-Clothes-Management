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
    public partial class TrashForm : Form
    {
        public TrashForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Convert chuyển từ string sang int
            //try
            //{
            //    int value = Convert.ToInt32(textBox1.Text);
            //    MessageBox.Show(value.ToString());
            //}
            //catch (System.FormatException )
            //{
            //    MessageBox.Show("Xảy ra lỗi");
            //}


            //Except email
            try
            {
                int value = Convert.ToInt32(textBox1.Text);
            }
            catch (FormatException error)
            {
                MessageBox.Show(error.Message);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }

    }
}
