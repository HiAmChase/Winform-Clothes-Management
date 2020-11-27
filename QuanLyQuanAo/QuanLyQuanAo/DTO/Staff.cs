using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyQuanAo.DTO
{
    public class Staff
    {
        private int idAccount;
        private string name;
        private string address;
        private string phone;
        private string email;
        private string username;

        public Staff(int idAccount,string username,string password, int status, string name, string address, string phone, string email)
        {
            this.IdAccount = idAccount;
            this.Username = username;
            this.Password = password;
            this.Status = status;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
        }

        public Staff(DataRow row)
        {
            
            this.IdAccount = (int)row["IDAccount"];
            this.Username = row["Username"].ToString();
            this.Password = row["Password"].ToString();
            this.Status = (int)row["Status"];
            this.Name = row["Name"].ToString();
            this.Address = row["Address"].ToString();
            this.Phone = row["Phone"].ToString();
            this.Email = row["Email"].ToString();
        }

        public int IdAccount
        {
            get => idAccount;
            set => idAccount = value;
        }
        public string Username
        {
            get => username;
            set => username = value;
        }
        public string Password
        { 
            get => Password;
            set => Password = value;
        }

        public int Status
        {
            get => Status;
            set => Status = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Address
        {
            get => address;
            set => address = value;
        }
        public string Phone
        {
            get => phone;
            set => phone = value;
        }
        public string Email
        {
            get => email;
            set => email = value;
        }
    }
}
