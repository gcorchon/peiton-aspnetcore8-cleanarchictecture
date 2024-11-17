namespace Peiton.Contracts.FondosSolidarios;

public class FondoSolidarioExtendidoListItem
{
    public int Id { get; set; }
    public DateTime FechaSolicitud { get; set; }
    public DateTime? FechaRevision { get; set; }
    public DateTime? FechaAutorizacion { get; set; }
    public DateTime? FechaPago { get; set; }
    public string Tutelado { get; set; } = null!;
    public decimal Importe { get; set; }
    public string Estado { get; set; } = null!;
    public string FondoSolidarioTipoFondo { get; set; } = null!;
    public bool Caducado { get; set; }
}