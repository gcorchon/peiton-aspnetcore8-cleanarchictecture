using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class CategoriaConsulta
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<ConsultaAlmacenada> ConsultasAlmacenadas { get; } = new List<ConsultaAlmacenada>(); */

}
