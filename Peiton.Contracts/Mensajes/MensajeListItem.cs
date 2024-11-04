namespace Peiton.Contracts.Mensajes;

public class MensajeListItem
{
    public int Id { get; set; }
    public Remitente Remitente { get; set; } = null!;
    public string? Asunto { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public int Dias { get; set; }
    public string Estado { get; set; } = null!;
    public string? CssClass { get; set; }
}