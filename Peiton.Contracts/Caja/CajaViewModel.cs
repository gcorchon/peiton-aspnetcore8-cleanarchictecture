using Peiton.Contracts.Common;

namespace Peiton.Contracts.Caja;

public class CajaViewModel
{
    public int Tipo { get; set; }
    public DateTime FechaAutorizacion { get; set; }
    public bool? PagarSoloEnFecha { get; set; }
    public string Concepto { get; set; } = null!;
    public decimal Importe { get; set; }
    public int? TipoPagoId { get; set; }
    public int? MetodoPagoId { get; set; }
    public int? PeriodicidadId { get; set; }
    public bool Pendiente { get; set; }
    public string? Observaciones { get; set; }
    public bool? HablarConSocial { get; set; }
    public bool Anticipo { get; set; }
    public int? Recepcion { get; set; }
    public string? RecepcionOtro { get; set; }
    public int? ParentescoId { get; set; }
    public string Autorizador { get; set; } = null!;
    public string? Centro { get; set; }
    public string? DireccionCentro { get; set; }
    public decimal SaldoCaja { get; set; } // <!-- Este valor hay que calcularlo aparte, no está en la tabla de Caja
}