namespace WebAPI.Data.Context;

public interface IDbContextFactory
{
    MainDbContext CreateDbContext();
}