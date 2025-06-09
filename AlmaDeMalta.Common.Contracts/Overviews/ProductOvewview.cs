

using AlmaDeMalta.Common.Contracts.Contracts;

namespace AlmaDeMalta.Common.Contracts.Overviews;
    public class ProductOvewview
    {
    public Guid ProductId { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string Description { get; set; } = null!;
    public decimal Stock { get; set; } = 0.0m;
    public MesaureUnit Unit { get; set; } = MesaureUnit.Gram;
}
