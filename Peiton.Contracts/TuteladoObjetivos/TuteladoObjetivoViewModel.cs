using Peiton.Contracts.Common;

namespace Peiton.Contracts.TuteladoObjetivos;

public class TuteladoObjetivoViewModel : TuteladoObjetivoBase
{
    public int TipoObjetivoId { get; set; }
    public ListItem? ObjetivoSocial { get; set; }
}