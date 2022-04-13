using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models.Organizations;

namespace WebAPI.Models.Employees;

[Table("OrganizationEmployee")]
public class OrganizationEmployee
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int? DepartmentId { get; set; }

    public int? ProfessionId { get; set; }

    public int OrganizationId { get; set; }

    public DateTime? DateBegin { get; set; }

    public DateTime? DateEnd { get; set; }

    public int? EmploymentTypeId { get; set; }

    public Employee Employee { get; set; }

    public Organization Organization { get; set; }
}