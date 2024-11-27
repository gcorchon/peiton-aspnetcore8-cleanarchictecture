namespace Peiton.Contracts.Caja;

public class CajaPendienteTuteladoListItem
{
    public int Id { get; set; }
    public DateTime FechaAutorizacion { get; set; }
    public string Concepto { get; set; } = null!;
    public string? TipoPago { get; set; }
    public string? MetodoPago { get; set; }
    public decimal Importe { get; set; }
}