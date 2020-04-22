using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DBProject.DAL;


namespace DBProject
{
    public partial class ViewUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowUsers(sender, e);
        }
        protected void ShowUsers(object sender, EventArgs e)
        {
            myDAL objmyDAl = new myDAL();
            DataTable DT = new DataTable();
            int found;
            found = objmyDAl.AllUsers(ref DT);
            if (found != 1)
            {
                Message.Text = "There was some error";
            }
            else
            {
                if (DT.Rows.Count > 0)
                {

                    Message.Text = "Following Users are found";
                    UsersGrid.DataSource = DT;
                    UsersGrid.DataBind();
                }
                else
                {

                    Message.Text = "No Users Found";
                }
            }

        }
    }
}