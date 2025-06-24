using System.Linq.Expressions;

namespace AlmaDeMalta.Common.Contracts.Repositories;
public interface IRepository<T> where T : class
{
    Task<T?> FindOneAsync(Expression<Func<T, bool>> filter);
    Task<IList<T>> GetAsync();
    Task CreateAsync(T  entity);
    Task DeleteAsync(Expression<Func<T, bool>> filter);
    Task UpdateAsync(Expression<Func<T, bool>> filter, T entity);
    Task UpdateManyAsync(Expression<Func<T, bool>> filter, Expression<Func<T, T>> update);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> filter);
    Task<IList<T>> GetAsync(Expression<Func<T, bool>> filter);
    void Create(T entity);
    void Delete(Expression<Func<T, bool>> filter);
    void Update(Expression<Func<T, bool>> filter, T entity);
}
