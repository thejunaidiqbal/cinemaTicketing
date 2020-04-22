using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DBProject.DAL;

namespace DBProject
{
    public partial class ScreensInCinema : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cinemas(sender, e);
        }
       
        
        //Cinemas
        protected void Cinemas(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            int AdminID = (int)Session["ID"];
            objmyDAL.AdminCinemas(AdminID, ref GetData);
            if (GetData.Rows.Count > 0)
            {
                GetData.Columns.Add("Cinema", typeof(string), "CinemaID + '    ' + CinemaName + '   ' + Locations");
                DropDownList1.DataSource = GetData;
                DropDownList1.DataTextField = "Cinema";
                DropDownList1.DataValueField = "CinemaID";
                if (GetData.Rows.Count > 0)
                {
                    DropDownList1.DataBind();
                }
            }

        }

        //public int AddCinemaScreens(string CinemaID, string Screen, int Price, int TotalSeats)
        protected void AddScreen(object sender,EventArgs e)
        {
            myDAL objMyDal = new myDAL();
            string CinemaID = DropDownList1.Text.ToString();
            string Screen = TextBox1.Text.ToString();
            int Price = 0;
            Int32.TryParse(TextBox2.Text.ToString(),out Price);
            int TotalSeats = 0;
            Int32.TryParse(TextBox3.Text.ToString(), out TotalSeats);
            int found = objMyDal.AddCinemaScreens(CinemaID, Screen, Price, TotalSeats);
            if(found==0)
            {
                Status.Text = "Error! Try Again";
            }
            else if(found==-1)
            {
                Status.Text = "Error! Screen Already Exists";

            }
            else
            {
                Status.Text = "Screen Added";
            }
            
        }

    }
}