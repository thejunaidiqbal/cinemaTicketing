using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;
using System.Data;


namespace DBProject
{
    public partial class Rating : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Temp = DropDownList1.SelectedValue.ToString();
            if (Temp == "")
            {
                GetCinemas(sender,e);
                //GetMovies(sender, e);
            }
        }
        public void GetCinemas(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            objmyDAL.GetAllCinemas(ref GetData);
            GetData.Columns.Add("Cinema",typeof(string),"CinemaName + '  ' + Locations");
            DropDownList1.DataSource = GetData;
            DropDownList1.DataTextField = "Cinema";
            DropDownList1.DataValueField = "CinemaID";
            if (GetData.Rows.Count > 0)
            {
                DropDownList1.DataBind();
            }
            
        }

        

        /*public void GetMovies(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            string CinemaID = DropDownList1.SelectedValue.ToString();
            objmyDAL.GetMovieData( ref GetData);
            DropDownList3.DataSource = GetData;
            DropDownList3.DataTextField = "MovieName";
            DropDownList3.DataValueField = "MovieID";
            DropDownList3.DataBind();
        }*/
        public void RateCinema(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            int Rating = 0;
            Rating=DropDownList3.SelectedIndex;
            string CinemaID = DropDownList1.SelectedValue.ToString();
            int found=objmyDAL.AddCinemaRatings(Rating, CinemaID);
            if(found==1)
            {
                Status.Text = "Rating Added Successfully";
            }
            else if( found==0)
            {

                Status.Text = "Rating Not Added . Try Again";
            }
        }
       
    }
}