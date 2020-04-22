using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;
using System.Data;

namespace DBProject
{
    public partial class DeleteUserAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DelAcc(object sender, EventArgs e)
        {
            myDAL objmydal = new myDAL();
            int ID = (int)Session["ID"];
            string type = "U";
            int found = objmydal.DeleteAnyAccount(ID, type);
            if (found == 1)
            {
                Status.Text = "Account Deleted";
                Response.AddHeader("REFRESH", "2;URL=Home.aspx");
            }
            else if (found == 0)
            {

                Status.Text = "Account Not Deleted. Try again";
                Response.AddHeader("REFRESH", "3;URL=UserAccount.aspx");
            }
        }
        protected void NotDelAcc(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx", true);
        }
    }
}