namespace Peiton.Core.Entities;
public class SeguroAhorro
{
	public int Id { get; set; }
	public int TuteladoId { get; set; }
	public int? SeguroId { get; set; }
	public string? NumeroPoliza { get; set; }
	public DateTime? FechaInicio { get; set; }
	public DateTime? FechaRescate { get; set; }
	public DateTime? FechaBaja { get; set; }
	public bool Vitalicio { get; set; }
	public decimal? PrimaUnica { get; set; }
	public virtual Seguro? Seguro { get; set; }
	public virtual Tutelado Tutelado { get; set; } = null!;

}
