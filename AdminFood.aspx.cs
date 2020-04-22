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
    public partial class AdminFood : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //AddCinemaFoods(int AdminID, string ItemName, int ItemId, int Price)
        protected void Add(object sender, EventArgs e)
        {
            myDAL objMyDal = new myDAL();
            int AdminID = (int)Session["ID"];
            string ItemName=TextBox1.Text.ToString();
            int ItemId = 0;
            Int32.TryParse(TextBox2.Text, out ItemId);
            int Price = 0;
            Int32.TryParse(TextBox3.Text, out Price);
            int found = objMyDal.AddFoods(AdminID, ItemName, ItemId, Price);
            if (found == ItemId)
            {
                Status.Text = "Added Successfully by ID";
                TextBox5.Text = found.ToString();
                Response.AddHeader("REFRESH", "2;AdminHome.aspx");
            }
            else if (found == 0)
            {
                Status.Text = "ID already exists";
            }
            else if (found != ItemId)
            {
                Status.Text = "Item Offer Already Exists by ID";
                TextBox5.Text = found.ToString();
                Response.AddHeader("REFRESH", "2;AdminHome.aspx");
            }
        }
       
    }
}