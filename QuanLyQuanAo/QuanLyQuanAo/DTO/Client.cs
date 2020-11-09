using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DTO
{
    public class Client
    {
        private int idClient;
        private string name;
        private string address;
        private string phone;
        private string email;

        public Client(int idClient, string name, string address, string phone, string email)
        {
            this.IdClient = idClient;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
        }

        public Client(DataRow row)
        {
            this.IdClient = (int)row["IDClient"];
            this.Name = row["Name"].ToString();
            this.Address = row["Address"].ToString();
            this.Phone = row["Phone"].ToString();
            this.Email = row["Email"].ToString();
        }

        public int IdClient 
        {
            get => idClient; 
            set => idClient = value; 
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
