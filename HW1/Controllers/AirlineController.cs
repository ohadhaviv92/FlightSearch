using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HW1.Models;


using System.Net;
using System.Net.Http;


namespace HW1.Controllers
{
    public class AirlineController : ApiController
    {
        // GET api/<controller>
        public string Get()
        {
            return Airline.checkTable();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]Airline airline)
        {
            airline.insert();
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