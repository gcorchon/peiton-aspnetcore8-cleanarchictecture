using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class LocalizacionCaja
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<DatosEconomicosCaja> DatosEconomicosCaja { get; } = new List<DatosEconomicosCaja>(); */

}
