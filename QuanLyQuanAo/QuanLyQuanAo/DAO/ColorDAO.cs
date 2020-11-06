using QuanLyQuanAo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DAO
{
    public class ColorDAO
    {
        private static ColorDAO instance;
        public static ColorDAO Instance 
        {
            get { if (instance == null) instance = new ColorDAO(); return ColorDAO.instance; } 
            private set => instance = value; 
        }
        
        private ColorDAO() { }

        public List<ColorInfo> GetColor()
        {
            List<ColorInfo> listColor = new List<ColorInfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Color");

            foreach(DataRow item in data.Rows)
            {
                ColorInfo color = new ColorInfo(item);
                listColor.Add(color);
            }

            return listColor;
        }

        public ColorInfo GetColorByIDProduct(int idProduct)
        {
            ColorInfo color = null;

            string query = "EXEC USP_GetColorByProductID @IDProduct";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idProduct });

            foreach (DataRow item in data.Rows)
            {
                color = new ColorInfo(item);
                return color;
            }

            return color;
        }
    }
}
