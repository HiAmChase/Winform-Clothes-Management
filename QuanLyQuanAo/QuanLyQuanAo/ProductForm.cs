using QuanLyQuanAo.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAo
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
            LoadProduct();
            AddBinding();
        }

        private void LoadProduct()
        {
            dataViewProduct.DataSource = SanPhamDAO.Instance.GetProduct();
        }

        private void AddBinding()
        {
            //textBoxID.DataBindings.Add("Text", dataViewProduct.DataSource, "MaMatHang");
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
