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

        public bool InsertBillExport(int idClient, List<BillProduct> products)
        {
            int result = 0;

            result += DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertBillExport @IDClient", new object[] { idClient });

            int idbill = (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(IDBillExport) FROM BillExport");

            foreach (BillProduct item in products)
            {
                string query = string.Format("EXEC USP_InsertBillExportInfo @IDBillExport = {0}, @IDProduct = {1}, @Amount = {2}",
                                                idbill, item.IdProduct, item.Amount);

                result += DataProvider.Instance.ExecuteNonQuery(query);
            }

            return result > 0;
        }
    }
}
