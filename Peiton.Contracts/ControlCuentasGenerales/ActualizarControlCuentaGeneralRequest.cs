using Peiton.Contracts.Common;

namespace Peiton.Contracts.ControlCuentasGenerales;

public class ActualizarControlCuentaGeneralRequest : ControlCuentaGeneralBase
{
    public int? JuzgadoArchivadoId { get; set; }
    public int? JuzgadoPresentadaId { get; set; }
}