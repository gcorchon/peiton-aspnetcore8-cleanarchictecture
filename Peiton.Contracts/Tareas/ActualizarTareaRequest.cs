using Peiton.Contracts.Mensajes;

namespace Peiton.Contracts.Tareas;

public class ActualizarTareaRequest
{
    public IEnumerable<DestinatarioMensajeRequest> Alertas { get; set; } = null!;
    public int? TareaDepartamentoId { get; set; }
    public int? TareaCategoriaId { get; set; }
    public int? TareaSubcategoriaId { get; set; }
    public int? TareaTipoId { get; set; }
    public int? UsuarioDistribuidorId { get; set; }
    public int? UsuarioGestorId { get; set; }
    public int? TareaEstadoId { get; set; }
    public int? TareaEntidadId { get; set; }
    public string? Motivo { get; set; }
    public string? ComentariosDistribuidor { get; set; }
    public string? ComentariosGestor { get; set; }
    public DateTime? FechaGestion { get; set; }
    public DateTime? FechaCierre { get; set; }
    public string[] Archivos { get; set; } = null!;
}