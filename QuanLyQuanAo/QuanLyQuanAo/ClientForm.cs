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
            Process.InvisibleAttributes(dataViewClient, new object[] { "IDClient" });
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

        private void editButton_Click(object sender, EventArgs e)
        {
            editFlag = 1;
            labelNotify.Text = "Sửa thông tin";

            saveButton.Enabled = true;
            cancelButton.Enabled = true;

            ClearBinding();
            EnableTextBox();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (addFlag == 1)
                InsertClient();
            if (editFlag == 1)
                UpdateClient();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa thông tin này ?", "Cảnh báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                ClearBinding();
                DeleteClient();
            }
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
            try
            {
                string name = Process.ToInput(textBoxName.Text);
                string phone = Process.ToPhone(textBoxPhone.Text);
                string email = Process.ToEmail(textBoxEmail.Text);
                string address = Process.ToInput(textBoxAddress.Text);

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
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void UpdateClient()
        {
            try
            {
                int id = Convert.ToInt32(textBoxID.Text);
                string name = Process.ToInput(textBoxName.Text);
                string phone = Process.ToPhone(textBoxPhone.Text);
                string email = Process.ToEmail(textBoxEmail.Text);
                string address = Process.ToInput(textBoxAddress.Text);

                if (ClientDAO.Instance.UpdateClient(id, name, phone, email, address))
                {
                    MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException error)
            {
                MessageBox.Show(error.Message);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void DeleteClient()
        {
            try
            {
                int idClient = Convert.ToInt32(textBoxID.Text);

                if (ClientDAO.Instance.DeleteClient(idClient))
                {
                    MessageBox.Show("Xóa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        List<Client> findClient(string name)
        {


            List<Client> listClient = ClientDAO.Instance.FindClient(name);

            return listClient;
        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            LoadClient();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            listClient.DataSource = findClient(textBoxFindClient.Text);
        }
    }
}
