using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class RelacionAllegado
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<TuteladoAllegado> TuteladosAllegados { get; } = new List<TuteladoAllegado>(); */

}
