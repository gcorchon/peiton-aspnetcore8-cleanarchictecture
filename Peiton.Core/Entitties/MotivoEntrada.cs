using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class MotivoEntrada
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<RegistroEntrada> RegistrosEntradas { get; } = new List<RegistroEntrada>(); */

}
