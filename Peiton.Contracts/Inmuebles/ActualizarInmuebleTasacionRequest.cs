namespace Peiton.Contracts.Inmuebles;
public class ActualizarInmuebleTasacionRequest
{
    public bool Autorizado { get; set; }
    public bool Presentado { get; set; }
    public bool Firme { get; set; }
    public DateTime? FechaAutorizado { get; set; }
    public DateTime? FechaPresentado { get; set; }
    public DateTime? FechaFirme { get; set; }
    public string? Observaciones { get; set; } = null!;
    public int? InmuebleTasadorId { get; set; }
    public decimal? ValorTasacion { get; set; }
    public decimal? PrecioVenta { get; set; }
}
