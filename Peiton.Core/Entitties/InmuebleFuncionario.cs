using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class InmuebleFuncionario
{
	public int Id { get; set; }
	public string Nombre { get; set; } = null!;

	/* public virtual ICollection<Inmueble> Inmuebles { get; } = new List<Inmueble>(); */

}
