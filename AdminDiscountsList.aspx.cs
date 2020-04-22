using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;
using System.Data;

namespace DBProject
{
    public partial class AdminDiscountsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillDiscounts(sender, e);
        }
        protected void FillDiscounts(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            int AdminID = (int)Session["ID"];
            objmyDAL.AdminDiscountsList(ref GetData, AdminID);
            //GetData.Columns.Add("Cinema", typeof(string), "VoucherID + '    ' + DiscountPrice + '   ' + MinPrice");
            DiscountsGrid.DataSource = GetData;
            if (GetData.Rows.Count > 0)
            {
                DiscountsGrid.DataBind();
            }
        }

    }
}