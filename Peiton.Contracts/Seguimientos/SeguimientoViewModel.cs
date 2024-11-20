namespace Peiton.Contracts.Seguimientos;

public class SeguimientoViewModel
{
    public int CategoriaAgendaId { get; set; }
    public string Descripcion { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public int? AgendaActuacionId { get; set; }
    public bool? Realizada { get; set; }
    public int? Minutos { get; set; }
    public int? AgendaAreaActuacionId { get; set; }
    public DateTime? FechaActuacion { get; set; }
    public bool Desacuerdo { get; set; }
}