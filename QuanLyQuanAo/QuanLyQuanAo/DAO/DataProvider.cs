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
        private static DataProvider instance;

        private string sqlSource = @"Data Source=DESKTOP-NLC0EVM\SQLEXPRESS;Initial Catalog=QuanLyQuanAo;Integrated Security=True";
        //private string sqlSource = @"Data Source=DESKTOP-RA9UVLD\SQLEXPRESS;Initial Catalog=QuanLyQuanAo;Integrated Security=True";

        public static DataProvider Instance 
        { 
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }
      

        public DataTable ExecuteQuery(string query, object[] parameters = null)
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

        public int ExecuteNonQuery(string query, object[] parameters = null)
        {
            int data = 0;

            using (SqlConnection sqlConnection = new SqlConnection(sqlSource))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                string[] listParameters = query.Split(' ');
                if (parameters != null)
                {
                    int i = 0;
                    foreach (string item in listParameters)
                    {
                        if (item.Contains('@'))
                        {
                            sqlCommand.Parameters.Clear();
                            sqlCommand.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                data = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
            return data;
        }

        public object ExecuteScalar(string query, object[] parameters = null)
        {
            object data = 0;

            using (SqlConnection sqlConnection = new SqlConnection(sqlSource))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                string[] listParameters = query.Split(' ');
                if (parameters != null)
                {
                    int i = 0;
                    foreach (string item in listParameters)
                    {
                        if (item.Contains('@'))
                        {
                            sqlCommand.Parameters.Clear();
                            sqlCommand.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                data = sqlCommand.ExecuteScalar();

                sqlConnection.Close();
            }
            return data;
        }
    }
}
