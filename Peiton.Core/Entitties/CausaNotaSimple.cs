using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class CausaNotaSimple
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<NotaSimple> NotasSimples { get; } = new List<NotaSimple>(); */

}
