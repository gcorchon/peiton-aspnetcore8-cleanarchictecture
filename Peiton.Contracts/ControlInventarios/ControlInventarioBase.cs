namespace Peiton.Contracts.ControlInventarios;

public class ControlInventarioBase
{
    public int? EstadoInventarioId { get; set; }
    public DateTime? FechaSalida { get; set; }
    public int? EstadoAprobacionInventarioId { get; set; }
    public DateTime? FechaAprobacion { get; set; }
    public DateTime? FechaDenegacion { get; set; }
    public DateTime? FechaRecepcionJuzgado { get; set; }
    public string? Observaciones { get; set; }
    public int? NombramientoId { get; set; }
    public DateTime? FechaLimite { get; set; }
    public DateTime? FechaRealizacion { get; set; }
}