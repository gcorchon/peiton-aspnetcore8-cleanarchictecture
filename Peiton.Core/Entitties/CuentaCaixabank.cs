namespace Peiton.Core.Entities;
public class CuentaCaixabank
{
	public string Iban { get; set; } = null!;
	public int CredencialId { get; set; }
	public virtual Credencial Credencial { get; set; } = null!;

}
