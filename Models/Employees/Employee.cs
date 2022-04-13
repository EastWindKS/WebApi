using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models.Addresses;

namespace WebAPI.Models.Employees;

[Table("Employee")]
public class Employee
{
    public int Id { get; set; }

    public short? Sex { get; set; }

    public string IdentityCode { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? AddressId { get; set; }

    public int? EmployeeInsuranceId { get; set; }

    public string Remark { get; set; }

    public string AspNetUserId { get; set; }

    public Address Address { get; set; }

    public EmployeeInsurance EmployeeInsurance { get; set; }

    public ICollection<EmployeePassport> EmployeePassports { get; set; } = new HashSet<EmployeePassport>();

    public ICollection<OrganizationEmployee> OrganizationEmployee { get; set; } = new HashSet<OrganizationEmployee>();

    public string GetShortName()
    {
        var firstPassport = EmployeePassports.FirstOrDefault();

        return firstPassport is null ? string.Empty : $"{firstPassport.Surname.Trim()} {firstPassport.FirstName.Trim()[0]}.{firstPassport.SecondName.Trim()[0]}.";
    }
}