namespace Peiton.Contracts.Vales;

public class ValesFilter
{
    public string? FechaSolicitud { get; set; }
    public string? FechaRevision { get; set; }
    public string? FechaAutorizacion { get; set; }
    public string? FechaPago { get; set; }
    public string? Solicitante { get; set; }
    public int? Estado { get; set; }
    public string? Importe { get; set; }
}
