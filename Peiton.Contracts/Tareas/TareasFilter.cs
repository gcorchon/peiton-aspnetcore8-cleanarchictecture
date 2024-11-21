namespace Peiton.Contracts.Tareas;

public class TareasFilter
{
    public DateTime? Fecha { get; set; }
    public int? TareaDepartamentoId { get; set; }
    public string? TareaCategoria { get; set; }
    public string? UsuarioGestor { get; set; }
    public string? TareaSubcategoria { get; set; }
    public int? TareaTipoId { get; set; }
}