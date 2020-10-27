using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DAO
{
    public class DataProvider
    {
        private string sqlSource = @"Data Source=DESKTOP-NLC0EVM\SQLEXPRESS;Initial Catalog=QuanLyQuanAo;Integrated Security=True";
        
        public DataTable ExecuteQuery(string query, object[] parameters)
        {
            DataTable data = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(sqlSource))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                string[] listParameters = query.Split(' ');
                if (parameters != null)
                {
                    int i = 0;
                    foreach(string item in listParameters)
                    {
                        if (item.Contains('@'))
                        {
                            sqlCommand.Parameters.Clear();
                            sqlCommand.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(data);

                sqlConnection.Close();
            }
            return data;
        }
    }
}
