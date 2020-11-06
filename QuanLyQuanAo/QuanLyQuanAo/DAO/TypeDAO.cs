using QuanLyQuanAo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DAO
{
    public class TypeDAO
    {
        private static TypeDAO instance;

        public static TypeDAO Instance 
        {
            get { if (instance == null) instance = new TypeDAO(); return TypeDAO.instance; } 
            private set => instance = value; 
        }

        private TypeDAO() { }

        public List<TypeInfo> GetTypeInfo()
        {
            List<TypeInfo> listType = new List<TypeInfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Type");

            foreach (DataRow item in data.Rows)
            {
                TypeInfo type = new TypeInfo(item);
                listType.Add(type);
            }

            return listType;
        }

        public TypeInfo GetTypeByIDProduct(int idProduct)
        {
            TypeInfo type = null;

            string query = "EXEC USP_GetTypeByProductID @IDProduct";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idProduct });

            foreach (DataRow item in data.Rows)
            {
                type = new TypeInfo(item);
                return type;
            }

            return type;
        }
    }
}
