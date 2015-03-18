/*
 * Travel Experts Project #2 - C#, ASP.NET, SQL Server
 * Database Class for Products
 * Created By: John Nguyen (Team 3)
 * Created On: December 9, 2004
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelExperts
{
    public class ProductDB
    {
        // Change the name of a single product in the database
        public static void UpdateProduct(string oldProd, string newProd)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string modifyStatement =
                "UPDATE Products SET " +
                "ProdName = @NewProductName " +
                "WHERE ProdName = @OldProductName";
            SqlCommand modifyCommand = new SqlCommand(modifyStatement, connection);
            modifyCommand.Parameters.AddWithValue("@NewProductName", newProd);
            modifyCommand.Parameters.AddWithValue("@OldProductName", oldProd);
            try
            {
                connection.Open();
                modifyCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        // Add a single product to the database
        public static void AddProductName(string newProd)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string insertStatement = "INSERT INTO Products (ProdName) VALUES(@newProd)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@newProd", newProd);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        // Get a list of suppliers to be deleted along with the selected product
        public static List<string> GetDeleteList(string delProduct)
        {
            // Create a list of the items being deleted and display in a message box
            List<string> delList = new List<string>();
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement =
                "SELECT DISTINCT SupName " +
                "FROM Products p,Suppliers s,Products_Suppliers ps " +
                "WHERE p.ProductId = ps.ProductId AND s.SupplierId = ps.SupplierId " +
                "AND ProdName = @ProdName " +
                "ORDER BY SupName";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProdName", delProduct);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    delList.Add(reader["SupName"].ToString());
                }
                reader.Close();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return delList;
        }

        // Delete a ProductSupplierId, and a ProductId from the database after confirmation
        public static void DeleteProductName(string delProduct)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string deleteStatement =
                // Delete the Product from the Packages_Products_Suppliers table, then the Products_Suppliers table, then the Products table
                "DELETE FROM Packages_Products_Suppliers " +
                "WHERE ProductSupplierId IN " +
                "(SELECT pps.ProductSupplierId FROM Packages_Products_Suppliers pps, Products_Suppliers ps,Products p " +
                "WHERE pps.ProductSupplierId = ps.ProductSupplierId AND ps.ProductId = p.ProductId AND p.ProdName = @delprod); " +
                
                "DELETE FROM BookingDetails " +
                "WHERE ProductSupplierId IN " +
                "(SELECT DISTINCT bd.ProductSupplierId FROM BookingDetails bd, Products_Suppliers ps,Products p " +
                "WHERE bd.ProductSupplierId = ps.ProductSupplierId AND ps.ProductId = p.ProductId AND p.ProdName = @delProd); " +

                "DELETE FROM Products_Suppliers " +
                "WHERE ProductId IN " +
                "(SELECT ProductId FROM Products WHERE ProdName = @delProd); " +
                
                "DELETE FROM Products " +
                "WHERE ProdName = @delProd";
            SqlCommand insertCommand = new SqlCommand(deleteStatement, connection);
            insertCommand.Parameters.AddWithValue("@delProd", delProduct);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                MessageBox.Show("Sorry, you cannot delete that product.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                connection.Close();
            }
        }

        // Performs search on main page
        public static List<Product> SearchProducts(string charactersToSearch)
        {
            List<Product> productList = new List<Product>();
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement = "SELECT * FROM Products " +
                "WHERE ProductId like '%" + charactersToSearch.Trim() + "%' OR " +
                "ProdName like '%" + charactersToSearch.Trim() + "%'";
            if (charactersToSearch.Trim().Length != 0)
            {
                string msg = "";
                if (Validator.inputIsInteger(charactersToSearch, out msg))
                {
                    selectStatement += " OR ProductId ='" + charactersToSearch + "'";
                }
            }
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Product newProduct = new Product(); //create a Product object
                    newProduct.prodID = Convert.ToInt32(reader["ProductId"]); //add package details
                    newProduct.prodName = reader["ProdName"].ToString();
                    productList.Add(newProduct); //add Product to list
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return productList;
        }
    }
}
