using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class FormaPago
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<Asiento> Asientos { get; } = new List<Asiento>(); */

}
