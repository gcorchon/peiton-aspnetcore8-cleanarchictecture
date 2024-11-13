using Peiton.Contracts.Common;

namespace Peiton.Contracts.TuteladoObjetivos;

public class TuteladoObjetivoViewModel
{
    public int TipoObjetivoId { get; set; }
    public int Orden { get; set; }
    public string? Texto { get; set; }
    public ListItem? ObjetivoSocial { get; set; }
    public DateTime? Fecha { get; set; }
    public bool? Conseguido { get; set; }
    public TareaViewModel[] Tareas { get; set; } = null!;
    public bool? NoConseguido { get; set; }
}