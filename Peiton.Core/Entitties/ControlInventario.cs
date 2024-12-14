namespace Peiton.Core.Entities;
public class ControlInventario
{
	public int Id { get; set; }
	public int TuteladoId { get; set; }
	public int? EstadoInventarioId { get; set; }
	public DateTime? FechaSalida { get; set; }
	public int? EstadoAprobacionInventarioId { get; set; }
	public DateTime? FechaAprobacion { get; set; }
	public DateTime? FechaDenegacion { get; set; }
	public DateTime? FechaRecepcionJuzgado { get; set; }
	public string? Observaciones { get; set; }
	public int? Documento { get; set; }
	public int? NombramientoId { get; set; }
	public int? JuzgadoId { get; set; }
	public DateTime? FechaLimite { get; set; }
	public DateTime? FechaRealizacion { get; set; }
	public int? ProfesionalId { get; set; }
	public virtual Nombramiento? Nombramiento { get; set; }
	public virtual EstadoAprobacionInventario? EstadoAprobacionInventario { get; set; }
	public virtual EstadoInventario? EstadoInventario { get; set; }
	public virtual Juzgado? Juzgado { get; set; }
	public virtual Tutelado Tutelado { get; set; } = null!;

}
