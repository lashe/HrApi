using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
public class Staffss
{
    public BasicDetails basicDetails { get; set; }
    public OtherDetails otherDetails { get; set; }
    public EmploymentDetails employmentDetails { get; set; }
    public Managers managers { get; set; }
}

public class BasicDetails
{
    public String surname { get; set; }
    public string firstName { get; set; }
    public String middleName { get; set; }
    public string marritalStatus { get; set; }
    public string phoneNumber { get; set; }
    public String email { get; set; }
    public String birthDate { get; set; }
    public String gender { get; set; }
    public String countryId { get; set; }
    public String stateId { get; set; }
    public String cityId { get; set; }
    public String address { get; set; }
}

public class OtherDetails
{
    public String idTypeId { get; set; }
    public String idNumber { get; set; }
    public String kinName { get; set; }
    public String kinAddress { get; set; }
    public String kinPhone { get; set; }
    public String kinRelationshipId { get; set; }
}

public class EmploymentDetails
{
    public String employeeNumber { get; set; }
    public String employeeFunctionId { get; set; }
    public String hireDate { get; set; }
    public String branchId { get; set; }
    public OrgUnits[] orgUnits { get; set; }
}

public class OrgUnits
{
    public String unitCategoryId { get; set; }
    public String unitId { get; set; }
}

public class Managers
{
    public string manager1Id { get; set; }
    public string manager2Id { get; set; }
}