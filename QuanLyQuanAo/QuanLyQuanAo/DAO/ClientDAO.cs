using QuanLyQuanAo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DAO
{
    public class ClientDAO
    {
        private static ClientDAO instance;

        public static ClientDAO Instance 
        {
            get { if (instance == null) instance = new ClientDAO(); return ClientDAO.instance; }
            private set => instance = value; 
        }

        private ClientDAO() { }

        public List<Client> GetClient()
        {
            List<Client> listClient = new List<Client>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Client");

            foreach (DataRow item in data.Rows)
            {
                Client client = new Client(item);
                listClient.Add(client);
            }

            return listClient;
        }

        public bool InsertClient(string name, string phone, string email, string address)
        {
            string query = string.Format("EXEC USP_InsertClient @Name = N'{0}', @Phone = '{1}', @Email = '{2}', @Address = N'{3}'",
                                          name, phone, email, address);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateClient(int id, string name, string phone, string email, string address)
        {
            string query = string.Format("EXEC USP_UpdateClient @IDClient = {0}, @Name = N'{1}', @Phone = '{2}', " +
                                         "@Email = '{3}', @Address = N'{4}'",
                                          id, name, phone, email, address);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteClient(int id)
        {
            string query = string.Format("EXEC USP_DeleteClient @IDClient = {0}", id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public int GetIDClientMax()
        {
            string query = "SELECT MAX(IDClient) FROM Client";

            int result = (int)DataProvider.Instance.ExecuteScalar(query);

            return result;
        }
    }
}
