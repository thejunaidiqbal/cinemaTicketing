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
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Sign_Up(object sender, EventArgs e)
        {
           // Response.Redirect("WebForm1.aspx",true);
            myDAL objmyDAL = new myDAL();
            String name = TextBox1.Text;
            int ID = 0;
            Int32.TryParse(TextBox2.Text, out ID);
            string pw = txtPassword.Text;
            string Val = DropDownList2.SelectedValue;
            string t = Type.SelectedValue;
            string city = "0";
            if (Val == "1")
            {
                city = "Lahore";
            }
            else if (Val == "2")
            {
                city = "Islamabad";
            }
            else if (Val == "3")
            {
                city = "Karachi";
            }
            else if (Val == "4")
            {
                city = "Faisalabad";
            }
            else if (Val == "5")
            {
                city = "Multan";
            }

            int found = 0;
            found = objmyDAL.InsertUser(name, ID, pw, city, t);
            if (found == 0)
                Message1.Text = "There was some error! CNIC already exists!";
            else if (found == 1)
            {
                //Message1.Text = "Sign up succcessful!";
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
                Message1.Text = "Password should be atleast 4 characters long!";

        }
    }
}