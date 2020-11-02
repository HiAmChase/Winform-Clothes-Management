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
            AddProductBinding();
        }

        private void LoadProduct()
        {
            dataViewProduct.DataSource = ProductDAO.Instance.GetProduct();
        }

        private void AddProductBinding()
        {
            textBoxProduct.DataBindings.Add("Text", dataViewProduct.DataSource, "Name");
            textBoxBranch.DataBindings.Add("Text", dataViewProduct.DataSource, "Branch");
            textBoxSize.DataBindings.Add("Text", dataViewProduct.DataSource, "Size");
            textBoxType.DataBindings.Add("Text", dataViewProduct.DataSource, "Type");
            textBoxColor.DataBindings.Add("Text", dataViewProduct.DataSource, "Color");
            textBoxUnit.DataBindings.Add("Text", dataViewProduct.DataSource, "Unit");
            textBoxAmount.DataBindings.Add("Text", dataViewProduct.DataSource, "Amount");
            textBoxPrice.DataBindings.Add("Text", dataViewProduct.DataSource, "Price");
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
