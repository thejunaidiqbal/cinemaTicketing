using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBProject
{
    public partial class AddRemoveCinema : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void RedirectToAdminCinema(object sender, EventArgs e)
        {
            Response.Redirect("AddCinemas.aspx", true);
        }
        protected void RedirectToRemoveCinema(object sender, EventArgs e)
        {

            Response.Redirect("RemoveCinema.aspx", true);
        }
    }
}