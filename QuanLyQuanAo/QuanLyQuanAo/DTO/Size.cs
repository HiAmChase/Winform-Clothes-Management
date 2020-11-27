using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DTO
{
    public class Size
    {
        private int idSize;
        private string sizeInfo;

        public Size(int idSize, string sizeInfo)
        {
            this.IdSize = idSize;
            this.SizeInfo = sizeInfo;
        }

        public Size(DataRow row)
        {
            this.IdSize = (int)row["IDSize"];
            this.SizeInfo = row["Size"].ToString();
        }

        public int IdSize 
        { 
            get => idSize; 
            set => idSize = value; 
        }
        public string SizeInfo 
        { 
            get => sizeInfo; 
            set => sizeInfo = value; 
        }
    }
}
