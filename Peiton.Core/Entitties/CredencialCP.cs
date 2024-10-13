namespace Peiton.Core.Entities;
public class CredencialCP
{
	public int Id { get; set; }
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
	public virtual EntidadFinanciera EntidadFinanciera { get; set; } = null!;
	/* public virtual ICollection<AccountCP> AccountsCP { get; } = new List<AccountCP>(); */

}
