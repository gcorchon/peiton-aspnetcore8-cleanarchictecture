namespace Peiton.Core.Entities;
public class Provincia
{
	public int Id { get; set; }
	public string Nombre { get; set; } = null!;
	public int ComunidadAutonomaId { get; set; }
	public virtual ComunidadAutonoma ComunidadAutonoma { get; set; } = null!;
	/* public virtual ICollection<Arrendamiento> Arrendamientos { get; } = new List<Arrendamiento>(); */
	/* public virtual ICollection<EntidadGestora> EntidadesGestoras { get; } = new List<EntidadGestora>(); */
	/* public virtual ICollection<Inmueble> Inmuebles { get; } = new List<Inmueble>(); */
	/* public virtual ICollection<ResidenciaHabitual> ResidenciasHabituales { get; } = new List<ResidenciaHabitual>(); */
	/* public virtual ICollection<ResidenciaHabitualHistorico> ResidenciasHabitualesHistoricos { get; } = new List<ResidenciaHabitualHistorico>(); */

}
