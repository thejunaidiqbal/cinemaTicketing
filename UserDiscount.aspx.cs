using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;
using System.Data;

namespace DBProject
{
    public partial class UserDiscount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Generatediscounts(sender, e);
        }

        public void Generatediscounts(object sender, EventArgs e)   //drop down
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = null;
            string CinemaID = Session["CinemaID"].ToString();
            int Amount = (int)Session["Price"];
            objmyDAL.DiscountsForCinema(CinemaID,Amount,ref GetData);
            if (GetData.Rows.Count>0)
            {
                DropDownList1.DataSource = GetData;
                DropDownList1.DataTextField = "DiscountPrice";
                DropDownList1.DataValueField = "VoucherID";
                if (GetData.Rows.Count > 0)
                {
                    DropDownList1.DataBind();
                }
            }
            else
            {
                Session["CinemaID"] = CinemaID;
                Status.Text = "No discounts found ";
                Response.AddHeader("REFRESH", "2;payment.aspx");
            }
        }

        public void GetDiscountPrice(object sender, EventArgs e)  //price acc to drop down
        {
            myDAL objmyDAL = new myDAL();
            int VoucherID = 0;
            Int32.TryParse(DropDownList1.SelectedValue.ToString(),out VoucherID);
            int Price=objmyDAL.DiscountPrice(VoucherID);
            TextBox6.Text = Price.ToString();
        }
        public void Insert(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            int UserId=(int)Session["ID"];
            int Amount=(int)Session["Price"];
            int DiscountPrice=0;
            Int32.TryParse(TextBox6.Text.ToString(),out DiscountPrice);
            Amount = Amount - DiscountPrice;
            string CinemaID= Session["CinemaID"].ToString();
            int VoucherID=0;
            string ShowId = Session["ShowID"].ToString();
            int TicketsNo = (int)Session["Tickets"];
            Int32.TryParse(DropDownList1.SelectedValue.ToString(),out VoucherID);
            int found = objmyDAL.AddDiscountForOrder(VoucherID, ShowId, CinemaID, UserId);
            if(found==1)
            {
                //successful
                
                Status.Text = "Successfull booking";

                Response.AddHeader("REFRESH", "2;payment.aspx");
            }
            
        }
    }
}