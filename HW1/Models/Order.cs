using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW1.Models
{
    public class Order
    {

        
        string passengersNames;
        string email;
        DateTime orderDate;
        int[] tourNumbers;


        Flight flight;



        public Order()
        {
          
        }

        public Order( string passengersNames, string email, Flight flight,DateTime orderDate)
        {
            
            this.passengersNames = passengersNames;
            this.email = email;
            this.orderDate = orderDate;
            this.flight = flight;
        }
        public Order(string passengersNames, string email, Flight flight, DateTime orderDate,int[] tourNumbers)
        {

            this.passengersNames = passengersNames;
            this.email = email;
            this.orderDate = orderDate;
            this.flight = flight;
            TourNumbers = tourNumbers;
        }


        public string PassengersNames { get => passengersNames; set => passengersNames = value; }
        public string Email { get => email; set => email = value; }
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
        public Flight Flight { get => flight; set => flight = value; }
        public int[] TourNumbers { get => tourNumbers; set => tourNumbers = value; }

        public List<Order> getOrders()
        {
            DBservices db = new DBservices();
            return db.getOrders();
        }


    }
}