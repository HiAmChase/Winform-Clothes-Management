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

        public bool InsertProduct()
        {


            return true;
        }


    }
}
