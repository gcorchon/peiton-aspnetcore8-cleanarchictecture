namespace Peiton.Contracts.Caja;

public class HistoricoMovimientosFilter
{
    public string? FechaAutorizacion { get; set; }
    public string? Concepto { get; set; }
    public int? Metodo { get; set; }
    public string? Importe { get; set; }
    public bool? Anticipo { get; set; }
}