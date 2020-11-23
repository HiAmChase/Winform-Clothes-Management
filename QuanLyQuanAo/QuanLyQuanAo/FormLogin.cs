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
<<<<<<< HEAD
            //MessageBox.Show("Alo");
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            int getStatus = Testadmin(username, password);
            
            switch(getStatus)
            {
                case 1:
                    FormController form = new FormController();
=======
            string Username = textBoxUsername.Text;
            string Password = textBoxPassword.Text;
            if(Login(Username,Password))
            {

                if(Testadmin(Username,Password))
                {
                    FormController f = new FormController();
>>>>>>> 806519d34c54b7834fbe03cbe508f3d0483c2beb
                    this.Hide();
                    form.ShowDialog();
                    this.Show();
<<<<<<< HEAD
                    break;
                case 0:
                    BillInfo formBill = new BillInfo();
=======
                }    
                else
                {
                    BillInfo f = new BillInfo();
>>>>>>> 806519d34c54b7834fbe03cbe508f3d0483c2beb
                    this.Hide();
                    formBill.ShowDialog();
                    this.Show();
<<<<<<< HEAD
                    break;
                default:
                    MessageBox.Show("Đéo có pass cũng đòi vào ?", "Thông báo", MessageBoxButtons.OK);
                    break;
            }
        }

        int Testadmin(string Username, string Password)
=======
                }    
                                    
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu !");
            }    

        }

        private bool Login(string Username, string Password)
        {
            return AccountDAO.Instance.Login(Username, Password);
        }

        private bool Testadmin(string Username, string Password)
>>>>>>> 806519d34c54b7834fbe03cbe508f3d0483c2beb
        {
            return AccountDAO.Instance.Testadmin(Username, Password);
        }
    }
}
