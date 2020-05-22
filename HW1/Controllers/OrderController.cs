using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HW1.Models;
using Microsoft.Ajax.Utilities;

namespace HW1.Controllers
{
    public class OrderController : ApiController
    {
  


        // GET: api/Order/5
        public Order Get()
        {

            Order or = new Order();

            return or.getOrders(); 
        }

        // POST: api/Order
        public void Post([FromBody]string[] values)
        {
            DBservices db = new DBservices();
            db.insertOrder(values);
        }

        // PUT: api/Order/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Order/5
        public void Delete(int id)
        {
        }
    }
}
