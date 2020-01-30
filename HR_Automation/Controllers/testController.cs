using EmployeeDataAccess;
using HR_Automation.Models;
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
    public class testController : ApiController
    {
        private SqlConnection con;

        [BasicAuthentication]
        public HttpResponseMessage  Get()
        {

            using (lapo_hrEntities entities = new lapo_hrEntities())
            {

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
                
                var query = "update testing set text='hello',number='12345',createdby='"+sid+"' where staffid='1003'";

                SqlCommand Command = new SqlCommand(query, con);
                //con.Open();
                Command.ExecuteNonQuery();




               

                var status = Request.CreateResponse(HttpStatusCode.OK , sid);

                return status;
              // return entities.employees.ToList();
            }
        }
        public HttpResponseMessage Post([FromBody] addstaff newstff)
        {
            using (lapo_hrEntities entities = new lapo_hrEntities()) { }

            /*{
                employee emp = new employee();
                newstff.address =  emp.address;
                newstff.branchID = emp.branchID;
                newstff.cityID = emp.cityID;
                newstff.countryid = emp.countryid;
                newstff.dob = emp.dob;
                newstff.email = emp.email;
                newstff.employeeFnID = emp.employeeFnID;
                newstff.Fname = emp.Fname;
                newstff.Gender = emp.Gender;
                newstff.hiredate = emp.hiredate;
                newstff.idNumber = emp.idNumber;
                newstff.idTypeID = emp.idTypeID;
                newstff.kinAddress = emp.kinAddress;
                newstff.kinName = emp.kinPhone;
                newstff.kinRelshipId = emp.kinRelshipId;
                newstff.manager1ID = emp.manager1ID;
                newstff.manager2ID = emp.manager2ID;
                newstff.Mname = emp.Mname;
                newstff.Mstatus = emp.Mstatus;
                newstff.phone = emp.phone;
                newstff.Sname = emp.Sname;
                newstff.staffID = emp.staffID;
                newstff.stateID = emp.stateID;
                newstff.unitCatID = emp.unitCatID;
                newstff.unitID = emp.unitID;

                entities.employee.Add(emp);
                entities.SaveChanges();
                string latestid = newstff.staffID;

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

                return Request.CreateResponse(HttpStatusCode.Created, "staff " + latestid + " added successfully");
            }*/
            return Request.CreateResponse(HttpStatusCode.Created, "staff  added successfully");
        }
    }
}
