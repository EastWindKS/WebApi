namespace WebAPI.Data.Context;

public interface IDbContextFactory<out T>
{
    T CreateContext();
}