using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class TitularidadServicioEntidadGestora
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<EntidadGestora> EntidadesGestoras { get; } = new List<EntidadGestora>(); */

}
