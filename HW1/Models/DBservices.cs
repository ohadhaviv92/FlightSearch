using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;


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

        public string checkAirport()
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

            String cStr = "select top(1) * from Airports_CS";      // helper method to build the insert string

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



        public int insert(Airline airline)
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

            String cStr = BuildInsertCommand(airline);      // helper method to build the insert string

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



        public int insert(Airport airport)
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

            String cStr = BuildInsertCommand(airport);      // helper method to build the insert string

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
        //private String BuildInsertCommand(Flight car)
        //{
        //    String command;

        //    StringBuilder sb = new StringBuilder();
        //    // use a string builder to create the dynamic string
        //    //sb.AppendFormat("Values('{0}', '{1}' ,{2}, {3})", car.Model, car.Manufacturer, car.Year.ToString(), car.Price.ToString());
        //    //String prefix = "INSERT INTO Cars_CS " + "(model, manufacturer, year, price) ";
        //    //command = prefix + sb.ToString();

        //    command = "tesdt";//need to remove!!!!! 
        //    return command;
        //}

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
        //---------------------------------------------------------------------------------
        // Create the SqlCommand
        //---------------------------------------------------------------------------------
        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 20;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd;
        }
    }
}
