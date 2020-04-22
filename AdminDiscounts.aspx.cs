using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DBProject.DAL;

namespace DBProject
{
    public partial class AdminDiscounts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
        protected void Add(object sender, EventArgs e)
        {
            myDAL objMyDal = new myDAL();
            int AdminID = (int)Session["ID"];
            int VoucherID=0;
             Int32.TryParse(TextBox1.Text, out VoucherID);
            int DiscountPrice=0;
             Int32.TryParse(TextBox2.Text, out DiscountPrice);
            int MinAmount=0;
             Int32.TryParse(TextBox3.Text, out MinAmount);
            int MaxAmount=0;
             Int32.TryParse(TextBox4.Text, out MaxAmount);
             int found = objMyDal.AddDiscount(VoucherID, DiscountPrice, MinAmount, MaxAmount, AdminID);
             if (found == VoucherID)
             {
                 Status.Text = "Added Successfully by ID";
                 TextBox5.Text = found.ToString();
                 Response.AddHeader("REFRESH", "2;AdminHome.aspx");
             }
             else if(found==0 )
             {
                 Status.Text = "ID already exists";
             }
             else if(found!=VoucherID)
             {
                 Status.Text = "Offer Already Exists by ID";
                 TextBox5.Text = found.ToString();
                 Response.AddHeader("REFRESH", "2;AdminHome.aspx");
             }
        }
        
    }
}