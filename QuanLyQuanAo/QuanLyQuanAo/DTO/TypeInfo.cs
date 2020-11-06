using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DTO
{
    public class TypeInfo
    {
        private int idType;
        private string name;

        public TypeInfo(int idType, string name)
        {
            this.IdType = idType;
            this.Name = name;
        }

        public TypeInfo(DataRow row)
        {
            this.IdType = (int)row["IDType"];
            this.Name = row["Name"].ToString();
        }

        public int IdType 
        { 
            get => idType;
            set => idType = value; 
        }
        public string Name 
        { 
            get => name; 
            set => name = value; 
        }
    }
}
