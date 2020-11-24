using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace QuanLyQuanAo.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public int Testadmin(string username, string password)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hasdata = new MD5CryptoServiceProvider().ComputeHash(temp);
            string haspass = "";
            foreach(byte item in hasdata)
            {
                haspass += item;

            }
            int ERROR = -100;
            int result = ERROR;

            string query = string.Format("EXEC USP_Testadmin2 @Username = '{0}', @Password = '{1}'", username, haspass);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
                result = (int)DataProvider.Instance.ExecuteScalar(query);
            }

            return result;
        }



    }
}