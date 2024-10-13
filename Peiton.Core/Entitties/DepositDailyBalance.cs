namespace Peiton.Core.Entities;
public class DepositDailyBalance
{
	public int DepositId { get; set; }
	public DateTime Fecha { get; set; }
	public decimal Balance { get; set; }
	public virtual Deposit Deposit { get; set; } = null!;

}
