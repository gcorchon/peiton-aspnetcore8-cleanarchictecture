using Peiton.ListItems;

namespace Peiton.Core.Entities;
[ListItem]
public class UrgenciaConceptoCoste
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<UrgenciaCoste> UrgenciasCostes { get; } = new List<UrgenciaCoste>(); */

}
