using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class TipoVehiculo
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<Vehiculo> Vehiculos { get; } = new List<Vehiculo>(); */

}
