using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductSupplierDB
/// </summary>
/// 
namespace TravelExperts
{
    [DataObject(true)]
    public static class ProductSupplierDB
    {
        //get products and suppliers of a package. requires package ID
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<ProductSupplier> GetProductSupplierByPackageID(int id)
        {
            List<ProductSupplier> productsSuppliers = new List<ProductSupplier>();

            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement = "SELECT ps.ProductSupplierId, pro.ProdName, s.SupName, bd.BasePrice " +
                "FROM Packages pac, Packages_Products_Suppliers pps, Products_Suppliers ps, " +
                "Products pro, Suppliers s, BookingDetails bd " +
                "WHERE pac.PackageId='" + id + "' " +
                "AND pac.PackageId=pps.PackageId " +
                "AND pps.ProductSupplierId=ps.ProductSupplierId " +
                "AND ps.ProductId=pro.ProductId " +
                "AND ps.SupplierId=s.SupplierId " +
                "AND bd.ProductSupplierId=ps.ProductSupplierId";

            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    ProductSupplier productSupplier = new ProductSupplier();

                    productSupplier.ProductSupplierId = (int)reader["ProductSupplierId"];
                    productSupplier.ProdName = (string)reader["ProdName"];
                    productSupplier.SupName = (string)reader["SupName"];
                    productSupplier.BasePrice = (decimal)reader["BasePrice"];

                    productsSuppliers.Add(productSupplier);

                }
                return productsSuppliers;
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
