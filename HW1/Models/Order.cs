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
        User user;
        Flight flight;



        public Order()
        {
          
        }

        public Order(int orderID, string passengersNames, string email, User user, Flight flight)
        {
            this.orderID = orderID;
            this.passengersNames = passengersNames;
            this.email = email;
            this.user = user;
            this.flight = flight;
        }

        public int OrderID { get => orderID; set => orderID = value; }
        public string PassengersNames { get => passengersNames; set => passengersNames = value; }
        public string Email { get => email; set => email = value; }
        public User User { get => user; set => user = value; }
        public Flight Flight { get => flight; set => flight = value; }

        public Order getOrders()
        {
            DBservices db = new DBservices();
            return db.getOrders();
        }


    }
}