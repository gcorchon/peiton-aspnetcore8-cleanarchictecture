using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class Recordatorio
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<Evento> Eventos { get; } = new List<Evento>(); */

}
