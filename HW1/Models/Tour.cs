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
        double tourPrice;
        int duration;
        List<Trip> trips;

        public Tour(string agencyName, string tourName, double tourPrice, int duration, List<Trip> trips)
        {
            
            this.agencyName = agencyName;
            this.tourName = tourName;
            this.tourPrice = tourPrice;
            this.duration = duration;
            this.trips = trips;
        }

        
        public string AgencyName { get => agencyName; set => agencyName = value; }
        public string TourName { get => tourName; set => tourName = value; }
        public double TourPrice { get => tourPrice; set => tourPrice = value; }
        public int Duration { get => duration; set => duration = value; }
        public List<Trip> Trips { get => trips; set => trips = value; }
    }
}