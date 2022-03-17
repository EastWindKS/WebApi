using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data.Context;

public class MainDbContext : DbContext
{
    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
    {
    }
}