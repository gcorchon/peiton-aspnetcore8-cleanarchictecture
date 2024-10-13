namespace Peiton.Core.Entities;
public class TuteladoActividad
{
	public int TuteladoId { get; set; }
	public int ActividadId { get; set; }
	public int? ActividadLocalizacionId { get; set; }
	public virtual Actividad Actividad { get; set; } = null!;
	public virtual ActividadLocalizacion? ActividadLocalizacion { get; set; }
	public virtual Tutelado Tutelado { get; set; } = null!;

}
