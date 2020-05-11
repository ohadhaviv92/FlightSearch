using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HW1.Models;

namespace HW1.Controllers
{
    public class FlightController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Flight> Get()
        {
            return Flight.flightList;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]Flight flight)
        {
            flight.insert();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}