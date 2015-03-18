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
    public partial class frmProductSupplier : Form
    {
        public frmProductSupplier()
        {
            InitializeComponent();
        }

        private void frmModifyProductSupplier_Load(object sender, EventArgs e)
        {
            // Data binding for the Products & Suppliers lists
            this.productsTableAdapter.Fill(this.travelExpertsDataSet.Products);
            this.suppliersTableAdapter.Fill(this.travelExpertsDataSet.Suppliers);
            lstProductList.ClearSelected();
            lstSupplierList.ClearSelected();
        }

        // Menu bar items
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frmModifyProductSupplier_Load(this, null);
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Products Tab
        private void lstProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtModifyProduct.Text = lstProductList.GetItemText(lstProductList.SelectedItem);
        }

        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtModifyProduct)) 
            {
                string selectedProd = lstProductList.GetItemText(lstProductList.SelectedItem);
                string editedProd = txtModifyProduct.Text;

                if (selectedProd != editedProd) 
                {
                    DialogResult update =
                    MessageBox.Show("Change '" + selectedProd + "' to '" + editedProd + "'?"
                    , "Confirm Change", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (update == DialogResult.OK)
                    {
                        ProductDB.UpdateProduct(selectedProd, editedProd);
                        // Refresh table adapter to display updated list
                        this.frmModifyProductSupplier_Load(this, null);

                        // Select the item that was just updated
                        int index = lstProductList.FindString(editedProd, -1);
                        if (index != -1)
                        {
                            lstProductList.SetSelected(index, true);
                        }
                    }
                }
            }  
        }

        // Supplier Tab
        private void lstSupplierList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtModifySupplier.Text = lstSupplierList.GetItemText(lstSupplierList.SelectedItem);
        }

        private void btnSaveSupplier_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtModifySupplier))
            {
                string selectedSup = lstSupplierList.GetItemText(lstSupplierList.SelectedItem);
                string editedSup = txtModifySupplier.Text;

                if (selectedSup != editedSup)
                {
                    DialogResult update =
                        MessageBox.Show("Change '" + selectedSup + "' to '" + editedSup + "'?"
                        , "Confirm Change", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (update == DialogResult.OK)
                    {
                        SupplierDB.UpdateSupplier(selectedSup, editedSup);
                        // Refresh table adapter to display updated list
                        this.frmModifyProductSupplier_Load(this, null);
                        lstSupplierList.GetItemText(lstSupplierList.SelectedItem);

                        // Select the item that was just updated
                        int index = lstSupplierList.FindString(editedSup, -1);
                        if (index != -1)
                        {
                            lstSupplierList.SetSelected(index, true);
                        }
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
