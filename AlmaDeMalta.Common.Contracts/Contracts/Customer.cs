using AlmaDeMalta.Common.Contracts.Attributes;

namespace AlmaDeMalta.Common.Contracts.Contracts;
[CollectionName("Customers")]
public class Customer: BaseEntity
{
    public override IList<string> ItemType => [nameof(Customer)];
    public string Name { get; set; } = null!;
    public string? Email { get; set; } = null!;
    public string? Phone { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public string TaxPayerId { get; set; } = null!;
    public bool IsDefaul { get; set; } = false;
}
