using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;
using System.Data;
using System.Text;

namespace DBProject
{
    public partial class MoviesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SearchMovies(sender, e);
        }
        protected void SearchMovies(object sender, EventArgs e)
        {
            myDAL objmyDAl = new myDAL();
            DataTable DT= new DataTable();
            int found;
            found = objmyDAl.BrowseAllMovies(ref DT);
            if (found != 1)
            {
                Message.Text = "There was some error!";
            }
            else
            {
                MoviesGrid.DataSource = DT;
                if (DT.Rows.Count > 0)
                {

                    Message.Text = "Following movies are found:";
                    MoviesGrid.DataBind();
                }
                else
                {
                    Message.Text = "No Movies Found:";
                }
            }
           
        }

    }
}