using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using HR_Automation.Models;
using System.Web;
using EmployeeDataAccess;
using System.Data.SqlClient;
using System.Data;

namespace HR_Automation.Controllers
{
    public class LoginController : ApiController
    {
        private SqlConnection con;
        [BasicAuthentication]
        
       public HttpResponseMessage Get()
        {

            // login lgn = new login();
            //var token = lgn.access_token;
            //var token = ActionContext.Request.Headers.Authorization.Parameter;
            //var msg = "success";
            //var collection = new Dictionary<string, object>();
            //collection.Add("status", msg);
            //collection.Add("access_token", token);
            //return Request.CreateResponse(HttpStatusCode.OK, collection, "application/json");
            return null;
        }

        public HttpResponseMessage Post([FromBody]login login)
        {
            string loginid = login.staffid;
            string loginpass = login.password;

            using (lapo_hrEntities entities = new lapo_hrEntities())
            {
                 if(    entities.login.Any(user => user.staffid.Equals(loginid,
                    StringComparison.OrdinalIgnoreCase) && user.password == loginpass) == true)
                {
                    //var token = ActionContext.Request.Headers.Authorization.Parameter;
                    var token = "wgdgdgrwhkchkodwedbnffhsfdhfsjsfstyrudsgrhrjgjfdfgdsfrygrfrdgstefnmhkp8itwes";
                    var msg = "success";
                    var collection = new Dictionary<string, object>();
                    collection.Add("status", msg);
                    collection.Add("access_token", token);
                    return Request.CreateResponse(HttpStatusCode.OK, collection, "application/json");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "error");
                }
            }

            /* con = new SqlConnection("Data Source=(local);Initial Catalog=lapo_hr;Integrated Security=True");
            SqlCommand cmd1 = new SqlCommand("select * from login where email='" + loginid + "' and password='"+loginpass+"'", con);
            SqlDataAdapter adpt = new SqlDataAdapter();
            con.Open();
            adpt.SelectCommand = cmd1;
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                var token = ActionContext.Request.Headers.Authorization.Parameter;
                var msg = "success";
                var collection = new Dictionary<string, object>();
                collection.Add("status", msg);
                collection.Add("access_token", token);
                return Request.CreateResponse(HttpStatusCode.OK, collection, "application/json");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "error");
            } */
          
        }
    }
}
