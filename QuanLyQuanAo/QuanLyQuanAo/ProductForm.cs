﻿using QuanLyQuanAo.DAO;
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
        BindingSource listProduct = new BindingSource();
        public ProductForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
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

        private void AddProductBinding()
        {
            textBoxID.DataBindings.Add("Text", dataViewProduct.DataSource, "IDProduct");
            textBoxProduct.DataBindings.Add("Text", dataViewProduct.DataSource, "Name");
            numUpDownSize.DataBindings.Add("Text", dataViewProduct.DataSource, "Size");
            numUpDownAmount.DataBindings.Add("Text", dataViewProduct.DataSource, "Amount");
            textBoxPrice.DataBindings.Add("Text", dataViewProduct.DataSource, "Price");
            textBoxUnit.DataBindings.Add("Text", dataViewProduct.DataSource, "Unit");
        }

        private void LoadProduct()
        {
            dataViewProduct.DataSource = listProduct;
            listProduct.DataSource = ProductDAO.Instance.GetProduct();
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

        private void addButton_Click(object sender, EventArgs e)
        {
            labelNotify.Text = "Điền thông tin: ";
            saveButton.Enabled = true;

            ClearDataBinding();
            EnableTextBoxAndComboBox();
            ReleaseInput();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            InsertProduct();
        }

        private void ClearDataBinding()
        {
            textBoxID.DataBindings.Clear();
            textBoxProduct.DataBindings.Clear();
            numUpDownSize.DataBindings.Clear();
            numUpDownAmount.DataBindings.Clear();
            textBoxPrice.DataBindings.Clear();
            textBoxUnit.DataBindings.Clear();
        }

        private void EnableTextBoxAndComboBox()
        {
            //textBoxID.Enabled = true;
            textBoxProduct.Enabled = true;
            numUpDownSize.Enabled = true;
            numUpDownAmount.Enabled = true;
            textBoxPrice.Enabled = true;
            textBoxUnit.Enabled = true;
            comboBoxBranch.Enabled = true;
            comboBoxColor.Enabled = true;
            comboBoxType.Enabled = true;
        }

        private void ReleaseInput()
        {
            textBoxID.Text = "";
            textBoxProduct.Text = "";
            numUpDownSize.Text = "";
            numUpDownAmount.Text = "";
            textBoxPrice.Text = "";
            textBoxUnit.Text = "";
            comboBoxBranch.SelectedIndex = 0;
            comboBoxColor.SelectedIndex = 0;
            comboBoxType.SelectedIndex = 0;
        }

        private void InsertProduct()
        {
            string name = textBoxProduct.Text;
            string branch = comboBoxBranch.Text;
            int size = Convert.ToInt32(numUpDownSize.Value);
            string type = comboBoxType.Text;
            string color = comboBoxColor.Text;
            string unit = textBoxUnit.Text;
            int amount = Convert.ToInt32(numUpDownAmount.Value);
            double price = Convert.ToDouble(textBoxPrice.Text);


        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
