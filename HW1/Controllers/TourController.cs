using HW1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HW1.Controllers
{
    public class TourController : ApiController
    {
  

        // GET: api/Tour/5
        public List<Tour> Get()
        {
            DBservices db = new DBservices();
            return db.getAllTours();
        }

        // POST: api/Tour
        public void Post([FromBody]Tour tour)
        {
            tour.insert();
        }

        // PUT: api/Tour/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tour/5
        public void Delete(int id)
        {
        }
    }
}
