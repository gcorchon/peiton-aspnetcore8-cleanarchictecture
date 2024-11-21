namespace Peiton.Contracts.Tareas;

public class TareaListItem
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string? TareaDepartamento { get; set; }
    public string? TareaCategoria { get; set; }
    public string? UsuarioGestor { get; set; }
    public string? TareaSubcategoria { get; set; }
    public string? TareaTipo { get; set; }
    public int? TareaEstadoId { get; set; }
}