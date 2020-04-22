using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;
using System.Data;

namespace DBProject
{
    public partial class UserPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
       
        protected void ChangePassword(object sender, EventArgs e)
        {
            myDAL objMyDal = new myDAL();
            int ID = (int)Session["ID"];
            string oldpassword = txtPasswordOld.Text.ToString();
            string newpassword = txtPasswordNew.Text.ToString();
            int found=objMyDal.ChangePassword(ID, oldpassword, newpassword);
            if (found == 1)
            {
                CheckChange.Visible = true;
                CheckChange.Text = "Password changed";
                Response.AddHeader("REFRESH", "1;URL=UserHome.aspx");
                
            }
            else if(found==0)
            {
                CheckChange.Text = "Incorrect New Password .Try Entering Again";
            }
        }
    }
}