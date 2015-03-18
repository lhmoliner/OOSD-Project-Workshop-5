/* CPRG214 Project 2 Website
 * Created/Modified By: John
 * January 20th, 2015
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace TravelExperts
{
    public class TravelExpertsDB
    {
        // Get connection to the database (connected)
        public static SqlConnection GetConnection()
        {
            string connectionString =
                //"Data Source=localhost\\sqlexpress;Initial Catalog=TravelExperts;Integrated Security=True";
                "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\TravelExperts.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}