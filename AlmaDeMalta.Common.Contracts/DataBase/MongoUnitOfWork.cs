using AlmaDeMalta.Common.Contracts.Contracts;
using AlmaDeMalta.Common.Contracts.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmaDeMalta.Common.Contracts.DataBase;
public class MongoUnitOfWork(IDbContext dbContext) : IUnitOfWork
{

    private IRepository<Product>? _productRepository;
    public IRepository<Product> ProductRepository => _productRepository ??= new RepositoryBase<Product>(dbContext);

    public void StartTransaction()
    {

    }

    public void Dispose()
    {
        dbContext.Dispose();
    }

    public bool Commit()
    {
       return dbContext.SaveChanges();
    }

    public async Task<bool> CommitAsync()
    {
        return await dbContext.SaveChangesAsync();
    }
}
