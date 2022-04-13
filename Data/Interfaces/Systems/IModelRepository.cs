using System.Linq.Expressions;

namespace WebAPI.Data.Interfaces.Systems;

public interface IModelRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(string property = default);

    Task<T> GetAsync(int id, string property = default);

    IEnumerable<T> GetAsync(Expression<Func<T, bool>> predicate, string property = default);

    Task DeleteAsync(int id);

    Task<int> InsertAsync(T entity);

    Task<int> UpdateAsync(T entity);
}