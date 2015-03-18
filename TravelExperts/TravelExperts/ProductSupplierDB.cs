/*
 * Travel Experts Project #2 - C#, ASP.NET, SQL Server
 * Database Class for Products_Suppliers table
 * Created By: John Nguyen (Team 3)
 * Created On: December 10, 2004
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
    public class ProductSupplierDB
    {
        // Get ProductSupplierID, Product Name, and Supplier Name table information from the database
        public static DataTable GetProducts()
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement =
                "SELECT ProductSupplierId AS ID,ProdName AS Product,SupName AS Supplier " +
                "FROM Products p,Suppliers s,Products_Suppliers ps " +
                "WHERE p.ProductId = ps.ProductId AND s.SupplierId = ps.SupplierId " +
                "ORDER BY Product,Supplier";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable itemTable = new DataTable();  // Store the information in a Data Table
            try
            {
                connection.Open();
                adapter.Fill(itemTable);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return itemTable;
        }

        // Find ProductSupplierIds, Product Names, or Supplier Names that contain the search string
        public static DataTable SearchProductSupplier(string searchString)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement =
                "Select ProductSupplierId AS ID,ProdName AS Product,SupName AS Supplier " +
                "FROM Products p,Suppliers s,Products_Suppliers ps " +
                "WHERE (p.ProductId = ps.ProductId AND s.SupplierId = ps.SupplierId) AND " +
                "(ProdName LIKE '%" + searchString.Trim() + "%' " +
                "OR SupName LIKE '%" + searchString.Trim() + "%'" +
                "OR ProductSupplierId LIKE '" + searchString.Trim() + "%')";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable searchTable = new DataTable();    // Return the search string in a data table
            try
            {
                connection.Open();
                adapter.Fill(searchTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchTable;
        }

        // Check if the submitted product + supplier combination already exists in the database
        public static bool CheckProductSupplierExists(string prodName, string supName)
        {
            bool doesExist;
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string insertStatement =
                "SELECT @prodName,@supName " +
                "FROM Products_Suppliers ps " +
                "INNER JOIN Products p ON p.ProductId = ps.ProductId AND p.ProdName = @prodName " +
                "INNER JOIN Suppliers s ON s.SupplierId = ps.SupplierId AND s.SupName = @supName";
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@prodName", prodName);
            insertCommand.Parameters.AddWithValue("@supName", supName);
            try
            {
                connection.Open();
                object checkExist = insertCommand.ExecuteScalar();
                if (checkExist == null)
                {
                    doesExist = false;
                }
                else
                {
                    doesExist = true;
                }
                return doesExist;
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

        // Add a new product + supplier combination information to the database
        public static void AddProduct(string prodName, string supName)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string insertStatement =
                "INSERT INTO Products_Suppliers (ProductId, SupplierId) " +
                "SELECT ProductId, SupplierId " +
                "FROM Products, Suppliers " +
                "WHERE ProdName = @prodName AND SupName = @supName";
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@prodName", prodName);
            insertCommand.Parameters.AddWithValue("@supName", supName);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error # " + ex.Number + ": "
                    + ex.Message, ex.GetType().ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        // Delete a ProductSupplierId from the database
        public static void DeleteProductSupplier(string selProd, string selSup)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            
            // Delete the ProductSupplierID from the Packages_Products_Suppliers table first
            // and then delete it from the Products_Suppliers
            string deleteStatement =
                "DELETE FROM Packages_Products_Suppliers " +
                "WHERE ProductSupplierId IN " +
                "(SELECT pps.ProductSupplierId FROM Packages_Products_Suppliers pps, Products_Suppliers ps,Products p,Suppliers s " +
                "WHERE pps.ProductSupplierId = ps.ProductSupplierId " +
                "AND ps.ProductId = p.ProductId AND p.ProdName = @selProd " +
                "AND ps.SupplierId = s.SupplierId AND s.SupName = @selSup); " +

                "DELETE FROM Products_Suppliers " +
                "WHERE ProductSupplierId IN " +
                "(SELECT ProductSupplierId FROM Products_Suppliers ps " +
                "INNER JOIN Products p ON ps.ProductId = p.ProductId AND p.ProdName = @selProd " +
                "INNER JOIN Suppliers s ON ps.SupplierId = s.SupplierId AND s.SupName = @selSup)";
            SqlCommand insertCommand = new SqlCommand(deleteStatement, connection);
            insertCommand.Parameters.AddWithValue("@selProd", selProd);
            insertCommand.Parameters.AddWithValue("@selSup", selSup);
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

    }
}
