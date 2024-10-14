using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using ProductCRUD.Models;

namespace ProductCRUD.DAL
{
    public class Product_DAL
    {
        //string constring = ConfigurationManager.ConnectionStrings["ProductConnection"].ToString();
        public List<Product>GetProducts()
        {
            List<Product> productlist = new List<Product>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductConnection"].ToString()))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Get_Products";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command); 
                DataTable dtProducts = new DataTable();

                connection.Open();
                sqlDA.Fill(dtProducts);
                connection.Close();

                foreach (DataRow dr in dtProducts.Rows)
                {
                    productlist.Add(new Product
                    {
                        ProductID = Convert.ToInt32(dr["ProductID"]),
                        ProductName = dr["ProductName"].ToString(),
                        Category = dr["Category"].ToString(),
                    });
                }
            }
            return productlist;
        }
    }
}