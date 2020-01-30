using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using HR_Automation.Models;

namespace HR_Automation.Controllers
{
    public class AddStaffController : ApiController
    {
        private SqlConnection con;

        public HttpResponseMessage Get()
        {
            con = new SqlConnection("Data Source=(local);Initial Catalog=lapo_hr;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select Employeenumber, CONCAT(surname,' ',firstname) as name, branchid from employee ", con);
            SqlDataAdapter amd = new SqlDataAdapter();
            con.Open();

            amd.SelectCommand = cmd;

            DataTable dt = new DataTable();

            amd.Fill(dt);
            List<staff> list = new List<staff>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow staffrecord in dt.Rows)
                {
                    list.Add(new ReadStaff(staffrecord));
                }
                
            }
            var collection = new Dictionary<string, object>();
            collection.Add("staff", list);
            return Request.CreateResponse(HttpStatusCode.OK, collection, "application/json");
        }

        public HttpResponseMessage Post([FromBody] Staffss staffadd)
        {
           con = new SqlConnection("Data Source=(local);Initial Catalog=lapo_hr;Integrated Security=True");
            var query = "insert into employee (employeeNumber,firstname,middlename,surname,birthdate,maritalstatus,Gender,hiredate,phonenumber,email,stateID,cityID,address,idTypeID,idNumber,kinName,kinPhone,kinAddress,kinRelationshipId,employeeFunctionid,branchID,manager1ID,Manager2ID,countryid) values(@employeeNumber,@firstname,@middlename,@surname,@birthdate,@maritalstatus,@Gender,@hiredate,@phonenumber,@email,@stateID,@cityID,@address,@idTypeID,@idNumber,@kinName,@kinPhone,@kinAddress,@kinRelationshipId,@employeeFunctionid,@branchID,@manager1Id,@manager2Id,@countryid)";
            SqlCommand insertcommand = new SqlCommand(query, con);
            insertcommand.Parameters.AddWithValue("@employeeNumber",staffadd.employmentDetails.employeeNumber);
            insertcommand.Parameters.AddWithValue("@firstname", staffadd.basicDetails.firstName);
            insertcommand.Parameters.AddWithValue("@middlename", staffadd.basicDetails.middleName);
            insertcommand.Parameters.AddWithValue("@surname", staffadd.basicDetails.surname);
            insertcommand.Parameters.AddWithValue("@birthdate", staffadd.basicDetails.birthDate);
            insertcommand.Parameters.AddWithValue("@maritalstatus", staffadd.basicDetails.marritalStatus);
            insertcommand.Parameters.AddWithValue("@Gender",staffadd.basicDetails.gender);
            insertcommand.Parameters.AddWithValue("@hiredate", staffadd.employmentDetails.hireDate);
            insertcommand.Parameters.AddWithValue("@phonenumber",staffadd.basicDetails.phoneNumber);
            insertcommand.Parameters.AddWithValue("@email", staffadd.basicDetails.email);
            insertcommand.Parameters.AddWithValue("@stateID", staffadd.basicDetails.stateId);
            insertcommand.Parameters.AddWithValue("@cityID", staffadd.basicDetails.cityId);
            insertcommand.Parameters.AddWithValue("@address", staffadd.basicDetails.address);
            insertcommand.Parameters.AddWithValue("@idTypeID", staffadd.otherDetails.idTypeId);
            insertcommand.Parameters.AddWithValue("@idNumber", staffadd.otherDetails.idNumber);
            insertcommand.Parameters.AddWithValue("@kinName", staffadd.otherDetails.kinName);
            insertcommand.Parameters.AddWithValue("@kinPhone", staffadd.otherDetails.kinPhone);
            insertcommand.Parameters.AddWithValue("@kinAddress", staffadd.otherDetails.kinAddress);
            insertcommand.Parameters.AddWithValue("@kinRelationshipId", staffadd.otherDetails.kinRelationshipId);
            insertcommand.Parameters.AddWithValue("@employeeFunctionid", staffadd.employmentDetails.employeeFunctionId);
            insertcommand.Parameters.AddWithValue("@branchID", staffadd.employmentDetails.branchId);
            insertcommand.Parameters.AddWithValue("@manager1Id", staffadd.managers.manager1Id);
            insertcommand.Parameters.AddWithValue("@manager2Id", staffadd.managers.manager2Id);
            insertcommand.Parameters.AddWithValue("@countryid", staffadd.basicDetails.countryId);
            con.Open();
            int result = insertcommand.ExecuteNonQuery();
            if (result > 0)
            {
                var empid = staffadd.employmentDetails.employeeNumber;

                con = new SqlConnection("Data Source=(local);Initial Catalog=lapo_hr;Integrated Security=True");
                SqlCommand cmd2 = new SqlCommand("select employeeid, Employeenumber, CONCAT(surname,' ',firstname) as name from employee where employeeNumber='"+empid+"' ", con);
                SqlDataAdapter amd = new SqlDataAdapter();
                con.Open();
                amd.SelectCommand = cmd2;
                DataTable dt = new DataTable();
                amd.Fill(dt);
                var emid = dt.Rows[0]["employeeid"].ToString();
                var emname = dt.Rows[0]["name"].ToString();
                var emnum = dt.Rows[0]["employeeNumber"].ToString();
                var listt = new List<string>();
                listt.Add(empid);
                listt.Add(emname);
                listt.Add(emnum);
                var collection = new Dictionary<string, object>();
                collection.Add("status",HttpStatusCode.Created );
                collection.Add("message", "Staff added successfully");
                collection.Add("data",listt );

                return Request.CreateResponse(HttpStatusCode.Created, collection, "application/json");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "error");
            }
        }
    }
}
