/* CPRG214 Project 2 Website
 * Created/Modified By: John, Leisy and MB
 * February 2, 2015
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
    public static class CustomerDB
    {
        //get customers from the database
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement =
                "SELECT * " +
                "FROM Customers ORDER BY CustFirstName, CustLastName";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            try
            {
                connection.Open();
                SqlDataReader custReader = selectCommand.ExecuteReader();
                while (custReader.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerID = (int)custReader["CustomerID"];
                    customer.CustFirstName = (string)custReader["CustFirstName"];
                    customer.CustLastName = (string)custReader["CustLastName"];
                    customer.CustAddress = (string)custReader["CustAddress"];
                    customer.CustCity = (string)custReader["CustCity"];
                    customer.CustProv = (string)custReader["CustProv"];
                    customer.CustPostal = (string)custReader["CustPostal"];
                    customer.CustCountry = (string)custReader["CustCountry"];
                    customer.CustHomePhone = (string)custReader["CustHomePhone"];
                    customer.CustBusPhone = (string)custReader["CustBusPhone"];
                    customer.CustEmail = (string)custReader["CustEmail"];
                    customer.AgentId = (int)custReader["AgentID"];

                    customers.Add(customer);
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
            return customers;
        }

        //get a customer from database based on customer id 
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Customer GetCustomer(int customerID)
        {
            Customer customer = null;

            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement
                = "SELECT * "
                + "FROM Customers "
                + "WHERE CustomerID = @CustomerID";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@CustomerID", customerID);
            try
            {
                connection.Open();
                SqlDataReader custReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (custReader.Read())
                {
                    customer = new Customer();
                    customer.CustomerID = (int)custReader["CustomerID"];
                    customer.CustFirstName = (string)custReader["CustFirstName"];
                    customer.CustLastName = (string)custReader["CustLastName"];
                    customer.CustAddress = (string)custReader["CustAddress"];
                    customer.CustCity = (string)custReader["CustCity"];
                    customer.CustProv = (string)custReader["CustProv"];
                    customer.CustPostal = (string)custReader["CustPostal"];
                    customer.CustCountry = (string)custReader["CustCountry"];
                    customer.CustHomePhone = (string)custReader["CustHomePhone"];
                    customer.CustBusPhone = (string)custReader["CustBusPhone"];
                    customer.CustEmail = (string)custReader["CustEmail"];
                    customer.AgentId = (int)custReader["AgentID"];
                    return customer;
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

        //get a customer from database based on customer email 
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Customer GetCustomerByEmail(string custEmail)
        {
            Customer customer = null;

            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement
                = "SELECT * "
                + "FROM Customers "
                + "WHERE CustEmail = @CustEmail";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@CustEmail", custEmail);

            try
            {
                connection.Open();
                SqlDataReader custReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (custReader.Read())
                {
                    customer = new Customer();
                    customer.CustomerID = (int)custReader["CustomerID"];
                    customer.CustFirstName = (string)custReader["CustFirstName"];
                    customer.CustLastName = (string)custReader["CustLastName"];
                    customer.CustAddress = (string)custReader["CustAddress"];
                    customer.CustCity = (string)custReader["CustCity"];
                    customer.CustProv = (string)custReader["CustProv"];
                    customer.CustPostal = (string)custReader["CustPostal"];
                    customer.CustCountry = (string)custReader["CustCountry"];
                    customer.CustHomePhone = (string)custReader["CustHomePhone"];
                    customer.CustBusPhone = (string)custReader["CustBusPhone"];
                    customer.CustEmail = (string)custReader["CustEmail"];
                    customer.AgentId = (int)custReader["AgentId"];
                    customer.CustPassword = (string)custReader["CustPassword"];
                    return customer;
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

        // Adds a customer to database
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int AddCustomer(Customer customer)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string insertStatement =
                "INSERT Customers " +
                "(CustFirstName, CustLastName, CustAddress, CustCity, CustProv, " +
                "CustPostal, CustCountry, CustHomePhone, CustBusPhone, CustEmail, AgentID, CustPassword) " +
                "VALUES (@CustFirstName, @CustLastName, @CustAddress, @CustCity, @CustProv, " +
                "@CustPostal, @CustCountry, @CustHomePhone, @CustBusPhone, @CustEmail, @AgentID, @CustPassword)";
            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@CustFirstName", customer.CustFirstName);
            insertCommand.Parameters.AddWithValue("@CustLastName", customer.CustLastName);
            insertCommand.Parameters.AddWithValue("@CustAddress", customer.CustAddress);
            insertCommand.Parameters.AddWithValue("@CustCity", customer.CustCity);
            insertCommand.Parameters.AddWithValue("@CustProv", customer.CustProv);
            insertCommand.Parameters.AddWithValue("@CustPostal", customer.CustPostal);
            insertCommand.Parameters.AddWithValue("@CustCountry", customer.CustCountry);
            insertCommand.Parameters.AddWithValue("@CustHomePhone", customer.CustHomePhone);
            insertCommand.Parameters.AddWithValue("@CustBusPhone", customer.CustBusPhone);
            insertCommand.Parameters.AddWithValue("@CustEmail", customer.CustEmail);
            insertCommand.Parameters.AddWithValue("@AgentID", 4);
            insertCommand.Parameters.AddWithValue("@CustPassword", customer.CustPassword);
            try
            {
                connection.Open();
                int count = insertCommand.ExecuteNonQuery();
                if (count > 0)
                    return 1;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return -1;
        }

        //updates customer
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static bool UpdateCustomer(Customer original_customer, Customer customer)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string updateStatement =
                "UPDATE Customers SET " +
                "CustFirstName = @NewCustFirstName, " +
                "CustLastName = @NewCustLastName, " +
                "CustAddress = @NewCustAddress, " +
                "CustCity = @NewCustCity, " +
                "CustProv = @NewCustProv, " +
                "CustPostal = @NewCustPostal, " +
                "CustCountry = @NewCustCountry, " +
                "CustHomePhone = @NewCustHomePhone, " +
                "CustBusPhone = @NewCustBusPhone, " +
                "CustEmail = @NewCustEmail " +

                "WHERE " +
                "CustomerID = @OldCustomerID AND " +
                "CustFirstName = @OldCustFirstName AND " +
                "CustLastName = @OldCustLastName AND " +
                "CustAddress = @OldCustAddress AND " +
                "CustCity = @OldCustCity AND " +
                "CustProv = @OldCustProv AND " +
                "CustPostal = @OldCustPostal AND " +
                "CustCountry = @OldCustCountry AND " +
                "CustHomePhone = @OldCustHomePhone AND " +
                "CustBusPhone = @OldCustBusPhone AND " +
                "CustEmail = @OldCustEmail AND " +
                "AgentID = @OldAgentID ";

            SqlCommand updateCommand =
                new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@NewCustFirstName", customer.CustFirstName);
            updateCommand.Parameters.AddWithValue("@NewCustLastName", customer.CustLastName);
            updateCommand.Parameters.AddWithValue("@NewCustAddress", customer.CustAddress);
            updateCommand.Parameters.AddWithValue("@NewCustCity", customer.CustCity);
            updateCommand.Parameters.AddWithValue("@NewCustProv", customer.CustProv);
            updateCommand.Parameters.AddWithValue("@NewCustPostal", customer.CustPostal);
            updateCommand.Parameters.AddWithValue("@NewCustCountry", customer.CustCountry);
            updateCommand.Parameters.AddWithValue("@NewCustHomePhone", customer.CustHomePhone);
            updateCommand.Parameters.AddWithValue("@NewCustBusPhone", customer.CustBusPhone);
            updateCommand.Parameters.AddWithValue("@NewCustEmail", customer.CustEmail);

            updateCommand.Parameters.AddWithValue("@OldCustomerId", original_customer.CustomerID);
            updateCommand.Parameters.AddWithValue("@OldCustFirstName", original_customer.CustFirstName);
            updateCommand.Parameters.AddWithValue("@OldCustLastName", original_customer.CustLastName);
            updateCommand.Parameters.AddWithValue("@OldCustAddress", original_customer.CustAddress);
            updateCommand.Parameters.AddWithValue("@OldCustCity", original_customer.CustCity);
            updateCommand.Parameters.AddWithValue("@OldCustProv", original_customer.CustProv);
            updateCommand.Parameters.AddWithValue("@OldCustPostal", original_customer.CustPostal);
            updateCommand.Parameters.AddWithValue("@OldCustCountry", original_customer.CustCountry);
            updateCommand.Parameters.AddWithValue("@OldCustHomePhone", original_customer.CustHomePhone);
            updateCommand.Parameters.AddWithValue("@OldCustBusPhone", original_customer.CustBusPhone);
            updateCommand.Parameters.AddWithValue("@OldCustEmail", original_customer.CustEmail);
            updateCommand.Parameters.AddWithValue("@OldAgentID", original_customer.AgentId);

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

        //deletes customer
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteCustomer(Customer customer)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Customers " +
                "WHERE " +
                "CustomerID = @CustomerID AND " +
                "CustFirstName = @CustFirstName AND " +
                "CustLastName = @CustLastName AND " +
                "CustAddress = @CustAddress AND " +
                "CustCity = @CustCity AND " +
                "CustProv = @CustProv AND " +
                "CustPostal = @CustPostal AND " +
                "CustCountry = @CustCountry AND " +
                "CustHomePhone = @CustHomePhone AND " +
                "CustBusPhone = @CustBusPhone AND " +
                "CustEmail = @CustEmail AND " +
                "AgentID = @AgentID ";

            SqlCommand deleteCommand =
                new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
            deleteCommand.Parameters.AddWithValue("@CustFirstName", customer.CustFirstName);
            deleteCommand.Parameters.AddWithValue("@CustLastName", customer.CustLastName);
            deleteCommand.Parameters.AddWithValue("@CustAddress", customer.CustAddress);
            deleteCommand.Parameters.AddWithValue("@CustCity", customer.CustCity);
            deleteCommand.Parameters.AddWithValue("@CustProv", customer.CustProv);
            deleteCommand.Parameters.AddWithValue("@CustPostal", customer.CustPostal);
            deleteCommand.Parameters.AddWithValue("@CustCountry", customer.CustCountry);
            deleteCommand.Parameters.AddWithValue("@CustHomePhone", customer.CustHomePhone);
            deleteCommand.Parameters.AddWithValue("@CustBusPhone", customer.CustBusPhone);
            deleteCommand.Parameters.AddWithValue("@CustEmail", customer.CustEmail);
            deleteCommand.Parameters.AddWithValue("@AgentID", customer.AgentId);
            try
            {
                connection.Open();
                int count = deleteCommand.ExecuteNonQuery();
                if (count > 0)
                    return customer.CustomerID;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return -1;
        }

        //checks password before login
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static bool CheckPassword(string enteredCustEmail, string enteredCustPassword)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();//Define conection
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT ISNULL(CustEmail, '') AS CustEmail, "
                + "ISNULL(CustPassword,'') AS CustPassword "
                + "FROM Customers WHERE CustEmail = @CustEmail and CustPassword = @CustPassword", connection);

            command.Parameters.Add(new SqlParameter("CustEmail", enteredCustEmail));
            command.Parameters.Add(new SqlParameter("CustPassword", enteredCustPassword));

            SqlDataReader dataReader = command.ExecuteReader();

            try
            {
                dataReader.Read();
                if (dataReader.HasRows)
                {
                    if (dataReader["CustEmail"].ToString().Trim() == enteredCustEmail &&
                        dataReader["CustPassword"].ToString().Trim() == enteredCustPassword)
                    {
                        return true;
                    }
                    else
                        return false;
                }
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
                dataReader.Close();
            }
        }
    }
}