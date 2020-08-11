using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW1.Models
{
    public class Tour
    {

        int tourID;
        string agencyName;
        string tourName;
        string city;
        double tourPrice;
        int durationInMinute;
        List<Trip> trips;

        public Tour() { }

        public Tour(string agencyName, string tourName, double tourPrice, int durationInMinute, List<Trip> trips, string city, int tourID)
        {
            AgencyName = agencyName;
            TourName = tourName;
            TourPrice = tourPrice;
            DurationInMinute = durationInMinute;
            Trips = trips;
            City = city;
            TourID = tourID;
        }

        public string AgencyName { get => agencyName; set => agencyName = value; }
        public string TourName { get => tourName; set => tourName = value; }
        public double TourPrice { get => tourPrice; set => tourPrice = value; }
        public int DurationInMinute { get => durationInMinute; set => durationInMinute = value; }
        public List<Trip> Trips { get => trips; set => trips = value; }
        public string City { get => city; set => city = value; }
        public int TourID { get => tourID; set => tourID = value; }

        public void insert()
        {

            DBservices db = new DBservices();
            db.insert(this);
            
        }
    }
}