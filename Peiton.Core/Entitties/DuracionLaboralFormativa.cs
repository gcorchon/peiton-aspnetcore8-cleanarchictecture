using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class DuracionLaboralFormativa
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<DatosSociales> DatosSociales { get; } = new List<DatosSociales>(); */

}
