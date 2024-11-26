namespace Peiton.Contracts.Caja;

public class CajaTuteladoFilter
{
    public DateTime? FechaAutorizacion { get; set; }
    public DateTime? FechaPago { get; set; }
    public string? Concepto { get; set; } = null!;
    public int? TipoPagoId { get; set; }
    public int? MetodoPagoId { get; set; }
    public bool? Anticipo { get; set; }
    public decimal? Importe { get; set; }
    public decimal? Balance { get; set; }

}