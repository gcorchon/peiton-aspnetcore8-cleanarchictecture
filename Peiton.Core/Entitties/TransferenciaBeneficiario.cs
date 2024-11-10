using Peiton.ListItems;

namespace Peiton.Core.Entities;

[ListItem("Nombre")]
public class TransferenciaBeneficiario
{
	public int Id { get; set; }
	public string Nombre { get; set; } = null!;

	/* public virtual ICollection<TransferenciaBeneficiarioCuenta> TransferenciasBeneficiariosCuentas { get; } = new List<TransferenciaBeneficiarioCuenta>(); */

}
