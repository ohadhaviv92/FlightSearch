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
        
        Flight flight;



        public Order()
        {
          
        }

        public Order( string passengersNames, string email, Flight flight)
        {
            
            this.passengersNames = passengersNames;
            this.email = email;
            
            this.flight = flight;
        }

       
        public string PassengersNames { get => passengersNames; set => passengersNames = value; }
        public string Email { get => email; set => email = value; }
        
        public Flight Flight { get => flight; set => flight = value; }

        public List<Order> getOrders()
        {
            DBservices db = new DBservices();
            return db.getOrders();
        }


    }
}