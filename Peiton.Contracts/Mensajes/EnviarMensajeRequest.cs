namespace Peiton.Contracts.Mensajes;

public class EnviarMensajeRequest
{
    public IEnumerable<DestinatarioMensaje> Para { get; set; } = null!;
    public IEnumerable<DestinatarioMensaje> ConCopia { get; set; } = null!;

    public string Asunto { get; set; } = null!;
    public string Cuerpo { get; set; } = null!;
}