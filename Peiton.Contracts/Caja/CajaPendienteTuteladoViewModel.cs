using Peiton.Contracts.Common;

namespace Peiton.Contracts.Caja;

public class CajaPendienteTuteladoViewModel
{
    public int Tipo { get; set; }
    public DateTime FechaAutorizacion { get; set; }
    public bool? PagarSoloEnFecha { get; set; }
    public string Concepto { get; set; } = null!;
    public decimal Importe { get; set; }
    public int? TipoPagoId { get; set; }
    public int? MetodoPagoId { get; set; }
    public int? PeriodicidadId { get; set; }
    public string? Observaciones { get; set; }
    public bool? HablarConSocial { get; set; }
    public string Autorizador { get; set; } = null!;
    public ListItem? Centro { get; set; }
    public string? DireccionCentro { get; set; }
}