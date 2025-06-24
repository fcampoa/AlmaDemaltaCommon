
using System.Linq.Expressions;

namespace AlmaDeMalta.Common.Contracts.DataBase;
public class SandBoxDbContext : IDbContext
{
    public void Add<T>(T entity) where T : class
    {
        throw new NotImplementedException();
    }

    public Task AddAsync<T>(T entity) where T : class
    {
        throw new NotImplementedException();
    }

    public void Delete<T>(Expression<Func<T, bool>> filter) where T : class
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync<T>(Expression<Func<T, bool>> filter) where T : class
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<IList<T>> Filter<T>(Expression<Func<T, bool>> filter) where T : class
    {
        throw new NotImplementedException();
    }

    public Task<T> FindOneAsync<T>(Expression<Func<T, bool>> filter) where T : class
    {
        throw new NotImplementedException();
    }

    public Task<IList<T>> GetCollection<T>() where T : class
    {
        throw new NotImplementedException();
    }

    public void InitTransaction()
    {
        throw new NotImplementedException();
    }

    public bool SaveChanges()
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public void Update<T>(Expression<Func<T, bool>> filter, T entity) where T : class
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync<T>(Expression<Func<T, bool>> filter, T entity) where T : class
    {
        throw new NotImplementedException();
    }

    public Task UpdateManyAsync<T>(Expression<Func<T, bool>> filter, Expression<Func<T, T>> update) where T : class
    {
        throw new NotImplementedException();
    }
}
