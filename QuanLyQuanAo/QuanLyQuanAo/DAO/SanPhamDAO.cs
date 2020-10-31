using QuanLyQuanAo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DAO
{
    public class SanPhamDAO
    {
        private static SanPhamDAO instance;
        public static SanPhamDAO Instance { 
            get { if (instance == null) instance = new SanPhamDAO(); return SanPhamDAO.instance; }
            private set { SanPhamDAO.instance = value; }
        }
        private SanPhamDAO() { }
        
        public DataTable GetProduct()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_GetProduct");
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
