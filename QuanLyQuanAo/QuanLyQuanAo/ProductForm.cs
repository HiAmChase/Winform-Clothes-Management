using QuanLyQuanAo.DAO;
using QuanLyQuanAo.DTO;
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
            LoadBranchesIntoComboBox();
            LoadColorIntoComboBox();
            LoadTypeIntoComboBox();
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            int idProduct = (int)dataViewProduct.SelectedCells[0].OwningRow.Cells["IDProduct"].Value;

            AutoUpdateComboBoxBranch(idProduct);
            AutoUpdateComboBoxColor(idProduct);
            AutoUpdateComboBoxType(idProduct);
        }

        private void LoadProduct()
        {
            dataViewProduct.DataSource = ProductDAO.Instance.GetProduct();
        }

        private void LoadBranchesIntoComboBox()
        {
            comboBoxBranch.DataSource = BranchDAO.Instance.GetBranch();
            comboBoxBranch.DisplayMember = "Name";
        }

        private void LoadColorIntoComboBox()
        {
            comboBoxColor.DataSource = ColorDAO.Instance.GetColor();
            comboBoxColor.DisplayMember = "NameColor";
        }

        private void LoadTypeIntoComboBox()
        {
            comboBoxType.DataSource = TypeDAO.Instance.GetTypeInfo();
            comboBoxType.DisplayMember = "Name";
        }

        private void AddProductBinding()
        {
            textBoxID.DataBindings.Add("Text", dataViewProduct.DataSource, "IDProduct");
            textBoxProduct.DataBindings.Add("Text", dataViewProduct.DataSource, "Name");
            textBoxSize.DataBindings.Add("Text", dataViewProduct.DataSource, "Size");
            textBoxAmount.DataBindings.Add("Text", dataViewProduct.DataSource, "Amount");
            textBoxPrice.DataBindings.Add("Text", dataViewProduct.DataSource, "Price");
            textBoxUnit.DataBindings.Add("Text", dataViewProduct.DataSource, "Unit");
        }

        private void AutoUpdateComboBoxBranch(int idProduct)
        {
            Branch branch = BranchDAO.Instance.GetBranchByIDProduct(idProduct);

            int index = -1;
            int i = 0;

            foreach (Branch item in comboBoxBranch.Items)
            {
                if (item.IdBranch == branch.IdBranch)
                {
                    index = i;
                    break;
                }
                i++;
            }
            comboBoxBranch.SelectedIndex = index;
        }

        private void AutoUpdateComboBoxColor(int idProduct)
        {
            ColorInfo color = ColorDAO.Instance.GetColorByIDProduct(idProduct);

            int index = -1;
            int i = 0;

            foreach (ColorInfo item in comboBoxColor.Items)
            {
                if (item.IdColor == color.IdColor)
                {
                    index = i;
                    break;
                }
                i++;
            }
            comboBoxColor.SelectedIndex = index;
        }

        private void AutoUpdateComboBoxType(int idProduct)
        {
            TypeInfo type = TypeDAO.Instance.GetTypeByIDProduct(idProduct);

            int index = -1;
            int i = 0;

            foreach (TypeInfo item in comboBoxType.Items)
            {
                if (item.IdType == type.IdType)
                {
                    index = i;
                    break;
                }
                i++;
            }
            comboBoxType.SelectedIndex = index;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
