using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class Distrito
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<Arrendamiento> Arrendamientos { get; } = new List<Arrendamiento>(); */
	/* public virtual ICollection<Inmueble> Inmuebles { get; } = new List<Inmueble>(); */
	/* public virtual ICollection<ResidenciaHabitual> ResidenciasHabituales { get; } = new List<ResidenciaHabitual>(); */
	/* public virtual ICollection<ResidenciaHabitualHistorico> ResidenciasHabitualesHistoricos { get; } = new List<ResidenciaHabitualHistorico>(); */

}
