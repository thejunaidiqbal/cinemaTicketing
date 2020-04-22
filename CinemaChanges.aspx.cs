using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DBProject.DAL;

namespace DBProject
{
    public partial class CinemaChanges : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void FoodItems(object sender, EventArgs e)
        {
            Response.Redirect("FoodItemsInCinema.aspx", true);
        }
        protected void Discounts(object sender, EventArgs e)
        {

            Response.Redirect("DiscountsInCinema.aspx", true);
        }

        protected void Screens(object sender, EventArgs e)
        {

            Response.Redirect("ScreensInCinema.aspx", true);
        }
    }
}