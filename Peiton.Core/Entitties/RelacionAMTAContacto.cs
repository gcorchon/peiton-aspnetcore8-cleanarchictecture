using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class RelacionAMTAContacto
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public int Orden { get; set; }
	public string? TextoInformeSocial { get; set; }

	/* public virtual ICollection<ApoyoFormal> ApoyosFormales { get; } = new List<ApoyoFormal>(); */
	/* public virtual ICollection<DatosSociales> DatosSociales { get; } = new List<DatosSociales>(); */

}
