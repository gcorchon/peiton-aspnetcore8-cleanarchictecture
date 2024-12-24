using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class TipoTitularidad
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	public virtual ICollection<InmuebleTipoTitularidad> InmueblesTiposTitularidades { get; } = [];

}
