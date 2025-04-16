namespace AlmaDeMalta.Common.Contracts.Attributes;
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class CollectionName: Attribute
    {
    public string Name { get; }
    public CollectionName(string name)
    {
        Name = name;
    }
}
