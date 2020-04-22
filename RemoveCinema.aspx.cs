using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;
using System.Data;

namespace DBProject
{
    public partial class RemoveCinema : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillCinemas(sender, e);
            }
        }

        //Fill
        protected void FillCinemas(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            int AdminID = (int)Session["ID"];
            objmyDAL.AdminCinemas(AdminID,ref GetData);
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

        //Remove
        protected void Remove(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            string CinemaID = DropDownList1.Text.ToString();
            objmyDAL.RemoveCinema(CinemaID);
            FillCinemas(sender, e);
        }

        //Done
        protected void Done(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx", true);
        }
    }
}