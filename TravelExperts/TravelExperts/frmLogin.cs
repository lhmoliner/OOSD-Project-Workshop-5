/* CMPP248 Part 2 Workshop 2
 * Login Form
 * Created By: Leisy Moliner
 * December 9, 2014
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelExperts
{
    public partial class frmLogin : Form
    {
        bool agentExists;

        public frmLogin()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string enteredAgentId = txtAgentId.Text;
                string enteredPassword = txtPassword.Text;

                //AgentDB agentToCheck = new AgentDB();

                agentExists = AgentDB.CheckPassword(enteredAgentId, enteredPassword);

                if (agentExists)
                {
                    this.Hide();
                    frmMain mainForm = new frmMain(); //presenting the main form
                    mainForm.agent = AgentDB.GetAgent(Convert.ToInt32(enteredAgentId)); 
                    mainForm.ShowDialog();
                    this.Close();
                } 
                else
                    MessageBox.Show("You entered an invalid AgentID or Password");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
        /*private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = TravelExpertsDB.GetConnection();//Define conection
                connection.Open();

                string enteredAgentId = txtAgentId.Text;
                string enteredPassword = txtPassword.Text;

                SqlCommand command = new SqlCommand("SELECT ISNULL(AgentId, '') AS AgentId, " 
                    +"ISNULL(AgtPassword,'') AS AgtPassword "
                    +"FROM Agents WHERE AgentId = @AgentId and AgtPassword = @AgtPassword", connection);

                command.Parameters.Add(new SqlParameter("AgentId", enteredAgentId));
                command.Parameters.Add(new SqlParameter("AgtPassword", enteredPassword));

                SqlDataReader dataReader = command.ExecuteReader();

                try
                {
                    dataReader.Read();
                    if (dataReader["AgentId"].ToString().Trim() == enteredAgentId &&
                        dataReader["AgtPassword"].ToString().Trim() == enteredPassword)
                    {
                        this.Hide();
                        frmMain mainForm = new frmMain(); //presenting the main form
                        mainForm.ShowDialog();
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("You entered an invalid AgentID or Password");
                }
                dataReader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }*/

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
