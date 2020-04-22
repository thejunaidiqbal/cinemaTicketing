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
    public partial class BookTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           string Temp=Movie.Text.ToString();
          if(Temp=="")
          {
             FillDropDownList();
             CinemasShowingMovie(sender, e);
             //CinemaDateTime(sender, e);
             //CinemaDateTimeScreen(sender, e);
             // CalculateTickets(sender, e);
        
          }
          
        }

        private void FillDropDownList()
        {
            //Search for movie name
            myDAL objmyDAL = new myDAL();
            string MovieID = Session["MovieID"].ToString();
            string MovieName = null;
            objmyDAL.MovieName(MovieID,ref MovieName);
            Movie.Text = MovieName;
            Movie.ReadOnly = true;
        }

        protected void CinemasShowingMovie(object sender, EventArgs e)
        {

            myDAL objmyDAL = new myDAL();
            string MovieID = Session["MovieID"].ToString();
                      DataTable GetData=new DataTable();
            objmyDAL.GetMovieCinemas(ref GetData,MovieID );
            DropDownList4.DataSource = GetData;
            DropDownList4.DataTextField = "CinemaName";
            DropDownList4.DataValueField = "CinemaID";
            if (GetData.Rows.Count > 0)
            {
                DropDownList4.DataBind();
                CinemaDateTime(sender, e);
            }
        }

        protected void CinemaDateTime(object sender, EventArgs e)
        {
            
            myDAL objmyDAL = new myDAL();
            string CinemaID = DropDownList4.SelectedValue.ToString();
            string MovieID = Session["MovieID"].ToString();
          
            DataTable GetData = new DataTable();
            objmyDAL.GetMovieCinemasTime(ref GetData, CinemaID,MovieID);
            DropDownList2.DataSource = GetData;
            DropDownList2.DataTextField = "ShowDT";
            DropDownList2.DataValueField = "ShowDT";
            if (GetData.Rows.Count > 0)
            {
                DropDownList2.DataBind();
                CinemaDateTimeScreen(sender, e);
            }
         }

        protected void CinemaDateTimeScreen(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            string CinemaID = DropDownList4.SelectedValue.ToString();
            string MovieID = Session["MovieID"].ToString();
            
            string TimeDate = Convert.ToDateTime(DropDownList2.SelectedItem.Text).ToString("yyyy-MM-dd hh:mm:ss tt");
            DataTable GetData = new DataTable();
            objmyDAL.GetMovieCinemasTimeScreen(ref GetData,CinemaID, MovieID, TimeDate);
            DropDownList5.DataSource = GetData;
            
            DropDownList5.DataTextField = "Screen";
            DropDownList5.DataValueField = "Screen";
            if (GetData.Rows.Count > 0)
            {
                DropDownList5.DataBind();
                CalculateTickets(sender, e);
            }
          
           
        }
        protected void CalculateTickets(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            string CinemaID = DropDownList4.SelectedValue.ToString();
            string MovieID = Session["MovieID"].ToString();
            string TimeDate = DropDownList2.SelectedValue.ToString();
            string Screen = DropDownList5.SelectedValue.ToString();
            string ShowId = null;
            objmyDAL.ReturnShowId(ref ShowId, CinemaID, MovieID, TimeDate, Screen);
            int found=objmyDAL.GetTickets(ShowId);
            TextBox6.Text = found.ToString();
            TextBox6.ReadOnly = true;
            found = objmyDAL.GetPrice(ShowId);
            TextBox1.Text = found.ToString();
            TextBox1.ReadOnly = true;
        }
       
        
        protected void Book(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            int UserId=(int) Session["ID"];
            string ShowId=null;
            int TicketsNo = 0;
            Int32.TryParse(TextBox5.Text, out TicketsNo);
            string CinemaID=DropDownList4.SelectedValue.ToString();
            Session["CinemaID"] = CinemaID;
            string MovieID = Session["MovieID"].ToString();
            string TimeDate=DropDownList2.SelectedValue.ToString();
            string Screen=DropDownList5.SelectedValue.ToString();
            objmyDAL.ReturnShowId(ref ShowId,CinemaID,MovieID,TimeDate,Screen);
            int TicketsAvaialable=objmyDAL.GetTickets(ShowId);
            if (TicketsAvaialable >=TicketsNo)
            {
                int Price = 0;
                Int32.TryParse(TextBox1.Text, out Price);
                Price = Price * TicketsNo;
                int found = objmyDAL.UserRecordInsert(UserId, ShowId, TicketsNo,Price);
                if (found == 1)
                {
                    Status.Text = "Booking Successful!";
                    Session["ShowID"] = ShowId;
                    Session["Tickets"] = TicketsNo;
                    Session["Price"] = Price;
                    Response.AddHeader("REFRESH", "2;FoodYesOrNo.aspx");
                }
                else
                {

                    Status.Text = "Booking UnSuccessful";
                }
               

                 }
            }
        }
        
    }