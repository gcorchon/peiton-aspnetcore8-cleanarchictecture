namespace Peiton.Core.Entities;
public class AppMovilCita
{
	public int Id { get; set; }
	public int TuteladoId { get; set; }
	public int? AppMovilPeriodicidadId { get; set; }
	public string Titulo { get; set; } = null!;
	public string Descripcion { get; set; } = null!;
	public DateTime Fecha { get; set; }
	public DateTime? FechaBaja { get; set; }
	public virtual AppMovilPeriodicidad? AppMovilPeriodicidad { get; set; }
	public virtual Tutelado Tutelado { get; set; } = null!;

}
