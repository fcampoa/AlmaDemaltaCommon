using AlmaDeMalta.Common.Contracts.Contracts;
using AlmaDeMalta.Common.Contracts.DataBase;

namespace AlmaDeMalta.Common.Services.Services;
    public class ProductService(IUnitOfWork unitOfWork) : IProductService
{
    public async Task CreateAsync(Product entity)
    {
        try
        {
            unitOfWork.StartTransaction();

            var repo = unitOfWork.ProductRepository;
            await repo.CreateAsync(entity);

            unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            throw new Exception("Error creating product", ex);
        }
    }
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var repo = unitOfWork.ProductRepository;
            return await repo.GetAsync();
        }

        public Task<Product?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }

