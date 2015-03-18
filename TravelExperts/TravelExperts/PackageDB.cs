/* CMPP248 Part 2 Workshop 2
 * Created By: Leisy, and MB
 * January 8, 2015
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
    public static class PackageDB
    {
        //find packages that has the findMe string
        public static List<Package> GetPackages(string findMe, bool showAll)
        {

            List<Package> listOfPackages = new List<Package>();

            //create connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            //create sql command
            //string selectStatement = "SELECT * FROM Packages "+
            //    "WHERE PkgName like '%" + findMe.Trim() + "%' OR " +
            //    "PkgDesc like '%" + findMe.Trim() + "%'";

            string forPackageID = "";
            
            //search for something
            if (findMe.Trim().Length != 0)
            {
                string msg = "";
                if (Validator.inputIsInteger(findMe, out msg))
                {
                    forPackageID = " OR PackageId ='" + findMe + "' ";
                }
            }
            string selectStatement = "select PackageId, pkgName, pkgStartDate, pkgEndDate, pkgDesc, pkgBasePrice, PkgAgencyCommission, " +
                "stuff((select ', '+ [prodName] " +
                "from Products, Products_Suppliers, Packages_Products_Suppliers " +
                "where Products.ProductId=Products_Suppliers.ProductId and " +
                "Products_Suppliers.ProductSupplierId=Packages_Products_Suppliers.ProductSupplierId and " +
                "Packages_Products_Suppliers.PackageId=t.PackageId for XML path('')),1,1,'') as Products " +
                "from (select distinct * from Packages " +
                "WHERE PkgName like '%" + findMe.Trim() + "%' OR " +
                "PkgDesc like '%" + findMe.Trim() + "%'" +
                forPackageID + ")t";
            if (!showAll)
            {
                selectStatement = "SELECT * FROM (" + selectStatement + ")as x " +
                    "WHERE PkgEndDate > GETDATE()";
            }
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

            //open connection
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //create reader
            try
            {
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    //create a package
                    Package newPackage = new Package();
                    //add package details
                    newPackage.ID = (int)reader["PackageId"];
                    newPackage.Name = reader["PkgName"].ToString();
                    newPackage.Start_Date = Convert.ToDateTime(reader["PkgStartDate"]).Date;
                    newPackage.End_Date = Convert.ToDateTime(reader["PkgEndDate"]).Date;
                    newPackage.Description = reader["PkgDesc"].ToString();
                    newPackage.Base_Price = (decimal)reader["PkgBasePrice"];
                    newPackage.Agency_Commission = (decimal)reader["PkgAgencyCommission"];
                    newPackage.Products = reader["Products"].ToString();

                    //add book to list
                    listOfPackages.Add(newPackage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //close connection
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listOfPackages;
        }
        //get products
        public static List<Product> GetProducts(string findMe)
        {

            List<Product> listOfProducts = new List<Product>();

            //create connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            //create sql command
            string selectStatement = "SELECT * FROM Products " +
                "WHERE ProdName like '%" + findMe.Trim() + "%'";

            //search for something
            if (findMe.Trim().Length != 0)
            {
                selectStatement += " OR ProductID='" + findMe + "'";

            }
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

            //open connection
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //create reader
            try
            {
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    //create a product
                    Product newProduct = new Product();
                    //add product details
                    newProduct.prodID = (int)reader["ProductID"];
                    newProduct.prodName = reader["ProdName"].ToString();


                    //add product to list
                    listOfProducts.Add(newProduct);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //close connection
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listOfProducts;
        }
        //get suppliers of a product
        public static List<Supplier> GetSuppliers(string findMe)
        {

            List<Supplier> listOfSuppliers = new List<Supplier>();

            //create connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            //search for something
            string selectStatement;
            if (findMe.Trim().Length != 0)
            {
                selectStatement = "SELECT * FROM Suppliers " +
                    "WHERE SupplierId in " +
                        "(SELECT SupplierId FROM Products_Suppliers " +
                        "WHERE ProductId=" + findMe + ")";
            }
            else
            {
                return null;
            }
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

            //open connection
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //create reader
            try
            {
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    //create a supplier
                    Supplier newSupplier = new Supplier();
                    //add supplier details
                    newSupplier.SupplierId = (int)reader["SupplierId"];
                    newSupplier.SupName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(reader["SupName"].ToString().ToLower());


                    //add supplier to list
                    listOfSuppliers.Add(newSupplier);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //close connection
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listOfSuppliers;
        }
        public static string[] GetProductSupplier(int prodID, int supID)
        {
            string[] record = new string[3];

            //create connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            //search for something
            //string selectStatement = "SELECT * FROM Products_Suppliers "+
            //    "WHERE ProductId="+prodID.ToString()+" AND "+
            //        "SupplierId="+supID.ToString();
            string selectStatement = "Select ProductSupplierId, ProdName, SupName " +
                "FROM " +
                    "(SELECT * FROM Products_Suppliers WHERE ProductId=" + prodID.ToString() + " and SupplierId=" + supID.ToString() + ")as x, Products, Suppliers " +
                "WHERE x.ProductId=Products.ProductId AND x.SupplierId=Suppliers.SupplierId";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

            //open connection
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //create reader
            try
            {
                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //getID
                    record[0] = reader["ProductSupplierId"].ToString();
                    record[1] = reader["ProdName"].ToString();
                    record[2] = reader["SupName"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //close connection
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return record;
        }
        public static bool AddPackage(Package packageToAdd)
        {
            //create connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            //create sql command
            string insertStatement =
                "INSERT Packages " +
                "(PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission) " +
                "VALUES (@PkgName, @PkgStartDate, @PkgEndDate, @PkgDesc, @PkgBasePrice, @PkgAgencyCommission)";

            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@PkgName", packageToAdd.Name);
            insertCommand.Parameters.AddWithValue(
                "@PkgStartDate", packageToAdd.Start_Date);
            insertCommand.Parameters.AddWithValue(
                "@PkgEndDate", packageToAdd.End_Date);
            insertCommand.Parameters.AddWithValue(
                "@PkgDesc", packageToAdd.Description);
            insertCommand.Parameters.AddWithValue(
                "@PkgBasePrice", packageToAdd.Base_Price);
            insertCommand.Parameters.AddWithValue(
                "@PkgAgencyCommission", packageToAdd.Agency_Commission);

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                return false;
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        public static bool AddPackageProductSupplier(int pkgID, int ProductsSuppliers)
        {
            //create connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            //create sql command
            string insertStatement =
                "IF NOT EXISTS (SELECT * FROM Packages_Products_Suppliers " +
                "WHERE PackageId = " + pkgID.ToString() + " AND ProductSupplierId = " +
                    ProductsSuppliers.ToString() + ") " +
                    "INSERT INTO Packages_Products_Suppliers (PackageId, ProductSupplierId) " +
                    "VALUES (" + pkgID.ToString() + "," + ProductsSuppliers.ToString() + ")";

            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                return false;
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        //delete package
        public static bool DeletePackage(int pkgID)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string deleteLinkingTableStatement =
                "delete from Packages_Products_Suppliers " +
                "where PackageId= " + pkgID.ToString();
            string deletePkgStatement =
                "DELETE FROM Packages " +
                "WHERE PackageId = " + pkgID.ToString();

            SqlCommand deleteLinkingTableCommand =
                new SqlCommand(deleteLinkingTableStatement, connection);
            SqlCommand deletePkgCommand =
                new SqlCommand(deletePkgStatement, connection);

            try
            {
                connection.Open();
                deleteLinkingTableCommand.ExecuteNonQuery();
                int count = deletePkgCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException)
            {
                MessageBox.Show("You do not have enough permission to delete this product",
                    "Error Deleting",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        //get a package
        public static Package GetPackage(int id)
        {

            Package pkg = new Package();

            //create connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            //create sql command
            string selectStatement = "SELECT * FROM Packages " +
                "WHERE PackageId =" + id.ToString();
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

            //open connection
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //create reader
            try
            {
                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                while (reader.Read())
                {
                    //add package details
                    pkg.ID = (int)reader["PackageId"];
                    pkg.Name = reader["PkgName"].ToString();
                    pkg.Start_Date = Convert.ToDateTime(reader["PkgStartDate"]);
                    pkg.End_Date = Convert.ToDateTime(reader["PkgEndDate"]);
                    pkg.Description = reader["PkgDesc"].ToString();
                    pkg.Base_Price = (decimal)reader["PkgBasePrice"];
                    pkg.Agency_Commission = (decimal)reader["PkgAgencyCommission"];

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //close connection
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pkg;
        }
        public static List<string[]> GetPackageProductSupplier(int pkgID)
        {
            List<string[]> records = new List<string[]>();


            //create connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string selectStatement = "select Packages_Products_Suppliers.productsupplierid, " +
                "prodname, supname " +
                "from Packages_Products_Suppliers, Products_Suppliers, Products, Suppliers " +
                "where Packages_Products_Suppliers.ProductSupplierId=Products_Suppliers.ProductSupplierId and " +
                "Products.ProductId=Products_Suppliers.ProductId and " +
                "Suppliers.SupplierId=Products_Suppliers.SupplierId and " +
                "Packages_Products_Suppliers.PackageId=" + pkgID.ToString();
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

            //open connection
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //create reader
            try
            {
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    string[] record = new string[3];

                    record[0] = reader["ProductSupplierId"].ToString();
                    record[1] = reader["ProdName"].ToString();
                    record[2] = reader["SupName"].ToString();
                    records.Add(record);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //close connection
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return records;
        }
        public static bool UpdatePackage(Package editPackage)
        {

            SqlConnection connection = TravelExpertsDB.GetConnection();
            string updateStatement =
                "UPDATE Packages SET " +
                "PkgName = @PkgName, " +
                "PkgStartDate = @PkgStartDate, " +
                "PkgEndDate = @PkgEndDate, " +
                "PkgDesc = @PkgDesc, " +
                "PkgBasePrice = @PkgBasePrice, " +
                "PkgAgencyCommission = @PkgAgencyCommission " +
                "WHERE PackageId = @PackageId ";
            SqlCommand updateCommand =
                new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue(
                "@PackageId", editPackage.ID);
            updateCommand.Parameters.AddWithValue(
                "@PkgName", editPackage.Name);
            updateCommand.Parameters.AddWithValue(
                "@PkgStartDate", editPackage.Start_Date);
            updateCommand.Parameters.AddWithValue(
                "@PkgEndDate", editPackage.End_Date);
            updateCommand.Parameters.AddWithValue(
                "@PkgDesc", editPackage.Description);
            updateCommand.Parameters.AddWithValue(
                "@PkgBasePrice", editPackage.Base_Price);
            updateCommand.Parameters.AddWithValue(
                "@PkgAgencyCommission", editPackage.Agency_Commission);

            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
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
        //delete records that are not in the list
        public static bool DeletePackageProductSupplier(int pkgID, List<int> prodSupID)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string stringProdSupId = "";
            foreach (int n in prodSupID)
            {
                stringProdSupId += n.ToString() + ",";
            }
            if (stringProdSupId.Length > 0)
            {
                stringProdSupId = stringProdSupId.Remove(stringProdSupId.Length - 1);
            }
            string deleteStatement =
                "IF EXISTS (SELECT * FROM Packages_Products_Suppliers " +
                "WHERE PackageId = " + pkgID.ToString() + " AND ProductSupplierId NOT in " +
                "(" + stringProdSupId + ")) " +
                "delete from Packages_Products_Suppliers " +
                "where PackageID=" + pkgID.ToString() + " AND ProductSupplierId NOT in " +
                "(" + stringProdSupId + ")";
            SqlCommand deleteCommand =
                new SqlCommand(deleteStatement, connection);
            try
            {
                connection.Open();
                int count = deleteCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
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
        public static int GetMaxPackageID()
        {
            int id;
            //create connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            //create sql command
            string selectStatement = "select MAX(packageID) from Packages";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

            //open connection
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                id = (int)selectCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //close connection
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }
        //find products that has the findMe string
        public static List<Product> GetProducts(string findMe, bool showAll)
        {

            List<Product> listOfProducts = new List<Product>();

            //create connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            //create sql command
            string selectStatement = "SELECT * FROM Products " +
                "WHERE prodname like '%" + findMe.Trim() + "%'";

            //search for something
            if (findMe.Trim().Length != 0)
            {
                string msg = "";
                if (Validator.inputIsInteger(findMe, out msg))
                {
                    selectStatement += " OR ProductId ='" + findMe + "'";
                }
            }
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

            //open connection
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //create reader
            try
            {
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    //create a package
                    Product newProduct = new Product();
                    //add package details
                    newProduct.prodID = (int)reader["ProductId"];
                    newProduct.prodName = reader["prodName"].ToString();
                    //add book to list
                    listOfProducts.Add(newProduct);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //close connection
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listOfProducts;
        }
    }
}
