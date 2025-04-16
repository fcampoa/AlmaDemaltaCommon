namespace AlmaDeMalta.Common.Contracts.Attributes;
[AttributeUsage(AttributeTargets.Interface, Inherited = false)]
public class ServiceClass: Attribute
    {
    public Type TargetClass { get; }
    public StrategyEnum Strategy { get; } = StrategyEnum.Scoped;

    public ServiceClass(Type targetClass, StrategyEnum strategy) 
    {
        TargetClass = targetClass;
        Strategy = strategy;
    }
}
