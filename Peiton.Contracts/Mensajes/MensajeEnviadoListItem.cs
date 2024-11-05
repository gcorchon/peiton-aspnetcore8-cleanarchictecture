namespace Peiton.Contracts.Mensajes;

public class MensajeEnviadoListItem
{
    public int Id { get; set; }
    public string Para { get; set; } = null!;
    public string? Asunto { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public int Dias { get; set; }
}