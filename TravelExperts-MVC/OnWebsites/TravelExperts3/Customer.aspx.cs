using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelExperts;

public partial class Customer : System.Web.UI.Page
{
    int custID;
    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        //if (Session["userID"] != null)
        //{
        //    custID = (int)Session["userID"];
        //    lblTotal.Text = PackageDB.GetSum(custID);
        //}
        //else
        //{
        Session["userID"] = 104;
        custID = Convert.ToInt32(Session["userID"]);
        lblTotal.Text = String.Format(": {0:C}", Convert.ToDecimal(PackageDB.GetSum(custID)));
        //Response.Redirect("Login.aspx");
        //    }
    }
    //save package product to session variable and goes to Package.aspx
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        Session["PackageID"] = row.Cells[4].Text;
        Response.Redirect("Package.aspx");
    }

    protected void DetailsView1_ModeChanged(object sender, EventArgs e)
    {
        // Display the current mode in the header row.
        switch (DetailsView1.CurrentMode)
        {
            case DetailsViewMode.Edit:
                {
                    GridView1.Enabled = false;
                }
                break;
            case DetailsViewMode.Insert:
                {
                    GridView1.Visible = false;
                    lblCustomerPackages.Visible = false;
                }
                break;
            default:
                {
                    GridView1.Enabled = true;
                    GridView1.Visible = true;
                    lblCustomerPackages.Visible = true;
                    Response.Redirect("~/Customer.aspx");
                }
                break;
        }
    }
    protected void DetailsView1_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
    {
        Response.Redirect("~/Customer.aspx");
    }
}