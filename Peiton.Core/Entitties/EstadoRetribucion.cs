using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class EstadoRetribucion
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<ControlRendicion> ControlesRendiciones { get; } = new List<ControlRendicion>(); */

}
