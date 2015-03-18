using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
{
    TravelExperts.Customer newCustomer;
    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblErrorMsg.Text = "";
        newCustomer = null;
        //validate

        if (EmailIsNotUsed(txtEmail.Text) &&
            PasswordMatches(txtPassword.Text, txtConfirmPassword.Text))
        {
            //create customer
            newCustomer = new TravelExperts.Customer();
            newCustomer.CustFirstName = txtFirstName.Text;
            newCustomer.CustLastName = txtLastName.Text;
            newCustomer.CustAddress = txtAddress.Text;
            newCustomer.CustCity = txtCity.Text;
            newCustomer.CustProv = ddlProvince.SelectedValue;
            newCustomer.CustPostal = txtPostalCode.Text;
            newCustomer.CustCountry = txtCountry.Text;
            newCustomer.CustHomePhone = txtHomePhone.Text;
            newCustomer.CustBusPhone = txtBusinessPhone.Text;
            newCustomer.CustEmail = txtEmail.Text;
            newCustomer.CustPassword = txtPassword.Text;

            //add customer to database
            if (TravelExperts.CustomerDB.AddCustomer(newCustomer) > 0)
            {
                //login then redirect to next page
                newCustomer = TravelExperts.CustomerDB.GetCustomerByEmail(newCustomer.CustEmail);
                Session["user"] = newCustomer;
                Session["userName"] = newCustomer.CustFirstName + " " + newCustomer.CustLastName;
                Session["userID"] = newCustomer.CustomerID;

                Response.Redirect("Customer.aspx");//Redirecting user to main page after loggin
            }
            else //customer wasnt added to db
            { 

            }
        }
        else
        {
            lblErrorMsg.Text = "The email is already used by another customer";
        }
    }
    protected bool EmailIsNotUsed(string email)
    {
        if (TravelExperts.CustomerDB.GetCustomerByEmail(email) == null)
        {
            return true;
        }
        return false;
    }
    protected bool PasswordMatches(string pw1, string pw2){
        if(pw1 == pw2){
            return true;
        }
        return false;
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clearTextBoxes();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //cancel
        //redirect to a page
        Response.Redirect("Main.aspx");
    }
    private void clearTextBoxes()
    {
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtAddress.Text = "";
        txtCity.Text = "";
        ddlProvince.SelectedIndex = 0;
        txtPostalCode.Text = "";
        txtCountry.Text = "";
        txtHomePhone.Text = "";
        txtBusinessPhone.Text = "";
        txtEmail.Text = "";
        txtPassword.Text = "";
        txtConfirmPassword.Text = "";

        lblErrorMsg.Text = "";
    }
}