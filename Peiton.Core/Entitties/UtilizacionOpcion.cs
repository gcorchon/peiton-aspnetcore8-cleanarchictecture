using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class UtilizacionOpcion
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<Inmueble> Inmuebles { get; } = new List<Inmueble>(); */
}
