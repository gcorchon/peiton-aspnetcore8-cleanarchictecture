namespace Peiton.Contracts.Caja;

public class CajaFilter
{
    public string? FechaAutorizacion { get; set; }
    public string? FechaPago { get; set; }
    public string? Nombre { get; set; }
    public string? Concepto { get; set; }
    public int? Tipo { get; set; }
    public string? Importe { get; set; }
    public bool? Pendiente { get; set; }
}