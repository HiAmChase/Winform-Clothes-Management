using QuanLyQuanAo.DAO;
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
    public partial class BillInfo : Form
    {
        public BillInfo()
        {
            InitializeComponent();
            LoadProduct();
            AddBinding();
        }

        private void LoadProduct()
        {
            dataViewProduct.DataSource = ProductDAO.Instance.GetProduct();
            dataViewProduct.Columns["IDProduct"].Visible = false;
            dataViewProduct.Columns["Branch"].Visible = false;
            dataViewProduct.Columns["Unit"].Visible = false;
        }

        private void AddBinding()
        {
            textBoxProduct.DataBindings.Add("Text", dataViewProduct.DataSource, "Name");
            textBoxType.DataBindings.Add("Text", dataViewProduct.DataSource, "Type");
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int idProduct = (int)dataViewProduct.SelectedCells[0].OwningRow.Cells["IDProduct"].Value;

        }
    }
}
