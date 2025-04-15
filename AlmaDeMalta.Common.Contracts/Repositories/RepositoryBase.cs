using AlmaDeMalta.Common.Contracts.Attributes;
using AlmaDeMalta.Common.Contracts.Contracts;
using AlmaDeMalta.Common.Contracts.DataBase;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;
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
       return await dbContext.GetCollection<T>().AnyAsync(filter);
    }

    public async Task<T> FindOneAsync(Expression<Func<T, bool>> filter)
    {
        return await dbContext.GetCollection<T>().FirstOrDefaultAsync(filter);
    }

    public async Task<IList<T>> GetAsync()
    {
        return await dbContext.GetCollection<T>().ToListAsync();
    }

    public async Task<IList<T>> GetAsync(Expression<Func<T, bool>> filter)
    {
       return await dbContext.Filter<T>(filter).ToListAsync();
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
