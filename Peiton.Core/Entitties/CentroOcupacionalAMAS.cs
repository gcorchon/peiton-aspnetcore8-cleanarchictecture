using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class CentroOcupacionalAMAS
{
	public int Id { get; set; }
	public string Nombre { get; set; } = null!;

	/* public virtual ICollection<DatosSociales> DatosSociales { get; } = new List<DatosSociales>(); */

}
