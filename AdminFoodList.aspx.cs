using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DBProject.DAL;

namespace DBProject
{
    public partial class AdminFoodList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillFoodItems(sender, e);
        }
        protected void FillFoodItems(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            int AdminID = (int)Session["ID"];
            objmyDAL.AdminFoodsList(AdminID, ref GetData);
            
            FoodGrid.DataSource = GetData;
            if (GetData.Rows.Count > 0)
            {
                FoodGrid.DataBind();
            }

        }
    }
}