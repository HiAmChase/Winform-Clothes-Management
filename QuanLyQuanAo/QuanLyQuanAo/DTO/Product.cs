using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DTO
{
    public class Product
    {
        private int idProduct;
        private string name;
        private int idType;
        private int idBranch;
        private int idSize;
        private int idColor;
        private int amount;
        private string unit;
        private double price;

        public Product (int idProduct, string name, int idType, int idBranch,
                        int idSize, int idColor, int amount, string unit, double price)
        {
            this.IdProduct = idProduct;
            this.Name = name;
            this.IdType = idType;
            this.IdBranch = idBranch;
            this.IdSize = idSize;
            this.IdColor = idColor;
            this.Amount = amount;
            this.Unit = unit;
            this.Price = price;
        }



        public int IdProduct { get => idProduct; set => idProduct = value; }
        public string Name { get => name; set => name = value; }
        public int IdType { get => idType; set => idType = value; }
        public int IdBranch { get => idBranch; set => idBranch = value; }
        public int IdSize { get => idSize; set => idSize = value; }
        public int IdColor { get => idColor; set => idColor = value; }
        public string Unit { get => unit; set => unit = value; }
        public double Price { get => price; set => price = value; }
        public int Amount { get => amount; set => amount = value; }
    }
}
