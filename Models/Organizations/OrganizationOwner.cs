using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Data.Interfaces.Systems;
using WebAPI.Models.Employees;

namespace WebAPI.Models.Organizations;

[Table("OrganizationOwner")]
public class OrganizationOwner : IContainId
{
    public int Id { get; set; }

    public int OrganizationId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime DateBegin { get; set; }

    public DateTime? DateEnd { get; set; }

    [ForeignKey("OrganizationId")]
    public Organization Organization { get; set; }

    [ForeignKey("EmployeeId")]
    public Employee Employee { get; set; }
}