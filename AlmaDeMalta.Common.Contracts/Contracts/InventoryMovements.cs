

using AlmaDeMalta.Common.Contracts.Attributes;
using AlmaDeMalta.Common.Contracts.Overviews;

namespace AlmaDeMalta.Common.Contracts.Contracts;
[CollectionName("Inventory")]
public class InventoryMovements: BaseEntity
{
    public override IList<string> ItemType => [nameof(InventoryMovements)];
    public ProductOvewview Product { get; set; } = null!;
    public decimal Quantity { get; set; } = 0;
    public string? Reason { get; set; } = null!;
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public string? UserId { get; set; } = null!;
    public bool IsIncoming { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public MesaureUnit Unit { get; set; } = MesaureUnit.Gram;

}
