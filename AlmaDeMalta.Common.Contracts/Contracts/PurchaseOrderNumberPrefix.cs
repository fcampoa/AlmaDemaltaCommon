
using AlmaDeMalta.Common.Contracts.Attributes;

namespace AlmaDeMalta.Common.Contracts.Contracts;
[CollectionName("Sale")]
public class PurchaseOrderNumberPrefix: BaseEntity
{
    public override IList<string> ItemType => [nameof(PurchaseOrderNumberPrefix)];
    public string prefix { get; set; } = null!;
    public int Number { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
}
