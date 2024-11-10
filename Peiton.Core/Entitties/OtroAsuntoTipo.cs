using Peiton.ListItems;

namespace Peiton.Core.Entities;
[ListItem]
public class OtroAsuntoTipo
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<OtroAsunto> OtrosAsuntos { get; } = new List<OtroAsunto>(); */

}
