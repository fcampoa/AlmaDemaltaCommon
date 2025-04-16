using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlmaDeMalta.Common.Contracts.DataBase
{
    public interface IDbContext
    {
        Task<IList<T>> GetCollection<T>() where T : class;
        Task AddAsync<T>(T entity) where T : class;
        Task UpdateAsync<T>(Expression<Func<T, bool>> filter, T entity) where T : class;
        Task DeleteAsync<T>(Expression<Func<T, bool>> filter) where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(Expression<Func<T, bool>> filter, T entity) where T : class;
        void Delete<T>(Expression<Func<T, bool>> filter) where T : class;
        Task<IList<T>> Filter<T>(Expression<Func<T, bool>> filter) where T : class;
        Task<T> FindOneAsync<T>(Expression<Func<T, bool>> filter) where T : class;
        void InitTransaction();
        Task<bool> SaveChangesAsync();
        bool SaveChanges();
        void Dispose();
    }
}
