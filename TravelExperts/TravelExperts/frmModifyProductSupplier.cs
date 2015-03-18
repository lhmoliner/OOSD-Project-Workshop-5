/*
 * Travel Experts Project #2 - C#, ASP.NET, SQL Server
 * Class for the Modify Products & Suppliers Windows Form
 * Created By: John Nguyen (Team 3)
 * Created On: December 9, 2004
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
    public partial class frmModifyProductSupplier : Form
    {
        public frmModifyProductSupplier()
        {
            InitializeComponent();
            tabModifyProductSupplier.Selected += new TabControlEventHandler(tabModifyProductSupplier_Selected);
        }

        private void frmModifyProductSupplier_Load(object sender, EventArgs e)
        {
            // Data binding for the Products & Suppliers lists
            this.productsTableAdapter.Fill(this.travelExpertsDataSet.Products);
            // Popluate the supplier list box with list information taken from the SupplierDB class
            lstSupplierList.DataSource = SupplierDB.GetSupplier();
            
            lstProductList.ClearSelected();
            lstSupplierList.ClearSelected();
            lstProductList.Enabled = true;
            lstSupplierList.Enabled = true;
            txtModifyProduct.Enabled = false;
            txtModifySupplier.Enabled = false;
            btnCancel.Enabled = false;
            btnDelete.Enabled = false;
        }

        // Menu bar items
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frmModifyProductSupplier_Load(this, null);
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Display the selected product in the text box
        private void lstProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtModifyProduct.Text = lstProductList.GetItemText(lstProductList.SelectedItem);
            txtModifyProduct.Enabled = true;
            btnCancel.Enabled = true;
            btnDelete.Enabled = true;
        }

        // Save button for the products tab
        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            string selectedProd = lstProductList.GetItemText(lstProductList.SelectedItem);
            string editedProd = txtModifyProduct.Text;

            // Validation to see if the typed product is already in the list
            int index = lstProductList.FindString(editedProd, -1);
            if (editedProd != "" && index != -1)
            {
                MessageBox.Show("Warning: Product already exists.","Duplicate Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else 
            { 
                // Test for saving
                if (lstProductList.Enabled == false && editedProd != "") // Test if adding product
                {
                    DialogResult result = MessageBox.Show("Save '" + editedProd + "' as a new product?", "Confirm Add",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.OK)
                    {
                        ProductDB.AddProductName(editedProd);
                        this.frmModifyProductSupplier_Load(this, null);

                        // Select the item that was just saved
                        SelectItem(editedProd, lstProductList);
                    }
                }
                else if (lstProductList.Enabled == false && editedProd == "")   // If adding product, check if textbox is empty
                {
                    MessageBox.Show("Please enter a new product name.", "Entry Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtModifyProduct.Focus();
                }
                else if (lstProductList.Enabled == true && selectedProd != editedProd) // Test if editing a selected product
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
                        SelectItem(editedProd, lstProductList);
                    }
                }
                else if (lstProductList.Enabled == true && selectedProd == "") // Test if editing a product but nothing is selected
                {
                    MessageBox.Show("Please select a product to edit.", "Item Not Selected",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtModifyProduct.Focus();
                }
            }
        }

        // Display the selected supplier in the text box
        private void lstSupplierList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtModifySupplier.Text = lstSupplierList.GetItemText(lstSupplierList.SelectedItem);
            txtModifySupplier.Enabled = true;
            btnCancel.Enabled = true;
            btnDelete.Enabled = true;
        }

        // Save button for the suppliers tab
        private void btnSaveSupplier_Click(object sender, EventArgs e)
        {
            string selectedSup = lstSupplierList.GetItemText(lstSupplierList.SelectedItem);
            string editedSup = txtModifySupplier.Text;

            // Validation to see if the typed item is already in the list
            int index = lstSupplierList.FindString(editedSup, -1);
            if (editedSup != "" && index != -1)
            {
                MessageBox.Show("Warning: Supplier already exists.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Test for saving or editing
                if (lstSupplierList.Enabled == false && editedSup != "")
                {
                    DialogResult result = MessageBox.Show("Save '" + editedSup + "' as a new supplier?", "Confirm Add",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.OK)
                    {
                        SupplierDB.AddSupplierName(editedSup);
                        this.frmModifyProductSupplier_Load(this, null);

                        // Select the item that was just saved
                        SelectItem(editedSup, lstSupplierList);
                    }
                }
                else if (lstSupplierList.Enabled == false && editedSup == "")
                {
                    MessageBox.Show("Please enter a new supplier name.", "Entry Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtModifySupplier.Focus();
                }
                else if (lstSupplierList.Enabled == true && selectedSup != editedSup)
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
                        SelectItem(editedSup, lstSupplierList);
                    }
                }
                else if (lstSupplierList.Enabled == true && selectedSup == "")
                {
                    MessageBox.Show("Please select a supplier name to edit.", "Item Not Selected",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtModifySupplier.Focus();
                }
            }
        }

        // Declare a variable to determine which tab the user has selected
        public bool productTab;

        // Create and Delete functions for both Products and Suppliers
        private void tabModifyProductSupplier_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name == tabProduct.Name)  // Trigger when Product tab is selected
            {
                lstProductList.ClearSelected();
                lstProductList.Enabled = true;
                txtModifyProduct.Enabled = false;
                btnAdd.Enabled = true;
                btnCancel.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (e.TabPage.Name == tabSupplier.Name)    // Trigger when Supplier tab is selected
            {
                lstSupplierList.ClearSelected();
                lstSupplierList.Enabled = true;
                txtModifySupplier.Enabled = false;
                btnAdd.Enabled = true;
                btnCancel.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        // Create button for both Products and Suppliers
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (tabModifyProductSupplier.SelectedTab == tabProduct) // Create object for product
            {
                ResetForm();
                lstProductList.Enabled = false;
                txtModifyProduct.Enabled = true;
                txtModifyProduct.Focus();
                btnAdd.Enabled = false;
                btnCancel.Enabled = true;
            }
            else if (tabModifyProductSupplier.SelectedTab == tabSupplier)
            {
                ResetForm();
                lstSupplierList.Enabled = false;
                txtModifySupplier.Enabled = true;
                txtModifySupplier.Focus();
                btnAdd.Enabled = false;
                btnCancel.Enabled = true;   
            }
        }

        // The cancel button will clear all selections and reset the form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
            txtModifyProduct.Enabled = false;
            txtModifySupplier.Enabled = false;
            btnAdd.Enabled = true;
            btnCancel.Enabled = false;
        }

        // Reset the form when the Add, Delete, or Cancel buttons are pressed
        private void ResetForm()
        {
            lstProductList.ClearSelected();
            lstSupplierList.ClearSelected();
            lstProductList.Enabled = true;
            lstSupplierList.Enabled = true;
            txtModifySupplier.Clear();
            txtModifyProduct.Clear();
            btnDelete.Enabled = false;
        }

        // Delete a selected item for both the products and suppliers tab
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tabModifyProductSupplier.SelectedTab == tabProduct) // Delete objects for the product tab
            {
                string selectedProd = lstProductList.GetItemText(lstProductList.SelectedItem);
                var deleteList = string.Join("\n", ProductDB.GetDeleteList(selectedProd));
                DialogResult delProd = MessageBox.Show("Are you sure you want to delete '" + selectedProd +"'?\n\n" +
                    "You will also be deleting the following links to this product:\n" + deleteList,
                    "Confirm Delete",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (delProd == DialogResult.OK)     // Delete if dialog result is OK
                {
                    ProductDB.DeleteProductName(selectedProd);      // Delete the product
                    this.frmModifyProductSupplier_Load(this, null); // Refresh the page
                }
            }
            else if (tabModifyProductSupplier.SelectedTab == tabSupplier) // Delete objects for the supplier tab
            {
                string selectedSup = lstSupplierList.GetItemText(lstSupplierList.SelectedItem);
                var deleteList = string.Join("\n", SupplierDB.GetDeleteList(selectedSup));
                DialogResult delProd = MessageBox.Show("Are you sure you want to delete '" + selectedSup + "'?\n\n" +
                    "You will also be deleting the following links to this supplier:\n" + deleteList,
                    "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (delProd == DialogResult.OK)     // Delete if dialog result is OK
                {
                    SupplierDB.DeleteSupplierName(selectedSup);     // Delete the selected supplier
                    this.frmModifyProductSupplier_Load(this, null); // Refresh the page
                }
            }
        }

        // Method to select an item that was just saved or edited
        public static void SelectItem(string selected, ListBox list)
        {
            int index = list.FindString(selected, -1);
            if (index != -1)
            {
                list.SetSelected(index, true);

            }
        }
    }
}
