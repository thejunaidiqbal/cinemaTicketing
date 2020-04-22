using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;
using System.Data;

namespace DBProject
{
    public partial class Lists : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Food(object sender, EventArgs e)
        {
            Response.Redirect("AdminFoodList.aspx", true);
        }
        protected void Revenues(object sender, EventArgs e)
        {
            Response.Redirect("ViewRevenue.aspx", true);
        }
        protected void Users(object sender, EventArgs e)
        {
            Response.Redirect("ViewUsers.aspx", true);
        }
        protected void Discounts(object sender, EventArgs e)
        {

            Response.Redirect("AdminDiscountsList.aspx", true);
        }
        protected void Cinemas(object sender, EventArgs e)
        {

            Response.Redirect("AdminCinemasList.aspx", true);
        }
        protected void Shows(object sender, EventArgs e)
        {

            Response.Redirect("AdminShowsList.aspx", true);
        }
    }
}