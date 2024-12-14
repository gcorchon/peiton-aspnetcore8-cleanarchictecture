namespace Peiton.Contracts.ControlRendiciones;

public class ControlRendicionBase
{
    public int TipoRendicionId { get; set; }
    public DateTime? FechaInicioIncidencia { get; set; }
    public DateTime? FechaFinIncidencia { get; set; }
    public int? TipoIncidencia { get; set; }
    public DateTime? FechaInicioRendicion { get; set; }
    public DateTime? FechaFinRendicion { get; set; }
    public DateTime? FechaSalidaAMTA { get; set; }
    public DateTime? FechaRecepcionJuzgado { get; set; }
    public int? NombramientoId { get; set; }
    public decimal? RendimientoLiquido { get; set; }
    public int? EstadoAprobacionRendicionId { get; set; }
    public DateTime? FechaRendicionAprobada { get; set; }
    public int? TipoAprobacionRendicionId { get; set; }
    public DateTime? FechaRendicionDenegada { get; set; }
    public string? Observaciones { get; set; }
    public int? EstadoRetribucionId { get; set; }
    public DateTime? FechaRetribucionConcedida { get; set; }
    public decimal? Porcentaje { get; set; }
    public decimal? Importe { get; set; }
}