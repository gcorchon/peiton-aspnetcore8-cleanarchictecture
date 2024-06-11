namespace Peiton.Contracts.Vales;
public class ActualizarValeRequest
{
    public string? ObservacionesAutorizacion { get; set; }
    public bool Revisado { get; set; }
    public bool Autorizado { get; set; }
    public bool Pagado { get; set; }
    public bool Rechazado { get; set; }
}