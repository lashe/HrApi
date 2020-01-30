using HR_Automation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace HR_Automation.Controllers
{
    public class UsersController : ApiController
    {
        private User[] users = new User[]
   {
        new User { id = 1, name = "Haleemah Redfern", email = "email1@mail.com", phone = "01111111", role = 1},
        new User { id = 2, name = "Aya Bostock", email = "email2@mail.com", phone = "01111111", role = 1},
        new User { id = 3, name = "Sohail Perez", email = "email3@mail.com", phone = "01111111", role = 1},
        new User { id = 4, name = "Merryn Peck", email = "email4@mail.com", phone = "01111111", role = 2},
        new User { id = 5, name = "Cairon Reynolds", email = "email5@mail.com", phone = "01111111", role = 3}
   };


        // GET: api/Users
        [ResponseType(typeof(IEnumerable<User>))]
        public IEnumerable<User> Get()
        {
            return users;
        }

        // GET: api/Users/5
        public IHttpActionResult Get(int id)
        {
            var product = users.FirstOrDefault((p) => p.id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
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
