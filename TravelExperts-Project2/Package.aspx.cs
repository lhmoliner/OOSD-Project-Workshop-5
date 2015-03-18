/* CPRG214 ASP Workshop 2
 * Created By: John, Leisy, and MB
 * January 22, 2015
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Package : System.Web.UI.Page
{
    string pkgID="default";
    //pass the package id from session variable to local variable and chooses image to be displayed
    protected void Page_Load(object sender, EventArgs e)
    {
        
        pkgID = (string)Session["PackageID"];
        Image.ImageUrl = "/Images/package" + pkgID + ".jpg";
    }
}