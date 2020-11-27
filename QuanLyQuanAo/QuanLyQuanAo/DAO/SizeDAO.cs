using QuanLyQuanAo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DAO
{
    public class SizeDAO
    {
        private static SizeDAO instance;

        public static SizeDAO Instance 
        {
            get { if (instance == null) instance = new SizeDAO(); return SizeDAO.instance; } 
            private set => instance = value; 
        }

        private SizeDAO() { }

        public List<Size> GetSize()
        {
            List<Size> listSize = new List<Size>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Size");

            foreach (DataRow item in data.Rows)
            {
                Size size = new Size(item);
                listSize.Add(size);
            }

            return listSize;
        }

        public Size GetSizeByIDProduct(int idProduct)
        {
            Size size = null;

            string query = string.Format("EXEC USP_GetSizeByProductID @IDProduct = {0}", idProduct);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                size = new Size(item);
                return size;
            }

            return size;
        }
    }
}
