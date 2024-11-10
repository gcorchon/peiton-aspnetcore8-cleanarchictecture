using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class TipoFinanciacionPublica
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<ResidenciaHabitual> ResidenciasHabituales { get; } = new List<ResidenciaHabitual>(); */
	/* public virtual ICollection<ResidenciaHabitualHistorico> ResidenciasHabitualesHistoricos { get; } = new List<ResidenciaHabitualHistorico>(); */

}
