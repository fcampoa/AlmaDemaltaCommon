namespace AlmaDeMalta.Common.Contracts.DataBase;
    public interface IUnitOfWork
    {    
    void StartTransaction();
    bool Commit();
    Task<bool> CommitAsync();
    public void Dispose();
}
