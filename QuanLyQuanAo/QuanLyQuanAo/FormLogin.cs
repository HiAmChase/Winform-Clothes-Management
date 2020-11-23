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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
            //MessageBox.Show("Alo");
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            int getStatus = Testadmin(username, password);
            
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
                    MessageBox.Show("Đéo có pass cũng đòi vào ?", "Thông báo", MessageBoxButtons.OK);
                    break;
            }
        }

        int Testadmin(string Username, string Password)
        {
            return AccountDAO.Instance.Testadmin(Username, Password);
        }

    }
}
