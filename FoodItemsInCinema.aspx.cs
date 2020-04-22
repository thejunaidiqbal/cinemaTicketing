using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;
using System.Data;

namespace DBProject
{
    public partial class FoodItemsInCinema : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string temp = DropDownList1.Text.ToString();
            if (temp == "")
            {
                FillDropDown(sender, e);
                AdminFoodItems(sender, e);
            }
        }
        protected void FillDropDown(object sender, EventArgs e)
        {
            myDAL objmyDal = new myDAL();
            DataTable GetData = new DataTable();
            int AdminID = (int)Session["ID"];
            objmyDal.ViewAdminCinemas(AdminID, ref  GetData);
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
            DataTable result = new DataTable();
            string CinemaID = DropDownList1.Text.ToString();
            int found = objmyDal.FoodItemsAvailable(CinemaID, ref result);
            DropDownList2.DataSource = result;
            DropDownList2.DataTextField = "ItemID";
            DropDownList2.DataValueField = "ItemID";
            DropDownList2.DataBind();
            if (result.Rows.Count > 0)
            {
                ItemDetails(sender, e);
            }
        }
        protected void ItemDetails(object sender, EventArgs e)
        {
            myDAL objmyDal = new myDAL();
            DataTable result = new DataTable();
            int ItemID = 0;
            Int32.TryParse(DropDownList2.Text.ToString(),out ItemID);
            string Name = null;
            int Price = 0;
            int found = objmyDal.GetFoodDetails(ItemID, ref Name, ref Price);
            TextBox1.Text = Name;
            TextBox2.Text = Price.ToString();
        }
        protected void AdminFoodItems(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            int AdminID = (int)Session["ID"];
            objmyDAL.AdminFoods(AdminID, ref GetData);
            //GetData.Columns.Add("Cinema", typeof(string), "VoucherID + '    ' + DiscountPrice + '   ' + MinPrice");
            DropDownList3.DataSource = GetData;
            DropDownList3.DataTextField = "ItemID";
            DropDownList3.DataValueField = "ItemID";
            
            if (GetData.Rows.Count > 0)
            {
                DropDownList3.DataBind();
                GetFoodDetail(sender, e);
            }

        }

        protected void GetFoodDetail(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            int AdminID = (int)Session["ID"];
            int ItemID = 0;
            Int32.TryParse(DropDownList3.SelectedValue.ToString(), out ItemID);
            string Name = null;
            int Price = 0;
            objmyDAL.GetFoodDetails(ItemID, ref Name, ref Price);
            TextBox3.Text = Name;
            TextBox4.Text = Price.ToString();

        }
        protected void Add(object sender, EventArgs e)
        {
            //add dropdownlist3 value in CinemasFoods
             myDAL objmyDAL = new myDAL();
             string CinemaID = DropDownList1.Text.ToString();
             int ItemID = 0;
            Int32.TryParse(DropDownList3.Text.ToString(),out ItemID);
             objmyDAL.AddCinemaFoods(CinemaID, ItemID);
             FillDropDown(sender, e);
        }
        protected void Remove(object sender, EventArgs e)
        {
            //Remove dropdownlist2 value in CinemasFoods
                myDAL objmyDAL = new myDAL();
             string CinemaID = DropDownList1.Text.ToString();
             int ItemID = 0;
            Int32.TryParse(DropDownList2.Text.ToString(),out ItemID);
             objmyDAL.RemoveCinemaFoods(CinemaID, ItemID);
             TextBox1.Text = String.Empty;
             TextBox2.Text = String.Empty;
             FillDropDown(sender, e);
        }
        protected void Done(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx",true);
        }
    }
}