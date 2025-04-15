using AlmaDeMalta.Common.Contracts.Attributes;
using System.Runtime.CompilerServices;

namespace AlmaDeMalta.Common.Contracts.Contracts;
[CollectionName("Product")]
public class Product: BaseEntity
{
    public override IList<string> ItemType => [nameof(Product)];
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ProductCategory Category { get; set; } = ProductCategory.Other;
    public string ImageUrl { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public ProductType Type { get; set; } = ProductType.Other;
    public MesaureUnit Unit { get; set; } = MesaureUnit.Other;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}
