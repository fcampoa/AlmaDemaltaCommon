using AlmaDeMalta.Common.Contracts.Contracts;
using AlmaDeMalta.Common.Contracts.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmaDeMalta.Migrations.Migrations.Seeds
{
    public class ProductSeed(IUnitOfWork unitOfWork) : IMigration
    {
        public async Task Execute()
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Test Product2",
                Description = "This is a test product",
                Price = 9.99m,
                CreatedAt = DateTime.UtcNow,
            };
            var repo = unitOfWork.ProductRepository;

            var existingProduct = await repo.ExistsAsync(p => p.Name == product.Name);
            if (!existingProduct)
            {
                repo.Create(product);
            }
        }
    }    
}
