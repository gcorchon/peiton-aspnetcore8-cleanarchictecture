using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem(ParentValue = "Fk_InmuebleTipoAutorizacion")]
public class InmuebleMotivoAutorizacion
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public int InmuebleTipoAutorizacionId { get; set; }
	public virtual InmuebleTipoAutorizacion InmuebleTipoAutorizacion { get; set; } = null!;
	/* public virtual ICollection<InmuebleAutorizacion> InmueblesAutorizaciones { get; } = new List<InmuebleAutorizacion>(); */

}
