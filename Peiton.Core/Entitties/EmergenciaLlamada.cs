using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class EmergenciaLlamada
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<Emergencia> Emergencias { get; } = new List<Emergencia>(); */

}
