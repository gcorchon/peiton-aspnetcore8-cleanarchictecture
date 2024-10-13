namespace Peiton.Core.Entities;
public class TipoObjetivo
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public bool MostrarEnAppMovil { get; set; }

	/* public virtual ICollection<AppMovilTarea> AppMovilTareas { get; } = new List<AppMovilTarea>(); */
	/* public virtual ICollection<ObjetivoSocial> ObjetivosSociales { get; } = new List<ObjetivoSocial>(); */
	/* public virtual ICollection<TuteladoObjetivo> TuteladosObjetivos { get; } = new List<TuteladoObjetivo>(); */

}
