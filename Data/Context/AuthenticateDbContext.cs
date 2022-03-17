using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Authenticate;
using WebAPI.Models.UserRights;
using WebAPI.Services;

namespace WebAPI.Data.Context
{
    public class AuthenticateDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthenticateDbContext(DbContextOptions<AuthenticateDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            var configuration = AppConfig.GetConfig();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<AspNetUserRight> AspNetUserRights { get; set; }
        public DbSet<RightControllerAction> RightControllerActions { get; set; }
        public DbSet<RightController> RightControllers { get; set; }
    }
}