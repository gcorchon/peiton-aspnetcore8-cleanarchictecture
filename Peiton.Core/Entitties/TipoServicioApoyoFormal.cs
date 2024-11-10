using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class TipoServicioApoyoFormal
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public string? TextoInformeSocial { get; set; }

	/* public virtual ICollection<ApoyoFormal> ApoyosFormales { get; } = new List<ApoyoFormal>(); */
	/* public virtual ICollection<ServicioApoyoFormal> ServiciosApoyosFormales { get; } = new List<ServicioApoyoFormal>(); */

}
