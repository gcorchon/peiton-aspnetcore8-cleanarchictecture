using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class TipoAnejo
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<InmuebleAnejo> InmueblesAnejos { get; } = new List<InmuebleAnejo>(); */

}
