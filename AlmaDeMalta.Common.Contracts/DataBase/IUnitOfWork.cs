using AlmaDeMalta.Common.Contracts.Repositories;

namespace AlmaDeMalta.Common.Contracts.DataBase;
    public interface IUnitOfWork
    {
    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    void StartTransaction();
    bool Commit();
    Task<bool> CommitAsync();
    public void Dispose();
}
