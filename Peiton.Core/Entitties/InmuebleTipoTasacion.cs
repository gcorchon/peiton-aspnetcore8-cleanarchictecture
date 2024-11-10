using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class InmuebleTipoTasacion
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<InmuebleTasacion> InmueblesTasaciones { get; } = new List<InmuebleTasacion>(); */

}
