namespace WebAPI.Infrastructure;

using Microsoft.EntityFrameworkCore;

public static class Extension
{
    public static IQueryable<T> Includes<T>(this IQueryable<T> queryable, string includeProperties) where T : class
    {
        var properties = includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries);
        var query = queryable.AsQueryable();

        foreach (var property in properties)
        {
            query = query.Include(property.Trim());
        }

        return query;
    }
}