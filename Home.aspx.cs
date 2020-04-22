using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DBProject.DAL;


namespace DBProject
{
    public partial class Home : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable GetData = new DataTable();
                string cs = ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("Select I.MovieID,I.ImageData,M.MovieName from Images I join Movies M on I.MovieID=M.MovieID where I.MovieID Is Not Null ", con);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(GetData); //get results

                    if (GetData.Rows.Count > 0)
                    {
                        //Images.DataSource = GetData;
                        //Images.DataBind();

                    }
                    
                   

                }
            }
        }


        protected void Redirect(object sender, DataListCommandEventArgs e)
        {
            string ID = e.CommandArgument.ToString();
            
            Session["MovieID"] = ID;
           
            Response.Redirect("SignIn.aspx", true);
        }



    }
}