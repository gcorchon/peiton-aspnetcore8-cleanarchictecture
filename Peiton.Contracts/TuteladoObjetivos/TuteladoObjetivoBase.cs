namespace Peiton.Contracts.TuteladoObjetivos;

public class TuteladoObjetivoBase
{
    public int Orden { get; set; }
    public string? Texto { get; set; }
    public DateTime? Fecha { get; set; }
    public bool? Conseguido { get; set; }
    public TareaViewModel[] Tareas { get; set; } = null!;
    public bool? NoConseguido { get; set; }
}