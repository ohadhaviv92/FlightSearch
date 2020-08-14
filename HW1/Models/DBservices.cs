using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Globalization;

/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
namespace HW1.Models
{
    public class DBservices
    {
        public SqlDataAdapter da;
        public DataTable dt;

        public DBservices()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public string editDiscount(Discount discount)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);

            }

            String cStr = "UPDATE discounts set AirlineCode = '"+discount.AirlineCode+"', AirportCodeFrom = '"+discount.AirportCodeFrom+"', AirportCodeTo = '"+discount.AirportCodeTo+"', DateFrom = '"+discount.DateFrom.ToShortDateString()+"', DateTo='"+discount.DateTo.ToShortDateString()+"', discount = "+discount.DiscountAmount+" where id = "+discount.Id ;      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                string numEffected = (string)cmd.ExecuteScalar(); // execute the command

                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        public int addDiscount(Discount discount)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommand(discount);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {

                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        public string deleteDiscount(int discountId)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
                
            }

            String cStr = "DELETE FROM discounts where id = "+ discountId+"" ;      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                string numEffected = (string)cmd.ExecuteScalar(); // execute the command

                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        public int insertOrder(string[] order)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommand(order);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        public int registerAgent(Agent ag)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommand(ag);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {

                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }


        public List<Order> getOrders()
        {
            SqlConnection con = null;

            try
            {

                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from orders as o join MyFlights_CS as f on f.FlightPath = o.flightId";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                List<Order> list = new List<Order>();
                while (dr.Read())
                {   // Read till the end of the data into a row
                    Order ord = new Order();
                    ord.Email= (string)dr["userEmail"];
                    ord.OrderDate = (DateTime)dr["orderDate"];
                 
                    Flight f= new Flight((string)dr["flightId"], (string)dr["AirportFrom"], (string)dr["AirportTo"], (DateTime)dr["DepTime"], (DateTime)dr["ArriveTime"], (string)dr["Duration"], float.Parse(dr["Price"].ToString()), (int)dr["LegsNumber"]);
                    ord.PassengersNames= (string)dr["passengersNames"];
                    ord.Flight = f;
                    list.Add(ord);

                }

                return list;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }


            return null;
        }


        public List<Tour> getTours(string agencyID)
        {
            SqlConnection con = null;

            try
            {

                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from Tour_CS where agentName="+agencyID;
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                List<Tour> list = new List<Tour>();
                while (dr.Read())
                {   // Read till the end of the data into a row
                    Tour tour = new Tour();
                    tour.TourID = (int)dr["tourID"];
                    tour.TourName = (string)dr["tourName"];
                    tour.City = (string)dr["city"];
                    tour.TourPrice = (double)dr["price"];
                    tour.DurationInMinute = (int)dr["durationInMinute"];
                    list.Add(tour);

                }

                return list;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }


            return null;
        }

        public List<Tour> getAllTours()
        {
            SqlConnection con = null;

            try
            {

                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from Tour_CS";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                List<Tour> list = new List<Tour>();
                while (dr.Read())
                {   // Read till the end of the data into a row
                    Tour t = new Tour();
                    t.AgencyName = (string)dr["agentName"];
                    t.City= (string)dr["city"];
                    t.TourName = (string)dr["tourName"];
                    t.TourPrice = (double)dr["price"];
                    t.TourID= (int)dr["TourID"];
                    t.DurationInMinute = (int)dr["durationInMinute"];
                    t.Trips = getAllTrips((int)dr["TourID"]);
                    list.Add(t);
                }
                
                return list;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }




            return null;
        }


        public List<Trip> getAllTrips(int tourID)
        {
            SqlConnection con = null;

            try
            {

                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from TripInTour_CS where TourID ='"+ tourID+"'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                List<Trip> list = new List<Trip>();
                while (dr.Read())
                {   // Read till the end of the data into a row
                    Trip t = new Trip();
                    t.TripID = (string)dr["tripID"];
                    t.DurationInMinute = (int)dr["durationInMinute"];
                    t.Price = (double)dr["price"];
                    t.Image = (string)dr["image"];
                    t.Score = (double)dr["score"];
                    t.Intro = (string)dr["intro"];
                    t.Title = (string)dr["title"];
                    t.OpeningHour = (string)dr["openingHour"];
                    list.Add(t);
                }

                return list;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }




            return null;
        }

        public List<Discount> getDiscounts()
        {
            SqlConnection con = null;

            try
            {

                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from discounts";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                List<Discount> list = new List<Discount>();
                while (dr.Read())
                {   // Read till the end of the data into a row
                    Discount discount = new Discount();
                    discount.Id = (int)dr["id"];
                    discount.AirlineCode = (string)dr["AirlineCode"];
                    discount.AirportCodeFrom = (string)dr["AirportCodeFrom"];
                    discount.AirportCodeTo = (string)dr["AirportCodeTo"];
                    discount.DateFrom = (DateTime)dr["DateFrom"];
                    discount.DateTo = (DateTime)dr["DateTo"];
                    discount.DiscountAmount = (double)dr["discount"];
                    list.Add(discount);

                }

                return list;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }




            return null;
        }

        //--------------------------------------------------------------------------------------------------
        // This method creates a connection to the database according to the connectionString name in the web.config 
        //--------------------------------------------------------------------------------------------------
        public SqlConnection connect(String conString)
        {

            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }

        //--------------------------------------------------------------------------------------------------
        // This method inserts a car to the cars table 
        //--------------------------------------------------------------------------------------------------

        public User getUser(string userName)
        {
            
            SqlConnection con = null;

            try
            {

                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM users where username = '" + userName + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                User us = new User();
                while (dr.Read())
                {   // Read till the end of the data into a row
                    

                    us.UserName = (string)dr["username"];
                    us.Password = (string)dr["password"];
                    us.IsAdmin = (string)dr["isAdmin"];
                    
                }

                return us;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }




            return null;
        }

        public string agentLogin(string[] logins)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = "select * from TourAgent_CS u where u.agentName='" + logins[0] + "' and u.pass='" + logins[1] + "'";      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                string numEffected = (string)cmd.ExecuteScalar(); // execute the command

                return numEffected;
            }
            catch (Exception ex)
            {
                return "";
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        public string login(string[] logins)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = "select * from users u where u.username='"+ logins[0]+ "' and u.password='"+ logins[1]+ "'";      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                string numEffected = (string)cmd.ExecuteScalar(); // execute the command

                return numEffected;
            }
            catch (Exception ex)
            {
                return "";
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }


        public string check(string tableName)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = "select top(1) * from "+ tableName;      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                string numEffected = (string)cmd.ExecuteScalar(); // execute the command

                return numEffected;
            }
            catch (Exception ex)
            {
                return "";
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }



        public int insert(Airline[] airline)
        {
            int numEffected = 0;
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            for (int i = 0; i < airline.Length; i++)
            {
                String cStr = BuildInsertCommand(airline[i]);      // helper method to build the insert string

                cmd = CreateCommand(cStr, con);             // create the command
                try
                {
                    numEffected = cmd.ExecuteNonQuery(); // execute the command

                }
                catch (Exception ex)
                {
                    continue;
                }
            }



            if (con != null)
            {
                // close the db connection
                con.Close();
            }

            return numEffected;

        }

        public void insert(Tour tour)
        {

            SqlConnection con;
            SqlCommand cmd;
            
            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommand(tour);      // add tour ang getId of tour

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                Int32 id = Convert.ToInt32(cmd.ExecuteScalar()); // execute the command


                for (int i = 0; i < tour.Trips.Count; i++)
                {
                    try
                    {
                        cStr = BuildInsertCommand((Trip)tour.Trips[i], id);
                        cmd = CreateCommand(cStr, con);             // create the command
                        cmd.ExecuteNonQuery(); // execute the command

                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                }
                


            }
            catch (Exception ex)
            {
                
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        public int insert(Airport[] airport)
        {
            int numEffected = 0;
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            for (int i = 0; i < airport.Length; i++)
            {
                String cStr = BuildInsertCommand(airport[i]);      // helper method to build the insert string

                cmd = CreateCommand(cStr, con);             // create the command
                try
                {
                    numEffected = cmd.ExecuteNonQuery(); // execute the command
                    
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            

            
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            
            return numEffected;

        }

        public string insert(Flight flight)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            int flag = 0;
            
            try
            {
                String cStr2 = "select * from MyFlights_CS where FlightPath='" + flight.FlightPath1.ToString()+"'";
                SqlCommand cmd2 = new SqlCommand(cStr2, con);

                // get a reader
                SqlDataReader dr = cmd2.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                
                while (dr.Read())
                {
                    flag = 1;
                }
                return 0;
                    
            }
            catch (Exception)
            {

                throw;
            }

            if (flag == 0)
            {
                String cStr = BuildInsertCommand(flight);      // helper method to build the insert string

                cmd = CreateCommand(cStr, con);             // create the command
                try
                {

                    return cmd.ExecuteNonQuery(); // execute the command

                }
                catch (Exception ex)
                {

                    // write to log
                    throw (ex);
                }

                finally
                {
                    if (con != null)
                    {
                        // close the db connection
                        con.Close();
                    }
                }
            }

        }

        public int insert(Leg l)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommand(l);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                return 0;
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        //--------------------------------------------------------------------
        // Build the Insert command String
        //--------------------------------------------------------------------


        private String BuildInsertCommand(Agent ag)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            //use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}')", ag.AgentName, ag.AgentImage, ag.Password);
            String prefix = "INSERT INTO TourAgent_CS " + "(agentName,agentImage,pass) ";
            command = prefix + sb.ToString();

            return command;
        }

        private String BuildInsertCommand(Trip trip , int id)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            //use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}','{3}','{4}', '{5}', '{6}','{7}','{8}')", id, trip.TripID, trip.Image, trip.Intro.Replace("'",""),trip.Title.Replace("'", ""), trip.OpeningHour,trip.Score,trip.DurationInMinute,trip.Price);
            String prefix = "INSERT INTO TripInTour_CS " + "(TourID, tripID,image,intro,title,openingHour,score,durationInMinute,price) ";
            command = prefix + sb.ToString();
            return command;
        }
        private String BuildInsertCommand(Tour tour)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            //use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}','{3}','{4}')", tour.AgencyName, tour.TourName, tour.TourPrice,tour.DurationInMinute,tour.City);
            String prefix = "INSERT INTO Tour_CS " + "(agentName,tourName,price,durationInMinute,city) ";
            command = prefix + sb.ToString();
            command += "SELECT SCOPE_IDENTITY()";
            return command;
        }

        private String BuildInsertCommand(Discount discount)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            //use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}','{3}','{4}','{5}')", discount.AirlineCode, discount.AirportCodeFrom,discount.AirportCodeTo,discount.DateFrom.ToShortDateString(), discount.DateTo.ToShortDateString(), discount.DiscountAmount);
            String prefix = "INSERT INTO discounts " + "(AirlineCode, AirportCodeFrom,AirportCodeTo,DateFrom,DateTo,discount) ";
            command = prefix + sb.ToString();
            return command;
        }

        private String BuildInsertCommand(string[] order)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            //use a string builder to create the dynamic string
            
            sb.AppendFormat("Values('{0}', '{1}', '{2}','{3}','{4}')", order[0], order[1],order[2], order[3],order[4]);
            String prefix = "INSERT INTO orders " + "(flightid, passengersNames,userEmail,orderDate,packages) ";
            command = prefix + sb.ToString();
            return command;
        }

        private String BuildInsertCommand(Airline airline)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            //use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}')", airline.AirlineCode, airline.AirlineName);
            String prefix = "INSERT INTO Airlines_CS " + "(AirlineCode, AirlineName) ";
            command = prefix + sb.ToString();
            return command;
        }
        private String BuildInsertCommand(Airport airport)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            //use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}' ,'{2}', '{3}', '{4}', '{5}')", airport.Airportcode, airport.Airportname, airport.Longitude, airport.Latitudes,airport.City,airport.Coutry);
            String prefix = "INSERT INTO Airports_CS " + "(AirportCode, Airportname, Longitude, Latitudes, City, Country) ";
            command = prefix + sb.ToString();
            return command;
        }

        private String BuildInsertCommand(Flight flight)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            //use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}' ,'{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", flight.FlightPath1, flight.AirportFrom1, flight.AirportTo1, flight.DepTime1, flight.ArriveTime1, flight.Duration1, flight.Price, flight.LegsNumber1);
            String prefix = "INSERT INTO MyFlights_CS " + "(FlightPath, AirportFrom, AirportTo, DepTime, ArriveTime, Duration, Price, LegsNumber) ";
            command = prefix + " OUTPUT Inserted.FlightPath " + sb.ToString();
            return command;
        }

        private String BuildInsertCommand(Leg l)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            //use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}' ,'{2}', '{3}', '{4}', '{5}', '{6}','{7}','{8}','{9}')", l.Id, l.Fullpathid, l.Legnumber, l.Flight_no, l.Fromairport, l.Toairport,l.Airlinecode, l.DepTime1, l.ArriveTime1,l.Duration1);
            String prefix = "INSERT INTO Legs_CS " + "(id, fullpathid, legnumber, flight_no, fromairport, toairport, airlinecode, DepTime, ArriveTime, Duration) ";
            command = prefix + sb.ToString();
            return command;
        }
        //---------------------------------------------------------------------------------
        // Create the SqlCommand
        //---------------------------------------------------------------------------------
        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 40;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd;
        }
    }
}
