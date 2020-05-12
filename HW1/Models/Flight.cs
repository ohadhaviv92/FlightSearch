using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW1.Models
{
    public class Flight
    {
        private static List<Flight> flightList = new List<Flight>();
        string FlightPath;
        string AirportFrom;
        string AirportTo;
        string DepTime;
        string ArriveTime;
        string Duration;
        float price;
        int LegsNumber;
        List<Leg> stops = new List<Leg>();

        public Flight(string flightPath1, string airportFrom1, string airportTo1, string depTime1, string arriveTime1, string duration1, float price, int legsNumber1, List<Leg> stops)
        {
            FlightPath1 = flightPath1;
            AirportFrom1 = airportFrom1;
            AirportTo1 = airportTo1;
            DepTime1 = depTime1;
            ArriveTime1 = arriveTime1;
            Duration1 = duration1;
            Price = price;
            LegsNumber1 = legsNumber1;
            Stops = stops;
        }

        public static List<Flight> FlightList { get => flightList; set => flightList = value; }
        public string FlightPath1 { get => FlightPath; set => FlightPath = value; }
        public string AirportFrom1 { get => AirportFrom; set => AirportFrom = value; }
        public string AirportTo1 { get => AirportTo; set => AirportTo = value; }
        public string DepTime1 { get => DepTime; set => DepTime = value; }
        public string ArriveTime1 { get => ArriveTime; set => ArriveTime = value; }
        public string Duration1 { get => Duration; set => Duration = value; }
        public float Price { get => price; set => price = value; }
        public int LegsNumber1 { get => LegsNumber; set => LegsNumber = value; }
        public List<Leg> Stops { get => stops; set => stops = value; }


   
        public int insert()
        {
            DBservices db = new DBservices();
            db.insert(this);
            return 0;
        }   
    }


}