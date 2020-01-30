using EmployeeDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace HR_Automation.Controllers
{
    public class IdentificationController : ApiController
    {
        private SqlConnection con;

        // GET: api/Identification
        public IEnumerable<identification> Get()
        {
            using (lapo_hrEntities entities = new lapo_hrEntities())
            {
                return entities.identification.ToList();
            }
        }

        // GET: api/Identification/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Identification
        public HttpResponseMessage Post([FromBody]identification newid)
        {
            try
            {
                using (lapo_hrEntities entities = new lapo_hrEntities())
                {
                    entities.identification.Add(newid);
                    entities.SaveChanges();

                    string newidd = newid.idtype;

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

                    var query = "update identification set createdby='" + sid + "',createddt='" + DateTime.Today + "' where idtype='" + newidd + "'";

                    SqlCommand Command = new SqlCommand(query, con);

                    Command.ExecuteNonQuery();
                    con.Close();

                    var message = Request.CreateResponse(HttpStatusCode.Created, "'" + newidd + "' added successfully");
                    return message;
                }
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "error");
            }
        }

        // PUT: api/Identification/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Identification/5
        public void Delete(int id)
        {
        }
    }
}
