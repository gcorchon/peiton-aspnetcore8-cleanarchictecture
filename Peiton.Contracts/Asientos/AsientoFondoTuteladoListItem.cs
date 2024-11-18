namespace Peiton.Contracts.Asientos;

public class AsientoFondoTuteladoListItem
{
    public int Numero { get; set; }
    public string Tipo { get; set; } = "";
    public string Concepto { get; set; } = "";
    public decimal Importe { get; set; }
    public DateTime? FechaPago { get; set; }
    public DateTime? FechaAutorizacion { get; set; }
}