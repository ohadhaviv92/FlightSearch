﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HW1.Models;

namespace HW1.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        public User Get(string username)
        {
            User us = new User();
            return us.getUser(username);
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
