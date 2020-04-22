using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBProject
{
    public partial class AddRemoveFood : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void RedirectToAdminFood(object sender, EventArgs e)
        {
            Response.Redirect("AdminFood.aspx", true);
        }
        protected void RedirectToRemoveFood(object sender, EventArgs e)
        {

            Response.Redirect("RemoveFoodItem.aspx", true);
        }
    }
}