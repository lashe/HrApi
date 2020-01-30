using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeDataAccess;

namespace HR_Automation.Models
{
    public class loginSecurity
    {
        public static bool Login(string staffID, string password)
        {
            using (lapo_hrEntities entities = new lapo_hrEntities())
            {
                return entities.login.Any(user => user.staffid.Equals(staffID,
                    StringComparison.OrdinalIgnoreCase) && user.password == password);
            }
        }
    }
}