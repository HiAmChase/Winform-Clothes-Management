using QuanLyQuanAo.DAO;
using QuanLyQuanAo.DTO;
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
    public partial class SupplierForm : Form
    {
        int addFlag = 0;
        int editFlag = 0;
        BindingSource listSupplier = new BindingSource();
        public SupplierForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            LoadSupplier();
            AddBinding();
            AddBranchIntoComboBox();
            DisableTextBoxAndComboBox();
            TurnOffFlag();
        }

        private void LoadSupplier()
        {
            dataViewSupplier.DataSource = listSupplier;
            listSupplier.DataSource = SupplierDAO.Instance.GetSupplier();
        }

        private void AddBinding()
        {
            textBoxID.DataBindings.Add("Text", dataViewSupplier.DataSource, "IDSupplier");
            textBoxName.DataBindings.Add("Text", dataViewSupplier.DataSource, "Name");
            textBoxPhone.DataBindings.Add("Text", dataViewSupplier.DataSource, "Phone");
            textBoxEmail.DataBindings.Add("Text", dataViewSupplier.DataSource, "Email");
            textBoxAddress.DataBindings.Add("Text", dataViewSupplier.DataSource, "Address");
        }

        private void AddBranchIntoComboBox()
        {
            comboBoxBranch.DataSource = BranchDAO.Instance.GetBranch();
            comboBoxBranch.DisplayMember = "Name";
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            int idSupplier = (int)dataViewSupplier.SelectedCells[0].OwningRow.Cells["IDSupplier"].Value;
            AutoUpdateComboBoxBranch(idSupplier);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addFlag = 1;
            labelNotify.Text = "Điền thông tin";

            saveButton.Enabled = true;
            cancelButton.Enabled = true;

            ClearBinding();
            EnableTextBoxAndComboBox();
            ReleaseInput();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            editFlag = 1;
            labelNotify.Text = "Sửa thông tin";

            saveButton.Enabled = true;
            cancelButton.Enabled = true;

            ClearBinding();
            EnableTextBoxAndComboBox();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (addFlag == 1)
                InsertSupplier();
            if (editFlag == 1)
                UpdateSupplier();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa thông tin này ?", "Cảnh báo",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                ClearBinding();
                DeleteSupplier();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ClearBinding()
        {
            textBoxID.DataBindings.Clear();
            textBoxName.DataBindings.Clear();
            textBoxPhone.DataBindings.Clear();
            textBoxEmail.DataBindings.Clear();
            textBoxAddress.DataBindings.Clear();
        }

        private void EnableTextBoxAndComboBox()
        {
            textBoxName.Enabled = true;
            textBoxPhone.Enabled = true;
            textBoxEmail.Enabled = true;
            textBoxAddress.Enabled = true;
            comboBoxBranch.Enabled = true;
        }

        private void DisableTextBoxAndComboBox()
        {
            textBoxName.Enabled = false;
            textBoxPhone.Enabled = false;
            textBoxEmail.Enabled = false;
            textBoxAddress.Enabled = false;
            comboBoxBranch.Enabled = false;


            labelNotify.Text = "";

            saveButton.Enabled = false;
            cancelButton.Enabled = false;
        }

        private void ReleaseInput()
        {
            textBoxID.Text = "";
            textBoxName.Text = "";
            textBoxPhone.Text = "";
            textBoxEmail.Text = "";
            textBoxAddress.Text = "";
            comboBoxBranch.Text = "";
        }

        private void AutoUpdateComboBoxBranch(int id)
        {
            string query = "USP_GetBranchBySupplierID";
            string variable = "@IDSupplier";
            Branch branch = BranchDAO.Instance.GetBranchByID(id, query, variable);

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

        private void TurnOffFlag()
        {
            addFlag = 0;
            editFlag = 0;
        }

        private void InsertSupplier()
        {
            string name = textBoxName.Text.ToString();
            string address = textBoxAddress.Text.ToString();
            string phone = textBoxPhone.Text.ToString();
            string email = textBoxEmail.Text.ToString();
            string branch = comboBoxBranch.Text.ToString();

            if (SupplierDAO.Instance.InsertSupplier(name, branch, phone, email, address))
            {
                MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSupplier()
        {
            int id = Convert.ToInt32(textBoxID.Text);
            string name = textBoxName.Text.ToString();
            string address = textBoxAddress.Text.ToString();
            string phone = textBoxPhone.Text.ToString();
            string email = textBoxEmail.Text.ToString();
            string branch = comboBoxBranch.Text.ToString();

            if (SupplierDAO.Instance.UpdateSupplier(id, name, branch, phone, email, address))
            {
                MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteSupplier()
        {
            int id = Convert.ToInt32(textBoxID.Text);

            if (SupplierDAO.Instance.DeleteSupplier(id))
            {
                MessageBox.Show("Xoá thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
