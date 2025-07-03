

using AlmaDeMalta.Common.Contracts.Attributes;

namespace AlmaDeMalta.Common.Contracts.Contracts;
[CollectionName("Users")]
public class User : BaseEntity
{
    public override IList<string> ItemType => [nameof(User)];
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? AuthProviderId { get; set; } = string.Empty;
    public string Phone { get; set; } = null!;
    public RoleEnum Role { get; set; } = RoleEnum.User;
}
