namespace Peiton.Core.Entities;
public class AccountTransactionCP
{
	public int Id { get; set; }
	public int AccountCPId { get; set; }
	public string Description { get; set; } = null!;
	public string Reference { get; set; } = null!;
	public string Payer { get; set; } = null!;
	public string Payee { get; set; } = null!;
	public DateTime OperationDate { get; set; }
	public DateTime ValueDate { get; set; }
	public decimal Quantity { get; set; }
	public DateTime Fecha { get; set; }
	public bool Ocultar { get; set; }
	public string Origen { get; set; } = null!;
	public string? AfterbanksTransactionId { get; set; }
	public virtual AccountCP AccountCP { get; set; } = null!;
	public virtual ICollection<Asiento> Asientos { get; } = new List<Asiento>();

}
