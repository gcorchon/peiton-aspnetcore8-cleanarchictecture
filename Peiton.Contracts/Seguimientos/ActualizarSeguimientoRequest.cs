using Peiton.Contracts.Mensajes;

namespace Peiton.Contracts.Seguimientos;

public class ActualizarSeguimientoRequest : SeguimientoBase
{
    public IEnumerable<DestinatarioMensajeRequest> Alertas { get; set; } = null!;
}