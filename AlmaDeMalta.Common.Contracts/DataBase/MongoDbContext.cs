using AlmaDeMalta.Common.Contracts.Attributes;
using MongoDB.Driver;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlmaDeMalta.Common.Contracts.DataBase;
    public class MongoDbContext(IMongoClient mongoClient, string databaseName) : IDbContext
    {
        private readonly IMongoDatabase _database = mongoClient.GetDatabase(databaseName);
        private readonly IClientSessionHandle _session = mongoClient.StartSession();
        public IQueryable<T> GetCollection<T>() where T : class => GetMongoCollection<T>().AsQueryable();        

        public async Task AddAsync<T>(T entity) where T : class
        {
            var collection = GetMongoCollection<T>();
            await collection.InsertOneAsync(_session, entity);
        }

        public async Task UpdateAsync<T>(Expression<Func<T, bool>> filter, T entity) where T : class
        {
            var collection = GetMongoCollection<T>();
            await collection.ReplaceOneAsync<T>(_session, filter, entity);
        }

        public async Task DeleteAsync<T>(Expression<Func<T, bool>> filter) where T : class
        {
            var collection = GetMongoCollection<T>();
            await collection.DeleteOneAsync(_session, filter);
        }

        public IQueryable<T> Filter<T>(Expression<Func<T, bool>> filter) where T : class
        {
            return GetCollection<T>().Where(filter);
        }

    public void Add<T>(T entity) where T : class
    {
        var collection = GetMongoCollection<T>();
        collection.InsertOne(entity);
    }

    public void Update<T>(Expression<Func<T, bool>> filter, T entity) where T : class
    {
        var collection = GetMongoCollection<T>();
        collection.ReplaceOne<T>(filter, entity);
    }

    public void Delete<T>(Expression<Func<T, bool>> filter) where T : class
    {
        var collection = GetMongoCollection<T>();
        collection.DeleteOne(filter);
    }

    public void InitTransaction()
    {
        try
        {
            _session.StartTransaction();
        }
        catch
        {
            _session.AbortTransaction();
            throw;
        }
    }

    public bool SaveChanges()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveChangesAsync()
    {
        try
        {
            await _session.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _session.AbortTransactionAsync(); // Cancela la transacción en caso de error
            return false;
        }
    }

    public void Dispose()
    {
        _session?.Dispose();
    }
    private IMongoCollection<T> GetMongoCollection<T>() where T : class
    {
        var collectionNameAttribute = typeof(T).GetCustomAttribute<CollectionName>();
        if (collectionNameAttribute == null)
        {
            throw new InvalidOperationException($"The type {typeof(T).Name} does not have a CollectionName attribute.");
        }

        return _database.GetCollection<T>(collectionNameAttribute.Name);
    }
}
