using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW1.Models
{
    public class Order
    {

        int orderID;
        string passengersNames;
        string email;
        
        Flight flight;



        public Order()
        {
          
        }

        public Order(int orderID, string passengersNames, string email, Flight flight)
        {
            this.orderID = orderID;
            this.passengersNames = passengersNames;
            this.email = email;
            
            this.flight = flight;
        }

        public int OrderID { get => orderID; set => orderID = value; }
        public string PassengersNames { get => passengersNames; set => passengersNames = value; }
        public string Email { get => email; set => email = value; }
        
        public Flight Flight { get => flight; set => flight = value; }

        public Order getOrders()
        {
            DBservices db = new DBservices();
            return db.getOrders();
        }


    }
}