using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class TipoPago
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<VwCaja> VwCaja { get; } = []; */
	/* public virtual ICollection<Caja> Caja { get; } = new List<Caja>(); */
	/* public virtual ICollection<CajaIncidencia> CajaIncidencias { get; } = new List<CajaIncidencia>(); */

}
