

using AlmaDeMalta.Common.Contracts.Contracts;

namespace AlmaDeMalta.Common.Contracts.Overviews;
    public static class ExtensionMethods
    {
    public static ProductOvewview ToProductOverview(this Product product)
    {
        return new ProductOvewview
        {
            ProductId = product.Id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            Stock = product.Stock
        };
    }
}
