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
    public partial class ViewImage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            string cs = ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select ImageData from Images where ImageID=@ImageID", con);
                cmd.Parameters.Add("@ImageID", SqlDbType.Int).Value = Session["ImageID"].ToString();
                cmd.CommandType = CommandType.Text;
                con.Open();
                Byte[] content = cmd.ExecuteScalar() as Byte[];
                string str = Convert.ToBase64String(content);
                Image1.ImageUrl = "data:Image/jpg;base64," + str;


            }
        }
    }
}