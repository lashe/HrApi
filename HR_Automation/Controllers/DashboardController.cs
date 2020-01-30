using EmployeeDataAccess;
using HR_Automation.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HR_Automation.Controllers
{
    public class DashboardController : ApiController
    {
        private SqlConnection con;
        
        
        // GET: api/Dashboard
        public HttpResponseMessage Get()
        {
            
            con = new SqlConnection("Data Source=(local);Initial Catalog=lapo_hr;Integrated Security=True");
            SqlCommand cmd1 = new SqlCommand("select COUNT(employeeID) as totalStaff from employee", con);
            SqlCommand cmd = new SqlCommand("select Employeenumber, CONCAT(surname,' ',firstname) as name, branchid from employee ", con);
            SqlDataAdapter amd = new SqlDataAdapter();
            SqlDataAdapter adpt = new SqlDataAdapter();
            con.Open();

            adpt.SelectCommand = cmd1;
            amd.SelectCommand = cmd;
            
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();

            adpt.Fill(dt1);
            amd.Fill(dt);
            var totalstaff = dt1.Rows[0]["totalStaff"].ToString();
            List<staff> list = new List<staff>(dt.Rows.Count);
            if(dt.Rows.Count>0)
            {
                foreach (DataRow staffrecord in dt.Rows)
                {
                    list.Add(new ReadStaff(staffrecord));
                }
            }
            var collection = new Dictionary<string, object>();
            collection.Add("totalStaff", totalstaff);
            collection.Add("staff", list);


            return Request.CreateResponse(HttpStatusCode.OK, collection, "application/json");
            // string stid = dt.Rows[0]["staffid"].ToString();
            // string sname = dt.Rows[0]["name"].ToString();




        }

        // GET: api/Dashboard/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Dashboard
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Dashboard/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Dashboard/5
        public void Delete(int id)
        {
        }
    }
}
