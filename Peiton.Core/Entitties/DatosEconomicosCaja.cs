namespace Peiton.Core.Entities;
public class DatosEconomicosCaja
{
	public int TuteladoId { get; set; }
	public int? LocalizacionCajaId { get; set; }
	public DateTime? FechaCustodia { get; set; }
	public bool? Tasado { get; set; }
	public bool? Entregado { get; set; }
	public DateTime? FechaEntregado { get; set; }
	public string? Descripcion { get; set; }
	public string? Observaciones { get; set; }
	public virtual LocalizacionCaja? LocalizacionCaja { get; set; }
	public virtual Tutelado Tutelado { get; set; } = null!;

}
