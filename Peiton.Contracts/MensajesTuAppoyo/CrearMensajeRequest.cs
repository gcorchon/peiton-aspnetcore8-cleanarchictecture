namespace Peiton.Contracts.MensajesTuAppoyo;

public class CrearMensajeRequest
{
    public int TuteladoId { get; set; }
    public string Asunto { get; set; } = null!;
    public string Cuerpo { get; set; } = null!;
}