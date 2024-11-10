using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class DatosJuridicosEstado
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<Tutelado> Tutelados { get; } = new List<Tutelado>(); */

}
