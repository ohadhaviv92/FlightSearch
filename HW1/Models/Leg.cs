using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW1.Models
{
    public class Leg
    {

        string id;
        string fullpathid;
        int legnumber;
        string flight_no;
        string fromairport;
        string toairport;
        string airlinecode;
        DateTime DepTime;
        DateTime ArriveTime;
        string Duration;

        public Leg(string id, string fullpathid, int legnumber, string flight_no, string fromairport, string toairport, string airlinecode, DateTime depTime1, DateTime arriveTime1, string duration1)
        {
            Id = id;
            Fullpathid = fullpathid;
            Legnumber = legnumber;
            Flight_no = flight_no;
            Fromairport = fromairport;
            Toairport = toairport;
            Airlinecode = airlinecode;
            DepTime1 = depTime1;
            ArriveTime1 = arriveTime1;
            Duration1 = duration1;
        }

        public string Id { get => id; set => id = value; }
        public string Fullpathid { get => fullpathid; set => fullpathid = value; }
        public int Legnumber { get => legnumber; set => legnumber = value; }
        public string Flight_no { get => flight_no; set => flight_no = value; }
        public string Fromairport { get => fromairport; set => fromairport = value; }
        public string Toairport { get => toairport; set => toairport = value; }
        public string Airlinecode { get => airlinecode; set => airlinecode = value; }
        public DateTime DepTime1 { get => DepTime; set => DepTime = value; }
        public DateTime ArriveTime1 { get => ArriveTime; set => ArriveTime = value; }
        public string Duration1 { get => Duration; set => Duration = value; }

        public int insert()
        {
            DBservices db = new DBservices();
            db.insert(this);
            return 0;
        }
    }
}