using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DBProject.DAL;
using System.Data;

namespace DBProject
{
    public partial class AddShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              string Temp=DropDownList1.SelectedValue.ToString();
          if(Temp=="")
          {
              PopDownMovies(sender,e);
              AdminCinemas(sender, e);
              
          }
        }
        protected void PopDownMovies(object sender, EventArgs e)
        {
            myDAL objMyDal = new myDAL();
            DataTable GetData = new DataTable();
            int AdminID = (int)Session["ID"];
            objMyDal.AdminMovies(AdminID,ref GetData);
            DropDownList1.DataSource = GetData;
            DropDownList1.DataTextField = "MovieName";
            DropDownList1.DataValueField = "MovieID";
            if (GetData.Rows.Count > 0)
            {
                DropDownList1.DataBind();
            }
        }

        protected void AdminCinemas(object sender, EventArgs e)
        {
            myDAL objMyDal = new myDAL();
            DataTable GetData = new DataTable();
            int AdminID = (int)Session["ID"];
            objMyDal.AdminCinemas(AdminID, ref GetData);
            DropDownList2.DataSource = GetData;
            DropDownList2.DataTextField = "CinemaName";
            DropDownList2.DataValueField = "CinemaID";
            if (GetData.Rows.Count > 0)
            {
                DropDownList2.DataBind();
                CinemaScreens(sender, e);
           
            }
            
           
        }

        protected void CinemaScreens(object sender, EventArgs e)
        {
            myDAL objMyDal = new myDAL();
            DataTable GetData = new DataTable();
            string CinemaID = DropDownList2.Text.ToString(); 
            objMyDal.CinemaScreens(CinemaID, ref GetData);
            DropDownList3.DataSource = GetData;
            DropDownList3.DataTextField = "Screen";
            DropDownList3.DataValueField = "Screen";
            if (GetData.Rows.Count > 0)
            {
                DropDownList3.DataBind();
            }
        }

        protected void  CheckAvailableScreens(object sender, EventArgs e)
        {
            if (TextBox2.Text != String.Empty)
            {
                myDAL objMyDal = new myDAL();
                DataTable GetData = new DataTable();
                int AdminID = (int)Session["ID"];
                string TimeDate = TextBox2.Text.ToString();
                string CinemaID = DropDownList2.SelectedValue.ToString();
                string Screen = DropDownList3.Text.ToString();
                int found=objMyDal.CheckAvailableScreens(CinemaID, TimeDate,Screen);  //return if selected screen is available on that day from Showtimes;
                if(found==0)
                {
                    Status.Text = "Screen Not Available";
                }
                
                
            }
            
        }

        //AddShowtime(string ShowID,string CinemaID,string MovieID, string Screen, string TimeDate)
        
        protected void AddShowtime(object sender, EventArgs e)
        {
            myDAL objMyDal = new myDAL();
            //string TimeDate = DateTime.ParseExact(TextBox2.Text.ToString(), "yyyy-MM-dd hh:mm:ss", null).ToString();

            DateTime date = Convert.ToDateTime(TextBox2.Text.ToString(), System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);
            string TimeDate = date.ToString("yyyy-MM-dd");
            string CinemaID = DropDownList2.SelectedValue.ToString();
            string Screen = DropDownList3.Text.ToString();
            string ShowID = TextBox1.Text.ToString();
            string MovieID = DropDownList1.Text.ToString();
            objMyDal.AddShowtime(ShowID, CinemaID, MovieID, Screen, TimeDate);

        }
// admin Movies List admin Cinemas List respective screens of that cinema and also status='pending' and 'FilledSeats'==0 initially
    }
}