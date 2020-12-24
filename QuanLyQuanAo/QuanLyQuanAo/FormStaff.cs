using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanAo.DAO;


namespace QuanLyQuanAo
{
    public partial class FormStaff : Form
    {

        BindingSource listStaff = new BindingSource();
        int addFlag = 0;
        int editFlag = 0;
        public FormStaff()
        {
            InitializeComponent();
            LoadData();
        }
            

        private void LoadData()
        {
            LoadStaff();
            AddBinding();
            DisableTextBox();
            TurnOffFlag();
        }
        private void LoadStaff()
        {
            dataViewStaff.DataSource = listStaff;
            listStaff.DataSource = StaffDAO.Instance.GetStaff();
            Process.InvisibleAttributes(dataViewStaff, new object[] { "IDAccount" });
        }
        private void AddBinding()
        {
            textBoxID.DataBindings.Add("Text", dataViewStaff.DataSource, "IDAccount");
            textBoxUsername.DataBindings.Add("Text", dataViewStaff.DataSource, "Username");
            textBoxName.DataBindings.Add("Text", dataViewStaff.DataSource, "Name");
            numericStatus.DataBindings.Add("Value", dataViewStaff.DataSource, "Status");
            textBoxPhone.DataBindings.Add("Text", dataViewStaff.DataSource, "Phone");
            textBoxEmail.DataBindings.Add("Text", dataViewStaff.DataSource, "Email");
            textBoxAddress.DataBindings.Add("Text", dataViewStaff.DataSource, "Address");
        }

        private void DisableTextBox()
        {
            textBoxID.Enabled = false;
            textBoxUsername.Enabled = false;
            textBoxName.Enabled = false;
            numericStatus.Enabled = false;
            textBoxPhone.Enabled = false;
            textBoxEmail.Enabled = false;
            textBoxAddress.Enabled = false;

            saveButton.Enabled = false;
            cancelButton.Enabled = false;
                       
        }

        
        private void TurnOffFlag()
        {
            addFlag = 0;
            editFlag = 0;
        }

        

        

         
        

        
        

        private void ClearBinding()
        {
            textBoxID.DataBindings.Clear();
            textBoxUsername.DataBindings.Clear();
            textBoxName.DataBindings.Clear();
            numericStatus.DataBindings.Clear();
            textBoxPhone.DataBindings.Clear();
            textBoxEmail.DataBindings.Clear();
            textBoxAddress.DataBindings.Clear();
        }

        private void EnableTextBox()
        {
            textBoxUsername.Enabled = true;
            textBoxName.Enabled = true;
            numericStatus.Enabled = true;
            textBoxPhone.Enabled = true;
            textBoxEmail.Enabled = true;
            textBoxAddress.Enabled = true;
        }

        private void ReleaseInput()
        {
            textBoxID.Text = "";
            textBoxUsername.Text = "";
            textBoxName.Text = "";
            numericStatus.Text = "";
            textBoxPhone.Text = "";
            textBoxEmail.Text = "";
            textBoxAddress.Text = "";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addFlag = 1;
            saveButton.Enabled = true;
            cancelButton.Enabled = true;

            ClearBinding();
            EnableTextBox();

            ReleaseInput();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            editFlag = 1;


            saveButton.Enabled = true;
            cancelButton.Enabled = true;

            ClearBinding();
            EnableTextBox();
            textBoxUsername.Enabled = false;
            textBoxName.Enabled = false;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa thông tin này ?", "Cảnh báo",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                ClearBinding();
                DeleteStaff();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (addFlag == 1)
                InsertStaff();
            if (editFlag == 1)
                UpdateStaff();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void InsertStaff()
        {
            try
            {
                string Username = Process.ToInput(textBoxUsername.Text);
                string name = Process.ToInput(textBoxName.Text);
                int status = Convert.ToInt32(numericStatus.Value);
                string phone = Process.ToPhone(textBoxPhone.Text);
                string email = Process.ToEmail(textBoxEmail.Text);
                string address = Process.ToInput(textBoxAddress.Text);

                if (StaffDAO.Instance.InsertStaff(Username, name, status, phone, email, address))
                {
                    MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void UpdateStaff()
        {
            try
            {
                int id = Convert.ToInt32(textBoxID.Text);
                string username = Process.ToInput(textBoxUsername.Text);
                string name = Process.ToInput(textBoxName.Text);
                int status = Convert.ToInt32(numericStatus.Value);
                string phone = Process.ToPhone(textBoxPhone.Text);
                string email = Process.ToEmail(textBoxEmail.Text);
                string address = Process.ToInput(textBoxAddress.Text);

                if (StaffDAO.Instance.UpdateStaff(id, status, phone, email, address))
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

        private void DeleteStaff()
        {
            try
            {
                int idstaff = Convert.ToInt32(textBoxID.Text);

                if (StaffDAO.Instance.DeleteStaff(idstaff))
                {
                    MessageBox.Show("Xóa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }


        private void cancleButton2_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void exitButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
