using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class MotivoEmergencia
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public bool Visible { get; set; } = true;

	/* public virtual ICollection<Emergencia> Emergencias { get; } = new List<Emergencia>(); */

}
