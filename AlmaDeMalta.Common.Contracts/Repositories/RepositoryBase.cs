using AlmaDeMalta.Common.Contracts.DataBase;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;
using System.Linq;
using System.Reflection;

namespace AlmaDeMalta.Common.Contracts.Repositories;
public class RepositoryBase<T>(IDbContext dbContext) : IRepository<T> where T : class
{
    public async Task CreateAsync(T entity)
    {
        await dbContext.AddAsync<T>(entity);
    }

    public async Task DeleteAsync(Expression<Func<T, bool>> filter)
    {
        await dbContext.DeleteAsync<T>(filter);
    }

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> filter)
    {
        var result = await dbContext.Filter<T>(filter);
        return result.Any();
    }

    public async Task<T?> FindOneAsync(Expression<Func<T, bool>> filter)
    {
        return await dbContext.FindOneAsync<T>(filter);

    }

    public async Task<IList<T>> GetAsync()
    {
        return await dbContext.GetCollection<T>();
    }

    public async Task<IList<T>> GetAsync(Expression<Func<T, bool>> filter)
    {
        return await dbContext.Filter<T>(filter);
    }

    public async Task UpdateAsync(Expression<Func<T, bool>> filter, T entity)
    {
        await dbContext.UpdateAsync<T>(filter, entity);
    }
    public void Create(T entity)
    {
        dbContext.Add<T>(entity);
    }
    public void Update(Expression<Func<T, bool>> filter, T entity)
    {
        dbContext.Update<T>(filter, entity);
    }

    public void Delete(Expression<Func<T, bool>> filter)
    {
        dbContext.Delete<T>(filter);
    }
}
