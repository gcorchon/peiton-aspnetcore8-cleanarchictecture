using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem]
public class FormaPagoGastoEstimacionFinanciera
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;

	/* public virtual ICollection<GastoEstimacionFinanciera> GastosEstimacionesFinancieras { get; } = new List<GastoEstimacionFinanciera>(); */

}
