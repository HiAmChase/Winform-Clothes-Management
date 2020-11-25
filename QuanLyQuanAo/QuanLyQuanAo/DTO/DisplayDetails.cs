using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DTO
{
    public abstract class DisplayDetails
    {
        protected int idProduct;
        protected string name;
        protected int amount;
        protected double totalPrice;

        public DisplayDetails(int idProduct, string name, int amount, double totalPrice)
        {
            this.IdProduct = idProduct;
            this.Name = name;
            this.Amount = amount;
            this.TotalPrice = totalPrice;
        }

        public DisplayDetails(DataRow row)
        {
            this.IdProduct = Convert.ToInt32(row["IDProduct"]);
            this.Name = row["Name"].ToString();
            this.Amount = Convert.ToInt32(row["Amount"]);
            this.TotalPrice = Convert.ToDouble(row["TotalPrice"]);
        }

        public int IdProduct 
        { 
            get => idProduct;
            set => idProduct = value;
        }
        public int Amount 
        {
            get => amount;
            set => amount = value; 
        }

        public string Name 
        { 
            get => name;
            set => name = value; 
        }
        public double TotalPrice 
        { 
            get => totalPrice;
            set => totalPrice = value;
        }

    }
}
