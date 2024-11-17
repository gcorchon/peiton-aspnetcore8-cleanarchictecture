namespace Peiton.Contracts.FondosSolidarios;

public class ActualizarFondoSolidarioRequest
{
    public int? FondoSolidarioFormaPagoId { get; set; }
    public int? FondoSolidarioTarjetaPrepagoId { get; set; }
    public DateTime? FechaPago { get; set; }
    public string ObservacionesAutorizacion { get; set; } = null!;
    public bool Revisado { get; set; }
    public bool Autorizado { get; set; }
    public bool Pagado { get; set; }
    public bool Rechazado { get; set; }
    public bool Verificado { get; set; }
    public DateTime? FechaBaja { get; set; }
}