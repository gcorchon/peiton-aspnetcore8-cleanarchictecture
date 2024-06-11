namespace Peiton.Contracts.Vales;

public class ValeListItem
{
    public int Id { get; set; }
    public DateTime FechaSolicitud { get; set; }
    public DateTime? FechaRevision { get; set; }
    public DateTime? FechaAutorizacion { get; set; }
    public DateTime? FechaPago { get; set; }
    public string Solicitante { get; set; } = "";
    public bool Revisado { get; set; }
    public bool Autorizado { get; set; }
    public bool Pagado { get; set; }
    public bool Rechazado { get; set; }
    public decimal Importe { get; set; }

}
