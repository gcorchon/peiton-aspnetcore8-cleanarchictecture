namespace Peiton.Contracts.Sucursales;
public class ActualizarSucursalRequest
{
    public bool Autorizada { get; set; }
    public bool Solicitada { get; set; }
    public bool Firme { get; set; }
    public DateTime? FechaAutorizacion { get; set; }
    public DateTime? FechaSolicitud { get; set; }
    public DateTime? FechaFirmeza { get; set; }
    public string? Observaciones { get; set; }
}
