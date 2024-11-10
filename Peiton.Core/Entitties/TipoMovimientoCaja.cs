using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class TipoMovimientoCaja
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

}
