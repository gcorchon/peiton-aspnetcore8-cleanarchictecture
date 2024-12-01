namespace Peiton.Contracts.Caja;


public class ActualizarMovimientoCajaTuteladoRequest
{
    public DateTime FechaAutorizacion { get; set; }
    public bool? PagarSoloEnFecha { get; set; }
    public string Concepto { get; set; } = null!;
    public decimal Importe { get; set; }
    public int? TipoPagoId { get; set; }
    public int? MetodoPagoId { get; set; }
    public int? PeriodicidadId { get; set; }
    public string? Observaciones { get; set; }
    public bool? HablarConSocial { get; set; }
    public int? CentroId { get; set; }
    public string? DireccionCentro { get; set; }
}
