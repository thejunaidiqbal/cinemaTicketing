using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;
using System.Data;


namespace DBProject
{
    public partial class RemoveFoodItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Temp = DropDownList1.SelectedValue.ToString();
            if(Temp=="")
            {
                FillFoodItems(sender, e);
            }
        }
        protected void FillFoodItems(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            int AdminID = (int)Session["ID"];
            objmyDAL.AdminFoods( AdminID,ref GetData);
            //GetData.Columns.Add("Cinema", typeof(string), "VoucherID + '    ' + DiscountPrice + '   ' + MinPrice");
            DropDownList1.DataSource = GetData;
            DropDownList1.DataTextField = "ItemID";
            DropDownList1.DataValueField = "ItemID";
           
            if (GetData.Rows.Count > 0)
            {
                DropDownList1.DataBind();
                GetFoodDetail(sender, e);
            }

        }

        protected void GetFoodDetail(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            int AdminID = (int)Session["ID"];
            int ItemID = 0;
            Int32.TryParse(DropDownList1.SelectedValue.ToString(), out ItemID);
            string Name = null;
            int Price = 0;
            objmyDAL.GetFoodDetails(ItemID, ref Name, ref Price);
            TextBox1.Text = Name;
            TextBox2.Text = Price.ToString();

        }
        //Remove
        protected void Remove(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            int ItemID = 0;
            Int32.TryParse(DropDownList1.Text.ToString(),out ItemID);
            int AdminID = (int)Session["ID"];
            objmyDAL.DeleteFood(ItemID,AdminID);
            Status.Text = "Removed Successfully";
            TextBox1.Text = String.Empty;
            TextBox2.Text = String.Empty;
            FillFoodItems(sender, e);
        }

        //Done
        protected void Done(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx", true);
        }
    }
}