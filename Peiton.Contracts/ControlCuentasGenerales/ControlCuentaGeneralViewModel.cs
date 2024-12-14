using Peiton.Contracts.Common;

namespace Peiton.Contracts.ControlCuentasGenerales;

public class ControlCuentaGeneralViewModel : ControlCuentaGeneralBase
{
    public ListItem? JuzgadoArchivado { get; set; }
    public ListItem? JuzgadoPresentada { get; set; }
}