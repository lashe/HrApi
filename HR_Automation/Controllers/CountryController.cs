using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace HR_Automation.Controllers
{
    public class CountryController : ApiController
    {
        private SqlConnection con;

        public IEnumerable<country> Get()
        {
            using (lapo_hrEntities entities = new lapo_hrEntities())
            {
                return entities.country.ToList();
            }
        }
        public HttpResponseMessage Post([FromBody]country newcountry)
        {
            try
            {
                using (lapo_hrEntities entities = new lapo_hrEntities())
                {
                    entities.country.Add(newcountry);
                    entities.SaveChanges();

                    string newcnt = newcountry.countryname;

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

                    var query = "update country set createdby='" + sid + "',createddt='" + DateTime.Today + "' where countryname='" + newcnt + "'";

                    SqlCommand Command = new SqlCommand(query, con);

                    Command.ExecuteNonQuery();
                    con.Close();

                    var message = Request.CreateResponse(HttpStatusCode.Created, "country '" + newcnt + "' added successfully");
                    return message;
                }
            }
            catch (Exception)
            {
               return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"error");
               
            }
        }


    }
}
