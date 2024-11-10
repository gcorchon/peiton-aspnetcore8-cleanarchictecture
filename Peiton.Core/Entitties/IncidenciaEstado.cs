using Peiton.ListItems;

namespace Peiton.Core.Entities;
[ListItem]
public class IncidenciaEstado
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<Incidencia> Incidencias { get; } = new List<Incidencia>(); */

}
