using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class SucesionTipo
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<Sucesion> Sucesiones { get; } = new List<Sucesion>(); */

}
