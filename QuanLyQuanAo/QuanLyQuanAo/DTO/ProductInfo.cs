using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DTO
{
    public class ProductInfo
    {
        private string name;
        private string type;
        private string branch;
        private string color;
        private string unit;
        private int size;
        private int amount;
        private double price;

        public ProductInfo(string name, string type, string branch, string color,
                        string unit, int size, int amount, double price)
        {
            this.Name = name;
            this.Type = type;
            this.Branch = branch;
            this.Color = color;
            this.Unit = unit;
            this.Size = size;
            this.Amount = amount;
            this.Price = price;
        }

        public ProductInfo(DataRow row)
        {
            this.Name = row["Tên"].ToString();
            this.Type = row["Loại"].ToString();
            this.Branch = row["Thương Hiệu"].ToString();
            this.Color = row["Màu Sắc"].ToString();
            this.Unit = row["Đơn Vị Tính"].ToString();
            this.Size = (int)row["Kích Thước"];
            this.Amount = (int)row["Số Lượng"];
            this.Price = Math.Round(Convert.ToDouble(row["Đơn Giá"]), 1);
        } 

        public string Name 
        {   
            get => name; 
            set => name = value; 
        }
        public string Type
        { 
            get => type; 
            set => type = value; 
        }
        public string Branch 
        { 
            get => branch; 
            set => branch = value; 
        }
        public string Color 
        { 
            get => color; 
            set => color = value; 
        }
        public string Unit 
        { 
            get => unit; 
            set => unit = value; 
        }
        public int Size 
        { 
            get => size; 
            set => size = value;
        }
        public int Amount 
        { 
            get => amount; 
            set => amount = value; 
        }
        public double Price 
        { 
            get => price;
            set => price = value; 
        }
    }
}
