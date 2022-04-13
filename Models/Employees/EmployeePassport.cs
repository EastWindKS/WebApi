using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.Employees;

[Table("EmployeePassport")]
public class EmployeePassport
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string FirstName { get; set; }

    public string Surname { get; set; }

    public string SecondName { get; set; }
}