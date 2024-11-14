using Peiton.Contracts.Common;

namespace Peiton.Contracts.Vehiculos;

public class VehiculoListItem : VehiculoBase
{
    public int Id { get; set; }
    public ListItem TipoVehiculo { get; set; } = null!;
}