using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem(ParentValue = "Fk_TipoServicioApoyoFormal")]
public class ServicioApoyoFormal
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public int TipoServicioApoyoFormalId { get; set; }
	public string? TextoInformeSocial { get; set; }
	public virtual TipoServicioApoyoFormal TipoServicioApoyoFormal { get; set; } = null!;
	/* public virtual ICollection<ApoyoFormal> ApoyosFormales { get; } = new List<ApoyoFormal>(); */
	/* public virtual ICollection<AtencionApoyoFormal> AtencionesApoyosFormales { get; } = new List<AtencionApoyoFormal>(); */

}
