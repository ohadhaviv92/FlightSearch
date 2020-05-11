using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW1.Models
{
    public class Airport
    {
        string airportcode;
        string airportname;
        string longitude;
        string latitudes;
        string city;
        string coutry;

        public Airport(string airportcode, string airportname, string longitude, string latitudes, string city, string coutry)
        {
            Airportcode = airportcode;
            Airportname = airportname;
            Longitude = longitude;
            Latitudes = latitudes;
            City = city;
            Coutry = coutry;
        }

        public string Airportcode { get => airportcode; set => airportcode = value; }
        public string Airportname { get => airportname; set => airportname = value; }
        public string Longitude { get => longitude; set => longitude = value; }
        public string Latitudes { get => latitudes; set => latitudes = value; }
        public string City { get => city; set => city = value; }
        public string Coutry { get => coutry; set => coutry = value; }

        public int insert()
        {
            DBservices db = new DBservices();
            db.insert(this);
            return 0;
        }
    }
}