﻿using QuanLyQuanAo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAo.DAO
{
    public class ProductDAO
    {
        private static ProductDAO instance;
        public static ProductDAO Instance { 
            get { if (instance == null) instance = new ProductDAO(); return ProductDAO.instance; }
            private set { ProductDAO.instance = value; }
        }
        private ProductDAO() { }

        public List<ProductInfo> GetProduct()
        {
            List<ProductInfo> listProduct = new List<ProductInfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_GetProduct");

            foreach(DataRow item in data.Rows)
            {
                ProductInfo product = new ProductInfo(item);
                listProduct.Add(product);
            }

            return listProduct;
        }

        public bool InsertProduct(string name, string type, string branch, int size,
                                    string color, int amount, string unit, double price)
        {
            string query = string.Format("EXEC USP_InsertProduct @Name = N'{0}', @Type = N'{1}'," +
                                    " @Branch = N'{2}', @Size = {3}, @Color = N'{4}', " +
                                    " @Amount = {5}, @Unit = N'{6}', @Price = {7}",
                                        name, type, branch, size, color, amount, unit, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateProduct(int id, string name, string type, string branch, int size,
                                    string color, int amount, string unit, double price)
        {
            string query = string.Format("EXEC USP_UpdateProduct @IDProduct = {0},@Name = N'{1}', @Type = N'{2}'," +
                                    " @Branch = N'{3}', @Size = {4}, @Color = N'{5}', " +
                                    " @Amount = {6}, @Unit = N'{7}', @Price = {8}",
                                        id, name, type, branch, size, color, amount, unit, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteProduct(int id)
        {
            string query = string.Format("EXEC USP_DeleteProduct @IDProduct = {0}", id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public List<ProductInfo> GetProductBySupplierName(int idSupplier)
        {
            List<ProductInfo> listProduct = new List<ProductInfo>();

            string query = string.Format("EXEC USP_GetProductBySupplier @IDSupplier = {0}", idSupplier);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ProductInfo product = new ProductInfo(item);
                listProduct.Add(product);
            }

            return listProduct;
        }
    }
}
