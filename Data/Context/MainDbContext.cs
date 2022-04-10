using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Addresses;
using WebAPI.Models.Finances;
using WebAPI.Models.Organizations;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Organization>()
            .HasMany(e => e.ChildOrganizations)
            .WithOne(e => e.ParentOrganization)
            .HasForeignKey(e => e.ParentOrganizationId);
    }
}