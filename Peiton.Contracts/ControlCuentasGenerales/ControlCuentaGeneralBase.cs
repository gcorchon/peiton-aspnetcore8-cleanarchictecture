namespace Peiton.Contracts.ControlCuentasGenerales;

public class ControlCuentaGeneralBase
{
    public int TipoCGJId { get; set; }
    public DateTime? FechaArchivado { get; set; }
    public int? NombramientoArchivadoId { get; set; }
    public DateTime? FechaInicioPresentada { get; set; }
    public DateTime? FechaFinPresentada { get; set; }
    public DateTime? FechaSalidaAMTA { get; set; }
    public DateTime? FechaRecepcionJuzgado { get; set; }
    public int? NombramientoPresentadaId { get; set; }
    public int? MotivoMuertoId { get; set; }
    public int? EstadoAprobacionCGJId { get; set; }
    public DateTime? FechaAprobacion { get; set; }
    public DateTime? FechaDenegacion { get; set; }
    public int? RazonDenegacionCGJId { get; set; }
    public string? Observaciones { get; set; }
    public int? ArchivoCGJId { get; set; }
    public int? ArchivoAprobacionId { get; set; }
}