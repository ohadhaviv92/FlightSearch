using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW1.Models
{
    public class Airline
    {

        string airlineCode;
        string airlineName;

        public Airline(string airlineCode, string airlineName)
        {
            this.airlineCode = airlineCode;
            this.airlineName = airlineName;
        }

        public string AirlineCode { get => airlineCode; set => airlineCode = value; }
        public string AirlineName { get => airlineName; set => airlineName = value; }


        public static int insert(Airline[] airline)
        {
            DBservices db = new DBservices();
            db.insert(airline);
            return 0;
        }

        public static string checkTable()
        {
            DBservices db = new DBservices();
            return db.check("Airlines_CS");

        }
    }
}