using QuanLyQuanAo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DAO
{
    public class ProductDAO
    {
        private static ProductDAO instance;
        public static ProductDAO Instance { 
            get { if (instance == null) instance = new ProductDAO(); return ProductDAO.instance; }
            private set { ProductDAO.instance = value; }
        }
        private ProductDAO() { }

        public List<ProductInfo> GetProduct()
        {
            List<ProductInfo> listProduct = new List<ProductInfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_GetProduct");

            foreach(DataRow item in data.Rows)
            {
                ProductInfo product = new ProductInfo(item);
                listProduct.Add(product);
            }

            return listProduct;
        }

        public List<ProductInfo> findProduct(string name)
        {
            List<ProductInfo> listProduct = new List<ProductInfo>();

            string query = string.Format("SELECT P.IDProduct,P.Name,T.Name AS [Type],B.Name AS [Branch],C.Color,P.Unit,S.Size, P.Amount,P.PriceOut,P.PriceIn FROM Product P INNER JOIN Type T ON T.IDType = P.IDType INNER JOIN Color C ON C.IDColor = P.IDColor INNER JOIN Size S ON S.IDSize = P.IDSize INNER JOIN Supplier SUP ON SUP.IDSupplier = P.IDSupplier  INNER JOIN Branch B ON B.IDBranch = SUP.IDBranch WHERE B.name like N'%{0}%'or P.name like N'%{1}%' or C.color like N'%{2}%' or T.name like N'%{3}%'", name,name,name, name);
               
                DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ProductInfo product = new ProductInfo(item);
                listProduct.Add(product);
            }

            return listProduct;
        }

        public bool InsertProduct(string name, string type, string branch, string size,
                                    string color, int amount, string unit, double priceIn, double priceOut)
        {
            string query = string.Format("EXEC USP_InsertProduct @Name = N'{0}', @Type = N'{1}'," +
                                    " @Branch = N'{2}', @Size = N'{3}', @Color = N'{4}', " +
                                    " @Amount = {5}, @Unit = N'{6}', @PriceIn = {7}, @PriceOut = {8}",
                                        name, type, branch, size, color, amount, unit, priceIn, priceOut);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateProduct(int id, string name, string type, string branch, string size,
                                    string color, int amount, string unit, double priceIn, double priceOut)
        {
            string query = string.Format("EXEC USP_UpdateProduct @IDProduct = {0},@Name = N'{1}', @Type = N'{2}'," +
                                    " @Branch = N'{3}', @Size = N'{4}', @Color = N'{5}', " +
                                    " @Amount = {6}, @Unit = N'{7}', @PriceIn = {8}, @PriceOut = {9}",
                                        id, name, type, branch, size, color, amount, unit, priceIn ,priceOut);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteProduct(int id)
        {
            string query = string.Format("EXEC USP_DeleteProduct @IDProduct = {0}", id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public List<ProductInfo> GetProductBySupplier(int idSupplier)
        {
            List<ProductInfo> listProduct = new List<ProductInfo>();

            string query = string.Format("EXEC USP_GetProductBySupplier @IDSupplier = {0}", idSupplier);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ProductInfo product = new ProductInfo(item);
                listProduct.Add(product);
            }

            return listProduct;
        }

        public ProductInfo GetProductByIDAndAmount(int idProduct, int amount)
        {
            ProductInfo product = null;

            string query = "EXEC USP_GetProductByIDAndAmount @IDProduct , @Amount";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idProduct, amount });

            foreach (DataRow item in data.Rows)
            {
                product = new ProductInfo(item);
                return product;
            }
            return product;
        }

        public int GetIDProductMax()
        {
            int result = (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(IDProduct) FROM Product");

            return result;
        }
    }
}
