namespace Peiton.Core.Entities;
public class ControlCuentaGeneral
{
	public int Id { get; set; }
	public int TuteladoId { get; set; }
	public int TipoCGJId { get; set; }
	public DateTime? FechaArchivado { get; set; }
	public int? JuzgadoArchivadoId { get; set; }
	public int? NombramientoArchivadoId { get; set; }
	public DateTime? FechaInicioPresentada { get; set; }
	public DateTime? FechaFinPresentada { get; set; }
	public DateTime? FechaSalidaAMTA { get; set; }
	public DateTime? FechaRecepcionJuzgado { get; set; }
	public int? JuzgadoPresentadaId { get; set; }
	public int? NombramientoPresentadaId { get; set; }
	public int? MotivoMuertoId { get; set; }
	public int? EstadoAprobacionCGJId { get; set; }
	public DateTime? FechaAprobacion { get; set; }
	public DateTime? FechaDenegacion { get; set; }
	public int? RazonDenegacionCGJId { get; set; }
	public string? Observaciones { get; set; }
	public int? ArchivoCGJId { get; set; }
	public int? ArchivoAprobacionId { get; set; }
	public virtual EstadoAprobacionCGJ? EstadoAprobacionCGJ { get; set; }
	public virtual MotivoMuerto? MotivoMuerto { get; set; }
	public virtual RazonDenegacionCGJ? RazonDenegacionCGJ { get; set; }
	public virtual TipoCGJ TipoCGJ { get; set; } = null!;
	public virtual Archivo? ArchivoAprobacion { get; set; }
	public virtual Archivo? ArchivoCGJ { get; set; }
	public virtual Juzgado? JuzgadoArchivado { get; set; }
	public virtual Juzgado? JuzgadoPresentada { get; set; }
	public virtual Nombramiento? NombramientoArchivado { get; set; }
	public virtual Nombramiento? NombramientoPresentada { get; set; }
	public virtual Tutelado Tutelado { get; set; } = null!;

}
