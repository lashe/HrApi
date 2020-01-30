using EmployeeDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HR_Automation.Models
{
    public class EmployeeSecurity
    {
        public static bool Login(string email, string password)
        {
            using(lapo_hrEntities entities = new lapo_hrEntities())
            {
                return entities.login.Any(user => user.email.Equals(email,
                    StringComparison.OrdinalIgnoreCase) && user.password == password);
            }
        }
    }
}