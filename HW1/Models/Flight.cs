using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW1.Models
{
    public class Flight
    {
        static public List<Flight> flightList = new List<Flight>();
        string from;
        string to;
        double price;
        string depTime;
        string arriveTime;
        List<string> stops = new List<string>();
        string airlineName;

        public Flight(string from, string to, double price, string depTime, string arriveTime, List<string> stops, string airlineName)
        {
            this.from = from;
            this.to = to;
            this.price = price;
            this.depTime = depTime;
            this.arriveTime = arriveTime;
            this.Stops = stops;
            this.airlineName = airlineName;
        }

        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }
        public double Price { get => price; set => price = value; }
        public string DepTime { get => depTime; set => depTime = value; }
        public string ArriveTime { get => arriveTime; set => arriveTime = value; }
       
        public string AirlineName { get => airlineName; set => airlineName = value; }
        public List<string> Stops { get => stops; set => stops = value; }

        public int insert()
        {
            flightList.Add(this);
            return 1;
        }   
    }


}