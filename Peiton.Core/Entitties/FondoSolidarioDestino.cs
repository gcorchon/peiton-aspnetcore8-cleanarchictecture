namespace Peiton.Core.Entities;
public class FondoSolidarioDestino
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public int? FondoSolidarioTipoFondoId { get; set; }
	public virtual FondoSolidarioTipoFondo? FondoSolidarioTipoFondo { get; set; }
	/* public virtual ICollection<FondoSolidario> FondosSolidarios { get; } = new List<FondoSolidario>(); */
	/* public virtual ICollection<UrgenciaFondoSolidario> UrgenciasFondosSolidarios { get; } = new List<UrgenciaFondoSolidario>(); */

}
