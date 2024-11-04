using Microsoft.Extensions.DependencyInjection;

namespace Peiton.DependencyInjection;

[AttributeUsage(AttributeTargets.Class)]
public class InjectableAttribute : Attribute
{
    public Type? InterfaceType { get; init; }
    public ServiceLifetime? Lifetime { get; init; }
    public InjectableAttribute() : this(null) { }

    public InjectableAttribute(Type? interfaceType) : this(interfaceType, ServiceLifetime.Scoped)
    {
    }

    public InjectableAttribute(Type? interfaceType, ServiceLifetime serviceLifetime)
    {
        this.InterfaceType = interfaceType;
        this.Lifetime = serviceLifetime;
    }
}