using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DTO
{
    public class BillProductOut : DisplayDetails
    {
        private double priceOut;
        private int maxAmount;

        public BillProductOut(int idProduct, string name, double priceOut, int amount, int maxAmount)
            : base(idProduct, name, amount)
        {
            this.PriceOut = priceOut;
            this.MaxAmount = maxAmount;
            this.TotalPrice = priceOut * amount;
        }

        public BillProductOut(DataRow row)
            : base(row)
        {
            this.PriceOut = Convert.ToInt32(row["PriceOut"]);
            this.MaxAmount = Convert.ToInt32(row["MaxAmount"]);
        }

        public double PriceOut 
        { 
            get => priceOut;
            set => priceOut = value;
        }

        public int MaxAmount { 
            get => maxAmount; 
            private set => maxAmount = value;
        }

    }
}
