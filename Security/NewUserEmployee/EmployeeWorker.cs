using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Context;
using WebAPI.Models.Addresses;
using WebAPI.Models.Employees;

namespace WebAPI.Security.NewUserEmployee;

public class EmployeeWorker
{
    public EmployeeWorker()
    {
        _secureEmployeeDbContext = new SecureEmployeeDbContext(new DbContextOptions<SecureEmployeeDbContext>());
    }

    private readonly SecureEmployeeDbContext _secureEmployeeDbContext;

    public async Task<int> CreateEmployee()
    {
        var newEmployee = new Employee
        {
            EmployeeInsurance = new EmployeeInsurance {Number = string.Empty},
            Address = new Address()
        };

        var addedEmployee = await _secureEmployeeDbContext.Employees.AddAsync(newEmployee);
        await _secureEmployeeDbContext.SaveChangesAsync();

        return addedEmployee.Entity.Id;
    }

    public async Task UpdateEmployeeAspNetUserIdByEmployeeId(int employeeId, string aspNetUserId)
    {
        var employee = await _secureEmployeeDbContext.Employees.FindAsync(employeeId);

        if (employee != null)
        {
            employee.AspNetUserId = aspNetUserId;
            _secureEmployeeDbContext.Employees.Update(employee);
            await _secureEmployeeDbContext.SaveChangesAsync();
        }
    }
}