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
        int addFlag = 0;
        int editFlag = 0;
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
            LoadSizeIntoComboBox();
            LoadBranchesIntoComboBox();
            LoadColorIntoComboBox();
            LoadTypeIntoComboBox();
            DisableTextBoxAndComboBox();
            TurnOffFlag();
        }

        private void LoadProduct()
        {
            dataViewProduct.DataSource = listProduct;
            listProduct.DataSource = ProductDAO.Instance.GetProduct();

        }

        private void AddProductBinding()
        {
            textBoxID.DataBindings.Add("Text", dataViewProduct.DataSource, "IDProduct");
            textBoxProduct.DataBindings.Add("Text", dataViewProduct.DataSource, "Name");
            numUpDownAmount.DataBindings.Add("Text", dataViewProduct.DataSource, "Amount");
            textBoxPriceIn.DataBindings.Add("Text", dataViewProduct.DataSource, "PriceIn");
            textBoxPriceOut.DataBindings.Add("Text", dataViewProduct.DataSource, "PriceOut");
            textBoxUnit.DataBindings.Add("Text", dataViewProduct.DataSource, "Unit");
        }

        private void LoadSizeIntoComboBox()
        {
            comboBoxSize.DataSource = SizeDAO.Instance.GetSize();
            comboBoxSize.DisplayMember = "SizeInfo";
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

        private void DisableTextBoxAndComboBox()
        {
            textBoxProduct.Enabled = false;
            numUpDownAmount.Enabled = false;
            textBoxPriceIn.Enabled = false;
            textBoxPriceOut.Enabled = false;
            textBoxUnit.Enabled = false;
            comboBoxBranch.Enabled = false;
            comboBoxColor.Enabled = false;
            comboBoxType.Enabled = false;
            comboBoxSize.Enabled = false;
        
            saveButton.Enabled = false;
            cancelButton.Enabled = false;

            labelNotify.Text = "";
        }

        private void TurnOffFlag()
        {
            addFlag = 0;
            editFlag = 0;
        }



        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            try { int idProduct = (int)dataViewProduct.SelectedCells[0].OwningRow.Cells["IDProduct"].Value;


                AutoUpdateComboBoxSize(idProduct);
                AutoUpdateComboBoxBranch(idProduct);
                AutoUpdateComboBoxColor(idProduct);
                AutoUpdateComboBoxType(idProduct);
            }
            catch 
            { };

        }

        private void AutoUpdateComboBoxSize(int idProduct)
        {
            DTO.Size size = SizeDAO.Instance.GetSizeByIDProduct(idProduct);

            int index = -1;
            int i = 0;

            foreach (DTO.Size item in comboBoxSize.Items)
            {
                if (item.IdSize == size.IdSize)
                {
                    index = i;
                    break;
                }
                i++;
            }
            comboBoxSize.SelectedIndex = index;
        }

        private void AutoUpdateComboBoxBranch(int idProduct)
        {
            string query = "USP_GetBranchByProductID";
            string variable = "@IDProduct";
            Branch branch = BranchDAO.Instance.GetBranchByID(idProduct, query, variable);

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
            addFlag = 1;
            labelNotify.Text = "Điền thông tin";

            saveButton.Enabled = true;
            cancelButton.Enabled = true;

            ClearDataBinding();
            EnableTextBoxAndComboBox();
            ReleaseInput();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            editFlag = 1;
            labelNotify.Text = "Sửa thông tin";

            saveButton.Enabled = true;
            cancelButton.Enabled = true;

            ClearDataBinding();
            EnableTextBoxAndComboBox();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa thông tin này ?", "Cảnh báo", 
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                ClearDataBinding();
                DeleteProduct();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (addFlag == 1)
                InsertProduct();
            if (editFlag == 1)
                UpdateProduct();
        }

        private void ClearDataBinding()
        {
            textBoxID.DataBindings.Clear();
            textBoxProduct.DataBindings.Clear();
            numUpDownAmount.DataBindings.Clear();
            textBoxPriceIn.DataBindings.Clear();
            textBoxPriceOut.DataBindings.Clear();
            textBoxUnit.DataBindings.Clear();
        }

        private void EnableTextBoxAndComboBox()
        {
            textBoxProduct.Enabled = true;
            numUpDownAmount.Enabled = true;
            textBoxPriceIn.Enabled = true;
            textBoxPriceOut.Enabled = true;
            textBoxUnit.Enabled = true;

            comboBoxColor.Enabled = true;
            comboBoxType.Enabled = true;
            comboBoxSize.Enabled = true;
        }

        private void ReleaseInput()
        {
            textBoxID.Text = "";
            textBoxProduct.Text = "";
            numUpDownAmount.Text = "";
            textBoxPriceIn.Text = "";
            textBoxPriceOut.Text = "";
            textBoxUnit.Text = "";
            comboBoxBranch.SelectedIndex = 0;
            comboBoxColor.SelectedIndex = 0;
            comboBoxType.SelectedIndex = 0;
            comboBoxSize.SelectedIndex = 0;
        }

        private void InsertProduct()
        {
            string name = textBoxProduct.Text;
            string branch = comboBoxBranch.Text;
            string size = comboBoxSize.Text;
            string type = comboBoxType.Text;
            string color = comboBoxColor.Text;
            string unit = textBoxUnit.Text;
            int amount = Convert.ToInt32(numUpDownAmount.Value);
            double priceIn = Convert.ToDouble(textBoxPriceIn.Text);
            double priceOut = Convert.ToDouble(textBoxPriceOut.Text);

            if (ProductDAO.Instance.InsertProduct(name, type, branch, size, color, amount, unit, priceIn, priceOut))
            {
                MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void UpdateProduct()
        {
            int id = Convert.ToInt32(textBoxID.Text);
            string name = textBoxProduct.Text;
            string branch = comboBoxBranch.Text;
            string size = comboBoxSize.Text;
            string type = comboBoxType.Text;
            string color = comboBoxColor.Text;
            string unit = textBoxUnit.Text;
            int amount = Convert.ToInt32(numUpDownAmount.Value);
            double priceIn = Convert.ToDouble(textBoxPriceIn.Text);
            double priceOut = Convert.ToDouble(textBoxPriceOut.Text);

            if (ProductDAO.Instance.UpdateProduct(id, name, type, branch, size, color, amount, unit, priceIn, priceOut))
            {
                MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 

        }

        private void DeleteProduct()
        {
            int idProduct = Convert.ToInt32(textBoxID.Text);

            if (ProductDAO.Instance.DeleteProduct(idProduct))
            {
                MessageBox.Show("Xoá thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        List<ProductInfo> findProduct(string name)
        {
            

            List<ProductInfo> listProduct = ProductDAO.Instance.findProduct(name);

            return listProduct;
        }
        private void findButton_Click(object sender, EventArgs e)
        {
            listProduct.DataSource= findProduct(textBoxFindPro.Text);
        }

        private void exitfindButton_Click(object sender, EventArgs e)
        {
            LoadProduct();
        }
    }
}
