using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class ComunidadAutonoma
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<EntidadGestora> EntidadesGestoras { get; } = new List<EntidadGestora>(); */
	/* public virtual ICollection<Provincia> Provincias { get; } = new List<Provincia>(); */

}
