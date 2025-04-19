namespace AlmaDeMalta.Common.Contracts.Attributes;
[AttributeUsage(AttributeTargets.Interface, Inherited = false)]
public class ServiceClass(Type targetClass, StrategyEnum strategy) : Attribute
    {
    public Type TargetClass { get; } = targetClass;
    public StrategyEnum Strategy { get; } = strategy;
}
