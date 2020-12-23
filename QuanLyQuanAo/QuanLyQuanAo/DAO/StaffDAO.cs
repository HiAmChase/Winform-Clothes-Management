using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanAo.DTO;
using System.Security.Cryptography;

namespace QuanLyQuanAo.DAO
{
    public class StaffDAO
    {
        private static StaffDAO instance;

        public static StaffDAO Instance
        {
            get { if (instance == null) instance = new StaffDAO(); return StaffDAO.instance; }
            private set { instance = value; }
        }

        private StaffDAO() { }

        public DataTable GetStaff()
        {
            return DataProvider.Instance.ExecuteQuery("Select IDAccount, Username, Name,Status,Phone,Email ,Address From dbo.Staff");
        }
        
        
       

        public int Login(string username, string password)
        {
            

            int ERROR = -100;
            int result = ERROR;

            string query = string.Format("EXEC USP_Login @Username = '{0}', @Password = '{1}'", username,password);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
               
                result = (int)DataProvider.Instance.ExecuteScalar(query);
            }

            return result;
        }

        
        public bool InsertStaff(string username, string name, int status, string phone, string email, string address)
        {
            
            string query = string.Format("EXEC USP_InsertStaff @Username = N'{0}', @Name = N'{1}', @Status= '{2}',@Phone = N'{3}', @Email = N'{4}', @Address = N'{5}' ", username, name, status, phone, email, address);
            if (CheckUser(username))
                return false;
            else
            {
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                return result > 0;
            }
            
            
        }

        public bool CheckUser(string username)
        {
            string query = string.Format("EXEC USP_CheckUser @Username=N'{0}'", username);
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }


        public bool UpdateStaff(int id, int status,string phone, string email, string address)
        {
            string query = string.Format("EXEC USP_UpdateStaff @IDAccount = {0},@Status='{1}', @Phone = N'{2}', @Email = N'{3}', @Address = N'{4}'",
                                          id, status,phone, email, address);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteStaff(int id)
        {
            string query = string.Format("EXEC USP_DeleteStaff @IDAccount = {0}", id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdatePassword(string  username, string password, string newpassword )
        {   

            string query = string.Format("EXEC USP_UpdatePassword @Username = N'{0}',@Password=N'{1}',@newPassword=N'{2}'", username, password, newpassword);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }


    }
}