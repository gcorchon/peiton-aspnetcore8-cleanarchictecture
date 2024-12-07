namespace Peiton.Contracts.EmergenciasCentros;

public class EmergenciasCentrosFilter
{
	public string? MotivoEmergenciaCentro { get; set; } = null!;
	public DateTime? Fecha { get; set; }
	public string? Hora { get; set; }
	public string? Descripcion { get; set; } = null!;
}