using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class FondoSolidarioFormaPago
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<FondoSolidario> FondosSolidarios { get; } = new List<FondoSolidario>(); */
	/* public virtual ICollection<UrgenciaFondoSolidario> UrgenciasFondosSolidarios { get; } = new List<UrgenciaFondoSolidario>(); */

}
