

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
    public static CustomerOverview ToCustomerOverview(this Customer customer)
    {
        return new CustomerOverview
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            Phone = customer.Phone
        };
    }
    public static SaleDashboardOverview ToSaleDashboardOverview(this SaleDashboard saleDashboard)
    {
        return new SaleDashboardOverview
        {
            Id = saleDashboard.Id,
            Name = saleDashboard.Name,
            IsDefault = saleDashboard.IsDefault,
            TotalProducts = saleDashboard.Products.Count
        };
    }
}
