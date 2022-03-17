using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Addresses;
using WebAPI.Models.Employees;
using WebAPI.Services;

namespace WebAPI.Data.Context;

public class SecureEmployeeDbContext : DbContext
{
    public SecureEmployeeDbContext(DbContextOptions<SecureEmployeeDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        var configuration = AppConfig.GetConfig();
        var connectionString = configuration.GetConnectionString("DbSecureEmployeeCreator");
        optionsBuilder.UseSqlServer(connectionString);
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeInsurance> EmployeeInsurances { get; set; }
    public DbSet<Address> Addresses { get; set; }
}