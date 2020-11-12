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
        BindingSource listSupplier = new BindingSource();
        public SupplierForm()
        {
            InitializeComponent();
            LoadSupplier();
            AddBinding();
            AddBranchIntoComboBox();
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
            int idSupplier = Convert.ToInt32(textBoxID.Text);
            AutoUpdateComboBoxBranch(idSupplier);
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

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
