
using AlmaDeMalta.Common.Contracts.Attributes;
using AlmaDeMalta.Common.Contracts.Overviews;

namespace AlmaDeMalta.Common.Contracts.Contracts;
    [CollectionName("Sale")]
    public class SaleDashboard: BaseEntity
    {
    public override IList<string> ItemType => [nameof(SaleDashboard)];
    public IList<ProductOvewview> Products { get; set; } = [];
    public string Name { get; set; } = string.Empty;
    public bool IsDefault { get; set; } = false;
}
