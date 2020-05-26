using HW1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HW1.Controllers
{
    public class DiscountController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Discount> Get()
        {
            Discount discount = new Discount();

            return discount.getDiscounts();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]Discount discount)
        {
            DBservices db = new DBservices();
            db.addDiscount(discount);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete([FromBody]int discountId)
        {
            Discount.deleteDiscount(discountId);
        }
    }
}