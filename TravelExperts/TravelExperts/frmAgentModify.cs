/* CMPP248 Part 2 Workshop 2
 * AgentModify form
 * Created By: Leisy Moliner
 * December 9, 2014
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelExperts
{
    public partial class frmAgentModify : Form
    {
        public frmAgentModify()
        {
            InitializeComponent();
        }

        public Agent agent;
        public bool addAgent;

        //Form Methods --------------------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (addAgent)
                {
                    agent = new Agent();//Adding a new agent
                    this.PutAgentData(agent);

                    try
                    {
                        agent.AgentId = AgentDB.AddAgent(agent);
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
                else
                {
                    Agent newAgent = new Agent();
                    newAgent.AgentId = agent.AgentId;
                    this.PutAgentData(newAgent);
                    try
                    {
                        if (!AgentDB.UpdateAgent(agent, newAgent))
                        {
                            MessageBox.Show("Another user has updated or deleted that agent.", "Database Error");
                            this.DialogResult = DialogResult.Retry;
                        }
                        else
                        {
                            agent = newAgent;
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAgentModify_Load(object sender, EventArgs e)
        {
            if (addAgent)
            {
                this.Text = "Add Agent";//Customize name (text) on form's window
                this.btnAdd.Text = "Add";//Customize text on button for Add/Modify
            }
            else
            {
                this.Text = "Modify Agent";//Customize name (text) on form's window
                this.btnAdd.Text = "Modify";//Customize text on button for Add/Modify
                this.DisplayAgent();//Loads info from selection and populates textBoxes
            }
        }

        //Supporting methods --------------------------------
        private void DisplayAgent()
        {
            txtAgtFirstName.Text = agent.AgtFirstName;//Loads info from selection and populates textBoxes
            txtAgtMiddleInitial.Text = agent.AgtMiddleInitial;
            txtAgtLastName.Text = agent.AgtLastName;
            txtAgtBusPhone.Text = agent.AgtBusPhone;
            txtAgtEmail.Text = agent.AgtEmail;
            cmbAgtPosition.Text = agent.AgtPosition;
            cmbAgentId.Text = Convert.ToString(agent.AgencyId);
            txtAgtPassword.Text = agent.AgtPassword;
        }

        private bool IsValidData()
        {
            //string msg;
            //Validating data on GUI using Validator class - check is data format is valid
            return
                Validator.IsPresent(txtAgtFirstName) &&
                //Validator.IsPresent(txtAgtMiddleInitial) &&
                Validator.IsPresent(txtAgtLastName) &&
                Validator.IsPresent(txtAgtBusPhone) &&
                Validator.IsPresent(txtAgtEmail) &&
                Validator.IsPresent(cmbAgtPosition) &&
                Validator.IsPresent(cmbAgentId) &&
                //Validator.inputIsInteger(txtAgencyId.Text, out msg) &&
                //Validator.inputRangeIsValid(txtAgencyId, 1, 3, out msg) &&
                Validator.IsPresent(txtAgtPassword);
        }

        private void PutAgentData(Agent agent)
        {
            agent.AgtFirstName = txtAgtFirstName.Text;
            agent.AgtMiddleInitial = txtAgtMiddleInitial.Text;
            agent.AgtLastName = txtAgtLastName.Text;
            agent.AgtBusPhone = txtAgtBusPhone.Text;
            agent.AgtEmail = txtAgtEmail.Text;
            agent.AgtPosition = cmbAgtPosition.Text;
            agent.AgencyId = Convert.ToInt32(cmbAgentId.Text);
            agent.AgtPassword = txtAgtPassword.Text;
        }
    }
}
