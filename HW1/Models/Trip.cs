using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW1.Models
{
    public class Trip
    {
        string tripID;
        int durationInMinute;
        string image;
        string intro;
        string title;
        double score;
        string openingHour;
        double price;

        public Trip(string tripID, int durationInMinute, string image, string intro, string title, double score, string openingHour, double price)
        {
            this.tripID = tripID;
            this.durationInMinute = durationInMinute;
            this.image = image;
            this.intro = intro;
            this.title = title;
            this.score = score;
            this.openingHour = openingHour;
            this.price = price;
        }
        public Trip() { }
        public string TripID { get => tripID; set => tripID = value; }
        public int DurationInMinute { get => durationInMinute; set => durationInMinute = value; }
        public string Image { get => image; set => image = value; }
        public string Intro { get => intro; set => intro = value; }
        public string Title { get => title; set => title = value; }
        public double Score { get => score; set => score = value; }
        public string OpeningHour { get => openingHour; set => openingHour = value; }
        public double Price { get => price; set => price = value; }
    }
}