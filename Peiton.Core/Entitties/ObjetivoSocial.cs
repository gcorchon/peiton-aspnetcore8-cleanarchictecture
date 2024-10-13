namespace Peiton.Core.Entities;
public class ObjetivoSocial
{
	public int Id { get; set; }
	public string Descripcion { get; set; } = null!;
	public int TipoObjetivoId { get; set; }
	public virtual TipoObjetivo TipoObjetivo { get; set; } = null!;
	/* public virtual ICollection<AppMovilTarea> AppMovilTareas { get; } = new List<AppMovilTarea>(); */
	/* public virtual ICollection<AppMovilTipoTarea> AppMovilTiposTareas { get; } = new List<AppMovilTipoTarea>(); */
	/* public virtual ICollection<TuteladoObjetivo> TuteladosObjetivos { get; } = new List<TuteladoObjetivo>(); */

}
