using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TravelExpertsDB
/// </summary>
/// 
namespace TravelExperts
{
    public class TravelExpertsDB
    {
        // Get connection to the database (connected)
        public static SqlConnection GetConnection()
        {
            string connectionString =
                "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\TravelExperts.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
