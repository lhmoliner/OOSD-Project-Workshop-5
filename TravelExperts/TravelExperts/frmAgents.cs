/* CMPP248 Part 2 Workshop 2
 * Form Agents
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
    public partial class frmAgents : Form
    {
        public frmAgents()
        {
            InitializeComponent();
        }

        private Agent agent;

        //Form Methods --------------------------------
        private void frmAgents_Load(object sender, EventArgs e)
        {
            SearchFor();//fills table with current information
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAgentModify addAgentForm = new frmAgentModify();
            addAgentForm.addAgent = true;
            DialogResult result = addAgentForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                agent = addAgentForm.agent;
                txtAgentId.Text = agent.AgentId.ToString();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            //Get agent from selection
            int agentId = Convert.ToInt32(dgvAgents.SelectedRows[0].Cells[0].Value);
            try
            {
                agent = AgentDB.GetAgent(agentId);

                frmAgentModify modifyAgentForm = new frmAgentModify();
                modifyAgentForm.addAgent = false;
                modifyAgentForm.agent = agent;

                DialogResult result = modifyAgentForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    agent = modifyAgentForm.agent;
                    SearchFor();
                }
                else if (result == DialogResult.Retry)
                {
                    //this.GetAgent(agent.AgentId);
                    SearchFor();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Deleting Agents' information its not supported at this moment",
            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void txtAgentId_TextChanged(object sender, EventArgs e)
        {
            string searchMe = txtAgentId.Text;
            dgvAgents.DataSource = AgentDB.SearchAgents(searchMe);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Supporting methods --------------------------------
        private void SearchFor()
        {
            dgvAgents.DataSource = AgentDB.SearchAgents(txtAgentId.Text);
            dgvAgents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //not visible for column with password 
            dgvAgents.Columns[8].Visible = false;
            this.Refresh();
        }

        private void ReloadGridView()
        {
            foreach (DataGridViewRow item in dgvAgents.SelectedRows)
            { dgvAgents.Rows.RemoveAt(item.Index); }
        }

        //Reload the GridView after updates
    }
}