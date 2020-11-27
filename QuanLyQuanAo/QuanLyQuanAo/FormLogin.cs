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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có thực sự muốn thoát? ","Thông báo",MessageBoxButtons.OKCancel)!=System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            int getStatus = Login(username, password);
            
            switch(getStatus)
            {
                case 1:
                    FormController form = new FormController();
                    this.Hide();
                    form.ShowDialog();
                    this.Show();
                    break;
                case 0:
                    BillInfo formBill = new BillInfo();
                    this.Hide();
                    formBill.ShowDialog();
                    this.Show();
                    break;
                default:
                    MessageBox.Show("Sai tên tài khoản hoặc mật khẩu, vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK);
                    break;
            }
        }

        int Login(string Username, string Password)
        {
            return StaffDAO.Instance.Login(Username, Password);
        }
    }
}
