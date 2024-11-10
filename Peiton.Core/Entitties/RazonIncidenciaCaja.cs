using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class RazonIncidenciaCaja
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<CajaIncidencia> CajaIncidencias { get; } = new List<CajaIncidencia>(); */

}
