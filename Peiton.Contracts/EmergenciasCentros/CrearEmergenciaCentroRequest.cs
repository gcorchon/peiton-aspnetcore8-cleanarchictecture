namespace Peiton.Contracts.EmergenciasCentros;

public class CrearEmergenciaCentroRequest
{
    public int TuteladoId { get; set; }
	public int MotivoEmergenciaCentroId { get; set; }
	public DateTime Fecha { get; set; }
	public string Descripcion { get; set; } = null!;
}