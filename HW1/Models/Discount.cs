using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW1.Models
{
    public class Discount
    {
        string airlineCode;
        string AirportCodeFrom;
        string AirportCodeTo;
        DateTime DateFrom;
        DateTime DateTo;
        float discount;

        public string AirlineCode { get => airlineCode; set => airlineCode = value; }
        public string AirportCodeFrom1 { get => AirportCodeFrom; set => AirportCodeFrom = value; }
        public string AirportCodeTo1 { get => AirportCodeTo; set => AirportCodeTo = value; }
  
      
    }
}