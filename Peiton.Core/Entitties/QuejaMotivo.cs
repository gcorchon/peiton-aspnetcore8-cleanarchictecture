using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class QuejaMotivo
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	public virtual ICollection<Queja> Quejas { get; } = new List<Queja>();
}
