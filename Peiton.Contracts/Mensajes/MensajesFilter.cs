namespace Peiton.Contracts.Mensajes;

public class MensajesFilter
{
    public string? Persona { get; set; }
    public string? Asunto { get; set; }
    public string? Fecha { get; set; }
    public int? Dias { get; set; }
    public string? Estado { get; set; }
}