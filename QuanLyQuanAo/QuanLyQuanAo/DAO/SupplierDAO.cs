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

        public List<SupplierInfo> FindSupplier(string name)
        {
            List<SupplierInfo> list = new List<SupplierInfo>();

            string query = string.Format(" SELECT S.IDSupplier, S.Name, B.Name AS [Branch], S.Phone, S.Email, S.Address FROM Supplier S INNER JOIN Branch B ON S.IDBranch = B.IDBranch WHERE S.Name like N'%{0}%' or B.Name like N'%{1}%'", name, name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                SupplierInfo supplier = new SupplierInfo(item);
                list.Add(supplier);
            }

            return list;
        }
       
        public bool InsertSupplier(string name, string nameBranch, string phone, string email, string address)
        {
            string query = string.Format("EXEC USP_InsertSupplier @Name = N'{0}', @NameBranch = N'{1}'," +
                                    "@Phone = N'{2}', @Email = N'{3}', @Address = N'{4}'",
                                            name, nameBranch, phone, email, address);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateSupplier(int id, string name, string nameBranch, 
                                    string phone, string email, string address)
        {
            string query = string.Format("EXEC USP_UpdateSupplier @IDSupplier = {0}, @Name = N'{1}', @NameBranch = N'{2}'," +
                                   "@Phone = N'{3}', @Email = N'{4}', @Address = N'{5}'",
                                           id, name, nameBranch, phone, email, address);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteSupplier(int id)
        {
            string query = string.Format("EXEC USP_DeleteSupplier @IDSupplier = {0}", id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public int GetNewIDSupplier()
        {
            string query = "SELECT MAX(IDSupplier) FROM Supplier";

            int newID = (int)DataProvider.Instance.ExecuteScalar(query);

            return newID;
        }
    }
}
