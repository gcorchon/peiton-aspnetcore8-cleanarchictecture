namespace Peiton.Contracts.Inmuebles;
public class SucesionViewModel
{
    public int Id { get; set; }
    public string Tutelado { get; set; } = null!;

    public string DNI { get; set; } = null!;

    public string Origen { get; set; } = null!;
    public string TipoSucesion { get; set; } = null!;
    public string Trabajador { get; set; } = null!;
    public string Estado { get; set; } = null!;

    public DateTime? FechaEscritura { get; set; }
    public bool Solicitada { get; set; }
    public bool Autorizada { get; set; }
    public bool Firme { get; set; }
    public DateTime? FechaSolicitud { get; set; }
    public DateTime? FechaAutorizacion { get; set; }
    public DateTime? FechaFirmeza { get; set; }
    public string? Observaciones { get; set; }
    public DateTime Fecha { get; set; }
}
