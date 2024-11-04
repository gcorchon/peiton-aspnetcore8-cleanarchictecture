namespace Peiton.Contracts.Mensajes;

public class MensajeViewModel
{
    public string[] Para { get; set; } = null!;
    public string[]? ConCopia { get; set; } = null!;
    public string Asunto { get; set; } = null!;
    public string Cuerpo { get; set; } = null!;
    public int Dias { get; set; }
}