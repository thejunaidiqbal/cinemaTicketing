using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;
using System.Data;
using System.Text;


namespace DBProject
{
    public partial class ViewRevenue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RevenueGenerate(sender,e);
        }
        public void RevenueGenerate(object sender, EventArgs e)
        {
            int AdminID = (int)Session["ID"];
            myDAL objmyDAl = new myDAL();
            DataTable DT = new DataTable();
            int found;
            found = objmyDAl.GenerateRevenue(AdminID,ref DT);
            if (found != 1)
            {
                Message.Text = "There was some error!";
            }
            else
            {
                
                if (DT.Rows.Count > 0)
                {
                    Message.Text = "Following results are found:";
                    RevenueGrid.DataSource = DT;
                    RevenueGrid.DataBind();
                }
                else
                {
                    Message.Text = "No results found:";
                }
            }

        }
    }
}