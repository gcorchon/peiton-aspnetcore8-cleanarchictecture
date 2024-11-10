using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class Fiscalia
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<Urgencia> Urgencias { get; } = new List<Urgencia>(); */

}
