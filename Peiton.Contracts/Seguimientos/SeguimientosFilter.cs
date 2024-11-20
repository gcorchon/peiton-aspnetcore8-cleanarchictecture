namespace Peiton.Contracts.Seguimientos;

public class SeguimientosFilter
{
    public int? CategoriaAgendaId { get; set; }
    public string? Tutelado { get; set; }
    public string? Descripcion { get; set; }
    public DateTime? Fecha { get; set; }
    public int? AgendaActuacionId { get; set; }
}