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
        
        public DataTable GetProduct()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM Product");
        }

        /* Chưa sửa
        public List<SanPham> GetProductTest()
        {
            List<SanPham> listProduct = new List<SanPham>();

            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_GetProduct");

            foreach(DataRow item in data.Rows)
            {
                SanPham product = new SanPham(item);
                listProduct.Add(product);
            }

            return listProduct;
        }
        */
    }
}
