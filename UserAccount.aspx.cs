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
    public partial class UserAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                GetInfo(sender, e);
            }
        }
        protected void Refresh(object sender, EventArgs e)
        {
            TextBox1.Text = String.Empty;
            TextBox2.Text = String.Empty;
            TextBox1.ReadOnly = false;
            TextBox2.ReadOnly = false;
            DropDownList1.Enabled = true;
        }
        protected void GetInfo(object sender, EventArgs e)
        {
            TextBox1.ReadOnly = true;
            TextBox2.ReadOnly = true;
            DropDownList1.Enabled = false;
            myDAL objmydal=new myDAL();
            int ID = (int)Session["ID"];
            string Name="";
            string CityGet = "";
            int MoviesWatched=0;
            int MoneySpent=0;
            int found=objmydal.GetUserInfo(ID,ref Name,ref CityGet, ref MoviesWatched,ref MoneySpent);
            if (found == 1)
            {
                //changes made
                TextBox1.Text = Name;
                TextBox2.Text = ID.ToString();
                Label1.Text = MoviesWatched.ToString();
                Label2.Text = MoneySpent.ToString();
                if (CityGet == "Lahore")
                {
                    DropDownList1.SelectedValue = "1";
                }
                else if (CityGet == "Islamabad")
                {

                    DropDownList1.SelectedValue = "2";
                }
                else if (CityGet == "Karachi")
                {

                    DropDownList1.SelectedValue = "3";
                }
                else if (CityGet == "Faisalabad")
                {

                    DropDownList1.SelectedValue = "4";
                }
                else if (CityGet == "Multan")
                {

                    DropDownList1.SelectedValue = "5";
                }
            }
            else
            {
                //changes not made
            }
        }
        protected void EditInfo(object sender, EventArgs e)
        {

            myDAL objmydal = new myDAL();
            int ID = 0;
            int oldID = (int)Session["ID"];
            Int32.TryParse(TextBox2.Text, out ID);
            string Name = TextBox1.Text;
            string CityGet = DropDownList1.SelectedItem.Text;
            int found=objmydal.EditUserInfo(oldID,ID, Name,  CityGet);
            if (found == 1)
            {
                Session["ID"] = ID;
                CheckChange.Text = "Changes Successful";
                Response.AddHeader("REFRESH", "2;URL=UserHome.aspx");
            }
            else
            {
                CheckChange.Text = "Changes not made . Try again";
            }
        }

        protected void ChangeP(object sender, EventArgs e)
        {
            Response.Redirect("UserPassword.aspx", true);
        }
        protected void DelAcc(object sender, EventArgs e)
        {
            Response.Redirect("DeleteUserAccount.aspx", true);
        }
            
    }
}