using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DBProject.DAL;

namespace DBProject
{
    public partial class Cinemas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowCinemas(sender, e);
        }
        protected void ShowCinemas(object sender, EventArgs e)
        {
            myDAL objmyDAl = new myDAL();
            DataTable DT = new DataTable();
            int found;
            found = objmyDAl.AllCinemas(ref DT);
            if (found != 1)
            {
                Message.Text = "There was some error!";
            }
            else
            {
                Message.Text = "Following cinemas are found:";
                CinemaGrid.DataSource = DT;
                if (DT.Rows.Count > 0)
                {
                    CinemaGrid.DataBind();
                }
            }

        }
    }
}