using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem("Nombre")]
public class AbogadoExterno
{
	public int Id { get; set; }
	public string Nombre { get; set; } = null!;

	/* public virtual ICollection<OtroAsunto> OtrosAsuntos { get; } = new List<OtroAsunto>(); */

}
