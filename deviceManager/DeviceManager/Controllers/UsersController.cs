using DeviceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeviceManager.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/values
        public List<User> Get()
        {
            var listUser = new List<User>();
            //request bdd : get all
            return listUser;
        }

        // GET api/values/5
        public User Get(int id)
        {
            var User = new User();
            //request bdd : get where id
            return User;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
