namespace Peiton.Contracts.FondosSolidarios;

public class FondosSolidariosFilter
{
    public DateTime? FechaSolicitud { get; set; }
    public DateTime? FechaRevision { get; set; }
    public DateTime? FechaAutorizacion { get; set; }
    public DateTime? FechaPago { get; set; }
    public string? Tutelado { get; set; }
    public decimal? Importe { get; set; }
    public int? Estado { get; set; }
    public int? FondoSolidarioTipoFondoId { get; set; }
}