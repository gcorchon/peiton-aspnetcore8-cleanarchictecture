namespace Peiton.Contracts.Caja;

public class CajaTuteladoListItem
{
    public int Id { get; set; }
    public DateTime FechaAutorizacion { get; set; }
    public DateTime? FechaPago { get; set; }
    public string Concepto { get; set; } = null!;
    public string? TipoPago { get; set; }
    public string? MetodoPago { get; set; }
    public bool Anticipo { get; set; }
    public decimal Importe { get; set; }
    public decimal Balance { get; set; }


}