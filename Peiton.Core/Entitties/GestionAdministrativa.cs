namespace Peiton.Core.Entities;
public class GestionAdministrativa
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int TuteladoId { get; set; }
    public int GestionAdministrativaTipoId { get; set; }
    public string? Observaciones { get; set; }
    public DateTime FechaCreacion { get; set; }
    public int? GestorAdministrativoId { get; set; }
    public int Estado { get; set; }
    public DateTime? FechaSolicitud { get; set; }
    public DateTime? FechaDesignacion { get; set; }
    public DateTime? FechaFinalizacion { get; set; }
    public decimal? Importe { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
    public virtual Tutelado Tutelado { get; set; } = null!;
    public virtual GestionAdministrativaTipo GestionAdministrativaTipo { get; set; } = null!;
    public virtual GestorAdministrativo? GestorAdministrativo { get; set; }
}
