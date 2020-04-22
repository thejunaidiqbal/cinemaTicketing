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
    public partial class AddCinemas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Add(object sender, EventArgs e)
        {
            myDAL objMyDal = new myDAL();
            int AdminID = (int)Session["ID"];
            string CinemaName = TextBox1.Text.ToString();
            string CinemaID = TextBox2.Text.ToString();
            string Location = TextBox3.Text.ToString();
            int Screens = 0;
            Int32.TryParse(TextBox4.Text, out Screens);
            string ContactNo = TextBox5.Text.ToString();
            int Rating = 0;
            Int32.TryParse(TextBox6.Text, out Rating);
            int AccountNo = 0;
            Int32.TryParse(TextBox7.Text, out AccountNo);
            string FoodAvailable = Food.SelectedValue.ToString();
            int found = objMyDal.AddNewCinemas(CinemaName,CinemaID,Location,Screens, ContactNo,Rating,
            FoodAvailable, AdminID,  AccountNo);
            if (found == 1)
            {
                Status.Text = "Added Successfully by ID";
                TextBox5.Text = found.ToString();
                Response.AddHeader("REFRESH", "2;AdminHome.aspx");
            }
            else if (found == 0)
            {
                Status.Text = "ID already exists";
            }
            
        }
    }
}