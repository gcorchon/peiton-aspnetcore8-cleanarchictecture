using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class TipoCategoria
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<Categoria> Categorias { get; } = new List<Categoria>(); */

}
