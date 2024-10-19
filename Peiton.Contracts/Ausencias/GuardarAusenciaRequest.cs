namespace Peiton.Contracts.Ausencias;

public class GuardarAusenciaRequest
{
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }

    public int UsuarioId { get; set; }
    public int? UsuarioSuplenteId { get; set; }
}

