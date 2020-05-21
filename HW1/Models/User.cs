using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW1.Models
{
    public class User
    {

        string userName;
        string password;
        string isAdmin;

        public User()
        {
           
        }

        

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string IsAdmin { get => isAdmin; set => isAdmin = value; }


        public User getUser(string username)
        {
            DBservices dbs = new DBservices();
            return dbs.getUser(username);

        }
    }
}