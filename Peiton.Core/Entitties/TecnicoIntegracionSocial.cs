using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class TecnicoIntegracionSocial
{
	public int Id { get; set; }
	public string Nombre { get; set; } = null!;

	/* public virtual ICollection<Tutelado> Tutelados { get; } = new List<Tutelado>(); */

}
