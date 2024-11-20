namespace Peiton.Contracts.Mensajes;

public class EnviarMensajeRequest
{
    public IEnumerable<DestinatarioMensajeRequest> Para { get; set; } = null!;
    public IEnumerable<DestinatarioMensajeRequest> ConCopia { get; set; } = null!;

    public string Asunto { get; set; } = null!;
    public string Cuerpo { get; set; } = null!;
}