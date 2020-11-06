using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAo.DTO
{
    public class ColorInfo
    {
        private int idColor;
        private string nameColor;

        public ColorInfo(int idColor, string color)
        {
            this.IdColor = idColor;
            this.NameColor = color;
        }

        public ColorInfo(DataRow row)
        {
            this.IdColor = (int)row["IDColor"];
            this.NameColor = row["Color"].ToString();
        }

        public int IdColor 
        { 
            get => idColor; 
            set => idColor = value; 
        }
        public string NameColor 
        { 
            get => nameColor; 
            set => nameColor = value; 
        }
    }
}
