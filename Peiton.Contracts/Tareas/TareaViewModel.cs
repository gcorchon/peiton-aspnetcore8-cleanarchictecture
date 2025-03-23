using Peiton.Contracts.Common;

namespace Peiton.Contracts.Tareas;

public class TareaViewModel
{
    public int? TareaDepartamentoId { get; set; }
    public int? TareaCategoriaId { get; set; }
    public int? TareaSubcategoriaId { get; set; }
    public int? TareaTipoId { get; set; }
    public ListItem? UsuarioDistribuidor { get; set; }
    public ListItem? UsuarioGestor { get; set; }
    public int? TareaEstadoId { get; set; }
    public int? TareaEntidadId { get; set; }
    public string? Motivo { get; set; }
    public string? ComentariosDistribuidor { get; set; }
    public string? ComentariosGestor { get; set; }
    public DateTime? FechaGestion { get; set; }
    public DateTime? FechaCierre { get; set; }
    public string[] Archivos { get; set; } = null!;
    public Alerta[] AlertasEnviadas { get; set; } = null!;
    public bool? Autorizado { get; set; }
}