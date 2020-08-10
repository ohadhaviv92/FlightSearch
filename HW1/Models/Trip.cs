using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW1.Models
{
    public class Trip
    {
        string tripID;
        string duration;
        string image;
        string intro;
        string title;
        double score;
        string openingHour;

        public Trip(string tripID, string duration, string image, string intro, string title, double score, string openingHour)
        {
            this.tripID = tripID;
            this.duration = duration;
            this.image = image;
            this.intro = intro;
            this.title = title;
            this.score = score;
            this.openingHour = openingHour;
        }

        public string TripID { get => tripID; set => tripID = value; }
        public string Duration { get => duration; set => duration = value; }
        public string Image { get => image; set => image = value; }
        public string Intro { get => intro; set => intro = value; }
        public string Title { get => title; set => title = value; }
        public double Score { get => score; set => score = value; }
        public string OpeningHour { get => openingHour; set => openingHour = value; }
    }
}