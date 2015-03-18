/* CMPP248 Part 2 Workshop 2
 * Class for AgentDB
 * Created By: Leisy Moliner
 * December 9, 2014
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
    public class AgentDB
    {
        public static Agent GetAgent(int agentId)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();//Define conection

            //Build select statement 
            string selectStatement
                = "SELECT * FROM Agents "
                + "WHERE AgentId = @AgentId";  //Get the data into a temp table 

            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);//Build SQL command
            selectCommand.Parameters.AddWithValue("@AgentId", agentId);//Patch previous statement

            //Exception handling
            try
            {
                //Executes if agent exist
                connection.Open();
                SqlDataReader custReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (custReader.Read())
                {
                    Agent agent = new Agent();
                    agent.AgentId = Convert.ToInt32(custReader["AgentId"]);//Fill with data from reader
                    agent.AgtFirstName = custReader["AgtFirstName"].ToString();
                    agent.AgtMiddleInitial = custReader["AgtMiddleInitial"].ToString();
                    agent.AgtLastName = custReader["AgtLastName"].ToString();
                    agent.AgtBusPhone = custReader["AgtBusPhone"].ToString();
                    agent.AgtEmail = custReader["AgtEmail"].ToString();
                    agent.AgtPosition = custReader["AgtPosition"].ToString();
                    agent.AgencyId = Convert.ToInt32(custReader["AgencyId"]);
                    agent.AgtPassword = custReader["AgtPassword"].ToString();

                    return agent;//Returns agent
                }
                else //agent does not exist
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

        public static int AddAgent(Agent agent)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string insertStatement =
                "INSERT Agents " +
                "(AgtFirstName, AgtMiddleInitial, AgtLastName, AgtBusPhone, AgtEmail, AgtPosition, AgencyId, AgtPassword) " +
                "VALUES (@AgtFirstName, @AgtMiddleInitial, @AgtLastName, @AgtBusPhone, @AgtEmail, @AgtPosition, @AgencyId, @AgtPassword)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@AgtFirstName", agent.AgtFirstName);
            insertCommand.Parameters.AddWithValue("@AgtMiddleInitial", agent.AgtMiddleInitial);
            insertCommand.Parameters.AddWithValue("@AgtLastName", agent.AgtLastName);
            insertCommand.Parameters.AddWithValue("@AgtBusPhone", agent.AgtBusPhone);
            insertCommand.Parameters.AddWithValue("@AgtEmail", agent.AgtEmail);
            insertCommand.Parameters.AddWithValue("@AgtPosition", agent.AgtPosition);
            insertCommand.Parameters.AddWithValue("@AgencyId", agent.AgencyId);
            insertCommand.Parameters.AddWithValue("@AgtPassword", agent.AgtPassword);

            //Exception handling
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT IDENT_CURRENT('Agents') FROM Agents";

                SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
                int agentName = Convert.ToInt32(selectCommand.ExecuteScalar());
                return agentName;
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

        public static bool UpdateAgent(Agent oldAgent, Agent newAgent)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string updateStatement =

                "UPDATE Agents SET " +
                "AgtFirstName = @NewAgtFirstName, " +
                "AgtMiddleInitial = @NewAgtMiddleInitial, " +
                "AgtLastName = @NewAgtLastName, " +
                "AgtBusPhone = @NewAgtBusPhone, " +
                "AgtEmail = @NewAgtEmail, " +
                "AgtPosition = @NewAgtPosition, " +
                "AgencyId = @NewAgencyId, " +
                "AgtPassword = @NewAgtPassword " +
                "WHERE AgentId = @NewAgentId ";

            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@NewAgentId", newAgent.AgentId);
            updateCommand.Parameters.AddWithValue("@NewAgtFirstName", newAgent.AgtFirstName);
            updateCommand.Parameters.AddWithValue("@NewAgtMiddleInitial", newAgent.AgtMiddleInitial);
            updateCommand.Parameters.AddWithValue("@NewAgtLastName", newAgent.AgtLastName);
            updateCommand.Parameters.AddWithValue("@NewAgtBusPhone", newAgent.AgtBusPhone);
            updateCommand.Parameters.AddWithValue("@NewAgtEmail", newAgent.AgtEmail);
            updateCommand.Parameters.AddWithValue("@NewAgtPosition", newAgent.AgtPosition);
            updateCommand.Parameters.AddWithValue("@NewAgencyId", newAgent.AgencyId);
            updateCommand.Parameters.AddWithValue("@NewAgtPassword", newAgent.AgtPassword);

            //Exception handling
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

        public static bool DeleteAgent(Agent agent)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string deleteStatement =
               "DELETE FROM Agents " +
               "WHERE AgtFirstName = @AgtFirstName " + "AND AgtMiddleInitial = @AgtMiddleInitial " +
               "AND AgtLastName = @AgtLastName " + "AND AgtBusPhone = @AgtBusPhone " +
               "AND AgtEmail = @AgtEmail " + "AND AgtPosition = @AgtPosition " +
               "AND AgencyId = @AgencyId " + "AND AgtPassword = @AgtPassword ";


            SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@AgtFirstName", agent.AgtFirstName);
            deleteCommand.Parameters.AddWithValue("@AgtMiddleInitial", agent.AgtMiddleInitial);
            deleteCommand.Parameters.AddWithValue("@AgtLastName", agent.AgtLastName);
            deleteCommand.Parameters.AddWithValue("@AgtBusPhone", agent.AgtBusPhone);
            deleteCommand.Parameters.AddWithValue("@AgtEmail", agent.AgtEmail);
            deleteCommand.Parameters.AddWithValue("@AgtPosition", agent.AgtPosition);
            deleteCommand.Parameters.AddWithValue("@AgencyId", agent.AgencyId);
            deleteCommand.Parameters.AddWithValue("@AgtPassword", agent.AgtPassword);

            //Exception handling
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

        public static List<Agent> SearchAgents(string agentId)
        {

            List<Agent> agentList = new List<Agent>();
            SqlConnection connection = TravelExpertsDB.GetConnection(); //create connection

            //create sql command
            string selectStatement = "SELECT * FROM Agents " +
                "WHERE AgtFirstName like '%" + agentId.Trim() + "%' OR " +
                "AgtLastName like '%" + agentId.Trim() + "%'";

            if (agentId.Trim().Length != 0)//search for something
            {
                string msg = "";
                if (Validator.inputIsInteger(agentId, out msg))
                {
                    selectStatement += " OR AgentId ='" + agentId + "'";
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

            try
            {
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    //create an agent
                    Agent newAgent = new Agent();
                    //add agent details
                    newAgent.AgentId = Convert.ToInt32(reader["AgentId"]);
                    newAgent.AgtFirstName = reader["AgtFirstName"].ToString();
                    newAgent.AgtMiddleInitial = reader["AgtMiddleInitial"].ToString();
                    newAgent.AgtLastName = reader["AgtLastName"].ToString();
                    newAgent.AgtBusPhone = reader["AgtBusPhone"].ToString();
                    newAgent.AgtEmail = reader["AgtEmail"].ToString();
                    newAgent.AgtPosition = reader["AgtPosition"].ToString();
                    newAgent.AgencyId = Convert.ToInt32(reader["AgencyId"]);
                    newAgent.AgtPassword = reader["AgtPassword"].ToString();

                    //add agent to list
                    agentList.Add(newAgent);
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
          
            return agentList;
        }

        //to be linked with get agent
        public static bool CheckPassword (string enteredAgentId, string enteredPassword)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();//Define conection
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT ISNULL(AgentId, '') AS AgentId, "
                + "ISNULL(AgtPassword,'') AS AgtPassword "
                + "FROM Agents WHERE AgentId = @AgentId and AgtPassword = @AgtPassword", connection);

            command.Parameters.Add(new SqlParameter("AgentId", enteredAgentId));
            command.Parameters.Add(new SqlParameter("AgtPassword", enteredPassword));

            SqlDataReader dataReader = command.ExecuteReader();

            try
            {
                dataReader.Read();
                if (dataReader["AgentId"].ToString().Trim() == enteredAgentId &&
                    dataReader["AgtPassword"].ToString().Trim() == enteredPassword)
                {
                    return true;
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
