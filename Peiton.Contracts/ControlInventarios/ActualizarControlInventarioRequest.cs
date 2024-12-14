using Peiton.Contracts.Common;

namespace Peiton.Contracts.ControlInventarios;

public class ActualizarControlInventarioRequest : ControlInventarioBase
{
    public int? JuzgadoId { get; set; }
}