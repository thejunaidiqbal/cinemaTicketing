using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DBProject.DAL;

namespace DBProject
{
    public partial class AddMovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Temp = DropDownList1.SelectedValue.ToString();
            if(Temp=="")
            {
                lblMessage.Visible = false;
                hyperlink.Visible = false;
                lockIT(sender, e);
                PopDownMovies(sender,e);
            }
            
        }
        protected void ADDFromList(object sender, EventArgs e)
        {
            myDAL objMyDal = new myDAL();
            string MovieID= DropDownList1.SelectedValue.ToString();
            int AdminId = (int)Session["ID"];
            objMyDal.AddMoviesToAdmin(AdminId,MovieID);
            Status.Text = "Added Successfully";
            Response.AddHeader("REFRESH", "2;AdminHome.aspx");

        }
        protected void Add(object sender, EventArgs e)
        {
            myDAL objMyDal= new myDAL();
            int AdminID=(int)Session["ID"];
            string MovieName=TextBox1.Text.ToString();
            string Genre=TextBox2.Text.ToString();
            string Category=TextBox3.Text.ToString();
            string MovieID = TextBox4.Text.ToString();
            objMyDal.AddMoviesInList(AdminID, MovieName, MovieID, Genre, Category);
            //add movieID in images list
            int ImageID=(int)Session["ImageID"];
            objMyDal.MovieIDInImages(ImageID, MovieID);
            Status.Text = "Added Successfully";
            Response.AddHeader("REFRESH", "2;AdminHome.aspx");
        }
        protected void Unlock(object sender, EventArgs e)
        {
            TextBox1.ReadOnly = false;
            TextBox2.ReadOnly = false;
            TextBox3.ReadOnly = false;
            TextBox4.ReadOnly = false;
        }
        protected void lockIT(object sender, EventArgs e)
        {
            TextBox1.ReadOnly = true;
            TextBox2.ReadOnly = true;
            TextBox3.ReadOnly = true;
            TextBox4.ReadOnly = true;
        }

        protected void PopDownMovies(object sender, EventArgs e)
        {
            myDAL objMyDal = new myDAL();
            DataTable GetData=new DataTable();
            objMyDal.GetMovieData(ref GetData);
            DropDownList1.DataSource = GetData;
            DropDownList1.DataTextField = "MovieName";
            DropDownList1.DataValueField = "MovieID";
            if (GetData.Rows.Count > 0)
            {
                DropDownList1.DataBind();
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            
            HttpPostedFile postedFile = FileUpload1.PostedFile;
            string filename = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(filename);
            int fileSize = postedFile.ContentLength;

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif"
                || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
            {
                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);


                string cs = ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("UploadImage", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramName = new SqlParameter()
                    {
                        ParameterName = @"Name",
                        Value = filename
                    };
                    cmd.Parameters.Add(paramName);

                    SqlParameter paramSize = new SqlParameter()
                    {
                        ParameterName = "@Size",
                        Value = fileSize
                    };
                    cmd.Parameters.Add(paramSize);

                    SqlParameter paramImageData = new SqlParameter()
                    {
                        ParameterName = "@ImageData",
                        Value = bytes
                    };
                    cmd.Parameters.Add(paramImageData);

                    
                    SqlParameter paramImageId = new SqlParameter()
                    {
                        ParameterName = "@ImageID",
                        Value = -1,
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(paramImageId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Upload Successful";
                    hyperlink.Visible = true;
                    hyperlink.NavigateUrl = "~/ViewImage.aspx?Id=" +
                        cmd.Parameters["@ImageId"].Value.ToString();
                    int ImageID=0;
                    Int32.TryParse(cmd.Parameters["@ImageId"].Value.ToString(),out ImageID);
                    Session["ImageID"] = ImageID;
                }
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Only images (.jpg, .png, .gif and .bmp) can be uploaded";
                hyperlink.Visible = false;
            }
        }
    }
   
}

     
