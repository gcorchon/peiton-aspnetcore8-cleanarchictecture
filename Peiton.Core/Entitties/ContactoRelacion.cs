using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class ContactoRelacion
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<Contacto> Contactos { get; } = new List<Contacto>(); */

}
