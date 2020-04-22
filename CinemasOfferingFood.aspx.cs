using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DBProject.DAL;

namespace DBProject
{
    public partial class CinemasOfferingFood : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //fill drop down
            string Temp = DropDownList1.SelectedValue.ToString();
            if (Temp == "")
            {
                FillDropDown(sender, e);
            }
        }

        protected void FillDropDown(object sender, EventArgs e)
        {
            myDAL objmyDal = new myDAL();
            DataTable GetData = new DataTable();
            objmyDal.GetAllCinemas(ref GetData);
            DropDownList1.DataSource = GetData;
            GetData.Columns.Add("Cinema", typeof(string), "CinemaName + '  ' + Locations");
            DropDownList1.DataTextField = "Cinema";
            DropDownList1.DataValueField = "CinemaID";
            if (GetData.Rows.Count > 0)
            {
                DropDownList1.DataBind();
                ListItems(sender, e);
            }

        }
        protected void ListItems(object sender, EventArgs e)
        {
            myDAL objmyDal = new myDAL();
            DataTable GetData = new DataTable();
            string CinemaID = DropDownList1.Text.ToString();
            int found= objmyDal.FoodItemsAvailable(CinemaID, ref GetData);
            if (found != 1)
            {
                Message.Text = "There was some error!";
            }
            else
            {
                Message.Text = "Following items are found:";
                CinemaGrid.DataSource = GetData;
                if (GetData.Rows.Count > 0)
                {
                    CinemaGrid.DataBind();
                }
            }
        }
    }
}