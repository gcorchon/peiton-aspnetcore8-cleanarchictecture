using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class InmuebleTipoAutorizacion
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<InmuebleMotivoAutorizacion> InmueblesMotivosAutorizaciones { get; } = new List<InmuebleMotivoAutorizacion>(); */

}
