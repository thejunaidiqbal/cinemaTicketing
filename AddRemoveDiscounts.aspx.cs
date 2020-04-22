using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBProject
{
    public partial class AddRemoveDiscounts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void RedirectToAdminDiscount(object sender, EventArgs e)
        {
            Response.Redirect("AdminDiscounts.aspx", true);
        }
        protected void RedirectToRemoveDiscount(object sender, EventArgs e)
        {

            Response.Redirect("RemoveDiscount.aspx", true);
        }
    }
}