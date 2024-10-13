namespace Peiton.Core.Entities;
public class PensionPlan
{
	public int Id { get; set; }
	public int CredencialId { get; set; }
	public string PlanNumber { get; set; } = null!;
	public string WebAlias { get; set; } = null!;
	public decimal Saldo { get; set; }
	public string Currency { get; set; } = null!;
	public DateTime? StartDate { get; set; }
	public DateTime FechaSaldo { get; set; }
	public DateTime Fecha { get; set; }
	public bool Baja { get; set; }
	public DateTime? FechaBaja { get; set; }
	public string? Titularidad { get; set; }
	public string? Observaciones { get; set; }
	public string Origen { get; set; } = null!;
	public virtual Credencial Credencial { get; set; } = null!;
	/* public virtual ICollection<PensionPlanDailyInfo> PensionesPlanesDailyInfos { get; } = new List<PensionPlanDailyInfo>(); */

}
