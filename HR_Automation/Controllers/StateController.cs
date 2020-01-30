using EmployeeDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HR_Automation.Controllers
{
    [BasicAuthentication]
    public class StateController : ApiController
    {
        public IEnumerable<state> Get()
        {
            using (lapo_hrEntities entities = new lapo_hrEntities())
            {
                return entities.state.ToList();
            }
        }
        public HttpResponseMessage Post([FromBody]state newstate)
        {
            using (lapo_hrEntities entities = new lapo_hrEntities())
            {
                entities.state.Add(newstate);
                entities.SaveChanges();

                var message = Request.CreateResponse(HttpStatusCode.Created, "country added successfully");
                return message;
            }
        }
    }
}
