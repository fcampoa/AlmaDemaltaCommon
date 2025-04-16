namespace AlmaDeMalta.Common.Services.Services;
    public interface IBaseService<T>
    {
    // Create
    Task CreateAsync(T entity);
    // Read
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    // Update
    Task UpdateAsync(T entity);
    // Delete
    Task DeleteAsync(Guid id);
}
