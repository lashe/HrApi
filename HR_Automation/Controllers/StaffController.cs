using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using HR_Automation.Models;
using EmployeeDataAccess;
using System.Web.Http.Controllers;

using System.Web.Http.Filters;
using System.Text;
using System.Data.Entity.Validation;

namespace HR_Automation.Controllers
{
    [BasicAuthentication]
    public class StaffController : ApiController
    {
        private SqlConnection con;
        //GET api/<controller>
        public IEnumerable<employee> Get()
        {
            using (lapo_hrEntities entities = new lapo_hrEntities())
            {
                return entities.employee.ToList();
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]employee newstaff)
        {

            try
            {
                using (lapo_hrEntities entities = new lapo_hrEntities())
                {
                    entities.employee.Add(newstaff);
                    entities.SaveChanges();
                    

                    string latestid = newstaff.staffID;
                    //foreach(Object org_unit in newstaff.orgUnits)
                    //{

                  //  }

                    string authenticationToken = ActionContext.Request.Headers.Authorization.Parameter;
                    string decodedauthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                    string[] emailPasswordArray = decodedauthenticationToken.Split(':');
                    string username = emailPasswordArray[0].ToString();

                    con = new SqlConnection("Data Source=(local);Initial Catalog=lapo_hr;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand("select Staffid from login where email='" + username + "' ", con);
                    SqlDataAdapter amd = new SqlDataAdapter();
                    con.Open();
                    amd.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    amd.Fill(dt);
                    string sid = dt.Rows[0]["staffid"].ToString();

                    var query = "update employee set createdby='" + sid + "',createddt='" + DateTime.Today + "' where staffid='" + latestid + "'";

                    SqlCommand Command = new SqlCommand(query, con);

                    Command.ExecuteNonQuery();
                    con.Close();


                    var status = Request.CreateResponse(HttpStatusCode.Created, "staff " + latestid + " added successfully");
                    var msg1 = Request.CreateResponse("staff added successfully");
                    var id = Request.CreateResponse(latestid);

                    return status;


                }
            }
            catch (Exception ex)
            {
               return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "error", ex);
                
            }
           


            
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