namespace Peiton.Contracts.Caja;

public class CajaPendienteTuteladoFilter
{
    public DateTime? FechaAutorizacion { get; set; }
    public string? Concepto { get; set; } = null!;
    public int? TipoPagoId { get; set; }
    public int? MetodoPagoId { get; set; }
    public decimal? Importe { get; set; }
}