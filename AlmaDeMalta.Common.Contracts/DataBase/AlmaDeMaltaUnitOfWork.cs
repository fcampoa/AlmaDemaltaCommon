using AlmaDeMalta.Common.Contracts.Contracts;
using AlmaDeMalta.Common.Contracts.Repositories;

namespace AlmaDeMalta.Common.Contracts.DataBase;
public class AlmaDeMaltaUnitOfWork(IDbContext dbContext) : UnitOfWork(dbContext), IAlmaDeMaltaUnitOfWork
{

    private IRepository<Product>? _productRepository;
    public IRepository<Product> ProductRepository => _productRepository ??= new RepositoryBase<Product>(dbContext);


}
