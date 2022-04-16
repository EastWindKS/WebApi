using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Context;
using WebAPI.Data.Interfaces.Systems;
using WebAPI.Infrastructure;

namespace WebAPI.Data.Repositories.Services;

public class ModelRepository<T> : IModelRepository<T> where T : class, IContainId
{
    protected ModelRepository(IDbContextFactory dbContextFactory, string property)
    {
        Context = dbContextFactory.CreateDbContext();
        DbSet = Context.Set<T>();
        _property = property;
        Factory = dbContextFactory;
    }

    private readonly string _property;

    private MainDbContext Context { get; }

    protected DbSet<T> DbSet { get; }

    protected IDbContextFactory Factory { get; }

    public virtual async Task<IEnumerable<T>> GetAllAsync(string property = default)
    {
        if (string.IsNullOrEmpty(property))
        {
            property = _property;
        }

        return await DbSet.Includes(property).AsNoTracking().ToListAsync();
    }

    public virtual async Task<T> GetAsync(int id, string property = default)
    {
        if (string.IsNullOrEmpty(property))
        {
            property = _property;
        }

        return await DbSet.Includes(property).AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }

    public virtual IEnumerable<T> GetAsync(Expression<Func<T, bool>> predicate, string property = default)
    {
        if (string.IsNullOrEmpty(property))
        {
            property = _property;
        }
        
        return DbSet.Where(predicate).Includes(property).AsNoTracking();
    }

    public virtual async Task DeleteAsync(int id)
    {
        var entity = await DbSet.FindAsync(id);

        if (entity != null)
        {
            DbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }
    }

    public virtual async Task<int> InsertAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity.Id;
    }

    public virtual async Task<int> UpdateAsync(T entity)
    {
        DbSet.Update(entity);
        await Context.SaveChangesAsync();
        return entity.Id;
    }
}