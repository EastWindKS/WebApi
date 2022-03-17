using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.Employees;

[Table("EmployeeInsurance")]
public class EmployeeInsurance
{
    public int Id { get; set; }

    public string Number { get; set; }
}