using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class TipoProducto
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<ProductoManual> ProductosManuales { get; } = new List<ProductoManual>(); */

}
