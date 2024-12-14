using Peiton.Contracts.Common;

namespace Peiton.Contracts.ControlRendiciones;

public class ActualizarControlRendicionRequest : ControlRendicionBase
{
    public int? JuzgadoId { get; set; }
}