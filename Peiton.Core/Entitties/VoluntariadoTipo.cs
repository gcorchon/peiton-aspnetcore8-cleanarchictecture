using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class VoluntariadoTipo
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<Voluntariado> Voluntariados { get; } = new List<Voluntariado>(); */

}
