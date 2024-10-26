namespace Peiton.Core.Entities;
public class Senalamiento
{
	public int Id { get; set; }
	public DateTime? Fecha { get; set; }
	public string? Procedimiento { get; set; }
	public int? JuzgadoId { get; set; }

	public int? AbogadoAsistenteId { get; set; }
	public string? Descripcion { get; set; }
	public int? AbogadoAsignadoId { get; set; }
	public string? Tutelado { get; set; }
	public string? ProfesionalAsistente { get; set; }
	public bool MadridCapital { get; set; }
	public virtual Abogado? AbogadoAsistente { get; set; }
	public virtual Abogado? AbogadoAsignado { get; set; }
	public virtual Juzgado? Juzgado { get; set; }

	//Hasta el 5 de Diciembre de 2017 se usaba una referencia a un tutelado, a saber qué cambio hubo entonces que dejó de usarse y solo guardamos el nombre del tutelado
	/*public int? TuteladoId { get; set; }	
	public virtual Tutelado? TuteladoNavigation { get; set; }*/

}
