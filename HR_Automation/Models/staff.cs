using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace HR_Automation.Models
{
    public class staff
    {
        
       
        public string employeeNumber { get; set; }
        public string name { get; set; }
        //public string Sname { get; set; }
        public string branchid { get; set; }



    }
    public class createStaff : staff
    {

    }
    public class ReadStaff : staff
    {
        public ReadStaff(DataRow row)
        {
           employeeNumber = row["employeeNumber"].ToString();
            name = row["name"].ToString();
            //Sname = row["Sname"].ToString();
            branchid = row["branchid"].ToString();

        }
          public string employeeNumber { get; set; }
          public string name { get; set; }
          //public string Sname { get; set; }
          public string branchid { get; set; }
      //  public string email { get; set; }

    }
}