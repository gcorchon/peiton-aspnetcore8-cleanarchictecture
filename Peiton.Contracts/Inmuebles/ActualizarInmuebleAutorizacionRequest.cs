namespace Peiton.Contracts.Inmuebles;
public class ActualizarInmuebleAutorizacionRequest
{
    public bool Autorizado { get; set; }
    public bool Presentado { get; set; }
    public bool Firme { get; set; }
    public DateTime? FechaAutorizado { get; set; }
    public DateTime? FechaPresentado { get; set; }
    public DateTime? FechaFirme { get; set; }
    public string? Observaciones { get; set; }
    public bool Archivo { get; set; }
}
