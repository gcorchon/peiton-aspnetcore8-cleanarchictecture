namespace Peiton.Core.Entities;
public class PensionPlanDailyInfo
{
	public int PensionPlanId { get; set; }
	public DateTime Fecha { get; set; }
	public decimal Balance { get; set; }
	public DateTime ValueDate { get; set; }
	public virtual PensionPlan PensionPlan { get; set; } = null!;

}
