using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;
using System.Data;


namespace DBProject
{
    public partial class AdminShowsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminShows(sender, e);
        }
        protected void AdminShows(object sender, EventArgs e)
        {
            myDAL objmyDAl = new myDAL();
            DataTable DT = new DataTable();
            int found;
            int AdminID = (int)Session["ID"];
            found = objmyDAl.AdminShows(AdminID,ref DT);
            if (found != 1)
            {
                Message.Text = "There was some error!";
            }
            else
            {
                ShowsGrid.DataSource = DT;
                if (DT.Rows.Count > 0)
                {

                    Message.Text = "Following Shows are found:";
                    ShowsGrid.DataBind();
                }
            }

        }
    }
}