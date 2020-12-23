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
    public partial class FormUpdatePass : Form
    {
        public FormUpdatePass()
        {
            InitializeComponent();
        }

        private void UpdatePassword()
        {
            try
            {
                string username = Variable.ToInput(textBoxUsername.Text);
                string password = Variable.ToInput(textBoxPassword.Text);
                string newpassword = Variable.ToInput(textBoxPassword2.Text);
                if (StaffDAO.Instance.UpdatePassword(username, password, newpassword))
                {
                    MessageBox.Show("Đổi mật khẩu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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

        

        

        private void Savebutton_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đổi mật khẩu này ?", "Cảnh báo",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
                UpdatePassword();
        }

        
    }
}
