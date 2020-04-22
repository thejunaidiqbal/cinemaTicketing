using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;
using System.Data;

namespace DBProject
{
    public partial class MovieShowtimes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string Temp = DropDownList1.SelectedValue.ToString();
            if (Temp == "")
            {
                FillDropDownList();
               
            }

        }

        private void FillDropDownList()
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            objmyDAL.GetMovieData(ref GetData);
            DropDownList1.DataSource = GetData;
            DropDownList1.DataTextField = "MovieName";
            DropDownList1.DataValueField = "MovieID";
            if (GetData.Rows.Count > 0)
            {
                DropDownList1.DataBind();
            }
        }
        public void FindShows(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            string MovieID = DropDownList1.Text.ToString();
             DataTable GetData = new DataTable();
             int found=objmyDAL.ViewMovieShows(MovieID,ref GetData);
             if (found != 1)
             {
                 Message.Text = "There was some error!";
             }
             else
             {
              
                 ShowsGrid.DataSource = GetData;
                 if (GetData.Rows.Count > 0)
                 {
                     Message.Text = "Following shows are found:";
                     ShowsGrid.DataBind();
                 }
                 else
                 {
                     Message.Text = "No shows found:";
                 }
             }
        }
    }
}