namespace Peiton.Core.Entities;
public class FundDailyInfo
{
	public int FundId { get; set; }
	public DateTime Fecha { get; set; }
	public decimal Balance { get; set; }
	public DateTime ValueDate { get; set; }
	public virtual Fund Fund { get; set; } = null!;

}
