using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;
using System.Data;

namespace DBProject
{
    public partial class RemoveDiscount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Temp=DropDownList1.SelectedValue.ToString();
            if(Temp=="")
            {
                FillDiscounts(sender, e);
            }
        }
        protected void FillDiscounts(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            int AdminID = (int)Session["ID"];
            objmyDAL.GetDiscountData(ref GetData,AdminID);
            //GetData.Columns.Add("Cinema", typeof(string), "VoucherID + '    ' + DiscountPrice + '   ' + MinPrice");
            DropDownList1.DataSource = GetData;
            DropDownList1.DataTextField = "VoucherID";
            DropDownList1.DataValueField = "VoucherID";
            
            if (GetData.Rows.Count > 0)
            {
                DropDownList1.DataBind();
                GetDiscountDetail(sender, e);
            }

        }

        protected void GetDiscountDetail(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            int AdminID = (int)Session["ID"];
            int VoucherID = 0;
            Int32.TryParse(DropDownList1.SelectedValue.ToString(),out VoucherID);
            int DiscountPrice = 0;
            int MinAmount = 0;
            int MaxAmount = 0;
            objmyDAL.GetDiscountDetails(VoucherID,ref DiscountPrice,ref MinAmount,ref MaxAmount);
            TextBox1.Text = DiscountPrice.ToString();
            TextBox2.Text = MinAmount.ToString();
            TextBox3.Text = MaxAmount.ToString();

        }
        //Remove
        protected void Remove(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            string CinemaID = DropDownList1.Text.ToString();
            objmyDAL.RemoveCinema(CinemaID);
            Status.Text = "Removed Successfully";
            TextBox1.Text = String.Empty;
            TextBox2.Text = String.Empty;
            TextBox3.Text = String.Empty;
            FillDiscounts(sender, e);
        }

        //Done
        protected void Done(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx", true);
        }
    }
}