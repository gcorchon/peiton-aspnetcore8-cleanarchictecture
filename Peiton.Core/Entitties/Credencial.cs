namespace Peiton.Core.Entities;
public class Credencial
{
	public int Id { get; set; }
	public int TuteladoId { get; set; }
	public int EntidadFinancieraId { get; set; }
	public string DatosConexion { get; set; } = null!;
	public DateTime? UltimaEjecucionCorrecta { get; set; }
	public DateTime? UltimaEjecucion { get; set; }
	public int Reintentos { get; set; }
	public bool DatosCorrectos { get; set; }
	public bool Baja { get; set; }
	public DateTime? ProximaEjecucion { get; set; }
	public bool DetenerRobot { get; set; }
	public string? UltimoXml { get; set; }
	public bool RequiereSMS { get; set; }
	public string? EBLog { get; set; }
	public virtual EntidadFinanciera EntidadFinanciera { get; set; } = null!;
	public virtual Tutelado Tutelado { get; set; } = null!;
	public virtual ICollection<Account> Accounts { get; } = new List<Account>();
	/* public virtual ICollection<CuentaCaixabank> CuentasCaixabank { get; } = new List<CuentaCaixabank>(); */
	/* public virtual ICollection<Deposit> Deposit { get; } = new List<Deposit>(); */
	/* public virtual ICollection<Fund> Fundes { get; } = new List<Fund>(); */
	/* public virtual ICollection<Loan> Loanes { get; } = new List<Loan>(); */
	/* public virtual ICollection<PensionPlan> PensionesPlanes { get; } = new List<PensionPlan>(); */
	/* public virtual ICollection<Share> Shares { get; } = new List<Share>(); */

}
