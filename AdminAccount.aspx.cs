using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;
using System.Data;
namespace DBProject
{
    public partial class AdminAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                GetAInfo(sender, e);
            }
        }
        protected void Refresh(object sender, EventArgs e)
        {
            TextBox1.Text = String.Empty;
            TextBox2.Text = String.Empty;
            TextBox1.ReadOnly = false;
            TextBox2.ReadOnly = false;
                    }
        protected void GetAInfo(object sender, EventArgs e)
        {
            TextBox1.ReadOnly = true;
            TextBox2.ReadOnly = true;
            myDAL objmydal = new myDAL();
            int ID = (int)Session["ID"];
            string Name = "";
            int found = objmydal.GetAdminInfo(ID, ref Name);
            if (found == 1)
            {
                //changes made
                TextBox1.Text = Name;
                TextBox2.Text = ID.ToString();
             
            }
            else
            {
                //changes not made
            }
        }
        protected void EditAInfo(object sender, EventArgs e)
        {

            myDAL objmydal = new myDAL();
            int ID = 0;
            int oldID = (int)Session["ID"];
            Int32.TryParse(TextBox2.Text, out ID);
            string Name = TextBox1.Text;
            int found = objmydal.EditAdminInfo(oldID, ID, Name);
            if (found == 1)
            {
                Session["ID"] = ID;
                CheckChange.Text = "Changes Successful";
                Response.AddHeader("REFRESH", "2;URL=AdminHome.aspx");
            }
            else
            {
                CheckChange.Text = "Changes not made . Try again";
            }
        }

        protected void ChangeP(object sender, EventArgs e)
        {
            Response.Redirect("AdminPassword.aspx", true);   //admin password
        }
        
    }
}