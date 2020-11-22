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
            string Username = textBoxUsername.Text;
            string Password = textBoxPassword.Text;
            if(Login(Username,Password))
            {

                if(Testadmin(Username,Password))
                {
                    FormController f = new FormController();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }    
                else
                {
                    BillInfo f = new BillInfo();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }    
                                    
            }
            else
            {
                MessageBox.Show("sai tên đăng nhập hoặc mật khẩu !");
            }    

        }

        bool Login(string Username, string Password)
        {
            return AccountDAO.Instance.Login(Username, Password);
        }

        bool Testadmin(string Username, string Password)
        {
            return AccountDAO.Instance.Testadmin(Username, Password);
        }
    }
}
