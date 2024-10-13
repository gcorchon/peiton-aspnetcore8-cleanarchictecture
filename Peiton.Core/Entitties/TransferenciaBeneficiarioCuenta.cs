namespace Peiton.Core.Entities;
public class TransferenciaBeneficiarioCuenta
{
	public int Id { get; set; }
	public int TransferenciaBeneficiarioId { get; set; }
	public string Cuenta { get; set; } = null!;
	public virtual TransferenciaBeneficiario TransferenciaBeneficiario { get; set; } = null!;

}
