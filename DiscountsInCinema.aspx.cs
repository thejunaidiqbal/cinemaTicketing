using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DBProject.DAL;

namespace DBProject
{
    public partial class DiscountsInCinema : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //fill drop down
            string Temp = DropDownList1.SelectedValue.ToString();
            if (Temp == "")
            {
                FillDropDown(sender, e);
                AdminDiscounts(sender, e);
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
                ListDiscounts(sender, e);
            }
        }

        //DiscountsByCinema
        protected void ListDiscounts(object sender, EventArgs e)
        {
            myDAL objmyDal = new myDAL();
            DataTable result = new DataTable();
            string CinemaID = DropDownList1.Text.ToString();
            int found = objmyDal.DiscountsByCinema(CinemaID, ref result);
            DropDownList2.DataTextField = "VoucherID";
            DropDownList2.DataValueField = "VoucherID";
            DropDownList2.DataBind();
            if (result.Rows.Count > 0)
            {
                GetDiscountDetail(sender, e);
            }
        }
        protected void GetDiscountDetail(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            int AdminID = (int)Session["ID"];
            int VoucherID = 0;
            Int32.TryParse(DropDownList2.SelectedValue.ToString(), out VoucherID);
            int DiscountPrice = 0;
            int MinAmount = 0;
            int MaxAmount = 0;
            objmyDAL.GetDiscountDetails(VoucherID, ref DiscountPrice, ref MinAmount, ref MaxAmount);
            TextBox1.Text = DiscountPrice.ToString();
            TextBox2.Text = MinAmount.ToString();
            TextBox3.Text = MaxAmount.ToString();

        }
        protected void AdminDiscounts(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            int AdminID = (int)Session["ID"];
            objmyDAL.GetDiscountData(ref GetData, AdminID);
            DropDownList3.DataSource = GetData;
            DropDownList3.DataTextField = "VoucherID";
            DropDownList3.DataValueField = "VoucherID";
            if (GetData.Rows.Count > 0)
            {
                DropDownList3.DataBind();
                AdminDiscountDetail(sender, e);
            }

        }

        protected void AdminDiscountDetail(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            int AdminID = (int)Session["ID"];
            int VoucherID = 0;
            Int32.TryParse(DropDownList3.SelectedValue.ToString(), out VoucherID);
            int DiscountPrice = 0;
            int MinAmount = 0;
            int MaxAmount = 0;
            objmyDAL.GetDiscountDetails(VoucherID, ref DiscountPrice, ref MinAmount, ref MaxAmount);
            TextBox4.Text = DiscountPrice.ToString();
            TextBox5.Text = MinAmount.ToString();
            TextBox6.Text = MaxAmount.ToString();

        }
        
        protected void Add(object sender, EventArgs e)
        {
            //drop down list 3 add
              myDAL objmyDAL = new myDAL();
            int VoucherID = 0;
            Int32.TryParse(DropDownList3.SelectedValue.ToString(), out VoucherID);
            string CinemaID=DropDownList1.Text.ToString();
            objmyDAL.AddDiscountForCinema(VoucherID, CinemaID);
        }

        protected void Remove(object sender, EventArgs e)
        {
            //drop down list 2 remove
            myDAL objmyDAL = new myDAL();
            int VoucherID = 0;
            Int32.TryParse(DropDownList2.SelectedValue.ToString(), out VoucherID);
            string CinemaID = DropDownList1.Text.ToString();
            objmyDAL.DeleteDiscountFromCinema(VoucherID, CinemaID);
        }

        protected void Done(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx", true);
        }

    }
}