using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR_Automation.Models
{
    public class addstaff
    {
        public string basicDetails { get; set; }
        public string otherDetails { get; set; }
        public string employmentDetails { get; set; }
        public string orgUnits { get; set; }
        public string managers { get; set; }
        public int sn { get; set; }
        public string staffID { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Sname { get; set; }
        public Nullable<System.DateTime> dob { get; set; }
        public string Mstatus { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> hiredate { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public Nullable<int> stateID { get; set; }
        public Nullable<int> cityID { get; set; }
        public string address { get; set; }
        public string idTypeID { get; set; }
        public string idNumber { get; set; }
        public string kinName { get; set; }
        public string kinPhone { get; set; }
        public string kinAddress { get; set; }
        public string kinRelshipId { get; set; }
        public string employeeFnID { get; set; }
        public Nullable<int> branchID { get; set; }
        public Nullable<int> unitCatID { get; set; }
        public Nullable<int> unitID { get; set; }
        public string manager1ID { get; set; }
        public string manager2ID { get; set; }
        public string createdby { get; set; }
        public Nullable<System.DateTime> createddt { get; set; }
        public Nullable<int> countryid { get; set; }
    }
}