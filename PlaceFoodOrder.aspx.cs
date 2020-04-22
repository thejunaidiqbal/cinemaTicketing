using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;
using System.Data;

namespace DBProject
{
    public partial class PlaceFoodOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                ShowFoodOptions(sender,e);
             
        }
        public void Confirm(object sender, EventArgs e)
    {
        myDAL objMyDal = new myDAL();
        Status.Text = "Order Saved";
        int TotalMoney = (int)Session["Price"];
        int UserID = (int)Session["ID"];
        string ShowID=Session["ShowID"].ToString();
        int Price=objMyDal.TotalFoodBill(UserID,ShowID);
        TotalMoney = TotalMoney + Price;
        Session["Price"] = TotalMoney;
        Response.Redirect("UserDiscount.aspx", true);
    }
        public void ShowFoodOptions(object sender, EventArgs e)   // to show the grid
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            string CinemaID = Session["CinemaID"].ToString();
            objmyDAL.CinemaFoodsItems(CinemaID,ref GetData);     //showing items of the cinema
            
            if (GetData.Rows.Count > 0)
            {
                DropDownList1.DataSource = GetData;
                DropDownList1.DataTextField = "ItemName";
                DropDownList1.DataValueField = "ItemID";
                if (GetData.Rows.Count > 0)
                {
                    DropDownList1.DataBind();
                    GeneratePrice(sender, e);
                }
            }
            else
            {
                Status.Text = "No Food Items Available";
                Response.Redirect("UserDiscount.aspx", true);

            }
        }

        public void ShowFoodInUserList(object sender,EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            DataTable GetData = new DataTable();
            int UserID = (int)Session["ID"];
            string ShowID = Session["ShowID"].ToString();
            objmyDAL.UserFoodList(ShowID,UserID, ref GetData);     //showing items of the cinema
            
                DropDownList2.DataSource = GetData;
                DropDownList2.DataTextField = "ItemName";
                DropDownList2.DataValueField = "ItemID";
                
                TextBox3.Text = String.Empty;
                if (GetData.Rows.Count > 0)
                {
                    DropDownList2.DataBind();
                QuantityOFItem(sender, e);
               }
            
            
        }

        public void QuantityOFItem(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            int UserID = (int)Session["ID"];
            string ShowID = Session["ShowID"].ToString();
            int ItemID = 0;
            Int32.TryParse(DropDownList2.SelectedValue.ToString(), out ItemID);
            int Quantity=objmyDAL.GetUSerFoodQuantity(UserID, ShowID, ItemID);
            TextBox3.Text = Quantity.ToString();
        }

        public void GeneratePrice(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            int ItemID = 0;
            Int32.TryParse(DropDownList1.SelectedValue.ToString(), out ItemID);
            int price= objmyDAL.GeneratePrice(ItemID);
            if(price!=0)
            {
                TextBox1.Text = price.ToString();
            }

        }
        public void Add(object sender, EventArgs e)
        {
             myDAL objmyDAL = new myDAL();
            int UserId=(int)Session["ID"];
            string ShowID = Session["ShowID"].ToString();
             int ItemID = 0;
            Int32.TryParse(DropDownList1.SelectedValue.ToString(), out ItemID);
            int Quantity = 0;
            Int32.TryParse(TextBox2.Text.ToString(), out Quantity);
            objmyDAL.OrderItem(UserId, ShowID, ItemID, Quantity);   //item added in the list
            ShowFoodInUserList(sender, e);
        }
        public void Remove(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();
            int UserId = (int)Session["ID"];
            string ShowID = Session["ShowID"].ToString();
            int ItemID = 0;
            Int32.TryParse(DropDownList2.SelectedValue.ToString(), out ItemID);
            int Quantity = 0;
            Int32.TryParse(TextBox3.Text.ToString(), out Quantity);
            objmyDAL.RemoveItemFromOrder(UserId, ShowID, ItemID, Quantity);   //item Removed in the list
            ShowFoodInUserList(sender, e);
        }

       
    }
}