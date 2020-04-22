using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;
using System.Data;
using System.Text;


namespace DBProject
{
    public partial class WatchHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowUsers(sender, e);
        }
        protected void ShowUsers(object sender, EventArgs e)
        {
            myDAL objmyDAl = new myDAL();
            DataTable DT = new DataTable();
            int UserId=(int)Session["ID"];
            int found=0;
            found = objmyDAl.ViewWatchHistory(UserId, ref DT);
            if (found != 1)
            {
                Message.Text = "There was some error!";
            }
            else
            {
                if (DT.Rows.Count > 0)
                {

                    Message.Text = "Your Record!!!";
                    WatchGrid.DataSource = DT;
                    WatchGrid.DataBind();
                }
                else
                {

                    Message.Text = "No Record Found!!!";
                }
            }

        }
    }
}