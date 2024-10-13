namespace Peiton.Contracts.Facturas;

public class FacturaListItem
{
    public int Id { get; set; }
    public DateTime? FechaRegistro { get; set; }
    public string? EstadoInicial { get; set; }
    public string? EstadoContable { get; set; }
    public string? Denominacion { get; set; }
    public string? NumeroFactura { get; set; }
    public decimal? Importe { get; set; }
    public DateTime? FechaPago { get; set; }
}

