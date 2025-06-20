using AlmaDeMalta.Common.Contracts.Contracts;
using AlmaDeMalta.Common.Contracts.Repositories;

namespace AlmaDeMalta.Common.Contracts.DataBase;
public class AlmaDeMaltaUnitOfWork(IDbContext dbContext) : UnitOfWork(dbContext), IAlmaDeMaltaUnitOfWork
{

    private readonly Dictionary<Type, object> _repositories = new();

    private IRepository<Product>? _productRepository;
    public IRepository<Product> ProductRepository => _productRepository ??= new RepositoryBase<Product>(dbContext);

    private IRepository<InventoryMovements>? _inventoryMovementsRepository;
    public IRepository<InventoryMovements> InventoryMovementsRepository => _inventoryMovementsRepository ??= new RepositoryBase<InventoryMovements>(dbContext);

    private IRepository<Sale>? _saleRepository;
    public IRepository<Sale> SaleRepository => _saleRepository ??= new RepositoryBase<Sale>(dbContext);

    public IRepository<T> GetRepository<T>() where T : class
    {
        var type = typeof(T);
        if(!_repositories.TryGetValue(type, out var repo))
        {
            repo = new RepositoryBase<T>(dbContext);
            _repositories[type] = repo;
        }
        return (IRepository<T>)repo!;
    }

}
