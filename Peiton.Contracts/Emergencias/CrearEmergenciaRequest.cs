namespace Peiton.Contracts.Emergencias;

public class CrearEmergenciaRequest
{
    public int TuteladoId { get; set; }
	public int MotivoEmergenciaId { get; set; }
	public DateTime Fecha { get; set; }
	public string Descripcion { get; set; } = null!;
	public int? EmergenciaLlamadaId { get; set; }
}