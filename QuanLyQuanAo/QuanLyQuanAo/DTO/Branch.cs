using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DTO
{
    public class Branch
    {
        private int idBranch;
        private string name;

        public Branch(int idBranch, string name)
        {
            this.IdBranch = idBranch;
            this.Name = name;
        }

        public Branch(DataRow row)
        {
            this.IdBranch = (int)row["IDBranch"];
            this.Name = row["Name"].ToString();
        }

        public int IdBranch 
        { 
            get => idBranch; 
            set => idBranch = value; 
        }
        public string Name 
        { 
            get => name; 
            set => name = value; 
        }
    }
}
