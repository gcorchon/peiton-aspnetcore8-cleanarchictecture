namespace Peiton.Core.Entities;

public class Requerimiento
{
    public int Id { get; set; }
    public int TuteladoId { get; set; }
    public string? Comentarios { get; set; }
    public string? NumeroProcedimiento { get; set; }
    public DateTime FechaRequerimiento { get; set; }
    public DateTime? FechaContestado { get; set; }
    public bool Contestado { get; set; }
    public bool SolicitadoAplazamiento { get; set; }
    public int? RequerimientoTipoId { get; set; }
    public int? RequerimientoDetalleId { get; set; }
    public int? RequerimientoOrigenId { get; set; }
    public int? JuzgadoId { get; set; }
    public int? UsuarioId { get; set; }
    public int? ArchivoRequerimientoId { get; set; }
    public int? ContestacionRequerimientoId { get; set; }
    public virtual Tutelado Tutelado { get; set; } = null!;
    public virtual RequerimientoTipo? RequerimientoTipo { get; set; }
    public virtual RequerimientoDetalle? RequerimientoDetalle { get; set; }
    public virtual RequerimientoOrigen? RequerimientoOrigen { get; set; }
    public virtual Juzgado? Juzgado { get; set; }
    public virtual Usuario? Usuario { get; set; }
    public virtual Archivo? ArchivoRequerimiento { get; set; }
    public virtual Archivo? ContestacionRequerimiento { get; set; }
}
