namespace Peiton.Core.Entities;
public class Deposit
{
	public int Id { get; set; }
	public int CredencialId { get; set; }
	public string AccountNumber { get; set; } = null!;
	public DateTime? StartDate { get; set; }
	public DateTime? LastDate { get; set; }
	public string? WebAlias { get; set; }
	public DateTime Fecha { get; set; }
	public DateTime? FechaBaja { get; set; }
	public decimal? Saldo { get; set; }
	public DateTime? FechaSaldo { get; set; }
	public string? Observaciones { get; set; }
	public string? Titularidad { get; set; }
	public bool Baja { get; set; }
	public string? CustomWebAlias { get; set; }
	public string Origen { get; set; } = null!;
	public virtual Credencial Credencial { get; set; } = null!;
	/* public virtual ICollection<DepositDailyBalance> DepositDailyBalances { get; } = new List<DepositDailyBalance>(); */

}
