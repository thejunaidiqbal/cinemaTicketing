using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace DBProject.DAL
{
    public class myDAL
    {
        private static readonly string constring =
            System.Configuration.ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;

        //Add Movie in Admins Link
        public int AddMoviesToAdmin(int AdminId, string MovieID)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                
                cmd = new SqlCommand("insert into AdminMovies values(@AdminId,@MovieID)", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@MovieID", SqlDbType.VarChar, 20).Value = MovieID;
                cmd.Parameters.Add("@AdminID", SqlDbType.Int).Value = AdminId;
                cmd.ExecuteNonQuery();
                

            }
            catch (SqlException ex)
            {

                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        //all users
        public int AllUsers(ref DataTable GetData)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                GetData = new DataTable();
                cmd = new SqlCommand("Select * from UsersList", Con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results
                GetData = ds.Tables[0];

            }
            catch (SqlException ex)
            {

                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        //CinemaScreens
        //all users
        public int CinemaScreens(string CinemaID,ref DataTable GetData)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                GetData = new DataTable();
                cmd = new SqlCommand("Select distinct P.Screen from ScreenPrice P join Cinemas C on C.CinemaID=P.CinemaID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar, 20).Value = CinemaID;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results
                GetData = ds.Tables[0];

            }
            catch (SqlException ex)
            {

                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        //Available Screen
        public int CheckAvailableScreens(string CinemaID,string TimeDate,string Screen)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            int R=0;
            try
            {
               
                cmd = new SqlCommand("if exists(Select P.Screen from Showtimes S join ScreenPrice P on S.Screen=P.Screen and S.CinemaID=P.CinemaID where S.ShowDT=@TimeDate and S.CinemaID=@CinemaID and S.Screen=@Screen ) set @return=0 ", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar,20).Value = CinemaID;
                cmd.Parameters.Add("@TimeDate", SqlDbType.DateTime).Value = TimeDate;
                cmd.Parameters.Add("@Screen", SqlDbType.VarChar,20).Value = Screen;
                SqlParameter ReturnValue = new SqlParameter("@return", SqlDbType.Int);
                ReturnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue);
                cmd.Parameters["@return"].Value = 1;
                cmd.ExecuteNonQuery();
                R = (int)cmd.Parameters["@return"].Value;
                
            }
            catch (SqlException ex)
            {

                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return R;  //0 for not avaiable 1 for available
        }

        //view admin shows
        public int AdminShows(int AdminID, ref DataTable GetData)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                GetData = new DataTable();
                cmd = new SqlCommand("Select distinct S.ShowID,C.CinemaName,C.Locations,M.MovieName,S.Screen,S.ShowDT,S.ShowStatus,S.FilledSeats from Showtimes S join Cinemas C on C.CinemaID=S.CinemaID join Movies M on M.MovieID=S.MovieID where C.AdminID=@AdminID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@AdminID", SqlDbType.Int).Value = AdminID;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results
                GetData = ds.Tables[0];

            }
            catch (SqlException ex)
            {

                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }


     //add into showtimes
        public int AddShowtime(string ShowID,string CinemaID,string MovieID, string Screen, string TimeDate)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
               
                cmd = new SqlCommand("insert into Showtimes values(@ShowID,@CinemaID,@MovieID,@Screen,@TimeDate,'Pending',0)", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar, 20).Value = CinemaID;
                cmd.Parameters.Add("@TimeDate", SqlDbType.DateTime).Value = TimeDate;
                cmd.Parameters.Add("@ShowID", SqlDbType.VarChar, 20).Value = ShowID;
                cmd.Parameters.Add("@MovieID", SqlDbType.VarChar, 20).Value = MovieID;
                cmd.Parameters.Add("@Screen", SqlDbType.VarChar, 20).Value = Screen;
                cmd.ExecuteNonQuery();
                
            }
            catch (SqlException ex)
            {

                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }





        //load Movies of that admin
        public int AdminMovies(int AdminID,ref DataTable GetData)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                GetData = new DataTable();
                cmd = new SqlCommand("Select distinct M.MovieName,M.MovieID from Movies M join AdminMovies A on A.MovieID=M.MovieID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@AdminID", SqlDbType.Int).Value = AdminID;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results
                GetData = ds.Tables[0];

            }
            catch (SqlException ex)
            {

                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }




        //load Movies
        public int GetMovieData(ref DataTable GetData)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                GetData = new DataTable();
                cmd = new SqlCommand("Select distinct M.MovieName,M.MovieID from Movies M ", Con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results
                GetData = ds.Tables[0];

            }
            catch (SqlException ex)
            {

                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        public int GetMovieCinemas(ref DataTable GetData, string MovieID)   //return cinemas List
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                GetData = new DataTable();
                cmd = new SqlCommand("Select distinct C.CinemaName,S.CinemaID from Showtimes S join Cinemas C on C.CinemaID=S.CinemaID where MovieID=@MovieID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@MovieID", SqlDbType.VarChar, 20).Value = MovieID;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results
                GetData = ds.Tables[0];

            }
            catch (SqlException ex)
            {

                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        public int GetMovieCinemasTime(ref DataTable GetData, string CinemaID, string MovieID)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                GetData = new DataTable();
                cmd = new SqlCommand("Select distinct ShowDT from Showtimes S where MovieID=@MovieID and CinemaID=@CinemaID ", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@MovieID", SqlDbType.VarChar, 20).Value = MovieID;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar, 20).Value = CinemaID;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results
                GetData = ds.Tables[0];

            }
            catch (SqlException ex)
            {

                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        public int GetTickets(string ShowID)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            int tickets = 0;
            try
            {
                cmd = new SqlCommand("select @Tickets=P.TotalSeats-S.FilledSeats from Showtimes S join ScreenPrice P on P.CinemaID=S.CinemaID and P.Screen=S.Screen where S.ShowId=@ShowID ", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@ShowID", SqlDbType.VarChar, 20).Value = ShowID;
                SqlParameter ReturnValue = new SqlParameter("@Tickets", SqlDbType.Int);
                ReturnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue);
                cmd.ExecuteNonQuery();
                tickets = (int)cmd.Parameters["@Tickets"].Value;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return tickets;
            }
            finally
            {
                Con.Close();
            }
            return tickets;
        }
        public int GetMovieCinemasTimeScreen(ref DataTable GetData, string CinemaID, string MovieID, string TimeDate)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                GetData = new DataTable();
                cmd = new SqlCommand("Select distinct S.Screen from Showtimes S where S.MovieID=@MovieID and S.CinemaID=@CinemaID and S.ShowDT=@ShowDT", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@MovieID", SqlDbType.VarChar, 20).Value = MovieID;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar, 20).Value = CinemaID;
                cmd.Parameters.Add("@ShowDT", SqlDbType.DateTime).Value = TimeDate;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results
                GetData = ds.Tables[0];

            }
            catch (SqlException ex)
            {

                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        public int GetUserInfo(int UserID, ref string Name, ref string City, ref int MoviesWatched, ref int MoneySpent)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("GetUserInfo", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = UserID;
                SqlParameter ReturnValue1 = new SqlParameter("@Name", SqlDbType.VarChar, 30);
                SqlParameter ReturnValue2 = new SqlParameter("@City", SqlDbType.VarChar, 20);
                SqlParameter ReturnValue3 = new SqlParameter("@MoviesWatched", SqlDbType.Int);
                SqlParameter ReturnValue4 = new SqlParameter("@MoneySpent", SqlDbType.Int);
                ReturnValue1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue1);
                ReturnValue2.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue2);
                ReturnValue3.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue3);
                ReturnValue4.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue4);
                cmd.ExecuteNonQuery();
                Name = cmd.Parameters["@Name"].Value.ToString();
                City = cmd.Parameters["@City"].Value.ToString();
                MoviesWatched = (int)cmd.Parameters["@MoviesWatched"].Value;
                MoneySpent = (int)cmd.Parameters["@MoneySpent"].Value;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }
        public int EditAdminInfo(int oldID, int ID, string Name)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("EditAdminInfo", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@oldID", SqlDbType.Int).Value = oldID;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 30).Value = Name;
                cmd.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }
        public int GetAdminInfo(int ID, ref string Name)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("select @Name=AdminName from Administrator where AdminID=@ID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                SqlParameter ReturnValue = new SqlParameter("@Name", SqlDbType.VarChar, 30);
                ReturnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue);
                cmd.ExecuteNonQuery();
                Name = cmd.Parameters["@Name"].Value.ToString();


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }
        public int EditUserInfo(int oldID, int ID, string Name, string City)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("EditInfo", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@oldID", SqlDbType.Int).Value = oldID;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 30).Value = Name;
                cmd.Parameters.Add("@City", SqlDbType.VarChar, 20).Value = City;
                cmd.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        public int SearchUser(int id, string pw, string t)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("LogInAccount", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 20).Value = pw;
                cmd.Parameters.Add("@type", SqlDbType.VarChar, 1).Value = t;
                SqlParameter ReturnValue = new SqlParameter("@return", SqlDbType.Int);
                ReturnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue);
                cmd.ExecuteNonQuery();
                int R = (int)cmd.Parameters["@return"].Value;
                Con.Close();
                if (R == 0)
                {
                    return -1;
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }
        public int InsertUser(string name, int id, string pw, string city, string t)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SignUP", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 30).Value = name;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 20).Value = pw;
                cmd.Parameters.Add("@city", SqlDbType.VarChar, 20).Value = city;
                cmd.Parameters.Add("@type", SqlDbType.VarChar, 1).Value = t;
                SqlParameter ReturnValue = new SqlParameter("@return", SqlDbType.Int);
                ReturnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue);
                cmd.ExecuteNonQuery();
                int R = (int)cmd.Parameters["@return"].Value;
                Con.Close();
                if (R == 0)
                {
                    return -1;
                }

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;

            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        //function to change password
        public int ChangePassword(int ID, string oldPassword, string newPassword)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {

                cmd = new SqlCommand("update UAlogin set UAPassword=@newPassword where UAID=@ID and UAPassword=@oldPassword ", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@oldPassword", SqlDbType.VarChar, 20).Value = oldPassword;
                cmd.Parameters.Add("@newPassword", SqlDbType.VarChar, 20).Value = newPassword;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;

            }
            finally
            {
                Con.Close();

            }
            return 1;
        }

        //function to return showID
        public int ReturnShowId(ref string ShowId, string CinemaID, string MovieID, string TimeDate, string Screen)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Select @ShowID=ShowID from Showtimes where CinemaID=@CinemaID and MovieID=@MovieID and ShowDT=@ShowDT and Screen=@Screen", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar, 20).Value = CinemaID;
                cmd.Parameters.Add("@MovieID", SqlDbType.VarChar, 20).Value = MovieID;
                cmd.Parameters.Add("@ShowDT", SqlDbType.DateTime).Value = TimeDate;
                cmd.Parameters.Add("@Screen", SqlDbType.VarChar, 20).Value = Screen;
                SqlParameter ReturnValue = new SqlParameter("@ShowID", SqlDbType.VarChar, 20);
                ReturnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue);
                cmd.ExecuteNonQuery();
                ShowId = cmd.Parameters["@ShowID"].Value.ToString();


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }
        //return discount by showid
        public int AvailableDiscountID(string CinemaID, int Amount ,ref DataTable GetData)
        {
            return 0;
        }

        //get price by discount id
        public int DiscountPrice(int VoucherID)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            int Price = 0;
            try
            {
                cmd = new SqlCommand("select @Price=DiscountPrice from DiscountDetails where VoucherID=@VoucherID ", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@VoucherID", SqlDbType.Int).Value = VoucherID;
                SqlParameter ReturnValue = new SqlParameter("@Price", SqlDbType.Int);
                ReturnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue);
                cmd.ExecuteNonQuery();
                Price = (int)cmd.Parameters["@Price"].Value;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return Price;
        }


        //list discounts of the cinema selected

        public int DiscountsByCinema(string CinemaID, ref DataTable GetData)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select D.DiscountPrice,D.MinAmount from DiscountDetails D join CinemasDiscount C on C.VoucherID=D.VoucherID where C.CinemaID=@CinemaID ", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar, 20).Value = CinemaID;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results

                GetData = new DataTable();
                GetData = ds.Tables[0];
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }


        //generate discounts based on the CinemaID
        public int DiscountsForCinema(string CinemaID,int Amount,ref DataTable GetData)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            int VoucherID = 0;
            try
            {
                cmd = new SqlCommand("select C.VoucherID from DiscountDetails D join CinemasDiscount C on C.VoucherID=D.VoucherID where C.CinemaID=@CinemaID and @Amount<=D.MaxAmount and @Amount>=D.MinAmount", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar,20).Value = CinemaID;
                cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = Amount;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results
                
                    GetData = new DataTable();
                    GetData = ds.Tables[0];
                
                

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return VoucherID;
        }

        //show user list
        public int UserFoodList(string ShowID,int UserID, ref DataTable GetData)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select I.ItemName,I.ItemID from FoodOrders F join FoodItems I on I.ItemID=F.ItemID where ShowID=@ShowID and UserID=@UserID ", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                cmd.Parameters.Add("@ShowID", SqlDbType.VarChar,20).Value = ShowID;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results

                GetData = ds.Tables[0]; //fill the results in ref input table
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }

            return 1;
        }
        public int GetUSerFoodQuantity(int UserID,string ShowID,int ItemID)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            int Quantity = 0;
            try
            {
                cmd = new SqlCommand("select @Quantity=Quantity from FoodOrders where ShowID=@ShowID and UserID=@UserID and ItemID=@ItemID ", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                cmd.Parameters.Add("@ItemID", SqlDbType.Int).Value = ItemID;
                cmd.Parameters.Add("@ShowID", SqlDbType.VarChar, 20).Value = ShowID;
                SqlParameter ReturnValue = new SqlParameter("@Quantity", SqlDbType.Int);
                ReturnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue);
                cmd.ExecuteNonQuery();
                Quantity = (int)cmd.Parameters["@Quantity"].Value;
               
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }

            return Quantity;
        }

        //get price of a screen in the cinema;
        public int GetPrice(string ShowID)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            int Price = 0;
            try
            {
                cmd = new SqlCommand("select @Price=P.Price from Showtimes S join ScreenPrice P on S.CinemaID=P.CinemaID and S.Screen=P.Screen where S.ShowId=@ShowID ", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@ShowID", SqlDbType.VarChar, 20).Value = ShowID;
                SqlParameter ReturnValue = new SqlParameter("@Price", SqlDbType.Int);
                ReturnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue);
                cmd.ExecuteNonQuery();
                Price = (int)cmd.Parameters["@Price"].Value;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return Price;
        }

        //function to call stored procedure InsertUserRecord for ticket booking

        //add discount in the list record of the user
        public int AddDiscountForOrder(int VoucherID,string ShowID,string CinemaID,int UserID)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            SqlCommand cmd2;
            SqlCommand cmd1;
            SqlCommand cmd3;
            int R = 0;
            try
            {
                cmd = new SqlCommand("update UserRecord set DiscountID=@VoucherID where UserID=@UserID and CinemaID=@CinemaID  ", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@VoucherID", SqlDbType.Int).Value = VoucherID;
                cmd.Parameters.Add("@ShowID", SqlDbType.VarChar, 20).Value = ShowID;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar, 20).Value = CinemaID;

                cmd.ExecuteNonQuery();
                cmd1 = new SqlCommand("select @Price=DiscountPrice from DiscountDetails where VoucherID=@VoucherID  ", Con);
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.Add("@VoucherID", SqlDbType.Int).Value = VoucherID;
                SqlParameter ReturnValue = new SqlParameter("@Price", SqlDbType.Int);
                ReturnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue);
                cmd.ExecuteNonQuery();
                 R = (int)cmd.Parameters["@Price"].Value;

                cmd1.ExecuteNonQuery();


                cmd2= new SqlCommand("update Cinemas set TotalEarning=TotalEarning+@Price where CinemaID=@CinemaID  ", Con);
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.Add("@VoucherID", SqlDbType.Int).Value = VoucherID;
                cmd2.Parameters.Add("@ShowID", SqlDbType.VarChar, 20).Value = ShowID;
                cmd2.Parameters.Add("@CinemaID", SqlDbType.VarChar, 20).Value = CinemaID;

                cmd2.ExecuteNonQuery();

                cmd2 = new SqlCommand("update UsersList set UserMoney=UserMoney-@Price where UserID=@UserID  ", Con);
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                cmd2.ExecuteNonQuery();

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        public int UserRecordInsert(int UserId, string ShowId, int TicketsNo,int Amount)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("InsertUserRecord", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
                cmd.Parameters.Add("@ShowID", SqlDbType.VarChar, 20).Value = ShowId;
                cmd.Parameters.Add("@NoOfTickets", SqlDbType.Int).Value = TicketsNo;
                cmd.Parameters.Add("@Money", SqlDbType.Int).Value = Amount;
                cmd.ExecuteNonQuery();
              
                

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }
        public int BrowseAllMovies(ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select distinct M.MovieName from Movies M join Showtimes S on S.MovieID=M.MovieID where S.ShowStatus='Pending'", Con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results

                result = ds.Tables[0]; //fill the results in ref input table
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }

            return 1;
        }
        public int BrowseByMovies(string MovieId, ref DataTable result)//to return resulting table
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("BrowseMovies", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MovieId", SqlDbType.VarChar, 20).Value = MovieId;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results

                result = ds.Tables[0]; //fill the results in ref input table
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }

            return 1;
        }

        //AddRatings

        public int AddCinemaRatings(int Rating, string CinemaID)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("AddRatings", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Rating", SqlDbType.Int).Value = Rating;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar, 20).Value = CinemaID;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }

            return 1;
        }

        //WatchHistory
        public int ViewWatchHistory(int UserId, ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("WatchHistory", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results

                result = ds.Tables[0]; //fill the results in ref input table
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }

            return 1;
        }

        //DeleteAccount

        public int DeleteAnyAccount(int ID, string Type)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("DeleteAccount", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@Type", SqlDbType.VarChar, 1).Value = Type;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        //PaymentMethod

        public int AskForPaymentMethod(string CinemaID, string CardNumber, int TotalMoney,int UserID)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("PaymentMethod", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CardNumber", SqlDbType.VarChar, 20).Value = CardNumber;
                cmd.Parameters.Add("@TotalMoney", SqlDbType.Int).Value = TotalMoney;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar, 20).Value = CinemaID;
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }
        //FoodAvailable int a cinema

        public int FoodItemsAvailable(string CinemaID, ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("FoodAvailable", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CinemaId", SqlDbType.VarChar, 20).Value = CinemaID;
                SqlParameter ReturnValue = new SqlParameter("@return", SqlDbType.Int);
                ReturnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue);
                cmd.ExecuteNonQuery();
                int R = (int)cmd.Parameters["@return"].Value;
                if (R == 1)  //found return table;
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(ds); //get results

                    result = ds.Tables[0]; //fill the results in ref input table
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        //FoodItemsAvailableInCinema(CinemaID, ref result)
     

        /*View Shows of a Movie*/
        public int ViewMovieShows(string MovieID,ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select M.MovieName,C.CinemaName,C.Locations,S.Screen,S.ShowDT,P.Price from (Showtimes S join Cinemas C on S.CinemaID=C.CinemaID) join Movies M on M.MovieID=S.MovieID join ScreenPrice P on P.Screen=S.Screen and S.CinemaID=P.CinemaID where S.MovieID=@MovieID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@MovieID", SqlDbType.VarChar, 20).Value = MovieID;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results

                result = ds.Tables[0]; //fill the results in ref input table


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        /*ViewShowtimes*/
        public int ViewShowTimes(ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("ViewShowtimes", Con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results

                result = ds.Tables[0]; //fill the results in ref input table


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        /*ViewCinemas*/
        public int ViewCinemasList(ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("ViewCinemas", Con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results

                result = ds.Tables[0]; //fill the results in ref input table


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }
        //Generate Price
        public int GeneratePrice(int ItemID)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            int R = 0;
            try
            {
                cmd = new SqlCommand("select @Price=Price from FoodItems where ItemID=@ItemID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@ItemID", SqlDbType.Int).Value = ItemID;
                SqlParameter ReturnValue = new SqlParameter("@Price", SqlDbType.Int);
                ReturnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue);
                cmd.ExecuteNonQuery();
                 R = (int)cmd.Parameters["@Price"].Value;
                

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return R;
        }

        //OrderFood

        public int OrderItem(int UserId, string ShowID, int ItemId, int Quantity)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("OrderFood", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
                cmd.Parameters.Add("@ShowId", SqlDbType.VarChar, 20).Value = ShowID;
                cmd.Parameters.Add("@ItemID", SqlDbType.Int).Value = ItemId;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = Quantity;
                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        //show list
        public int ShowItemsInList(string ShowID, int UserID,ref DataTable GetData)
    {
        DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select I.ItemName,F.Quantity from FoodOrders F join FoodItems I on I.ItemID=F.ItemID where F.ShowID=@ShowID and UserID=@UserID  ", Con);
                GetData = new DataTable();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@ShowID", SqlDbType.VarChar, 20).Value = ShowID;
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results
                GetData = ds.Tables[0];


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;

}



        //RemoveFoodItem

        public int RemoveItemFromOrder(int UserId, string ShowID, int ItemId, int Quantity)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("RemoveFoodItem", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
                cmd.Parameters.Add("@ShowId", SqlDbType.VarChar, 20).Value = ShowID;
                cmd.Parameters.Add("@ItemID", SqlDbType.Int).Value = ItemId;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = Quantity;
                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }


        //FoodOrderTotal
        public int TotalFoodBill(int UserId, string ShowID)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            int TotalMoney = 0;
            try
            {
                cmd = new SqlCommand("FoodOrderTotal", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
                cmd.Parameters.Add("@ShowId", SqlDbType.VarChar, 20).Value = ShowID;
                SqlParameter ReturnValue = new SqlParameter("@TotalMoney", SqlDbType.Int);
                ReturnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue);
                cmd.ExecuteNonQuery();
                TotalMoney = (int)cmd.Parameters["@TotalMoney"].Value;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return TotalMoney;
        }
        //AddMovies
        public string AddMoviesInList(int AdminID, string MovieName, string MovieID, string Genre, string Category)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            string MovieReturnId = null;
            try
            {
                cmd = new SqlCommand("AddMovies", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MovieName", SqlDbType.VarChar, 30).Value = MovieName;
                cmd.Parameters.Add("@MovieID", SqlDbType.VarChar, 20).Value = MovieID;
                cmd.Parameters.Add("@Genre", SqlDbType.VarChar, 20).Value = Genre;
                cmd.Parameters.Add("@Category", SqlDbType.VarChar, 20).Value = Category;
                cmd.Parameters.Add("@AdminID", SqlDbType.VarChar, 20).Value = AdminID;
                SqlParameter ReturnValue = new SqlParameter("@MovieReturnId", SqlDbType.VarChar, 20);
                ReturnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue);
                cmd.ExecuteNonQuery();
                MovieReturnId = (string)cmd.Parameters["@MovieReturnId"].Value;



            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return MovieReturnId;
            }
            finally
            {
                Con.Close();
            }
            return MovieReturnId;
        }

        //Add Movie Rating
               //Get All Cinemas
        public int GetAllCinemas(ref DataTable GetData)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select distinct CinemaName,CinemaID,Locations from Cinemas C  ", Con);
                GetData = new DataTable();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results
                GetData = ds.Tables[0];


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }
         
          public int AllCinemas(ref DataTable GetData)
          {
              DataSet ds = new DataSet();
              SqlConnection Con = new SqlConnection(constring);
              Con.Open();
              SqlCommand cmd;
              try
              {
                  cmd = new SqlCommand("select distinct CinemaName,Locations,ContactNo,Rating,FoodAvailable from Cinemas C  ", Con);
                  GetData = new DataTable();
                  cmd.CommandType = CommandType.Text;
                  cmd.ExecuteNonQuery();
                  using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                      da.Fill(ds); //get results
                  GetData = ds.Tables[0];


              }
              catch (SqlException ex)
              {
                  Console.WriteLine("SQL Error" + ex.Message.ToString());
                  return 0;
              }
              finally
              {
                  Con.Close();
              }
              return 1;
          }


        //Get a cinema Location
        public int GetLocation(string CinemaID,ref DataTable GetData)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select distinct Locations,CinemaID from Cinemas C where CinemaID=@CinemaID", Con);
                GetData = new DataTable();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar, 20).Value = CinemaID;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results
                GetData = ds.Tables[0];


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        //RevenueGenerator

        public int GenerateRevenue(int AdminID,ref DataTable GetData)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select  C.CinemaName,C.CinemaID,C.TotalEarning from Cinemas C where AdminID=@AdminID ", Con);
                GetData = new DataTable();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@AdminID", SqlDbType.VarChar, 20).Value = AdminID;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results
                GetData = ds.Tables[0];


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }
        //AddCinemas

        public int AddNewCinemas(string CinemaName, string CinemaID, string Location, int ScreenCount, string ContactNo, int Rating,
            string FoodAvailable, int AdminID, int AccountNo)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("AddCinemas", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CinemaName", SqlDbType.VarChar, 30).Value = CinemaName;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar, 20).Value = CinemaID;
                cmd.Parameters.Add("@Locations", SqlDbType.VarChar, 20).Value = Location;
                cmd.Parameters.Add("@Screens", SqlDbType.Int).Value = ScreenCount;
                cmd.Parameters.Add("@ContactNo", SqlDbType.VarChar, 20).Value = ContactNo;
                cmd.Parameters.Add("@Rating", SqlDbType.Int).Value = Rating;
                cmd.Parameters.Add("@FoodAvailable", SqlDbType.VarChar, 1).Value = FoodAvailable;
                cmd.Parameters.Add("@AdminID", SqlDbType.Int).Value = AdminID;
                cmd.Parameters.Add("@AccountNo", SqlDbType.Int).Value = AccountNo;
                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }



        //AddScreens

        public int AddCinemaScreens(string CinemaID, string Screen, int Price, int TotalSeats)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            int R = 0;
            int Get=0;
            try
            {
                cmd = new SqlCommand("AddScreens", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar, 20).Value = CinemaID;
                cmd.Parameters.Add("@Screen", SqlDbType.VarChar, 20).Value = Screen;
                cmd.Parameters.Add("@Price", SqlDbType.Int).Value = Price;
                cmd.Parameters.Add("@TotalSeats", SqlDbType.Int).Value = TotalSeats;
                SqlParameter ReturnValue = new SqlParameter("@return", SqlDbType.Int);
                ReturnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue);
                cmd.ExecuteNonQuery();
                Get = (int)cmd.Parameters["@return"].Value;
                

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return Get;
        }

        //ADDFood
        //Delete Food
        public int DeleteFood(int ItemID, int AdminID)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Delete from FoodItemsAdmin where AdminID=@AdminID and ItemID=@ItemID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@AdminID", SqlDbType.Int).Value = AdminID;
                cmd.Parameters.Add("@ItemID", SqlDbType.Int).Value = ItemID;
                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        //delete food from cinema
        public int RemoveFood(int VoucherID, string CinemaID)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("delete from FoodServices where CinemaID=@CinemaID and ItemID=@VoucherID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar,20).Value = CinemaID;
                cmd.Parameters.Add("@VoucherID", SqlDbType.Int).Value = VoucherID;
                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }
        //Get ItemID
        public int GetItemID(string ItemName,int Price)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            int ItemReturnID = 0;
            try
            {
                cmd = new SqlCommand("Select @ItemID=ItemID from FoodItems where ItemName=@ItemName and Price=@Price", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@ItemName", SqlDbType.VarChar, 20).Value = ItemName;
                cmd.Parameters.Add("@Price", SqlDbType.Int).Value = Price;
                SqlParameter ReturnValue = new SqlParameter("@ItemID", SqlDbType.Int);
                ReturnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue);
                cmd.ExecuteNonQuery();
                ItemReturnID = (int)cmd.Parameters["@ItemReturnID"].Value;


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return ItemReturnID;
            }
            finally
            {
                Con.Close();
            }
            return ItemReturnID;
        }

        //Get Food Items of a cinema

        public int CinemaFoodsItems(string CinemaID, ref DataTable GetData)   //Add new food item
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("select F.ItemName,S.ItemID from FoodItems F join FoodServices S on S.ItemID=F.ItemID where S.CinemaID=@CinemaID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar, 20).Value = CinemaID;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results
                GetData = ds.Tables[0];

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        //Add Cinema Food
        public int AddCinemaFoods(string CinemaID, int ItemID)   //Add new food item
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Insert into FoodServices values(@ItemID,@CinemaID)", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar, 20).Value = CinemaID;
                cmd.Parameters.Add("@ItemID", SqlDbType.Int).Value = ItemID;
                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }
        public int RemoveCinemaFoods(string CinemaID, int ItemID)   //Add new food item
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("delete from FoodServices where ItemID=@ItemID and CinemaID=@CinemaID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar, 20).Value = CinemaID;
                cmd.Parameters.Add("@ItemID", SqlDbType.Int).Value = ItemID;
                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        public int AddFoods(int AdminID, string ItemName, int ItemId, int Price)   //Add new food item in FoodItems
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            int ItemReturnID = 0;
            try
            {
                cmd = new SqlCommand("ADDFood", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ItemName", SqlDbType.VarChar, 20).Value = ItemName;
                cmd.Parameters.Add("@ItemId", SqlDbType.Int).Value = ItemId;
                cmd.Parameters.Add("@Price", SqlDbType.Int).Value = Price;
                cmd.Parameters.Add("@AdminId", SqlDbType.Int).Value = AdminID;
                SqlParameter ReturnValue = new SqlParameter("@ItemReturnID", SqlDbType.Int);
                ReturnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue);
                cmd.ExecuteNonQuery();
                ItemReturnID = (int)cmd.Parameters["@ItemReturnID"].Value;


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return ItemReturnID;
            }
            finally
            {
                Con.Close();
            }
            return ItemReturnID;
        }


        //Discounts list of the admin

        public int AdminDiscountsList(ref DataTable GetData, int AdminID)
       {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                GetData = new DataTable();
                cmd = new SqlCommand("Select distinct D.VoucherID,D.DiscountPrice,D.MinAmount,D.MaxAmount from  AdminDiscounts A join DiscountDetails D on D.VoucherID=A.VoucherID where A.AdminID=@AdminID" , Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@AdminID", SqlDbType.Int).Value = AdminID;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results
                GetData = ds.Tables[0];

            }
            catch (SqlException ex)
            {

                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
      }

        //All discounts added by that admin
       public int GetDiscountData(ref DataTable GetData,int AdminID)
       {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                GetData = new DataTable();
                cmd = new SqlCommand("Select distinct VoucherID from  AdminDiscounts where AdminID=@AdminID" , Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@AdminID", SqlDbType.VarChar, 20).Value = AdminID;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results
                GetData = ds.Tables[0];

            }
            catch (SqlException ex)
            {

                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
      }

        //return Min max and discout price by voucher id
        public int GetDiscountDetails(int VoucherID, ref int DiscountPrice,ref int MinAmount,ref int MaxAmount )
       {
           DataSet ds = new DataSet();
           SqlConnection Con = new SqlConnection(constring);
           Con.Open();
           SqlCommand cmd;
           int ReturnVoucherID = 0;
           try
           {
               cmd = new SqlCommand("select @DiscountPrice=DiscountPrice  ,@MinAmount=MinAmount , @MaxAmount=MaxAmount  from DiscountDetails where VoucherID=@VoucherID", Con);
               cmd.CommandType = CommandType.Text;
               cmd.Parameters.Add("@VoucherID", SqlDbType.Int).Value = VoucherID;
            
               SqlParameter ReturnValue1 = new SqlParameter("@DiscountPrice", SqlDbType.Int);
               SqlParameter ReturnValue2 = new SqlParameter("@MinAmount", SqlDbType.Int);
               SqlParameter ReturnValue3 = new SqlParameter("@MaxAmount", SqlDbType.Int);
            
               ReturnValue1.Direction = ParameterDirection.Output;
               cmd.Parameters.Add(ReturnValue1);
               ReturnValue2.Direction = ParameterDirection.Output;
               cmd.Parameters.Add(ReturnValue2);
               ReturnValue3.Direction = ParameterDirection.Output;
               cmd.Parameters.Add(ReturnValue3);
               cmd.ExecuteNonQuery();
               DiscountPrice =(int) cmd.Parameters["@DiscountPrice"].Value;
               MinAmount = (int)cmd.Parameters["@MinAmount"].Value;
               MaxAmount = (int)cmd.Parameters["@MaxAmount"].Value;
               

           }
           catch (SqlException ex)
           {
               Console.WriteLine("SQL Error" + ex.Message.ToString());
               return 0;
           }
           finally
           {
               Con.Close();
           }
           return 1;
       }
        public int GetFoodDetails(int ItemID, ref string Name, ref int Price)
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            int ReturnVoucherID = 0;
            try
            {
                cmd = new SqlCommand("select @Name=ItemName , @Price=Price from FoodItems where ItemID=@ItemID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@ItemID", SqlDbType.Int).Value = ItemID;

                SqlParameter ReturnValue1 = new SqlParameter("@Name", SqlDbType.VarChar,20);
                SqlParameter ReturnValue2 = new SqlParameter("@Price", SqlDbType.Int);

                ReturnValue1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue1);
                ReturnValue2.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue2);
                cmd.ExecuteNonQuery();
                Name = cmd.Parameters["@Name"].Value.ToString();
                Price = (int)cmd.Parameters["@Price"].Value;


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }
        /*DiscountOffers*/
        public int DeleteDiscount(int VoucherID,int AdminID)    //Delete Discount from Admins Discount Table
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("delete from AdminDiscounts where AdminID=@AdminID and VoucherID=@VoucherID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@VoucherID", SqlDbType.Int).Value = VoucherID;;
                cmd.Parameters.Add("@AdminID", SqlDbType.Int).Value = AdminID;
                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }
        public int RemoveDiscount(int VoucherID, int CinemaID)    //Delete Discount from Admins Discount Table
        {
            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("delete from CinemasDiscount where CinemaID=@CinemaID and VoucherID=@VoucherID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@VoucherID", SqlDbType.Int).Value = VoucherID; ;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar,20).Value = CinemaID;
                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }


        public int AddDiscount(int VoucherID, int DiscountPrice, int MinAmount, int MaxAmount, int AdminID)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            int ReturnVoucherID = 0;
            try
            {
                cmd = new SqlCommand("DiscountOffers", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@VoucherID", SqlDbType.Int).Value = VoucherID;
                cmd.Parameters.Add("@DiscountPrice", SqlDbType.Int).Value = DiscountPrice;
                cmd.Parameters.Add("@MinAmount", SqlDbType.Int).Value = MinAmount;
                cmd.Parameters.Add("@MaxAmount", SqlDbType.Int).Value = MaxAmount;
                cmd.Parameters.Add("@AdminID", SqlDbType.Int).Value = AdminID;
                SqlParameter ReturnValue = new SqlParameter("@ReturnVoucherID", SqlDbType.Int);
                ReturnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ReturnValue);
                cmd.ExecuteNonQuery();
                ReturnVoucherID = (int)cmd.Parameters["@ReturnVoucherID"].Value;


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return ReturnVoucherID;
            }
            finally
            {
                Con.Close();
            }
            return ReturnVoucherID;
        }

        //AddDiscountCinema

        public int AddDiscountForCinema(int VoucherID, string CinemaID)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("AddDiscountCinema", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@VoucherID", SqlDbType.Int).Value = VoucherID;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar, 20).Value = CinemaID;
                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }
  public int DeleteDiscountFromCinema(int VoucherID, string CinemaID)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Delete from CinemasDiscount where VoucherID=@VoucherID and CinemaID=@CinemaID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@VoucherID", SqlDbType.Int).Value = VoucherID;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar, 20).Value = CinemaID;
                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        //DeleteMovie

        public int DeleteMovies(string MovieId, string CinemaId)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("DeleteMovie", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MovieId", SqlDbType.VarChar, 20).Value = MovieId;
                cmd.Parameters.Add("@CinemaId", SqlDbType.VarChar, 20).Value = CinemaId;
                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        //DeleteFood

        public int DeleteFoodFromCinema(int FoodId, string CinemaID)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("DeleteFood", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FoodId", SqlDbType.Int).Value = FoodId;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar, 20).Value = CinemaID;
                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }
        //addShows

        public int AddShowForMovie(string ShowID, string CinemaID, string MovieID, DateTime Date_time, string Screen)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("addShows", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ShowID", SqlDbType.VarChar, 20).Value = ShowID;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar, 20).Value = CinemaID;
                cmd.Parameters.Add("@MovieID", SqlDbType.VarChar, 20).Value = MovieID;
                cmd.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = Date_time;
                cmd.Parameters.Add("@Screen", SqlDbType.VarChar, 20).Value = Screen;
                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        /* AdminCinemas
@AdminID int*/

        public int ViewAdminCinemas(int AdminID, ref DataTable result)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("AdminCinemas", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AdminID", SqlDbType.Int).Value = AdminID;
                cmd.ExecuteNonQuery();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results

                result = ds.Tables[0]; //fill the results in ref input table


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        //GetAdminFoodDetails
        public int AdminFoodsList(int AdminID, ref DataTable result)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Select I.ItemID,I.ItemName,I.Price from FoodItemsAdmin F join FoodItems I on I.ItemID=F.ItemID where AdminID=@AdminID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@AdminID", SqlDbType.Int).Value = AdminID;
                cmd.ExecuteNonQuery();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results

                result = ds.Tables[0]; //fill the results in ref input table


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }


        //GetAdminFoodID
        public int AdminFoods(int AdminID, ref DataTable result)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Select ItemID from FoodItemsAdmin where AdminID=@AdminID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@AdminID", SqlDbType.Int).Value = AdminID;
                cmd.ExecuteNonQuery();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results

                result = ds.Tables[0]; //fill the results in ref input table


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }


        /*AdminCinemasFoods
@AdminID int*/
        public int AdminCinemaFoods(int AdminID, ref DataTable result)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("AdminCinemasFoods", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AdminID", SqlDbType.Int).Value = AdminID;
                cmd.ExecuteNonQuery();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results

                result = ds.Tables[0]; //fill the results in ref input table


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;

        }

        //AdminShowtimings
        public int AdminViewShowtimings(int AdminID, ref DataTable result)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("AdminShowtimings", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AdminID", SqlDbType.Int).Value = AdminID;
                cmd.ExecuteNonQuery();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results

                result = ds.Tables[0]; //fill the results in ref input table


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }
        //ViewDiscounts

        public int AdminViewDiscounts(int AdminID, ref DataTable result)
        {

            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("ViewDiscounts", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AdminID", SqlDbType.Int).Value = AdminID;
                cmd.ExecuteNonQuery();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds); //get results

                result = ds.Tables[0]; //fill the results in ref input table


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }
        public int UpdateFoodBill(int TotalMoney, int UserID)
        {


            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("update UsersList set UserMoney=UserMoney+@TotalMoney  where UserId=@UserID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@TotalMoney", SqlDbType.Int).Value = TotalMoney;
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;
        }

        //update cinema earning
        public int UpdateCinemaEarning(int TotalMoney, string CinemaID)
        {


            DataSet ds = new DataSet();
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("update Cinemas set TotalEarning=TotalEarning+@TotalMoney where CinemaID=@CinemaID", Con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@TotalMoney", SqlDbType.Int).Value = TotalMoney;
                cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar, 20).Value = CinemaID;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                Con.Close();
            }
            return 1;

        }

       public int  AdminCinemas(int AdminID, ref DataTable GetData)
       {

           DataSet ds = new DataSet();
           SqlConnection Con = new SqlConnection(constring);
           Con.Open();
           SqlCommand cmd;
           try
           {
               cmd = new SqlCommand("select CinemaName,CinemaID,Locations from Cinemas where AdminID=@AdminID", Con);
               cmd.CommandType = CommandType.Text;
               cmd.Parameters.Add("@AdminID", SqlDbType.Int).Value = AdminID;
               cmd.ExecuteNonQuery();
               using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   da.Fill(ds); //get results
               GetData = ds.Tables[0];

           }
           catch (SqlException ex)
           {
               Console.WriteLine("SQL Error" + ex.Message.ToString());
               return 0;
           }
           finally
           {
               Con.Close();
           }
           return 1;
       }
       public int RemoveCinema(string CinemaID)
       {

           DataSet ds = new DataSet();
           SqlConnection Con = new SqlConnection(constring);
           Con.Open();
           SqlCommand cmd;
           try
           {
               cmd = new SqlCommand("update Cinemas set AdminID=NULL where CinemaID=@CinemaID ", Con);
               cmd.CommandType = CommandType.Text;
               cmd.Parameters.Add("@CinemaID", SqlDbType.VarChar,20).Value = CinemaID;
               cmd.ExecuteNonQuery();

           }
           catch (SqlException ex)
           {
               Console.WriteLine("SQL Error" + ex.Message.ToString());
               return 0;
           }
           finally
           {
               Con.Close();
           }
           return 1;
       }
        //add movieID in images list
       public int MovieIDInImages(int ImageID,string MovieID)
       {

           DataSet ds = new DataSet();
           SqlConnection Con = new SqlConnection(constring);
           Con.Open();
           SqlCommand cmd;
           SqlCommand cmd1;
           try
           {
               cmd = new SqlCommand("update Images set MovieID=@MovieID where ImageID=@ImageID ", Con);
               cmd.CommandType = CommandType.Text;
               cmd.Parameters.Add("@ImageID", SqlDbType.Int).Value = ImageID;
               cmd.Parameters.Add("@MovieID", SqlDbType.VarChar,20).Value = MovieID;
               cmd.ExecuteNonQuery();
               cmd1 = new SqlCommand("delete from Images where MovieID=null", Con);
               cmd1.CommandType = CommandType.Text;
               cmd1.ExecuteNonQuery();
               
           }
           catch (SqlException ex)
           {
               Console.WriteLine("SQL Error" + ex.Message.ToString());
               return 0;
           }
           finally
           {
               Con.Close();
           }
           return 1;
       }
        //get movie name
       public int MovieName(string MovieID,ref string MovieName )
       {

           DataSet ds = new DataSet();
           SqlConnection Con = new SqlConnection(constring);
           Con.Open();
           SqlCommand cmd;
           try
           {
               cmd = new SqlCommand("select @MovieName=MovieName from Movies where MovieID=@MovieID", Con);
               cmd.CommandType = CommandType.Text;
               cmd.Parameters.Add("@MovieID", SqlDbType.VarChar, 20).Value = MovieID;
               SqlParameter ReturnValue = new SqlParameter("@MovieName", SqlDbType.VarChar, 20);
               ReturnValue.Direction = ParameterDirection.Output;
               cmd.Parameters.Add(ReturnValue);
               cmd.ExecuteNonQuery();
               MovieName = cmd.Parameters["@MovieName"].Value.ToString();

           }
           catch (SqlException ex)
           {
               Console.WriteLine("SQL Error" + ex.Message.ToString());
               return 0;
           }
           finally
           {
               Con.Close();
           }
           return 1;
       }

    }
}




