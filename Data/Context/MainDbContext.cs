using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Addresses;
using WebAPI.Models.Employees;
using WebAPI.Models.Filters;
using WebAPI.Models.Finances;
using WebAPI.Models.Organizations;
using WebAPI.Models.UserRights;
using SearchOption = WebAPI.Models.Filters.SearchOption;

namespace WebAPI.Data.Context;

public class MainDbContext : DbContext
{
    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
    {
    }

    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<OrganizationLegalForm> OrganizationLegalForms { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<OrganizationBankAccount> OrganizationBankAccounts { get; set; }
    public DbSet<EmployeePassport> EmployeePassports { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<OrganizationOwner> OrganizationOwners { get; set; }
    public DbSet<OrganizationEmployee> OrganizationEmployees { get; set; }
    public DbSet<FilterList> FilterLists { get; set; }
    public DbSet<PropertyDataType> PropertyDataTypes { get; set; }
    public DbSet<SearchOption> SearchOptions { get; set; }
    public DbSet<SearchOptionPropertyDataTypeLink> SearchOptionPropertyDataTypeLinks { get; set; }
    public DbSet<RightController> RightControllers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Organization>()
            .HasMany(e => e.ChildOrganizations)
            .WithOne(e => e.ParentOrganization)
            .HasForeignKey(e => e.ParentOrganizationId);
    }
}