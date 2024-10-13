namespace Peiton.Core.Entities;
public class Prestamo
{
	public int Id { get; set; }
	public int TuteladoId { get; set; }
	public int TipoPrestamoId { get; set; }
	public int EntidadFinancieraId { get; set; }
	public decimal? Inicial { get; set; }
	public decimal? Pendiente { get; set; }
	public decimal? Cuota { get; set; }
	public string? Localizacion { get; set; }
	public DateTime? Fecha { get; set; }
	public string? Porcentaje { get; set; }
	public DateTime? FechaInicio { get; set; }
	public string? Observaciones { get; set; }
	public bool? Baja { get; set; }
	public DateTime? FechaBaja { get; set; }
	public string? Numero { get; set; }
	public virtual EntidadFinanciera EntidadFinanciera { get; set; } = null!;
	public virtual TipoPrestamo TipoPrestamo { get; set; } = null!;
	public virtual Tutelado Tutelado { get; set; } = null!;

}
