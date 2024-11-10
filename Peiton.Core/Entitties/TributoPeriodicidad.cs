using Peiton.ListItems;

namespace Peiton.Core.Entities;
[ListItem]
public class TributoPeriodicidad
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public string? Etiqueta { get; set; }
	public int? Periodos { get; set; }

	/* public virtual ICollection<TributoTutelado> TributosTutelados { get; } = new List<TributoTutelado>(); */

}
