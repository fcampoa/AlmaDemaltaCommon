using AlmaDeMalta.Common.Contracts.Contracts;
using AlmaDeMalta.Common.Contracts.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmaDeMalta.Migrations.Migrations.Seeds
{
    public class ProductSeed(IAlmaDeMaltaUnitOfWork unitOfWork) : IMigration
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
                Stock = 10,
                Availability = 10,
                Barcode = "1234567890123",
            };
            var repo = unitOfWork.ProductRepository;

            var existingProduct = await repo.ExistsAsync(p => p.Name == product.Name && p.Barcode == product.Barcode);
            if (!existingProduct)
            {
                repo.Create(product);
            }
        }
    }    
}
