using Peiton.Contracts.Mensajes;

namespace Peiton.Contracts.Seguimientos;

public class ActualizarSeguimientoRequest : SeguimientoViewModel
{
    public IEnumerable<DestinatarioMensajeRequest> Alertas { get; set; } = null!;
}