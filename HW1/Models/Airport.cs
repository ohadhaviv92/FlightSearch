using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW1.Models
{
    public class Airport
    {
        int airportcode;
        string airportname;
        int longitude;
        int latitudes;
        string city;
        string coutry;

        public Airport(int airportcode, string airportname, int longitude, int latitudes, string city, string coutry)
        {
            Airportcode = airportcode;
            Airportname = airportname;
            Longitude = longitude;
            Latitudes = latitudes;
            City = city;
            Coutry = coutry;
        }

        public int Airportcode { get => airportcode; set => airportcode = value; }
        public string Airportname { get => airportname; set => airportname = value; }
        public int Longitude { get => longitude; set => longitude = value; }
        public int Latitudes { get => latitudes; set => latitudes = value; }
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