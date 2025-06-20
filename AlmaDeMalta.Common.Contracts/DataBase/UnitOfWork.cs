using AlmaDeMalta.Common.Contracts.Repositories;

namespace AlmaDeMalta.Common.Contracts.DataBase;
    public class UnitOfWork(IDbContext dbContext) : IUnitOfWork
    {
    private readonly Dictionary<Type, object> _repositories = new();
    public void StartTransaction()
    {
        dbContext.InitTransaction();
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

    public IRepository<T> GetRepository<T>() where T : class
    {
        var type = typeof(T);
        if (!_repositories.TryGetValue(type, out var repo))
        {
            repo = new RepositoryBase<T>(dbContext);
            _repositories[type] = repo;
        }
        return (IRepository<T>)repo!;
    }
 }
