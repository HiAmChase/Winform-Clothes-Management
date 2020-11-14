using QuanLyQuanAo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance 
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; } 
            private set => instance = value;
        }

        private BillInfoDAO() { }

        public BillProduct GetBillProduct(int idProduct, int amount)
        {
            BillProduct bill = null;

            string query = "EXEC USP_GetBillProduct @IDProduct , @Amount";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idProduct, amount });

            bill = new BillProduct(data.Rows[0]);

            return bill;
        }

        /*public bool InsertBillProduct(int idProduct, int amount)
        {
            DataProvider.Instance.ExecuteQuery();
        } */
    }
}
