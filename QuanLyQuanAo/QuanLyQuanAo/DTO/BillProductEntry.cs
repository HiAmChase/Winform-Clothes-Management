using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DTO
{
    public class BillProductEntry : DisplayDetails
    {
        private double priceIn;

        public BillProductEntry(int idProduct, string name, double priceIn, int amount, double totalPrice)
            : base(idProduct, name, amount, totalPrice)
        {
            this.PriceIn = priceIn;
        }

        public BillProductEntry(DataRow row)
            : base (row)
        {
            this.PriceIn = Convert.ToInt32(row["PriceIn"]);
        }

        public double PriceIn { get => priceIn; set => priceIn = value; }
    }
}
