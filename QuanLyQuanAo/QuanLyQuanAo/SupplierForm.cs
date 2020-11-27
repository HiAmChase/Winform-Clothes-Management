﻿using QuanLyQuanAo.DAO;
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
            textBoxBranch.DataBindings.Add("Text", dataViewSupplier.DataSource, "Branch");
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
            textBoxBranch.DataBindings.Clear();
        }

        private void EnableTextBoxAndComboBox()
        {
            textBoxName.Enabled = true;
            textBoxPhone.Enabled = true;
            textBoxEmail.Enabled = true;
            textBoxAddress.Enabled = true;
        }

        private void DisableTextBoxAndComboBox()
        {
            textBoxName.Enabled = false;
            textBoxPhone.Enabled = false;
            textBoxEmail.Enabled = false;
            textBoxAddress.Enabled = false;
            textBoxBranch.Enabled = false;


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
            textBoxBranch.Text = "";
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
            string branch = textBoxBranch.Text.ToString();

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
            string branch = textBoxBranch.Text.ToString();

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
