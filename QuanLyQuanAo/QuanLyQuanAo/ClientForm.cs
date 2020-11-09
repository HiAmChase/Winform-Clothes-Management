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
    public partial class ClientForm : Form
    {
        int addFlag = 0;
        int editFlag = 0;
        BindingSource listClient = new BindingSource();
        public ClientForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            LoadClient();
            AddBinding();
            DisableTextBox();
            TurnOffFlag();
        }

        private void LoadClient()
        {
            dataViewClient.DataSource = listClient;
            listClient.DataSource = ClientDAO.Instance.GetClient();
        }

        private void AddBinding()
        {
            textBoxID.DataBindings.Add("Text", dataViewClient.DataSource, "IDClient");
            textBoxName.DataBindings.Add("Text", dataViewClient.DataSource, "Name");
            textBoxPhone.DataBindings.Add("Text", dataViewClient.DataSource, "Phone");
            textBoxEmail.DataBindings.Add("Text", dataViewClient.DataSource, "Email");
            textBoxAddress.DataBindings.Add("Text", dataViewClient.DataSource, "Address");
        }

        private void DisableTextBox()
        {
            textBoxID.Enabled = false;
            textBoxName.Enabled = false;
            textBoxPhone.Enabled = false;
            textBoxEmail.Enabled = false;
            textBoxAddress.Enabled = false;

            saveButton.Enabled = false;
            cancelButton.Enabled = false;

            labelNotify.Text = "";
        }

        private void TurnOffFlag()
        {
            addFlag = 0;
            editFlag = 0;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addFlag = 1;
            labelNotify.Text = "Điền thông tin";

            saveButton.Enabled = true;
            cancelButton.Enabled = true;

            ClearBinding();
            EnableTextBox();
            ReleaseInput();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            InsertClient();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearBinding()
        {
            textBoxID.DataBindings.Clear();
            textBoxName.DataBindings.Clear();
            textBoxPhone.DataBindings.Clear();
            textBoxEmail.DataBindings.Clear();
            textBoxAddress.DataBindings.Clear();
        }

        private void EnableTextBox()
        {
            textBoxName.Enabled = true;
            textBoxPhone.Enabled = true;
            textBoxEmail.Enabled = true;
            textBoxAddress.Enabled = true;
        }

        private void ReleaseInput()
        {
            textBoxID.Text = "";
            textBoxName.Text = "";
            textBoxPhone.Text = "";
            textBoxEmail.Text = "";
            textBoxAddress.Text = "";
        }

        private void InsertClient()
        {
            string name = textBoxName.Text.ToString();
            string phone = textBoxPhone.Text.ToString();
            string email = textBoxEmail.Text.ToString();
            string address = textBoxAddress.Text.ToString();

            if (ClientDAO.Instance.InsertClient(name, phone, email, address))
            {
                MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
