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
        private int idProduct;
        private string name;
        private string type;
        private string branch;
        private string color;
        private string unit;
        private string size;
        private int amount;
        private double priceOut;
        private double priceIn;

        public ProductInfo(int idProduct, string name, string type, string branch, string color,
                        string unit, string size, int amount, double priceIn ,double priceOut)
        {
            this.IdProduct = idProduct;
            this.Name = name;
            this.Type = type;
            this.Branch = branch;
            this.Color = color;
            this.Unit = unit;
            this.Size = size;
            this.Amount = amount;
            this.PriceIn = priceIn;
            this.PriceOut = priceOut;
        }

        public ProductInfo(DataRow row)
        {
            this.IdProduct = (int)row["IDProduct"];
            this.Name = row["Name"].ToString();
            this.Type = row["Type"].ToString();
            this.Branch = row["Branch"].ToString();
            this.Color = row["Color"].ToString();
            this.Unit = row["Unit"].ToString();
            this.Size = row["Size"].ToString();
            this.Amount = (int)row["Amount"];
            this.PriceIn = Math.Round(Convert.ToDouble(row["PriceIn"]), 1);
            this.PriceOut = Math.Round(Convert.ToDouble(row["PriceOut"]), 1);
        }
        public int IdProduct
        {
            get => idProduct;
            set => idProduct = value;
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
        public string Size
        { 
            get => size;
            set => size = value;
        }
        public int Amount 
        { 
            get => amount; 
            set => amount = value; 
        }
        public double PriceIn 
        { 
            get => priceIn; 
            set => priceIn = value; 
        }

        public double PriceOut 
        { 
            get => priceOut; 
            set => priceOut = value; 
        }

        public static implicit operator List<object>(ProductInfo v)
        {
            throw new NotImplementedException();
        }
    }
}
