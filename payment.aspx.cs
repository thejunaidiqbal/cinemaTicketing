using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using DBProject.DAL;

namespace DBProject
{
    public partial class payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Pay(object sender, EventArgs e)
        {
            myDAL objMyDal=new myDAL();
            string CinemaID=Session["CinemaID"].ToString();
            string CardNumber=TextBox1.Text.ToString();
            int TotalMoney=(int)Session["Price"];
            int UserID = (int)Session["ID"];
            int found=objMyDal.AskForPaymentMethod(CinemaID, CardNumber, TotalMoney, UserID);
            if (found == 1)
            {
                Status.Text = "Payment Successfull";
                Response.AddHeader("REFRESH", "2;UserHome.aspx");
            }
        }

    }
}