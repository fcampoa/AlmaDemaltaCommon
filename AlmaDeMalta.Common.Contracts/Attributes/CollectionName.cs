namespace AlmaDeMalta.Common.Contracts.Attributes;
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class CollectionName(string name) : Attribute
    {
    public string Name { get; } = name;
}
