/* CPRG214 ASP Workshop 2
 * Created By: MB
 * January 22, 2015
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace TravelExperts
{
    [DataObject(true)]
    public static class PackageDB
    {
        //get packages of a customer from database. requires customers ID
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Package> GetPackagesByCustomerID(int id){
            List<Package> packages = new List<Package>();

            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement = 
                "SELECT "
                + "Packages.PackageId, Packages.PkgName, "
                + "Packages.PkgStartDate, Packages.PkgEndDate, "
                + "Packages.PkgDesc, Packages.PkgBasePrice, "
                + "Packages.PkgAgencyCommission "
                + "FROM Packages, Bookings "
                + "WHERE Packages.PackageID=Bookings.PackageID "
                + "AND Bookings.CustomerId=@CustomerId";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@CustomerId", id);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                if (reader.Read())
                {
                    Package package = new Package();
                    package.PackageID = (int)reader["PackageID"];
                    package.PkgName = (string)reader["PkgName"];
                    package.PkgStartDate = (DateTime)reader["PkgStartDate"];
                    package.PkgEndDate = (DateTime)reader["PkgEndDate"];
                    package.PkgDesc = (string)reader["PkgDesc"];
                    package.PkgBasePrice = (decimal)reader["PkgBasePrice"];
                    package.PkgAgencyCommission = (decimal)reader["PkgAgencyCommission"];

                    packages.Add(package);

                    return packages;
                }
                else
                {
                    return null;
                }
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

        //get a package from database based on id
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Package GetPackagesByID(int id)
        {
            Package package = null;

            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement =
                "SELECT * "
                + "FROM Packages "
                + "WHERE PackageID='"+id+"'";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    package = new Package();
                    package.PackageID = (int)reader["PackageID"];
                    package.PkgName = (string)reader["PkgName"];
                    package.PkgStartDate = (DateTime)reader["PkgStartDate"];
                    package.PkgEndDate = (DateTime)reader["PkgEndDate"];
                    package.PkgDesc = (string)reader["PkgDesc"];
                    package.PkgBasePrice = (decimal)reader["PkgBasePrice"];
                    package.PkgAgencyCommission = (decimal)reader["PkgAgencyCommission"];
                    
                    return package;
                }
                else
                {
                    return null;
                }
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