namespace Peiton.Contracts.Requerimientos;

public class GuardarRequerimientoRequest
{
    public string? Comentarios { get; set; }
    public string? NumeroProcedimiento { get; set; }
    public DateTime? FechaContestado { get; set; }
    public bool Contestado { get; set; }
    public bool SolicitadoAplazamiento { get; set; }
    public int? RequerimientoTipoId { get; set; }
    public int? RequerimientoDetalleId { get; set; }
    public int? RequerimientoOrigenId { get; set; }
    public int TuteladoId { get; set; }
    public int? JuzgadoId { get; set; }
    public int? UsuarioId { get; set; }
    public int? ArchivoRequerimientoId { get; set; }
    public int? ContestacionRequerimientoId { get; set; }
}