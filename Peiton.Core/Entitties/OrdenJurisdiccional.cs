using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class OrdenJurisdiccional
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<Procedimiento> Procedimientos { get; } = new List<Procedimiento>(); */

}
