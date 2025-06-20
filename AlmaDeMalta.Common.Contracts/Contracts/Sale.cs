using AlmaDeMalta.Common.Contracts.Attributes;
using AlmaDeMalta.Common.Contracts.Overviews;

namespace AlmaDeMalta.Common.Contracts.Contracts;
    [CollectionName("Sale")]
    public class Sale: BaseEntity
    {
    public override IList<string> ItemType => [nameof(Sale)];
    public List<ProductOvewview> Products { get; set; } = [];
    public decimal Subtotal { get; set; } = 0;
    public decimal Total { get; set; } = 0;
    public PaymentMethod PaymentMethod { get; set; } = null!;
    public StatusEnum Status { get; set; } = StatusEnum.Draft;

}
