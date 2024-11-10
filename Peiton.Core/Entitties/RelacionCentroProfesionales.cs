using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class RelacionCentroProfesionales
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public string? TextoInformeSocial { get; set; }
	public string? TextoInformeSocial2 { get; set; }
	public string? TextoInformeSocial3 { get; set; }

	/* public virtual ICollection<DatosSociales> DatosSociales { get; } = new List<DatosSociales>(); */

}
