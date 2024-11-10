using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class Seguro
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<SeguroAhorro> SegurosAhorros { get; } = new List<SeguroAhorro>(); */
	/* public virtual ICollection<SeguroContratado> SegurosContratados { get; } = new List<SeguroContratado>(); */

}
