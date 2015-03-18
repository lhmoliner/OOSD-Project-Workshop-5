using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelExperts;

public partial class Login : System.Web.UI.Page
{

    Customer customer = new Customer();

    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        bool customerExists = false;
        string custEmail = Login1.UserName;
        string custPassword = Login1.Password;

        //get user's password and email to check with database
        customerExists = CustomerDB.CheckPassword(custEmail, custPassword);

        if (customerExists)
        {
            Session["user"] = CustomerDB.GetCustomerByEmail(custEmail);
            Session["userID"] = CustomerDB.GetCustomerByEmail(custEmail).CustomerID;
            Session["userName"] = CustomerDB.GetCustomerByEmail(custEmail).CustFirstName;

            Response.Redirect("Customer.aspx");//Redirecting user to main page after loggin
        }
        else
        {
            Login1.FailureText = "Invalid username or password.";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}