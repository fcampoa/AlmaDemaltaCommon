using AlmaDeMalta.Common.Contracts.Contracts;
using AlmaDeMalta.Common.Contracts.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmaDeMalta.Common.Contracts.DataBase;
public class MongoUnitOfWork(IMongoClient mongoClient, string databaseName) : IUnitOfWork
{
    private readonly IMongoDatabase _database = mongoClient.GetDatabase(databaseName);
    private readonly IClientSessionHandle _session = mongoClient.StartSession();

    private IRepository<Product>? _productRepository;
    public IRepository<Product> ProductRepository => _productRepository ??= new RepositoryBase<Product>(_database);


    public void Dispose()
    {
        _session?.Dispose();
    }

    public bool SaveChanges()
    {
        try
        {
            _session?.CommitTransaction();
            return true;
        }
        catch (Exception ex)
        {
            _session?.AbortTransaction();
            throw new Exception("Error saving changes", ex);
        }
    }

    public async Task<bool> SaveChangesAsync()
    {
        try
        {
            await _session.CommitTransactionAsync();
            return true;
        }
        catch (Exception ex)
        {
            _session.AbortTransactionAsync();
            throw new Exception("Error saving changes", ex);
        }
    }
}
