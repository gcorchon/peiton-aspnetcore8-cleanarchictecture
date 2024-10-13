namespace Peiton.Core.Entities;
public class CredencialMasiva
{
	public int Id { get; set; }
	public int EntidadFinancieraId { get; set; }
	public string DatosConexion { get; set; } = null!;
	public virtual EntidadFinanciera EntidadFinanciera { get; set; } = null!;

}
