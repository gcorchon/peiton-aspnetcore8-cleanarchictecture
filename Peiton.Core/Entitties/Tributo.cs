using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class Tributo
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public bool Inmobiliario { get; set; }

	/* public virtual ICollection<TributoTutelado> TributosTutelados { get; } = new List<TributoTutelado>(); */

}
