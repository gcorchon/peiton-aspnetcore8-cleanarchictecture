namespace Peiton.Contracts.Caja;

public class HistoricoMovimientoListItem
{
    public int Id { get; set; }
    public DateTime FechaPago { get; set; }
    public string? Metodo { get; set; } = "";
    public string Concepto { get; set; } = "";
    public string? Tipo { get; set; } = "";
    public decimal Importe { get; set; }
    public bool Anticipo { get; set; }
}