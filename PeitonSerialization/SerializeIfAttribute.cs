namespace Peiton.Serialization;
public class SerializeIfAttribute : Attribute
{
    public int Permission { get; init; }
    public SerializeIfAttribute(int permission)
    {
        this.Permission = permission;
    }
}
