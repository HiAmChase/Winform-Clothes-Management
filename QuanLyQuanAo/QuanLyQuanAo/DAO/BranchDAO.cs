using QuanLyQuanAo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DAO
{
    public class BranchDAO
    {
        private static BranchDAO instance;

        public static BranchDAO Instance 
        {
            get { if (instance == null) instance = new BranchDAO(); return BranchDAO.instance; }
            private set => instance = value; 
        }

        private BranchDAO() { }

        public List<Branch> GetBranch()
        {
            List<Branch> listBranches = new List<Branch>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Branch");

            foreach(DataRow item in data.Rows)
            {
                Branch branch = new Branch(item);
                listBranches.Add(branch);
            }

            return listBranches;
        }

        public Branch GetBranchByID(int id, string storeProcName, string variable)
        {
            Branch branch = null;

            string query = "EXEC " + storeProcName + " " + variable;

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[]{id});

            foreach(DataRow item in data.Rows)
            {
                branch = new Branch(item);
                return branch;
            }

            return branch;
        }

    }
}
