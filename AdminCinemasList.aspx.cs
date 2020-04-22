using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DBProject.DAL;

namespace DBProject
{
    public partial class AdminCinemasList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillCinemas(sender, e);
        }
        protected void FillCinemas(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            int AdminID = (int)Session["ID"];
            objmyDAL.AdminCinemas(AdminID, ref GetData);
            GetData.Columns.Add("Cinema", typeof(string), "CinemaID + '    ' + CinemaName + '   ' + Locations");
            CinemaGrid.DataSource = GetData;
            if (GetData.Rows.Count > 0)
            {
                CinemaGrid.DataBind();
            }
        }
    }
}