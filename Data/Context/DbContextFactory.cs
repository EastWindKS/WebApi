using System.Security.Principal;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data.Context;

public class DbContextFactory : IDbContextFactory
{
    public DbContextFactory(IConfiguration configuration, IPrincipal principal)
    {
        _configuration = configuration;
        _principal = principal;
    }

    private readonly IConfiguration _configuration;

    private readonly IPrincipal _principal;

    public MainDbContext CreateDbContext()
    {
        var userName = _principal.Identity?.Name;
        var originalConnectionString = _configuration.GetConnectionString("UserSpecificConnection");
        var privateConnectionString = originalConnectionString.Replace("loginPlaceholder", userName);
        var optionsBuilder = new DbContextOptionsBuilder<MainDbContext>();
        var options = optionsBuilder.UseSqlServer(privateConnectionString).Options;
        var context = new MainDbContext(options);

        return context;
    }

    public static MainDbContext CreateContext(string userName, string originalConnectionString)
    {
        var privateConnectionString = originalConnectionString.Replace("loginPlaceholder", userName);
        var optionsBuilder = new DbContextOptionsBuilder<MainDbContext>();
        var options = optionsBuilder.UseSqlServer(privateConnectionString).Options;
        return new MainDbContext(options);
    }
}