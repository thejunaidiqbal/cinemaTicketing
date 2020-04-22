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
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Sign_In(object sender, EventArgs e)
        {
            //Response.Redirect("WebForm1.aspx", true);
            myDAL objmyDAL = new myDAL();

            int ID = 0;
            Int32.TryParse(TextBox1.Text, out ID);
            string pw = txtPassword.Text;
            string t = DropDownList1.SelectedValue;
            int found = 0;
            found = objmyDAL.SearchUser(ID, pw, t);
            if (found == 0)
                Message1.Text = "There was some error!";
            else if (found == 1)
            {
                //Message1.Text = "Log in succcessful!";
                Session["ID"] = ID;
                Session["Type"] = t;
                if (t == "U")
                {
                    Response.Redirect("UserHome.aspx", true);
                }
                else if (t == "A")
                {
                    Response.Redirect("AdminHome.aspx", true);
                }

            }
            else if (found == -1)
                Message1.Text = "Incorrect CNIC/ password. Please sign up incase of no account!";
        }


    }
}