using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class AdaptacionCentro
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public string? TextoInformeSocial { get; set; }

	/* public virtual ICollection<DatosSociales> DatosSociales { get; } = new List<DatosSociales>(); */

}
