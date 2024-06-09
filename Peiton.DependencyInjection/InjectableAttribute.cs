namespace Peiton.DependencyInjection;

[AttributeUsage(AttributeTargets.Class)]
public class InjectableAttribute: Attribute
{
    public Type? InterfaceType {get; init;}
    
    public InjectableAttribute(){ }
    public InjectableAttribute(Type interfaceType )
    {
        this.InterfaceType = interfaceType;    
    }
}