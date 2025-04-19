namespace AlmaDeMalta.Common.Contracts.DataBase;
    public class UnitOfWork(IDbContext dbContext) : IUnitOfWork
{
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
}
