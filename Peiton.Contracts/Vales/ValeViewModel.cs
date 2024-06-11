namespace Peiton.Contracts.Vales;

public class ValeViewModel
{
    public int Id { get; set; }
    public string Solicitante { get; set; } = "";
    public string Revisor { get; set; } = "";
    public string Autorizador { get; set; } = "";
    public DateTime FechaSolicitud { get; set; }
    public DateTime? FechaRevision { get; set; }
    public DateTime? FechaAutorizacion { get; set; }
    public DateTime? FechaPago { get; set; }
    public decimal Importe { get; set; }
    public string ObservacionesSolicitud { get; set; } = "";
    public string[] Archivos { get; set; } = [];
    public string ObservacionesAutorizacion { get; set; } = "";
    public bool Revisado { get; set; }
    public bool Autorizado { get; set; }
    public bool Pagado { get; set; }
    public bool Rechazado { get; set; }
}
