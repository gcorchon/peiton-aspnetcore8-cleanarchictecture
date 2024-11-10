using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class EstadoInventario
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<ControlInventario> ControlesInventarios { get; } = new List<ControlInventario>(); */

}
