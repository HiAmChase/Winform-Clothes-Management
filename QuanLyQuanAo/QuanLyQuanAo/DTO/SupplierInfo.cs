using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DTO
{
    public class SupplierInfo
    {
        private int idSupplier;
        private string name;
        private string branch;
        private string phone;
        private string email;
        private string address;

        public SupplierInfo(int idSupplier, string name, string branch,
                            string phone, string email, string address)
        {
            this.IdSupplier = idSupplier;
            this.Name = name;
            this.Branch = branch;
            this.Phone = phone;
            this.Email = email;
            this.Address = address;
        }

        public SupplierInfo(DataRow row)
        {
            this.IdSupplier = (int)row["IDSupplier"];
            this.Name = row["Name"].ToString();
            this.Branch = row["Branch"].ToString();
            this.Phone = row["Phone"].ToString();
            this.Email = row["Email"].ToString();
            this.Address = row["Address"].ToString();
        }

        public int IdSupplier 
        { 
            get => idSupplier; 
            set => idSupplier = value;
        }
        public string Name 
        { 
            get => name; 
            set => name = value; 
        }
        public string Branch
        { 
            get => branch;
            set => branch = value;
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
        public string Address
        { 
            get => address; 
            set => address = value;
        }
    }
}
