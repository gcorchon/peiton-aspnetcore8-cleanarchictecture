namespace Peiton.Core.Entities;
public class CajaIncidencia
{
	public int Id { get; set; }
	public int CajaId { get; set; }
	public DateTime FechaIncidencia { get; set; }
	public int RazonIncidenciaCajaId { get; set; }
	public string? ExplicacionIncidencia { get; set; }
	public int TuteladoId { get; set; }
	public int Tipo { get; set; }
	public DateTime FechaAutorizacion { get; set; }
	public DateTime? FechaPago { get; set; }
	public bool? PagarSoloEnFecha { get; set; }
	public string Concepto { get; set; } = null!;
	public decimal Importe { get; set; }
	public int? TipoPagoId { get; set; }
	public int? MetodoPagoId { get; set; }
	public int? PeriodicidadId { get; set; }
	public int UsuarioId { get; set; }
	public bool Pendiente { get; set; }
	public string? Observaciones { get; set; }
	public int? CentroId { get; set; }
	public string? DireccionCentro { get; set; }
	public bool? HablarConSocial { get; set; }
	public bool Anticipo { get; set; }
	public int? Recepcion { get; set; }
	public string? RecepcionOtro { get; set; }
	public int? ParentescoId { get; set; }

	public virtual Caja Caja { get; set; } = null!;
	public virtual Tutelado Tutelado { get; set; } = null!;
	public virtual MetodoPago? MetodoPago { get; set; }
	public virtual Parentesco? Parentesco { get; set; }
	public virtual Periodicidad? Periodicidad { get; set; }
	public virtual TipoPago? TipoPago { get; set; }
	public virtual Usuario Usuario { get; set; } = null!;
	public virtual RazonIncidenciaCaja RazonIncidenciaCaja { get; set; } = null!;

}
