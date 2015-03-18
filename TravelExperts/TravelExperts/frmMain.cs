/* CMPP248 Part 2 Workshop 2
 * Class for Packages
 * Created by: MB, Leisy, and John
 * January 12, 2015
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private Package package;
        public Agent agent;


        //Display individual forms according to button pressed --------------------------------
        private void btnAddPackage_Click(object sender, EventArgs e)
        {
            package = null;
            frmPackage newForm = new frmPackage(package);
            DialogResult result = newForm.ShowDialog();
            SearchFor();
        }

        private void btnAgent_Click(object sender, EventArgs e)
        {
            frmAgents callAgentForm = new frmAgents();
            callAgentForm.ShowDialog();
            SearchFor();
        }

        private void btnProductSuppliers_Click(object sender, EventArgs e)
        {
            frmProduct newForm = new frmProduct();
            DialogResult result = newForm.ShowDialog();
            SearchFor();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //delete the package
            if (rdbPackage.Checked)
            {
                int row = this.dgvMainPage.CurrentCell.RowIndex;
                int col = 0;

                DialogResult result =
                MessageBox.Show("Do you want to delete "
                + dgvMainPage.SelectedRows[0].Cells[1].Value.ToString() + "?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int pkgid = (int)dgvMainPage.Rows[row].Cells[col].Value;
                    if (PackageDB.DeletePackage(pkgid))
                    {
                        MessageBox.Show("Package was deleted");
                        SearchFor();
                    }
                    else
                    {
                        MessageBox.Show("Failed deleting Package");
                    }
                }
            }
        }        

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //edit package from main form
            if (rdbPackage.Checked)
            {
                //get selected package
                int row = this.dgvMainPage.CurrentCell.RowIndex;
                int col = 0;
                int pkgid = (int)dgvMainPage.Rows[row].Cells[col].Value;
                package = PackageDB.GetPackage(pkgid);

                //open modify form and pass selected package
                frmPackage newForm = new frmPackage(package);
                DialogResult result = newForm.ShowDialog();
                SearchFor();
            }
        }


        //Main form controls --------------------------------
         private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //DataGridView Controls  --------------------------------
        private void dgvMainPage_Click(object sender, EventArgs e)
        {
            EnableDisableEditButton();
        }

        private void EnableDisableEditButton()
        {
            if (OneRowIsSelected() && rdbPackage.Checked)
            {
                if (rdbPackage.Checked)//package
                {
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }//multiple items are selected
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private bool OneRowIsSelected()
        {
            int count = 0;
            foreach (DataGridViewRow item in dgvMainPage.SelectedRows)
            {
                count++;
            }
            if (count == 1)
            {
                return true;
            }
            return false;
        }

        private void chbIncludeExpiredPackages_Click(object sender, EventArgs e)
        {
            SearchFor();
            FocusSelectAllSearchBox();
        }


        //Methods/Actions for interaction with radio buttons and search --------------------------------
        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            SearchFor();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchFor();
        }

        private void SearchFor()
        {
            bool isIncludeExpiredPackagesEnabled = false;
            dgvMainPage.DataSource = null;
            
            //search for Packages
            if (rdbPackage.Checked)
            {
                grpListOf.Text = "List Of Package";
                isIncludeExpiredPackagesEnabled = true;
                dgvMainPage.DataSource = PackageDB.GetPackages(txtSearch.Text, chbIncludeExpiredPackages.Checked);
                hideColumn(5);
                hideColumn(6);
                dgvMainPage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            //search for Products
            if (rdbProduct.Checked)
            {
                grpListOf.Text = "List Of Products";
                dgvMainPage.DataSource = ProductDB.SearchProducts(txtSearch.Text);
                dgvMainPage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            //search for Suppliers
            if (rdbSupplier.Checked)
            {
                grpListOf.Text = "List Of Suppliers";
                dgvMainPage.DataSource = SupplierDB.SearchSuppliers(txtSearch.Text);
                dgvMainPage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            //search for Agents
            if (rdbAgents.Checked)
            {
                grpListOf.Text = "List Of Agents";
                dgvMainPage.DataSource = AgentDB.SearchAgents(txtSearch.Text);
                dgvMainPage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                hideColumn(8);
            }

            chbIncludeExpiredPackages.Enabled = isIncludeExpiredPackagesEnabled;//enable 'IncludeExpiredPackages' box or not
            this.Refresh();
            EnableDisableEditButton();

            //dgvMainPage.Columns[columNo].Visible = false;
        }

        private void FocusSelectAllSearchBox()
        {
            txtSearch.Focus();
            txtSearch.SelectAll();
        }

        private void rdbPackage_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";//empty text field if user changes search parameters
            SearchFor();
            FocusSelectAllSearchBox();
        }

        private void rdbProduct_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";//empty text field if user changes search parameters
            SearchFor();
        }

        private void rdbSupplier_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";//empty text field if user changes search parameters
            SearchFor();
        }

        private void rdbAgents_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";//empty text field if user changes search parameters
            SearchFor();
        }

        private void chbIncludeExpiredPackages_CheckedChanged(object sender, EventArgs e)
        {
            SearchFor();
        }

        private void hideColumn(int columNo)
        {
            dgvMainPage.Columns[columNo].Visible = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            SearchFor();
            lblAgentInfo.Text = "Welcome " + agent.AgtFirstName + " " + agent.AgtLastName +
                "\nPhone: " + agent.AgtBusPhone + "\nEmail: " + agent.AgtEmail + "\nPosition: " + agent.AgtPosition;
        }
    }
}
