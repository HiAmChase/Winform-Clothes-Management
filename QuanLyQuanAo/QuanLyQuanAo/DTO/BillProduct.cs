using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DTO
{
    public class BillProduct
    {
        private int idProduct;
        private string name;
        private double price;
        private int amount;
        private int maxAmount;
        private double totalPrice;

        public BillProduct(int idProduct, string name, double price, int amount, int maxAmount, double totalPrice)
        {
            this.IdProduct = idProduct;
            this.Name = name;
            this.Price = price;
            this.Amount = amount;
            this.MaxAmount = maxAmount;
            this.TotalPrice = totalPrice;
        }

        public BillProduct(DataRow row)
        {
            this.IdProduct = Convert.ToInt32(row["IDProduct"]);
            this.Name = row["Name"].ToString();
            this.Price = Convert.ToInt32(row["Price"]);
            this.Amount = Convert.ToInt32(row["Amount"]);
            this.MaxAmount = Convert.ToInt32(row["MaxAmount"]);
            this.TotalPrice = Convert.ToDouble(row["TotalPrice"]);
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
        public double Price 
        { 
            get => price; 
            set => price = value; 
        }
        public int Amount 
        { 
            get => amount; 
            set => amount = value; 
        }
        public double TotalPrice 
        { 
            get => totalPrice; 
            set => totalPrice = value; 
        }
        public int MaxAmount { 
            get => maxAmount; 
            private set => maxAmount = value;
        }
    }
}
