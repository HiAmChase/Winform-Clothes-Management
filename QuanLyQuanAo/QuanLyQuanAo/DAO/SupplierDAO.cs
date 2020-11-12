using QuanLyQuanAo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DAO
{
    public class SupplierDAO
    {
        private static SupplierDAO instance;

        public static SupplierDAO Instance
        {
            get { if (instance == null) instance = new SupplierDAO(); return SupplierDAO.instance; } 
            private set => instance = value; 
        }

        private SupplierDAO() { }

        public List<SupplierInfo> GetSupplier()
        {
            List<SupplierInfo> list = new List<SupplierInfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_GetSupplier");

            foreach (DataRow item in data.Rows)
            {
                SupplierInfo supplier = new SupplierInfo(item);
                list.Add(supplier);
            }

            return list;
        }
    }
}
