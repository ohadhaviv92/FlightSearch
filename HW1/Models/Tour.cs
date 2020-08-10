using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW1.Models
{
    public class Tour
    {

        
        string agencyName;
        string tourName;
        string city;
        double tourPrice;
        int durationInMinute;
        List<Trip> trips;

        public Tour() { }
        public Tour( string agencyName, string tourName, string city, double tourPrice, int durationInMinute, List<Trip> trips)
        {
            
            this.agencyName = agencyName;
            this.tourName = tourName;
            this.city = city;
            this.tourPrice = tourPrice;
            this.durationInMinute = durationInMinute;
            this.trips = trips;
        }

        
        public string AgencyName { get => agencyName; set => agencyName = value; }
        public string TourName { get => tourName; set => tourName = value; }
        public double TourPrice { get => tourPrice; set => tourPrice = value; }
        public int DurationInMinute { get => durationInMinute; set => durationInMinute = value; }
        public List<Trip> Trips { get => trips; set => trips = value; }
        public string City { get => city; set => city = value; }

        public void insert()
        {

            DBservices db = new DBservices();
            db.insert(this);
            
        }
    }
}