/* CMPP248 Part 2 Workshop 2
 * Class for Packages
 * Created by: MB, and Leisy
 * January 12, 2015
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
    public partial class frmPackage : Form
    {
        Package package;
        public frmPackage(Package newPackage)
        {
            package = newPackage;
            InitializeComponent();
            this.AcceptButton = btnSubmit;
        }

        private void frmPackage_Load(object sender, EventArgs e)
        {
            if(package != null){//edit was selected
                //populate form
                PopulateForm();
            }
            FillProductComboBox();
        }
        private void PopulateForm()
        {
            txtName.Text = package.Name;
            txtDescription.Text = package.Description;
            txtPrice.Text = package.Base_Price.ToString();
            txtCommission.Text = package.Agency_Commission.ToString();
            dtpStart.Value = package.Start_Date;
            dtpEnd.Value = package.End_Date;

            //fill dgvProductSupplier
            List<string[]> listPkgProdSup = new List<string[]>();
            listPkgProdSup = PackageDB.GetPackageProductSupplier(package.ID);

            //add to datagridview if no duplicate
            foreach (string[] list in listPkgProdSup)
            {
                dgvProductSuppliers.Rows.Add(list[0], list[1], list[2]);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FillProductComboBox()
        {
            List<Product> products;
            products = PackageDB.GetProducts("");

            //foreach (Product p in products)
            //{
            //    cbxProductList.Items.Add(p);
            //}
            cbxProductList.DataSource = products;
            //cbxProductList.ValueMember = "prodID";
            //cbxProductList.DisplayMember = "prodName";
        }
        private void FillSupplierCombobox()
        {
            List<Supplier> suppliers;
            int productID = ((Product)cbxProductList.SelectedItem).prodID;
            suppliers = PackageDB.GetSuppliers(productID.ToString());

            cbxSuppliers.DataSource = suppliers;
            //cbxSuppliers.ValueMember = "SupplierId";
            //cbxSuppliers.DisplayMember = "SupName";
        }
        //add product and supplier to package
        private void btnAddToPackage_Click(object sender, EventArgs e)
        {
            int prodID = ((Product)cbxProductList.SelectedItem).prodID;
            string prodName = ((Product)cbxProductList.SelectedItem).prodName;
            int supID = ((Supplier)cbxSuppliers.SelectedItem).SupplierId;
            string supName = ((Supplier)cbxSuppliers.SelectedItem).SupName;

            //add to datagridview if no duplicate
            if(ProductSupplierIsNotIncluded(prodName,supName)){
                string[] record = PackageDB.GetProductSupplier(prodID, supID);
            
                //add row to datagridview
                dgvProductSuppliers.Rows.Add(record[0],record[1],record[2]);
            }
        }
        private void cbxProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillSupplierCombobox();
        }
        private bool ProductSupplierIsNotIncluded(string pName,string sName)
        {
            foreach (DataGridViewRow row in dgvProductSuppliers.Rows)
            {
                if ((row.Cells[1].Value.ToString().Equals(pName)) &&
                    (row.Cells[2].Value.ToString().Equals(sName.ToUpper())))
                {
                    return false;
                }
            }
            return true;
        }
        //remove product&supplier on datagridview
        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dgvProductSuppliers.SelectedRows)
            {
                dgvProductSuppliers.Rows.RemoveAt(item.Index);
            }
            dgvProductSuppliers.ClearSelection();
        }
        private bool ValidatePackageDataInput()
        {
            string msg="not set";
                //valid data
                if(Validator.notEmpty(txtName, out msg) &&
                    Validator.notEmpty(txtDescription, out msg) &&
                    Validator.StartAndEndDateIsValid(dtpStart,dtpEnd, out msg) &&
                    Validator.DateIsValid(dtpEnd, out msg) &&
                    Validator.InputIsDecimal(txtPrice, out msg) &&
                    Validator.inputIsPositive(txtPrice, out msg) &&
                    Validator.InputIsDecimal(txtCommission, out msg) &&
                    Validator.inputRangeIsValid
                        (txtCommission, 0, Convert.ToDecimal(txtPrice.Text), out msg))
                {
                    return true;
                }
            //invalid data
                MessageBox.Show("Invalid Input: " + msg);
                return false;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //create package
            if (package == null)
            {
                if(ValidatePackageDataInput())
                {
                    //create package object
                    Package p = new Package();
                    p.Name = txtName.Text;
                    p.Description = txtDescription.Text;
                    p.Start_Date = dtpStart.Value;
                    p.End_Date = dtpEnd.Value;
                    p.Base_Price = Convert.ToDecimal(txtPrice.Text);
                    p.Agency_Commission = Convert.ToDecimal(txtCommission.Text);

                    //insert package to DB
                    if (PackageDB.AddPackage(p)) //package was created
                    {
                        //get list of added products and suppliers
                        List<int> list = new List<int>();
                        foreach (DataGridViewRow item in dgvProductSuppliers.Rows)
                        {
                            int id = Convert.ToInt32(item.Cells[0].Value);
                            list.Add(id);
                        }
                        p.ID = PackageDB.GetMaxPackageID();
                        //insert products suppliers
                        foreach(int l in list){
                            PackageDB.AddPackageProductSupplier(p.ID, l);
                        }
                        MessageBox.Show("The Package was Added.",
                            "Package was Added");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Error Occured. Try Again",
                            "Package was NOT Added");
                    }
                }
            }
            //update package
            else
            {
                if (ValidatePackageDataInput())
                {
                    //edit package class
                    package.Name=txtName.Text;
                    package.Description=txtDescription.Text;
                    package.Base_Price=Convert.ToDecimal(txtPrice.Text);
                    package.Agency_Commission=Convert.ToDecimal(txtCommission.Text);
                    package.Start_Date=dtpStart.Value;
                    package.End_Date=dtpEnd.Value;

                    //update db
                    if (PackageDB.UpdatePackage(package))
                    {
                        //delete or add PackageProductSupplier Records
                        //get list of products and suppliers
                        List<int> list = new List<int>();
                        foreach (DataGridViewRow item in dgvProductSuppliers.Rows)
                        {
                            int prodSupID = Convert.ToInt32(item.Cells[0].Value);
                            list.Add(prodSupID);
                        }
                        //delete packageproductsupplier
                        if (PackageDB.DeletePackageProductSupplier(package.ID, list))
                        {
                            
                        }
                        //insert packageproductsupplier
                        foreach (int l in list)
                        {
                            PackageDB.AddPackageProductSupplier(package.ID, l);
                        }
                        MessageBox.Show("The Package was Added.",
                            "Package was Added");
                        Close();
                        
                    }
                    else
                    {
                        MessageBox.Show("Error occured when saving package");
                    }
                }
            }
        }
    }
}
