namespace Peiton.Core.Entities;
public class Senalamiento
{
	public int Id { get; set; }
	public DateTime? Fecha { get; set; }
	public string? Procedimiento { get; set; }
	public int? JuzgadoId { get; set; }
	public int? TuteladoId { get; set; }
	public int? AbogadoAsistenteId { get; set; }
	public string? Descripcion { get; set; }
	public int? AbogadoAsignadoId { get; set; }
	public string? Tutelado { get; set; }
	public string? ProfesionalAsistente { get; set; }
	public bool MadridCapital { get; set; }
	public virtual Abogado? AbogadoAsistente { get; set; }
	public virtual Juzgado? Juzgado { get; set; }
	public virtual Tutelado? TuteladoNavigation { get; set; }

}
