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

        public BillProductOut GetBillProductOut(int idProduct, int amount)
        {
            BillProductOut bill = null;

            string query = "EXEC USP_GetBillProductOut @IDProduct , @Amount";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idProduct, amount });

            bill = new BillProductOut(data.Rows[0]);

            return bill;
        }

        public bool InsertBillExport(int idClient, List<BillProductOut> products)
        {
            int result = 0;

            result += DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertBillExport @IDClient", new object[] { idClient });

            int idbill = (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(IDBillExport) FROM BillExport");

            foreach (BillProductOut item in products)
            {
                string query = string.Format("EXEC USP_InsertBillExportInfo @IDBillExport = {0}, @IDProduct = {1}, @Amount = {2}",
                                                idbill, item.IdProduct, item.Amount);

                result += DataProvider.Instance.ExecuteNonQuery(query);
            }

            return result > 0;
        }

        public bool InsertBillImport(int idSupplier, List<ProductInfo> products)
        {
            int result = 0;

            result += DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertBillImport @IDSupplier", new object[] { idSupplier });

            int idBill = (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(IDBillImport) FROM BillImport");

            foreach(ProductInfo item in products)
            {
                if (item.IdProduct != -1)
                {
                    string query = string.Format("EXEC USP_InsertBillImportInfo @IDBillImport = {0}, @IDProduct = {1}, @Amount = {2}",
                                                idBill, item.IdProduct, item.Amount);

                    result += DataProvider.Instance.ExecuteNonQuery(query);
                }
                else
                {
                    int amount = item.Amount;
                    if (ProductDAO.Instance.InsertProduct(item.Name, item.Type, item.Branch, item.Size, item.Color,
                                                                    0, item.Unit, item.PriceIn, item.PriceOut))
                    {
                        int idProduct = ProductDAO.Instance.GetIDProductMax();
                        string query = string.Format("EXEC USP_InsertBillImportInfo @IDBillImport = {0}, @IDProduct = {1}, @Amount = {2}",
                                                idBill, idProduct, amount);
                        result += DataProvider.Instance.ExecuteNonQuery(query);
                    }
                }
            }
            return result > 0;
        }
    }
}
