

using AlmaDeMalta.Common.Contracts.Overviews;

namespace AlmaDeMalta.Common.Contracts.Contracts;
public class SaleDetail
{
    public ProductOvewview Product { get; set; } = null!;
    public decimal Quantity { get; set; } = 0.0m;
}
