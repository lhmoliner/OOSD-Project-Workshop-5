/* CPRG214 ASP Workshop 2
 * Created By: Leisy, and MB
 * January 22, 2015
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.Page
{
    int custID;
    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        custID = ddlCustomers.SelectedIndex;
    }
    //save package product to session variable and goes to Package.aspx
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        Session["PackageID"] = row.Cells[1].Text;
        Response.Redirect("Package.aspx");
    }

    protected void DetailsView1_ModeChanged(object sender, EventArgs e)
    {
        // Display the current mode in the header row.
        switch (DetailsView1.CurrentMode)
        {
            case DetailsViewMode.Edit:
                {
                    ddlCustomers.Enabled = false;
                    GridView1.Enabled = false;
                }
                break;
            case DetailsViewMode.Insert:
                {
                    ddlCustomers.Visible = false;
                    GridView1.Visible = false;
                    lblSelectCustomer.Visible = false;
                    lblCustomerPackages.Visible = false;
                }
                break;
            default:
                {
                    ddlCustomers.Enabled = true;
                    GridView1.Enabled = true;
                    ddlCustomers.Visible = true;
                    GridView1.Visible = true;
                    lblSelectCustomer.Visible = true;
                    lblCustomerPackages.Visible = true;
                    Response.Redirect("~/Main.aspx");
                }
                break;
        }
    }
    protected void DetailsView1_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
    {
        Response.Redirect("~/Main.aspx");
    }
}
