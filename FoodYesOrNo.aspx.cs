using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBProject
{
    public partial class FoodYesOrNo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RedirectToPlaceFoodOrder(object sender, EventArgs e)
        {
            Response.Redirect("PlaceFoodOrder.aspx",true);
        }
        protected void RedirectToPayment(object sender, EventArgs e)
        {

            Response.Redirect("UserDiscount.aspx", true);
        }
    }
}