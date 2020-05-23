using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW1.Models
{
    public class Discount
    {
        string airlineCode;
        string airportCodeFrom;
        string airportCodeTo;
        DateTime dateFrom;
        DateTime dateTo;
        double discountAmount;

        public Discount()
        {
        }

        public Discount(string airlineCode, string airportCodeFrom, string airportCodeTo, DateTime dateFrom, DateTime dateTo, float discountAmount)
        {
            this.airlineCode = airlineCode;
            this.airportCodeFrom = airportCodeFrom;
            this.airportCodeTo = airportCodeTo;
            this.dateFrom = dateFrom;
            this.dateTo = dateTo;
            this.discountAmount = discountAmount;
        }

        public string AirlineCode { get => airlineCode; set => airlineCode = value; }
        public string AirportCodeFrom { get => airportCodeFrom; set => airportCodeFrom = value; }
        public string AirportCodeTo { get => airportCodeTo; set => airportCodeTo = value; }
        public DateTime DateFrom { get => dateFrom; set => dateFrom = value; }
        public DateTime DateTo { get => dateTo; set => dateTo = value; }
        public double DiscountAmount { get => discountAmount; set => discountAmount = value; }

        public List<Discount> getDiscounts()
        {
            DBservices db = new DBservices();
            return db.getDiscounts();
        }

        public Discount deleteDiscount()
        {
            DBservices db = new DBservices();
            return db.deleteDiscount(this);
        }

        public int addDiscount()
        {
            DBservices db = new DBservices();
            return db.addDiscount(this);
        }


    }
}