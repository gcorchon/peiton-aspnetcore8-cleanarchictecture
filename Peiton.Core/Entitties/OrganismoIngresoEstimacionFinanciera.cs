using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class OrganismoIngresoEstimacionFinanciera
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<IngresoEstimacionFinanciera> IngresosEstimacionesFinancieras { get; } = new List<IngresoEstimacionFinanciera>(); */

}
