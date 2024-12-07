namespace Peiton.Contracts.Emergencias;

public class EmergenciasFilter
{
	public string? MotivoEmergencia { get; set; } = null!;
	public DateTime? Fecha { get; set; }
	public string? Hora { get; set; }
	public string? Descripcion { get; set; } = null!;
	public string? EmergenciaLlamada { get; set; }
}